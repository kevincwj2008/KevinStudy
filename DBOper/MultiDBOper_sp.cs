using System;
using System.Data;
using System.Text;

namespace XFCompany.CIPnetWeb.DBOper
{
    /// <summary>
    /// 封装所有调用存储过程及SQL操作的方法。
    /// </summary>
    public partial class MultiDBOper : BaseDBOper
    {
        #region 有关用户基本信息的数据库操作函数
        /// <summary>
        /// <para>根据用户的序号获取用户的详细信息</para>
        /// <para>该函数调用存储过程 (xfsp_GetUserDetail @UserID)</para>
        /// </summary>
        /// <param name="UserID">用户的序号</param>
        /// <returns>用户的详细信息</returns>
        public static DataTable GetUserDetail(Guid UserID)
        {
            string spname = "csp_GetUserDetail";
            string[] spParams = SPNAME_PARAMS[spname];
            return dbo.ExecuteSP(spname, spParams, new object[] { UserID });
        }

        /// <summary>
        /// <para>根据用户的序号和AccessToken获取用户的详细信息</para>
        /// <para>该函数调用存储过程 (csp_GetUserDetailByAccessToken @UserID @AccessToken)</para>
        /// </summary>
        /// <param name="UserID">用户的序号AccessToken</param>
        /// <param name="AccessToken">登录用户的</param>
        /// <returns>用户的详细信息</returns>
        public static DataTable GetUserDetailByAccessToken(Guid UserID, String AccessToken)
        {
            string spname = "csp_GetUserDetailByAccessToken";
            string[] spParams = SPNAME_PARAMS[spname];
            return dbo.ExecuteSP(spname, spParams, new object[] { UserID, AccessToken });
        }
        #endregion 有关栏目的数据库操作函数

        #region 有关栏目、分类的数据库操作函数
        /// <summary>
        /// 获取栏目。
        /// </summary>
        /// <param name="thisPage">当前页。（如果是0则查询所有栏目。）</param>
        /// <param name="onepageNum">每页条数。</param>
        /// <param name="totalNum">总条数。</param>
        /// <param name="orderType">排序。</param>
        /// <returns></returns>
        public static DataTable GetChannels(int thisPage, int onepageNum, ref int totalNum, string orderType)
        {
            string spname = "csp_GetChannels";
            string[] spParams = SPNAME_PARAMS[spname];
            return dbo.ExecuteSP(spname, spParams, new object[] { totalNum, (thisPage < 1 ? 0 : ((thisPage - 1) * onepageNum + 1)), onepageNum, orderType }, out totalNum);
        }

        /// <summary>
        /// 获取栏目的详细信息。
        /// </summary>
        /// <param name="ChannelID">栏目ID。</param>
        /// <returns></returns>
        public static DataTable GetChannelDetail(Guid ChannelID)
        {
            string spname = "csp_GetChannelDetail";
            string[] spParams = SPNAME_PARAMS[spname];
            return dbo.ExecuteSP(spname, spParams, new object[] { ChannelID });
        }

        /// <summary>
        /// 获取栏目下的信息条数。
        /// </summary>
        /// <param name="ChannelID">栏目ID。</param>
        /// <returns></returns>
        public static int GetInfoCountByChannel(Guid ChannelID)
        {
            string spname = "csp_GetInfoCountByChannel";
            string[] spParams = SPNAME_PARAMS[spname];
            DataTable tempDt = dbo.ExecuteSP(spname, spParams, new object[] { ChannelID });
            if (tempDt != null && tempDt.Rows.Count > 0)
                return Convert.ToInt32(tempDt.Rows[0][0]);
            return 0;
        }

        /// <summary>
        /// 获取门户分类。
        /// </summary>
        /// <param name="thisPage">当前页。（如果是0则查询所有栏目。）</param>
        /// <param name="onepageNum">每页条数。</param>
        /// <param name="totalNum">总条数。</param>
        /// <param name="orderType">排序。</param>
        /// <returns></returns>
        public static DataTable GetPortalCatalogs(int thisPage, int onepageNum, ref int totalNum, string orderType)
        {
            string spname = "csp_GetPortalCatalogs";
            string[] spParams = SPNAME_PARAMS[spname];
            return dbo.ExecuteSP(spname, spParams, new object[] { totalNum, (thisPage < 1 ? 0 : ((thisPage - 1) * onepageNum + 1)), onepageNum, orderType }, out totalNum);
        }

        /// <summary>
        /// 获取地域分类。
        /// </summary>
        /// <param name="thisPage">当前页。（如果是0则查询所有栏目。）</param>
        /// <param name="onepageNum">每页条数。</param>
        /// <param name="totalNum">总条数。</param>
        /// <param name="orderType">排序。</param>
        /// <returns></returns>
        public static DataTable GetAreas(int thisPage, int onepageNum, ref int totalNum, string orderType)
        {
            string spname = "csp_GetAreas";
            string[] spParams = SPNAME_PARAMS[spname];
            return dbo.ExecuteSP(spname, spParams, new object[] { totalNum, (thisPage < 1 ? 0 : ((thisPage - 1) * onepageNum + 1)), onepageNum, orderType }, out totalNum);
        }

        /// <summary>
        /// 获取标签。
        /// </summary>
        /// <param name="thisPage">当前页。（如果是0则查询所有栏目。）</param>
        /// <param name="onepageNum">每页条数。</param>
        /// <param name="totalNum">总条数。</param>
        /// <param name="orderType">排序。</param>
        /// <returns></returns>
        public static DataTable GetTags(int thisPage, int onepageNum, ref int totalNum, string orderType)
        {
            string spname = "csp_GetTags";
            string[] spParams = SPNAME_PARAMS[spname];
            return dbo.ExecuteSP(spname, spParams, new object[] { totalNum, (thisPage < 1 ? 0 : ((thisPage - 1) * onepageNum + 1)), onepageNum, orderType }, out totalNum);
        }

        /// <summary>
        /// 获取科技厅项目申报分类。
        /// </summary>
        /// <param name="thisPage">当前页。（如果是0则查询所有栏目。）</param>
        /// <param name="onepageNum">每页条数。</param>
        /// <param name="totalNum">总条数。</param>
        /// <param name="orderType">排序。</param>
        /// <returns></returns>
        public static DataTable GetProjectApplicationCatalog(int thisPage, int onepageNum, ref int totalNum, string orderType)
        {
            string spname = "csp_GetProjectApplicationCatalog";
            string[] spParams = SPNAME_PARAMS[spname];
            return dbo.ExecuteSP(spname, spParams, new object[] { totalNum, (thisPage < 1 ? 0 : ((thisPage - 1) * onepageNum + 1)), onepageNum, orderType }, out totalNum);
        }

