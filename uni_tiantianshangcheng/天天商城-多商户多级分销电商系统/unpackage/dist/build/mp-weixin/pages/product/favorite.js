(global["webpackJsonp"]=global["webpackJsonp"]||[]).push([["pages/product/favorite"],{"388d":function(n,t,e){"use strict";e.d(t,"b",(function(){return u})),e.d(t,"c",(function(){return i})),e.d(t,"a",(function(){return o}));var o={tianGoodsJoinList:function(){return e.e("uni_modules/tian-mall/components/tian-goods-join-list/tian-goods-join-list").then(e.bind(null,"47d8"))}},u=function(){var n=this,t=n.$createElement;n._self._c},i=[]},"4b84":function(n,t,e){"use strict";var o=e("c492"),u=e.n(o);u.a},7814:function(n,t,e){"use strict";e.r(t);var o=e("7d08"),u=e.n(o);for(var i in o)"default"!==i&&function(n){e.d(t,n,(function(){return o[n]}))}(i);t["default"]=u.a},"7d08":function(n,t,e){"use strict";(function(n,e){Object.defineProperty(t,"__esModule",{value:!0}),t.default=void 0;var o=n.database(),u={data:function(){return{}},onPullDownRefresh:function(){console.log("刷新整页"),e.stopPullDownRefresh(),this.$refs.tgjl.refresh()},methods:{delItem:function(n){var t=this;this.confirmAction((function(){o.collection("opendb-mall-goods-favorite").where({_id:n.favorite_id,user_id:o.env.uid}).remove().then((function(n){t.$success("删除成功"),t.$refs.tgjl.refresh()}))}),"是否确定删除收藏？")}}};t.default=u}).call(this,e("a9ff")["default"],e("543d")["default"])},c492:function(n,t,e){},dfb5:function(n,t,e){"use strict";e.r(t);var o=e("388d"),u=e("7814");for(var i in u)"default"!==i&&function(n){e.d(t,n,(function(){return u[n]}))}(i);e("4b84");var r,f=e("f0c5"),c=Object(f["a"])(u["default"],o["b"],o["c"],!1,null,null,null,!1,o["a"],r);t["default"]=c.exports},f844:function(n,t,e){"use strict";(function(n){e("7a45");o(e("66fd"));var t=o(e("dfb5"));function o(n){return n&&n.__esModule?n:{default:n}}wx.__webpack_require_UNI_MP_PLUGIN__=e,n(t.default)}).call(this,e("543d")["createPage"])}},[["f844","common/runtime","common/vendor"]]]);