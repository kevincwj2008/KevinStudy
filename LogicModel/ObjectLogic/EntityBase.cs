using System;
using System.Text;
using System.Reflection;
using System.Data;
using XFCompany.CIPnetWeb.DBOper;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace XFCompany.CIPnetWeb.LogicModel
{
    /// <summary>
    /// 实体对象的基类。
    /// </summary>
    [Serializable]
    public class EntityBase
    {   
        /// <summary>
        /// 执行过程中的最后错误信息
        /// </summary>
        [NonSerialized]
        private String lastErr = String.Empty;
        /// <summary>
        /// 获取执行过程中的最后错误信息。
        /// </summary>
        public String LastErr
        {
            protected set { lastErr = value; }
            get { return lastErr; }
        }
        [NonSerialized]
        private BaseDBOper dboper;
        /// <summary>
        /// 获得一个数据库操作对象。此对象可以执行事务操作。
        /// </summary>
        internal BaseDBOper DBOper
        {
            get { return dboper != null? dboper : dboper = new BaseDBOper(); }
            set { dboper = value; }
        }

        /// <summary>
        /// 获取一个直接执行sql的DBOperator对象。
        /// </summary>
        [NonSerialized]
        protected XFCompany.Base.DB.DBOperator dbo;

        /// <summary>
        /// 构造函数。
        /// </summary>
        protected EntityBase()
        {
            //CS程序使用在创建实体类时可能不需要数据库链接
            if (!string.IsNullOrEmpty(BaseDBOper.DBType) && !string.IsNullOrEmpty(BaseDBOper.ConnStr))
            {
                dbo = new BaseDBOper().DBOper;
            }
        }

        /// <summary>
        /// 拷贝实体对象。新实体对象应该与旧实体对象类型一致，或者是旧实体对象的派生子类。
        /// </summary>
        /// <param name="newEntity">新实体对象。</param>
        /// <param name="oldEntity">旧实体对象。</param>
        public static void Copy(EntityBase newEntity, EntityBase oldEntity)
        {
            if (oldEntity == null || newEntity == null)
            {
                return;
            }
            try
            {
                foreach (PropertyInfo pi in oldEntity.GetType().GetProperties())
                {
                    pi.SetValue(newEntity, pi.GetValue(oldEntity, null), null);
                }
            }
            catch
            {
                return;
            }            
        }
        /// <summary>
        /// 从DataTable中复制一个实体对象。新实体对象属性应该与DataTable中的列名一致。
        /// </summary>
        /// <param name="newEntity">新实体对象。</param>
        /// <param name="dtEntity">原数据。</param>
        public static void Copy(EntityBase newEntity, DataTable dtEntity)
        {
            if (dtEntity == null || dtEntity.Rows.Count == 0)
            {
                return;
            }

            Copy(newEntity, dtEntity.Rows[0]);
        }

        /// <summary>
        /// 从DataRow中复制一个实体对象。新实体对象属性应该与DataTable中的列名一致。
        /// </summary>
        /// <param name="newEntity">新实体对象。</param>
        /// <param name="drEntity">原数据。</param>
        public static void Copy(EntityBase newEntity, DataRow drEntity)
        {
            if (drEntity == null)
            {
                return;
            }

            foreach (DataColumn col in drEntity.Table.Columns)
            {
                try
                {
                    string piName = col.ColumnName;
                    newEntity.SetValue(piName, drEntity[piName]);
                    //PropertyInfo pi = newEntity.GetType().GetProperty(piName);
                    //pi.SetValue(newEntity, dtEntity.Rows[0][piName], null);
                }
                catch
                {
                    continue;
                }
            }
        }

        /// <summary>
        /// 从DataRow中复制一个实体对象。新实体对象属性应该与DataTable中的列名一致。
        /// </summary>
        /// <param name="newEntity">新实体对象。</param>
        /// <param name="drEntity">原数据。</param>
        public static void Copy(EntityBase newEntity, JObject jobject)
        {
            if (jobject == null)
            {
                return;
            }

            IEnumerator<KeyValuePair<String, JToken>> ie = jobject.GetEnumerator();
            while (ie.MoveNext())
            {
                try
                {
                    string piName = ie.Current.Key;
                    newEntity.SetValue(piName, ie.Current.Value.ToObject<Object>());
                }
                catch
                {
                    continue;
                }
            }
        }

        /// <summary>
        /// 通过字段名，得到该字段名对应的属性值。
        /// </summary>
        /// <param name="fieldName">字段名。</param>
        /// <returns>属性值。若没有找到相应的属性，则返回null。</returns>
        public object GetValue(string fieldName)
        {
            if (String.IsNullOrEmpty(fieldName))
            {
                return null;
            }
            try
            {
                PropertyInfo pi = this.GetType().GetProperty(fieldName);
                if (pi != null)
                {
                    return pi.GetValue(this, null);
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// 通过字段名，设置该字段名对应的属性值。
        /// </summary>
        /// <param name="fieldName">字段名。</param>
        /// <param name="value">要设置的属性值。</param>
        /// <returns>true设置成功；false设置失败。</returns>
        public bool SetValue(string fieldName, object value)
        {
            if (String.IsNullOrEmpty(fieldName))
            {
                return false;
            }
            try
            {
                PropertyInfo pi = this.GetType().GetProperty(fieldName, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
                if (pi != null)
                {
                    if (value == null)
                    {
                        pi.SetValue(this, null, null);
                        return true;
                    }
                    if (pi.PropertyType.Name == "String")
                    {
                        value = value.ToString().Trim();
                    }
                    if (pi.PropertyType.Name == "Guid")
                    {
                        value = Guid.Parse(value.ToString());
                    }
                    else if (pi.PropertyType.Name == "DateTime" && value.ToString().Trim() == "")
                    {
                        pi.SetValue(this, null, null);
                        return true;
                    }
                    else if (pi.PropertyType.IsEnum)
                    {
                        if (value.GetType().Name == "Boolean")
                        {
                            pi.SetValue(this, Enum.ToObject(pi.PropertyType, ((bool)value)?1:0), null);
                        }
                        else
                        {
                            int iValue=-1;
                            if (int.TryParse(value.ToString(), out iValue))
                            {
                                pi.SetValue(this, Enum.ToObject(pi.PropertyType, iValue), null);
                            }
                            else
                            {
                                pi.SetValue(this, Enum.ToObject(pi.PropertyType, value), null);
                            }
                        }
                        return true;
                    }
                    pi.SetValue(this, Convert.ChangeType(value, pi.PropertyType), null);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 获取实体对象详细信息。
        /// </summary>
        public virtual bool GetDetail()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 将当前实体对象插入到对应的数据库表中。
        /// </summary>
        public virtual bool InsertSelf()
        {
            return true;
        }
        /// <summary>
        /// 将当前实体对象更新到对应的数据库表中。
        /// </summary>
        public virtual bool UpdateSelf()
        {
            return true;
        }

        /// <summary>
        /// 将当前实体对象更新到对应的数据库表中。
        /// </summary>
        public virtual bool UpdateSelf(string[] fieldNames)
        {
            return true;
        }

        /// <summary>
        /// 比较当前对象与给定对象的公有属性有哪些值不一样，将不一样的字段以逗号分隔的字符串返回。
        /// </summary>
        /// <param name="entity">用于比较的对象。</param>
        /// <returns>值不同的属性名组成的字符串，以逗号分隔。</returns>
        public string CompareTo(EntityBase entity)
        {
            StringBuilder fields = new StringBuilder();
            if (entity == null || entity.GetType() != this.GetType())
            {
                return String.Empty;
            }
            PropertyInfo[] pis = this.GetType().GetProperties();
            foreach (PropertyInfo pi in pis)
            {
                if (pi.GetValue(this, null) != pi.GetValue(entity, null))
                {
                    fields.Append(pi.Name + ",");
                }
            }
            return fields.ToString();
        }
        /// <summary>
        /// 处理排序的字符串。
        /// </summary>
        /// <param name="orderstr">需要处理的字符串，多个排序方式用“,”连接。</param>
        /// <returns></returns>
        public static string CreateOrderbyStr(string orderstr)
        {
            string Orderbys = string.Empty;
            if (String.IsNullOrEmpty(orderstr))
                return "";
            else
            {
                String[] strarr = orderstr.Split(new String[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < strarr.Length; i++)
                {
                    if (strarr[i].Substring(strarr[i].Length - 4, 4).ToLower() == "desc")
                    {
                        Orderbys += ",";
                        Orderbys += strarr[i].Substring(0, strarr[i].Length - 4);
                        Orderbys += " desc";
                    }
                    else
                    {
                        Orderbys += ",";
                        Orderbys += strarr[i].Substring(0, strarr[i].Length - 3);
                        Orderbys += " asc";
                    }
                }
                return Orderbys.Substring(1);
            }
        }
    }
}
