using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace XFCompany.CIPnetWeb.LogicModel
{
    static class HtmlParser
    {
        #region 静态函数


        /// <summary>
        /// 得到下一个标记开始的位置
        /// </summary>
        /// <param name="SrcContent">Html内容</param>
        /// <param name="StartPosition">起始位置</param>
        /// <returns>-1：没有找到标记开始，其他为对应位置</returns>
        private static int GetNextTagStartPosition(string SrcContent, int StartPosition)
        {
            return SrcContent.IndexOf('<', StartPosition);
        }

        /// <summary>
        /// 得到下一个标记结束的位置
        /// </summary>
        /// <param name="SrcContent">Html内容</param>
        /// <param name="StartPosition">起始位置</param>
        /// <returns>-1：没有找到标记结束，其他为对应位置</returns>
        private static int GetNextTagEndPosition(string SrcContent, int StartPosition)
        {
            bool IsDoubleChar = true;
            char[] EndTagChars = "\"'>".ToCharArray();
            int iPos = SrcContent.IndexOfAny(EndTagChars, StartPosition);
            while (iPos > -1)
            {

                if (SrcContent[iPos] == '>')
                {
                    if (IsDoubleChar)
                        break;
                }
                else
                {
                    if (IsDoubleChar)
                    {
                        iPos = SrcContent.IndexOf(SrcContent[iPos], iPos + 1);
                        if (iPos == -1)
                            IsDoubleChar = !IsDoubleChar;
                    }
                }
                
                if (iPos > -1)
                    iPos = SrcContent.IndexOfAny(EndTagChars, iPos + 1);

                //if (SrcContent[iPos] == '>')
                //{
                //    if (IsDoubleChar)
                //        break;
                //}
                //else
                //{
                //    IsDoubleChar = !IsDoubleChar;
                //}
                //iPos = SrcContent.IndexOfAny(EndTagChars, iPos + 1);
            }
            return iPos;
        }

        private static string GetTagAndTagInfo(string SrcContent, int TagEnd, int TagStart, out string TagInfo)
        {
            TagInfo = SrcContent.Substring(TagStart, TagEnd - TagStart - 1).Trim(" \r\n".ToCharArray());

            int Pos = TagInfo.IndexOf(' ');
            return ((Pos > 0) ? TagInfo.Substring(0, Pos) : TagInfo).TrimEnd("/".ToCharArray()).ToLower();
        }
        #endregion


        /// <summary>
        /// 获得到指定结束位置的最后一个Url地址。
        /// </summary>
        /// <param name="Content">待抽取内容。</param>
        /// <param name="EndPos">结束位置。</param>
        /// <param name="BaseUrl">基地址。</param>
        /// <returns>最后一个Url地址，如果为null则表示没有找到地址。</returns>
        public static Uri GetLastUrl(string Content, int EndPos, Uri BaseUrl)
        {
            int posS = Content.LastIndexOf(" href=", StringComparison.OrdinalIgnoreCase);
            if (posS > -1)
            {
                posS += 6;
                while (Content[posS] == ' ')
                    posS++;
                char chEnd;
                if ("'\"".IndexOf(Content[posS]) == -1)
                    chEnd = ' ';
                else
                {
                    chEnd = Content[posS];
                    posS++;
                }

                int posE = Content.IndexOf(chEnd, posS);
                if (posE > posS && posE <= EndPos)
                {
                    Uri newUri;
                    if (Uri.TryCreate(BaseUrl, Content.Substring(posS, posE - posS), out newUri))
                        return newUri;
                }
            }
            return null;
        }

        /// <summary>
        /// 格式化Html正文.
        /// </summary>
        /// <param name="Content">Html文档内容。</param>
        /// <param name="Buf">结果缓冲区。</param>
        public static void FormatHtml(string Content, HtmlBufBase Buf)
        {
            if (string.IsNullOrEmpty(Content))
                return;

            int TagEnd = 0;
            bool bIsNotInHideTag = true;  // 是否不在隐藏的标记内容中
            bool bIsNotInStyle = true;

            string HideTag = null;
            string LastTag = null;
            string Tag = string.Empty;
            #region MyRegion
            //do
            //{
            //    // 找标记开始
            //    int TagStart = GetNextTagStartPosition(Content, TagEnd);
            //    if (TagStart == -1) TagStart = Content.Length;// 达到结尾
            //    // 转换内容
            //    if (bIsNotScript && bIsNotInHideTag && bIsNotInStyle)
            //        Buf.AppendText( Content.Substring(TagEnd, TagStart - TagEnd),Tag);

            //    // 找标记结束
            //    TagEnd = GetNextTagEndPosition(Content, TagStart);
            //    if (TagEnd > -1)
            //    {
            //        TagEnd++;
            //        TagStart++;
            //        string TagInfo;
            //        Tag = GetTagAndTagInfo(Content, TagEnd, TagStart, out TagInfo);

            //        if (Tag == "script")  // 脚本开始
            //            bIsNotScript = false;
            //        else if (Tag == "/script")  // 脚本结束
            //            bIsNotScript = true;
            //        else if (Tag == "style")
            //            bIsNotInStyle = false;
            //        else if (Tag == "/style")
            //            bIsNotInStyle = true;
            //        else if (TagInfo.ToLower().IndexOf("display:none") > 0)
            //        {
            //            bIsNotInHideTag = false;
            //            HideTag = Tag;
            //        }
            //        else if (Tag == "/" + HideTag)
            //        {
            //            bIsNotInHideTag = true;
            //            HideTag = null;
            //        }
            //        else
            //            Buf.AppendTag(Tag, TagInfo);

            //        //else if (Tag == "base")
            //        //    BaseUrl = GetBaseUrl(TagInfo);
            //        LastTag = Tag;
            //    }
            //    else
            //        break;
            //} while (true); 
            #endregion
            do
            {
                // 找标记开始
                int TagStart = GetNextTagStartPosition(Content, TagEnd);
                if (TagStart == -1)
                    TagStart = Content.Length;// 达到结尾

                // 转换内容
                if (bIsNotInHideTag && bIsNotInStyle)
                    Buf.AppendText(Content.Substring(TagEnd, TagStart - TagEnd), Tag);
                // 判断是否是注释
                if (TagStart != -1 && TagStart < Content.Length-2 && Content[TagStart + 1] == '!' && Content[TagStart + 2] == '-')
                {
                    TagEnd = Content.IndexOf("-->", TagStart);
                    if (TagEnd == -1)
                    {
                        TagEnd = Content.Length;
                    }
                    else
                    {
                        TagEnd = TagEnd + 3;
                        continue;
                    }
                }
                // 找标记结束
                TagEnd = GetNextTagEndPosition(Content, TagStart);
                if (TagEnd > -1)
                {
                    TagEnd++;
                    TagStart++;
                    string TagInfo;
                    Tag = GetTagAndTagInfo(Content, TagEnd, TagStart, out TagInfo);

                    if (Tag == "script")  // 脚本开始
                    {
                        int scriptEndPos = Content.IndexOf("</script>", TagStart, StringComparison.OrdinalIgnoreCase);
                        if (scriptEndPos > 0)
                        {
                            TagEnd = scriptEndPos + 9;
                        }
                        else
                        {
                            TagEnd = Content.Length;
                        }
                    }
                    else if (Tag == "style")
                    {
                        bIsNotInStyle = false;
                    }
                    else if (Tag == "/style")
                    {
                        bIsNotInStyle = true;
                    }
                    else if (TagInfo.ToLower().IndexOf("display:none") > 0)
                    {
                        bIsNotInHideTag = false;
                        HideTag = Tag;
                    }
                    else if (Tag == "/" + HideTag)
                    {
                        bIsNotInHideTag = true;
                        HideTag = null;
                    }
                    else
                        Buf.AppendTag(Tag, TagInfo);

                    //else if (Tag == "base")
                    //    BaseUrl = GetBaseUrl(TagInfo);
                    LastTag = Tag;
                }
                else
                    break;
            } while (true);
            Buf.ReFormatText();
        }

        /// <summary>
        /// 预处理替换的标记
        /// </summary>
        /// <param name="Content"></param>
        /// <returns></returns>
        public static string ParseReplaceSymbol(string Content, HtmlBufBase Buf)
        {
            StringBuilder sb = new StringBuilder();
            if (string.IsNullOrEmpty(Content))
                return string.Empty;
            int TagEnd = 0;
            bool bIsNotInHideTag = true;  // 是否不在隐藏的标记内容中
            bool bIsNotInStyle = true;
            string HideTag = null;
            string Tag = string.Empty;
            do
            {
                // 找标记开始
                int TagStart = GetNextTagStartPosition(Content, TagEnd);
                if (TagStart == -1)
                    TagStart = Content.Length;// 达到结尾
                // 转换内容
                if (bIsNotInHideTag && bIsNotInStyle)
                    sb.Append(Content.Substring(TagEnd, TagStart - TagEnd));
                // 判断是否是注释
                if (TagStart != -1 && TagStart < Content.Length - 2 && Content[TagStart + 1] == '!' && Content[TagStart + 2] == '-')
                {
                    TagEnd = Content.IndexOf("-->", TagStart);
                    if (TagEnd == -1)
                    {
                        TagEnd = Content.Length;
                    }
                    else
                    {
                        TagEnd = TagEnd + 3;
                        continue;
                    }
                }
                // 找标记结束
                TagEnd = GetNextTagEndPosition(Content, TagStart);
                if (TagEnd > -1)
                {
                    TagEnd++;
                    TagStart++;
                    string TagInfo;
                    Tag = GetTagAndTagInfo(Content, TagEnd, TagStart, out TagInfo);
                    if (Tag == "script")  // 脚本开始
                    {
                        int scriptEndPos = Content.IndexOf("</script>", TagStart, StringComparison.OrdinalIgnoreCase);
                        if (scriptEndPos > 0)
                        {
                            TagEnd = scriptEndPos + 9;
                        }
                        else
                        {
                            TagEnd = Content.Length;
                        }
                    }
                    else if (Tag == "style")
                    {
                        bIsNotInStyle = false;
                    }
                    else if (Tag == "/style")
                    {
                        bIsNotInStyle = true;
                    }
                    else if (TagInfo.ToLower().IndexOf("display:none") > 0)
                    {
                        bIsNotInHideTag = false;
                        HideTag = Tag;
                    }
                    else if (Tag == "/" + HideTag)
                    {
                        bIsNotInHideTag = true;
                        HideTag = null;
                    }
                    else
                        Buf.PreAppendTagReplace(Tag, TagInfo, sb);
                }
                else
                    break;
            } while (true);
            return sb.ToString();
        }
        /// <summary>
        /// 预处理不保存的标记
        /// </summary>
        /// <param name="Content"></param>
        /// <returns></returns>
        public static string ParseNotSaveSymbol(string Content, HtmlBufBase Buf)
        {
            StringBuilder sb = new StringBuilder();
            if (string.IsNullOrEmpty(Content))
                return string.Empty;

            int TagEnd = 0;
            bool bIsNotInHideTag = true;  // 是否不在隐藏的标记内容中
            bool bIsNotInStyle = true;

            string HideTag = null;
            string Tag = string.Empty;
            do
            {
                // 找标记开始
                int TagStart = GetNextTagStartPosition(Content, TagEnd);
                if (TagStart == -1)
                    TagStart = Content.Length;// 达到结尾

                // 转换内容
                if (bIsNotInHideTag && bIsNotInStyle)
                    sb.Append(Content.Substring(TagEnd, TagStart - TagEnd));
                // 判断是否是注释
                if (TagStart != -1 && TagStart < Content.Length - 2 && Content[TagStart + 1] == '!' && Content[TagStart + 2] == '-')
                {
                    TagEnd = Content.IndexOf("-->", TagStart);
                    if (TagEnd == -1)
                    {
                        TagEnd = Content.Length;
                    }
                    else
                    {
                        TagEnd = TagEnd + 3;
                        continue;
                    }
                }
                // 找标记结束
                TagEnd = GetNextTagEndPosition(Content, TagStart);
                if (TagEnd > -1)
                {
                    TagEnd++;
                    TagStart++;
                    string TagInfo;
                    Tag = GetTagAndTagInfo(Content, TagEnd, TagStart, out TagInfo);

                    if (Tag == "script")  // 脚本开始
                    {
                        int scriptEndPos = Content.IndexOf("</script>", TagStart, StringComparison.OrdinalIgnoreCase);
                        if (scriptEndPos > 0)
                        {
                            TagEnd = scriptEndPos + 9;
                        }
                        else
                        {
                            TagEnd = Content.Length;
                        }
                    }
                    else if (Tag == "style")
                    {
                        bIsNotInStyle = false;
                    }
                    else if (Tag == "/style")
                    {
                        bIsNotInStyle = true;
                    }
                    else if (TagInfo.ToLower().IndexOf("display:none") > 0)
                    {
                        bIsNotInHideTag = false;
                        HideTag = Tag;
                    }
                    else if (Tag == "/" + HideTag)
                    {
                        bIsNotInHideTag = true;
                        HideTag = null;
                    }
                    else
                        Buf.PreAppendTagSave(Tag, TagInfo, sb);
                }
                else
                    break;
            } while (true);
            return sb.ToString();
        }

        #region 地址类格式化

        ///// <summary>
        ///// 把地址转换为绝对地址。
        ///// </summary>
        ///// <param name="BaseUrl">基地址。</param>
        ///// <param name="Url">相对地址。</param>
        ///// <returns>绝对地址。</returns>
        //public static string Format_Url(Uri BaseUrl, string Url)
        //{
        //    if (string.IsNullOrEmpty(Url))
        //        return null;

        //    //if (Url[0] == '?')
        //    //{
        //    //    if (string.IsNullOrEmpty(BaseUrl.Query))
        //    //        Url = BaseUrl.ToString() + Url;
        //    //    else
        //    //        Url = BaseUrl.AbsolutePath + Url;
        //    //}
        //    ////if (Url[0] == '?')
        //    ////    Url = BaseUrl.ToString() + Url;
        //    //else 
        //        if (Url.IndexOf("://") == -1 && BaseUrl != null)
        //    {
        //        Uri newUri;// = new Uri(BaseUrl, Url);
        //        if (Url[0] == '?')
        //        {
        //            if (string.IsNullOrEmpty(BaseUrl.Query))
        //                Url = BaseUrl.ToString() + Url;
        //            else
        //                Url = BaseUrl.AbsolutePath + Url;
        //        }
        //        try
        //        {
        //            if (Uri.TryCreate(BaseUrl, Url, out newUri))
        //                Url = newUri.AbsoluteUri;
        //        }
        //        catch
        //        {
        //            System.Diagnostics.Trace.WriteLine("Error In Format_Url:" + Url);
        //            return null;
        //        }
        //    }
        //    return Url.Replace("&amp;", "&").Replace("&lt;", "<").Replace("&gt;", ">");
        //}
        #endregion

        /// <summary>
        /// 过滤Html标记。
        /// </summary>
        /// <param name="Content"></param>
        /// <returns></returns>
        public static string FormatHtmlTitle(string Content)
        {
            HtmlTextBuf Buf = new HtmlTextBuf();
            FormatHtml(Content, Buf);
            return Buf.ToString();
        }
    }
}
