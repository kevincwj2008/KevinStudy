<%@ WebHandler Language="C#" Class="Handler" %>

using System;
using System.Web;
using System.Data;
using XFCompany.CIPnetWeb.DBOper;
using System.Collections.Generic;
using Newtonsoft.Json;

public class Handler : IHttpHandler {
    public enum EnumAdStatus
    { 
        /// <summary>
        /// 正常
        /// </summary>
        Normal,
        /// <summary>
        /// 锁定
        /// </summary>
        Lock
    }
    
    public void ProcessRequest (HttpContext context) {
        string keywords = String.Empty;
        if (context.Request["keyword"] != null)
            keywords = Microsoft.JScript.GlobalObject.unescape(context.Request["keyword"]);
        keywords = String.Empty;
        string sql = "SELECT TOP  10 PID,Name,Source,Url,Status FROM dbo.TB_Resources";
        if (!String.IsNullOrEmpty(keywords))
            sql += " where name like '%" + keywords + "%'";
        string status = String.Empty;
        if (context.Request["status"] != null)
            status = context.Request["status"];
        if (!String.IsNullOrEmpty(status) && status != "-1")
            sql += " and status = " + status;
        sql += " ORDER BY Createtime desc";
        DataTable tempDt = new BaseDBOper().DBOper.ExecuteSqlToDataTable(sql);
//        var tempEntity = new { ID = 0, Name = string.Empty };

        string JsonData = String.Empty;
        if (tempDt != null && tempDt.Rows.Count > 0)
        {
            List<Dictionary<string, string>> JsonList = new List<Dictionary<string, string>>();
            Dictionary<string, string> JsonDic;
            foreach (DataRow tempDr in tempDt.Rows)
            {
                JsonDic = new Dictionary<string, string>();
                JsonDic.Add("pid", tempDr["PID"].ToString());
                JsonDic.Add("name", tempDr["Name"].ToString());
                JsonDic.Add("source", tempDr["Source"].ToString());
                JsonDic.Add("url", tempDr["Url"].ToString());
                JsonDic.Add("status", tempDr["Status"].ToString());
                JsonDic.Add("statustext", (tempDr["Status"].ToString() == "0" ? "正常" : "锁定"));
                JsonList.Add(JsonDic);
            }
            JsonData = DicToJson(JsonList);
        }
        else
            JsonData = DicToJson(null);
        context.Response.Write(JsonData);
        context.Response.End();        
    }

    private string DicToJson(List<Dictionary<string, string>> JsonList)
    {
        string DataJson = String.Empty;
        DataJson = JsonList == null ? "[]" : JsonConvert.SerializeObject(JsonList);
        return "{\"issuccess\":\"true\",\"count\":" + (JsonList == null ? 0 : 21554) + ",\"data\":" + DataJson + "}";
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }


    protected void Page_Error(object sender, EventArgs e)
    {
        Exception ex = HttpContext.Current.Server.GetLastError();
        if (HttpContext.Current.Server.GetLastError() is HttpRequestValidationException)
        {
            HttpContext.Current.Response.Write("请输入合法的字符串【<a href=\"javascript:history.back(0);\">返回</a>】");
            HttpContext.Current.Server.ClearError();
        }
    } 

}
