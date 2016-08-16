using System;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using Newtonsoft.Json.Linq;

namespace XFCompany.CIPnetWeb.LogicModel
{
    /// <summary>
    /// BasePage类。
    /// </summary>
    public class BasePage : System.Web.UI.Page
    {
       

        #region 定义获取Request中url参数的方法
        /// <summary>
        /// 获取Guid类型的值。
        /// </summary>
        /// <param name="param">参数名称。</param>
        /// <param name="value">返回参数的值。</param>
        /// <returns></returns>
        public static bool GetRequest(string param, out Guid value)
        {
            if (String.IsNullOrEmpty(HttpContext.Current.Request[param]))
            {
                value = Guid.Empty;
                return false;
            }
            else
            {
                try
                {
                    value = new Guid(HttpContext.Current.Request[param].Trim());
                    return true;
                }
                catch
                {
                    value = Guid.Empty;
                    return false;
                }
            }
        }

        /// <summary>
        /// 获取字符串类型的值。
        /// </summary>
        /// <param name="param">参数名称。</param>
        /// <param name="value">返回参数的值。</param>
        /// <returns></returns>
        public static bool GetRequest(string param, out string value)
        {
            if (String.IsNullOrEmpty(HttpContext.Current.Request[param]))
            {
                value = String.Empty;
                return false;
            }
            else
            {
                value = ReplaceSpecialChar(HttpContext.Current.Request[param].Trim());
                return value != String.Empty;
            }
        }

        /// <summary>
        /// 获取字符串类型的值。
        /// </summary>
        /// <param name="param">参数名称。</param>
        /// <param name="value">返回参数的值。</param>
        /// <param name="Server"></param>
        /// <returns></returns>
        public static bool GetRequest(string param, out string value, HttpServerUtility Server)
        {
            if (String.IsNullOrEmpty(HttpContext.Current.Request[param]))
            {
                value = String.Empty;
                return false;
            }
            else
            {
                if (Server != null)
                {
                    value = ReplaceSpecialChar(HttpContext.Current.Request[param].Trim());
                }
                else
                {
                    value = ReplaceSpecialChar(HttpContext.Current.Request[param].Trim());
                }
                return value != String.Empty;
            }
        }

        /// <summary>
        /// 获取字符串类型的值。
        /// </summary>
        /// <param name="param">参数名称。</param>
        /// <param name="value">返回参数的值。</param>
        /// <param name="isreplace">是否替换特殊字符(如：单引号、双引号、与符号等)。</param>
        /// <returns></returns>
        public static bool GetRequest(string param, out string value, bool isreplace)
        {
            if (String.IsNullOrEmpty(HttpContext.Current.Request[param]))
            {
                value = String.Empty;
                return false;
            }
            else
            {
                if (isreplace)
                {
                    value = ReplaceSpecialChar(HttpContext.Current.Request[param].Trim());
                }
                else
                {
                    value = HttpContext.Current.Request[param].Trim();
                }
                return value != String.Empty;
            }
        }

        /// <summary>
        /// 获取数字类型的值。
        /// </summary>
        /// <param name="param">参数名称。</param>
        /// <param name="value">返回参数的值。</param>
        /// <returns></returns>
        public static bool GetRequest(string param, out int value)
        {
            if (String.IsNullOrEmpty(HttpContext.Current.Request[param]))
            {
                value = 0;
                return false;
            }
            else
            {
                return Int32.TryParse(HttpContext.Current.Request[param].Trim(), out value);
            }
        }

        /// <summary>
        /// 获取时间类型的值。
        /// </summary>
        /// <param name="param">参数名称。</param>
        /// <param name="value">返回参数的值。</param>
        /// <returns></returns>
        public static bool GetRequest(string param, out DateTime value)
        {
            if (String.IsNullOrEmpty(HttpContext.Current.Request[param]))
            {
                value = DateTime.Parse(System.Data.SqlTypes.SqlDateTime.MinValue.ToString());
                return false;
            }
            else
            {
                return DateTime.TryParse(HttpContext.Current.Request[param].Trim(), out value);
            }
        }

