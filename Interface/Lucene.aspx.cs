using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
//using XFCompany.CIPnetWeb.LogicModel;

public partial class Lucene : System.Web.UI.Page
{
    protected string MatchName = String.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        ////Lucene写数据
        //DataTable LuceneDt = XFCompany.CIPnetWeb.DBOper.BaseDBOper.DoQuery("SELECT * FROM dbo.CDS_Bid");
        //List<CdsBid> LuceneCollection = (List<CdsBid>)CollectionHelper.ConvertTo<CdsBid>(LuceneDt);
        //LuceneHelper.instance.CreateCdsBidIndex(LuceneCollection);

        ////查询数据
        //int totalNum = 0;
        //List<CdsBid> testCollection = LuceneHelper.instance.SearchCdsBid(1, 10, "询价采购公告", -1, -1, -1, "CreateTimeDesc", -1, -1, -1, String.Empty, -1, out totalNum);
        ////    //LuceneHelper.instance.Search("四川北京疫苗互联网");

        //if (testCollection != null && testCollection.Count > 0)
        //{
        //    foreach (CdsBid temp in testCollection)
        //    {
        //        MatchName += temp.ID + "：" + temp.Name + "------Createtime:" + temp.CreateTime + "<br>";
        //    }
        //}
    }
}