(global["webpackJsonp"]=global["webpackJsonp"]||[]).push([["pages/search/search"],{"21a6":function(t,e,n){"use strict";var a=n("a48d"),i=n.n(a);i.a},9279:function(t,e,n){"use strict";(function(t,n){function a(t,e,n){return e in t?Object.defineProperty(t,e,{value:n,enumerable:!0,configurable:!0,writable:!0}):t[e]=n,t}Object.defineProperty(e,"__esModule",{value:!0}),e.default=void 0;var i="opendb-search-log",o="opendb-mall-goods",c="name",s="name,content,goods_desc,goods_sn",r="__local_search_history",l=function(t){for(var e=t.length-1;e>=0;e--){var n=t.indexOf(t[e]),a=t.lastIndexOf(t[e]);n!=a&&t.splice(a,1)}return t};function u(t,e,n){var a=t,i=null,o=!0;return n&&a(),function(){var t=arguments,n=this;o&&(o=!1,a.apply(n,t)),i&&clearTimeout(i),i=setTimeout((function(){clearTimeout(i),i=null,a.apply(n,t)}),e||200)}}var h={data:function(){return{mallGoodsDbName:o,searchLogDbName:i,hasText:0,localSearchList:t.getStorageSync(r),localSearchListDel:!1,netHotListIsHide:!1,searchText:"",iconColor:"#999999",associativeList:[],keyBoardPopup:!1,hotWorld:"apple",focus:!0,speechEngine:"iFly"}},onLoad:function(t){this.hasText=t.text,t.text&&(this.searchText=getApp().globalData.searchText)},created:function(){var e=this;this.db=n.database(),this.searchLogDb=this.db.collection(this.searchLogDbName),this.mallGoodsDb=this.db.collection(this.mallGoodsDbName),t.onKeyboardHeightChange((function(t){e.keyBoardPopup=0!==t.height}))},methods:{clear:function(t){console.log("res: ",t)},confirm:function(t){this.search(t.value)},cancel:function(e){t.hideKeyboard(),t.navigateBack({delta:1})},search:function(e){(e||this.hotWorld)&&(e?(this.searchText!==e&&(this.searchText=e),this.localSearchListManage(e),this.searchLogDbAdd(e)):this.hotWorld&&(this.searchText=this.hotWorld),t.hideKeyboard(),this.loadList(this.searchText))},localSearchListManage:function(e){var n=t.getStorageSync(r);n.length?(this.localSearchList.unshift(e),l(this.localSearchList),this.localSearchList.length>10&&this.localSearchList.pop()):this.localSearchList=[e],t.setStorageSync(r,this.localSearchList)},LocalSearchListClear:function(){var e=this;t.showModal({content:"确认清空搜索历史吗？",confirmText:"删除",confirmColor:"red",cancelColor:"#808080",success:function(n){n.confirm&&(e.localSearchListDel=!1,e.localSearchList=[],t.removeStorageSync(r))}})},LocalSearchlistItemClick:function(e,n){if(this.localSearchListDel)return this.localSearchList.splice(n,1),t.setStorageSync(r,this.localSearchList),void(this.localSearchList.length||(this.localSearchListDel=!1));this.search(e)},searchHotRefresh:function(){this.$refs.udb.refresh()},speech:function(){},searchLogDbAdd:function(t){var e=this;this.getDeviceId().then((function(n){e.searchLogDb.add({device_uuid:n,content:t,create_date:Date.now()})}))},getDeviceId:function(){return new Promise((function(e,n){var a=t.getStorageSync("uni_id");e(a||t.getSystemInfoSync().system+"_"+Math.random().toString(36).substr(2))}))},associativeClick:function(t){console.log("associativeClick: ",t),this.loadList(t.name)},loadList:function(){var e=arguments.length>0&&void 0!==arguments[0]?arguments[0]:"";getApp().globalData.searchText=e,e&&!this.hasText?t.redirectTo({url:"/pages/product/list"}):t.navigateBack()}},computed:{associativeShow:function(){return this.searchText&&this.associativeList.length}},watch:{searchText:u((function(t){var e=this;t?this.mallGoodsDb.where(a({},c,new RegExp(t,"gi"))).field(s).limit(15).get().then((function(t){e.associativeList=t.result.data})):this.associativeList.length=0}),100)}};e.default=h}).call(this,n("543d")["default"],n("a9ff")["default"])},a48d:function(t,e,n){},bc00:function(t,e,n){"use strict";n.d(e,"b",(function(){return i})),n.d(e,"c",(function(){return o})),n.d(e,"a",(function(){return a}));var a={uniSearchBar:function(){return Promise.all([n.e("common/vendor"),n.e("uni_modules/uni-search-bar/components/uni-search-bar/uni-search-bar")]).then(n.bind(null,"a7a1"))},uniIcons:function(){return Promise.all([n.e("common/vendor"),n.e("uni_modules/uni-icons/components/uni-icons/uni-icons")]).then(n.bind(null,"b0c4"))},unicloudDb:function(){return Promise.all([n.e("common/vendor"),n.e("node-modules/@dcloudio/uni-cli-shared/components/unicloud-db")]).then(n.bind(null,"960d"))},uniList:function(){return n.e("uni_modules/uni-list/components/uni-list/uni-list").then(n.bind(null,"bcc9"))},uniListItem:function(){return n.e("uni_modules/uni-list/components/uni-list-item/uni-list-item").then(n.bind(null,"a80a"))}},i=function(){var t=this,e=t.$createElement,n=(t._self._c,t.$hasScopedSlotsParams("50cad900-6")),a=n?t.$getScopedSlotsParams("50cad900-6","default","loading")&&!t.netHotListIsHide:null,i=!n||a||t.netHotListIsHide?null:t.$getScopedSlotsParams("50cad900-6","default","error"),o=n&&!a&&!t.netHotListIsHide&&i?t.$getScopedSlotsParams("50cad900-6","default","error"):null,c=!n||a||t.netHotListIsHide||i?null:t.$getScopedSlotsParams("50cad900-6","default","data");t._isMounted||(t.e0=function(e){t.localSearchListDel=!0},t.e1=function(e){t.localSearchListDel=!1},t.e2=function(e){t.netHotListIsHide=!t.netHotListIsHide},t.e3=function(e,n){var a=arguments[arguments.length-1].currentTarget.dataset,i=a.eventParams||a["event-params"];n=i.word;return t.search(n.content)}),t.$mp.data=Object.assign({},{$root:{m0:n,m1:a,m2:i,m3:o,l0:c}})},o=[]},db96:function(t,e,n){"use strict";n.r(e);var a=n("9279"),i=n.n(a);for(var o in a)"default"!==o&&function(t){n.d(e,t,(function(){return a[t]}))}(o);e["default"]=i.a},f052:function(t,e,n){"use strict";(function(t){n("7a45");a(n("66fd"));var e=a(n("fe55"));function a(t){return t&&t.__esModule?t:{default:t}}wx.__webpack_require_UNI_MP_PLUGIN__=n,t(e.default)}).call(this,n("543d")["createPage"])},fe55:function(t,e,n){"use strict";n.r(e);var a=n("bc00"),i=n("db96");for(var o in i)"default"!==o&&function(t){n.d(e,t,(function(){return i[t]}))}(o);n("21a6");var c,s=n("f0c5"),r=Object(s["a"])(i["default"],a["b"],a["c"],!1,null,"72fb0b93",null,!1,a["a"],c);e["default"]=r.exports}},[["f052","common/runtime","common/vendor"]]]);