        /// <summary>
        /// 获取float类型的值。
        /// </summary>
        /// <param name="param">参数名称。</param>
        /// <param name="value">返回参数的值。</param>
        /// <returns></returns>
        public static bool GetRequest(string param, out float value)
        {
            if (String.IsNullOrEmpty(HttpContext.Current.Request[param]))
            {
                value = 0f;
                return false;
            }
            else
            {
                try
                {
                    value = (float)Convert.ToDouble(HttpContext.Current.Request[param].Trim());
                    return true;
                }
                catch
                {
                    value = 0f;
                    return false;
                }
            }
        }

        /// <summary>
        /// 获取bool类型的值。
        /// </summary>
        /// <param name="param">参数名称。</param>
        /// <param name="value">返回参数的值。</param>
        /// <returns></returns>
        public static bool GetRequest(string param, out bool value)
        {
            if (String.IsNullOrEmpty(HttpContext.Current.Request[param]))
            {
                value = false;
                return false;
            }
            else
            {
                return bool.TryParse(HttpContext.Current.Request[param].Trim(), out value);
            }
        }
        #endregion

        #region 处理页面显示字段

        private static string fieldDefault = "未知";
        /// <summary>
        /// 字段的默认值。
        /// </summary>
        public static string FieldDefault
        {
            get { return fieldDefault; }
        }

        /// <summary>
        /// 处理页面显示字段。
        /// </summary>
        /// <param name="value">需要处理的字段值。</param>
        /// <param name="returnValue">返回处理后字段值。</param>
        /// <returns>符合要求返回true，否则返回false。</returns>
        private static bool DisposeField(object value, out string returnValue)
        {
            if (value == null)
            {
                returnValue = fieldDefault;
                return false;
            }
            else
            {
                if (string.IsNullOrEmpty(value.ToString()))
                {
                    returnValue = fieldDefault;
                    return false;
                }
                else
                {
                    returnValue = value.ToString();
                    return true;
                }
            }
        }

        /// <summary>
        /// 处理页面显示字符串字段。
        /// </summary>
        /// <param name="value">需要处理的字符串值。</param>
        /// <returns>返回处理后字符串值。</returns>
        public static string DisposeString(object value)
        {
            string strReturn;
            DisposeField(value, out strReturn);
            if (strReturn == fieldDefault)
                return String.Empty;
            return strReturn;
        }


        /// <summary>
        /// 处理页面显示字符串字段，将多个\r\n替换为1个。
        /// </summary>
        /// <param name="value">需要处理的字符串值。</param>
        /// <param name="IsReplace">是否需要替换换行符。</param>
        /// <returns>返回处理后字符串值。</returns>
        public static string DisposeStringByNewline(object value)
        {
            string strReturn = DisposeString(value);
            return Regex.Replace(strReturn, "(\r\n)+", "\r\n");
        }

        /// <summary>
        /// 处理页面显示枚举字段。
        /// </summary>
        /// <param name="enumType">枚举类型。</param>
        /// <param name="value">需要处理的枚举值。</param>
        /// <returns>返回处理后枚举的文本值。</returns>
        public static string DisposeEnum(Type enumType, object value)
        {
            string strReturn;
            if (!DisposeField(value, out strReturn))
                return strReturn;
            return Helper.GetUIText((Enum)Enum.ToObject(enumType, value));
        }

        /// <summary>
        /// 处理页面显示枚举字段。
        /// </summary>
        /// <param name="enumType">枚举类型。</param>
        /// <param name="value">需要处理的枚举值。</param>
        /// <returns>返回处理后枚举的文本值。</returns>
        public static string DisposeEnum(Type enumType, string value)
        {
            string strReturn;
            if (!DisposeField(value, out strReturn))
                return strReturn;
            return Helper.GetUIText((Enum)Enum.Parse(enumType, value));
        }

