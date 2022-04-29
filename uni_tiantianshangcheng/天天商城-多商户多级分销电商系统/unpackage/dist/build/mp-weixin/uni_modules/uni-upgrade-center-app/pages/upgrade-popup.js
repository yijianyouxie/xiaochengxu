(global["webpackJsonp"]=global["webpackJsonp"]||[]).push([["uni_modules/uni-upgrade-center-app/pages/upgrade-popup"],{5670:function(e,t,n){"use strict";(function(e){Object.defineProperty(t,"__esModule",{value:!0}),t.default=void 0;var r=a(n("a34a"));function a(e){return e&&e.__esModule?e:{default:e}}function o(e,t){return s(e)||l(e,t)||u(e,t)||i()}function i(){throw new TypeError("Invalid attempt to destructure non-iterable instance.\nIn order to be iterable, non-array objects must have a [Symbol.iterator]() method.")}function u(e,t){if(e){if("string"===typeof e)return c(e,t);var n=Object.prototype.toString.call(e).slice(8,-1);return"Object"===n&&e.constructor&&(n=e.constructor.name),"Map"===n||"Set"===n?Array.from(e):"Arguments"===n||/^(?:Ui|I)nt(?:8|16|32)(?:Clamped)?Array$/.test(n)?c(e,t):void 0}}function c(e,t){(null==t||t>e.length)&&(t=e.length);for(var n=0,r=new Array(t);n<t;n++)r[n]=e[n];return r}function l(e,t){if("undefined"!==typeof Symbol&&Symbol.iterator in Object(e)){var n=[],r=!0,a=!1,o=void 0;try{for(var i,u=e[Symbol.iterator]();!(r=(i=u.next()).done);r=!0)if(n.push(i.value),t&&n.length===t)break}catch(c){a=!0,o=c}finally{try{r||null==u["return"]||u["return"]()}finally{if(a)throw o}}return n}}function s(e){if(Array.isArray(e))return e}function d(e,t,n,r,a,o,i){try{var u=e[o](i),c=u.value}catch(l){return void n(l)}u.done?t(c):Promise.resolve(c).then(r,a)}function f(e){return function(){var t=this,n=arguments;return new Promise((function(r,a){var o=e.apply(t,n);function i(e){d(o,r,a,i,u,"next",e)}function u(e){d(o,r,a,i,u,"throw",e)}i(void 0)}))}}var v="__localFilePath__",h="iOS",p=null;function g(){var e=arguments.length>0&&void 0!==arguments[0]?arguments[0]:"0",t=arguments.length>1&&void 0!==arguments[1]?arguments[1]:"0";e=String(e).split("."),t=String(t).split(".");for(var n=Math.min(e.length,t.length),r=0,a=0;a<n;a++){var o=Number(e[a]),i=Number(t[a]);if(o>i){r=1;break}if(o<i){r=-1;break}}if(0===r&&e.length!==t.length)for(var u=e.length>t.length,c=u?e:t,l=n;l<c.length;l++){var s=Number(c[l]);if(s>0){r=u?1:-1;break}}return r}var m={data:function(){return{installForBeforeFilePath:"",installed:!1,installing:!1,downloadSuccess:!1,downloading:!1,downLoadPercent:0,downloadedSize:0,packageFileSize:0,tempFilePath:"",title:"更新日志",contents:"",is_mandatory:!1,subTitle:"发现新版本",downLoadBtnTextiOS:"立即跳转更新",downLoadBtnText:"立即下载更新",downLoadingText:"安装包下载中，请稍后"}},onLoad:function(t){var n=t.local_storage_key;if(!n)return console.error("local_storage_key为空，请检查后重试"),void e.navigateBack();var r=e.getStorageSync(n);if(!r)return console.error("安装包信息为空，请检查后重试"),void e.navigateBack();var a=["version","url","type"];for(var o in r)if(-1!==a.indexOf(o)&&!r[o])return console.error("参数 ".concat(o," 必填，请检查后重试")),void e.navigateBack();Object.assign(this,r),this.checkLocalStoragePackage()},onBackPress:function(){if(this.is_mandatory)return!0;p&&p.abort()},computed:{isWGT:function(){return"wgt"===this.type},isiOS:function(){return!this.isWGT&&this.platform.includes(h)}},methods:{checkLocalStoragePackage:function(){var t=e.getStorageSync(v);if(t){var n=t.version,r=t.savedFilePath,a=t.installed;a||0!==g(n,this.version)?this.deleteSavedFile(r):(this.downloadSuccess=!0,this.installForBeforeFilePath=r,this.tempFilePath=r)}},closeUpdate:function(){var t=this;return f(r.default.mark((function n(){return r.default.wrap((function(n){while(1)switch(n.prev=n.next){case 0:if(!t.downloading){n.next=5;break}if(!t.is_mandatory){n.next=3;break}return n.abrupt("return",e.showToast({title:"下载中，请稍后……",icon:"none",duration:500}));case 3:return e.showModal({title:"是否取消下载？",cancelText:"否",confirmText:"是",success:function(t){t.confirm&&(p&&p.abort(),e.navigateBack())}}),n.abrupt("return");case 5:if(!t.downloadSuccess||!t.tempFilePath){n.next=10;break}return n.next=8,t.saveFile(t.tempFilePath,t.version);case 8:return e.navigateBack(),n.abrupt("return");case 10:e.navigateBack();case 11:case"end":return n.stop()}}),n)})))()},downloadPackage:function(){var t=this;this.downloading=!0,p=e.downloadFile({url:this.url,success:function(e){200==e.statusCode&&(t.downloadSuccess=!0,t.tempFilePath=e.tempFilePath,t.is_mandatory&&t.installPackage())},complete:function(){t.downloading=!1,t.downLoadPercent=0,t.downloadedSize=0,t.packageFileSize=0,p=null}}),p.onProgressUpdate((function(e){t.downLoadPercent=e.progress,t.downloadedSize=(e.totalBytesWritten/Math.pow(1024,2)).toFixed(2),t.packageFileSize=(e.totalBytesExpectedToWrite/Math.pow(1024,2)).toFixed(2)}))},installPackage:function(){},restart:function(){this.installed=!1},saveFile:function(t,n){return f(r.default.mark((function a(){var i,u,c,l;return r.default.wrap((function(r){while(1)switch(r.prev=r.next){case 0:return r.next=2,e.saveFile({tempFilePath:t});case 2:if(i=r.sent,u=o(i,2),c=u[0],l=u[1],!c){r.next=8;break}return r.abrupt("return");case 8:e.setStorageSync(v,{version:n,savedFilePath:l.savedFilePath});case 9:case"end":return r.stop()}}),a)})))()},deleteSavedFile:function(t){return e.removeStorageSync(v),e.removeSavedFile({filePath:t})},jumpToAppStore:function(){plus.runtime.openURL(this.url)}}};t.default=m}).call(this,n("543d")["default"])},"576c":function(e,t,n){"use strict";n.r(t);var r=n("797d"),a=n("7465");for(var o in a)"default"!==o&&function(e){n.d(t,e,(function(){return a[e]}))}(o);n("77c4");var i,u=n("f0c5"),c=Object(u["a"])(a["default"],r["b"],r["c"],!1,null,null,null,!1,r["a"],i);t["default"]=c.exports},"690b":function(e,t,n){},7465:function(e,t,n){"use strict";n.r(t);var r=n("5670"),a=n.n(r);for(var o in r)"default"!==o&&function(e){n.d(t,e,(function(){return r[e]}))}(o);t["default"]=a.a},"77c4":function(e,t,n){"use strict";var r=n("690b"),a=n.n(r);a.a},"797d":function(e,t,n){"use strict";var r;n.d(t,"b",(function(){return a})),n.d(t,"c",(function(){return o})),n.d(t,"a",(function(){return r}));var a=function(){var e=this,t=e.$createElement;e._self._c},o=[]},db5c:function(e,t,n){"use strict";(function(e){n("7a45");r(n("66fd"));var t=r(n("576c"));function r(e){return e&&e.__esModule?e:{default:e}}wx.__webpack_require_UNI_MP_PLUGIN__=n,e(t.default)}).call(this,n("543d")["createPage"])}},[["db5c","common/runtime","common/vendor"]]]);