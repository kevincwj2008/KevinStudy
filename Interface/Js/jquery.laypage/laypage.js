!
function () {
    function e(a) {
        e.dir = "dir" in e ? e.dir : d.getpath + "/skin/laypage.min.css";
        new d(a);
        e.dir && !g[h]("laypagecss") && d.use(e.dir, "laypagecss")
    }
    e.v = "1.3";
    var g = document,
		h = "getElementById",
		k = 0,
		d = function (a) {
		    (this.config = a || {}).item = k++;
		    this.render(!0)
		};
    d.on = function (a, b, c) {
        return a.attachEvent ? a.attachEvent("on" + b, function () {
            c.call(a, window.even)
        }) : a.addEventListener(b, c, !1), d
    };
    d.getpath = function () {
        var a = document.scripts,
			a = a[a.length - 1].src;
        return a.substring(0, a.lastIndexOf("/") + 1)
    }();
    d.use = function (a, b) {
        var c = g.createElement("link");
        c.type = "text/css";
        c.rel = "stylesheet";
        c.href = e.dir;
        b && (c.id = b);
        g.getElementsByTagName("head")[0].appendChild(c)
    };
    d.prototype.type = function () {
        var a = this.config;
        return "object" == typeof a.cont ? void 0 === a.cont.length ? 2 : 3 : void 0
    };
    d.prototype.view = function () {
        var a = this.config,
			b = [],
			c, d, f, g;
        if (a.pages |= 0, a.curr = 0 | a.curr || 1, a.groups = "groups" in a ? 0 | a.groups : 5, a.first = "first" in a ? a.first : "\x26#x9996;\x26#x9875;", a.last = "last" in a ? a.last : "\x26#x5C3E;\x26#x9875;", a.prev = "prev" in a ? a.prev : "\x26#x4E0A;\x26#x4E00;\x26#x9875;", a.next = "next" in a ? a.next : "\x26#x4E0B;\x26#x4E00;\x26#x9875;", 1 > a.pages) return "";
        a.groups > a.pages && (a.groups = a.pages);
        c = Math.ceil((a.curr + (1 < a.groups && a.groups !== a.pages ? 1 : 0)) / (0 === a.groups ? 1 : a.groups));
        1 < c && a.first && 0 !== a.groups && b.push('\x3ca href\x3d"javascript:;" class\x3d"laypage_first" data-page\x3d"1"  title\x3d"\x26#x9996;\x26#x9875;"\x3e' + a.first + "\x3c/a\x3e");
        1 < a.curr && a.prev && b.push('\x3ca href\x3d"javascript:;" class\x3d"laypage_prev" data-page\x3d"' + (a.curr - 1) + '"\x3e' + a.prev + "\x3c/a\x3e");
        1 < c && a.first && 0 !== a.groups && b.push("\x3cspan\x3e\x26#x2026;\x3c/span\x3e");
        d = Math.floor((a.groups - 1) / 2);
        f = 1 < c ? a.curr - d : 1;
        c = 1 < c ?
		function () {
		    var b = a.curr + (a.groups - d - 1);
		    return b > a.pages ? a.pages : b
		}() : a.groups;
        for (c - f < a.groups - 1 && (f = c - a.groups + 1) ; f <= c; f++) f === a.curr ? b.push('\x3cspan class\x3d"laypage_curr" ' + (/^#/.test(a.skin) ? 'style\x3d"background-color:' + a.skin + '"' : "") + "\x3e" + f + "\x3c/span\x3e") : b.push('\x3ca href\x3d"javascript:;" data-page\x3d"' + f + '"\x3e' + f + "\x3c/a\x3e");
        return a.pages > a.groups && c < a.pages && a.last && 0 !== a.groups && b.push('\x3cspan\x3e\x26#x2026;\x3c/span\x3e\x3ca href\x3d"javascript:;" class\x3d"laypage_last" title\x3d"\x26#x5C3E;\x26#x9875;"  data-page\x3d"' + a.pages + '"\x3e' + a.last + "\x3c/a\x3e"), g = !a.prev && 0 === a.groups, (a.curr !== a.pages && a.next || g) && b.push(g && a.curr === a.pages ? '\x3cspan class\x3d"page_nomore" title\x3d"\x26#x5DF2;\x26#x6CA1;\x26#x6709;\x26#x66F4;\x26#x591A;"\x3e' + a.next + "\x3c/span\x3e" : '\x3ca href\x3d"javascript:;" class\x3d"laypage_next" data-page\x3d"' + (a.curr + 1) + '"\x3e' + a.next + "\x3c/a\x3e"), '\x3cdiv name\x3d"laypage' + e.v + '" class\x3d"laypage_main laypageskin_' + (a.skin ?
		function (a) {
		    return /^#/.test(a) ? "molv" : a
		}(a.skin) : "default") + '" id\x3d"laypage_' + this.config.item + '"\x3e\x3cspan class\x3d"laypagezys"\x3e\u603b\u6570\uff1a' + a.count + '\x3c/span\x3e\x3cspan class\x3d"laypagezys"\x3e\u9875\u6570\uff1a' + a.curr + " / " + a.pages + "\x3c/span\x3e" + b.join("") + (a.skip ? '\x3cspan class\x3d"laypage_total"\x3e\x3clabel\x3e\x26#x5230;\x26#x7B2C;\x3c/label\x3e\x3cinput type\x3d"number" min\x3d"1" onkeyup\x3d"this.value\x3dthis.value.replace(/\\D/, \'\');" class\x3d"laypage_skip"\x3e\x3clabel\x3e\x26#x9875;\x3c/label\x3e\x3cbutton type\x3d"button" class\x3d"laypage_btn"\x3e\x26#x786e;\x26#x5b9a;\x3c/button\x3e\x3c/span\x3e' : "") + "\x3c/div\x3e"
    };
    d.prototype.jump = function (a) {
        if (a) {
            var b = this,
				c = b.config,
				e = a.children,
				f = a.getElementsByTagName("button")[0],
				g = a.getElementsByTagName("input")[0];
            a = 0;
            for (var h = e.length; h > a; a++) "a" === e[a].nodeName.toLowerCase() && d.on(e[a], "click", function () {
                var a = 0 | this.getAttribute("data-page");
                c.curr = a;
                b.render()
            });
            f && d.on(f, "click", function () {
                var a = 0 | g.value.replace(/\s|\D/g, "");
                a && a <= c.pages && (c.curr = a, b.render())
            })
        }
    };
    d.prototype.render = function (a) {
        var b = this.config,
			c = this.type(),
			d = this.view();
        2 === c ? b.cont.innerHTML = d : 3 === c ? b.cont.html(d) : g[h](b.cont).innerHTML = d;
        b.jump && b.jump(b, a);
        this.jump(g[h]("laypage_" + b.item));
        b.hash && !a && (location.hash = "!" + b.hash + "\x3d" + b.curr)
    };
    "function" == typeof define ? define(function () {
        return e
    }) : "undefined" != typeof exports ? module.exports = e : window.laypage = e
}();