        /// <summary>
        /// 处理显示活动是否结束
        /// </summary>
        /// <param name="StrStart">活动开始时间</param>
        /// <param name="StrEnd">活动结束时间</param>
        /// <returns></returns>
        public static String DisposeEventTime(String StrStart, String StrEnd)
        {
            if (String.IsNullOrEmpty(StrEnd))
                return String.Empty;
            DateTime StartTime, EndTime;
            if (!DateTime.TryParse(StrStart, out StartTime))
                return String.Empty;
            if (!DateTime.TryParse(StrEnd, out EndTime))
                return String.Empty;
            if (StartTime == DateTime.MinValue && EndTime == DateTime.MinValue)//用于搜索页中全文检索
                return String.Empty;
            if (EndTime < DateTime.Now)
                return "已结束";
            return DisposeTime(StrStart, StrEnd);
        }

        /// <summary>
        /// 处理显示时间
        /// </summary>
        /// <param name="Strbegin">开始时间</param>
        /// <param name="Strend">结束时间</param>
        /// <returns></returns>
        public static String DisposeTime(String Strbegin, String Strend)
        {
            string strTimeShow = String.Empty;
            DateTime begin, end;
            if (!DateTime.TryParse(Strbegin, out begin))
                return strTimeShow;
            if (!DateTime.TryParse(Strend, out end))
                return strTimeShow;
            if (begin == DateTime.MinValue && end == DateTime.MinValue)//用于搜索页中全文检索
                return strTimeShow;

            if (begin == null || end == null || begin > end)//传入参数有误
            {
                return strTimeShow;
            }
            int cday = 0;
            int chour = 0;
            int cminute = 0;

            DateTime now = DateTime.Now;//当前时间
            if (begin > now)//尚未开始
            {
                cday = (begin - now).Days;
                chour = (begin - now).Hours;
                cminute = (begin - now).Minutes;
                if (cday > 0)
                    return strTimeShow = "还有 " + cday.ToString() + " 天开始";
                if (chour > 0)
                    return strTimeShow = "还有 " + chour.ToString() + " 小时开始";
                if (cminute >= 5)
                    return strTimeShow = "还有 " + cminute.ToString() + " 分钟开始";
                return "即将开始";
            }
            else if (end > now)//已开始未超出结束时间的
            {
                if (end.ToString("yyyy-MM-dd") == now.ToString("yyyy-MM-dd"))
                    return strTimeShow = "今天 " + end.ToShortTimeString() + " 截止";
                else
                {
                    cday = (end - now).Days;
                    chour = (end - now).Hours;
                    cminute = (end - now).Minutes;
                    if (cday > 0)
                        return strTimeShow = "剩余 " + cday.ToString() + " 天";
                    if (chour > 0)
                        return strTimeShow = "剩余 " + chour.ToString() + " 小时";
                    if (cminute >= 5)
                        return strTimeShow = "剩余 " + cminute.ToString() + " 分钟";
                    return "即将结束";
                }
            }
            else//已超出
            {
                cday = (now - end).Days;
                chour = (now - end).Hours;
                cminute = (now - end).Minutes;
                if (cday > 0)
                    return strTimeShow = "已超出 " + cday.ToString() + " 天";
                if (chour > 0)
                    return strTimeShow = "已超出 " + chour.ToString() + " 小时";
                if (cminute < 1)
                    cminute = 1;
                return strTimeShow = "已超出 " + cminute.ToString() + " 分钟";
            }
        }

