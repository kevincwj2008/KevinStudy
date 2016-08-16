function AdList_Back(e) {
    this.conf = e;
    this.CIPnetList;
};

AdList_Back.prototype = {
    init: function () {
        AdList_Back.CIPnetList = $("#AdList").CIPnetList({
            "thispage": 1,
            "pagesize": 20,
            "url": "http://localhost:13065/ad/handler.ashx",
            "callback": AdList_Back.CallBackAd,
            "loading": AdList_Back.loading
        });

        $("#SearchBtn").click(function () {
            AdList_Back.CIPnetList.Refresh(1);
        });
    },
    CallBackAd: function (JsonData) {
        $("#AdTmpl").tmpl(JsonData).appendTo("#AdList");
    },
    loading: function () {
        $("#AdList").html("我们正在努力为您获取数据");
    }
};