        /// <summary>
        /// 获取科技厅项目申报分类。
        /// </summary>
        /// <param name="thisPage">当前页。（如果是0则查询所有栏目。）</param>
        /// <param name="onepageNum">每页条数。</param>
        /// <param name="totalNum">总条数。</param>
        /// <param name="orderType">排序。</param>
        /// <returns></returns>
        public static DataTable GetSupportPolicyCatalog(int thisPage, int onepageNum, ref int totalNum, string orderType)
        {
            string spname = "csp_GetSupportPolicyCatalog";
            string[] spParams = SPNAME_PARAMS[spname];
            return dbo.ExecuteSP(spname, spParams, new object[] { totalNum, (thisPage < 1 ? 0 : ((thisPage - 1) * onepageNum + 1)), onepageNum, orderType }, out totalNum);
        }
        #endregion

        #region 有关栏目内容（资讯）的数据库操作函数
        /// <summary>
        /// 获取资讯信息。
        /// </summary>
        /// <param name="thisPage">当前页。</param>
        /// <param name="onepageNum">每页条数。</param>
        /// <param name="totalNum">总条数。</param>
        /// <param name="Status">状态。</param>
        /// <param name="ChannelID">栏目ID。</param>
        /// <param name="KeyWords">关键词。</param>
        /// <param name="orderType">排序。</param>
        /// <returns></returns>
        public static DataTable GetInformation(int thisPage, int onepageNum, ref int totalNum, int Status, String ChannelID, String KeyWords, int IsHasImage, String orderType)
        {
            string spname = "csp_GetInformation";
            string[] spParams = SPNAME_PARAMS[spname];
            return dbo.ExecuteSP(spname, spParams, new object[] { totalNum, (thisPage < 1 ? 0 : ((thisPage - 1) * onepageNum + 1)), onepageNum, Status, ChannelID, KeyWords, IsHasImage, orderType }, out totalNum);
        }

        /// <summary>
        /// 获取资讯详细信息
        /// </summary>
        /// <param name="ChannelID"></param>
        /// <returns></returns>
        public static DataTable GetInformationDetail(Guid ChannelID)
        {
            string spname = "csp_GetChannelDetail";
            string[] spParams = SPNAME_PARAMS[spname];
            return dbo.ExecuteSP(spname, spParams, new object[] { ChannelID });
        }
        #endregion

        #region 有关需求首页显示
        /// <summary>
        /// 获取首页显示服务。
        /// </summary>
        /// <param name="thisPage">当前页。</param>
        /// <param name="onepageNum">每页条数。</param>
        /// <param name="totalNum">总条数。</param>
        /// <returns></returns>
        public static DataTable GetServiceHomeShow(int thisPage, int onepageNum, ref int totalNum)
        {
            string spname = "csp_GetServiceHomeShow";
            string[] spParams = SPNAME_PARAMS[spname];
            return dbo.ExecuteSP(spname, spParams, new object[] { totalNum, (thisPage < 1 ? 0 : ((thisPage - 1) * onepageNum + 1)), onepageNum }, out totalNum);
        }

        /// <summary>
        /// 删除服务首页显示。
        /// </summary>
        /// <param name="ServiceHomeShowID">服务首页显示ID。</param>
        /// <returns></returns>
        public static void DeleteServiceHomeShow(Guid ServiceHomeShowID)
        {
            string spname = "csp_DeleteServiceHomeShow";
            string[] spParams = SPNAME_PARAMS[spname];
            dbo.ExecuteSP(spname, spParams, new object[] { ServiceHomeShowID });
        }

        /// <summary>
        /// 修改排序。
        /// </summary>
        /// <param name="ServiceHomeShowID">修改排序的ID。</param>
        /// <param name="NewOrder">新的排序。</param>
        public static void UpdateServiceHomeShowOrder(Guid ServiceHomeShowID, int NewOrder)
        {
            string spname = "csp_UpdateServiceHomeShowOrder";
            string[] spParams = SPNAME_PARAMS[spname];
            dbo.ExecuteSP(spname, spParams, new object[] { ServiceHomeShowID, NewOrder });
        }


        #endregion

        #region 有关分类服务的数据库操作函数
        public static DataTable GetServiceSort(int thisPage, int onepageNum, int sorttype, ref int totalNum)
        {
            string spname = "csp_GetServiceSort";
            string[] spParams = SPNAME_PARAMS[spname];
            return dbo.ExecuteSP(spname, spParams, new object[] { totalNum, (thisPage < 1 ? 0 : ((thisPage - 1) * onepageNum + 1)), sorttype, onepageNum }, out totalNum);
        }
        public static void UpdateServiceSortOrder(Guid ServiceHomeShowID, int NewOrder)
        {
            string spname = "csp_UpdateServiceSortOrder";
            string[] spParams = SPNAME_PARAMS[spname];
            dbo.ExecuteSP(spname, spParams, new object[] { ServiceHomeShowID, NewOrder });
        }
        #endregion
        /// <summary>
        ///获取统计数据
        /// </summary>
        /// <returns></returns>
        public static DataTable GetDataStatistics()
        {
            return dbo.ExecuteSP("csp_GetDataStatistics");
        }
        public static DataTable GetPolicy(int thisPage, int onepageNum, string keywords, ref int totalNum, string orderType)
        {
            string spname = "csp_GetPolicy";
            string[] spParams = SPNAME_PARAMS[spname];
            return dbo.ExecuteSP(spname, spParams, new object[] { totalNum, (thisPage < 1 ? 0 : ((thisPage - 1) * onepageNum + 1)), onepageNum, keywords, orderType }, out totalNum);
        }

        /// <summary>
        /// 通过政策法规的ID获取解读信息。
        /// </summary>
        /// <param name="PIDs">法规的IDs。</param>
        /// <returns></returns>
        public static DataTable GetPolicyByIds(String PIDs)
        {
            string spname = "csp_GetPolicyByIds";
            string[] spParams = SPNAME_PARAMS[spname];
            return dbo.ExecuteSP(spname, spParams, new object[] { PIDs });
        }