        /// <summary>
        /// 替换话题
        /// </summary>
        /// <param name="StrContent">需替换的字符串。</param>
        /// <returns></returns>
        public static String ReplaceTopic(String StrContent)
        {
            //String.IsNullOrEmpty(StrContent) ? "" : System.Text.RegularExpressions.Regex.Replace(StrContent, @"\#([^\#]+)\#", "<a href=\"javascript:GetListByTopic('" + tempMatch.Value + "');\">#$1#</a>");
            if (String.IsNullOrEmpty(StrContent))
            {
                return "";
            }
            else
            {
                String strMatch = String.Empty;
                MatchCollection mc = System.Text.RegularExpressions.Regex.Matches(StrContent, @"\#([^\#\s]+)\#");
                foreach (Match m in mc)
                {
                    String TopicKws = m.Value;
                    MatchCollection matchC = System.Text.RegularExpressions.Regex.Matches(TopicKws, "<img[\\s\\S]*?src=(?:(?:(['\"])([\\s\\S]*?)\\1)|([^\\s>]*))[\\s\\S]*?>");
                    if (matchC.Count == 0)
                    {
                        strMatch = "<a href=\"javascript:GetListByTopic('" + (m.Value.Split('#')[1].Length > 25 ? (m.Value.Split('#')[1].Substring(0, 25)) : m.Value.Split('#')[1]) + "');\">" + m.Value + "</a>";
                        StrContent = StrContent.Replace(m.Value, strMatch);
                    }
                    else
                    {
                        foreach (Match match in matchC)
                        {
                            Regex regImgtitle = new Regex(@"<img\b[^<>]*?\btitle[\s\t\r\n]*=[\s\t\r\n]*[""']?[\s\t\r\n]*(?<imgtitle>[^\s\t\r\n""'<>]*)[^<>]*?/?[\s\t\r\n]*>", RegexOptions.IgnoreCase);

                            // 搜索匹配的字符串 
                            MatchCollection matches = regImgtitle.Matches(match.Value);
                            string newtopicname = String.Empty;
                            // 取得匹配项列表 
                            foreach (Match match1 in matches)
                                newtopicname += match1.Groups["imgtitle"].Value;
                            TopicKws = TopicKws.Replace(match.Value, System.Text.RegularExpressions.Regex.Match(newtopicname, @"(?!\[)([^\[\]]*)(?=\])").Value);
                        }

                        strMatch = "<a href=\"javascript:GetListByTopic('" + (TopicKws.Split('#')[1].Length > 25 ? (TopicKws.Split('#')[1].Substring(0, 25)) : TopicKws.Split('#')[1]) + "');\">" + m.Value + "</a>";
                        StrContent = StrContent.Replace(m.Value, strMatch);

                    }
                }
                return StrContent;
            }
        }

        /// <summary>
        /// 获取文件的大小(将字节单位转换为KM,MB,B来显示)。
        /// </summary>
        /// <param name="filesize">文件大小。</param>
        /// <returns></returns>
        public string GetFileSize(object filesize)
        {
            try
            {
                Int64 FileSize = Convert.ToInt64(filesize);
                if (FileSize == 0)
                    return "0";
                else
                {
                    Int64 a = FileSize / (1024 * 1024 * 1024);
                    if (a >= 1)
                    {
                        return (FileSize / (1024f * 1024f * 1024f)).ToString("F") + "GB";
                    }
                    Int64 m = (FileSize - (a * 1024 * 1024 * 1024)) / (1024 * 1024);
                    if (m >= 1)
                    {
                        return (FileSize / (1024f * 1024f)).ToString("F") + "MB";
                    }
                    Int64 k = (FileSize - (m * 1024 * 1024)) / 1024;
                    if (k >= 1)
                    {
                        return (FileSize / 1024f).ToString("F") + "KB";
                    }
                    Int64 b = FileSize;
                    if (b >= 1)
                    {
                        return FileSize.ToString() + "B";
                    }
                    if (m == 0 && k == 0 && b == 0)
                        return "< 1B";
                    return "0";
                }
            }
            catch
            {
                return "0";
            }
        }

