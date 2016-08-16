; (function ($, window, document, undefined) {
    //定义CIPnetList的构造函数
    var CIPnetList = function (ele, opt) {
        this.$element = ele,
        this.defaults = {
            "thispage": 1,
            "pagesize": 12,
            "url": "",
            "callback": function (JsonData, totalCount) { },
            "loading": "正在为您获取数据",
            "error": "获取数据失败，请稍后再试",
            "nodata": "没有数据",
            "pageboxid": "Pagination"
        },
        this.options = $.extend({}, this.defaults, opt);
        this.GetData(true);
    }

    //定义CIPnetList的方法
    CIPnetList.prototype = {
        AjaxParameter: function (IsReadHash) {
            var ListCondition = [];
            if (IsReadHash) {
                try {
                    if (window.location.hash != "") {
                        jQuery.parseJSON(unescape(window.location.hash).substring(1));
                        ListCondition.push(unescape(window.location.hash).substring(1));
                        if ($.trim(ListCondition.join('')) != "") {
                            JsonParameters = jQuery.parseJSON(ListCondition.join(''));
                            for (var key in JsonParameters) {
                                if (key == "thispage" || key == "pagesize")
                                    eval('this.options.' + key + '="' + JsonParameters[key] + '";');
                                else
                                    $(".ciplistcon[pname='" + key + "']", "#ConditionBox").val(unescape(JsonParameters[key]));
                            }
                            return JsonParameters;
                        }
                    }
                } catch (e) {
                }
            }
            var ListConAry = $(".ciplistcon", "#ConditionBox");
            ListCondition.push("{");
            ListCondition.push("\"thispage\":\"" + this.options.thispage + "\"");
            ListCondition.push(",\"pagesize\":\"" + this.options.pagesize + "\"");
            var CurrObj = this;
            if (ListConAry.length > 0) {
                $.each(ListConAry, function () {
                    ListCondition.push(",\"" + $(this).attr("pname") + "\":\"" + escape($(this).val()) + "\"");
                });
            }
            ListCondition.push("}");
            window.location.hash = escape(ListCondition.join(''));
            return jQuery.parseJSON(ListCondition.join(''));
        },
        CIPnetEscape: function (SourceStr) {
            SourceStr = SourceStr.replace(/>/g, "&gt;");
            SourceStr = SourceStr.replace(/</g, "&lt;");
            SourceStr = SourceStr.replace(/ /g, "&nbsp;");
            SourceStr = SourceStr.replace(/"/g, "&quot;");
            SourceStr = SourceStr.replace(/'/g, "&#39;");
            SourceStr = SourceStr.replace(/\\/g, "\\\\");//对斜线的转义  
            SourceStr = SourceStr.replace(/\n/g, "\\n");
            SourceStr = SourceStr.replace(/\r/g, "\\r");
            return SourceStr;//.replace(/'/g, "\\'").replace(/"/g, '\\"');//$("<div/>").text(SourceStr).html()
        },
        GetData: function (IsReadHash) {
            var CurrObj = this;
            var jqxhr = $.ajax({
                url: CurrObj.options.url,
                type: "POST",// 默认为GET,你可以根据需要更改
                //cache: true,// 默认为true,但对于script,jsonp类型为false,可以自行设置
                data: CurrObj.AjaxParameter(IsReadHash),
                dataType: "json",// 指定想要的数据类型
                beforeSend: function () {
                    if (typeof CurrObj.options.loading == "function")
                        CurrObj.options.loading();
                    else
                        CurrObj.$element.html(CurrObj.options.loading);
                    $("#" + CurrObj.options.pageboxid).html("");
                },
                //jsonp: "callback", // 指定回调处理JSONP类型的请求
                statusCode: { // 如果你想处理各状态的错误的话
                    //404: handler404,
                    //500: handler500
                }
            });
            jqxhr.done(function (backData) {//拼接页面列表
                if (backData.issuccess == "true") {
                    if (backData.data.length == 0) {
                        if (typeof CurrObj.options.nodata == "function")
                            CurrObj.options.nodata();
                        else
                            CurrObj.$element.html(CurrObj.options.nodata);
                    }
                    else {
                        CurrObj.$element.html("");
                        CurrObj.options.callback(backData.data);
                    }
                }
                else {
                    if (typeof CurrObj.options.error == "function")
                        CurrObj.options.error();
                    else
                        CurrObj.$element.html(CurrObj.options.error);
                }
            });
            jqxhr.done(function (backData) {//显示分页
                var totalCount = parseInt(backData.count);
                if (totalCount > 0)
                    CurrObj.CreateSplitPage(totalCount);
            });
            jqxhr.fail(function () {
                if (typeof CurrObj.options.error == "function")
                    CurrObj.options.error();
                else
                    CurrObj.$element.html(CurrObj.options.error);
            });
        },
        Refresh: function (page) {//刷新页码
            this.options.thispage = page;
            this.GetData(false);
        },
        CreateSplitPage: function (totalCount) {
            var CurrObj = this;
            var totalPage = this.GetTotalPage(parseInt(totalCount), parseInt(this.options.pagesize));
            laypage({
                cont: $("#" + this.options.pageboxid),
                pages: totalPage,
                curr: this.options.thispage,
                count: totalCount,
                skin: "#666",
                last: false,
                prev: "上一页",
                next: "下一页",
                jump: function (e, first) {
                    if (!first) {
                        CurrObj.Refresh(e.curr);
                    }
                }
            });
        },
        GetTotalPage: function (totalCount, pageSize) {
            if (totalCount == 0 || pageSize == 0) return 0;
            return Math.ceil(totalCount / pageSize);
        },
        Do: function (DoUrl, JsonParameters, CallbackFun) {
            var jqxhr = $.ajax({
                url: DoUrl,
                type: "POST",// 默认为GET,你可以根据需要更改
                //cache: true,// 默认为true,但对于script,jsonp类型为false,可以自行设置
                data: JsonParameters,
                dataType: "json",// 指定想要的数据类型
                //beforeSend: function () {
                //    if (typeof CurrObj.options.loading == "function")
                //        CurrObj.options.loading();
                //    else
                //        CurrObj.$element.html(CurrObj.options.loading);
                //    $("#" + CurrObj.options.pageboxid).html("");
                //},
                //jsonp: "callback", // 指定回调处理JSONP类型的请求
                statusCode: { //如果你想处理各状态的错误的话
                    //404: handler404,
                    //500: handler500
                }
            });
            jqxhr.done(function (backData) {//拼接页面列表
                CallbackFun(backData);
            });
            jqxhr.fail(function () {
                alert("执行操作失败，请重试。");
            });
        }
    }
    //在插件中使用CIPnetList对象
    $.fn.CIPnetList = function (options) {
        //创建CIPnetList的实体
        var cipList = new CIPnetList(this, options);
        //调用其方法
        return cipList;
    }
})(jQuery, window, document);