(global["webpackJsonp"]=global["webpackJsonp"]||[]).push([["pages/login/bindmobile"],{"070e":function(e,t,n){},"0943":function(e,t,n){"use strict";(function(e){n("7a45");i(n("66fd"));var t=i(n("6e86"));function i(e){return e&&e.__esModule?e:{default:e}}wx.__webpack_require_UNI_MP_PLUGIN__=n,e(t.default)}).call(this,n("543d")["createPage"])},"14f4":function(e,t,n){"use strict";n.r(t);var i=n("b1e3"),o=n.n(i);for(var s in i)"default"!==s&&function(e){n.d(t,e,(function(){return i[e]}))}(s);t["default"]=o.a},"6e86":function(e,t,n){"use strict";n.r(t);var i=n("a1ae"),o=n("14f4");for(var s in o)"default"!==s&&function(e){n.d(t,e,(function(){return o[e]}))}(s);n("7c3c");var r,a=n("f0c5"),u=Object(a["a"])(o["default"],i["b"],i["c"],!1,null,null,null,!1,i["a"],r);t["default"]=u.exports},"7c3c":function(e,t,n){"use strict";var i=n("070e"),o=n.n(i);o.a},a1ae:function(e,t,n){"use strict";var i;n.d(t,"b",(function(){return o})),n.d(t,"c",(function(){return s})),n.d(t,"a",(function(){return i}));var o=function(){var e=this,t=e.$createElement;e._self._c},s=[]},b1e3:function(e,t,n){"use strict";(function(e){function n(e,t){var n=Object.keys(e);if(Object.getOwnPropertySymbols){var i=Object.getOwnPropertySymbols(e);t&&(i=i.filter((function(t){return Object.getOwnPropertyDescriptor(e,t).enumerable}))),n.push.apply(n,i)}return n}function i(e){for(var t=1;t<arguments.length;t++){var i=null!=arguments[t]?arguments[t]:{};t%2?n(Object(i),!0).forEach((function(t){o(e,t,i[t])})):Object.getOwnPropertyDescriptors?Object.defineProperties(e,Object.getOwnPropertyDescriptors(i)):n(Object(i)).forEach((function(t){Object.defineProperty(e,t,Object.getOwnPropertyDescriptor(i,t))}))}return e}function o(e,t,n){return t in e?Object.defineProperty(e,t,{value:n,enumerable:!0,configurable:!0,writable:!0}):e[t]=n,e}Object.defineProperty(t,"__esModule",{value:!0}),t.default=void 0;var s={data:function(){return{formData:{mobile:"",code:""},codeDuration:0,codeInterVal:null,read:!0,providerList:[]}},onLoad:function(){e.hideLoading(),console.log("this.inviteCode",this.inviteCode,this.$store.state.user.openid)},computed:{appConfig:function(){return this.$config.app},inviteCode:function(){return this.$store.state.user.inviteCode}},methods:{changeRead:function(e){this.read=e.detail.value.length>0},sendSmsCode:function(){var t=this;this.codeDuration?this.$message("请在".concat(this.codeDuration,"秒后重试")):/^1\d{10}$/.test(this.formData.mobile)?(e.showLoading({title:"请等待"}),this.$request("user/login/sendSms",{mobile:this.formData.mobile}).then((function(e){t.codeDuration=60,t.codeInterVal=setInterval((function(){t.codeDuration--,0===t.codeDuration&&t.codeInterVal&&(clearInterval(t.codeInterVal),t.codeInterVal=null)}),1e3),t.$success("验证码发送成功")}),(function(e){t.$message("验证码发送失败")}))):this.$message("手机号码填写错误")},login:function(){var t=this;if(this.isSubmit)return!1;/^1\d{10}$/.test(this.formData.mobile)?/^\d{6}$/.test(this.formData.code)?(this.isSubmit=!0,e.showLoading({title:"请等待"}),this.$request("user/info/bind_mobile",{inviteCode:this.inviteCode,channelCode:this.$store.state.user.channelCode,mobile:this.formData.mobile,code:this.formData.code,uid:this.$store.state.user.userInfo._id,openid:this.$store.state.user.openid}).then((function(e){t.loginSuccess(e)}),(function(e){t.isSubmit=!1,t.$message("绑定失败")}))):this.$message("验证码填写错误"):this.$message("手机号码填写错误")},loginSuccess:function(e){this.$success("绑定成功"),this.$store.dispatch("mall/getCartTotal"),this.$store.dispatch("user/getUserInfo"),this.navTimeBack()},getPhoneNumber:function(e){var t=this;console.log("getPhoneNumber",e),e.detail.iv&&this.$request("user/login/weixin_phone",i(i({},e.detail),{},{sessionKey:this.$store.state.user.sessionKey,uid:this.$store.state.user.userInfo._id,openid:this.$store.state.user.openid}),{loading:!0}).then((function(e){console.log("getPhoneNumber",e),t.loginSuccess(e)}))}}};t.default=s}).call(this,n("543d")["default"])}},[["0943","common/runtime","common/vendor"]]]);