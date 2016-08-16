using System;
using XFCompany.CIPNet.GlobalSetting;
using System.Text;
using System.Data;
using XFCompany.CIPnetWeb.DBOper;
using Newtonsoft.Json;

namespace XFCompany.CIPnetWeb.LogicModel
{
    /// <summary>
    /// 信息类。
    /// </summary>
    public class Information : EntityBase
    {
        #region 常量
        public const String CTBName_Information = "CTB_Information";
        public const string CTBName_Channel = "CTB_Channel";
        #endregion

        #region 属性
        /// <summary>
        /// 信息编号
        /// </summary>
        [UIText("信息编号")]
        public Guid PID { get; set; }

        /// <summary>
        /// 信息标题
        /// </summary>
        [UIText("信息标题")]
        public String Name { get; set; }

        /// <summary>
        /// 信息摘要
        /// </summary>
        [UIText("信息摘要")]
        public String Abstract { get; set; }

        /// <summary>
        /// 信息内容
        /// </summary>
        [UIText("信息内容")]
        public String Description { get; set; }

        /// <summary>
        /// 栏目编号
        /// </summary>
        [UIText("栏目编号")]
        public Guid ChannelID { get; set; }

        /// <summary>
        /// 栏目名称
        /// </summary>
        [UIText("栏目名称")]
        public string ChannelName { get; set; }

        /// <summary>
        /// 权重
        /// </summary>
        [UIText("权重")]
        public int Weight { get; set; }

        /// <summary>
        /// 信息状态
        /// </summary>
        [UIText("信息状态")]
        public EnumInformationStatus Status { get; set; }

        /// <summary>
        /// 发布时间
        /// </summary>
        [UIText("发布时间")]
        public DateTime Createtime { get; set; }

        public EnumInformationHasImage IsHasImage { get; set; }
        #endregion

        #region 构造函数
        public Information()
        { }

        public Information(Guid InformationID)
        {
            this.PID = InformationID;
        }

        public Information(Guid _pid,string _name,string _description)
        {
            this.PID = _pid;
            this.Name = _name;
            this.Description = _description;
        }
        #endregion

        #region 操作函数
        /// <summary>
        /// 验证插入的数据字段是否合法
        /// </summary>
        /// <returns></returns>
        private bool Validate()
        {
            bool bFlag = false;
            Type t = this.GetType();
            string strErrTemp = "";
            bFlag = new StringCheck(this.Name, 1, (int)DBStringLen.XFString100).Check(out strErrTemp);
            if (!bFlag)
            {
                this.LastErr = Helper.GetUIText(t, t.GetMember("Name")[0]) + strErrTemp;
                return bFlag;
            }

            bFlag = new StringCheck(this.Abstract, 0, (int)DBStringLen.XFString600).Check(out strErrTemp);
            if (!bFlag)
            {
                this.LastErr = Helper.GetUIText(t, t.GetMember("Abstract")[0]) + strErrTemp;
                return bFlag;
            }
            return true;
        }

        /// <summary>
        /// 添加信息
        /// </summary>
        /// <returns></returns>
        public bool Insert()
        {
            if (!Validate())
                return false;
            return DBOper.DoInsert(CTBName_Information,
                new string[] { "PID", "Name", "Abstract", "Description", "Weight", "Status", "ChannelID", "IsHasImage" },
                new object[] { this.PID, this.Name, this.Abstract, this.Description, this.Weight, (int)this.Status, this.ChannelID, (int)this.IsHasImage });
        }

        /// <summary>
        /// 修改信息。
        /// </summary>
        /// <returns></returns>
        public bool Update()
        {
            if (!Validate())
                return false;
            return DBOper.DoUpdate(CTBName_Information,
                new string[] { "Name", "Abstract", "Description", "Weight", "Status", "ChannelID", "IsHasImage" },
                new object[] { this.Name, this.Abstract, this.Description, this.Weight, (int)this.Status, this.ChannelID, (int)this.IsHasImage }, new string[] { "PID" }, new object[] { this.PID });
        }

        /// <summary>
        /// 删除信息。
        /// </summary>
        /// <returns></returns>
        public bool Delete(Guid[] InformationIDs)
        {
            if (InformationIDs == null || InformationIDs.Length == 0)
                return true;
            StringBuilder wherestr = new StringBuilder();
            foreach (Guid tempInfoID in InformationIDs)
                wherestr.Append("[PID] = '" + tempInfoID.ToString() + "' or");
            if (wherestr.Length > 0)
            {
                wherestr = wherestr.Remove(wherestr.Length - 2, 2);
                return DBOper.DoDelete(CTBName_Information, wherestr.ToString());
            }
            else
                return false;
        }

        /// <summary>
        /// 获取信息详细。
        /// </summary>
        /// <returns></returns>
        public override bool GetDetail()
        {
            DataTable DetailDt = this.dbo.ExecuteSqlToDataTable("SELECT i.*,c.Name as ChannelName FROM "+CTBName_Information+" as i left join "+CTBName_Channel+" as c on i.ChannelID=c.PID WHERE i.PID='"+this.PID+"'");
            if (DetailDt != null && DetailDt.Rows.Count != 0)
            {
                EntityBase.Copy(this, DetailDt);
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
    }
}
