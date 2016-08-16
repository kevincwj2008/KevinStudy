﻿using Lucene.Net.Analysis;
using Lucene.Net.Analysis.PanGu;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.QueryParsers;
using Lucene.Net.Search;
using Lucene.Net.Store;
using PanGu;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Reflection;
using System.Text;
using XFCompany.CIPnetWeb.LogicModel;

/// <summary>
/// 盘古分词在lucene.net中的使用帮助类
/// 调用LuceneHelper.instance
/// </summary>
public class LuceneHelper
{
    /// <summary>
    /// 定义平台内的Lucene类型
    /// </summary>
    public enum EnumLuceneType
    { 
        CdsBid
    }

    public static Dictionary<string, Directory> DictDirectory = new Dictionary<string, Directory>();

    private LuceneHelper() { }

    #region 单一实例
    private static LuceneHelper _instance = null;
    /// <summary>
    /// 单一实例
    /// </summary>
    public static LuceneHelper instance
    {
        get
        {
            if (_instance == null) _instance = new LuceneHelper();
            return _instance;
        }
    }
    #endregion

    #region 分词测试
    /// <summary>
    /// 分词测试
    /// </summary>
    /// <param name="keyword"></param>
    /// <returns></returns>
    protected string GetKeyWordsSplitBySpace(string keywords, PanGuTokenizer tokenizer)
    {
        StringBuilder result = new StringBuilder();
        ICollection<WordInfo> words = tokenizer.SegmentToWordInfos(keywords);
        foreach (var item in words)
        {
            if (item == null)
            {
                continue;
            }
            result.AppendFormat("{0}^{1}.0 ", item.Word, (int)Math.Pow(3, item.Rank));
        }
        return result.ToString().Trim();
    }
    #endregion

    #region directory_luce
    /// <summary>
    /// Lucene.Net的目录-参数
    /// </summary>
    private Directory GetLuceneDirectory(string LuceneFolder)
    {
        if (DictDirectory.ContainsKey(LuceneFolder))
            return DictDirectory[LuceneFolder];
        else
        {
            string LucenePath = "D:\\Study\\LuceneNet\\DataSource";
            LucenePath += LuceneFolder;
            System.IO.DirectoryInfo directory = null;
            if (!System.IO.Directory.Exists(LucenePath))
                directory = System.IO.Directory.CreateDirectory(LucenePath);
            else
                directory = new System.IO.DirectoryInfo(LucenePath);
            Directory temp = Lucene.Net.Store.FSDirectory.Open(directory);
            DictDirectory.Add(LuceneFolder, temp);
            return temp;
        }
    }
    #endregion

    #region Lucene Analyzer
    private Analyzer _analyzer = null;
    /// <summary>
    /// Lucene使用的分词器。
    /// </summary>
    public Analyzer analyzer
    {
        get
        {
            if (_analyzer == null)
            {
                _analyzer = new Lucene.Net.Analysis.PanGu.PanGuAnalyzer();
                //_analyzer = new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_30);
            }
            return _analyzer;
        }
    }
    #endregion

    #region Lucene Version Num
    private static Lucene.Net.Util.Version _version = Lucene.Net.Util.Version.LUCENE_30;
    /// <summary>
    /// Lucene版本号。
    /// </summary>
    public Lucene.Net.Util.Version version
    {
        get
        {
            return _version;
        }
    }
    #endregion

