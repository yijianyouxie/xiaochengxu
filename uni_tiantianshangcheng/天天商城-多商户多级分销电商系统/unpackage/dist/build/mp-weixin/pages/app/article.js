(global["webpackJsonp"]=global["webpackJsonp"]||[]).push([["pages/app/article"],{"0211":function(t,n,e){"use strict";e.r(n);var a=e("edd5"),u=e("9390");for(var r in u)"default"!==r&&function(t){e.d(n,t,(function(){return u[t]}))}(r);e("09ab");var i,o=e("f0c5"),c=Object(o["a"])(u["default"],a["b"],a["c"],!1,null,"751f0232",null,!1,a["a"],i);n["default"]=c.exports},"09ab":function(t,n,e){"use strict";var a=e("eef3"),u=e.n(a);u.a},3665:function(t,n,e){"use strict";(function(t){e("7a45");a(e("66fd"));var n=a(e("0211"));function a(t){return t&&t.__esModule?t:{default:t}}wx.__webpack_require_UNI_MP_PLUGIN__=e,t(n.default)}).call(this,e("543d")["createPage"])},"490f":function(t,n,e){"use strict";(function(t,a){Object.defineProperty(n,"__esModule",{value:!0}),n.default=void 0;var u=i(e("a34a")),r=i(e("8ac0"));function i(t){return t&&t.__esModule?t:{default:t}}function o(t,n,e,a,u,r,i){try{var o=t[r](i),c=o.value}catch(f){return void e(f)}o.done?n(c):Promise.resolve(c).then(a,u)}function c(t){return function(){var n=this,e=arguments;return new Promise((function(a,u){var r=t.apply(n,e);function i(t){o(r,a,u,i,c,"next",t)}function c(t){o(r,a,u,i,c,"throw",t)}i(void 0)}))}}var f=t.database(),d={data:function(){return{id:!1,content:""}},onLoad:function(t){t.id&&(this.id=t.id),this.loadData()},methods:{loadData:function(){var t=this;return c(u.default.mark((function n(){return u.default.wrap((function(n){while(1)switch(n.prev=n.next){case 0:f.collection("opendb-news-articles").doc(t.id).field("title,content").get({getOne:!0}).then((function(n){var e=n.result;a.setNavigationBarTitle({title:e.data.title}),t.content=(0,r.default)(e.data.content)}));case 1:case"end":return n.stop()}}),n)})))()}}};n.default=d}).call(this,e("a9ff")["default"],e("543d")["default"])},9390:function(t,n,e){"use strict";e.r(n);var a=e("490f"),u=e.n(a);for(var r in a)"default"!==r&&function(t){e.d(n,t,(function(){return a[t]}))}(r);n["default"]=u.a},edd5:function(t,n,e){"use strict";var a;e.d(n,"b",(function(){return u})),e.d(n,"c",(function(){return r})),e.d(n,"a",(function(){return a}));var u=function(){var t=this,n=t.$createElement;t._self._c},r=[]},eef3:function(t,n,e){}},[["3665","common/runtime","common/vendor"]]]);