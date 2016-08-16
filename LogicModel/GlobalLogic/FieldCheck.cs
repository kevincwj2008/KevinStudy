using System;
using System.Text.RegularExpressions;
using System.Text;

namespace XFCompany.CIPnetWeb.LogicModel
{
    /// <summary>
    /// 字段检测类。
    /// </summary>
    public class FieldCheck
    {
        /// <summary>
        /// 检测函数。
        /// </summary>
        /// <returns>符合要求返回true,否则返回false。</returns>
        public virtual bool Check(out String strErrorInfo)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// 整形检测。
    /// </summary>
    public class IntCheck
    {
        /// <summary>
        /// 检测值。
        /// </summary>
        protected int IntCheckValue;

        /// <summary>
        /// 最小值。
        /// </summary>
        private int iMin = Int32.MinValue;

        /// <summary>
        /// 最大值。
        /// </summary>
        private int iMax = Int32.MaxValue;

        /// <summary>
        /// 初始化函数。
        /// </summary>
        /// <param name="oValue">检测值。</param>
        public IntCheck(int oValue)
        {
            this.IntCheckValue = oValue;
        }

        /// <summary>
        /// 初始化函数。
        /// </summary>
        /// <param name="oValue">检测值。</param>
        /// <param name="iMin">最小值(若不判断最小值请设置为：Int32.MinValue)。</param>
        /// <param name="iMax">最大值(若不判断最大值请设置为：Int32.MaxValue)。</param>
        public IntCheck(int oValue, int iMin, int iMax)
        {
            this.IntCheckValue = oValue;
            this.iMin = iMin;
            this.iMax = iMax;
        }

        /// <summary>
        /// 检测函数。
        /// </summary>
        /// <returns>符合要求返回true,否则返回false。</returns>
        public bool Check(out String strErrorInfo)
        {
            bool bFlag = false;
            strErrorInfo = "";
            if (IntCheckValue < iMin)
            {
                strErrorInfo = GlobalMSG.All["Msg_OutMinValue"].Replace("MinValue", iMin.ToString());
                return bFlag;
            }
            if (IntCheckValue > iMax)
            {
                strErrorInfo = GlobalMSG.All["Msg_OutMaxValue"].Replace("MaxValue", iMax.ToString());
                return bFlag;
            }
            return !bFlag;
        }
    }

    /// <summary>
    /// 字符串检测。
    /// </summary>
    public class StringCheck
    {
        /// <summary>
        /// String类型检测值
        /// </summary>
        protected string StringCheckValue;
        /// <summary>
        /// 最小长度。
        /// </summary>
        private int iMinLength = 0;

        /// <summary>
        /// 最大长度。
        /// </summary>
        private int iMaxLength = 0;

        /// <summary>
        /// 初始化函数。
        /// </summary>
        /// <param name="oValue">检测值。</param>
        public StringCheck(String oValue)
        {
            this.StringCheckValue = oValue;
        }

        /// <summary>
        /// 初始化函数。
        /// </summary>
        /// <param name="oValue">检测值。</param>
        /// <param name="iMinLength">最小长度(若不判断最小长度请设置为：0)。</param>
        /// <param name="iMaxLength">最大长度(若不判断最大长度请设置为：0)。</param>
        public StringCheck(String oValue, int iMinLength, int iMaxLength)
        {
            this.StringCheckValue = oValue;
            this.iMinLength = iMinLength;
            this.iMaxLength = iMaxLength;
        }

        /// <summary>
        /// 检测函数。
        /// </summary>
        /// <returns>符合要求返回true,否则返回false。</returns>
        public virtual bool Check(out String strErrorInfo)
        {
            bool bFlag = false;
            strErrorInfo = "";

            if (iMinLength <= 0 && String.IsNullOrEmpty(StringCheckValue))
                return true;
            if (Encoding.Default.GetBytes(StringCheckValue).Length < iMinLength)
            {
                strErrorInfo = GlobalMSG.All["Msg_String_OutMinLength"].Replace("MinLength", iMinLength.ToString());
                return bFlag;
            }

            if (iMaxLength != 0)
            {
                if (Encoding.Default.GetBytes(StringCheckValue).Length > iMaxLength)
                {
                    strErrorInfo = GlobalMSG.All["Msg_String_OutMaxLength"].Replace("MaxLength", iMaxLength.ToString());
                    return bFlag;
                }
            }
            return !bFlag;
        }

        /// <summary>
        /// 检测函数。
        /// </summary>
        /// <returns>符合要求返回true,否则返回false。</returns>
        public virtual bool CheckLength(out String strErrorInfo)
        {
            bool bFlag = false;
            strErrorInfo = "";

            if (iMinLength <= 0 && String.IsNullOrEmpty(StringCheckValue))
                return true;
            if (StringCheckValue.Length < iMinLength)
            {
                strErrorInfo = GlobalMSG.All["Msg_String_OutMinLength"].Replace("MinLength", iMinLength.ToString());
                return bFlag;
            }

            if (iMaxLength != 0)
            {
                if (StringCheckValue.Length > iMaxLength)
                {
                    strErrorInfo = GlobalMSG.All["Msg_String_OutMaxLength"].Replace("MaxLength", iMaxLength.ToString());
                    return bFlag;
                }
            }
            return !bFlag;
        }
    }

