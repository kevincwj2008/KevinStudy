using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XFCompany.CIPNet.GlobalSetting
{
    /// <summary>
    /// 定义平台中上传附件的大小
    /// </summary>
    public class GlobalSize
    {
        /// <summary>
        /// 身份证或护照的扫描件或照片的大小。
        /// </summary>
        public static String IDCardImageSize = "900*600";
        /// <summary>
        /// 机构代码证的大小。
        /// </summary>
        public static String EnterpriseCodeImageSize = "900*780";
        /// <summary>
        /// 机构营业执照的大小。
        /// </summary>
        public static String EnterpriseLicenseImageSize = "900*780";
        
    }
}
