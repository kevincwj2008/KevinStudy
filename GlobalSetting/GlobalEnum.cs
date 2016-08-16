namespace XFCompany.CIPNet.GlobalSetting
{
    /// <summary>
    /// 资源整合平台应用程序类型。
    /// </summary>
    public enum EnumAppType
    {
        /// <summary>
        /// CS架构应用程序。
        /// </summary>
        CS,
        /// <summary>
        /// BS架构应用程序。
        /// </summary>
        BS
    }

    /// <summary>
    /// 定义整个四川双创平台中的各子平台。
    /// </summary>
    public enum EnumPlatform
    {
        /// <summary>
        /// 门户
        /// </summary>
        [UIText("门户")]
        Portal,
        /// <summary>
        /// 创新信息垂直搜索引擎
        /// </summary>
        [UIText("创新信息垂直搜索引擎")]
        SearchEngines,
        /// <summary>
        /// 电商平台
        /// </summary>
        [UIText("电商平台")]
        BusinessPlatform,
        /// <summary>
        /// 众创空间
        /// </summary>
        [UIText("众创空间")]
        CyberSpace,
        /// <summary>
        /// 生态环境
        /// </summary>
        [UIText("生态环境")]
        Ecotope
    }

    /// <summary>
    /// 定义平台内所有用户类型。
    /// </summary>
    public enum EnumUserType
    {
        /// <summary>
        /// 专家/技术人员用户(个人用户)。
        /// </summary>
        [UIText("专家/技术人员")]
        UserPerson,
        /// <summary>
        /// 平台中心管理员。
        /// </summary>
        [UIText("平台中心管理员")]
        AdminPlatformCenter
    }

    /// <summary>
    /// 实名认证状态(0-已认证;1-认证审核中;2-认证未通过;3-未认证)
    /// </summary>
    public enum EnumAuthenticationStatus
    {
        /// <summary>
        /// 已认证。
        /// </summary>
        [UIText("已认证")]
        Authenticated = 0,
        /// <summary>
        /// 认证审核中。
        /// </summary>
        [UIText("认证审核中")]
        Authenticating,
        /// <summary>
        /// 认证未通过。
        /// </summary>
        [UIText("认证未通过")]
        AuthenticateFial,
        /// <summary>
        /// 未认证。
        /// </summary>
        [UIText("未认证")]
        NoAuthentication
    }
    public enum EnumLogoType
    {
        /// <summary>
        /// 正式Logo
        /// </summary>
        Logo,
        /// <summary>
        /// 临时文件的原图
        /// </summary>
        Upload,
        /// <summary>
        /// 预览图
        /// </summary>
        Preview
    }
    /// <summary>
    /// 用户是否激活。
    /// </summary>
    public enum EnumIsActivate
    {
        /// <summary>
        /// 未激活
        /// </summary>
        [UIText("未激活")]
        UnActivate,
        /// <summary>
        /// 已激活
        /// </summary>
        [UIText("已激活")]
        Activate,
        /// <summary>
        /// 邮箱未激活
        /// </summary>
        [UIText("邮箱未激活")]
        EmailUnActivate
    }

    /// <summary>
    /// 定义平台内用户的状态。
    /// </summary>
    public enum EnumUserStatus
    {
        /// <summary>
        /// 正常
        /// </summary>
        [UIText("正常")]
        Normal,
        /// <summary>
        /// 待审核
        /// </summary>
        [UIText("待审核")]
        UnVerified,
        /// <summary>
        /// 审核未通过
        /// </summary>
        [UIText("审核未通过")]
        VerifiedFail
    }

    /// <summary>
    /// 缓存类型
    /// </summary>
    public enum EnumMemcached
    {
        /// <summary>
        /// 某一用户
        /// </summary>
        [UIText("某一用户")]
        User,
        /// <summary>
        /// 所有用户（数据库中所有用户，用于解析动态）
        /// </summary>
        [UIText("所有用户")]
        AllUser,
        /// <summary>
        /// 我关注的
        /// </summary>
        [UIText("我关注的用户")]
        User_Attention,
        /// <summary>
        /// 所有用户
        /// </summary>
        [UIText("所有用户")]
        User_AllUser,
        /// <summary>
        /// 我的粉丝
        /// </summary>
        [UIText("我的粉丝")]
        User_Fans,
        /// <summary>
        /// 验证码
        /// </summary>
        [UIText("验证码。")]
        CheckCode,
        /// <summary>
        /// 资讯列表
        /// </summary>
        [UIText("资讯列表。")]
        Informations,
        /// <summary>
        /// 授权信息
        /// </summary>
        [UIText("授权信息。")]
        AccessToken,
        /// <summary>
        /// 我关注的动态
        /// </summary>
        [UIText("我关注的动态")]
        AttentionDiscuss,
        /// <summary>
        /// 所有动态
        /// </summary>
        [UIText("所有动态")]
        AllDiscuss,
        /// <summary>
        /// 所有动态数
        /// </summary>
        [UIText("所有动态数")]
        AllDiscussCount,
        /// <summary>
        /// 所有活动
        /// </summary>
        [UIText("所有活动")]
        AllEvent,
        /// <summary>
        /// Ta的动态
        /// </summary>
        [UIText("Ta的动态")]
        User_Discuss,
        /// <summary>
        /// 与我相关动态
        /// </summary>
        [UIText("与我相关动态")]
        RelatedDiscuss,
        /// <summary>
        /// At我相关动态
        /// </summary>
        [UIText("At我相关动态")]
        AtMeDiscuss,
        /// <summary>
        /// 回复我相关动态
        /// </summary>
        [UIText("回复我相关动态")]
        ReplyMeDiscuss,
        /// <summary>
        /// 我的分享相关动态
        /// </summary>
        [UIText("我的分享相关动态")]
        MyShareDiscuss,
        /// <summary>
        /// 我的活动相关动态
        /// </summary>
        [UIText("我的活动相关动态")]
        MyEventDiscuss,
        /// <summary>
        /// 圈子的活动
        /// </summary>
        [UIText("圈子的活动")]
        GroupEvent,
        /// <summary>
        /// 动态回复列表
        /// </summary>
        [UIText("动态回复列表")]
        DiscussReply,
        /// <summary>
        /// 动态回复数
        /// </summary>
        [UIText("动态回复数")]
        DiscussReplyCount,
        /// <summary>
        /// 需求缓存
        /// </summary>
        [UIText("需求缓存")]
        Demand,
        /// <summary>
        /// 需求总数
        /// </summary>
        [UIText("需求总数")]
        DemandCount,
        /// <summary>
        /// 需求回复列表
        /// </summary>
        [UIText("需求回复列表")]
        DemandReply,
        /// <summary>
        /// 需求回复数
        /// </summary>
        [UIText("需求回复数")]
        DemandReplyCount,
        /// <summary>
        /// 推荐需求缓存
        /// </summary>
        [UIText("推荐需求缓存")]
        RecommendDemand,
        /// <summary>
        /// 需求详情
        /// </summary>
        [UIText("需求详情。")]
        DemandDetail,
        /// <summary>
        /// 推荐需求总数
        /// </summary>
        [UIText("推荐需求总数")]
        RecommendDemandCount,
        /// <summary>
        /// 动态详情
        /// </summary>
        [UIText("动态详情")]
        Discuss,
        /// <summary>
        /// 话题数
        /// </summary>
        [UIText("话题数")]
        TopicCount,
        /// <summary>
        /// 话题
        /// </summary>
        [UIText("话题")]
        Topic,
        /// <summary>
        /// 用户文档数
        /// </summary>
        [UIText("用户文档数")]
        UserFileCount,
        /// <summary>
        /// 用户文档
        /// </summary>
        [UIText("用户文档")]
        UserFile,
        /// <summary>
        /// 圈子文档数
        /// </summary>
        [UIText("圈子文档数")]
        GroupFileCount,
        /// <summary>
        /// 圈子文档
        /// </summary>
        [UIText("圈子文档")]
        GroupFile,
        /// <summary>
        /// 登录用户
        /// </summary>
        [UIText("登录用户")]
        Oauth_User,
        /// <summary>
        /// 用户服务列表
        /// </summary>
        [UIText("用户服务列表")]
        User_Services,
        /// <summary>
        /// 商铺服务列表
        /// </summary>
        [UIText("商铺服务列表")]
        Shop_Services,
        /// <summary>
        /// 服务大厅列表
        /// </summary>
        [UIText("服务大厅列表")]
        Home_Services,
        /// <summary>
        /// 推荐服务列表
        /// </summary>
        [UIText("推荐服务列表")]
        Recommend_Services,
        /// <summary>
        /// 服务回复评价列表
        /// </summary>
        [UIText("服务回复评价列表")]
        ServiceReplies_Evaluate,
        /// <summary>
        /// 服务回复咨询列表
        /// </summary>
        [UIText("服务回复咨询列表")]
        ServiceReplies_Consult,
        /// <summary>
        /// 服务详情
        /// </summary>
        [UIText("服务详情")]
        ServiceDetail,
        /// <summary>
        /// 栏目列表
        /// </summary>
        [UIText("栏目列表。")]
        Channel,


        /// <summary>
        /// 在线用户
        /// </summary>
        [UIText("在线用户。")]
        OnlineUsers,



        /// <summary>
        /// 圈子数据统计
        /// </summary>
        [UIText("圈子数据统计")]
        GroupStatistics,
        /// <summary>
        /// 圈子成员
        /// </summary>
        [UIText("圈子成员")]
        GroupMember,
        /// <summary>
        /// 圈子动态
        /// </summary>
        [UIText("圈子动态")]
        Group_Discuss,
        /// <summary>
        /// 某一圈子
        /// </summary>
        [UIText("某一圈子")]
        Group,
        /// <summary>
        /// 我的圈子
        /// </summary>
        [UIText("我的圈子")]
        User_Group,
        /// <summary>
        /// 平台所有圈子
        /// </summary>
        [UIText("平台所有圈子")]
        AllGroup,
        /// <summary>
        /// 平台所有圈子数量
        /// </summary>
        [UIText("平台所有圈子数量")]
        AllGroupCount,
        /// <summary>
        /// 第三方应用的所有圈子
        /// </summary>
        [UIText("第三方应用的所有圈子")]
        AllClientGroup,
        /// <summary>
        /// 第三方应用的所有圈子数量
        /// </summary>
        [UIText("第三方应用的所有圈子数量")]
        AllClientGroupCount,
        /// <summary>
        /// 我浏览过的圈子
        /// </summary>
        [UIText("我浏览过的圈子")]
        User_Browse_Group,
        /// <summary>
        /// 某一商铺（个人）
        /// </summary>
        [UIText("某一商铺（个人）")]
        Shop_Person,
        /// <summary>
        /// 某一商铺（企业）
        /// </summary>
        [UIText("某一商铺（企业）")]
        Shop_Enterprise,
        /// <summary>
        /// 商铺数据统计
        /// </summary>
        [UIText("商铺数据统计")]
        ShopStatistics,
        /// <summary>
        /// 商铺成员
        /// </summary>
        [UIText("商铺成员")]
        ShopMember,
        /// <summary>
        /// 短链接
        /// </summary>
        [UIText("短链接")]
        ShortUrl,
        /// <summary>
        /// 用户信息统计
        /// </summary>
        [UIText("用户信息统计")]
        UserStatistics
    }
    /// <summary>
    /// 资源整合平台应用程序类型。
    /// </summary>
    public enum EnumApplicationType
    {
        /// <summary>
        /// CS架构应用程序。
        /// </summary>
        CS,
        /// <summary>
        /// BS架构应用程序。
        /// </summary>
        BS
    }

    /// <summary>
    /// 数据库字符长度
    /// </summary>
    public enum DBStringLen
    {
        /// <summary>
        /// 用户名的最大长度
        /// </summary>
        XFStringUserName = 20,
        /// <summary>
        /// 密码的最大长度
        /// </summary>
        XFStringPassword = 32,
        /// <summary>
        /// 长度为6
        /// </summary>
        XFString6 = 6,
        /// <summary>
        /// 长度为10
        /// </summary>
        XFString10 = 10,
        /// <summary>
        /// 长度为20
        /// </summary>
        XFString20 = 20,
        /// <summary>
        /// 长度为50
        /// </summary>
        XFString50 = 50,
        /// <summary>
        /// 长度为100
        /// </summary>
        XFString100 = 100,
        /// <summary>
        /// 长度为140
        /// </summary>
        XFString140 = 140,
        /// <summary>
        /// 长度为200
        /// </summary>
        XFString200 = 200,
        /// <summary>
        /// 长度为280
        /// </summary>
        XFString280 = 280,
        /// <summary>
        /// 长度为300
        /// </summary>
        XFString300 = 300,
        /// <summary>
        /// 长度为400
        /// </summary>
        XFString400 = 400,
        /// <summary>
        /// 长度为500
        /// </summary>
        XFString500 = 500,
        /// <summary>
        /// 长度为600
        /// </summary>
        XFString600 = 600,
        /// <summary>
        /// 长度为800
        /// </summary>
        XFString800 = 800,
        /// <summary>
        /// 长度为2000
        /// </summary>
        XFString2000 = 2000,
        /// <summary>
        /// 长度为1000
        /// </summary>
        XFString1000 = 1000,
        /// <summary>
        /// 长度为3000
        /// </summary>
        XFString3000 = 3000
    }
    /// <summary>
    /// 定义目录的顶级目录
    /// </summary>
    public enum EnumTopCatalog
    {
        /// <summary>
        /// 地域分类
        /// </summary>
        [UIText("地域分类")]
        City,
        /// <summary>
        /// 行业分类
        /// </summary>
        [UIText("行业分类")]
        Industry,
        /// <summary>
        /// 专业分类
        /// </summary>
        [UIText("专业分类")]
        Professional,
        /// <summary>
        /// 政策资源
        /// </summary>
        [UIText("政策资源")]
        Policy,
        /// <summary>
        /// 技术资源
        /// </summary>
        [UIText("技术资源")]
        Tech,
        /// <summary>
        /// 资金资源
        /// </summary>
        [UIText("资金资源")]
        Fund,
        /// <summary>
        /// 人才资源
        /// </summary>
        [UIText("人才资源")]
        Person,
        /// <summary>
        /// 服务资源
        /// </summary>
        [UIText("服务资源")]
        Service,
        /// <summary>
        /// 管理资源
        /// </summary>
        [UIText("管理资源")]
        Management,
        /// <summary>
        /// 市场资源
        /// </summary>
        [UIText("市场资源")]
        Market,
        /// <summary>
        /// 服务分类
        /// </summary>
        [UIText("服务分类")]
        ServiceCatalog
    }
    /// <summary>
    /// 定义平台内分类目录的状态。
    /// </summary>
    public enum EnumCatalogStatus
    {
        /// <summary>
        /// 正常
        /// </summary>
        [UIText("正常")]
        Normal,
        /// <summary>
        /// 待审核
        /// </summary>
        [UIText("待审核")]
        UnVerified,
        /// <summary>
        /// 审核未通过
        /// </summary>
        [UIText("审核未通过")]
        VerifiedFail
    }
    /// <summary>
    /// 资讯状态
    /// </summary>
    public enum EnumInformationStatus
    {
        /// <summary>
        /// 正常
        /// </summary>
        [UIText("正常")]
        Normal,
        /// <summary>
        /// 锁定
        /// </summary>
        [UIText("锁定")]
        Lock
    }
    /// <summary>
    /// 服务状态
    /// </summary>
    public enum EnumServiceStatus
    {
        /// <summary>
        /// 正常
        /// </summary>
        [UIText("正常")]
        Normal,
        /// <summary>
        /// 锁定
        /// </summary>
        [UIText("锁定")]
        Lock
    }
    /// <summary>
    /// 服务动态回复类型
    /// </summary>
    public enum EnumServiceReplyType
    {
        /// <summary>
        /// 评价
        /// </summary>
        [UIText("评价")]
        Evaluate,
        /// <summary>
        /// 咨询
        /// </summary>
        [UIText("咨询")]
        Consult
    }
    /// <summary>
    /// 定义所有用户可能执行的操作。
    /// </summary>
    public enum EnumUserAction
    {
        /// <summary>
        /// 注册。
        /// </summary>
        [UIText("注册")]
        SignUp = 0,
        /// <summary>
        /// 登录。
        /// </summary>
        [UIText("登录")]
        SignIn = 1,
        /// <summary>
        /// 登出。
        /// </summary>
        [UIText("登出")]
        SignOut = 2,
        /// <summary>
        /// 找回密码。
        /// </summary>
        [UIText("找回密码")]
        FindPassword = 3,
        /// <summary>
        /// 编辑个人信息。
        /// </summary>
        [UIText("编辑个人信息")]
        EditPersonalInfo = 4,
        /// <summary>
        /// 添加联系人。
        /// </summary>
        [UIText("添加联系人")]
        AddContact = 5,
        /// <summary>
        /// 删除联系人。
        /// </summary>
        [UIText("删除联系人")]
        DeleteContact = 6
    }
    #region 排序方式
    /// <summary>
    /// 定义平台内联系人的排序方式
    /// </summary>
    public enum EnumOrderByContact
    {
        /// <summary>
        /// 按名称降序
        /// </summary>
        [UIText("按名称降序")]
        NameDesc,
        /// <summary>
        /// 按名称升序
        /// </summary>
        [UIText("按名称升序")]
        NameAsc,
        /// <summary>
        /// 按时间升序
        /// </summary>
        [UIText("按时间升序")]
        CreatetimeAsc,
        /// <summary>
        /// 默认排序
        /// </summary>
        [UIText("默认排序")]
        CreatetimeDesc
    }

    /// <summary>
    /// 定义平台内企业空间动态的排序方式
    /// </summary>
    public enum EnumOrderByDiscuss
    {
        /// <summary>
        /// 按时间降序
        /// </summary>
        [UIText("按时间降序")]
        CreatetimeDesc,
        /// <summary>
        /// 按回复时间降序
        /// </summary>
        [UIText("按回复时间降序")]
        ReplyCreatetimeDesc,
        /// <summary>
        /// 按@时间降序
        /// </summary>
        [UIText("按@时间降序")]
        AtCreatetimeDesc,
        /// <summary>
        /// 按回复我的时间降序
        /// </summary>
        [UIText("按回复我的时间降序")]
        ReplyMeCreatetimeDesc
    }
    /// <summary>
    /// 定义平台内服务列表排序方式
    /// </summary>
    public enum EnumOrderByService
    {
        /// <summary>
        /// 按时间降序
        /// </summary>
        [UIText("按时间降序")]
        CreatetimeDesc,
        /// <summary>
        /// 按权重倒序
        /// </summary>
        [UIText("按权重倒序")]
        WeightDesc,
        /// <summary>
        /// 按服务回复时间升序
        /// </summary>
        [UIText("按服务回复时间升序")]
        ReplyCreatetimeAsc,
        /// <summary>
        /// 按服务回复时间降序
        /// </summary>
        [UIText("按服务回复时间降序")]
        ReplyCreatetimeDesc
    }
    /// <summary>
    /// 政策扶持的排序
    /// </summary>

    public enum EnumOrderBySupportPolicy
    {
        /// <summary>
        /// 按时间降序
        /// </summary>
        [UIText("按时间降序")]
        CreatetimeDesc,

        /// <summary>
        /// 按权重倒序
        /// </summary>
        [UIText("按权重倒序")] 
        WeightDesc
    }


    /// <summary>
    /// 定义平台内服务咨询动态的排序方式
    /// </summary>
    public enum EnumOrderByServiceDiscuss
    {
        /// <summary>
        /// 按时间降序
        /// </summary>
        [UIText("按时间降序")]
        CreatetimeDesc
    }
    /// <summary>
    /// 定义平台内服务列表排序方式
    /// </summary>
    public enum EnumOrderByShopService
    {
        /// <summary>
        /// 按时间倒叙
        /// </summary>
        [UIText("按时间倒叙")]
        CreatetimeDesc,
        /// <summary>
        /// 按时间升序
        /// </summary>
        [UIText("按时间升序")]
        CreatetimeAsc,
        /// <summary>
        /// 按星级倒叙
        /// </summary>
        [UIText("按星级倒叙")]
        StarCountDesc,
        /// <summary>
        /// 按星级升序
        /// </summary>
        [UIText("按星级升序")]
        StarCountAsc,
        /// <summary>
        /// 按评价倒叙
        /// </summary>
        [UIText("按评价倒叙")]
        JudgeCountDesc,
        /// <summary>
        /// 按评价升序
        /// </summary>
        [UIText("按评价升序")]
        JudgeCountAsc,
        /// <summary>
        /// 按咨询倒叙
        /// </summary>
        [UIText("按咨询倒叙")]
        ConsultationCountDesc,
        /// <summary>
        /// 按咨询升序
        /// </summary>
        [UIText("按咨询升序")]
        ConsultationCountAsc,
        /// <summary>
        /// 按下单量倒叙
        /// </summary>
        [UIText("按下单量倒叙")]
        OrderCountDesc,
        /// <summary>
        /// 按下单量升序
        /// </summary>
        [UIText("按下单量升序")]
        OrderCountAsc
    }
    /// <summary>
    /// 定义平台内圈子成员的排序方式
    /// </summary>
    public enum EnumOrderByGroupMember
    {
        /// <summary>
        /// 默认排序
        /// </summary>
        [UIText("默认排序")]
        CreatetimeDesc,
        /// <summary>
        /// 按加入时间升序
        /// </summary>
        [UIText("按加入时间升序")]
        CreatetimeAsc
    }
    /// <summary>
    /// 定义平台内圈子的排序方式
    /// </summary>
    public enum EnumOrderByGroup
    {
        /// <summary>
        /// 按最后浏览
        /// </summary>
        [UIText("按最后浏览")]
        BrowsetimeDesc,
        /// <summary>
        /// 默认排序
        /// </summary>
        [UIText("默认排序")]
        CreatetimeDesc
    }
    /// <summary>
    /// 定义平台内商铺的排序方式
    /// </summary>
    public enum EnumOrderByShop
    {
        /// <summary>
        /// 按最后一次认证时间
        /// </summary>
        [UIText("按最后一次认证时间")]
        LastAuthenticationTimeDesc,
        /// <summary>
        /// 默认排序
        /// </summary>
        [UIText("默认排序")]
        CreatetimeDesc
    }
    /// <summary>
    /// 定义平台内商铺成员的排序方式
    /// </summary>
    public enum EnumOrderByShop_Member
    {
        /// <summary>
        /// 默认排序
        /// </summary>
        [UIText("默认排序")]
        CreatetimeDesc
    }
    #endregion

    /// <summary>
    /// 定义平台内用户的排序方式。
    /// </summary>
    public enum EnumOrderByUser
    {
        /// <summary>
        /// 按名称升序
        /// </summary>
        [UIText("按名称升序")]
        NameAsc,
        /// <summary>
        /// 按名称降序
        /// </summary>
        [UIText("按名称降序")]
        NameDesc,
        /// <summary>
        /// 按注册时间升序
        /// </summary>
        [UIText("按注册时间升序")]
        CreatetimeAsc,
        /// <summary>
        /// 默认排序
        /// </summary>
        [UIText("默认排序")]
        CreatetimeDesc
    }

    /// <summary>
    /// 资源整合平台用户注册类型。
    /// </summary>
    public enum EnumSignupType
    {
        /// <summary>
        /// 用户自行注册。
        /// </summary>
        self,
        /// <summary>
        /// 后台管理员添加。
        /// </summary>
        platform
    }

    /// <summary>
    /// 文档列表的排序方式
    /// </summary>
    public enum EnumOrderByFile
    {
        /// <summary>
        /// 按创建时间升序。
        /// </summary>
        [UIText("按创建时间升序")]
        CreatetimeAsc,

        /// <summary>
        /// 按资料类型降序
        /// </summary>
        [UIText("按资料类型降序")]
        TypeDesc,
        /// <summary>
        /// 按资料类型升序
        /// </summary>
        [UIText("按资料类型升序")]
        TypeAsc,
        /// <summary>
        /// 按资料名称降序
        /// </summary>
        [UIText("按资料名称降序")]
        NameDesc,
        /// <summary>
        /// 按资料名称升序
        /// </summary>
        [UIText("按资料名称升序")]
        NameAsc,
        /// <summary>
        /// 默认排序
        /// </summary>
        [UIText("默认排序")]
        CreatetimeDesc,
    }
    /// <summary>
    /// 定义平台内用户浏览的服务列表排序方式
    /// </summary>
    public enum EnumOrderByUserService
    {
        /// <summary>
        /// 按浏览时间降序
        /// </summary>
        [UIText("按浏览时间降序")]
        CreatetimeDesc,
        /// <summary>
        /// 按浏览时间升序
        /// </summary>
        [UIText("按浏览时间升序")]
        CreatetimeAsc
    }
    /// <summary>
    /// 定义是否公开状态。
    /// </summary>
    public enum EnumOpenedType
    {
        /// <summary>
        /// 公开
        /// </summary>
        [UIText("公开")]
        Opened = 0,
        /// <summary>
        /// 私有
        /// </summary>
        [UIText("私有")]
        UnOpened = 1
    }


    /// <summary>
    /// 定义平台内圈子成员是否为组织管理员。
    /// </summary>
    public enum EnumGroupMemberType
    {
        /// <summary>
        /// 成员
        /// </summary>
        [UIText("成员")]
        Normal = 0,
        /// <summary>
        /// 超级管理员
        /// </summary>
        [UIText("超级管理员")]
        Admin = 1
    }

    /// <summary>
    /// 圈子与成员的状态(顺序不能改变)。
    /// </summary>
    public enum EnumGroupMemberStatus
    {
        /// <summary>
        /// 已加入
        /// </summary>
        [UIText("已加入")]
        Joined,
        /// <summary>
        /// 申请中
        /// </summary>
        [UIText("申请中")]
        Applying,
        /// <summary>
        /// 最近浏览
        /// </summary>
        [UIText("最近浏览")]
        Browsed,
        /// <summary>
        /// 邀请中
        /// </summary>
        [UIText("邀请中")]
        Inviting
    }
    /// <summary>
    /// 设置圈子是否突出显示
    /// </summary>
    public enum EnumIsHighShow
    {
        /// <summary>
        /// 不显示
        /// </summary>
        [UIText("不显示")]
        No,
        /// <summary>
        /// 显示
        /// </summary>
        [UIText("显示")]
        Yes
    }
    /// <summary>
    /// 定义平台内通知的类型
    /// </summary>
    public enum EnumNoticeType
    {
        /// <summary>
        /// 工作通知
        /// </summary>
        [UIText("工作通知")]
        Work,
        /// <summary>
        /// 圈子通知
        /// </summary>
        [UIText("圈子通知")]
        Group,
        /// <summary>
        /// 活动通知
        /// </summary>
        [UIText("活动通知")]
        Meeting,
        /// <summary>
        /// 任务通知
        /// </summary>
        [UIText("任务通知")]
        Task,
        /// <summary>
        /// 交易或者咨询时，需求方的通知。
        /// </summary>
        [UIText("交易通知")]
        DemanderNotice,
        /// <summary>
        /// 交易或者咨询时，服务方的通知。
        /// </summary>
        [UIText("交易通知")]
        ServicerNotice,
        /// <summary>
        /// 企业通知
        /// </summary>
        [UIText("企业通知")]
        EnterpriseNotice
    }
    /// <summary>
    /// 定义平台内消息的状态。
    /// </summary>
    public enum EnumMessageReadStatus
    {
        /// <summary>
        /// 已读
        /// </summary>
        [UIText("已读")]
        Read,
        /// <summary>
        /// 未读
        /// </summary>
        [UIText("未读")]
        UnRead

    }






    #region 获取数据列表的方式
    /// <summary>
    /// 获取圈子列表的方式
    /// </summary>
    public enum EnumGetGroupMode
    {
        /// <summary>
        ///我的圈子
        /// </summary>
        ByMe,
        /// <summary>
        /// 所有圈子
        /// </summary>
        ByAll,
        /// <summary>
        /// 最近浏览
        /// </summary>
        ByBrowse,
        /// <summary>
        /// 只看有新消息的
        /// </summary>
        ByNew
    }
    #endregion

    /// <summary>
    /// 动态的类型。
    /// </summary>
    public enum EnumDiscussType
    {
        /// <summary>
        /// 主题。
        /// </summary>
        [UIText("主题")]
        Theme,
        /// <summary>
        ///回复。
        /// </summary>
        [UIText("回复")]
        Reply
    }
    /// <summary>
    /// 定义周期类型。
    /// </summary>
    public enum EnumRepeatType
    {
        /// <summary>
        /// 一律不。
        /// </summary>
        [UIText("一律不")]
        No = 0,
        /// <summary>
        /// 每天。
        /// </summary>
        [UIText("每天")]
        Day,
        /// <summary>
        /// 每周。
        /// </summary>
        [UIText("每周")]
        Week,
        /// <summary>
        /// 每两周。
        /// </summary>
        [UIText("每两周")]
        TwoWeeks,
        /// <summary>
        /// 每月。
        /// </summary>
        [UIText("每月")]
        Month
    }
    /// <summary>
    /// 动态的数据类型。
    /// </summary>
    public enum EnumDataType
    {
        /// <summary>
        /// 分享
        /// </summary>
        [UIText("分享")]
        Share = 0,
        /// <summary>
        /// 回复
        /// </summary>
        [UIText("回复")]
        Reply = 3,
        /// <summary>
        /// 活动
        /// </summary>
        [UIText("活动")]
        Meeting = 4
    }

    /// <summary>
    /// 文件用户关系的类型
    /// </summary>
    public enum EnumFileUserType
    {
        /// <summary>
        /// 上传
        /// </summary>
        [UIText("上传")]
        Upload,
        /// <summary>
        /// 回复
        /// </summary>
        [UIText("回复")]
        Reply,
        /// <summary>
        /// @
        /// </summary>
        [UIText("@")]
        At
    }
    /// <summary>
    /// 定义是否将提醒应用到所有参与者。
    /// </summary>
    public enum EnumRemindType
    {
        /// <summary>
        /// 不将提醒设置应用到所有参与者
        /// </summary>
        [UIText("否")]
        No,
        /// <summary>
        /// 将提醒设置应用到所有参与者
        /// </summary>
        [UIText("是")]
        Yes
    }
    /// <summary>
    /// 定义是否将提醒应用到所有参与者。
    /// </summary>
    public enum EnumRepeatDeleteType
    {
        /// <summary>
        /// 仅删除当前活动
        /// </summary>
        [UIText("仅删除当前活动")]
        Onlythis,
        /// <summary>
        /// 删除当前活动及之后所有活动
        /// </summary>
        [UIText("删除当前活动及之后所有活动")]
        AfterAll,
        /// <summary>
        /// 删除所有活动
        /// </summary>
        [UIText("删除所有活动")]
        All
    }
    /// <summary>
    /// 定义平台内时间字段显示格式。
    /// </summary>
    public enum EnumDateTimeStyle
    {
        /// <summary>
        /// 时间样式为(月月-日日)
        /// </summary>
        MMDD,
        /// <summary>
        /// 时间样式为(年年年年-月月-日日)
        /// </summary>
        YYYYMMDD,
        /// <summary>
        /// 时间样式为(年年-月月-日日)
        /// </summary>
        YYMMDD,
        /// <summary>
        /// 时间样式为(年年年年-月月-日日 时时：分分(星期))
        /// </summary>
        YYYYMMDDWeek,
        /// <summary>
        /// 网上实验室动态时间格式(1分钟前、2秒钟前)
        /// </summary>
        GroupNews,
        /// <summary>
        /// 时间样式为(月月-日日)
        /// </summary>
        ZHMMDD,
        /// <summary>
        /// 时间样式为(年年年年-月月-日日 时时:分分)
        /// </summary>
        YYYYMMDDHHMM,
        /// <summary>
        /// 时间样式为(YYYY年MM月)
        /// </summary>
        ZHYYYYMM,
        /// <summary>
        /// 时间样式为(月月-日日 时时:分分)
        /// </summary>
        ZHMMDDHHMM,
        /// <summary>
        /// 时间样式为(年年年年-月月-日日 如：2011年9月7日)
        /// </summary>
        ZHYYYYMMDD,
        /// <summary>
        /// 时间样式为(当年 月月-日日 时时:分分，其他 年年年年-月月-日日 时时:分分)
        /// </summary>
        Letter,
        /// <summary>
        /// 时间如果是当天的显示为(1分钟前、2秒钟前)，否则为(年年年年-月月-日日)
        /// </summary>
        IsToday,
        /// <summary>
        /// 时间样式为(年年年年-月月-日日 时时:分分:秒秒)
        /// </summary>
        YYYYMMDDHHMMSS,
        /// <summary>
        /// 时间如果是当天的显示为(1分钟前、2秒钟前)，否则为(年年年年-月月-日日 时时:分分:秒秒)
        /// </summary>
        Discuss,
        /// <summary>
        /// 时间格式为(年/月/日)
        /// </summary>
        YYYYMMDD_sprit,
        /// <summary>
        /// 时间样式为(年年年年-月月)
        /// </summary>
        YYYYMM,
        /// <summary>
        /// 时间样式为(月日年)
        /// </summary>
        MMDDYYYY,
        /// <summary>
        /// 时间样式为(时时:分分:秒秒)
        /// </summary>
        HHMMSS
    }

    /// <summary>
    /// 定义平台内字符串默认值。
    /// </summary>
    public enum EnumStringDefault
    {
        /// <summary>
        /// 未知。
        /// </summary>
        [UIText("未知")]
        Unknown,
        /// <summary>
        /// 无。
        /// </summary>
        [UIText("无")]
        No,
        /// <summary>
        /// 未填写
        /// </summary>
        [UIText("未填写")]
        Empty,
        /// <summary>
        /// 未分配活动地点
        /// </summary>
        [UIText("未分配活动地点")]
        MeetingRoom,
        /// <summary>
        /// 未归入部门
        /// </summary>
        [UIText("未归入部门")]
        Department
    }
    /// <summary>
    /// 定义平台内应用列表的排序方式
    /// </summary>
    public enum EnumOrderByClient
    {
        /// <summary>
        /// 按标题降序
        /// </summary>
        [UIText("按标题降序")]
        FriendlyNameDesc,
        /// <summary>
        /// 按标题升序
        /// </summary>
        [UIText("按标题升序")]
        FriendlyNameAsc,
        /// <summary>
        /// 默认排序
        /// </summary>
        [UIText("默认排序")]
        CreatetimeDesc

    }
    /// <summary>
    /// 定义平台内应用版本列表的排序方式
    /// </summary>
    public enum EnumOrderByClientVersion
    {
        /// <summary>
        /// 更新时间降序
        /// </summary>
        [UIText("更新时间降序")]
        UpdatetimeDesc,
        /// <summary>
        /// 更新时间升序
        /// </summary>
        [UIText("更新时间升序")]
        UpdatetimeAsc

    }

    public enum EnumConsumerStatus
    {
        /// <summary>
        /// 未知
        /// </summary>
        [UIText("未知")]
        Unknown,
        /// <summary>
        /// 通过
        /// </summary>
        [UIText("通过")]
        Valis,
        /// <summary>
        /// 暂时不通过
        /// </summary>
        [UIText("暂时不通过")]
        TemporarilyDisabled,
        /// <summary>
        /// 永久不通过
        /// </summary>
        [UIText("永久不通过")]
        PermanentlyDisabled
    }
    public enum EnumConsumerLevel
    {
        /// <summary>
        /// 公开接口
        /// </summary>
        [UIText("公开接口")]
        Open,
        /// <summary>
        /// 普通接口
        /// </summary>
        [UIText("普通接口")]
        Common,
        /// <summary>
        /// 中级接口
        /// </summary>
        [UIText("中级接口")]
        Middle,
        /// <summary>
        /// 高级接口
        /// </summary>
        [UIText("高级接口")]
        High,
        /// <summary>
        /// 官方接口 
        /// </summary>
        [UIText("官方接口")]
        Official
    }
    public enum EnumClientShowType
    {
        /// <summary>
        /// 工具型
        /// </summary>
        [UIText("工具型")]
        Tool,
        /// <summary>
        /// 链接型
        /// </summary>
        [UIText("链接型")]
        Link
    }
    /// <summary>
    /// 定义平台的应用是否可用
    /// </summary>
    public enum EnumClientIsUse
    {
        /// <summary>
        /// 可用
        /// </summary>
        [UIText("可用")]
        Use,
        /// <summary>
        /// 不可用
        /// </summary>
        [UIText("不可用")]
        UnUse
    }
    public enum EnumClientSource
    {
        /// <summary>
        /// 添加应用，显示在应用中心页面
        /// </summary>
        [UIText("显示在应用中心页面")]
        AppCenter,
        /// <summary>
        /// PIII不显示在应用中心页面
        /// </summary>
        [UIText("不显示在应用中心页面")]
        PIII
    }
    /// <summary>
    /// 是否必须升级
    /// </summary>
    public enum EnumClientUpdateType
    {
        /// <summary>
        /// 不必升级
        /// </summary>
        [UIText("不必升级")]
        No,
        /// <summary>
        /// 必须升级
        /// </summary>
        [UIText("必须升级")]
        Yes
    }
    /// <summary>
    /// 需求是否显示在首页
    /// </summary>
    public enum EnumDemandShowType
    {
        /// <summary>
        /// 显示在首页
        /// </summary>
        [UIText("显示在首页")]
        Yes,
        /// <summary>
        /// 不显示在首页
        /// </summary>
        [UIText("不显示在首页")]
        No
    }
    /// <summary>
    /// 服务是否显示在首页
    /// </summary>
    public enum EnumServiceShowType
    {
        /// <summary>
        /// 显示在首页
        /// </summary>
        [UIText("显示在首页")]
        Yes,
        /// <summary>
        /// 不显示在首页
        /// </summary>
        [UIText("不显示在首页")]
        No
    }


    /// <summary>
    /// 定义平台需求的排序方式
    /// </summary>
    public enum EnumOrderByDemand
    {
        /// <summary>
        /// 按权重升序。
        /// </summary>
        [UIText("按权重升序")]
        WeightAsc,
        /// <summary>
        /// 按权重降序。
        /// </summary>
        [UIText("按权重降序")]
        WeightDesc,
        /// <summary>
        /// 按回复时间升序。
        /// </summary>
        [UIText("按回复时间升序")]
        ReplyCreatetimeAsc,
        /// <summary>
        /// 按回复时间降序
        /// </summary>
        [UIText("按回复时间降序")]
        ReplyCreatetimeDesc,
        /// <summary>
        /// 按完成时间降序
        /// </summary>
        [UIText("按完成时间降序")]
        CompletetimeDesc,
        /// <summary>
        /// 按创建时间升序。
        /// </summary>
        [UIText("按创建时间升序")]
        CreatetimeAsc,
        /// <summary>
        /// 按创建时间降序
        /// </summary>
        [UIText("按创建时间降序")]
        CreatetimeDesc
    }
    /// <summary>
    /// 定义平台栏目的排序方式
    /// </summary>
    public enum EnumOrderByChannel
    {
        /// <summary>
        /// 按栏目名称升序。
        /// </summary>
        [UIText("按栏目名称升序")]
        NameAsc,
        /// <summary>
        /// 按栏目名称降序。
        /// </summary>
        [UIText("按栏目名称降序")]
        NameDesc,
        /// <summary>
        /// 按权重升序
        /// </summary>
        [UIText("按权重升序")]
        WeightAsc,
        /// <summary>
        /// 按权重降序序
        /// </summary>
        [UIText("按权重降序序")]
        WeightDesc,
        /// <summary>
        /// 按创建时间升序。
        /// </summary>
        [UIText("按创建时间升序")]
        CreatetimeAsc,
        /// <summary>
        /// 按创建时间降序
        /// </summary>
        [UIText("按创建时间降序")]
        CreatetimeDesc
    }

    /// <summary>
    /// 定义平台栏目的排序方式
    /// </summary>
    public enum EnumOrderByInformation
    {
        /// <summary>
        /// 按标题升序。
        /// </summary>
        [UIText("按标题升序")]
        NameAsc,
        /// <summary>
        /// 按标题降序。
        /// </summary>
        [UIText("按标题降序")]
        NameDesc,
        /// <summary>
        /// 按发布时间升序。
        /// </summary>
        [UIText("按发布时间升序")]
        CreatetimeAsc,
        /// <summary>
        /// 按发布时间降序
        /// </summary>
        [UIText("按发布时间降序")]
        CreatetimeDesc,
        /// <summary>
        /// 按权重升序。
        /// </summary>
        [UIText("按权重升序")]
        WeightAsc,
        /// <summary>
        /// 按权重降序
        /// </summary>
        [UIText("按权重降序")]
        WeightDesc
    }
    /// <summary>
    /// 定义平台视频的排序方式
    /// </summary>
    public enum EnumOrderByVideos
    {
        /// <summary>
        /// 按标题升序。
        /// </summary>
        [UIText("按标题升序")]
        NameAsc,
        /// <summary>
        /// 按标题降序。
        /// </summary>
        [UIText("按标题降序")]
        NameDesc,
        /// <summary>
        /// 按发布时间升序。
        /// </summary>
        [UIText("按发布时间升序")]
        CreatetimeAsc,
        /// <summary>
        /// 按发布时间降序
        /// </summary>
        [UIText("按发布时间降序")]
        CreatetimeDesc    
    }
    /// <summary>
    /// 需求的状态。
    /// </summary>
    public enum EnumDemandStatus
    {
        /// <summary>
        /// 进行中
        /// </summary>
        [UIText("进行中")]
        UnEnd,
        /// <summary>
        /// 已结束
        /// </summary>
        [UIText("已结束")]
        End
    }

    /// <summary>
    /// 平台后台需求数据来源
    /// </summary>
    public enum EnumDemandSource
    {
        /// <summary>
        /// 本平台
        /// </summary>
        [UIText("本平台")]
        MyPlatform,
        /// <summary>
        /// CIPnet平台
        /// </summary>
        [UIText("CIPnet平台")]
        CIPnetPlatform
    }

    /// <summary>
    /// 平台后台服务数据来源
    /// </summary>
    public enum EnumServiceSource
    {
        /// <summary>
        /// 本平台
        /// </summary>
        [UIText("本平台")]
        MyPlatform,
        /// <summary>
        /// CIPnet平台
        /// </summary>
        [UIText("CIPnet平台")]
        CIPnetPlatform
    }

    /// <summary>
    /// 定义平台中商铺的类型
    /// </summary>
    public enum EnumShopType
    {
        /// <summary>
        /// 个人
        /// </summary>
        [UIText("个人")]
        Person,
        /// <summary>
        /// 企业
        /// </summary>
        [UIText("企业")]
        Enterprise,
        /// <summary>
        /// 机构
        /// </summary>
        [UIText("机构")]
        Organ
    }
    /// <summary>
    /// 定义平台中商铺服务类型
    /// </summary>
    public enum EnumShopServiceType
    {
        /// <summary>
        /// 待审核服务
        /// </summary>
        [UIText("待审核服务")]
        UnAudit,
        /// <summary>
        /// 官方服务
        /// </summary>
        [UIText("官方服务")]
        Official,
        /// <summary>
        /// 官方认证服务
        /// </summary>
        [UIText("官方认证服务")]
        Authentication,
        /// <summary>
        /// 官方审核服务
        /// </summary>
        [UIText("官方审核服务")]
        Audit,
        /// <summary>
        /// 官方担保服务
        /// </summary>
        [UIText("官方担保服务")]
        Auarantee
    }
    /// <summary>
    /// 定义平台中商铺的状态
    /// </summary>
    public enum EnumShopStatus
    {
        /// <summary>
        /// 正常
        /// </summary>
        [UIText("正常")]
        Normal,
        ///// <summary>
        ///// 待审核
        ///// </summary>
        //[UIText("待审核")]
        //UnVerified,
        ///// <summary>
        ///// 审核未通过
        ///// </summary>
        //[UIText("审核未通过")]
        //VerifiedFail,
        /// <summary>
        /// 锁定
        /// </summary>
        [UIText("锁定")]
        Lock,
        /// <summary>
        /// 未开通
        /// </summary>
        [UIText("未开通")]
        UnCreate
    }
    /// <summary>
    /// 定义平台内商铺成员的管理员类型。
    /// </summary>
    public enum EnumShopAdminType
    {
        /// <summary>
        /// 普通管理员
        /// </summary>
        [UIText("普通管理员")]
        Admin,
        /// <summary>
        /// 超级管理员
        /// </summary>
        [UIText("超级管理员")]
        SuperAdmin
    }

    /// <summary>
    /// 定义平台内商铺成员的状态。
    /// </summary>
    public enum EnumShopMemberStatus
    {
        /// <summary>
        /// 正常
        /// </summary>
        [UIText("正常")]
        Normal,
        /// <summary>
        /// 锁定
        /// </summary>
        [UIText("锁定")]
        Lock
    }

    /// <summary>
    /// 表情图片的类型
    /// </summary>
    public enum EnumImgFace
    {
        /// <summary>
        /// 心情
        /// </summary>
        [UIText("心情")]
        Smile,
        /// <summary>
        /// 自然
        /// </summary>
        [UIText("自然")]
        Flower,
        /// <summary>
        /// 物体
        /// </summary>
        [UIText("物体")]
        Bell,
        /// <summary>
        /// 地点
        /// </summary>
        [UIText("地点")]
        Vehicle,
        /// <summary>
        /// 符号
        /// </summary>
        [UIText("符号")]
        Number
    }

    /// <summary>
    /// 企业空间活动的状态。
    /// </summary>
    public enum EnumEventStatus
    {
        /// <summary>
        /// 未开始
        /// </summary>
        [UIText("未开始")]
        UnStart,
        /// <summary>
        /// 进行中
        /// </summary>
        [UIText("进行中")]
        Going,
        /// <summary>
        /// 已结束
        /// </summary>
        [UIText("已结束")]
        End
    }

    /// <summary>
    /// 获取好友类型。
    /// </summary>
    public enum EnumGetFriendsMode
    {
        /// <summary>
        /// 我关注的
        /// </summary>
        [UIText("我关注的")]
        userattention = 0,
        /// <summary>
        /// 我的粉丝
        /// </summary>
        [UIText("我的粉丝")]
        userfans = 1
    }

    /// <summary>
    /// 获取服务列表的方式
    /// </summary>
    public enum EnumGetServiceMode
    {
        /// <summary>
        ///我咨询过的
        /// </summary>
        [UIText("我咨询过的")]
        ByMe,
        /// <summary>
        ///我的预约
        /// </summary>
        [UIText("我的预约")]
        MyOrder,
        /// <summary>
        ///我关注的服务
        /// </summary>
        [UIText("我关注的服务")]
        MyAttentionService,
        /// <summary>
        ///我关注的商铺
        /// </summary>
        [UIText("我关注的商铺")]
        MyAttentionShop,
        /// <summary>
        /// 服务大厅
        /// </summary>
        [UIText("服务大厅")]
        ByAll
    }

    /// <summary>
    /// 获取商铺客户管理列表的方式
    /// </summary>
    public enum EnumGetShopCustomerMode
    {
        /// <summary>
        /// 咨询过我的
        /// </summary>
        [UIText("咨询过我的")]
        ByMe,
        /// <summary>
        /// 浏览过我的
        /// </summary>
        [UIText("浏览过我的")]
        Visited
    }
    /// <summary>
    /// 商铺对外展示管理
    /// </summary>
    public enum EnumShopPortalFunctionMode
    {
        /// <summary>
        /// 布局管理
        /// </summary>
        [UIText("布局管理")]
        Module
    }
    /// <summary>
    /// 商铺对外展示模板
    /// </summary>
    public enum EnumShopPortalTemplate
    {
        /// <summary>
        /// 风格一
        /// </summary>
        [UIText("风格一")]
        Template_One
    }
    /// <summary>
    /// 用户对外展示页列表类型
    /// </summary>
    public enum EnumUserIndex
    {
        /// <summary>
        /// Ta/我的需求
        /// </summary>
        [UIText("的需求")]
        Demand,
        /// <summary>
        /// Ta/我的咨询
        /// </summary>
        [UIText("的咨询")]
        Consult,
        /// <summary>
        /// Ta/我的分享
        /// </summary>
        [UIText("的分享")]
        Share,
        /// <summary>
        /// Ta/我的人脉
        /// </summary>
        [UIText("的人脉")]
        User,
        /// <summary>
        /// Ta/我的圈子
        /// </summary>
        [UIText("的圈子")]
        Group,
        /// <summary>
        /// Ta/我的文档
        /// </summary>
        [UIText("的文档")]
        Document
    }
    /// <summary>
    /// CIPnet首页两大顶级栏目
    /// <para>针对于栏目列表和栏目详细页右侧头部导航</para>
    /// </summary>
    public enum EnumPlatChannelType
    {
        /// <summary>
        /// 创新服务
        /// </summary>
        [UIText("创新服务")]
        Innovation = 1,
        /// <summary>
        /// 生态圈建设
        /// </summary>
        [UIText("生态圈建设")]
        BuildCircel = 3
    }

    /// <summary>
    /// 广告状态。
    /// </summary>
    public enum EnumAdStatus
    {
        /// <summary>
        /// 正常。
        /// </summary>
        [UIText("正常")]
        Normal,
        /// <summary>
        /// 锁定。
        /// </summary>
        [UIText("锁定")]
        Lock
    }

    /// <summary>
    /// 友情链接状态。
    /// </summary>
    public enum EnumFriendLinkStatus
    {
        /// <summary>
        /// 正常。
        /// </summary>
        [UIText("正常")]
        Normal,
        /// <summary>
        /// 锁定。
        /// </summary>
        [UIText("锁定")]
        Lock
    }

    /// <summary>
    /// 定义平台内广告列表的排序方式
    /// </summary>
    public enum EnumOrderByAd
    {
        /// <summary>
        /// 按标题降序
        /// </summary>
        [UIText("按广告名称降序")]
        NameDesc,
        /// <summary>
        /// 按标题升序
        /// </summary>
        [UIText("按广告名称升序")]
        NameAsc,
        /// <summary>
        /// 默认排序
        /// </summary>
        [UIText("默认排序")]
        CreatetimeDesc,
        /// <summary>
        /// 权重排序
        /// </summary>
        [UIText("权重排序")]
        WeightDesc
    }

    /// <summary>
    /// 定义平台内友情链接列表的排序方式
    /// </summary>
    public enum EnumOrderByFriendLink
    {
        /// <summary>
        /// 按标题降序
        /// </summary>
        [UIText("按友情链接名称降序")]
        NameDesc,
        /// <summary>
        /// 按标题升序
        /// </summary>
        [UIText("按友情链接名称升序")]
        NameAsc,
        /// <summary>
        /// 按权重降序
        /// </summary>
        [UIText("按权重降序")]
        WeightDesc,
        /// <summary>
        /// 按权重升序
        /// </summary>
        [UIText("按权重升序")]
        WeightAsc,
        /// <summary>
        /// 默认排序
        /// </summary>
        [UIText("默认排序")]
        CreatetimeDesc
    }

    /// <summary>
    /// 锁定信息排序方式
    /// </summary>
    public enum EnumOrderByLockInfo
    {
        /// <summary>
        /// 按标题降序
        /// </summary>
        [UIText("按信息标题降序")]
        LockNameDesc,
        /// <summary>
        /// 按标题升序
        /// </summary>
        [UIText("按信息标题升序")]
        LockNameAsc,

        /// <summary>
        /// 默认排序
        /// </summary>
        [UIText("默认排序")]
        CreatetimeDesc
    }

    /// <summary>
    /// 是否有配图。
    /// </summary>
    public enum EnumInformationHasImage
    {
        /// <summary>
        /// 无配图。
        /// </summary>
        No,
        /// <summary>
        /// 有配图。
        /// </summary>
        Yes
    }

    /// <summary>
    /// 定义平台内区域平台列表的排序方式
    /// </summary>
    public enum EnumOrderByRegionalPlatform
    {
        /// <summary>
        /// 按标题降序
        /// </summary>
        [UIText("按区域平台名称降序")]
        NameDesc,
        /// <summary>
        /// 按标题升序
        /// </summary>
        [UIText("按区域平台名称升序")]
        NameAsc,
        /// <summary>
        /// 按权重降序
        /// </summary>
        [UIText("按权重降序")]
        WeightDesc,
        /// <summary>
        /// 按权重升序
        /// </summary>
        [UIText("按权重升序")]
        WeightAsc,
        /// <summary>
        /// 默认排序
        /// </summary>
        [UIText("默认排序")]
        CreatetimeDesc
    }
    public enum EnumOrderBySpecialtyPlatform
    {
        /// <summary>
        /// 按标题降序
        /// </summary>
        [UIText("按专业平台名称降序")]
        NameDesc,
        /// <summary>
        /// 按标题升序
        /// </summary>
        [UIText("按专业平台名称升序")]
        NameAsc,
        /// <summary>
        /// 按权重降序
        /// </summary>
        [UIText("按权重降序")]
        WeightDesc,
        /// <summary>
        /// 按权重升序
        /// </summary>
        [UIText("按权重升序")]
        WeightAsc,
        /// <summary>
        /// 默认排序
        /// </summary>
        [UIText("默认排序")]
        CreatetimeDesc
    }
    public enum EnumOrderByHotInfo
    {
        /// <summary>
        /// 按标题降序
        /// </summary>
        [UIText("按热点名称降序")]
        NameDesc,
        /// <summary>
        /// 按标题升序
        /// </summary>
        [UIText("按热点名称升序")]
        NameAsc,
        /// <summary>
        /// 按权重降序
        /// </summary>
        [UIText("按权重降序")]
        WeightDesc,
        /// <summary>
        /// 按权重升序
        /// </summary>
        [UIText("按权重升序")]
        WeightAsc,
        /// <summary>
        /// 默认排序
        /// </summary>
        [UIText("默认排序")]
        CreatetimeDesc
    }
    public enum EnumOrderByDynamic
    {
        /// <summary>
        /// 按标题降序
        /// </summary>
        [UIText("按动态名称降序")]
        NameDesc,
        /// <summary>
        /// 按标题升序
        /// </summary>
        [UIText("按动态名称升序")]
        NameAsc,
        /// <summary>
        /// 按权重降序
        /// </summary>
        [UIText("按权重降序")]
        WeightDesc,
        /// <summary>
        /// 按权重升序
        /// </summary>
        [UIText("按权重升序")]
        WeightAsc,
        /// <summary>
        /// 默认排序
        /// </summary>
        [UIText("默认排序")]
        CreatetimeDesc
    }

    public enum EnumOrderByServicePortalCatalog
    {
        /// <summary>
        /// 按权重降序
        /// </summary>
        [UIText("按权重降序")]
        WeightDesc,
        /// <summary>
        /// 按权重升序
        /// </summary>
        [UIText("按权重升序")]
        WeightAsc,
        /// <summary>
        /// 默认排序
        /// </summary>
        [UIText("默认排序")]
        CreatetimeDesc
    }
    public enum EnumOrderByShopPortalCatalog
    {
        /// <summary>
        /// 按权重降序
        /// </summary>
        [UIText("按权重降序")]
        WeightDesc,
        /// <summary>
        /// 按权重升序
        /// </summary>
        [UIText("按权重升序")]
        WeightAsc,
        /// <summary>
        /// 默认排序
        /// </summary>
        [UIText("默认排序")]
        CreatetimeDesc
    }
    public enum EnumOrderByFinancingIntention
    {
        [UIText("按时间升序")]
        CreatetimeAsc,
        /// <summary>
        /// 默认排序
        /// </summary>
        [UIText("默认排序")]
        CreatetimeDesc
    }

    /// <summary>
    /// 服务分类类型。
    /// </summary>
    public enum EnumServiceSortType
    {
        /// <summary>
        /// 补贴服务。
        /// </summary>
        [UIText("补贴服务")]
        Subsidies,
        /// <summary>
        /// 热门服务。
        /// </summary>
        [UIText("热门服务")]
        Hot
    }

    public enum EnumOrderbySortType
    {
        /// <summary>
        /// 按时间倒序
        /// </summary>
        CreatetimeDesc
    }

    /// <summary>
    /// 商铺等级
    /// </summary>
    public enum EnumShopLevel
    {
        /// <summary>
        /// 普通服务商
        /// </summary>
        [UIText("普通服务商")]
        Normal,
        /// <summary>
        /// 推荐服务商
        /// </summary>
        [UIText("推荐服务商")]
        Recommend,
        /// <summary>
        /// 优质服务商
        /// </summary>
        [UIText("优质服务商")]
        HighQuality
    }

    /// <summary>
    /// 商铺认证
    /// </summary>
    public enum EnumShopAuth
    {
        /// <summary>
        /// 待认证
        /// </summary>
        [UIText("待认证")]
        UnAuth,
        /// <summary>
        /// 认证未通过
        /// </summary>
        [UIText("认证未通过")]
        AuthFail,
        /// <summary>
        /// 已认证
        /// </summary>
        [UIText("已认证")]
        Auth
    }

    /// <summary>
    /// 预约状态
    /// </summary>
    public enum EnumOrderStatus
    {
        /// <summary>
        /// 待确认
        /// </summary>
        [UIText("待确认")]
        UnConfirm,
        /// <summary>
        /// 进行中
        /// </summary>
        [UIText("进行中")]
        Going,
        /// <summary>
        /// 已取消
        /// </summary>
        [UIText("已取消")]
        Cancel,
        /// <summary>
        /// 待确认完成
        /// </summary>
        [UIText("待确认完成")]
        Complete,
        /// <summary>
        /// 确认完成
        /// </summary>
        [UIText("预约结束")]
        Confirm
    }

    /// <summary>
    /// 预约删除状态
    /// </summary>
    public enum EnumOrderDelStatus
    {
        /// <summary>
        /// 正常
        /// </summary>
        [UIText("正常")]
        Normal,
        /// <summary>
        /// 已删除
        /// </summary>
        [UIText("已删除")]
        Deleted,
        /// <summary>
        /// 服务商已删除
        /// </summary>
        [UIText("服务商已删除")]
        ServiceDeleted,
        /// <summary>
        /// 需求商已删除
        /// </summary>
        [UIText("需求商已删除")]
        DemandDeleted
    }

    /// <summary>
    /// 评价类型
    /// </summary>
    public enum EnumReviewType
    {
        /// <summary>
        /// 评价
        /// </summary>
        [UIText("评价")]
        Normal,
        /// <summary>
        /// 追加评价
        /// </summary>
        [UIText("追加评价")]
        Additional
    }

    /// <summary>
    /// 评价等级（0-未评价；1-1颗心；2-2颗心；3-3颗心；4-4颗心；5-5颗心）
    /// </summary>
    public enum EnumReviewGrade
    {
        /// <summary>
        /// 1颗心
        /// </summary>
        [UIText("1颗心")]
        One = 1,
        /// <summary>
        /// 2颗心
        /// </summary>
        [UIText("2颗心")]
        Two = 2,
        /// <summary>
        /// 3颗心
        /// </summary>
        [UIText("1颗心")]
        Three = 3,
        /// <summary>
        /// 4颗心
        /// </summary>
        [UIText("4颗心")]
        Four = 4,
        /// <summary>
        /// 5颗心
        /// </summary>
        [UIText("5颗心")]
        Five = 5,
    }

    /// <summary>
    /// 定义平台内预约的排序方式
    /// </summary>
    public enum EnumOrderByOrder
    {
        /// <summary>
        /// 默认排序
        /// </summary>
        [UIText("默认排序")]
        CreatetimeDesc
    }
    public enum EnumOrderByPerson
    {
        /// <summary>
        /// 默认排序
        /// </summary>
        [UIText("默认排序")]
        CreatetimeDesc,
        /// <summary>
        /// 权重降序排序
        /// </summary>
        [UIText("权重降序排序")]
        WeightDesc,
        /// <summary>
        /// 权重升序排序
        /// </summary>
        [UIText("权重升序排序")]
        WeightAsc
    }

    public enum EnumOrderByPolicyContent
    {
        /// <summary>
        /// 默认排序
        /// </summary>
        [UIText("默认排序")]
        CreatetimeDesc,
        /// <summary>
        /// 名称降序排序
        /// </summary>
        [UIText("名称降序排序")]
        NameDesc,
           /// <summary>
        /// 名称升序排序
        /// </summary>
        [UIText("名称升序排序")]
        NameAsc,
        /// <summary>
        /// 权重降序排序
        /// </summary>
        [UIText("权重降序排序")]
        WeightDesc,
        /// <summary>
        /// 权重升序排序
        /// </summary>
        [UIText("权重升序排序")]
        WeightAsc
    }
    /// <summary>
    /// 定义平台内评价的排序方式
    /// </summary>
    public enum EnumOrderByReview
    {
        /// <summary>
        /// 默认排序
        /// </summary>
        [UIText("默认排序")]
        CreatetimeDesc
    }
    public enum EnumOrderbyServiceSort
    {
        /// <summary>
        /// 默认排序
        /// </summary>
        [UIText("默认排序")]
        CreatetimeDesc
    }

    /// <summary>
    /// 定义平台内双创大讲堂的排序方式
    /// </summary>
    public enum EnumOrderByVideo
    {
        /// <summary>
        /// 默认排序
        /// </summary>
        [UIText("默认排序")]
        CreatetimeDesc,
        /// <summary>
        /// 源网站发布时间倒序
        /// </summary>
        [UIText("源网站发布时间倒序")]
        PubdateDesc
    }

    /// <summary>
    /// 定义平台内评价的方式(预约评价)
    /// </summary>
    public enum EnumReviewByOrder
    {
        /// <summary>
        /// 评价时间倒叙
        /// </summary>
        [UIText("评价时间倒叙")]
        CreatetimeDesc,
        /// <summary>
        /// 评价时间正序
        /// </summary>
        [UIText("评价时间正序")]
        CreatetimeAsc,
        /// <summary>
        /// 评价等级倒叙
        /// </summary>
        [UIText("评价等级倒叙")]
        GradeDesc,
        /// <summary>
        /// 评价等级正序
        /// </summary>
        [UIText("评价等级正序")]
        GradeAsc
    }

    /// <summary>
    /// 定义平台内资源的状态。
    /// </summary>
    public enum EnumResourceStatus
    {
        /// <summary>
        /// 正常
        /// </summary>
        [UIText("正常")]
        Normal,
        /// <summary>
        /// 锁定
        /// </summary>
        [UIText("锁定")]
        Lock,
        /// <summary>
        /// 待审核
        /// </summary>
        [UIText("待审核")]
        UnVerified,
        /// <summary>
        /// 审核未通过
        /// </summary>
        [UIText("审核未通过")]
        VerifiedFail,
        /// <summary>
        /// 错误
        /// </summary>
        [UIText("错误")]
        Error,
        /// <summary>
        /// 错误：重复数据
        /// </summary>
        [UIText("错误：重复数据")]
        ErrRepeat,

    }

    /// <summary>
    /// 定义平台内全文检索排序方式
    /// </summary>
    public enum EnumOrderBySearch
    {
        /// <summary>
        /// 按时间降序
        /// </summary>
        [UIText("按时间降序")]
        CreatetimeDesc,
        /// <summary>
        /// 按权重倒序
        /// </summary>
        [UIText("按权重倒序")]
        ScoreDesc
    }

    /// <summary>
    /// 定义平台内已完成预约的用户排序方式(用于客户管理-已交易客户列表)
    /// </summary>
    public enum EnumOrderUserByOrder
    {
        /// <summary>
        /// 交易次数倒叙
        /// </summary>
        [UIText("交易次数倒叙")]
        TransCountDesc,
        /// <summary>
        /// 交易次数正序
        /// </summary>
        [UIText("交易次数正序")]
        TransCountAsc,
        /// <summary>
        /// 最近交易时间倒叙
        /// </summary>
        [UIText("最近交易时间倒叙")]
        CreatetimeDesc,
        /// <summary>
        /// 最近交易时间正序
        /// </summary>
        [UIText("最近交易时间正序")]
        CreatetimeAsc
    }

    #region 情报所数据所需枚举
    /// <summary>
    /// 科技文献的类型。
    /// </summary>
    public enum EnumScienceTecLiteratureType
    {
        /// <summary>
        /// 期刊
        /// </summary>
        [UIText("期刊")]
        Periodical = 9,
        /// <summary>
        /// 学位
        /// </summary>
        [UIText("学位")]
        Degree = 8,
        /// <summary>
        /// 会议
        /// </summary>
        [UIText("会议")]
        Meeting = 7,
        /// <summary>
        /// 专利
        /// </summary>
        [UIText("专利")]
        Patent = 13,
        /// <summary>
        /// 标准
        /// </summary>
        [UIText("标准")]
        Standard = 6,
        /// <summary>
        /// 年鉴
        /// </summary>
        [UIText("年鉴")]
        Yearbooks = 11,
        /// <summary>
        /// 企业
        /// </summary>
        [UIText("企业")]
        Enterprise = 15,
        /// <summary>
        /// 科技成果
        /// </summary>
        [UIText("科技成果")]
        Achievements = 3,
        /// <summary>
        /// 法律法规
        /// </summary>
        [UIText("法律法规")]
        LawsRegulations = 2,
        /// <summary>
        /// 报纸
        /// </summary>
        [UIText("报纸")]
        NewsPaper = 10,
        /// <summary>
        /// 视频
        /// </summary>
        [UIText("视频")]
        Video = 4,
        /// <summary>
        /// 资讯
        /// </summary>
        [UIText("资讯")]
        Information = 5,
        /// <summary>
        /// 科技报告
        /// </summary>
        [UIText("科技报告")]
        Report = 21
    }

    public enum EnumScienceTecAchievementsType
    {
        /// <summary>
        /// 需求
        /// </summary>
        [UIText("成果")]
        Fruit,
        /// <summary>
        /// 成果
        /// </summary>
        [UIText("项目")]
        Project,
        /// <summary>
        /// 需求
        /// </summary>
        [UIText("需求")]
        Demand
    }
    #endregion

    public enum EnumSearchItem
    {
        /// <summary>
        /// 通知公告
        /// </summary>
        [UIText("通知公告")]
        Notice,
        /// <summary>
        /// 政策法规
        /// </summary>
        [UIText("政策法规")]
        RegulatoryPolicy,
        /// <summary>
        /// 科技成果
        /// </summary>
        [UIText("科技成果")]
        Achievements,
        /// <summary>
        /// 科技项目
        /// </summary>
        [UIText("科技项目")]
        ScienceTecProject,
        /// <summary>
        /// 创新人才
        /// </summary>
        [UIText("创新人才")]
        InnovativeTalents,
        /// <summary>
        /// 科技动态
        /// </summary>
        [UIText("科技动态")]
        ScienceTecDynamics,
        /// <summary>
        /// 市场动态
        /// </summary>
        [UIText("市场动态")]
        MarketDynamics,
        /// <summary>
        /// 融资动态
        /// </summary>
        [UIText("融资动态")]
        FinancingDynamics,
        /// <summary>
        /// 科技报告
        /// </summary>
        [UIText("科技报告")]
        ScienceTecReport,
        /// <summary>
        /// 科技文献
        /// </summary>
        [UIText("科技文献")]
        ScienceTecLiterature,
        /// <summary>
        /// 找资金
        /// </summary>
        [UIText("寻找资金")]
        FindMoney,
        /// <summary>
        /// 服务机构
        /// </summary>
        [UIText("服务机构")]
        ServiceOrgan,
        /// <summary>
        /// 政策解读
        /// </summary>
        [UIText("政策解读")]
        PolicyInterpretation,
        /// <summary>
        /// 国际条约
        /// </summary>
        [UIText("国际条约")]
        InternationalTreaties,
        /// <summary>
        /// 行业规约
        /// </summary>
        [UIText("行业规约")]
        IndustryStatute,
        /// <summary>
        /// 融资政策
        /// </summary>
        [UIText("融资政策")]
        PolicyInfo,
        /// <summary>
        /// 融资项目
        /// </summary>
        [UIText("融资项目")]
        FindProject,
        /// <summary>
        /// 新品快递
        /// </summary>
        [UIText("新品快递")]
        NewProduct,
        /// <summary>
        /// 招标动态
        /// </summary>
        [UIText("招标动态")]
        BiddingDynamics,
        /// <summary>
        /// 重点头条
        /// </summary>
        [UIText("重点头条")]
        Headlines,
        /// <summary>
        /// 中标结果
        /// </summary>
        [UIText("中标结果")]
        WinBidding,
        /// <summary>
        /// 招标公告
        /// </summary>
        [UIText("招标公告")]
        BiddingNotice,
        /// <summary>
        /// 企业管理
        /// </summary>
        [UIText("企业管理")]
        ManagementExperience,
        /// <summary>
        /// 展会信息
        /// </summary>
        [UIText("展会信息")]
        Exhibition,
        /// <summary>
        /// 创新服务
        /// </summary>
        [UIText("创新服务")]
        Service,
        /// <summary>
        /// 创新需求
        /// </summary>
        [UIText("创新需求")]
        Demand,
        /// <summary>
        /// 个人用户
        /// </summary>
        [UIText("个人用户")]
        Maker,
        /// <summary>
        /// 现代企业制度
        /// </summary>
        [UIText("现代企业制度")]
        EnterpriseSystem,
        /// <summary>
        /// 战略管理
        /// </summary>
        [UIText("战略管理")]
        StrategicManagement,
        /// <summary>
        /// 营销管理
        /// </summary>
        [UIText("营销管理")]
        MarketManagement
    }
   
    /// <summary>
    /// 系统时间段类型
    /// </summary>
    public enum EnumTimeType
    {
        /// <summary>
        /// 一天内
        /// </summary>
        [UIText("当天内")]
        Today,
        /// <summary>
        /// 一周内
        /// </summary>
        [UIText("本周内")]
        ThisWeek,
        /// <summary>
        /// 本月内
        /// </summary>
        [UIText("本月内")]
        ThisMonth,
        /// <summary>
        /// 一年内
        /// </summary>
        [UIText("本年内")]
        ThisYear
    }
    public enum EnumPolicyContentType
    {
        /// <summary>
        /// 科技投入
        /// </summary>
        [UIText("科技投入")]
        TechnologicalInput,
        /// <summary>
        /// 金融支持
        /// </summary>
        [UIText("金融支持")]
        FinanceSupport,
        /// <summary>
        /// 技术转移
        /// </summary>
        [UIText("技术转移")]
        TechnologyTransfer,
        /// <summary>
        /// 人才培养
        /// </summary>
        [UIText("人才培养")]
        TalentTrain,
        /// <summary>
        /// 科技奖励
        /// </summary>
        [UIText("科技奖励")]
        TechnologyAward,
        /// <summary>
        /// 税收激励
        /// </summary>
        [UIText("税收激励")]
        TaxIncentive,
        /// <summary>
        /// 政府采购
        /// </summary>
        [UIText("政府采购")]
        GovernmentProcurement,
        /// <summary>
        /// 创新基地
        /// </summary>
        [UIText("创新基地")]
        InnovativeBase,
        /// <summary>
        /// 产权保护
        /// </summary>
        [UIText("产权保护")]
        CopyrightProtection,
        /// <summary>
        /// 引进消化
        /// </summary>
        [UIText("引进消化")]
        ImportedDigested,
        /// <summary>
        /// 自主创新
        /// </summary>
        [UIText("自主创新")]
        Innovation
    }

    public enum EnumProjectApplicationStatus
    {
        /// <summary>
        /// 正常
        /// </summary>
        [UIText("正常")]
        Normal,
        /// <summary>
        /// 锁定
        /// </summary>
        [UIText("锁定")]
        Lock
    }
    public enum EnumSupportPolicyStatus
    {
        /// <summary>
        /// 正常
        /// </summary>
        [UIText("正常")]
        Normal,
        /// <summary>
        /// 锁定
        /// </summary>
        [UIText("锁定")]
        Lock
    }

    /// <summary>
    /// 粉丝和朋友的排序
    /// </summary>
    public enum EnumOrderByFriends
    { 
        /// <summary>
        /// 默认排序
        /// </summary>
        [UIText("默认排序")]
        CreatetimeDesc,
        /// <summary>
        /// 按时间升序
        /// </summary>
        [UIText("按时间升序")]
        CreatetimeAsc,
        /// <summary>
        /// 按名称降序
        /// </summary>
        [UIText("按名称降序")]
        NameDesc,
        /// <summary>
        /// 按名称升序
        /// </summary>
        [UIText("按名称升序")]
        NameAsc
    }


    #region 知识库收藏信息
    /// <summary>
    /// 收藏信息是否公开
    /// </summary>
    public enum EnumIsPublish
    {
        /// <summary>
        /// 发布
        /// </summary>
        [UIText("公开")]
        Publish,
        /// <summary>
        /// 私有
        /// </summary>
        [UIText("私有")]
        UnPublished
    }

    public enum EnumFavoriteinfoType
    {
        /// <summary>
        /// 原创
        /// </summary>
         [UIText("原创")]
        Original,
        /// <summary>
        /// 转载
        /// </summary>
        [UIText("转载")]
        RePrint
    } 
    #endregion

    /// <summary>
    /// 智能匹配的数据类型。
    /// </summary>
    public enum EnumCDSDataType
    {
        /// <summary>
        /// 招标公告
        /// </summary>
        [UIText("招标公告")]
        Bid = 1,
        /// <summary>
        /// 创新人才
        /// </summary>
        [UIText("创新人才")]
        Person = 2,
        /// <summary>
        /// 通知公告
        /// </summary>
        [UIText("通知公告")]
        Policy = 3,
        /// <summary>
        /// 科技动态
        /// </summary>
        [UIText("科技动态")]
        TechInfo = 4,
        /// <summary>
        /// 市场动态
        /// </summary>
        [UIText("市场动态")]
        Market = 5,
        /// <summary>
        /// 创新服务
        /// </summary>
        [UIText("创新服务")]
        TechService = 6,
        /// <summary>
        /// 科技成果
        /// </summary>
        [UIText("科技成果")]
        TechResult = 7,
        /// <summary>
        /// 科技报告
        /// </summary>
        [UIText("科技报告")]
        TechReport = 8
    }

    public enum EnumCdsTableName
    {
        /// <summary>
        /// 招标
        /// </summary>
        CDS_Bid,
        /// <summary>
        /// 政策
        /// </summary>
        CDS_InfoPolicy,
        /// <summary>
        /// 资讯
        /// </summary>
        CDS_Information,
        /// <summary>
        /// 人才
        /// </summary>
        CDS_Person,
        /// <summary>
        /// 机构
        /// </summary>
        CDS_Org,
        /// <summary>
        /// 知识原创
        /// </summary>
        KM_Favoriteinfo
    }

    /// <summary>
    /// 是否已读。
    /// </summary>
    public enum EnumIsRead
    {
        /// <summary>
        /// 未读
        /// </summary>
        [UIText("未读")]
        UnRead,
        /// <summary>
        /// 已读
        /// </summary>
        [UIText("已读")]
        Readed
    }
    /// <summary>
    /// 状态
    /// </summary>
    public enum EnumStatus
    {
        /// <summary>
        /// 正常
        /// </summary>
        [UIText("正常")]
        Normal=0,
        /// <summary>
        /// 锁定
        /// </summary>
        [UIText("锁定")]
        Lock=1
    }

    public enum EnumEs_information
    {
        /// <summary>
        /// 按名称降序
        /// </summary>
        [UIText("按权重降序")]
        WeightDesc=3,
        /// <summary>
        /// 按名称升序
        /// </summary>
        [UIText("按权重升序")]
        WeightAsc=2,
        /// <summary>
        /// 按时间升序
        /// </summary>
        [UIText("按时间升序")]
        CreatetimeAsc=1,
        /// <summary>
        /// 默认排序
        /// </summary>
        [UIText("默认排序")]
        CreatetimeDesc=0
    }

    /// <summary>
    /// 企业性质
    /// </summary>
    public enum EnumEnterpriseNature
    { 
        /// <summary>
        /// 国有企业
        /// </summary>
        [UIText("国有企业")]
        StateOwned,
        /// <summary>
        /// 集体所有制企业
        /// </summary>
        [UIText("集体所有制企业")]
        EmployeeOwnership,
        /// <summary>
        /// 联营企业
        /// </summary>
        [UIText("联营企业")]
        Consortium,
        /// <summary>
        /// 三资企业
        /// </summary>
        [UIText("三资企业")]
        ForeignCapital,
        /// <summary>
        /// 私营企业
        /// </summary>
        [UIText("私营企业")]
        Private,
        /// <summary>
        /// 其他
        /// </summary>
        [UIText("其他")]
        Other
    }

    /// <summary>
    /// 企业规模
    /// </summary>
    public enum EnumEnterpriseScale
    {
        /// <summary>
        /// 少于50人
        /// </summary>
        [UIText("少于50人")]
        ScaleOne,
        /// <summary>
        /// 50-150人
        /// </summary>
        [UIText("50-150人")]
        ScaleTwo,
        /// <summary>
        /// 150-500人
        /// </summary>
        [UIText("150-500人")]
        ScaleThree,
        /// <summary>
        /// 50-1000人
        /// </summary>
        [UIText("500-1000人")]
        ScaleFour,
        /// <summary>
        /// 1000-5000人
        /// </summary>
        [UIText("1000-5000人")]
        ScaleFive,
        /// <summary>
        /// 5000-10000人
        /// </summary>
        [UIText("5000-10000人")]
        ScaleSix,
        /// <summary>
        /// 10000人以上
        /// </summary>
        [UIText("10000人以上")]
        ScaleSeven
    }

    /// <summary>
    /// 企业级众创网络空间成员状态。
    /// </summary>
    public enum EnumEnterpriseMemberStatus
    { 
        /// <summary>
        /// 申请加入
        /// </summary>
        [UIText("申请加入")]
        ApplyJoin,
        /// <summary>
        /// 邀请加入
        /// </summary>
        [UIText("邀请加入")]
        InvitedJoin,
        /// <summary>
        /// 已经加入
        /// </summary>
        [UIText("已加入")]
        Joined
    }

    /// <summary>
    /// 企业状态。
    /// </summary>
    public enum EnumEnterpriseStatus
    {
        /// <summary>
        /// 待审核
        /// </summary>
        [UIText("待审核")]
        UnVerified,
        /// <summary>
        /// 正常
        /// </summary>
        [UIText("正常")]
        Normal,
        /// <summary>
        /// 审核未通过
        /// </summary>
        [UIText("审核未通过")]
        VerifiedFail
    }

    /// <summary>
    /// 是否。
    /// </summary>
    public enum EnumYesOrNo
    {
        /// <summary>
        /// 否
        /// </summary>
        No = 0,
        /// <summary>
        /// 是
        /// </summary>
        Yes = 1        
    }

    /// <summary>
    /// 上传图片类型枚举。
    /// </summary>
    public enum EnumImageType
    {
        Logo,
        Banner,
        EsInfoImg
    }

    public enum EnumOrderByUserApply
    {
        /// <summary>
        /// 默认排序
        /// </summary>
        [UIText("按时间降序")]
        CreatetimeDesc,
        /// <summary>
        /// 按加入时间升序
        /// </summary>
        [UIText("按时间升序")]
        CreatetimeAsc
    }

    /// <summary>
    /// 文件类型。
    /// </summary>
    public enum EnumFileType
    { 
        /// <summary>
        /// 临时文件
        /// </summary>
        Temp,
        /// <summary>
        /// 正式文件
        /// </summary>
        Formal
    }

    /// <summary>
    /// 列表显示方式
    /// </summary>
    public enum EnumListShowType
    { 
        /// <summary>
        /// 信息列表
        /// </summary>
        [UIText("信息列表")]
        InfoList,
        /// <summary>
        /// 图片列表
        /// </summary>
        [UIText("图片列表")]
        ImageList
    }

    /// <summary>
    /// 推送类型。
    /// </summary>
    public enum EnumRecommendType
    { 
        /// <summary>
        /// 系统推送
        /// </summary>
        SystemRecommend,
        /// <summary>
        /// 企业推送
        /// </summary>
        EnterpriseRecommend
    }
}