    /// <summary>
    /// 电子邮箱检测。
    /// </summary>
    public class EmailCheck : StringCheck
    {
        /// <summary>
        /// 初始化函数。
        /// </summary>
        /// <param name="oValue">检测值。</param>
        public EmailCheck(String oValue)
            : base(oValue,5, 200)
        {
        }

        /// <summary>
        /// 检测函数。
        /// </summary>
        /// <returns>符合要求返回true,否则返回false。</returns>
        public override bool Check(out String strErrorInfo)
        {
            bool bFlag = false;
            if (!base.Check(out strErrorInfo))
                return bFlag;
            if (!Regex.IsMatch(StringCheckValue.ToLower(), @"^[\w-]+(\.[\w-]+)*@[\w-]+(\.[\w-]+)+$"))
            {
                strErrorInfo = GlobalMSG.All["Msg_Email_Err"];
                return bFlag;
            }
            return !bFlag;
        }
    }


    /// <summary>
    /// 网址检测。
    /// </summary>
    public class UrlCheck : StringCheck
    {
        /// <summary>
        /// 初始化函数。
        /// </summary>
        /// <param name="oValue">检测值。</param>
        public UrlCheck(String oValue)
            : base(oValue, 4, 600)
        {
        }

        /// <summary>
        /// 检测函数。
        /// </summary>
        /// <returns>符合要求返回true,否则返回false。</returns>
        public override bool Check(out String strErrorInfo)
        {
            bool bFlag = false;
            if (!base.Check(out strErrorInfo))
                return bFlag;
            string NewUrl = String.Empty;
            string tempStrRegex = "^[\u4E00-\u9FFF]|\\{|\\}|\\s+$";
            for (int k = 0; k < StringCheckValue.Length; k++)
            {
                if (!Regex.IsMatch(StringCheckValue[k].ToString(), tempStrRegex))
                    NewUrl += StringCheckValue[k];
            }
            String StrRegex = String.Empty;
            StrRegex = "^((https|http|ftp|rtsp|mms)?://)"
                    + "?(([0-9a-zA-Z_!~*'().&=+$%-]+: )?[0-9a-zA-Z_!~*'().&=+$%-]+@)?" //ftp的user@ 
                    + "(([0-9]{1,3}\\.){3}[0-9]{1,3}" // IP形式的URL- 199.194.52.184 
                    + "|" // 允许IP和DOMAIN（域名）
                    + "([0-9a-zA-Z_!~*'()-]+\\.)*" // 域名- www. 
                    + "([0-9a-zA-Z][0-9a-zA-Z-]{0,61})?[0-9a-zA-Z]\\." // 二级域名 
                    + "[a-zA-Z]{2,6})" // first level domain- .com or .museum 
                    + "(:[0-9]{1,4})?" // 端口- :80 
                    + "((/?)|" // a slash isn't required if there is no file name 
                    + "(/[0-9a-zA-Z_!~*'().;?:@&=+$,%#-\\[\\]]+)+/?)$";
            if (!Regex.IsMatch(NewUrl.ToLower(), StrRegex))
            {
                strErrorInfo = GlobalMSG.All["Msg_Url_Err"];
                return bFlag;
            }
            return !bFlag;
        }
    }

    /// <summary>
    /// 用户名检测
    /// </summary>
    public class UsernameCheck : StringCheck
    {
        /// <summary>
        /// 初始化函数。
        /// </summary>
        /// <param name="oValue">检测值。</param>
        public UsernameCheck(String oValue)
            : base(oValue, 6, 50)
        {
        }

        /// <summary>
        /// 检测函数。
        /// </summary>
        /// <returns>符合要求返回true,否则返回false。</returns>
        public override bool Check(out String strErrorInfo)
        {
            bool bFlag = false;
            if (!base.Check(out strErrorInfo))
                return bFlag;
            if (!Regex.IsMatch(StringCheckValue, @"^[a-zA-Z][a-zA-Z0-9_]{4,19}$"))
            {
                strErrorInfo = GlobalMSG.All["Msg_Username_Err"];
                return bFlag;
            }
            return !bFlag;
        }
    }
    
    /// <summary>
    /// 邮政编码检测
    /// </summary>
    public class ZipcodeCheck : StringCheck
    {
        /// <summary>
        /// 初始化函数。
        /// </summary>
        /// <param name="oValue">检测值。</param>
        public ZipcodeCheck(String oValue)
            : base(oValue, 3, 10)
        {
        }