        #region 有关最新入驻商铺
        /// <summary>
        /// 获取最新入驻商铺。
        /// </summary>
        /// <param name="thisPage">当前页。</param>
        /// <param name="onepageNum">每页条数。</param>
        /// <param name="totalNum">总条数。</param>
        /// <returns></returns>
        public static DataTable GetShopHomeShow(int thisPage, int onepageNum, ref int totalNum)
        {
            string spname = "csp_GetShopHomeShow";
            string[] spParams = SPNAME_PARAMS[spname];
            return dbo.ExecuteSP(spname, spParams, new object[] { totalNum, (thisPage < 1 ? 0 : ((thisPage - 1) * onepageNum + 1)), onepageNum }, out totalNum);
        }

        /// <summary>
        /// 删除最新入驻商铺。
        /// </summary>
        /// <param name="ShopHomeShowID">商铺首页显示ID。</param>
        /// <returns></returns>
        public static void DeleteShopHomeShow(Guid ShopHomeShowID)
        {
            string spname = "csp_DeleteShopHomeShow";
            string[] spParams = SPNAME_PARAMS[spname];
            dbo.ExecuteSP(spname, spParams, new object[] { ShopHomeShowID });
        }

        /// <summary>
        /// 修改排序。
        /// </summary>
        /// <param name="ShopHomeShowID">修改排序的ID。</param>
        /// <param name="NewOrder">新的排序。</param>
        public static void UpdateShopHomeShowOrder(Guid ShopHomeShowID, int NewOrder)
        {
            string spname = "csp_UpdateShopHomeShowOrder";
            string[] spParams = SPNAME_PARAMS[spname];
            dbo.ExecuteSP(spname, spParams, new object[] { ShopHomeShowID, NewOrder });
        }
        #endregion

        #region 有关广告、广告位
        /// <summary>
        /// 获取广告位。
        /// </summary>
        /// <param name="thisPage">当前页。（如果是0则查询所有栏目。）</param>
        /// <param name="onepageNum">每页条数。</param>
        /// <param name="totalNum">总条数。</param>
        /// <param name="orderType">排序。</param>
        /// <returns></returns>
        public static DataTable GetAdPosition(int thisPage, int onepageNum, ref int totalNum, string orderType)
        {
            string spname = "csp_GetAdPosition";
            string[] spParams = SPNAME_PARAMS[spname];
            return dbo.ExecuteSP(spname, spParams, new object[] { totalNum, (thisPage < 1 ? 0 : ((thisPage - 1) * onepageNum + 1)), onepageNum, orderType }, out totalNum);
        }

        /// <summary>
        /// 获取广告。
        /// </summary>
        /// <param name="thisPage">当前页。</param>
        /// <param name="onepageNum">每页条数。</param>
        /// <param name="totalNum">总条数。</param>
        /// <param name="Status">广告状态。</param>
        /// <param name="Platform">所属平台。</param>
        /// <param name="PositionID">广告位置。</param>
        /// <param name="IsExpired">是否过期(-1不判断，1已过期，0未过期)。</param>
        /// <param name="KeyWords">关键词。</param>
        /// <param name="orderType">排序。</param>
        /// <returns></returns>
        public static DataTable GetAd(int thisPage, int onepageNum, ref int totalNum, int Status, int Platform, String PositionID, int IsExpired, string KeyWords, string orderType)
        {
            string spname = "csp_GetAd";
            string[] spParams = SPNAME_PARAMS[spname];
            return dbo.ExecuteSP(spname, spParams, new object[] { totalNum, (thisPage < 1 ? 0 : ((thisPage - 1) * onepageNum + 1)), onepageNum, Status, Platform, PositionID, IsExpired, KeyWords, orderType }, out totalNum);
        }

        /// <summary>
        /// 获取广告详细信息。
        /// </summary>
        /// <param name="AdID">广告ID。</param>
        /// <returns></returns>
        public static DataTable GetAdDetail(Guid AdID)
        {
            string spname = "csp_GetAdDetail";
            string[] spParams = SPNAME_PARAMS[spname];
            return dbo.ExecuteSP(spname, spParams, new object[] { AdID });
        }
        #endregion

        #region 有关创新信息锁定信息
        /// <summary>
        /// 获取创新信息平台锁定信息。
        /// </summary>
        /// <param name="thisPage">当前页。</param>
        /// <param name="onepageNum">每页条数。</param>
        /// <param name="totalNum">是否需要总条数。（不需要则传0）</param>
        /// <param name="KeyWords">查询关键词。</param>
        /// <param name="orderType">排序。（枚举）</param>
        /// <returns></returns>
        public static DataTable GetLockInfo(int thisPage, int onepageNum, ref int totalNum, string KeyWords, string orderType)
        {
            string spname = "csp_GetLockInfo";
            string[] spParams = SPNAME_PARAMS[spname];
            return dbo.ExecuteSP(spname, spParams, new object[] { totalNum, (thisPage < 1 ? 0 : ((thisPage - 1) * onepageNum + 1)), onepageNum, KeyWords, orderType }, out totalNum);
        }
        /// <summary>
        /// 获取锁定信息详情
        /// </summary>
        /// <param name="LockInfoID">锁定ID</param>
        /// <returns></returns>
        public static DataTable GetLockInfoDetail(Guid LockInfoID)
        {
            string spname = "csp_GetLockInfoDetail";
            string[] spParams = SPNAME_PARAMS[spname];
            return dbo.ExecuteSP(spname, spParams, new object[] { LockInfoID });
        }
        #endregion

