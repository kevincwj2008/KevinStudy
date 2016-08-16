using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using XFCompany.Base.DB;
using System.Diagnostics;

namespace XFCompany.CIPnetWeb.DBOper
{
    /// <summary>
    /// 调用数据库访问接口的基类。此类本身主要用于增、删、改等数据库操作。
    /// </summary>
    public class BaseDBOper
    {
        #region 属性

        private DBOperator dboper;
        /// <summary>
        /// 数据库操作对象实例。
        /// </summary>
        public DBOperator DBOper
        {
            get { return dboper != null ? dboper : dboper = DBOperator.CreateInstance("SQLServer", "user id=sa;data source=192.168.0.3;persist security info=True;initial catalog=PIII_Person;password=Jykj000000;Connect Timeout=180;Max Pool Size=150;"); }
            set { dboper = value; }
        }

        #endregion

        #region 静态属性
        private static string dbType;
        /// <summary>
        /// 获取或设置数据库类型。
        /// </summary>
        public static string DBType
        {
            get { return dbType; }
            set { dbType = value; }
        }
        private static string connStr;
        /// <summary>
        /// 获取或设置数据库连接字符串。
        /// </summary>
        public static string ConnStr
        {
            get { return connStr; }
            set { connStr = value; }
        }
        /// <summary>
        /// 数据库访问接口对象。
        /// </summary>
        protected static DBOperator dbo
        {
            get { return DBOperator.CreateInstance(BaseDBOper.DBType, BaseDBOper.ConnStr); }
        }

        private static Dictionary<String, String[]> qname_sql;
        /// <summary>
        /// 获取查询用SQL语句名称与参数配对集合。
        /// </summary>
        protected static Dictionary<String, String[]> QNAME_SQL
        {
            get { return qname_sql != null ? qname_sql : qname_sql = InitParams_Q(); }
        }

        private static Dictionary<String, String[]> spname_params;
        /// <summary>
        /// 获取存储过程名称与参数配对集合。
        /// </summary>
        protected static Dictionary<String, String[]> SPNAME_PARAMS
        {
            get { return spname_params != null ? spname_params : spname_params = InitParams_SP(); }
        }

        #endregion

        #region 构造函数/初始化参数
        /// <summary>
        /// 
        /// </summary>
        public BaseDBOper()
        {
        }

