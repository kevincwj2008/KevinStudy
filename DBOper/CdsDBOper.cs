using System;
using System.IO;
using System.Net;
using System.Text;

namespace XFCompany.CIPnetWeb.DBOper
{
    public class CdsDBOper
    {
        //private const string CdsDoamin = "http://192.168.0.3:8099";
        private const string CdsDoamin = "http://cdsapi.scscnet.cn";

        public static string RequestUrl33(string InterfaceUrl, string PostDataUrl)   
        {
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(InterfaceUrl);
            Encoding encoding = Encoding.UTF8;
            //string param = "ie=utf-8&source=txt&query=hello&t=1327829764203&token=8a7dcbacb3ed72cad9f3fb079809a127&from=auto&to=auto";
            //encoding.GetBytes(postData);
            byte[] bs = encoding.GetBytes(PostDataUrl);
            string responseData = String.Empty;
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";
            req.ContentLength = bs.Length;
            using (Stream reqStream = req.GetRequestStream())
            {
                reqStream.Write(bs, 0, bs.Length);
                reqStream.Close();
            }
            using (HttpWebResponse response = (HttpWebResponse)req.GetResponse())
            {
                using (StreamReader reader = new StreamReader(response.GetResponseStream(), encoding))
                {
                    responseData = reader.ReadToEnd().ToString();
                }
                //context.Response.Write(responseData);
            }
            return String.Empty;
        }  

        public static string GetInterfaceResult2(string InterfaceUrl, string Param)
        {
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(InterfaceUrl);
            Encoding encoding = Encoding.UTF8;
            //string param = "ie=utf-8&source=txt&query=hello&t=1327829764203&token=8a7dcbacb3ed72cad9f3fb079809a127&from=auto&to=auto";
            //encoding.GetBytes(postData);
            byte[] bs = Encoding.ASCII.GetBytes(Param);
            string responseData = String.Empty;
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";
            req.ContentLength = bs.Length;
            using (Stream reqStream = req.GetRequestStream())
            {
                reqStream.Write(bs, 0, bs.Length);
                reqStream.Close();
            }
            string Result = String.Empty;
            using (HttpWebResponse response = (HttpWebResponse)req.GetResponse())
            {
                using (StreamReader reader = new StreamReader(response.GetResponseStream(), encoding))
                {
                    responseData = reader.ReadToEnd().ToString();
                }
                Result = responseData;
            }
            return Result;

            ////HttpWebRequest request = null;
            ////HTTPSQ请求  
            ////ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
            //HttpWebRequest request = WebRequest.Create(InterfaceUrl) as HttpWebRequest;
            //request.ProtocolVersion = HttpVersion.Version10;
            //request.Method = "POST";
            //request.ContentType = "application/x-www-form-urlencoded";
            //request.UserAgent =  "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
            ////如果需要POST数据     
            ////if (!(Parameters == null || Parameters.Count == 0))
            ////{
            //    //System.Text.StringBuilder buffer = new System.Text.StringBuilder();
            //    //int i = 0;
            //    //foreach (string key in Parameters.Keys)
            //    //{
            //    //    if (i > 0)
            //    //    {
            //    //        buffer.AppendFormat("&{0}={1}", key, Parameters[key]);
            //    //    }
            //    //    else
            //    //    {
            //    //        buffer.AppendFormat("{0}={1}", key, Parameters[key]);
            //    //    }
            //    //    i++;
            //    //}
            //byte[] data = System.Text.Encoding.GetEncoding("utf-8").GetBytes(Param);
            //    using (Stream stream = request.GetRequestStream())
            //    {
            //        stream.Write(data, 0, data.Length);
            //    }
            ////}
            //HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            ////打印返回值  
            //Stream stream2 = response.GetResponseStream();   //获取响应的字符串流  
            //StreamReader sr = new StreamReader(stream2); //创建一个stream读取流  
            //return sr.ReadToEnd(); 
        } 

