(global["webpackJsonp"]=global["webpackJsonp"]||[]).push([["components/j-msg/j-msg"],{"0518":function(t,n,e){"use strict";var a;e.d(n,"b",(function(){return u})),e.d(n,"c",(function(){return i})),e.d(n,"a",(function(){return a}));var u=function(){var t=this,n=t.$createElement,e=(t._self._c,t.item.timestamp?t.timestampToTime(t.item.timestamp):null);t.$mp.data=Object.assign({},{$root:{m0:e}})},i=[]},5501:function(t,n,e){},"9be9":function(t,n,e){"use strict";e.r(n);var a=e("0518"),u=e("ca5a");for(var i in u)"default"!==i&&function(t){e.d(n,t,(function(){return u[t]}))}(i);e("b6a8");var r,c=e("f0c5"),o=Object(c["a"])(u["default"],a["b"],a["c"],!1,null,"148e9def",null,!1,a["a"],r);n["default"]=o.exports},a43c:function(t,n,e){"use strict";Object.defineProperty(n,"__esModule",{value:!0}),n.default=void 0;var a={data:function(){return{}},methods:{timestampToTime:function(t){var n=new Date(parseInt(t)),e=n.getMonth()+1,a=n.getDate(),u=n.getHours(),i=n.getMinutes(),r=n.getSeconds(),c=e<10?"0"+e:e,o=a<10?"0"+a:a,f=u<10?"0"+u:u,s=i<10?"0"+i:i,l=r<10?"0"+r:r;return c+"-"+o+" "+f+":"+s+":"+l}},props:{active:{type:Boolean,default:function(){return!1}},item:{type:Object,default:function(){return{avatarUrl:"https://img.cdn.aliyun.dcloud.net.cn/uni-app/uniCloud/uniCloud-run-function-1.png",title:"title",timestamp:"234656453",text:"text",num:"9"}}}}};n.default=a},b6a8:function(t,n,e){"use strict";var a=e("5501"),u=e.n(a);u.a},ca5a:function(t,n,e){"use strict";e.r(n);var a=e("a43c"),u=e.n(a);for(var i in a)"default"!==i&&function(t){e.d(n,t,(function(){return a[t]}))}(i);n["default"]=u.a}}]);
;(global["webpackJsonp"] = global["webpackJsonp"] || []).push([
    'components/j-msg/j-msg-create-component',
    {
        'components/j-msg/j-msg-create-component':(function(module, exports, __webpack_require__){
            __webpack_require__('543d')['createComponent'](__webpack_require__("9be9"))
        })
    },
    [['components/j-msg/j-msg-create-component']]
]);