        #region 有关友情链接
        /// <summary>
        /// 获取友情链接。
        /// </summary>
        /// <param name="thisPage">当前页。</param>
        /// <param name="onepageNum">每页条数。</param>
        /// <param name="totalNum">总条数。（不需要总条数传0）</param>
        /// <param name="Status">状态。</param>
        /// <param name="Platform">所属平台。</param>
        /// <param name="Type">友情链接类型，文字类型和图片类型。</param>
        /// <param name="KeyWords">查询关键词。</param>
        /// <param name="orderType">排序。</param>
        /// <returns></returns>
        public static DataTable GetFriendLink(int thisPage, int onepageNum, ref int totalNum, int Status, int Platform, int Type, string KeyWords, string orderType)
        {
            string spname = "csp_GetFriendLink";
            string[] spParams = SPNAME_PARAMS[spname];
            return dbo.ExecuteSP(spname, spParams, new object[] { totalNum, (thisPage < 1 ? 0 : ((thisPage - 1) * onepageNum + 1)), onepageNum, Status, Platform, -1, KeyWords, orderType }, out totalNum);
        }
        /// <summary>
        /// 获取友情连接详情
        /// </summary>
        /// <param name="FriendLinkID">友情链接ID</param>
        /// <returns></returns>
        public static DataTable GetFriendLinkDetail(Guid FriendLinkID)
        {
            string spname = "csp_GetFriendLinkDetail";
            string[] spParams = SPNAME_PARAMS[spname];
            return dbo.ExecuteSP(spname, spParams, new object[] { FriendLinkID });
        }
        #endregion

        #region 区域平台
        /// <summary>
        /// 获取区域平台详细信息。
        /// </summary>
        /// <param name="RegionalPlatformID">区域平台ID。</param>
        /// <returns></returns>
        public static DataTable GetRegionalPlatformDetail(Guid RegionalPlatformID)
        {
            string spname = "csp_GetRegionalPlatformDetail";
            string[] spParams = SPNAME_PARAMS[spname];
            return dbo.ExecuteSP(spname, spParams, new object[] { RegionalPlatformID });
        }

        /// <summary>
        /// 获取区域平台列表。
        /// </summary>
        /// <param name="thisPage">当前页</param>
        /// <param name="onepageNum">每页条数</param>
        /// <param name="KeyWords">关键字</param>
        /// <param name="orderType">排序</param>
        /// <param name="totalNum">总条数</param>
        /// <returns></returns>
        public static DataTable GetRegionalPlatform(int thisPage, int onepageNum, string KeyWords, string orderType, ref int totalNum)
        {
            string spname = "csp_GetRegionalPlatform";
            string[] spParams = SPNAME_PARAMS[spname];
            return dbo.ExecuteSP(spname, spParams, new object[] { totalNum, (thisPage < 1 ? 0 : ((thisPage - 1) * onepageNum + 1)), onepageNum, KeyWords, orderType }, out totalNum);
        }
        #endregion
        #region 专业平台
        /// <summary>
        /// 获取区域平台详细信息。
        /// </summary>
        /// <param name="RegionalPlatformID">区域平台ID。</param>
        /// <returns></returns>
        public static DataTable GetSpecialtyPlatformDetail(Guid RegionalPlatformID)
        {
            string spname = "csp_GetSpecialtyPlatformDetail";
            string[] spParams = SPNAME_PARAMS[spname];
            return dbo.ExecuteSP(spname, spParams, new object[] { RegionalPlatformID });
        }
        public static DataTable GetSpecialtyPlatform(int thisPage, int onepageNum, string KeyWords, string orderType, ref int totalNum)
        {
            string spname = "csp_GetSpecialtyPlatform";
            string[] spParams = SPNAME_PARAMS[spname];
            return dbo.ExecuteSP(spname, spParams, new object[] { totalNum, (thisPage < 1 ? 0 : ((thisPage - 1) * onepageNum + 1)), onepageNum, KeyWords, orderType }, out totalNum);
        }
        #endregion
        #region 区域平台
        /// <summary>
        /// 获取区域平台活動详细信息。
        /// </summary>
        /// <param name="RegionalPlatformID">区域平台ID。</param>
        /// <returns></returns>
        public static DataTable GetRegionalPlatformActivityDetail(Guid RegionalPlatformID)
        {
            string spname = "csp_GetRegionalPlatformActivityDetail";
            string[] spParams = SPNAME_PARAMS[spname];
            return dbo.ExecuteSP(spname, spParams, new object[] { RegionalPlatformID });
        }

        /// <summary>
        /// 获取区域平台活動列表。
        /// </summary>
        /// <param name="thisPage">当前页</param>
        /// <param name="onepageNum">每页条数</param>
        /// <param name="KeyWords">关键字</param>
        /// <param name="orderType">排序</param>
        /// <param name="totalNum">总条数</param>
        /// <returns></returns>
        public static DataTable GetRegionalPlatformActivity(int thisPage, int onepageNum, string KeyWords, string orderType, ref int totalNum)
        {
            string spname = "csp_GetRegionalPlatformActivity";
            string[] spParams = SPNAME_PARAMS[spname];
            return dbo.ExecuteSP(spname, spParams, new object[] { totalNum, (thisPage < 1 ? 0 : ((thisPage - 1) * onepageNum + 1)), onepageNum, KeyWords, orderType }, out totalNum);
        }
        #endregion

        #region 有关热点的操作
        /// <summary>
        /// 获取热点信息
        /// </summary>
        /// <param name="thisPage">当前页</param>
        /// <param name="onepageNum">每页条数</param>
        /// <param name="totalNum">是否需要总条数。(不需要则传0)</param>
        /// <param name="KeyWords">查询关键字</param>
        /// <param name="orderType">排序（枚举）</param>
        /// <returns></returns>
        public static DataTable GetHotInfo(int thisPage, int onepageNum, ref int totalNum, string KeyWords, string orderType)
        {
            string spname = "csp_GetHotInfo";
            string[] spParams = SPNAME_PARAMS[spname];
            return dbo.ExecuteSP(spname, spParams, new object[] { totalNum, (thisPage < 1 ? 0 : ((thisPage - 1) * onepageNum + 1)), onepageNum, KeyWords, orderType }, out totalNum);
        }
        /// <summary>
        /// 获取热点详细信息。
        /// </summary>
        /// <param name="HotInfoID">热点ID。</param>
        /// <returns></returns>
        public static DataTable GetHotInfoDetail(Guid HotInfoID)
        {
            string spname = "csp_GetHotInfoDetail";
            string[] spParams = SPNAME_PARAMS[spname];
            return dbo.ExecuteSP(spname, spParams, new object[] { HotInfoID });
        }

        #endregion

