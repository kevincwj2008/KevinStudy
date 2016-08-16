using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XFCompany.CIPnetWeb.LogicModel
{
    /// <summary>
    /// 内容缓冲区。
    /// </summary>
    class HtmlBufBase
    {
        protected HtmlBufBase() { }

        protected StringBuilder Buf = new StringBuilder(2048);

        /// <summary>
        /// 添加Html文本内容。
        /// </summary>
        /// <param name="Text">Html文本。</param>
        /// <param name="Tag">标记名称。</param>
        public virtual void AppendText(string Text, string Tag) { this.Buf.Append(Text); }

        /// <summary>
        /// 添加标记内容。
        /// </summary>
        /// <param name="Tag">标记名称。</param>
        /// <param name="TagInfo">标记详细内容。</param>
        public virtual void AppendTag(string Tag, string TagInfo) { }

        /// <summary>
        /// 预处理要保留的标记
        /// </summary>
        /// <param name="Tag"></param>
        /// <param name="TagInfo"></param>
        /// <param name="sb"></param>
        public virtual void PreAppendTagSave(string Tag, string TagInfo, StringBuilder sb) { }

        /// <summary>
        /// 预处理替换的标记
        /// </summary>
        /// <param name="Tag"></param>
        /// <param name="TagInfo"></param>
        /// <param name="sb"></param>
        public virtual void PreAppendTagReplace(string Tag, string TagInfo, StringBuilder sb) { }

        /// <summary>
        /// 缓冲区内容。
        /// </summary>
        /// <returns></returns>
        public override string ToString() { return Buf.ToString(); }

        protected void ChangeHtmlSpecialChar(string src, bool NotRemoveAllSpace, bool RemoveStartPara)
        {
            StringBuilder Buf;
            if (!NotRemoveAllSpace || RemoveStartPara)
                Buf = new StringBuilder();
            else
                Buf = this.Buf;
            bool bLastIsNotSpace = false;
            for (int i = 0; i < src.Length; i++)
            {
                int nLen = src.Length - i - 1;
                if (src[i] == '&')
                {
                    if (nLen > 0 && src[i + 1] == '#')
                    {
                        int Pos = src.IndexOf(';', i + 1);
                        if ((Pos - i) > 3)	// 过滤
                            i = Pos;
                    }
                    else if (nLen > 2 && IsChar(src[i + 2], 't') && src[i + 3] == ';')	// &lt; &gt;
                    {
                        if (IsChar(src[i + 1], 'l'))
                            Buf.Append('<');
                        else if (IsChar(src[i + 1], 'g'))
                            Buf.Append('>');
                        i += 3;
                    }
                    else if (nLen > 3 && src[i + 4] == ';')	// &amp; &reg;
                    {
                        if (IsChar(src[i + 1], 'a') && IsChar(src[i + 2], 'm') && IsChar(src[i + 3], 'p'))
                        {
                            Buf.Append('&');
                        }
                        else if (IsChar(src[i + 1], 'r') && IsChar(src[i + 2], 'e') && IsChar(src[i + 3], 'g'))
                        {
                        }
                        else
                        {
                            Buf.Append('&');
                            i -= 4;
                        }
                        i += 4;
                    }
                    else if (nLen > 4 && (src[i + 5] == ';' || src[i + 5] == ' '))	// &quot; &copy; &ensp; &emsp; &nbsp;
                    {
                        if (IsChar(src[i + 3], 's') && IsChar(src[i + 4], 'p'))
                        {
                            if (NotRemoveAllSpace)
                                Buf.Append(' ');
                        }
                        else if (IsChar(src[i + 1], 'q') && IsChar(src[i + 2], 'u') && IsChar(src[i + 3], 'o') && IsChar(src[i + 4], 't'))
                        {
                            Buf.Append('"');
                        }
                        else if (IsChar(src[i + 1], 'c') && IsChar(src[i + 2], 'o') && IsChar(src[i + 3], 'p') && IsChar(src[i + 4], 'y'))
                        {
                            if (NotRemoveAllSpace)
                                Buf.Append(' ');
                        }
                        else
                        {
                            Buf.Append('&');
                            i -= 5;
                        }
                        i += 5;
                    }
                    else if (nLen > 5 && src[i + 6] == ';')
                    {
                        string value = src.Substring(i + 1, 5);
                        if (string.Compare(value, "trade", true) == 0)
                            i += 6;
                        else if (string.Compare(value, "raquo", true) == 0)
                        {
                            Buf.Append(">>");
                            i += 6;
                        }
                        else if (string.Compare(value, "ldquo", true) == 0)
                        {
                            Buf.Append("“");
                            i += 6;
                        }
                        else if (string.Compare(value, "rdquo", true) == 0)
                        {
                            Buf.Append("”");
                            i += 6;
                        }
                        else if (string.Compare(value, "mdash", true) == 0)
                        {
                            Buf.Append("—");
                            i += 6;
                        }
                    }
                    else
                        Buf.Append('&');
                }
                else if ((src[i] != ' ' || bLastIsNotSpace) && src[i] != '\r' && src[i] != '\t' && src[i] != '\n')
                    Buf.Append(src[i]);
                bLastIsNotSpace = src[i] != ' ';
            }

            if (this.Buf != Buf)
            {
                if (RemoveStartPara)
                    this.Buf.Append(Buf.ToString().Trim());
                else
                    this.Buf.Append(Buf.ToString());
            }
        }
        /// <summary>
        /// 判断字符是否相等（不区分大小写）
        /// </summary>
        /// <param name="src">原字符</param>
        /// <param name="Des">目标字符，必须为小写</param>
        /// <returns>true：相同；false：不同</returns>
        internal protected static bool IsChar(char src, char Des) { return src == Des || src == Des - 20; }

        /// <summary>
        /// 重新格式化内容，主要用于内容的后续处理。
        /// </summary>
        internal virtual void ReFormatText() { }
    }

    /// <summary>
    /// Html转换为文本的缓冲区。
    /// </summary>
    class HtmlTextBuf : HtmlBufBase
    {
        public HtmlTextBuf() { }

        ///// <summary>
        ///// 替换换行等符号的内容。
        ///// </summary>
        //private string _BrPDivTag = null;

        /// <summary>
        /// 添加内容，并把Html格式化的内容转化为文本内容。
        /// </summary>
        /// <param name="HtmlText">Html格式化的内容</param>
        /// <param name="Tag">标记名称</param>
        public override void AppendText(string HtmlText, string Tag)
        {
            bool bLastIsNotSpace = false;
            for (int i = 0; i < HtmlText.Length; i++)
            {
                int nLen = HtmlText.Length - i - 1;
                if (HtmlText[i] == '&')
                {
                    if (nLen > 0 && HtmlText[i + 1] == '#')
                    {
                        int Pos = HtmlText.IndexOf(';', i + 1);
                        if ((Pos - i) > 3)	// 过滤
                            i = Pos;
                    }
                    else if (nLen > 2 && IsChar(HtmlText[i + 2], 't') && HtmlText[i + 3] == ';')	// &lt; &gt;
                    {
                        if (IsChar(HtmlText[i + 1], 'l'))
                            Buf.Append('<');
                        else if (IsChar(HtmlText[i + 1], 'g'))
                            Buf.Append('>');
                        i += 3;
                    }
                    else if (nLen > 3 && HtmlText[i + 4] == ';')	// &amp; &reg;
                    {
                        if (IsChar(HtmlText[i + 1], 'a') && IsChar(HtmlText[i + 2], 'm') && IsChar(HtmlText[i + 3], 'p'))
                        {
                            Buf.Append('&');
                        }
                        else if (IsChar(HtmlText[i + 1], 'r') && IsChar(HtmlText[i + 2], 'e') && IsChar(HtmlText[i + 3], 'g'))
                        {
                        }
                        else
                        {
                            Buf.Append('&');
                            i -= 4;
                        }
                        i += 4;
                    }
                    else if (nLen > 4 && (HtmlText[i + 5] == ';' || HtmlText[i + 5] == ' '))	// &quot; &copy; &ensp; &emsp; &nbsp;
                    {
                        if (IsChar(HtmlText[i + 3], 's') && IsChar(HtmlText[i + 4], 'p'))
                        {
                            Buf.Append(' ');
                        }
                        else if (IsChar(HtmlText[i + 1], 'q') && IsChar(HtmlText[i + 2], 'u') && IsChar(HtmlText[i + 3], 'o') && IsChar(HtmlText[i + 4], 't'))
                        {
                            Buf.Append('"');
                        }
                        else if (IsChar(HtmlText[i + 1], 'c') && IsChar(HtmlText[i + 2], 'o') && IsChar(HtmlText[i + 3], 'p') && IsChar(HtmlText[i + 4], 'y'))
                        {
                            Buf.Append(' ');
                        }
                        else
                        {
                            Buf.Append('&');
                            i -= 5;
                        }
                        i += 5;
                    }
                    else if (nLen > 5 && HtmlText[i + 6] == ';')
                    {
                        string value = HtmlText.Substring(i + 1, 5);
                        if (string.Compare(value, "trade", true) == 0)
                            i += 6;
                        else if (string.Compare(value, "raquo", true) == 0)
                        {
                            Buf.Append(">>");
                            i += 6;
                        }
                        else if (string.Compare(value, "ldquo", true) == 0)
                        {
                            Buf.Append("“");
                            i += 6;
                        }
                        else if (string.Compare(value, "rdquo", true) == 0)
                        {
                            Buf.Append("”");
                            i += 6;
                        }
                        else if (string.Compare(value, "mdash", true) == 0)
                        {
                            Buf.Append("—");
                            i += 6;
                        }
                    }
                    else
                        Buf.Append('&');
                }
                else if ((HtmlText[i] != ' ' || bLastIsNotSpace) && HtmlText[i] != '\r' && HtmlText[i] != '\t' && HtmlText[i] != '\n')
                    Buf.Append(HtmlText[i]);
                bLastIsNotSpace = HtmlText[i] != ' ';
            }

            if (this.Buf != Buf)
            {
                this.Buf.Append(Buf.ToString());
            }
        }
    }

}
