(global["webpackJsonp"]=global["webpackJsonp"]||[]).push([["pages/order/comment"],{"2ce7":function(t,e,n){},"4c10":function(t,e,n){"use strict";n.r(e);var o=n("a530"),u=n.n(o);for(var a in o)"default"!==a&&function(t){n.d(e,t,(function(){return o[t]}))}(a);e["default"]=u.a},"993b":function(t,e,n){"use strict";var o=n("2ce7"),u=n.n(o);u.a},a530:function(t,e,n){"use strict";(function(t){Object.defineProperty(e,"__esModule",{value:!0}),e.default=void 0;var n=t.database(),o={data:function(){return{dataList:[],formData:{rate:5,comment:""},rateResult:["很差劲","还好了","一般般","很好","非常好"]}},onLoad:function(){this.loadData(),this.$store.state.app.customer.commentLevel&&(this.rateResult=this.$store.state.app.customer.commentLevel)},computed:{rateString:function(){return this.rateResult[this.formData.rate-1]}},methods:{changeRate:function(t){console.log("changeRate",t)},loadData:function(){var t=this;n.collection("tian-mall-orders").where("user_id==$cloudEnv_uid && is_delete==0 && state==3").orderBy("create_time desc").field("goods,shop").get().then((function(e){var n=e.result;console.log(n),t.dataList=[],n.data.map((function(e){e.goods&&(e.goods.forEach((function(t){t.order_id=e._id})),t.dataList=t.dataList.concat(e.goods.filter((function(t){return!t.comment}))))}))}))},comment:function(t){this.formData={rate:5,comment:"",goods_id:t.goods_id,sku_id:t.sku_id,id:t.order_id},this.$refs.popup.open()},cancel:function(){this.$refs.popup.close()},submit:function(){var t=this;this.formData.comment?(this.$request("mall/order/comment",this.formData).then((function(e){t.$success("评论成功"),t.loadData()})),this.cancel()):this.$message("请输入评价内容")}}};e.default=o}).call(this,n("a9ff")["default"])},beed:function(t,e,n){"use strict";n.d(e,"b",(function(){return u})),n.d(e,"c",(function(){return a})),n.d(e,"a",(function(){return o}));var o={uniPopup:function(){return n.e("uni_modules/uni-popup/components/uni-popup/uni-popup").then(n.bind(null,"36ef"))},uniRate:function(){return n.e("uni_modules/uni-rate/components/uni-rate/uni-rate").then(n.bind(null,"e22a"))},uniEasyinput:function(){return n.e("uni_modules/uni-easyinput/components/uni-easyinput/uni-easyinput").then(n.bind(null,"549f"))}},u=function(){var t=this,e=t.$createElement;t._self._c},a=[]},f3f3:function(t,e,n){"use strict";(function(t){n("566f");o(n("66fd"));var e=o(n("fed1"));function o(t){return t&&t.__esModule?t:{default:t}}wx.__webpack_require_UNI_MP_PLUGIN__=n,t(e.default)}).call(this,n("543d")["createPage"])},fed1:function(t,e,n){"use strict";n.r(e);var o=n("beed"),u=n("4c10");for(var a in u)"default"!==a&&function(t){n.d(e,t,(function(){return u[t]}))}(a);n("993b");var i,r=n("f0c5"),c=Object(r["a"])(u["default"],o["b"],o["c"],!1,null,null,null,!1,o["a"],i);e["default"]=c.exports}},[["f3f3","common/runtime","common/vendor"]]]);