        #region 有关动态的操作
        /// <summary>
        /// 获取动态信息
        /// </summary>
        /// <param name="thisPage">当前页</param>
        /// <param name="onepageNum">每页条数</param>
        /// <param name="totalNum">是否需要总条数。(不需要则传0)</param>
        /// <param name="PortalCatalogID">门户分类ID。</param>
        /// <param name="KeyWords">查询关键字</param>
        /// <param name="orderType">排序（枚举）</param>
        /// <returns></returns>
        public static DataTable GetDynamic(int thisPage, int onepageNum, ref int totalNum, Guid PortalCatalogID, string KeyWords, string orderType)
        {
            string spname = "csp_GetDynamic";
            string[] spParams = SPNAME_PARAMS[spname];
            return dbo.ExecuteSP(spname, spParams, new object[] { totalNum, (thisPage < 1 ? 0 : ((thisPage - 1) * onepageNum + 1)), onepageNum, PortalCatalogID, KeyWords, orderType }, out totalNum);
        }
        /// <summary>
        /// 获取动态的详细
        /// </summary>
        /// <param name="DynamicID">动态ID</param>
        /// <returns></returns>
        public static DataTable GetDynamicDetail(Guid DynamicID)
        {
            string spname = "csp_GetDynamicDetail";
            string[] spParams = SPNAME_PARAMS[spname];
            return dbo.ExecuteSP(spname, spParams, new object[] { DynamicID });
        }
        #endregion

        #region 服务与门户的操作
        public static DataTable GetServicePortalCatalog(int thisPage, int onepageNum, ref int totalNum, Guid PortalCatalogID, string orderType)
        {
            string spname = "csp_GetServicePortalCatalog";
            string[] spParams = SPNAME_PARAMS[spname];
            return dbo.ExecuteSP(spname, spParams, new object[] { totalNum, (thisPage < 1 ? 0 : ((thisPage - 1) * onepageNum + 1)), onepageNum, PortalCatalogID, orderType }, out totalNum);
        }
        #endregion

        #region 商铺与门户的操作
        public static DataTable GetShopPortalCatalog(int thisPage, int onepageNum, ref int totalNum, Guid PortalCatalogID, Guid AreaID, string orderType)
        {
            string spname = "csp_GetShopPortalCatalog";
            string[] spParams = SPNAME_PARAMS[spname];
            return dbo.ExecuteSP(spname, spParams, new object[] { totalNum, (thisPage < 1 ? 0 : ((thisPage - 1) * onepageNum + 1)), onepageNum, PortalCatalogID, AreaID, orderType }, out totalNum);
        }

        /// <summary>
        /// 获取门户每个分类下的商铺。
        /// </summary>
        /// <returns></returns>
        public static DataTable GetEveryPortalCatalogShop()
        {
            return dbo.ExecuteSP("csp_GetEveryPortalCatalogShop");
        }
        #endregion

        #region 有关融资的操作
        public static DataTable GetFinancingIntention(int thisPage, int onepageNum, ref int totalNum, string KeyWords, string orderType)
        {
            string spname = "csp_GetFinancingIntention";
            string[] spParams = SPNAME_PARAMS[spname];
            return dbo.ExecuteSP(spname, spParams, new object[] { totalNum, (thisPage < 1 ? 0 : ((thisPage - 1) * onepageNum + 1)), onepageNum, KeyWords, orderType }, out totalNum);
        }

        public static DataTable GetFinancingIntentionDetail(Guid GetFinancingIntentionID)
        {
            string spname = "csp_GetFinancingIntentionDetail";
            string[] spParams = SPNAME_PARAMS[spname];
            return dbo.ExecuteSP(spname, spParams, new object[] { GetFinancingIntentionID });
        }
        #endregion

        #region 有关人才的操作
        public static DataTable GetPerson(int thisPage, int onepageNum, ref int totalNum, string portalCatalogid, string KeyWords, string orderType)
        {
            string spname = "csp_GetPerson";
            string[] spParams = SPNAME_PARAMS[spname];
            return dbo.ExecuteSP(spname, spParams, new object[] { totalNum, (thisPage < 1 ? 0 : ((thisPage - 1) * onepageNum + 1)), onepageNum, portalCatalogid, KeyWords, orderType }, out totalNum);
        }

        public static DataTable GetPersonDetail(Guid GetPersonID)
        {
            string spname = "csp_GetPersonDetail";
            string[] spParams = SPNAME_PARAMS[spname];
            return dbo.ExecuteSP(spname, spParams, new object[] { GetPersonID });
        }
        #endregion

        #region 有关视频的操作
        /// <summary>
        /// 获取视频信息。
        /// </summary>
        /// <param name="thisPage">当前页。</param>
        /// <param name="onepageNum">每页条数。</param>
        /// <param name="totalNum">总条数。</param>
        /// <param name="Status">状态。</param>
        /// <param name="catalogid">栏目ID。</param>
        /// <param name="KeyWords">关键词。</param>
        /// <param name="orderType">排序。</param>
        /// <returns></returns>
        public static DataTable GetResourcesVideo(int thisPage, int onepageNum, ref int totalNum, int status, Guid catalogid, string KeyWords, string orderType)
        {
            string spname = "csp_GetResourcesVideo";
            string[] spParams = SPNAME_PARAMS[spname];
            return dbo.ExecuteSP(spname, spParams, new object[] { totalNum, (thisPage < 1 ? 0 : ((thisPage - 1) * onepageNum + 1)), onepageNum, status, catalogid, KeyWords, orderType }, out totalNum);
        }

        /// <summary>
        /// 获取视频的详情。
        /// </summary>
        /// <param name="VideoId">视频id。</param>
        /// <returns></returns>
        public static DataTable GetResourcesVideoDetail(Guid VideoId)
        {
            string spname = "csp_GetResourcesVideoDetail";
            string[] spParams = SPNAME_PARAMS[spname];
            return dbo.ExecuteSP(spname, spParams, new object[] { VideoId });
        }
        #endregion

        #region 有关分类目录的操作
        public static DataTable GetCatalogByPath(int thisPage, int onepageNum, ref int totalNum, string orderType, string path)
        {
            string spname = "sp_GetCatalogByPath";
            string[] spParams = SPNAME_PARAMS[spname];
            return dbo.ExecuteSP(spname, spParams, new object[] { totalNum, path, (thisPage < 1 ? 0 : ((thisPage - 1) * onepageNum + 1)), onepageNum, orderType }, out totalNum);
        }

        public static DataTable GetCatalogDetail(Guid ID)
        {
            string spname = "sp_GetCatalogDetailByCatalogID";
            string[] spParams = SPNAME_PARAMS[spname];
            return dbo.ExecuteSP(spname, spParams, new object[] { ID });
        }

