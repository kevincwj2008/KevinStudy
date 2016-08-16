using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using XFCompany.CIPNet.GlobalSetting;
using XFCompany.CIPnetWeb.DBOper;

namespace XFCompany.CIPnetWeb.LogicModel
{   
    /// <summary>
    ///视频类
    /// </summary>
    public class ResourcesVideo : Resources
    {
        #region 常量
        public const String TBName_ResourcesVideo = "TB_Resources_Video";
        #endregion

        #region 属性
        /// <summary>
        /// 视频编号
        /// </summary>
        [UIText("视频编号")]
        public Guid ResID { get; set; }
        /// <summary>
        /// 视频摘要
        /// </summary>
        [UIText("视频摘要")]
        public String Abstract { get; set; }

        /// <summary>
        /// 图片
        /// </summary>
        [UIText(" 图片")]
        public String Img { get; set; }
        /// <summary>
        /// 发布时间
        /// </summary>
        [UIText("发布时间")]
        public DateTime Pubdate { get; set; }
      
        #endregion

        #region 构造函数
        public ResourcesVideo()
        { }

        public ResourcesVideo(Guid ResID)
        {
            this.ResID = ResID;
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
            bFlag = new StringCheck(this.Abstract, 0, (int)DBStringLen.XFString300).Check(out strErrTemp);
            if (!bFlag)
            {
                this.LastErr = Helper.GetUIText(t, t.GetMember("Abstract")[0]) + strErrTemp;
                return bFlag;
            }
            bFlag = new StringCheck(this.Img, 0, (int)DBStringLen.XFString600).Check(out strErrTemp);
            if (!bFlag)
            {
                this.LastErr = Helper.GetUIText(t, t.GetMember("Img")[0]) + strErrTemp;
                return bFlag;
            }
            return true;
        }

        /// <summary>
        /// 添加信息
        /// </summary>
        /// <returns></returns>
        public override bool InsertSelf()
        {
            if (!Validate())
                return false;
            return DBOper.DoInsert(TBName_ResourcesVideo,
                new string[] { "ResID", "Abstract", "Img", "Pubdate" },
                new object[] { this.ResID, this.Abstract, this.Img, this.Pubdate });
        }

        /// <summary>
        /// 修改信息。
        /// </summary>
        /// <returns></returns>
        public override bool UpdateSelf()
        {
            if (!Validate())
                return false;            
            return DBOper.DoUpdate(TBName_ResourcesVideo,
                new string[] { "Abstract", "Img", "Pubdate" },
                new object[] { this.Abstract, this.Img, this.Pubdate }, new string[] { "ResID" }, new object[] { this.PID });
        }
        public override bool UpdateSelf(string[] fieldNames)
        {           
            if (fieldNames == null || fieldNames.Length == 0)
                return true;
            if (!this.Validate())
                return false;
            int i = 0;
            object[] fieldValues = new object[fieldNames.Length];
            foreach (string onefield in fieldNames)
            {
                fieldValues[i++] = this.GetValue(onefield);
            }
            return DBOper.DoUpdate(TBName_ResourcesVideo, fieldNames, fieldValues, new string[] { "ResID" }, new object[] { this.PID });
        }    
        /// <summary>
        /// 获取信息详细。
        /// </summary>
        /// <returns></returns>
        public override bool GetDetail()
        {
            DataTable DetailDt = MultiDBOper.GetResourcesVideoDetail(this.ResID);
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
