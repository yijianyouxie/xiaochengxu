(global["webpackJsonp"]=global["webpackJsonp"]||[]).push([["pages/address/edit"],{"8d46":function(e,t,n){"use strict";n.r(t);var r=n("ae99"),o=n("ed60");for(var a in o)"default"!==a&&function(e){n.d(t,e,(function(){return o[e]}))}(a);n("cb8f");var i,c=n("f0c5"),u=Object(c["a"])(o["default"],r["b"],r["c"],!1,null,null,null,!1,r["a"],i);t["default"]=u.exports},"9d85":function(e,t,n){"use strict";(function(e,r){Object.defineProperty(t,"__esModule",{value:!0}),t.default=void 0;var o=n("3912");function a(e,t){return d(e)||s(e,t)||c(e,t)||i()}function i(){throw new TypeError("Invalid attempt to destructure non-iterable instance.\nIn order to be iterable, non-array objects must have a [Symbol.iterator]() method.")}function c(e,t){if(e){if("string"===typeof e)return u(e,t);var n=Object.prototype.toString.call(e).slice(8,-1);return"Object"===n&&e.constructor&&(n=e.constructor.name),"Map"===n||"Set"===n?Array.from(e):"Arguments"===n||/^(?:Ui|I)nt(?:8|16|32)(?:Clamped)?Array$/.test(n)?u(e,t):void 0}}function u(e,t){(null==t||t>e.length)&&(t=e.length);for(var n=0,r=new Array(t);n<t;n++)r[n]=e[n];return r}function s(e,t){if("undefined"!==typeof Symbol&&Symbol.iterator in Object(e)){var n=[],r=!0,o=!1,a=void 0;try{for(var i,c=e[Symbol.iterator]();!(r=(i=c.next()).done);r=!0)if(n.push(i.value),t&&n.length===t)break}catch(u){o=!0,a=u}finally{try{r||null==c["return"]||c["return"]()}finally{if(o)throw a}}return n}}function d(e){if(Array.isArray(e))return e}function f(e,t){var n=Object.keys(e);if(Object.getOwnPropertySymbols){var r=Object.getOwnPropertySymbols(e);t&&(r=r.filter((function(t){return Object.getOwnPropertyDescriptor(e,t).enumerable}))),n.push.apply(n,r)}return n}function l(e){for(var t=1;t<arguments.length;t++){var n=null!=arguments[t]?arguments[t]:{};t%2?f(Object(n),!0).forEach((function(t){m(e,t,n[t])})):Object.getOwnPropertyDescriptors?Object.defineProperties(e,Object.getOwnPropertyDescriptors(n)):f(Object(n)).forEach((function(t){Object.defineProperty(e,t,Object.getOwnPropertyDescriptor(n,t))}))}return e}function m(e,t,n){return t in e?Object.defineProperty(e,t,{value:n,enumerable:!0,configurable:!0,writable:!0}):e[t]=n,e}var h=e.database(),p="uni-id-address";function b(e){var t={};for(var n in o.validator)e.indexOf(n)>-1&&(t[n]=o.validator[n]);return t}var v={data:function(){return{formData:{user_id:"",name:"",alias:"",mobile:"",mobile_area_code:"",province_code:"",city_code:"",area_code:"",address:"",formatted_address:"",zip_code:"",email:"",is_default:!1},formOtherData:{},formOptions:{},rules:l({},b(["user_id","name","alias","mobile","mobile_area_code","province_code","city_code","area_code","address","formatted_address","zip_code","email","is_default"]))}},onLoad:function(e){var t=e.id;this.formDataId=t,this.getDetail(t)},onReady:function(){this.$refs.form.setRules(this.rules)},methods:{submit:function(){var e=this;r.showLoading({mask:!0}),this.$refs.form.submit().then((function(t){e.formOtherData.formatted_address&&(t=Object.assign({},l(l({},e.formOtherData),t))),t.update_date=Date.now(),console.log(t,e.formData),e.submitForm(t)})).catch((function(e){r.hideLoading()}))},changeAddress:function(e){console.log("changeAddress",e);var t=e.detail.value.map((function(e){return e.value})),n=a(t,3),r=n[0],o=n[1];n[2];this.formOtherData={province_code:r,city_code:o,formatted_address:e.detail.value.map((function(e){return e.text})).join("")}},submitForm:function(e){var t=this;h.collection(p).doc(this.formDataId).update(e).then((function(e){r.showToast({icon:"none",title:"修改成功"}),t.getOpenerEventChannel().emit("refreshData"),setTimeout((function(){return r.navigateBack()}),500)})).catch((function(e){r.showModal({content:e.message||"请求服务失败",showCancel:!1})})).finally((function(){r.hideLoading()}))},getDetail:function(e){var t=this;r.showLoading({mask:!0}),h.collection(p).doc(e).field("user_id,name,alias,mobile,mobile_area_code,province_code,city_code,area_code,address,formatted_address,zip_code,email,is_default").get().then((function(e){var n=e.result.data[0];n&&(t.formData=n)})).catch((function(e){r.showModal({content:e.message||"请求服务失败",showCancel:!1})})).finally((function(){r.hideLoading()}))},handleDelete:function(){var e=this;this.confirmAction((function(){h.collection(p).doc(e.formDataId).remove().then((function(t){r.showToast({icon:"none",title:"删除成功"}),e.getOpenerEventChannel().emit("refreshData"),setTimeout((function(){return r.navigateBack()}),500)}))}),"是否确定删除？")}}};t.default=v}).call(this,n("a9ff")["default"],n("543d")["default"])},aaf4:function(e,t,n){},ae99:function(e,t,n){"use strict";n.d(t,"b",(function(){return o})),n.d(t,"c",(function(){return a})),n.d(t,"a",(function(){return r}));var r={uniForms:function(){return Promise.all([n.e("common/vendor"),n.e("uni_modules/uni-forms/components/uni-forms/uni-forms")]).then(n.bind(null,"5354"))},uniFormsItem:function(){return Promise.all([n.e("common/vendor"),n.e("uni_modules/uni-forms/components/uni-forms-item/uni-forms-item")]).then(n.bind(null,"392c"))},uniEasyinput:function(){return n.e("uni_modules/uni-easyinput/components/uni-easyinput/uni-easyinput").then(n.bind(null,"6186"))},uniDataPicker:function(){return Promise.all([n.e("common/vendor"),n.e("uni_modules/uni-data-picker/components/uni-data-picker/uni-data-picker")]).then(n.bind(null,"ca5d"))}},o=function(){var e=this,t=e.$createElement;e._self._c},a=[]},cb8f:function(e,t,n){"use strict";var r=n("aaf4"),o=n.n(r);o.a},cefa:function(e,t,n){"use strict";(function(e){n("7a45");r(n("66fd"));var t=r(n("8d46"));function r(e){return e&&e.__esModule?e:{default:e}}wx.__webpack_require_UNI_MP_PLUGIN__=n,e(t.default)}).call(this,n("543d")["createPage"])},ed60:function(e,t,n){"use strict";n.r(t);var r=n("9d85"),o=n.n(r);for(var a in r)"default"!==a&&function(e){n.d(t,e,(function(){return r[e]}))}(a);t["default"]=o.a}},[["cefa","common/runtime","common/vendor"]]]);