        public static DataTable GetCatalogDetail(string path)
        {
            string spname = "sp_GetCatalogDetailByPath";
            string[] spParams = SPNAME_PARAMS[spname];
            return dbo.ExecuteSP(spname, spParams, new object[] { path });
        }

        #endregion

        #region 政务支撑
        /// <summary>
        /// 政务支撑
        /// </summary>
        /// <param name="PolicyContentID"></param>
        /// <returns></returns>
        public static DataTable GetPolicyEffect(String type)
        {
            string spname = "csp_GetPolicyEffect";
            string[] spParams = SPNAME_PARAMS[spname];
            return dbo.ExecuteSP(spname, spParams, new object[] { type });
        }
        public static DataTable GetPolicyContentDetail(Guid PolicyContentID)
        {
            string spname = "csp_GetPolicyContentDetail";
            string[] spParams = SPNAME_PARAMS[spname];
            return dbo.ExecuteSP(spname, spParams, new object[] { PolicyContentID });
        }
        /// <summary>
        /// 获取政务支撑列表
        /// </summary>
        /// <param name="thisPage">当前页</param>
        /// <param name="onepageNum">每页的条数</param>
        /// <param name="KeyWords">关键字</param>
        /// <param name="orderType">排序</param>
        /// <param name="totalNum">总条数</param>
        /// <returns></returns>
        public static DataTable GetPolicyContent(int thisPage, int onepageNum, string KeyWords, string orderType, ref int totalNum, String PolicyContentType)
        {
            string spname = "csp_GetPolicyContent";
            string[] spParams = SPNAME_PARAMS[spname];
            return dbo.ExecuteSP(spname, spParams, new object[] { totalNum, (thisPage < 1 ? 0 : ((thisPage - 1) * onepageNum + 1)), onepageNum, KeyWords, orderType, PolicyContentType }, out totalNum);
        }
        #endregion

        #region 项目申报
        public static DataTable GetProjectApplicationDetail(Guid ProjectApplicationID)
        {
            string spname = "csp_GetProjectApplicationDetail";
            string[] spParams = SPNAME_PARAMS[spname];
            return dbo.ExecuteSP(spname, spParams, new object[] { ProjectApplicationID });
        }
        public static DataTable GetProjectApplication(int thisPage, int onepageNum, string KeyWords, string orderType, ref int totalNum, int status, string path)
        {
            string spname = "csp_GetProjectApplication";
            string[] spParams = SPNAME_PARAMS[spname];
            try
            {
                return dbo.ExecuteSP(spname, spParams, new object[] { totalNum, (thisPage < 1 ? 0 : ((thisPage - 1) * onepageNum + 1)), onepageNum, status, path, orderType, KeyWords }, out totalNum);
            }
            catch (Exception)
            {
                throw;
            }

        }
        #endregion

        public static DataTable GetSupportPolicyDetail(Guid ProjectApplicationID)
        {
            string spname = "csp_GetSupportPolicyDetail";
            string[] spParams = SPNAME_PARAMS[spname];
            return dbo.ExecuteSP(spname, spParams, new object[] { ProjectApplicationID });
        }
        public static DataTable GetSupportPolicy(int thisPage, int onepageNum, string KeyWords, string orderType, ref int totalNum, int status, string path)
        {
            string spname = "csp_GetSupportPolicy";
            string[] spParams = SPNAME_PARAMS[spname];
            try
            {
                return dbo.ExecuteSP(spname, spParams, new object[] { totalNum, (thisPage < 1 ? 0 : ((thisPage - 1) * onepageNum + 1)), onepageNum, status, path, orderType, KeyWords }, out totalNum);
            }
            catch (Exception)
            {
                throw;
            }

        }
        #region 有关标签的处理
        /// <summary>
        /// 机构打标签。
        /// </summary>
        /// <param name="ShopId">商铺编号。</param>
        /// <param name="PortalCatalogIds">门户分类编号（以逗号分隔）。</param>
        /// <param name="Weight">权重。</param>
        /// <param name="TagPath">标签。</param>
        /// <returns></returns>
        public static bool ShopAddTags(Guid ShopId, string PortalCatalogIds, int Weight, string TagPath, string ShopName)
        {
            string spname = "csp_ShopAddTags";
            string[] spParams = SPNAME_PARAMS[spname];
            DataTable tempDt = dbo.ExecuteSP(spname, spParams, new object[] { ShopId, PortalCatalogIds, Weight, TagPath, ShopName });
            if (tempDt != null && tempDt.Rows.Count > 0 && Convert.ToInt32(tempDt.Rows[0][0]) == 1)
                return true;
            return false;
        }

        /// <summary>
        /// 删除机构标签。
        /// </summary>
        /// <param name="ShopId">商铺id</param>
        /// <returns></returns>
        public static void DeleteShopTags(Guid ShopId)
        {
            string spname = "csp_DeleteShopTags";
            string[] spParams = SPNAME_PARAMS[spname];
            dbo.ExecuteSP(spname, spParams, new object[] { ShopId });
        }

        /// <summary>
        /// 服务打标签。
        /// </summary>
        /// <param name="ServiceId">服务编号。</param>
        /// <param name="ShopId">商铺编号。</param>
        /// <param name="Weight">权重。</param>
        /// <param name="TagPath">标签。</param>
        /// <returns></returns>
        public static bool ServiceAddTags(Guid ServiceId, Guid ShopId, int Weight, string TagPath, string ServiceName)
        {
            string spname = "csp_ServiceAddTags";
            string[] spParams = SPNAME_PARAMS[spname];
            DataTable tempDt = dbo.ExecuteSP(spname, spParams, new object[] { ServiceId, ShopId, Weight, TagPath, ServiceName });
            if (tempDt != null && tempDt.Rows.Count > 0 && Convert.ToInt32(tempDt.Rows[0][0]) == 1)
                return true;
            return false;
        }

