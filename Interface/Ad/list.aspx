<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeFile="list.aspx.cs" Inherits="Ad_list" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script type="text/javascript" src="../Js/jquery.min.js"></script>
    <script type="text/javascript" src="../Js/jquery.laypage/laypage.min.js"></script>
    <script type="text/javascript" src="../Js/jquery.tmpl.min.js"></script>
    <%--<script type="text/javascript" src="../Js/jquery.ba-hashchange.min.js"></script>--%>
    <script type="text/javascript" src="../Js/CIPnetList.js"></script>
    <script type="text/javascript" src="../Js/AdList.js"></script>
</head>
<body>
    <h1>广告信息</h1>
    <div id="ConditionBox">
        <input class="ciplistcon" type="text" id="AdStatus" pname="status" value="-1" />
        <input class="ciplistcon" type="text" pname="keyword" value="张"/>
        <input type="button" id="SearchBtn" value="搜索"/>
    </div>
    <div id="AdList"></div>
    <div id="Pagination"></div>
    <script id="AdTmpl" type="text/x-jquery-tmpl">
        <div style="margin-bottom: 10px;">
            <span style="margin-left: 10px;">${pid}</span>
            <span style="margin-left: 10px;">{{= name}}</span>            
            <span style="margin-left: 10px;">${status}</span>
            <span style="margin-left: 10px;">${statustext}</span>
            <span style="margin-left: 10px;">${source}</span>
            <span style="margin-left: 10px;">${url}</span>
        </div>
    </script>
</body>
</html>
<script type="text/javascript">
    $(document).ready(function () {
        window.AdList_Back = new AdList_Back({
            "thispage": 1,
            "pagesize": 20
        });
        window.AdList_Back.init();
    });
</script>