        /// <summary>
        /// 检测函数。
        /// </summary>
        /// <returns>符合要求返回true,否则返回false。</returns>
        public override bool Check(out String strErrorInfo)
        {
            bool bFlag = false;
            if (!base.Check(out strErrorInfo))
                return bFlag;
            if (!Regex.IsMatch(StringCheckValue, @"^\d{6}$"))
            {
                strErrorInfo = GlobalMSG.Get("Msg_Zipcode_Err");
                return bFlag;
            }
            return !bFlag;
        }
    }

    /// <summary>
    /// Guid检测。
    /// </summary>
    public class GuidCheck
    {
        /// <summary>
        /// Guid检测值
        /// </summary>
        protected Guid GuidCheckValue;
        /// <summary>
        /// 初始化函数。
        /// </summary>
        /// <param name="oValue">检测值。</param>
        public GuidCheck(Guid oValue)
        {
            this.GuidCheckValue = oValue;
        }

        /// <summary>
        /// 检测函数。
        /// </summary>
        /// <returns>符合要求返回true,否则返回false。</returns>
        public bool Check(out String strErrorInfo)
        {
            bool bFlag = false;
            strErrorInfo = "";
            if (GuidCheckValue == null || GuidCheckValue == Guid.Empty)
            {
                strErrorInfo = GlobalMSG.All["Msg_Guid_Err"];
                return bFlag;
            }
            return !bFlag;
        }
    }

    /// <summary>
    /// 时间检测
    /// </summary>
    public class DatetimeCheck
    {
        /// <summary>
        /// 时间检测开始值
        /// </summary>
        protected DateTime StartTime;
        /// <summary>
        /// 时间检测结束值
        /// </summary>
        protected DateTime EndTime;

        /// <summary>
        /// 初始化函数。
        /// </summary>
        /// <param name="StartTime">开始时间，如果没有开始时间，那么请把开始时间设为：Null</param>
        /// <param name="EndTime">结束时间。</param>
        public DatetimeCheck(DateTime StartTime, DateTime EndTime)
        {
            this.StartTime = StartTime;
            this.EndTime = EndTime;
        }

        /// <summary>
        /// 检测函数。
        /// </summary>
        /// <returns>符合要求返回true,否则返回false。</returns>
        public bool Check(out String strErrorInfo)
        {
            bool bFlag = false;
            strErrorInfo = "";
            if (EndTime != StartTime && EndTime != Convert.ToDateTime("1900-01-01"))
            {
                if (EndTime <= StartTime)
                {
                    strErrorInfo = GlobalMSG.All["Msg_Datetime_OutStartTime"];
                    return bFlag;
                }
            }
            return !bFlag;
        }

        /// <summary>
        /// 检测函数。
        /// </summary>
        /// <param name="currentTime">要检测的时间。</param>
        /// <param name="strErrorInfo">错误信息。</param>
        /// <returns>符合要求返回true,否则返回false。</returns>
        public bool Check(DateTime currentTime,out String strErrorInfo)
        {
            bool bFlag = false;
            strErrorInfo = "";
            if (currentTime == null || currentTime > EndTime || currentTime < StartTime)
            {
                strErrorInfo = GlobalMSG.All["Msg_Datetime_Err"];
                return bFlag;
            }
            return !bFlag;
        }
    }

    /// <summary>
    /// 浮点数检测。
    /// </summary>
    public class DoubleCheck
    {
        /// <summary>
        /// Double检测值
        /// </summary>
        protected Double DoubleCheckValue;

        /// <summary>
        /// 最小值。
        /// </summary>
        private double dMin = double.MinValue;

        /// <summary>
        /// 最大值。
        /// </summary>
        private double dMax = double.MaxValue;

        /// <summary>
        /// 初始化函数。
        /// </summary>
        /// <param name="oValue">检测值。</param>
        public DoubleCheck(double oValue)
        {
            this.DoubleCheckValue = oValue;
        }

        /// <summary>
        /// 初始化函数。
        /// </summary>
        /// <param name="dMin">最小值(若不判断最小值请设置为：double.MinValue)。</param>
        /// <param name="dMax">最大值(若不判断最大值请设置为：double.MaxValue)。</param>
        /// <param name="oValue">检测值。</param>
        public DoubleCheck(double oValue, double dMin, double dMax)
        {
            this.DoubleCheckValue = oValue;
            this.dMin = dMin;
            this.dMax = dMax;
        }

        /// <summary>
        /// 检测函数。
        /// </summary>
        /// <returns>符合要求返回true,否则返回false。</returns>
        public bool Check(out String strErrorInfo)
        {
            bool bFlag = false;
            strErrorInfo = "";
            if (DoubleCheckValue < dMin)
            {
                strErrorInfo = GlobalMSG.All["Msg_OutMinValue"].Replace("MinValue", dMin.ToString());
                return bFlag;
            }
            if (DoubleCheckValue > dMax)
            {
                strErrorInfo = GlobalMSG.All["Msg_OutMaxValue"].Replace("MaxValue", dMin.ToString());
                return bFlag;
            }
            return !bFlag;
        }
    }
}