        /// <summary>
        /// 通过搜索获得商铺id。
        /// </summary>
        /// <param name="thisPage">当前页。</param>
        /// <param name="onepageNum">每页条数。</param>
        /// <param name="totalNum">总条数。</param>
        /// <param name="catalog">分类。</param>
        /// <param name="TagPath">商铺标签。</param>
        /// <param name="keyword">关键词。</param>
        /// <param name="ServiceTagsPath">服务标签。</param>
        /// <param name="SearchType">搜索类型：（shopname、servicename）</param>
        /// <returns></returns>
        public static DataTable GetShopIDByTags(int thisPage, int onepageNum, ref int totalNum, string catalog, string TagPath, string keyword, string ServiceTagsPath, string SearchType)
        {
            string spname = "csp_GetPortalCatalogShop";
            string[] spParams = SPNAME_PARAMS[spname];
            return dbo.ExecuteSP(spname, spParams, new object[] { totalNum, (thisPage < 1 ? 0 : ((thisPage - 1) * onepageNum + 1)), onepageNum, catalog, TagPath, keyword, ServiceTagsPath, SearchType }, out totalNum);
        }

        public static DataTable GetPortalCatalogService(int thisPage, int onepageNum, ref int totalNum, Guid ShopId, Guid PortalCatalog, string TagPath, string Keyword)
        {
            string spname = "csp_GetPortalCatalogService";
            string[] spParams = SPNAME_PARAMS[spname];
            return dbo.ExecuteSP(spname, spParams, new object[] { totalNum, (thisPage < 1 ? 0 : ((thisPage - 1) * onepageNum + 1)), onepageNum, ShopId, TagPath, PortalCatalog, Keyword }, out totalNum);
        }

        /// <summary>
        /// 根据查询出来的商铺id，获取商铺标签和名称。
        /// </summary>
        /// <param name="ShopIds"></param>
        /// <returns></returns>
        public static DataTable GetShopTags(string ShopIds)
        {
            string spname = "csp_GetShopTags";
            string[] spParams = SPNAME_PARAMS[spname];
            return dbo.ExecuteSP(spname, spParams, new object[] { ShopIds });
        }

        public static DataTable GetServiceTags(string ServiceIds)
        {
            string spname = "csp_GetServiceTags";
            string[] spParams = SPNAME_PARAMS[spname];
            return dbo.ExecuteSP(spname, spParams, new object[] { ServiceIds });
        }
        #endregion

        #region 收藏课件、视频
        /// <summary>
        /// 获取收藏的资源、视频。
        /// </summary>
        /// <param name="thisPage">当前页。</param>
        /// <param name="onepageNum">每页条数。</param>
        /// <param name="totalNum">总条数。</param>
        /// <param name="UserId">用户id。</param>
        /// <param name="KeyWords">关键词。</param>
        /// <param name="StartDate">开始时间。</param>
        /// <param name="EndDate">结束时间。</param>
        /// <param name="Order">排序。</param>
        /// <returns></returns>
        public static DataTable GetUserResources(int thisPage, int onepageNum, ref int totalNum, Guid UserId, string KeyWords, string StartDate, string EndDate, string Order)
        {
            string spname = "csp_GetUserResources";
            string[] spParams = SPNAME_PARAMS[spname];
            return dbo.ExecuteSP(spname, spParams, new object[] { totalNum, (thisPage < 1 ? 0 : ((thisPage - 1) * onepageNum + 1)), onepageNum, UserId, KeyWords, StartDate, EndDate, Order }, out totalNum);
        }

        /// <summary>
        /// 判断用户是否收藏资源、视频。
        /// </summary>
        /// <param name="UserId">用户id。</param>
        /// <param name="ResId">资源id、视频id（以逗号分隔、带单引号）。</param>
        /// <returns></returns>
        public static DataTable GetIsCollectionResources(Guid UserId, string ResId)
        {
            string spname = "csp_GetIsCollectionResources";
            string[] spParams = SPNAME_PARAMS[spname];
            return dbo.ExecuteSP(spname, spParams, new object[] { UserId, ResId });
        }
        #endregion

        #region 有关企业级众创网络空间（2016-3-14）
        /// <summary>
        /// 插入企业栏目
        /// </summary>
        /// <param name="TemplateID"></param>
        /// <param name="EnterpriseID"></param>
        /// <returns></returns>
        public static int Insert_ES_EnterpriseChannel(Guid TemplateID, Guid EnterpriseID)
        {
            //    string spname = "csp_InsetES_EnterpriseChannel";
            //string[] spParams = SPNAME_PARAMS[spname];
            return dbo.ExecuteSql("INSERT INTO ES_EnterpriseChannel (pid,EnterpriseID,ChannelName,InfoCount,CatalogID,[Type],[Image],ImageSize)  SELECT (SELECT NEWID()) AS pid,@EnterpriseID AS EnterpriseID , ec.ChannelName,ec.InfoCount,'00000000-0000-0000-0000-000000000000' AS catalogid ,ec.[Type],ec.[Image],ec.ImgSize  FROM ES_Channel AS ec WHERE ec.pid=@TemplateID", new string[] { "@EnterpriseID", "@TemplateID" }, new object[] { TemplateID, EnterpriseID });
        }
        /// <summary>
        /// 获取企业栏目的详情
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        public static DataTable GetEnterpriseChannelDetail(Guid pid)
        {
            string spname = "csp_GetES_EnterpriseChannelDetail";
            string[] spParams = SPNAME_PARAMS[spname];
            return dbo.ExecuteSP(spname, spParams, new object[] { pid });
        }
        /// <summary>
        /// 获取某个企业的所有栏目
        /// </summary>
        /// <param name="enterpriseid"></param>
        /// <returns></returns>
        public static DataTable GetEnterpriseChannelList(Guid enterpriseid)
        {
            string spname = "csp_GetES_EnterpriseChannelList";
            string[] spParams = SPNAME_PARAMS[spname];
            return dbo.ExecuteSP(spname, spParams, new object[] { enterpriseid });
        }

        /// <summary>
        /// 获取信息的详情
        /// </summary>
        /// <param name="infoid"></param>
        /// <returns></returns>
        public static DataTable GetES_InformationDetail(string infoid)
        {
            string spname = "csp_GetES_InformationDetail";
            string[] spParams = SPNAME_PARAMS[spname];
            return dbo.ExecuteSP(spname, spParams, new object[] { infoid });
        }
        /// <summary>
        /// 获取信息的列表
        /// </summary>
        /// <param name="thisPage"></param>
        /// <param name="onepageNum"></param>
        /// <param name="totalNum"></param>
        /// <param name="?"></param>
        /// <returns></returns>
        public static DataTable GetES_InformationList(int thisPage, int onepageNum, ref int totalNum, string espriseGuid, string catalogid, string keywrods, string start, string end, String ordrby, int status)
        {
            string spname = "csp_GetES_InformationList";
            string[] spParams = SPNAME_PARAMS[spname];
            return dbo.ExecuteSP(spname, spParams, new object[] { totalNum, (thisPage < 1 ? 0 : ((thisPage - 1) * onepageNum + 1)), onepageNum, espriseGuid, catalogid, keywrods, start, end, ordrby,status }, out totalNum);
        }

