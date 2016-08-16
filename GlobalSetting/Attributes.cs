using System;
using System.Reflection;

namespace XFCompany.CIPNet.GlobalSetting
{
    /// <summary>
    /// 提供界面显示帮助属性。
    /// </summary>
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = true)]
    public class UITextAttribute : Attribute
    {
        private string text;
        /// <summary>
        /// 帮助内容。
        /// </summary>
        public virtual string Text
        {
            get { return String.IsNullOrEmpty(text) ? "" : text; }
        }
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="helpText">在界面显示的文本。</param>
        public UITextAttribute(string helpText)
        {
            this.text = helpText;
        }
    }
    /// <summary>
    /// 提供系统帮助的类。
    /// </summary>
    public class Helper
    {
        /// <summary>
        /// 获取给定枚举值的界面显示文本。
        /// </summary>
        /// <param name="enumValue">给定的枚举值。</param>
        /// <returns>界面显示文本。</returns>
        public static string GetUIText(Enum enumValue)
        {
            Type objType = enumValue.GetType();
            string s = enumValue.ToString();
            UITextAttribute[] UIAttribute = (UITextAttribute[])objType.GetField(s).GetCustomAttributes(typeof(UITextAttribute), false);

            if (null != UIAttribute && UIAttribute.Length == 1)
            {
                return UIAttribute[0].Text;
            }
            else
            {
                return String.Empty;
            }
        }

        /// <summary>
        /// 获取给定类属性的界面显示文本。
        /// </summary>
        /// <param name="t">类。</param>
        /// <param name="mi">类中的属性。</param>
        /// <returns>界面显示文本。</returns>
        public static string GetUIText(Type t, MemberInfo mi)
        {
            UITextAttribute UIAttribute = (UITextAttribute)Attribute.GetCustomAttribute(mi, typeof(UITextAttribute), false);

            if (null != UIAttribute)
            {
                return UIAttribute.Text;
            }
            else
            {
                return String.Empty;
            }
        }


        /// <summary>
        /// 获取给定枚举值的界面显示文本。
        /// </summary>
        /// <param name="t">枚举。</param>
        /// <param name="Text">文本。</param>
        /// <returns>枚举值。</returns>
        public static string GetValue(Type t, string Text)
        {
            FieldInfo[] fieldInfos = t.GetFields();
            foreach (FieldInfo fieldInfo in fieldInfos)
            {
                UITextAttribute[] UIAttribute = (UITextAttribute[])fieldInfo.GetCustomAttributes(typeof(UITextAttribute), false);

                if (null != UIAttribute && UIAttribute.Length == 1)
                {
                    if (Text == UIAttribute[0].Text)
                    {
                        return fieldInfo.Name;
                    }
                }
            }
            return String.Empty;
        }
    }
}