        /// <summary>
        /// 截取字符串。
        /// </summary>
        /// <param name="StrDesc">需要截取的字符串。</param>
        /// <param name="StrCnt">保留字符串的长度。</param>
        /// <param name="isDefault">是否需要省略符号。（true：有、false：没有）</param>
        /// <returns></returns>
        public static string GetSplitStr(string StrDesc, int StrCnt, bool isDefault)
        {

            if (StrDesc == null) return string.Empty;
            char[] temp = StrDesc.ToCharArray();
            int k = 0;
            for (int i = 0; i < temp.Length; i++)
            {
                if ((int)temp[i] > 300)
                {
                    k += 5;
                }
                else
                {
                    k += 3;
                }
                if (k >= StrCnt * 5)
                {
                    StrDesc = StrDesc.Remove(i, StrDesc.Length - i);
                    if (isDefault)
                    {
                        return StrDesc + "..";
                    }
                    else
                    {
                        return StrDesc;
                    }
                }

            }

            return StrDesc;
        }


        /// <summary>
        /// 截取中英文字符串。
        /// </summary>
        /// <param name="original">原始字符串。</param>
        /// <param name="length">截取长度。</param>
        /// <param name="fill">尾部附加字符串，占用截取字符串长度。</param> 
        /// <returns></returns>
        public static String GetSplitString(String original, Int32 length, String fill)
        {

            int length_n = length * 2;
            Regex CnRegex = new Regex("[\u4e00-\u9fa5]+", RegexOptions.Compiled);

            Char[] CharArray = original.ToCharArray();

            Int32 tmplength = 0;

            for (Int32 i = 0; i < CharArray.Length; i++)
            {

                tmplength += CnRegex.IsMatch(CharArray[i].ToString()) ? 2 : 1;

                if (tmplength > length_n)

                    return original.Substring(0, i - fill.Length) + fill;

            } return original;
        }



        /// <summary>
        /// 过滤Html标签。
        /// </summary>
        /// <param name="Htmlstring">过滤前的字符串。</param>
        /// <returns></returns>
        public static string FilterHtml(string Htmlstring)
        {
            return HtmlParser.FormatHtmlTitle(Htmlstring);
        }


        /// <summary>
        /// 替换@用户
        /// </summary>
        /// <param name="Content">内容。</param>
        /// <param name="AtUser">@用户集。</param>
        /// <returns>替换后内容。</returns>
        public static String DisposeDiscuss(String Content, String AtUsers)
        {
            if (String.IsNullOrEmpty(Content))
                return String.Empty;
            Content = Content.Replace("$$ShortUrlDomain$$", GlobalSettings.DisposeShortUrl);
            if (String.IsNullOrEmpty(AtUsers))
            {
                Content = FilterHtml(Content);
                return Content;
            }
            JArray jarrayUsers = JArray.Parse(AtUsers);
            for (int i = 0; i < jarrayUsers.Count; i++)
            {
                Content = Content.Replace("@[" + jarrayUsers[i].Value<String>("pid").ToUpper() + "]", "@" + jarrayUsers[i].Value<String>("name"));
            }
            Content = FilterHtml(Content);
            return Content;
        }
        #endregion

        #region 其他方法

        /// <summary>
        /// 替换上传文件名称中特殊字符。
        /// </summary>
        /// <param name="StrContent">需替换的字符串。</param>
        /// <returns></returns>
        public static String ReplaceUploadFiName(String StrContent)
        {
            return String.IsNullOrEmpty(StrContent) ? "" : StrContent.Replace("&", "＆");
        }
        /// <summary>
        /// 获取符合条件的记录总数。
        /// </summary>
        /// <param name="totalNum">总数。</param>
        /// <returns></returns>
        public static string GetTotalNum(int totalNum)
        {
            if (totalNum == 0)
                return "";
            else
            {
                String TotalStr = String.Empty;
                TotalStr = "符合条件的记录共" + totalNum + "条";
                return TotalStr;
            }
        }

        /// <summary>
        /// 替换特殊字符。
        /// </summary>
        /// <param name="StrContent">需替换的字符串。</param>
        /// <returns></returns>
        private static string ReplaceSpecialChar(string StrContent)
        {
            return String.IsNullOrEmpty(StrContent) ? "" : StrContent.Replace("<", "&lt;").Replace(">", "&gt;").Replace("'", "&apos;").Replace("\"", "&quot;");
        }