        public static DataTable GetES_Template()
        {
            return dbo.ExecuteSP("csp_GetES_Template");
        }
        /// <summary>
        /// 获取企业详情
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        public static DataTable GetES_EnterpriseDetail(Guid pid)
        {
            string spname = "csp_GetES_EnterpriseDetail";
            string[] spParams = SPNAME_PARAMS[spname];
            return dbo.ExecuteSP(spname, spParams, new object[] { pid });
        }

        /// <summary>
        /// 获取企业列表
        /// </summary>
        /// <param name="thisPage">当前页</param>
        /// <param name="onepageNum">一页条数</param>
        /// <param name="totalNum">返回总条数</param>
        /// <param name="nature">企业性质</param>
        /// <param name="scale">企业规模</param>
        /// <param name="status">企业状态</param>
        /// <param name="keywords">关键字</param>
        /// <param name="orderby">排序</param>
        /// <returns></returns>
        public static DataTable GetES_EnterpriseList(int thisPage, int onepageNum, ref int totalNum, int nature, int scale, int status, string keywords, string orderby)
        {
            string spname = "csp_GetES_EnterpriseList";
            string[] spParams = SPNAME_PARAMS[spname];
            return dbo.ExecuteSP(spname, spParams, new object[] { totalNum, (thisPage < 1 ? 0 : ((thisPage - 1) * onepageNum + 1)), onepageNum, nature, scale, status, keywords, orderby }, out totalNum);
        }

        /// <summary>
        /// 获取模板栏目
        /// </summary>
        /// <returns></returns>
        public static DataTable GetES_Channel()
        {
            return dbo.ExecuteSP("csp_GetES_Channel");
        }

        /// <summary>
        /// 获取分类列表
        /// </summary>
        /// <param name="thisPage">当前页</param>
        /// <param name="onepageNum">每页的条数</param>
        /// <param name="totalNum">返回总条数</param>
        /// <param name="name">分类名称</param>
        /// <param name="status">状态(0:正常，1：锁定)</param>
        /// <param name="EnterpriseID">企业编号</param>
        /// <returns></returns>
        public static DataTable GetES_CatalogList(int thisPage, int onepageNum, ref int totalNum, string name, int status, Guid EnterpriseID)
        {
            string spname = "csp_GetES_CatalogList";
            string[] spParams = SPNAME_PARAMS[spname];
            return dbo.ExecuteSP(spname, spParams, new object[] { totalNum, (thisPage < 1 ? 0 : ((thisPage - 1) * onepageNum + 1)), onepageNum, name, status, EnterpriseID }, out totalNum);
        }
        /// <summary>
        /// 获取分类详情
        /// </summary>
        /// <param name="PID"></param>
        /// <returns></returns>
        public static DataTable GetES_CatalogDetail(Guid PID)
        {
            string spname = "csp_GetES_CatalogDetail";
            string[] spParams = SPNAME_PARAMS[spname];
            return dbo.ExecuteSP(spname, spParams, new object[] { PID });
        }

        /// <summary>
        /// 获取企业栏目列表
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        public static DataTable GetES_EnterpriseChannelList(Guid EnterpriseId)
        {
            string spname = "csp_GetES_EnterpriseChannelList";
            string[] spParams = SPNAME_PARAMS[spname];
            return dbo.ExecuteSP(spname, spParams, new object[] { EnterpriseId });
        }

        /// <summary>
        /// 获取企业下的User
        /// </summary>
        /// <param name="thisPage">The this page.</param>
        /// <param name="onepageNum">The onepage number.</param>
        /// <param name="totalNum">The total number.</param>
        /// <param name="status">The status.</param>
        /// <param name="EnterpriseID">The enterprise identifier.</param>
        /// <returns>System.Data.DataTable.</returns>
        public static DataTable GetES_Enterprise_UserList(int thisPage, int onepageNum, ref int totalNum, int status, Guid EnterpriseID,Guid userid, string orderby)
        {
            string spname = "csp_GetES_Enterprise_UserList";
            string[] spParams = SPNAME_PARAMS[spname];
            return dbo.ExecuteSP(spname, spParams, new object[] { totalNum, (thisPage < 1 ? 0 : ((thisPage - 1) * onepageNum + 1)), onepageNum, status, EnterpriseID, userid,orderby }, out totalNum);
        }


        /// <summary>
        /// 获取邀请的Email用户
        /// </summary>
        /// <param name="thisPage">The this page.</param>
        /// <param name="onepageNum">The onepage number.</param>
        /// <param name="totalNum">The total number.</param>
        /// <param name="EnterpriseID">The enterprise identifier.</param>
        /// <param name="UserID">邀请的用户</param>
        /// <param name="orderby">The orderby.</param>
        /// <returns>DataTable.</returns>
        public static DataTable GetES_Enterprise_EmailUserList(int thisPage, int onepageNum, ref int totalNum, Guid EnterpriseID, Guid UserID, string orderby)
        {
            string spname = "csp_GetES_Enterprise_EmailUserList";
            string[] spParams = SPNAME_PARAMS[spname];
            return dbo.ExecuteSP(spname, spParams, new object[] { totalNum, (thisPage < 1 ? 0 : ((thisPage - 1) * onepageNum + 1)), onepageNum, EnterpriseID, UserID, orderby }, out totalNum);
        }

        /// <summary>
        /// 判断企业是否邀请该Email用户
        /// </summary>
        /// <param name="enterpriseid">The enterpriseid.</param>
        /// <param name="email">The email.</param>
        /// <returns>DataTable.</returns>
        public static DataTable GetEnterpriseInviteEmailUser(string enterpriseid, string email)
        {
            string spname = "csp_GetEnterpriseInviteEmailUser";
            string[] spParams = SPNAME_PARAMS[spname];
            return dbo.ExecuteSP(spname, spParams, new object[] { enterpriseid,email});
        }

        #endregion
    }
}