(global["webpackJsonp"]=global["webpackJsonp"]||[]).push([["pages/user/channel"],{"4d2b":function(t,e,n){"use strict";(function(t,o){Object.defineProperty(e,"__esModule",{value:!0}),e.default=void 0;var a=n("ab2b"),i=r(n("cbd5"));function r(t){return t&&t.__esModule?t:{default:t}}function u(t,e){var n=Object.keys(t);if(Object.getOwnPropertySymbols){var o=Object.getOwnPropertySymbols(t);e&&(o=o.filter((function(e){return Object.getOwnPropertyDescriptor(t,e).enumerable}))),n.push.apply(n,o)}return n}function s(t){for(var e=1;e<arguments.length;e++){var n=null!=arguments[e]?arguments[e]:{};e%2?u(Object(n),!0).forEach((function(e){d(t,e,n[e])})):Object.getOwnPropertyDescriptors?Object.defineProperties(t,Object.getOwnPropertyDescriptors(n)):u(Object(n)).forEach((function(e){Object.defineProperty(t,e,Object.getOwnPropertyDescriptor(n,e))}))}return t}function d(t,e,n){return e in t?Object.defineProperty(t,e,{value:n,enumerable:!0,configurable:!0,writable:!0}):t[e]=n,t}var c=t.database(),l="uni-id-channel";function f(t){var e={};for(var n in a.validator)t.indexOf(n)>-1&&(e[n]=a.validator[n]);return e}var m={mixins:[i.default],data:function(){return{type:"2",loaded:!1,qrcode:"",formDataId:"",address:{},formData:{status:0,title:"",mobile:null},dayTotal:[],formOptions:{},rules:s({},f(["title","mobile","status"]))}},onLoad:function(t){t.type&&(this.type=t.type),this.loadData()},onReady:function(){this.$refs.form&&this.$refs.form.setRules(this.rules)},watch:{userInfo:function(){this.loadData()}},computed:{isEdit:function(){return 0==this.formData.status||3==this.formData.status},userInfo:function(){return this.$store.state.user.userInfo}},methods:{chooseAddress:function(){var t=this;o.chooseLocation({success:function(e){t.address={name:e.name,address:e.address,longitude:e.longitude,latitude:e.latitude}}})},submit:function(){var t=this;o.showLoading({mask:!0}),this.$refs.form.submit().then((function(e){t.address.name?(e.status=1,e.address=t.address,e.modified=Date.now(),t.submitForm(e)):t.$message("请选择地址")})).catch((function(t){o.hideLoading()}))},submitForm:function(t){var e=this;this.formDataId?c.action("channel_apply").collection(l).doc(this.formDataId).update(t).then((function(t){o.showToast({icon:"none",title:"修改成功"})})).catch((function(t){o.showModal({content:t.message||"请求服务失败",showCancel:!1})})).finally((function(){o.hideLoading(),e.loadData()})):c.action("genStringId,channel_apply").collection(l).add(t).then((function(t){o.showToast({icon:"none",title:"申请成功"})})).catch((function(t){o.showModal({content:t.message||"请求服务失败",showCancel:!1})})).finally((function(){o.hideLoading(),e.loadData()}))},loadData:function(){var t=this;console.log("this.userInfo",this.userInfo),this.userInfo._id&&c.collection(l).where("user_id==$cloudEnv_uid").get({getOne:!0}).then((function(e){var n=e.result;if(n.data){if(t.address=n.data.address,t.formDataId=n.data._id,delete n.data._id,2==n.data.status){if(n.data.total=n.data.total?n.data.total:0,n.data.day_total){var o=[];for(var a in n.data.day_total)o.push({time:a,day:t.$dateFormat("Y-m-d",a),total:n.data.day_total[a]});o.sort((function(t,e){return e.time-t.time})),t.dayTotal=o,console.log("this.dayTotal",t.dayTotal)}t.setGlobalShareContent(),console.log("this.share",t.share),setTimeout((function(){t.$refs.uqrcode.make({size:355,text:t.share.href})}),1e3)}t.formData=n.data}t.loaded=!0,console.log("result",n)}))},goHome:function(){o.switchTab({url:"/pages/index/index"})}}};e.default=m}).call(this,n("a9ff")["default"],n("543d")["default"])},"508c":function(t,e,n){},"7b13":function(t,e,n){"use strict";var o=n("508c"),a=n.n(o);a.a},a104:function(t,e,n){"use strict";n.r(e);var o=n("4d2b"),a=n.n(o);for(var i in o)"default"!==i&&function(t){n.d(e,t,(function(){return o[t]}))}(i);e["default"]=a.a},b0e0:function(t,e,n){"use strict";n.r(e);var o=n("d1a2"),a=n("a104");for(var i in a)"default"!==i&&function(t){n.d(e,t,(function(){return a[t]}))}(i);n("7b13");var r,u=n("f0c5"),s=Object(u["a"])(a["default"],o["b"],o["c"],!1,null,null,null,!1,o["a"],r);e["default"]=s.exports},bc43:function(t,e,n){"use strict";(function(t){n("7a45");o(n("66fd"));var e=o(n("b0e0"));function o(t){return t&&t.__esModule?t:{default:t}}wx.__webpack_require_UNI_MP_PLUGIN__=n,t(e.default)}).call(this,n("543d")["createPage"])},d1a2:function(t,e,n){"use strict";n.d(e,"b",(function(){return a})),n.d(e,"c",(function(){return i})),n.d(e,"a",(function(){return o}));var o={uniLoadMore:function(){return Promise.all([n.e("common/vendor"),n.e("uni_modules/uni-load-more/components/uni-load-more/uni-load-more")]).then(n.bind(null,"86a6"))},uqrcode:function(){return Promise.all([n.e("common/vendor"),n.e("uni_modules/Sansnn-uQRCode/components/uqrcode/uqrcode")]).then(n.bind(null,"553d9"))},uniForms:function(){return Promise.all([n.e("common/vendor"),n.e("uni_modules/uni-forms/components/uni-forms/uni-forms")]).then(n.bind(null,"5354"))},uniFormsItem:function(){return Promise.all([n.e("common/vendor"),n.e("uni_modules/uni-forms/components/uni-forms-item/uni-forms-item")]).then(n.bind(null,"392c"))},uniEasyinput:function(){return n.e("uni_modules/uni-easyinput/components/uni-easyinput/uni-easyinput").then(n.bind(null,"6186"))}},a=function(){var t=this,e=t.$createElement;t._self._c},i=[]}},[["bc43","common/runtime","common/vendor"]]]);