        /// <summary>
        /// 组织空间中暂无数据的显示。
        /// </summary>
        /// <param name="HintTxt">提示文字。</param>
        /// <returns>返回暂无数据模块。</returns>
        public static string ShowNotInfoBlock(String HintTxt)
        {
            StringBuilder sbNotInfo = new StringBuilder();
            if (String.IsNullOrEmpty(HintTxt))
                return String.Empty;
            else
            {
                sbNotInfo.Append("<div class='dashedinitt' id='dashedinitt'>");
                sbNotInfo.Append("<div class='tx_dinitt'>");
                sbNotInfo.Append("<div class='tb_dinitt'>");
                sbNotInfo.Append("<div class='tl_dinitt'>");
                sbNotInfo.Append("<div class='tr_dinitt'>");
                sbNotInfo.Append("<div class='tr_dinitt'>");
                sbNotInfo.Append("<div class='tround_dinitt'><i class='tl_trdinitt'></i><i class='tr_trdinitt'></i></div>");
                sbNotInfo.Append("<div class='cont_dinitt '><div class='txt_cinit'>" + HintTxt + "</div></div>");
                sbNotInfo.Append("<div class='bround_dinitt'><i class='bl_trdinitt'></i><i class='br_trdinitt'></i></div>");
                sbNotInfo.Append("</div>");
                sbNotInfo.Append("</div>");
                sbNotInfo.Append("</div>");
                sbNotInfo.Append("</div>");
                sbNotInfo.Append("</div>");
                sbNotInfo.Append("</div>");
                return sbNotInfo.ToString();
            }
        }
        /// <summary>
        /// 验证当前浏览器是否是IE（360）
        /// </summary>
        /// <param name="browser">当前浏览器</param>
        /// <returns>是return true，否则return false。</returns>
        public static bool ValidateIsIEBrowser(object browser)
        {
            try
            {
                bool result = false;
                Regex reg_browser = new Regex("(msie\\s|trident.*rv:)([\\w.]+)");
                Match m = reg_browser.Match(browser.ToString().ToLower());
                if (browser != null && m.Success)
                    result = true;
                else
                    result = false;
                return result;
            }
            catch
            {
                return false;
            }
        }
        #endregion
        /// <summary>
        /// 对下载资料的名称的处理
        /// </summary>
        /// <param name="downfilename">资料名称</param>
        /// <returns></returns>
        public static string ReplaceDownFileName(string downfilename)
        {
            return (String.IsNullOrEmpty(downfilename) ? "" : downfilename.Replace("%24", "$").Replace("%25", "%").Replace("%40", "@").Replace("&amp;", "&").Replace("%3d", "=").Replace("%5b", "[").Replace("%5d", "]").Replace("%26", "&").Replace("%3b", ";").Replace("%5e", "^").Replace("%2b", "+").Replace("%7b", "{").Replace("%7d", "}").Replace("%2c", ","));
        }
        /// <summary>
        /// 处理下载文件时，输入出文件流 带有filename
        /// </summary>
        /// <param name="datas">文件内容(文件流)</param>
        /// <param name="filename">文件名称</param>
        protected void HandlerDownLoadFile(HttpContext httpContext, byte[] datas, string filename)
        {
            try
            {
                String range = httpContext.Request.Headers.Get("Range");//bytes=1916928-38729124
                int start = 0;
                int end = 0;
                byte[] results = null;
                if (!String.IsNullOrEmpty(range))
                {
                    try
                    {
                        String[] start_end = range.Substring(range.IndexOf("=") + 1).Split('-');
                        start = Convert.ToInt32(start_end[0]);
                        end = Convert.ToInt32(start_end[1]);
                    }
                    catch (Exception)
                    {
                        start = end = 0;
                    }
                }
                if (start != end && start < end && end > 0 && datas != null)
                {
                    try
                    {
                        int length = end - start + 1;
                        results = new byte[length];
                        Array.Copy(datas, start, results, 0, length);
                    }
                    catch
                    {
                        results = null;
                    }
                }
                if (results != null && results.Length > 0)
                {
                    datas = results;
                }

                httpContext.Response.Clear();
                httpContext.Response.ClearContent();
                httpContext.Response.ClearHeaders();
                httpContext.Response.BufferOutput = false;
                httpContext.Response.ContentType = "application/octet-stream";
                httpContext.Response.Charset = "utf-8";
                httpContext.Response.HeaderEncoding = System.Text.Encoding.UTF8;
                httpContext.Response.ContentEncoding = System.Text.Encoding.UTF8;
                if (!String.IsNullOrEmpty(filename))
                {
                    if (filename.IndexOf('/') > -1)
                        filename = filename.Split('/')[filename.Split('/').Length - 1].Split('_')[filename.Split('/')[filename.Split('/').Length - 1].Split('_').Length - 1];
                    if (httpContext.Request.UserAgent != null && ValidateIsIEBrowser(httpContext.Request.UserAgent))
                    {
                        httpContext.Response.AppendHeader("Content-Disposition", "attachment;filename=\"" + ReplaceDownFileName(HttpUtility.UrlEncode(filename, Encoding.UTF8).Replace("+", "%20")) + "\"");
                    }
                    else
                    {
                        httpContext.Response.AppendHeader("Content-Disposition", "attachment;filename=\"" + ReplaceDownFileName(HttpUtility.HtmlEncode(filename)) + "\"");
                    }
                }
                if (datas != null)
                {
                    httpContext.Response.AppendHeader("Content-Length", datas.Length.ToString());
                    //if (isExpires)
                    //{
                    //    httpContext.Response.AppendHeader("Expires", DateTime.Now.AddMinutes(GlobalSettings.CatchExpires).ToString());
                    //}
                    httpContext.Response.BinaryWrite(datas);
                }
                else
                {
                    httpContext.Response.WriteFile(String.Empty);
                }
                httpContext.Response.Flush();
                
            }
            catch
            {
                httpContext.Response.WriteFile(String.Empty);
            }
        }
        /// <summary>
        /// 处理下载文件时，输入出文件流 
        /// </summary>
        /// <param name="datas">文件内容(文件流)</param>
        protected void HandlerDownLoadFile(HttpContext httpContext, byte[] datas)
        {
            HandlerDownLoadFile(httpContext, datas,string.Empty);
        }

