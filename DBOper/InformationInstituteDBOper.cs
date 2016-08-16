using System;
using System.IO;
using System.Net;

namespace XFCompany.CIPnetWeb.DBOper
{
    public class InformationInstituteDBOper
    {
        /// <summary>
        /// 获取科技文献的数据。
        /// </summary>
        /// <param name="thisPage">当前页。</param>
        /// <param name="onepageNum">每页条数。</param>
        /// <param name="totalNum">总条数。</param>
        /// <param name="keyword">关键词。</param>
        /// <param name="Type">类型。</param>
        /// <returns></returns>
        public static String GetScstlData(int thisPage, int onepageNum, String keyword, int Type)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://infointf.istisc.cn/SearchWx?tp=" + Type + "&keyword=" + keyword + "&thisPage=" + thisPage + "&pageSize=" + onepageNum);
            request.Method = "GET";
            request.ContentType = "application/json";
            HttpWebResponse response = null;
            Stream stream = null;
            String result = String.Empty; ;
            try
            {
                response = (HttpWebResponse)request.GetResponse();
                stream = response.GetResponseStream();
                using (StreamReader sr = new StreamReader(stream))
                {
                    result = sr.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                return String.Empty;
            }
            finally
            {
                if (stream != null)
                {
                    stream.Close();
                }
                if (response != null)
                {
                    response.Close();
                }
            }
            return  result;
        }

        /// <summary>
        /// 获取科技成果的数据。
        /// </summary>
        /// <param name="thisPage">当前页。</param>
        /// <param name="onepageNum">每页条数。</param>
        /// <param name="totalNum">总条数。</param>
        /// <param name="keyword">关键词。</param>
        /// <param name="Type">类型。</param>
        /// <returns></returns>
        public static String GetScscgData(int thisPage, int onepageNum, String keyword, int Type)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://infointf.istisc.cn/SearchCg?tp=" + Type + "&keyword=" + keyword + "&thisPage=" + thisPage + "&pageSize=" + onepageNum);
            request.Method = "GET";
            request.ContentType = "application/json";
            HttpWebResponse response = null;
            Stream stream = null;
            String result = String.Empty; ;
            try
            {
                response = (HttpWebResponse)request.GetResponse();
                stream = response.GetResponseStream();
                using (StreamReader sr = new StreamReader(stream))
                {
                    result = sr.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                return String.Empty;
            }
            finally
            {
                if (stream != null)
                {
                    stream.Close();
                }
                if (response != null)
                {
                    response.Close();
                }
            }
            return result;
        }


        public static String GetScKjbgData(int thisPage, int onepageNum, String keyword)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://infointf.istisc.cn/SearchKjbg?keyword=" + keyword + "&thisPage=" + thisPage + "&pageSize=" + onepageNum);
            request.Method = "GET";
            request.ContentType = "application/json";
            HttpWebResponse response = null;
            Stream stream = null;
            String result = String.Empty; ;
            try
            {
                response = (HttpWebResponse)request.GetResponse();
                stream = response.GetResponseStream();
                using (StreamReader sr = new StreamReader(stream))
                {
                    result = sr.ReadToEnd();

                   
                }
            }
            catch (Exception ex)
            {
                return String.Empty;
            }
            finally
            {
                if (stream != null)
                {
                    stream.Close();
                }
                if (response != null)
                {
                    response.Close();
                }
            }
            return result;
        }
    }
}
