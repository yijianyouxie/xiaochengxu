(global["webpackJsonp"]=global["webpackJsonp"]||[]).push([["common/main"],{"2ea0":function(e,t,n){"use strict";n.r(t);var o=n("90e1"),r=n.n(o);for(var i in o)"default"!==i&&function(e){n.d(t,e,(function(){return o[e]}))}(i);t["default"]=r.a},"3bf1":function(e,t,n){"use strict";var o=n("b730"),r=n.n(o);r.a},"8c40":function(e,t,n){"use strict";n.r(t);var o=n("2ea0");for(var r in o)"default"!==r&&function(e){n.d(t,e,(function(){return o[e]}))}(r);n("3bf1");var i,u,c,a,s=n("f0c5"),f=Object(s["a"])(o["default"],i,u,!1,null,null,null,!1,c,a);t["default"]=f.exports},"90e1":function(e,t,n){"use strict";(function(e){Object.defineProperty(t,"__esModule",{value:!0}),t.default=void 0;var o=c(n("a34a")),r=n("26cb"),i=c(n("66fd")),u=n("adf2");function c(e){return e&&e.__esModule?e:{default:e}}function a(e,t,n,o,r,i,u){try{var c=e[i](u),a=c.value}catch(s){return void n(s)}c.done?t(a):Promise.resolve(a).then(o,r)}function s(e){return function(){var t=this,n=arguments;return new Promise((function(o,r){var i=e.apply(t,n);function u(e){a(i,o,r,u,c,"next",e)}function c(e){a(i,o,r,u,c,"throw",e)}u(void 0)}))}}function f(e,t){var n=Object.keys(e);if(Object.getOwnPropertySymbols){var o=Object.getOwnPropertySymbols(e);t&&(o=o.filter((function(t){return Object.getOwnPropertyDescriptor(e,t).enumerable}))),n.push.apply(n,o)}return n}function l(e){for(var t=1;t<arguments.length;t++){var n=null!=arguments[t]?arguments[t]:{};t%2?f(Object(n),!0).forEach((function(t){p(e,t,n[t])})):Object.getOwnPropertyDescriptors?Object.defineProperties(e,Object.getOwnPropertyDescriptors(n)):f(Object(n)).forEach((function(t){Object.defineProperty(e,t,Object.getOwnPropertyDescriptor(n,t))}))}return e}function p(e,t,n){return t in e?Object.defineProperty(e,t,{value:n,enumerable:!0,configurable:!0,writable:!0}):e[t]=n,e}var d="",v="",g={onLaunch:function(t){var n=this;if(console.log("App Launch",t),t.query||(t.query={}),t.query.q){var o=decodeURIComponent(t.query.q);Object.assign(t.query,l({},(0,u.getQueryString)(o))),delete t.query.q,console.log("options.query",t.query)}t.query.channel&&(v=t.query.channel,console.log("渠道",v),this.setChannelCode(t.query.channel)),t.query.u?(d=t.query.u,console.log("invite",d),this.setInviteCode(t.query.u)):this.getInviteFromClipboard(),this.setDefaultInfo({}),this.autoLogin(t.query),this.initSize(e.getSystemInfoSync()),e.onNetworkStatusChange((function(e){e.isConnected&&(console.log("isConnected"),n.autoLogin(t.query))}))},onShow:function(){console.log("App Show")},onHide:function(){console.log("App Hide")},computed:{},methods:l(l(l({},(0,r.mapMutations)({setInviteCode:function(e,t){e("user/SET_INVITECODE",t)},setChannelCode:function(e,t){e("user/SET_CHANNELCODE",t)},setDefaultInfo:function(e,t){e("user/SET_USER_INFO",t)},setPushClient:function(e,t){e("user/UPDATE_PUSH_CLIENT",t)},setUniverifyInit:function(e){e("user/UNIVERIFY_INIT")}})),(0,r.mapActions)({initApp:"app/init",mpLogin:"user/mpLogin"})),{},{autoLogin:function(e){var t=this;return s(o.default.mark((function n(){return o.default.wrap((function(n){while(1)switch(n.prev=n.next){case 0:t.$store.getters["user/isInitTokenValid"]||console.log("获取APP信息，需要用户详细信息"),t.micLogin(),t.initApp(l({},e));case 3:case"end":return n.stop()}}),n)})))()},getInviteFromClipboard:function(){return s(o.default.mark((function e(){return o.default.wrap((function(e){while(1)switch(e.prev=e.next){case 0:case"end":return e.stop()}}),e)})))()},micLogin:function(t){var n=this;return s(o.default.mark((function t(){return o.default.wrap((function(t){while(1)switch(t.prev=t.next){case 0:console.log("小程序用户自动登录开始"),e.getProvider({service:"oauth",success:function(t){console.log(t);var o=t.provider[0];e.login({provider:o,success:function(e){console.log("授权code",e),n.mpLogin({provider:o,channelCode:v,inviteCode:d,code:e.code}),console.log("小程序用户自动登录结束")}})}});case 2:case"end":return t.stop()}}),t)})))()},initUniverify:function(e){var t=this;return s(o.default.mark((function e(){return o.default.wrap((function(e){while(1)switch(e.prev=e.next){case 0:t;case 1:case"end":return e.stop()}}),e)})))()},checkPush:function(){},initSize:function(e){var t,n=e,o={};o=wx.getMenuButtonBoundingClientRect(),t=o.bottom+o.top-2*e.statusBarHeight,n.custom=o,n.navigationBarHeight=t,n.development=!1,console.log(n),i.default.prototype.systemInfo=n}})};t.default=g}).call(this,n("543d")["default"])},"91a8":function(e,t,n){"use strict";(function(e){n("566f");var t=c(n("66fd")),o=c(n("8c40")),r=c(n("f9f2")),i=c(n("68e5")),u=c(n("9589"));c(n("8bee"));function c(e){return e&&e.__esModule?e:{default:e}}function a(e,t){var n=Object.keys(e);if(Object.getOwnPropertySymbols){var o=Object.getOwnPropertySymbols(e);t&&(o=o.filter((function(t){return Object.getOwnPropertyDescriptor(e,t).enumerable}))),n.push.apply(n,o)}return n}function s(e){for(var t=1;t<arguments.length;t++){var n=null!=arguments[t]?arguments[t]:{};t%2?a(Object(n),!0).forEach((function(t){f(e,t,n[t])})):Object.getOwnPropertyDescriptors?Object.defineProperties(e,Object.getOwnPropertyDescriptors(n)):a(Object(n)).forEach((function(t){Object.defineProperty(e,t,Object.getOwnPropertyDescriptor(n,t))}))}return e}function f(e,t,n){return t in e?Object.defineProperty(e,t,{value:n,enumerable:!0,configurable:!0,writable:!0}):e[t]=n,e}wx.__webpack_require_UNI_MP_PLUGIN__=n,t.default.config.productionTip=!1,t.default.use(i.default),t.default.mixin(u.default),o.default.mpType="app";var l=new t.default(s({store:r.default},o.default));e(l).$mount()}).call(this,n("543d")["createApp"])},b730:function(e,t,n){}},[["91a8","common/runtime","common/vendor"]]]);