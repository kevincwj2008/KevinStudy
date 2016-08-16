using System;

namespace XFCompany.CIPnetWeb.LogicModel
{
    /// <summary>
    /// BaseList类。
    /// </summary>
    public class BaseList : BasePage
    {
        #region 属性

        /// <summary>
        /// 获取全部列表都需要的参数 - 当前页码数
        /// </summary>
        protected int thisPage = 1;
        /// <summary>
        /// 获取部分列表需要的参数 - 关键词
        /// </summary>
        protected string keywords = String.Empty;
        /// <summary>
        /// 获取列表需要的参数 - 排序类型
        /// </summary>
        protected string orderType = String.Empty;

        #region 分页参数
        /// <summary>
        /// 每页条数，大列表页永远为定值 10
        /// </summary>
        protected int pageSize = 0;
        /// <summary>
        /// 列表数据总条数
        /// </summary>
        protected int totalNum = -1;
        /// <summary>
        /// 总页数
        /// </summary>
        protected int totalPage = 0;
        /// <summary>
        /// 用来保存生成页码信息的字符串
        /// </summary>
        protected string strPageInfo;
        /// <summary>
        /// 当前页码前面显示n个页码
        /// </summary        /// </summary>
        protected int prepageNum = 4;
        /// <summary>
        /// 当前页码后面显示n个页码
        /// </summary>
        protected int nxtpageNum = 4;
        #endregion

        #endregion

        /// <summary>
        /// 每页条数。
        /// </summary>
        protected int showPageNum = 10;

        /// <summary>
        /// 生成一个页码的字符串。
        /// </summary>
        /// <param name="curPage">需要生成的页码。</param>
        /// <param name="isEllipsis">是否为省略号。</param>
        /// <param name="listName">列表名称。</param>
        protected virtual string CreateOnePageStr(string curPage, bool isEllipsis, string listName)
        {
            return String.Empty;
        }
        /// <summary>
        /// 获取列表需要的参数 - 列表ID
        /// </summary>
        protected string listName = String.Empty;
        /// <summary>
        /// 生成分页字符串。
        /// </summary>
        protected virtual void CreatePagesStr(string listName)
        {
        }

        /// <summary>
        /// 生成分页字符串，纯页码，类似：1 2 3。
        /// </summary>
        protected void CreatePageLogic(string listName)
        {
            int i = totalNum / pageSize;
            int j = totalNum % pageSize == 0 ? 0 : 1;
            totalPage = i + j;
            int temppage = thisPage;
            if (totalPage <= showPageNum)
            {
                int curPage = 1;
                while (curPage <= totalPage)
                {
                    this.strPageInfo += this.CreateOnePageStr((curPage++).ToString(), false, listName);
                }
            }
            else
            {
                if (thisPage <= (showPageNum - 4))
                {
                    int curPage = 1;
                    while (curPage <= (showPageNum - 2))
                    {
                        this.strPageInfo += this.CreateOnePageStr((curPage++).ToString(), false, listName);
                    }
                    this.strPageInfo += this.CreateOnePageStr((showPageNum - 1).ToString(), true, listName);
                    curPage = totalPage - 1;
                    while (curPage <= totalPage)
                    {
                        this.strPageInfo += this.CreateOnePageStr((curPage++).ToString(), false, listName);
                    }
                }
                else
                {
                    int curPage = 1;
                    while (curPage <= 2)
                    {
                        this.strPageInfo += this.CreateOnePageStr((curPage++).ToString(), false, listName);
                    }

                    if ((totalPage - thisPage) < (showPageNum - 2))
                    {
                        if (thisPage != (showPageNum - 4))
                        {
                            this.strPageInfo += this.CreateOnePageStr((totalPage - (showPageNum - 2)).ToString(), true, listName);
                        }

                        curPage = totalPage - (showPageNum - 2) + 1;
                        while (curPage <= totalPage)
                        {
                            this.strPageInfo += this.CreateOnePageStr((curPage++).ToString(), false, listName);
                        }


                    }
                    else
                    {
                        if (thisPage != (showPageNum - 4))
                        {
                            this.strPageInfo += this.CreateOnePageStr((this.thisPage - 2).ToString(), true, listName);
                        }

                        curPage = thisPage - 1;
                        while (curPage <= (thisPage + 1))
                        {
                            this.strPageInfo += this.CreateOnePageStr((curPage++).ToString(), false, listName);
                        }
                        this.strPageInfo += this.CreateOnePageStr((thisPage + 2).ToString(), true, listName);
                        curPage = totalPage - 1;
                        while (curPage <= totalPage)
                        {
                            this.strPageInfo += this.CreateOnePageStr((curPage++).ToString(), false, listName);
                        }
                    }
                }
            }
        }
    }
}