        /// <summary>
        /// 通过接口获取结果。
        /// </summary>
        /// <returns></returns>
        private static string GetInterfaceResult(string InterfaceUrl)
        {


            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(InterfaceUrl);
            request.Method = "GET";
            request.ContentType = "application/json";
            HttpWebResponse response = null;
            Stream stream = null;
            String result = String.Empty;
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

        #region 分类、地域、行业、专业、国家部委、地方部门
        /// <summary>
        /// 获取地区。
        /// </summary>
        /// <returns></returns>
        public static String GetCdsArea()
        {
            string InterfaceUrl = CdsDoamin + "/listarea";
            return GetInterfaceResult(InterfaceUrl);
        }

        /// <summary>
        /// 获取分类。
        /// </summary>
        /// <returns></returns>
        public static String GetCdsCatalog()
        {
            string InterfaceUrl = CdsDoamin + "/listcatalog";
            return GetInterfaceResult(InterfaceUrl);
        }

        /// <summary>
        /// 获取国家部委。
        /// </summary>
        /// <returns></returns>
        public static String GetCdsGovernment()
        {
            string InterfaceUrl = CdsDoamin + "/listgovernment";
            return GetInterfaceResult(InterfaceUrl);
        }

        /// <summary>
        /// 获取行业。
        /// </summary>
        /// <returns></returns>
        public static String GetCdsIndustry()
        {
            string InterfaceUrl = CdsDoamin + "/listindustry";
            return GetInterfaceResult(InterfaceUrl);
        }

        /// <summary>
        /// 获取地方部门。
        /// </summary>
        /// <returns></returns>
        public static String GetCdsLocalDepartment()
        {
            string InterfaceUrl = CdsDoamin + "/listlocaldepartment";
            return GetInterfaceResult(InterfaceUrl);
        }

        /// <summary>
        /// 获取专业。
        /// </summary>
        /// <returns></returns>
        public static String GetCdsProfessional()
        {
            string InterfaceUrl = CdsDoamin + "/listprofessional";
            return GetInterfaceResult(InterfaceUrl);
        }
        #endregion

        #region 订阅
        /// <summary>
        /// 获取订阅数据源。
        /// </summary>
        /// <returns></returns>
        public static String GetCdsSub_DataSources()
        {
            string InterfaceUrl = CdsDoamin + "/listSub_DataSources";
            return GetInterfaceResult(InterfaceUrl);
        }

        /// <summary>
        /// 添加订阅。
        /// </summary>
        /// <returns></returns>
        public static String AddSubscribe(Guid SubscribeID, Guid SourceID, Guid UserID, string Name, string Condition)
        {
            string InterfaceUrl = CdsDoamin + "/AddSubscribe?PID=" + SubscribeID + "&SourceID=" + SourceID + "&UserIDs=" + UserID + "&Name=" + Name + "&Condition=" + Condition;
            return GetInterfaceResult(InterfaceUrl);
        }

        /// <summary>
        /// 修改订阅。
        /// </summary>
        /// <returns></returns>
        public static String UpdateSubscribe(Guid SubscribeID, Guid SourceID,  string Name, string Condition)
        {
            string InterfaceUrl = CdsDoamin + "/UpdateSubscribe?KMSubID=" + SubscribeID + "&SourceID=" + SourceID + "&Name=" + Name + "&Condition=" + Condition;
            return GetInterfaceResult(InterfaceUrl);
        }

        /// <summary>
        /// 删除订阅。
        /// </summary>
        /// <returns></returns>
        public static String DeleteSubscribe(Guid SubscribeID, Guid SourceID)
        {
            string InterfaceUrl = CdsDoamin + "/DelSubscribe?KMSubID=" + SubscribeID + "&SourceID=" + SourceID;
            return GetInterfaceResult(InterfaceUrl);
        }

        /// <summary>
        /// 获取订阅详情。
        /// </summary>
        /// <returns></returns>
        public static String GetSubscribeDetail(Guid SubscribeID)
        {
            string InterfaceUrl = CdsDoamin + "/QuerySubscribe?KMSubID=" + SubscribeID;
            return GetInterfaceResult(InterfaceUrl);
        }

        /// <summary>
        /// 获取订阅列表。
        /// </summary>
        /// <param name="thisPage">当前页。</param>
        /// <param name="onepageNum">每页条数。</param>
        /// <param name="totalNum">总条数。</param>
        /// <param name="UserId">用户id。</param>
        /// <param name="Keywords">关键词。</param>
        /// <param name="OrderType">排序。</param>
        /// <returns></returns>
        public static String GetSubscribe(int thisPage, int onepageNum, int totalNum, Guid UserId, string Keywords, string OrderType)
        {
            string InterfaceUrl = CdsDoamin + "/ListSubscribe?thisPage=" + thisPage + "&onepageNum=" + onepageNum + "&totalNum=" + totalNum + "&UserIds=" + UserId + "&keywords=" + Keywords + "&OrderType=" + OrderType;
            return GetInterfaceResult(InterfaceUrl);
        }

        /// <summary>
        /// 修改订阅最后预览时间。
        /// </summary>
        /// <returns></returns>
        public static String UpdateSubscribeLastBrowseTime(Guid SubscribeID)
        {
            string InterfaceUrl = CdsDoamin + "/UpdateTimeSubscribe?KMSubID=" + SubscribeID;
            return GetInterfaceResult(InterfaceUrl);
        } 
        #endregion

        #region 获取列表、定制推送数据、系统推送数据、获取详情
        /// <summary>
        /// 获取CDS数据信息。
        /// </summary>
        /// <param name="Type">接口页面名称。</param>
        /// <param name="thisPage">当前页。</param>
        /// <param name="onepageNum">每页条数。</param>
        /// <param name="totalNum">总条数。</param>
        /// <param name="Keyword">关键词。</param>
        /// <param name="CatalogId">分类。</param>
        /// <param name="AreaId">地区。</param>
        /// <param name="IndustryId">行业。</param>
        /// <param name="ProfessionalId">专业。</param>
        /// <param name="GovernmentId">国家部委。</param>
        /// <param name="LocalDepartmentId">地方部门。</param>
        /// <param name="orderType">排序。</param>
        /// <param name="IsImage">是否带配图。</param>
        /// <param name="timeType">时间类型。</param>
        /// <param name="deadLine">截至日期。</param>
        /// <param name="browseTime">浏览时间。</param>
        /// <param name="IsRead">是否已读。</param>
        /// <param name="WordsSplitBySpace">拆分关键词。</param>
        /// <returns></returns>
        public static string GetCdsData(string Type, int thisPage, int onepageNum, int totalNum, string Keyword, int CatalogId, int AreaId, int IndustryId, int ProfessionalId, int GovernmentId, int LocalDepartmentId, string orderType, int IsImage, int timeType, int deadLine, string browseTime, int IsRead)
        {
            string InterfaceUrl = CdsDoamin + "/" + Type + "?thisPage=" + thisPage + "&onepageNum=" + onepageNum + "&totalNum=" + totalNum + "&Keyword=" + Keyword + "&CatalogId=" + CatalogId + "&AreaId=" + AreaId + "&IndustryId=" + IndustryId + "&ProfessionalId=" + ProfessionalId + "&GovernmentId=" + GovernmentId + "&LocalDepartmentId=" + LocalDepartmentId + "&orderType=" + orderType + "&IsImage=" + IsImage + "&timeType=" + timeType + "&deadLine=" + deadLine + "&browseTime=" + browseTime + "&IsRead=" + IsRead;
            return GetInterfaceResult(InterfaceUrl);
        }

        /// <summary>
        /// 获取定制推送信息列表。
        /// </summary>
        /// <param name="Type">接口页面名称。</param>
        /// <param name="thisPage">当前页。</param>
        /// <param name="onepageNum">每页条数。</param>
        /// <param name="totalNum">总条数。</param>
        /// <param name="Keyword">关键词。</param>
        /// <param name="UserRecommendTaskId">定制ID。</param>
        /// <param name="IsRead">是否已读。</param>
        /// <returns></returns>
        public static string GetCdsRecommendData(string Type, int thisPage, int onepageNum, int totalNum, string Keyword, int UserRecommendTaskId, int IsRead)
        {
            string InterfaceUrl = CdsDoamin + "/" + Type + "?thisPage=" + thisPage + "&onepageNum=" + onepageNum + "&totalNum=" + totalNum + "&Keyword=" + Keyword + "&UserRecommendTaskId=" + UserRecommendTaskId + "&IsRead=" + IsRead;
            return GetInterfaceResult(InterfaceUrl);
        }

        /// <summary>
        /// 获取系统推送。
        /// </summary>
        /// <param name="MatchDataType">匹配类型。</param>
        /// <param name="thisPage">当前页。</param>
        /// <param name="onepageNum">每页条数。</param>
        /// <param name="totalNum">总条数。</param>
        /// <param name="Keyword">关键词。</param>
        /// <param name="UserId">用户Id。</param>
        /// <param name="IsRead">是否阅读。</param>
        /// <returns></returns>
        public static string GetCdsSystemRecommendData(int MatchDataType, int thisPage, int onepageNum, int totalNum,int Type, string Keyword, Guid UserId, int IsRead)
        {
            string InterfaceUrl = CdsDoamin + "/ListSystemRecommendResult?MatchDataType=" + MatchDataType + "&RecommendType=" + Type + "&thisPage=" + thisPage + "&onepageNum=" + onepageNum + "&totalNum=" + totalNum + "&Keyword=" + Keyword + "&UserIds=" + UserId + "&IsRead=" + IsRead;
            return GetInterfaceResult(InterfaceUrl);
        }

        /// <summary>
        /// 登录时，把针对用户的系统推送信息存到表里。
        /// </summary>
        /// <param name="UserId">用户Id。</param>
        /// <returns></returns>
        public static void AddUserSystemRecommendData(Guid UserId)
        {
            string InterfaceUrl = CdsDoamin + "/UserLogin?UserIds=" + UserId;
            GetInterfaceResult(InterfaceUrl);
        }

        /// <summary>
        /// 获取信息详情。
        /// </summary>
        /// <param name="Type">类型。</param>
        /// <param name="InfoIds">信息ids。</param>
        /// <returns></returns>
        public static string GetCdsDataDetail(string Type,string InfoIds)
        {
            string InterfaceUrl = CdsDoamin + "/" + Type + "?id=" + InfoIds;
            return GetInterfaceResult(InterfaceUrl);
        }
        #endregion

        #region 智能匹配
        /// <summary>
        /// 智能匹配。
        /// </summary>
        /// <param name="MatchDataType">匹配类型。</param>
        /// <param name="Keyword">关键词。</param>
        /// <param name="MatchCount">匹配条数。</param>
        /// <returns></returns>
        public static string GetCdsMatchData(int MatchDataType, string Keyword, int MatchCount)
        {
            string InterfaceUrl = CdsDoamin + "/MatchHandler?type=" + MatchDataType + "&keyword=" + Keyword + "&count=" + MatchCount;
            return GetInterfaceResult(InterfaceUrl);
        }
        #endregion

        #region 定制推送操作
        /// <summary>
        /// 添加定制。
        /// </summary>
        /// <param name="UserId">用户id。</param>
        /// <param name="Name">名称。</param>
        /// <param name="MatchDataType">匹配类型。</param>
        /// <param name="Keywords">关键词。</param>
        /// <returns></returns>
        public static string AddCdsUserRecommendTask(Guid UserId, string Name, string MatchDataType, string Keywords)
        {
            string InterfaceUrl = CdsDoamin + "/AddUserRecommendTask?UserIds=" + UserId + "&Name=" + Name + "&MatchDataType=" + MatchDataType + "&Keywords=" + Keywords;
            return GetInterfaceResult(InterfaceUrl);
        }

        /// <summary>
        /// 修改定制。
        /// </summary>
        /// <param name="UserRecommendTaskId">定制id。</param>
        /// <param name="UserId">用户id。</param>
        /// <param name="Name">标题。</param>
        /// <param name="MatchDataType">匹配类型。</param>
        /// <param name="Keywords">关键词。</param>
        /// <returns></returns>
        public static string UpdateCdsUserRecommendTask(int UserRecommendTaskId, Guid UserId, string Name, string MatchDataType, string Keywords)
        {
            string InterfaceUrl = CdsDoamin + "/UpdateUserRecommendTask?UserRecommendTaskId=" + UserRecommendTaskId + "&UserIds=" + UserId + "&Name=" + Name + "&MatchDataType=" + MatchDataType + "&Keywords=" + Keywords;
            return GetInterfaceResult(InterfaceUrl);
        }

        /// <summary>
        /// 删除定制。
        /// </summary>
        /// <param name="UserRecommendTaskId">用户定制id。</param>
        /// <param name="UserId">用户id。</param>
        /// <returns></returns>
        public static string DelCdsUserRecommendTask(int UserRecommendTaskId, Guid UserId)
        {
            string InterfaceUrl = CdsDoamin + "/DelUserRecommendTask?UserRecommendTaskId=" + UserRecommendTaskId + "&UserIds=" + UserId;
            return GetInterfaceResult(InterfaceUrl);
        }

        /// <summary>
        /// 获取用户定制详情。
        /// </summary>
        /// <param name="UserRecommendTaskId">定制id。</param>
        /// <returns></returns>
        public static string GetCdsUserRecommendTaskDetail(int UserRecommendTaskId)
        {
            string InterfaceUrl = CdsDoamin + "/QueryUserRecommendTask?UserRecommendTaskId=" + UserRecommendTaskId;
            return GetInterfaceResult(InterfaceUrl);
        }

        /// <summary>
        /// 获取用户定制列表。
        /// </summary>
        /// <param name="thisPage">当前页。</param>
        /// <param name="onepageNum">每页条数。</param>
        /// <param name="totalNum">总条数。</param>
        /// <param name="UserId">用户id。</param>
        /// <param name="MatchDataType">匹配类型。</param>
        /// <param name="Keyword">关键词。</param>
        /// <returns></returns>
        public static string GetCdsUserRecommendTask(int thisPage, int onepageNum, int totalNum, Guid UserId, string MatchDataType, string Keyword)
        {
            string InterfaceUrl = CdsDoamin + "/ListUserRecommendTask?thisPage=" + thisPage + "&onepageNum=" + onepageNum + "&totalNum=" + totalNum + "&UserIds=" + UserId + "&MatchDataType=" + MatchDataType + "&Keyword=" + Keyword;
            return GetInterfaceResult(InterfaceUrl);
        }
        #endregion

        #region 企业推送操作
        /// <summary>
        /// 添加企业定制。
        /// </summary>
        /// <param name="EnterpriseId">企业id。</param>
        /// <param name="CreateUserId">创建用户id。</param>
        /// <param name="Name">定制主题。</param>
        /// <param name="MatchDataType">匹配类型。</param>
        /// <param name="Keywords">关键词。</param>
        /// <returns></returns>
        public static string AddCdsEnterpriseRecommendTask(Guid EnterpriseId, Guid CreateUserId, string Name, string MatchDataType, string Keywords)
        {
            string InterfaceUrl = CdsDoamin + "/AddEnterpriseRecommendTask?EnterpriseId=" + EnterpriseId + "&CreateUserId=" + CreateUserId + "&Name=" + Name + "&MatchDataType=" + MatchDataType + "&Keywords=" + Keywords;
            return GetInterfaceResult(InterfaceUrl);
        }

        /// <summary>
        /// 修改企业定制。
        /// </summary>
        /// <param name="EnterpriseRecommendTaskId">定制id。</param>
        /// <param name="EnterpriseId">企业id。</param>
        /// <param name="Name">定制主题。</param>
        /// <param name="MatchDataType">匹配类型。</param>
        /// <param name="Keywords">关键词。</param>
        /// <returns></returns>
        public static string UpdateCdsEnterpriseRecommendTask(int EnterpriseRecommendTaskId, Guid EnterpriseId, string Name, string MatchDataType, string Keywords)
        {
            string InterfaceUrl = CdsDoamin + "/UpdateEnterpriseRecommendTask?EnterpriseRecommendTaskId=" + EnterpriseRecommendTaskId + "&EnterpriseId=" + EnterpriseId + "&Name=" + Name + "&MatchDataType=" + MatchDataType + "&Keywords=" + Keywords;
            return GetInterfaceResult(InterfaceUrl);
        }

        /// <summary>
        /// 修改企业定制分发。
        /// </summary>
        /// <param name="EnterpriseRecommendTaskId">定制id。</param>
        /// <param name="EnterpriseId">企业id。</param>
        /// <param name="ReceiveUsersID">接收用户。</param>
        /// <param name="EsCatalogID">分发的分类。</param>
        /// <returns></returns>
        public static string UpdateCdsEnterpriseRecommendTask(int EnterpriseRecommendTaskId, Guid EnterpriseId, string ReceiveUsersID, string EsCatalogID)
        {
            string InterfaceUrl = CdsDoamin + "/UpdateEnterpriseRecommendTask?EnterpriseRecommendTaskId=" + EnterpriseRecommendTaskId + "&EnterpriseId=" + EnterpriseId + "&ReceiveUsersID=" + ReceiveUsersID + "&EsCatalogID=" + EsCatalogID;
            return GetInterfaceResult(InterfaceUrl);
        }

        /// <summary>
        /// 删除企业定制。
        /// </summary>
        /// <param name="EnterpriseRecommendTaskId">定制id。</param>
        /// <param name="EnterpriseId">企业id。</param>
        /// <returns></returns>
        public static string DelCdsEnterpriseRecommendTask(int EnterpriseRecommendTaskId, Guid EnterpriseId)
        {
            string InterfaceUrl = CdsDoamin + "/DelEnterpriseRecommendTask?EnterpriseRecommendTaskId=" + EnterpriseRecommendTaskId + "&EnterpriseId=" + EnterpriseId;
            return GetInterfaceResult(InterfaceUrl);
        }

        /// <summary>
        /// 获取企业定制详情。
        /// </summary>
        /// <param name="EnterpriseRecommendTaskId">企业定制id。</param>
        /// <returns></returns>
        public static string GetCdsEnterpriseRecommendTaskDetail(int EnterpriseRecommendTaskId)
        {
            string InterfaceUrl = CdsDoamin + "/QueryEnterpriseRecommendTask?EnterpriseRecommendTaskId=" + EnterpriseRecommendTaskId;
            return GetInterfaceResult(InterfaceUrl);
        }

        /// <summary>
        /// 获取企业定制推送列表。
        /// </summary>
        /// <param name="thisPage">当前页。</param>
        /// <param name="onepageNum">每页条数。</param>
        /// <param name="totalNum">总条数。</param>
        /// <param name="EnterpriseId">企业id。</param>
        /// <param name="MatchDataType">匹配类型。</param>
        /// <param name="Keyword">关键词。</param>
        /// <param name="StartDate">开始日期。</param>
        /// <param name="EndDate">结束日期。</param>
        /// <returns></returns>
        public static string GetCdsEnterpriseRecommendTask(int thisPage, int onepageNum, int totalNum, Guid EnterpriseId, string MatchDataType, string Keyword, string StartDate, string EndDate)
        {
            string InterfaceUrl = CdsDoamin + "/ListEnterpriseRecommendTask?thisPage=" + thisPage + "&onepageNum=" + onepageNum + "&totalNum=" + totalNum + "&EnterpriseId=" + EnterpriseId + "&MatchDataType=" + MatchDataType + "&Keyword=" + Keyword + "&begintime=" + StartDate + "&endtime=" + EndDate;
            return GetInterfaceResult(InterfaceUrl);
        }
        #endregion

        #region 收藏夹操作
        /// <summary>
        /// 添加收藏夹。
        /// </summary>
        /// <param name="FavoriteId">收藏夹id。</param>
        /// <param name="UserId">用户id。</param>
        /// <param name="Name">收藏夹名称。</param>
        /// <returns></returns>
        public static string AddFavorite(Guid FavoriteId, Guid UserId, string Name)
        {
            string InterfaceUrl = CdsDoamin + "/AddFavorite?PID=" + FavoriteId + "&UserIds=" + UserId + "&Name=" + Name;
            return GetInterfaceResult(InterfaceUrl);
        }

        /// <summary>
        /// 修改收藏夹。
        /// </summary>
        /// <param name="FavoriteId">收藏夹id。</param>
        /// <param name="Name">收藏夹名称。</param>
        /// <returns></returns>
        public static string UpdateFavorite(Guid FavoriteId, string Name)
        {
            string InterfaceUrl = CdsDoamin + "/UpdateFavorite?PID=" + FavoriteId + "&Name=" + Name;
            return GetInterfaceResult(InterfaceUrl);
        }

        /// <summary>
        /// 删除收藏夹。
        /// </summary>
        /// <param name="FavoriteId">收藏夹id。</param>
        /// <returns></returns>
        public static string DeleteFavorite(Guid FavoriteId)
        {
            string InterfaceUrl = CdsDoamin + "/DelFavorite?PID=" + FavoriteId;
            return GetInterfaceResult(InterfaceUrl);
        }

        /// <summary>
        /// 获取收藏夹详情。
        /// </summary>
        /// <returns></returns>
        public static string GetFavoriteDetail(Guid FavoriteId)
        {
            string InterfaceUrl = CdsDoamin + "/QueryFavorite?PID=" + FavoriteId;
            return GetInterfaceResult(InterfaceUrl);
        }

        /// <summary>
        /// 获取我的收藏夹。
        /// </summary>
        /// <param name="UserId">用户id。</param>
        /// <returns></returns>
        public static string GetMyFavorite(Guid UserId)
        {
            string InterfaceUrl = CdsDoamin + "/ListFavorite?UserIds=" + UserId;
            return GetInterfaceResult(InterfaceUrl);
        }

        /// <summary>
        /// 获取我的收藏夹个数。
        /// </summary>
        /// <param name="UserId">用户id。</param>
        /// <returns></returns>
        public static string GetMyFavoriteCount(Guid UserId)
        {
            string InterfaceUrl = CdsDoamin + "/CountFavorite?UserIds=" + UserId;
            return GetInterfaceResult(InterfaceUrl);
        }
        #endregion

        #region 收藏信息
        /// <summary>
        /// 添加收藏信息。
        /// </summary>
        /// <param name="FavoriteInfoId">收藏id。</param>
        /// <param name="FavoriteId">收藏夹id。</param>
        /// <param name="UserId">用户id。</param>
        /// <param name="InfoId">信息id。</param>
        /// <param name="tableName">表名。</param>
        /// <param name="Name">信息标题。</param>
        /// <param name="Abstract">摘要。</param>
        /// <param name="Url">链接地址。</param>
        /// <param name="Tags">标签。</param>
        /// <param name="IsPublish">是否公开。</param>
        /// <param name="Type">类型（原创、转载）。</param>
        /// <param name="Description">详情。</param>
        /// <returns></returns>
        public static string AddFavoriteInfo(Guid FavoriteInfoId, Guid FavoriteId, Guid UserId, string InfoId, string tableName, string Name, string Abstract, string Url, string Tags, int IsPublish, int Type, string Description)
        {
            string InterfaceUrl = "PID=" + FavoriteInfoId + "&FavoriteID=" + FavoriteId + "&UserIds=" + UserId + "&=InfoID" + InfoId + "&DataTableName=" + System.Web.HttpUtility.UrlEncode(tableName) + "&Name=" + System.Web.HttpUtility.UrlEncode(Name) + "&Abstract=" + System.Web.HttpUtility.UrlEncode(Abstract) + "&Urls=" + Url + "&Tags=" + System.Web.HttpUtility.UrlEncode(Tags) + "&IsPublish=" + IsPublish + "&types=" + Type + "&Description=" + System.Web.HttpUtility.UrlEncode(Description);
            return RequestUrl33(CdsDoamin + "/AddFavoriteinfo", InterfaceUrl);
        }

        /// <summary>
        /// 添加收藏信息。
        /// </summary>
        /// <param name="FavoriteInfoId">收藏id。</param>
        /// <param name="FavoriteId">收藏夹id。</param>
        /// <param name="Name">信息标题。</param>
        /// <param name="Abstract">摘要。</param>
        /// <param name="Url">链接地址。</param>
        /// <param name="Tags">标签。</param>
        /// <param name="IsPublish">是否公开。</param>
        /// <param name="Type">类型（原创、转载）。</param>
        /// <param name="Description">详情。</param>
        /// <returns></returns>
        public static string UpdateFavoriteInfo(Guid FavoriteInfoId, Guid FavoriteId, string Name, string Abstract, string Url, string Tags, int IsPublish, int Type, string Description)
        {
            string InterfaceUrl = CdsDoamin + "/UpdateFavoriteinfo?PID=" + FavoriteInfoId + "&FavoriteID=" + FavoriteId + "&Name=" + Name + "&Abstract=" + Abstract + "&Urls=" + Url + "&Tags=" + Tags + "&IsPublish=" + IsPublish + "&types=" + Type + "&Description=" + Description;
            return GetInterfaceResult(InterfaceUrl);
        }

        /// <summary>
        /// 删除收藏信息。
        /// </summary>
        /// <param name="FavoriteInfoId">收藏信息id。</param>
        /// <returns></returns>
        public static string DeleteFavoriteInfo(Guid FavoriteInfoId)
        {
            string InterfaceUrl = CdsDoamin + "/DelFavoriteinfo?PID=" + FavoriteInfoId;
            return GetInterfaceResult(InterfaceUrl);
        }

        /// <summary>
        /// 获取收藏信息详情。
        /// </summary>
        /// <param name="FavoriteInfoId">收藏信息id。</param>
        /// <returns></returns>
        public static string GetFavoriteInfoDetail(Guid FavoriteInfoId)
        {
            string InterfaceUrl = CdsDoamin + "/QueryFavoriteinfo?PID=" + FavoriteInfoId;
            return GetInterfaceResult(InterfaceUrl);
        }

        /// <summary>
        /// 获取收藏信息列表。
        /// </summary>
        /// <param name="thisPage">当前页。</param>
        /// <param name="onepageNum">每页条数。</param>
        /// <param name="totalNum">总条数。</param>
        /// <param name="UserId">用户id。</param>
        /// <param name="FavoriteId">收藏夹id。</param>
        /// <param name="IsPublish">是否公开。</param>
        /// <param name="Type">类型（原创、转载）。</param>
        /// <param name="StartDate">开始时间。</param>
        /// <param name="EndDate">结束时间。</param>
        /// <param name="Keywords">关键词。</param>
        /// <param name="Tags">标签。</param>
        /// <param name="OrderType">排序。</param>
        /// <returns></returns>
        public static string GetFavoriteInfo(int thisPage, int onepageNum,int totalNum,Guid UserId,Guid FavoriteId,int IsPublish,int Type,string StartDate,string EndDate,string Keywords,string Tags,string OrderType)
        {
            string InterfaceUrl = CdsDoamin + "/ListFavoriteinfo?thisPage=" + thisPage + "&onepageNum=" + onepageNum + "&totalNum=" + totalNum + "&UserID=" + UserId + "&FavoriteID=" + FavoriteId + "&IsPublish=" + IsPublish + "&types=" + Type + "&BeginTime=" + StartDate + "&EndTime=" + EndDate + "&Keywords=" + Keywords + "&Tags=" + Tags + "&OrderType=" + OrderType;
            return GetInterfaceResult(InterfaceUrl); 
        }

        /// <summary>
        /// 判断是否是否被收藏。
        /// </summary>
        /// <param name="UserId">用户id。</param>
        /// <param name="InfoUrl">url地址。</param>
        /// <returns></returns>
        public static string CheckIsFavoriteInfo(Guid UserId, string InfoUrl)
        {
            string InterfaceUrl = CdsDoamin + "/CheckIsFavoriteInfo?UserIds=" + UserId + "&Urls=" + InfoUrl;
            return GetInterfaceResult(InterfaceUrl); 
        }

        /// <summary>
        /// 取消收藏。
        /// </summary>
        /// <param name="UserId">用户id。</param>
        /// <param name="InfoUrl">url地址。</param>
        /// <returns></returns>
        public static string CancelFavoriteInfo(Guid UserId, string InfoUrl)
        {
            string InterfaceUrl = CdsDoamin + "/CancelFavoriteInfo?UserIds=" + UserId + "&Urls=" + InfoUrl;
            return GetInterfaceResult(InterfaceUrl);
        }

        /// <summary>
        /// 获取用户收藏信息的所有标签。
        /// </summary>
        /// <param name="UserId">用户id。</param>
        /// <returns></returns>
        public static string GetFavoriteInfoTags(Guid UserId)
        {
            string InterfaceUrl = CdsDoamin + "/GetFavoriteInfoTags?UserIds=" + UserId;
            return GetInterfaceResult(InterfaceUrl);
        }

        /// <summary>
        /// 获取用户收藏信息的时间分布。
        /// </summary>
        /// <param name="UserId">用户id。</param>
        /// <returns></returns>
        public static string GetFavInfoTimeDistribution(Guid UserId)
        {
            string InterfaceUrl = CdsDoamin + "/GetUserTimeInfo?UserIds=" + UserId;
            return GetInterfaceResult(InterfaceUrl);
        }
        #endregion
    }
}
