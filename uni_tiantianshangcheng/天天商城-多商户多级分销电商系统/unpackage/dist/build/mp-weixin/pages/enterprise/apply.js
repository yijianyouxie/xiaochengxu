(global["webpackJsonp"]=global["webpackJsonp"]||[]).push([["pages/enterprise/apply"],{"2eec":function(e,n,t){"use strict";t.r(n);var o=t("5da2"),i=t.n(o);for(var s in o)"default"!==s&&function(e){t.d(n,e,(function(){return o[e]}))}(s);n["default"]=i.a},"5da2":function(e,n,t){"use strict";(function(e,o){Object.defineProperty(n,"__esModule",{value:!0}),n.default=void 0;var i=t("9595");function s(e,n){var t=Object.keys(e);if(Object.getOwnPropertySymbols){var o=Object.getOwnPropertySymbols(e);n&&(o=o.filter((function(n){return Object.getOwnPropertyDescriptor(e,n).enumerable}))),t.push.apply(t,o)}return t}function a(e){for(var n=1;n<arguments.length;n++){var t=null!=arguments[n]?arguments[n]:{};n%2?s(Object(t),!0).forEach((function(n){r(e,n,t[n])})):Object.getOwnPropertyDescriptors?Object.defineProperties(e,Object.getOwnPropertyDescriptors(t)):s(Object(t)).forEach((function(n){Object.defineProperty(e,n,Object.getOwnPropertyDescriptor(t,n))}))}return e}function r(e,n,t){return n in e?Object.defineProperty(e,n,{value:t,enumerable:!0,configurable:!0,writable:!0}):e[n]=t,e}var u=e.database(),c="tian-mall-shop-apply";function l(e){var n={};for(var t in i.validator)e.indexOf(t)>-1&&(n[t]=i.validator[t]);return n}var d={data:function(){return{id:!1,address:{},formData:{id:null,address:null,name:"",phone:"",src:"",state:-1,business_license:"",food_license:"",legal_person_license:"",legal_person_license_back:"",modified:null},formOptions:{},rules:a({},l(["id","address","name","phone","src","business_license","food_license","legal_person_license","legal_person_license_back","modified"]))}},onLoad:function(e){e&&e.id&&(this.id=e.id,this.setFormData(this.getItemData()),this.loadData())},computed:{isDisable:function(){return this.id&&0==this.formData.state}},onReady:function(){this.$refs.form.setRules(this.rules)},methods:{setFormData:function(e){this.address=e.address,delete e.address,this.formData=e},loadData:function(){var e=this;u.collection(c).doc(this.id).get({getOne:!0}).then((function(n){var t=n.result;e.setFormData(t.data)}))},chooseLocation:function(){var e=this;this.isDisable||o.chooseLocation({success:function(n){console.log(n),e.address={name:n.name,address:n.address,latitude:n.latitude,longitude:n.longitude}}})},submit:function(){var e=this;this.address.name?(o.showLoading({mask:!0}),this.$refs.form.submit().then((function(n){n.address=e.address,e.id?e.editForm(n):e.submitForm(n)})).catch((function(e){o.hideLoading()}))):this.$message("店铺地址必填")},editForm:function(e){delete e._id,u.action("shop_apply").collection(c).doc(this.id).update(e).then((function(e){o.showToast({icon:"success",title:"重新申请成功"}),setTimeout((function(){return o.navigateBack()}),1500)})).catch((function(e){o.showModal({content:e.message||"请求服务失败",showCancel:!1})})).finally((function(){o.hideLoading()}))},submitForm:function(e){u.action("genId,shop_apply").collection(c).add(e).then((function(e){o.showToast({icon:"success",title:"申请成功"}),setTimeout((function(){return o.navigateBack()}),1500)})).catch((function(e){o.showModal({content:e.message||"请求服务失败",showCancel:!1})})).finally((function(){o.hideLoading()}))}}};n.default=d}).call(this,t("a9ff")["default"],t("543d")["default"])},8655:function(e,n,t){"use strict";(function(e){t("7a45");o(t("66fd"));var n=o(t("e1b9"));function o(e){return e&&e.__esModule?e:{default:e}}wx.__webpack_require_UNI_MP_PLUGIN__=t,e(n.default)}).call(this,t("543d")["createPage"])},afbe:function(e,n,t){"use strict";var o=t("d0a1"),i=t.n(o);i.a},d0a1:function(e,n,t){},d753:function(e,n,t){"use strict";t.d(n,"b",(function(){return i})),t.d(n,"c",(function(){return s})),t.d(n,"a",(function(){return o}));var o={uniForms:function(){return Promise.all([t.e("common/vendor"),t.e("uni_modules/uni-forms/components/uni-forms/uni-forms")]).then(t.bind(null,"5354"))},uniFormsItem:function(){return Promise.all([t.e("common/vendor"),t.e("uni_modules/uni-forms/components/uni-forms-item/uni-forms-item")]).then(t.bind(null,"392c"))},uniEasyinput:function(){return t.e("uni_modules/uni-easyinput/components/uni-easyinput/uni-easyinput").then(t.bind(null,"6186"))},tianIcons:function(){return t.e("uni_modules/tian-mall/components/tian-icons/tian-icons").then(t.bind(null,"553d"))},cloudImage:function(){return Promise.all([t.e("common/vendor"),t.e("uni_modules/cloud-image/components/cloud-image/cloud-image")]).then(t.bind(null,"cd68"))}},i=function(){var e=this,n=e.$createElement;e._self._c},s=[]},e1b9:function(e,n,t){"use strict";t.r(n);var o=t("d753"),i=t("2eec");for(var s in i)"default"!==s&&function(e){t.d(n,e,(function(){return i[e]}))}(s);t("afbe");var a,r=t("f0c5"),u=Object(r["a"])(i["default"],o["b"],o["c"],!1,null,null,null,!1,o["a"],a);n["default"]=u.exports}},[["8655","common/runtime","common/vendor"]]]);