        /// <summary>
        /// 初始化数据库类型、连接字符串、所有数据库访问SQL语句和存储过程。
        /// </summary>
        public static void InitDBParams(string dbtype, string connstr)
        {
            BaseDBOper.DBType = dbtype;
            BaseDBOper.ConnStr = connstr;

            InitParams_Q();
            InitParams_SP();
        }
        /// <summary>
        /// 初始化所有数据库访问SQL语句。
        /// </summary>
        private static Dictionary<string, string[]> InitParams_Q()
        {
            #region 数据库查询所需要的SQL语句，保存名称及参数
            Dictionary<string, string[]> qnames = new Dictionary<string, string[]>();
            //如以下方式
            //QNAME_SQL.Add("q_AddSendMail", new string[] { "Name", "Desc", "SendUserID", "UserID", "UserName", "FileName" });
            #endregion

            return qnames;
        }
        /// <summary>
        /// 初始化所有数据库访问存储过程。
        /// </summary>
        private static Dictionary<string, string[]> InitParams_SP()
        {
            #region 数据库查询所需要的存储过程，保存名称及参数
            Dictionary<string, string[]> spnames = new Dictionary<string, string[]>();
            spnames.Add("csp_GetUserDetail", new String[] { "@UserID" });
            spnames.Add("csp_GetUserDetailByAccessToken", new String[] { "@UserID", "@AccessToken" });

            #region 有关栏目、分类的存储过程
            spnames.Add("csp_GetChannels", new String[] { "@NeedTotalNum", "@BeginIndex", "@Count", "@Order" });
            spnames.Add("csp_GetChannelDetail", new String[] { "@ChannelID" });
            spnames.Add("csp_GetInfoCountByChannel", new String[] { "@ChannelID" });

            spnames.Add("csp_GetPortalCatalogs", new String[] { "@NeedTotalNum", "@BeginIndex", "@Count", "@Order" });
            spnames.Add("csp_GetAreas", new String[] { "@NeedTotalNum", "@BeginIndex", "@Count", "@Order" });
            spnames.Add("csp_GetTags", new String[] { "@NeedTotalNum", "@BeginIndex", "@Count", "@Order" });
            spnames.Add("csp_GetProjectApplicationCatalog", new String[] { "@NeedTotalNum", "@BeginIndex", "@Count", "@Order" });
            spnames.Add("csp_GetSupportPolicyCatalog", new String[] { "@NeedTotalNum", "@BeginIndex", "@Count", "@Order" });
            #endregion
            #region 有关栏目内容的存储过程
            spnames.Add("csp_GetInformation", new String[] { "@NeedTotalNum", "@BeginIndex", "@Count", "@Status", "@ChannelID", "@KeyWords", "@IsHasImage", "@Order" });
            #endregion

            #region 有关服务首页显示的存储过程
            spnames.Add("csp_GetServiceHomeShow", new String[] { "@NeedTotalNum", "@BeginIndex", "@Count" });
            spnames.Add("csp_DeleteServiceHomeShow", new String[] { "@ServiceHomeShowID" });
            spnames.Add("csp_UpdateServiceHomeShowOrder", new String[] { "@ServiceHomeShowID", "@NewOrder" });
            #endregion

            #region 有关最新入驻商铺
            spnames.Add("csp_GetShopHomeShow", new String[] { "@NeedTotalNum", "@BeginIndex", "@Count" });
            spnames.Add("csp_DeleteShopHomeShow", new String[] { "@ShopHomeShowID" });
            spnames.Add("csp_UpdateShopHomeShowOrder", new String[] { "@ShopHomeShowID", "@NewOrder" });
            #endregion

            #region 有关广告、广告位的存储过程
            spnames.Add("csp_GetAdPosition", new String[] { "@NeedTotalNum", "@BeginIndex", "@Count", "@Order" });
            spnames.Add("csp_GetAd", new String[] { "@NeedTotalNum", "@BeginIndex", "@Count", "@Status", "@Platform", "@AdPosition", "@IsExpired", "@KeyWords", "@Order" });
            spnames.Add("csp_GetAdDetail", new String[] { "@AdID" });
            #endregion

            #region 政务支撑
            spnames.Add("csp_GetPolicyContentDetail", new String[] { "@PolicyContentID" });
            spnames.Add("csp_GetPolicyContent", new String[] { "@NeedTotalNum", "@BeginIndex", "@Count", "@KeyWords", "@Order", "@PolicyContentType" });
            spnames.Add("csp_GetPolicyEffect", new String[] { "@PolicyEffectType" });
            #endregion

            #region 项目申报
            spnames.Add("csp_GetProjectApplicationDetail", new String[] { "@ProjectApplicationID" });
            spnames.Add("csp_GetProjectApplication", new String[] { "@NeedTotalNum", "@BeginIndex", "@Count", "@Status", "@Path", "@Order", "@KeyWords" });

            #endregion

            #region 项目申报
            spnames.Add("csp_GetSupportPolicyDetail", new String[] { "@SupportPolicyID" });
            spnames.Add("csp_GetSupportPolicy", new String[] { "@NeedTotalNum", "@BeginIndex", "@Count", "@Status", "@Path", "@Order", "@KeyWords" });

            #endregion
            #region 有关创新信息锁定信息的存储过程
            spnames.Add("csp_GetLockInfo", new String[] { "@NeedTotalNum", "@BeginIndex", "@Count", "@KeyWords", "@Order" });
            spnames.Add("csp_GetLockInfoDetail", new String[] { "@LockInfoID" });
            #endregion

            #region 有关友情链接的存储过程。
            spnames.Add("csp_GetFriendLink", new String[] { "@NeedTotalNum", "@BeginIndex", "@Count", "@Status", "@Platform", "@Type", "@KeyWords", "@Order" });
            spnames.Add("csp_GetFriendLinkDetail", new String[] { "@FriendLinkID" });
            #endregion

            #region 有关人才
            spnames.Add("csp_GetPerson", new String[] { "@NeedTotalNum", "@BeginIndex", "@Count", "@PortalCatalogID", "@KeyWords", "@Order" });
            spnames.Add("csp_GetPersonDetail", new String[] { "@PersonID" });
            #endregion

            #region 有关政策的
            spnames.Add("csp_GetPolicy", new String[] { "@NeedTotalNum", "@BeginIndex", "@Count", "@KeyWords", "@Order" });
            spnames.Add("csp_GetPolicyByIds", new String[] { "@PIDs" });
            #endregion

            #region 有关区域平台的存储过程。
            spnames.Add("csp_GetRegionalPlatformDetail", new String[] { "@RegionalPlatformID" });
            spnames.Add("csp_GetRegionalPlatform", new String[] { "@NeedTotalNum", "@BeginIndex", "@Count", "@KeyWords", "@Order" });
            #endregion

            #region 有关区域活动平台的存储过程。
            spnames.Add("csp_GetRegionalPlatformActivityDetail", new String[] { "@RegionalPlatformActivityID" });
            spnames.Add("csp_GetRegionalPlatformActivity", new String[] { "@NeedTotalNum", "@BeginIndex", "@Count", "@KeyWords", "@Order" });
            #endregion

            #region 有关专业平台的存储过程。
            spnames.Add("csp_GetSpecialtyPlatformDetail", new String[] { "@SpecialtyPlatformID" });
            spnames.Add("csp_GetSpecialtyPlatform", new String[] { "@NeedTotalNum", "@BeginIndex", "@Count", "@KeyWords", "@Order" });
            #endregion

            #region 有关热点的存储过程
            spnames.Add("csp_GetHotInfo", new String[] { "@NeedTotalNum", "@BeginIndex", "@Count", "@KeyWords", "@Order" });
            spnames.Add("csp_GetHotInfoDetail", new String[] { "@HotInfoID" });
            #endregion

            #region 有关动态的存储过程
            spnames.Add("csp_GetDynamic", new String[] { "@NeedTotalNum", "@BeginIndex", "@Count", "@PortalCatalogID", "@KeyWords", "@Order" });
            spnames.Add("csp_GetDynamicDetail", new String[] { "@DynamicID" });
            #endregion

            #region 服务与门户的存储过程
            spnames.Add("csp_GetServicePortalCatalog", new String[] { "@NeedTotalNum", "@BeginIndex", "@Count", "@PortalCatalogID", "@Order" });
            spnames.Add("csp_GetServicePortalCatalogDetail", new String[] { "@ServiceID" });

            #endregion

            #region 商铺与门户
            spnames.Add("csp_GetShopPortalCatalog", new String[] { "@NeedTotalNum", "@BeginIndex", "@Count", "@PortalCatalogID", "@AreaID", "@Order" });
            #endregion

            #region 融资的存储过程
            spnames.Add("csp_GetFinancingIntention", new String[] { "@NeedTotalNum", "@BeginIndex", "@Count", "@KeyWords", "@Order" });
            spnames.Add("csp_GetFinancingIntentionDetail", new String[] { "@PID" });
            #endregion

            spnames.Add("csp_UpdateServiceSortOrder", new String[] { "@ServiceID", "@NewOrder" });
            spnames.Add("csp_GetServiceSort", new String[] { "@NeedTotalNum", "@BeginIndex", "@SortType", "@Count" });

            #region 视频的存储过程

            spnames.Add("csp_GetResourcesVideo", new String[] { "@NeedTotalNum", "@BeginIndex", "@Count", "@Status", "@CatalogID", "@KeyWords", "@Order" });
            spnames.Add("csp_GetResourcesVideoDetail", new String[] { "@ResID" });


            #endregion

            #region 分类目录的存储过程

            spnames.Add("sp_GetCatalogByPath", new String[] { "@NeedTotalNum", "@Path", "@BeginIndex", "@Count", "@Order" });
            spnames.Add("sp_GetCatalogDetailByCatalogID", new String[] { "@ID" });
            spnames.Add("sp_GetCatalogDetailByPath", new String[] { "@Path" });

            #endregion

            #region 有关标签
            spnames.Add("csp_ShopAddTags", new String[] { "@ShopId", "@PortalCatalogIds", "@Weight", "@TagsPath", "@ShopName" });
            spnames.Add("csp_DeleteShopTags", new String[] { "@ShopId" });
            spnames.Add("csp_ServiceAddTags", new String[] { "@ServiceId", "@ShopId", "@Weight", "@TagsPath", "@ServiceName" });
            spnames.Add("csp_GetPortalCatalogShop", new String[] { "@NeedTotalNum", "@BeginIndex", "@Count", "@PortalCatalog", "@TagsPath", "@keywords", "@ServiceTagsPath", "@SearchType" });
            spnames.Add("csp_GetPortalCatalogService", new String[] { "@NeedTotalNum", "@BeginIndex", "@Count", "@ShopId", "@TagsPath", "@PortalCatalog", "@keywords" });
            spnames.Add("csp_GetShopTags", new String[] { "@ShopIds" });
            spnames.Add("csp_GetServiceTags", new String[] { "@ServiceIds" });
            #endregion

            #region 用户收藏课件、资源
            spnames.Add("csp_GetUserResources", new String[] { "@NeedTotalNum", "@BeginIndex", "@Count", "@UserID", "@KeyWords", "@StartDate", "@EndDate", "@Order" });
            spnames.Add("csp_GetIsCollectionResources", new String[] { "@UserID", "@ResID" });
            #endregion

            #region 企业级众创网络空间
            spnames.Add("csp_GetES_InformationDetail", new String[] { "@PID" });
            spnames.Add("csp_InsetES_EnterpriseChannel", new string[] { "@TemplateID", "@EnterpriseID" });
            spnames.Add("csp_GetES_InformationList", new string[] { "@NeedTotalNum", "@BeginIndex", "@Count", "@EspriseGuid", "@Catalogid", "@KeyWords", "@StartTime", "@EndTime", "@Ordrby", "@Status" });
            spnames.Add("csp_GetES_EnterpriseDetail", new String[] { "@PID" });
            spnames.Add("csp_GetES_EnterpriseList", new String[] { "@NeedTotalNum", "@BeginIndex", "@Count", "@Nature", "@Scale", "@Status", "@KeyWords", "@Ordrby" });
            spnames.Add("csp_GetES_EnterpriseChannelList", new String[] { "@EnterprisID"});
            spnames.Add("csp_GetES_EnterpriseChannelDetail", new String[] { "@PID" });
            spnames.Add("csp_GetES_CatalogList", new String[] { "@NeedTotalNum", "@BeginIndex", "@Count", "@KeyWords", "@Status", "@EnterpriseID" });
            spnames.Add("csp_GetES_CatalogDetail", new String[] { "@PID" });
            spnames.Add("csp_GetES_Enterprise_UserList", new String[] { "@NeedTotalNum", "@BeginIndex", "@Count", "@Status", "@EnterpriseID","@UserId" ,"@Orderby" });
            spnames.Add("csp_GetES_Enterprise_EmailUserList", new String[] { "@NeedTotalNum", "@BeginIndex", "@Count", "@EnterpriseID", "@UserID", "@Orderby" });
            spnames.Add("csp_GetEnterpriseInviteEmailUser", new string[] { "@EnterpriseID", "@Email" });//判断企业是否邀请该Email
            #endregion
            return spnames;
            #endregion
        }

