(global["webpackJsonp"]=global["webpackJsonp"]||[]).push([["pages/app/pages"],{"134e":function(e,t,n){"use strict";(function(e){function n(e,t){var n=Object.keys(e);if(Object.getOwnPropertySymbols){var r=Object.getOwnPropertySymbols(e);t&&(r=r.filter((function(t){return Object.getOwnPropertyDescriptor(e,t).enumerable}))),n.push.apply(n,r)}return n}function r(e){for(var t=1;t<arguments.length;t++){var r=null!=arguments[t]?arguments[t]:{};t%2?n(Object(r),!0).forEach((function(t){o(e,t,r[t])})):Object.getOwnPropertyDescriptors?Object.defineProperties(e,Object.getOwnPropertyDescriptors(r)):n(Object(r)).forEach((function(t){Object.defineProperty(e,t,Object.getOwnPropertyDescriptor(r,t))}))}return e}function o(e,t,n){return t in e?Object.defineProperty(e,t,{value:n,enumerable:!0,configurable:!0,writable:!0}):e[t]=n,e}Object.defineProperty(t,"__esModule",{value:!0}),t.default=void 0;var c={data:function(){return{type:"",loadmore:0,refresh:0,configs:{}}},onLoad:function(e){this.type=e.type,this.configs=r(r({},e),{},{parent_id:e.id}),e.title&&(this.barTitle=e.title)},onPullDownRefresh:function(){console.log("刷新整页"),e.stopPullDownRefresh(),this.refresh=Date.now()},onReachBottom:function(){console.log("加载下一页"),this.loadmore=Date.now()}};t.default=c}).call(this,n("543d")["default"])},"1ea1":function(e,t,n){"use strict";(function(e){n("566f");r(n("66fd"));var t=r(n("21c2"));function r(e){return e&&e.__esModule?e:{default:e}}wx.__webpack_require_UNI_MP_PLUGIN__=n,e(t.default)}).call(this,n("543d")["createPage"])},"21c2":function(e,t,n){"use strict";n.r(t);var r=n("c146"),o=n("c022");for(var c in o)"default"!==c&&function(e){n.d(t,e,(function(){return o[e]}))}(c);var a,i=n("f0c5"),u=Object(i["a"])(o["default"],r["b"],r["c"],!1,null,null,null,!1,r["a"],a);t["default"]=u.exports},c022:function(e,t,n){"use strict";n.r(t);var r=n("134e"),o=n.n(r);for(var c in r)"default"!==c&&function(e){n.d(t,e,(function(){return r[e]}))}(c);t["default"]=o.a},c146:function(e,t,n){"use strict";n.d(t,"b",(function(){return o})),n.d(t,"c",(function(){return c})),n.d(t,"a",(function(){return r}));var r={tianTabPages:function(){return Promise.all([n.e("common/vendor"),n.e("uni_modules/tian-mall/components/tian-tab-pages/tian-tab-pages")]).then(n.bind(null,"c9eb"))},tianPages:function(){return Promise.all([n.e("common/vendor"),n.e("uni_modules/tian-mall/components/tian-pages/tian-pages")]).then(n.bind(null,"e453"))}},o=function(){var e=this,t=e.$createElement;e._self._c},c=[]}},[["1ea1","common/runtime","common/vendor"]]]);