(global["webpackJsonp"]=global["webpackJsonp"]||[]).push([["uni_modules/uni-title/components/uni-title/uni-title"],{2667:function(t,e,i){"use strict";i.r(e);var n=i("7e01"),a=i("747c");for(var r in a)"default"!==r&&function(t){i.d(e,t,(function(){return a[t]}))}(r);i("6ca4");var s,u=i("f0c5"),c=Object(u["a"])(a["default"],n["b"],n["c"],!1,null,"a6a4ad9c",null,!1,n["a"],s);e["default"]=c.exports},"6ca4":function(t,e,i){"use strict";var n=i("b9de"),a=i.n(n);a.a},"747c":function(t,e,i){"use strict";i.r(e);var n=i("c14e"),a=i.n(n);for(var r in n)"default"!==r&&function(t){i.d(e,t,(function(){return n[t]}))}(r);e["default"]=a.a},"7e01":function(t,e,i){"use strict";var n;i.d(e,"b",(function(){return a})),i.d(e,"c",(function(){return r})),i.d(e,"a",(function(){return n}));var a=function(){var t=this,e=t.$createElement;t._self._c},r=[]},b9de:function(t,e,i){},c14e:function(t,e,i){"use strict";(function(t){Object.defineProperty(e,"__esModule",{value:!0}),e.default=void 0;var i={name:"UniTitle",props:{type:{type:String,default:""},title:{type:String,default:""},align:{type:String,default:"left"},color:{type:String,default:"#333333"},stat:{type:[Boolean,String],default:""}},data:function(){return{}},computed:{textAlign:function(){var t="center";switch(this.align){case"left":t="flex-start";break;case"center":t="center";break;case"right":t="flex-end";break}return t}},watch:{title:function(e){this.isOpenStat()&&t.report&&t.report("title",this.title)}},mounted:function(){this.isOpenStat()&&t.report&&t.report("title",this.title)},methods:{isOpenStat:function(){""===this.stat&&(this.isStat=!1);var t="boolean"===typeof this.stat&&this.stat||"string"===typeof this.stat&&""!==this.stat;return""===this.type&&(this.isStat=!0,"false"===this.stat.toString()&&(this.isStat=!1)),""!==this.type&&(this.isStat=!0,this.isStat=!!t),this.isStat}}};e.default=i}).call(this,i("543d")["default"])}}]);
;(global["webpackJsonp"] = global["webpackJsonp"] || []).push([
    'uni_modules/uni-title/components/uni-title/uni-title-create-component',
    {
        'uni_modules/uni-title/components/uni-title/uni-title-create-component':(function(module, exports, __webpack_require__){
            __webpack_require__('543d')['createComponent'](__webpack_require__("2667"))
        })
    },
    [['uni_modules/uni-title/components/uni-title/uni-title-create-component']]
]);
