(global["webpackJsonp"]=global["webpackJsonp"]||[]).push([["pages/app/cities"],{"04cc":function(t,e,i){"use strict";i.r(e);var n=i("c1ae"),a=i.n(n);for(var o in n)"default"!==o&&function(t){i.d(e,t,(function(){return n[t]}))}(o);e["default"]=a.a},"4ec6":function(t,e,i){"use strict";i.d(e,"b",(function(){return a})),i.d(e,"c",(function(){return o})),i.d(e,"a",(function(){return n}));var n={uniIndexedList:function(){return i.e("uni_modules/uni-indexed-list/components/uni-indexed-list/uni-indexed-list").then(i.bind(null,"11f4"))}},a=function(){var t=this,e=t.$createElement;t._self._c},o=[]},"719c":function(t,e,i){"use strict";(function(t){i("566f");n(i("66fd"));var e=n(i("e50d"));function n(t){return t&&t.__esModule?t:{default:t}}wx.__webpack_require_UNI_MP_PLUGIN__=i,t(e.default)}).call(this,i("543d")["createPage"])},c1ae:function(t,e,i){"use strict";(function(t,n){Object.defineProperty(e,"__esModule",{value:!0}),e.default=void 0;var a=o(i("a34a"));function o(t){return t&&t.__esModule?t:{default:t}}function c(t,e,i,n,a,o,c){try{var s=t[o](c),r=s.value}catch(d){return void i(d)}s.done?e(r):Promise.resolve(r).then(n,a)}function s(t){return function(){var e=this,i=arguments;return new Promise((function(n,a){var o=t.apply(e,i);function s(t){c(o,n,a,s,r,"next",t)}function r(t){c(o,n,a,s,r,"throw",t)}s(void 0)}))}}var r=t.database(),d={data:function(){return{localCity:{},limit:500,save:!1,codeList:{},dataList:[],hotLetter:"热门",zhixiashi:{"北京市":"110000","天津市":"120000","重庆市":"500000","上海市":"310000"}}},onLoad:function(t){t.save&&(this.save=t.save),this.loadData()},computed:{isLogin:function(){return this.$store.getters["user/isTokenValid"]}},methods:{loadData:function(){var t=this;r.collection("opendb-city-china").where("(type==1) || (type==2 && is_recommend==true)").field("code,name,first_letter,is_recommend").orderBy("first_letter asc,name asc").limit(this.limit).get().then((function(e){var i=e.result;console.log(i);var n="",a=[],o=["省直辖县级行政区划","自治区直辖县级行政区划","县"],c=[];i.data.map((function(e){e.first_letter!=n&&(n&&t.dataList.push({letter:n,data:a}),n=e.first_letter,a=[]),-1==o.indexOf(e.name)&&(a.push(e.name),e.is_recommend&&c.push(e.name),t.zhixiashi[e.name]?t.codeList[e.name]=t.zhixiashi[e.name]:t.codeList[e.name]=e.code)})),c.length>0&&t.dataList.unshift({letter:t.hotLetter,data:c}),t.dataList.push({letter:n,data:a}),t.getLocation()}))},getLocation:function(){var t=this;n.getLocation({success:function(e){console.log("getLocation",e),t.$request("utils/getLocationAddress",{fromLatlng:[e.latitude,e.longitude].join()}).then((function(e){if(console.log("data",e),e.ad_info){t.codeList[e.ad_info.district]?t.localCity={name:e.ad_info.district+"（当前定位）",realName:e.ad_info.district,code:t.codeList[e.ad_info.district]}:t.zhixiashi[e.ad_info.province]?t.localCity={name:e.ad_info.province+"（当前定位城市）",realName:e.ad_info.province,code:t.zhixiashi[e.ad_info.province]}:t.localCity={name:e.ad_info.city+"（当前定位城市）",realName:e.ad_info.city,code:t.codeList[e.ad_info.city]},console.log("this.localCity",t.localCity);var i=t.dataList[0].letter==t.hotLetter;if(t.codeList[t.localCity.name]=t.localCity.code,i){var n=t.dataList[0].data.findIndex((function(e){return 0==t.localCity.name.indexOf(e)}));-1!=n&&t.dataList[0].data.splice(n,1),t.dataList[0].data.unshift(t.localCity.name)}else t.dataList.unshift({letter:t.hotLetter,data:[t.localCity.name]})}}))}})},chooseCity:function(t){var e=this;return s(a.default.mark((function i(){var o;return a.default.wrap((function(i){while(1)switch(i.prev=i.next){case 0:if(console.log("chooseCity",t,e.codeList[t.item.name]),o={code:e.codeList[t.item.name],name:t.item.name},e.localCity&&e.localCity.code==o.code&&(o.name=e.localCity.realName),n.setStorage({key:"user_select_city",data:o}),!e.save||!e.isLogin){i.next=8;break}return i.next=7,r.collection("uni-id-users").where("_id==$cloudEnv_uid").update({select_city:o});case 7:e.$store.dispatch("user/getUserInfo");case 8:e.$success("设置成功"),e.navTimeBack(!0,1500,(function(){e.$store.dispatch("app/init",{city:o})}));case 10:case"end":return i.stop()}}),i)})))()}}};e.default=d}).call(this,i("a9ff")["default"],i("543d")["default"])},e50d:function(t,e,i){"use strict";i.r(e);var n=i("4ec6"),a=i("04cc");for(var o in a)"default"!==o&&function(t){i.d(e,t,(function(){return a[t]}))}(o);var c,s=i("f0c5"),r=Object(s["a"])(a["default"],n["b"],n["c"],!1,null,null,null,!1,n["a"],c);e["default"]=r.exports}},[["719c","common/runtime","common/vendor"]]]);