    #region 创建招标索引、并搜索
    /// <summary>
    /// 创建索引
    /// </summary>
    /// <param name="datalist"></param>
    /// <returns></returns>
    public bool CreateCdsBidIndex(DataTable InfoDt, string SelectFiled, string SegField)
    {
        if (InfoDt == null || InfoDt.Rows.Count == 0)
            return true;
        IndexWriter writer = null;
        Directory LuceneDirectory = this.GetLuceneDirectory(EnumLuceneType.CdsBid.ToString());
        try
        {
            writer = new IndexWriter(LuceneDirectory, analyzer, false, IndexWriter.MaxFieldLength.LIMITED); //false表示追加（true表示删除之前的重新写入）
        }
        catch
        {
            writer = new IndexWriter(LuceneDirectory, analyzer, true, IndexWriter.MaxFieldLength.LIMITED); //false表示追加（true表示删除之前的重新写入）
        }

        ArrayList SegFieldList = new ArrayList(SegField.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries));
        ArrayList SelectFiledList = new ArrayList(SelectFiled.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries));

        Document tempdoc;
        string PropName = String.Empty, PropValue = String.Empty;
        object PropObj;
        DateTime tempDate;
        foreach (DataRow tempDr in InfoDt.Rows)
        {
            tempdoc = new Document();
            foreach (string writeField in SelectFiledList)
            {
                PropName = writeField;
                PropObj = tempDr[writeField];
                PropValue = PropObj == null ? String.Empty : PropObj.ToString();
                if (DateTime.TryParse(PropValue, out tempDate))
                    PropValue = tempDate.ToString("yyyy-MM-dd HH:mm:ss");
                if (SegFieldList.Contains(PropName))
                    tempdoc.Add(new Field(PropName, PropValue, Field.Store.YES, Field.Index.ANALYZED));
                else
                    tempdoc.Add(new Field(PropName, PropValue, Field.Store.YES, Field.Index.NOT_ANALYZED));//id不分词

                if (PropName == "ImagePath")
                    tempdoc.Add(new Field("IsHasImage", (String.IsNullOrEmpty(PropValue) ? "0" : "1"), Field.Store.YES, Field.Index.NOT_ANALYZED));
            }

            try
            {
                writer.AddDocument(tempdoc);
            }
            catch (System.IO.FileNotFoundException fnfe)
            {
                continue;
            }
        }
        writer.Optimize();
        writer.Dispose();
        return true;
    }

    public string SearchCdsBid(int thisPage, int onepageCount, string Keyword, int CatalogId
    , int AreaId, int IndustryId, string orderType, int IsImage,
    int timeType, int deadLine, string browseTime, int IsRead, out int totalNum,string selectField)
    {
        BooleanQuery bq = new BooleanQuery();
        if (!String.IsNullOrEmpty(Keyword))
        {
            string[] fileds = CdsBid.SegField.Split(',');
            QueryParser parser = new MultiFieldQueryParser(version, fileds, analyzer);//多个字段查询
            Keyword = GetKeyWordsSplitBySpace(Keyword, new PanGuTokenizer());
            Query queryKeyword = parser.Parse(Keyword);
            bq.Add(queryKeyword, Occur.MUST);//与运算
        }

        Term tempTerm;
        Query tempQuery;
        if (CatalogId != -1)
        {
            tempTerm = new Term("CatalogID", CatalogId + "*");
            tempQuery = new WildcardQuery(tempTerm); //new TermQuery(tempTerm);
            bq.Add(tempQuery, Occur.MUST);//与运算
        }

        if (IndustryId != -1)
        {
            tempTerm = new Term("IndustryID", IndustryId + "*");
            tempQuery = new WildcardQuery(tempTerm); //new TermQuery(tempTerm);
            bq.Add(tempQuery, Occur.MUST);//与运算
        }

        if (AreaId != -1)
        {
            tempTerm = new Term("AreaID", AreaId + "*");
            tempQuery = new WildcardQuery(tempTerm); //new TermQuery(tempTerm);
            bq.Add(tempQuery, Occur.MUST);//与运算
        }

        if (IsImage != -1)
        {
            tempTerm = new Term("IsHasImage", IsImage.ToString());
            tempQuery = new TermQuery(tempTerm);
            bq.Add(tempQuery, Occur.MUST);//与运算
        }

        if (timeType != -1)
        {
            DateTime StartDate,EndDate;
            switch (timeType)
            {
                case 0://当天时间
                    StartDate = DateTime.Now;
                    EndDate = StartDate.AddDays(1);
                    tempQuery = new TermRangeQuery("CreateTime", StartDate.ToString("yyyy-MM-dd"), EndDate.ToString("yyyy-MM-dd"), true, false);
                    bq.Add(tempQuery, Occur.MUST);//与运算
                    break;
                case 1://本周
                    StartDate = DateTime.Today.AddDays(0 - (int)DateTime.Now.DayOfWeek);
                    EndDate = DateTime.Today;
                    tempQuery = new TermRangeQuery("CreateTime", StartDate.ToString("yyyy-MM-dd"), EndDate.ToString("yyyy-MM-dd"), true, false);
                    bq.Add(tempQuery, Occur.MUST);//与运算
                    break;
                case 2://本月
                    StartDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                    EndDate = DateTime.Today.AddDays(0 - (int)DateTime.Now.DayOfWeek);
                    tempQuery = new TermRangeQuery("CreateTime", StartDate.ToString("yyyy-MM-dd"), EndDate.ToString("yyyy-MM-dd"), true, false);
                    bq.Add(tempQuery, Occur.MUST);//与运算
                    break;
                case 3://本年
                    StartDate = new DateTime(DateTime.Now.Year, 1, 1);
                    EndDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                    tempQuery = new TermRangeQuery("CreateTime", StartDate.ToString("yyyy-MM-dd"), EndDate.ToString("yyyy-MM-dd"), true, false);
                    bq.Add(tempQuery, Occur.MUST);//与运算
                    break;
            }
        }

        if (deadLine != -1)
        {
            DateTime StartDate, EndDate;
            switch (deadLine)
            {
                case 0://当天时间
                    StartDate = DateTime.Now;
                    EndDate = StartDate.AddDays(1);
                    tempQuery = new TermRangeQuery("Deadline", StartDate.ToString("yyyy-MM-dd"), EndDate.ToString("yyyy-MM-dd"), true, false);
                    bq.Add(tempQuery, Occur.MUST);//与运算
                    break;
                case 1://本周
                    StartDate = DateTime.Today.AddDays(0 - (int)DateTime.Now.DayOfWeek);
                    EndDate = DateTime.Today;
                    tempQuery = new TermRangeQuery("Deadline", StartDate.ToString("yyyy-MM-dd"), EndDate.ToString("yyyy-MM-dd"), true, false);
                    bq.Add(tempQuery, Occur.MUST);//与运算
                    break;
                case 2://本月
                    StartDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                    EndDate = DateTime.Today.AddDays(0 - (int)DateTime.Now.DayOfWeek);
                    tempQuery = new TermRangeQuery("Deadline", StartDate.ToString("yyyy-MM-dd"), EndDate.ToString("yyyy-MM-dd"), true, false);
                    bq.Add(tempQuery, Occur.MUST);//与运算
                    break;
                case 3://本年
                    StartDate = new DateTime(DateTime.Now.Year, 1, 1);
                    EndDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                    tempQuery = new TermRangeQuery("Deadline", StartDate.ToString("yyyy-MM-dd"), EndDate.ToString("yyyy-MM-dd"), true, false);
                    bq.Add(tempQuery, Occur.MUST);//与运算
                    break;
            }
        }

        if (IsRead != -1 && !String.IsNullOrEmpty(browseTime))
        {
            if (IsRead == 0) //未读
            {
                tempQuery = new TermRangeQuery("CreateTime", browseTime, DateTime.MaxValue.ToString("yyyy-MM-dd"), true, false);
                bq.Add(tempQuery, Occur.MUST);//与运算 
            }
            else //已读
            {
                tempQuery = new TermRangeQuery("CreateTime", DateTime.MinValue.ToString("yyyy-MM-dd"), browseTime, true, false);
                bq.Add(tempQuery, Occur.MUST);//与运算 
            }
        }



        Directory LuceneDirectory = this.GetLuceneDirectory(EnumLuceneType.CdsBid.ToString());

        TopScoreDocCollector collector = TopScoreDocCollector.Create(thisPage * onepageCount, false);

        IndexSearcher searcher = new IndexSearcher(LuceneDirectory, true);//true-表示只读


        if (String.IsNullOrEmpty(orderType))
            orderType = String.IsNullOrEmpty(Keyword) ? "CreateTimeDesc" : "ScoreDesc,CreateTimeDesc";

        String[] OrderAry = orderType.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
        SortField[] tempSortField = new SortField[OrderAry.Length];
        int tempIndex = 0;
        foreach (string tempOrder in OrderAry)
        {
            if (tempOrder.Length > 4)
            {
                if (tempOrder.Substring(0, tempOrder.Length - 4).ToLower() == "score")
                    tempSortField[tempIndex] = new SortField(null, SortField.SCORE);
                else
                    tempSortField[tempIndex] = new SortField(tempOrder.Substring(0, tempOrder.Length - 4), SortField.DOC, (tempOrder.Substring(tempOrder.Length - 4).ToLower() == "desc" ? true : false));
            }
            else
                tempSortField[tempIndex] = new SortField(tempOrder, SortField.DOC, true);
            tempIndex++;
        }


        Sort sort = new Sort(tempSortField);
        TopDocs docs = searcher.Search(bq, (Filter)null, thisPage * onepageCount, sort);
        //searcher.Search(bq, collector);

        if (docs == null || docs.TotalHits == 0)
        //if (collector == null || collector.TotalHits == 0)
        {
            totalNum = 0;
            return null;
        }
        else
        {
            int start = onepageCount * (thisPage - 1);
            //结束数
            int limit = onepageCount;
            ScoreDoc[] hits = collector.TopDocs(start, limit).ScoreDocs;
            totalNum = collector.TotalHits;
            CdsBid tempCdsbid;
            List<CdsBid> list = new List<CdsBid>();


            for (int i = 0; i < docs.TotalHits; i++)
            {
                if (i >= (thisPage - 1) * onepageCount && i < thisPage * onepageCount)
                {
                    Document doc = searcher.Doc(docs.ScoreDocs[i].Doc);
                    //        Document doc = searcher.Doc(sd.Doc);
                    tempCdsbid = new CdsBid();
                    tempCdsbid.ID = int.Parse(doc.Get("ID"));
                    tempCdsbid.AreaID = int.Parse(doc.Get("AreaID"));
                    tempCdsbid.CatalogID = int.Parse(doc.Get("CatalogID"));
                    tempCdsbid.IndustryID = int.Parse(doc.Get("IndustryID"));
                    tempCdsbid.Description = doc.Get("Description").ToString();
                    tempCdsbid.Deadline = doc.Get("Deadline").ToString();
                    tempCdsbid.Status = int.Parse(doc.Get("Status"));
                    tempCdsbid.Name = doc.Get("Name").ToString();
                    tempCdsbid.ImagePath = doc.Get("ImagePath").ToString();
                    tempCdsbid.CreateTime = DateTime.Parse(doc.Get("CreateTime").ToString());
                    list.Add(tempCdsbid);
                }
            }


            //foreach (ScoreDoc sd in hits)//遍历搜索到的结果
            //{
            //    try
            //    {
            //        Document doc = searcher.Doc(sd.Doc);
            //        tempCdsbid = new CdsBid();
            //        tempCdsbid.ID = int.Parse(doc.Get("ID"));
            //        tempCdsbid.AreaID = int.Parse(doc.Get("AreaID"));
            //        tempCdsbid.CatalogID = int.Parse(doc.Get("CatalogID"));
            //        tempCdsbid.IndustryID = int.Parse(doc.Get("IndustryID"));
            //        tempCdsbid.Description = doc.Get("Description").ToString();
            //        tempCdsbid.Deadline = doc.Get("Deadline").ToString();
            //        tempCdsbid.Status = int.Parse(doc.Get("Status"));
            //        tempCdsbid.Name = doc.Get("Name").ToString();
            //        tempCdsbid.ImagePath = doc.Get("ImagePath").ToString();
            //        tempCdsbid.CreateTime = DateTime.Parse(doc.Get("CreateTime").ToString());
            //        list.Add(tempCdsbid);
            //    }
            //    catch (Exception ex)
            //    {
            //        Console.WriteLine(ex.Message);
            //    }
            //}
            return list;
        }
        //st.Stop();
        //Response.Write("查询时间：" + st.ElapsedMilliseconds + " 毫秒<br/>");

    }
    #endregion
}