        #endregion

        #region 增加、删除、修改等通用数据操作方法。
        /// <summary>
        /// 开始一个数据库事务。
        /// </summary>
        public void BeginTransaction()
        {
            this.DBOper.BeginTransaction();
        }
        /// <summary>
        /// 提交数据库事务。
        /// </summary>
        public void Commit()
        {
            this.DBOper.Commit();
        }
        /// <summary>
        /// 回滚数据库事务。
        /// </summary>
        public void Rollback()
        {
            try
            {
                this.DBOper.Rollback();
            }
            catch (System.Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// 事务执行结束时，释放事务资源。
        /// </summary>
        public void ReleaseTransaction()
        {
            this.DBOper.ReleaseTransaction();
        }


        /// <summary>
        ///  根据表名、字段名、字段值组合并执行添加SQL语句。
        /// </summary>
        /// <param name="TableName">要添加记录的表名称。</param>
        /// <param name="FieldNames">要添加记录的字段名。</param>
        /// <param name="FieldValues">要添加记录的字段值。</param>
        public bool DoInsert(string TableName, string[] FieldNames, object[] FieldValues)
        {
            StringBuilder Sql = new StringBuilder();
            if (!string.IsNullOrEmpty(TableName) && FieldNames.Length != 0 && FieldNames.Length == FieldValues.Length)
            {
                StringBuilder str = new StringBuilder();
                StringBuilder obj = new StringBuilder();
                for (int i = 0; i < FieldNames.Length; i++)
                {
                    str.Append("[" + FieldNames[i] + "],");
                    obj.Append("@" + FieldNames[i] + ",");
                    if (FieldValues[i] == null)
                    {
                        FieldValues[i] = "";
                    }
                }
                if (str.ToString().IndexOf(",") != -1)
                    str.Remove(str.ToString().LastIndexOf(","), 1);
                if (obj.ToString().IndexOf(",") != -1)
                    obj.Remove(obj.ToString().LastIndexOf(","), 1);

                Sql.Append("Insert Into [" + TableName + "] (" + str + ") values (" + obj + ")");
                try
                {
                    int t = this.DBOper.ExecuteSql(Sql.ToString(), FieldNames, FieldValues);
                    if (t > 0)
                        return true;
                }
                catch (System.Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    return false;
                }
            }
            return false;
        }

        /// <summary>
        ///  根据表名、字段名、字段值组合并执行修改SQL语句。
        /// </summary>
        /// <param name="TableName">要添加记录的表名称。</param>
        /// <param name="FieldNames">要添加记录的字段名数组。</param>
        /// <param name="FieldValues">要添加记录的字段值数组。</param>
        /// <param name="FieldsNamesWhere">要修改记录的条件字段名数组。</param>
        /// <param name="FieldsValuesWhere">要修改记录的条件字段值数组。</param>
        /// <returns>成功返回true，否则返回false。</returns>
        public bool DoUpdate(string TableName, string[] FieldNames, object[] FieldValues, string[] FieldsNamesWhere, object[] FieldsValuesWhere)
        {
            StringBuilder Sql = new StringBuilder();
            if (!string.IsNullOrEmpty(TableName) && FieldNames.Length != 0 && FieldNames.Length == FieldValues.Length && FieldsNamesWhere.Length == FieldsValuesWhere.Length)
            {
                StringBuilder str = new StringBuilder();
                for (int i = 0; i < FieldNames.Length; i++)
                {
                    str.Append("[" + FieldNames[i] + "]=@" + FieldNames[i] + ",");
                    if (FieldValues[i] == null)
                    {
                        FieldValues[i] = "";
                    }
                }
                if (str.ToString().IndexOf(",") != -1)
                    str.Remove(str.ToString().LastIndexOf(","), 1);

                StringBuilder str_w = new StringBuilder();
                for (int i = 0; i < FieldsNamesWhere.Length; i++)
                    str_w.Append(" and [" + FieldsNamesWhere[i] + "]=@" + FieldsNamesWhere[i]);

                string[] AllField = new string[FieldNames.Length + FieldsNamesWhere.Length];
                object[] AllValue = new object[FieldValues.Length + FieldsValuesWhere.Length];
                int index = 0;
                for (; index < FieldNames.Length; index++)
                {
                    AllField[index] = FieldNames[index];
                    AllValue[index] = FieldValues[index];
                }
                for (; (index - FieldNames.Length) < FieldsNamesWhere.Length; index++)
                {
                    AllField[index] = FieldsNamesWhere[index - FieldNames.Length];
                    AllValue[index] = FieldsValuesWhere[index - FieldNames.Length];
                }

                Sql.Append("Update [" + TableName + "] Set " + str + " Where 1=1 " + str_w.ToString());
                try
                {
                    int t = this.DBOper.ExecuteSql(Sql.ToString(), AllField, AllValue);
                    if (t > 0)
                        return true;
                }
                catch (System.Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    return false;
                }
            }
            return false;
        }

        /// <summary>
        ///  根据表名、字段名、字段值组合并执行修改SQL语句。
        /// </summary>
        /// <param name="TableName">要添加记录的表名称。</param>
        /// <param name="FieldNames">要添加记录的字段名数组。</param>
        /// <param name="FieldValues">要添加记录的字段值数组。</param>
        /// <param name="WhereSQL">条件字符串。"where"之后的语句，不需要再加where关键词。</param>
        /// <returns>成功返回true，否则返回false。</returns>
        public bool DoUpdate(string TableName, string[] FieldNames, object[] FieldValues, string WhereSQL)
        {
            StringBuilder Sql = new StringBuilder();
            if (!string.IsNullOrEmpty(TableName) && FieldNames.Length != 0 && FieldNames.Length == FieldValues.Length)
            {
                StringBuilder str = new StringBuilder();
                for (int i = 0; i < FieldNames.Length; i++)
                {
                    str.Append("[" + FieldNames[i] + "]=@" + FieldNames[i] + ",");
                    if (FieldValues[i] == null)
                    {
                        FieldValues[i] = "";
                    }
                }
                if (str.ToString().IndexOf(",") != -1)
                    str.Remove(str.ToString().LastIndexOf(","), 1);

                Sql.Append("Update [" + TableName + "] Set " + str);
                if (!String.IsNullOrEmpty(WhereSQL))
                {
                    Sql.Append(" where " + WhereSQL);
                }
                try
                {
                    int t = this.DBOper.ExecuteSql(Sql.ToString(), FieldNames, FieldValues);
                    if (t > 0)
                        return true;
                }
                catch (System.Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    return false;
                }
            }
            return false;
        }

        /// <summary>
        ///  根据表名、条件名和条件值组合并执行删除SQL语句。
        /// </summary>
        /// <param name="TableName">要删除的表名称。</param>
        /// <param name="FieldNames">条件字段名数组。</param>
        /// <param name="FieldValues">条件字段值数组。</param>
        public bool DoDelete(string TableName, string[] FieldNames, object[] FieldValues)
        {
            StringBuilder Sql = new StringBuilder();
            Sql.Append("Delete [" + TableName + "] Where 1=1  ");

            if (FieldNames.Length == FieldValues.Length)
            {
                for (int i = 0; i < FieldNames.Length; i++)
                    Sql.Append(" and [" + FieldNames[i] + "]= @" + FieldNames[i]);
                try
                {
                    DBOper.ExecuteSql(Sql.ToString(), FieldNames, FieldValues);
                    return true;
                }
                catch (System.Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    return false;
                }
            }
            return false;
        }

        /// <summary>
        ///  根据表名、条件值组合并执行删除SQL语句。
        /// </summary>
        /// <param name="TableName">要删除的表名称。</param>
        /// <param name="DeleteWhere">删除的条件(不包括Where)。</param>
        public bool DoDelete(string TableName, string DeleteWhere)
        {
            StringBuilder Sql = new StringBuilder();
            Sql.Append("Delete [" + TableName + "] Where " + DeleteWhere);
            try
            {
                int t = this.DBOper.ExecuteSql(Sql.ToString());
                if (t > 0)
                    return true;
            }
            catch (System.Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
            return false;
        }

        /// <summary>
        ///  根据表名、条件值组合并执行删除SQL语句，数据库里无数据删除时返回True。
        /// </summary>
        /// <param name="TableName">要删除的表名称。</param>
        /// <param name="DeleteWhere">删除的条件(不包括Where)。</param>
        public bool DoDeleteNoDate(string TableName, string DeleteWhere)
        {
            StringBuilder Sql = new StringBuilder();
            Sql.Append("Delete [" + TableName + "] Where " + DeleteWhere);
            try
            {
                int t = this.DBOper.ExecuteSql(Sql.ToString());
                if (t >= 0)
                    return true;
            }
            catch (System.Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
            return false;
        }

        /// <summary>
        ///  根据表名、条件名和条件值组合并执行查询SQL语句。
        /// </summary>
        /// <param name="TableName">要查询的表名称。</param>
        /// <param name="SelectWhere">查询条件。</param>
        public int DoSelectCount(string TableName, string SelectWhere)
        {
            StringBuilder Sql = new StringBuilder();
            Sql.Append("select count(*) from [" + TableName + "] Where " + SelectWhere);
            int Count = 0;
            try
            {
                Count = Convert.ToInt32(this.DBOper.ExecuteSqlScalar(Sql.ToString()));
            }
            catch (System.Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Count = 0;
            }
            return Count;
        }


        /// <summary>
        ///  根据表名、条件名和条件值组合并执行查询SQL语句。
        /// </summary>
        /// <param name="TableName">要查询的表名称。</param>
        /// <param name="FieldNames">条件字段名数组。</param>
        /// <param name="FieldValues">条件字段值数组。</param>
        public int DoSelectCount(string TableName, string[] FieldNames, object[] FieldValues)
        {
            StringBuilder Sql = new StringBuilder();
            Sql.Append("select count(*) from [" + TableName + "] Where 1=1  ");
            int Count = 0;
            if (FieldNames.Length == FieldValues.Length)
            {
                for (int i = 0; i < FieldNames.Length; i++)
                    Sql.Append(" and [" + FieldNames[i] + "]= @" + FieldNames[i]);
                try
                {
                    Count = Convert.ToInt32(this.DBOper.ExecuteSqlScalar(Sql.ToString(), FieldNames, FieldValues));
                }
                catch (System.Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    Count = 0;
                }
            }
            return Count;
        }
        #endregion

        #region 提供一些直接执行SQL语句的方法，尽量不要在程序中直接使用。
        /// <summary>
        /// 直接执行SQL语句，尽量不要使用。
        /// </summary>
        /// <param name="sql">sql语句。</param>
        /// <returns>成功返回true，失败返回false。</returns>
        public static bool RunSQL(string sql)
        {
            try
            {
                return dbo.ExecuteSql(sql) > 0 ? true : false;
            }
            catch (System.Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
        }
        /// <summary>
        /// 直接执行SQL语句，尽量不要使用。
        /// </summary>
        /// <param name="sql">SQL语句。</param>
        /// <returns>结果集，若执行SQL语句出现异常，则返回null。</returns>
        public static DataTable DoQuery(string sql)
        {
            try
            {
                return dbo.ExecuteSqlToDataTable(sql);
            }
            catch (System.Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }
        #endregion
    }
}