        protected void HandlerDownLoadFile(HttpContext httpContext, string filepath)
        {
            try
            {
                String strFile = String.Empty;
                string fileType = String.Empty;
                if (!BasePage.GetRequest("filepath", out strFile))
                {
                    if (!String.IsNullOrEmpty(filepath))
                        strFile = filepath;
                    else
                    {
                        httpContext.Response.Write("");
                        return;
                    }
                }
                BasePage.GetRequest("fType", out fileType);
                httpContext.Response.Clear();
                httpContext.Response.ClearContent();
                httpContext.Response.ClearHeaders();
                httpContext.Response.BufferOutput = false;
                httpContext.Response.ContentType = "application/octet-stream";
                httpContext.Response.Charset = "utf-8";
                httpContext.Response.HeaderEncoding = System.Text.Encoding.UTF8;
                httpContext.Response.ContentEncoding = System.Text.Encoding.UTF8;
                String strDownFileName = strFile.Split('/')[strFile.Split('/').Length - 1].Split('_')[strFile.Split('/')[strFile.Split('/').Length - 1].Split('_').Length - 1];
                if (ValidateIsIEBrowser(httpContext.Request.UserAgent))
                {
                    httpContext.Response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(strDownFileName, Encoding.UTF8).Replace("+", "%20"));
                }
                else
                {
                    httpContext.Response.AppendHeader("Content-Disposition", "attachment;filename=" + Server.HtmlEncode(strDownFileName));
                }
                httpContext.Response.WriteFile(strFile);
                httpContext.Response.Flush();
                httpContext.Response.End();
            }
            catch
            {
                httpContext.Response.Write("");
                return;
            }

        }

        
    }
}
