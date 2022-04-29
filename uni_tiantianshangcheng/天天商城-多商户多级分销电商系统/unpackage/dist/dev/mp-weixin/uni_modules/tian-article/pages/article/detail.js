(global["webpackJsonp"] = global["webpackJsonp"] || []).push([["uni_modules/tian-article/pages/article/detail"],{

/***/ 63:
/*!***************************************************************************************************************************************!*\
  !*** D:/xiaochengxu/uni_tiantianshangcheng/天天商城-多商户多级分销电商系统/main.js?{"page":"uni_modules%2Ftian-article%2Fpages%2Farticle%2Fdetail"} ***!
  \***************************************************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

"use strict";
/* WEBPACK VAR INJECTION */(function(createPage) {__webpack_require__(/*! uni-pages */ 5);
var _vue = _interopRequireDefault(__webpack_require__(/*! vue */ 3));
var _detail = _interopRequireDefault(__webpack_require__(/*! ./uni_modules/tian-article/pages/article/detail.vue */ 64));function _interopRequireDefault(obj) {return obj && obj.__esModule ? obj : { default: obj };}wx.__webpack_require_UNI_MP_PLUGIN__ = __webpack_require__;
createPage(_detail.default);
/* WEBPACK VAR INJECTION */}.call(this, __webpack_require__(/*! ./node_modules/@dcloudio/uni-mp-weixin/dist/index.js */ 1)["createPage"]))

/***/ }),

/***/ 64:
/*!****************************************************************************************************************!*\
  !*** D:/xiaochengxu/uni_tiantianshangcheng/天天商城-多商户多级分销电商系统/uni_modules/tian-article/pages/article/detail.vue ***!
  \****************************************************************************************************************/
/*! no static exports found */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony import */ var _detail_vue_vue_type_template_id_8aa676f8___WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ./detail.vue?vue&type=template&id=8aa676f8& */ 65);
/* harmony import */ var _detail_vue_vue_type_script_lang_js___WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./detail.vue?vue&type=script&lang=js& */ 67);
/* harmony reexport (unknown) */ for(var __WEBPACK_IMPORT_KEY__ in _detail_vue_vue_type_script_lang_js___WEBPACK_IMPORTED_MODULE_1__) if(__WEBPACK_IMPORT_KEY__ !== 'default') (function(key) { __webpack_require__.d(__webpack_exports__, key, function() { return _detail_vue_vue_type_script_lang_js___WEBPACK_IMPORTED_MODULE_1__[key]; }) }(__WEBPACK_IMPORT_KEY__));
/* harmony import */ var _detail_vue_vue_type_style_index_0_lang_css___WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./detail.vue?vue&type=style&index=0&lang=css& */ 70);
/* harmony import */ var _H_software_HBuilderX_3_4_7_20220422_HBuilderX_plugins_uniapp_cli_node_modules_dcloudio_vue_cli_plugin_uni_packages_vue_loader_lib_runtime_componentNormalizer_js__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ./node_modules/@dcloudio/vue-cli-plugin-uni/packages/vue-loader/lib/runtime/componentNormalizer.js */ 16);

var renderjs





/* normalize component */

var component = Object(_H_software_HBuilderX_3_4_7_20220422_HBuilderX_plugins_uniapp_cli_node_modules_dcloudio_vue_cli_plugin_uni_packages_vue_loader_lib_runtime_componentNormalizer_js__WEBPACK_IMPORTED_MODULE_3__["default"])(
  _detail_vue_vue_type_script_lang_js___WEBPACK_IMPORTED_MODULE_1__["default"],
  _detail_vue_vue_type_template_id_8aa676f8___WEBPACK_IMPORTED_MODULE_0__["render"],
  _detail_vue_vue_type_template_id_8aa676f8___WEBPACK_IMPORTED_MODULE_0__["staticRenderFns"],
  false,
  null,
  null,
  null,
  false,
  _detail_vue_vue_type_template_id_8aa676f8___WEBPACK_IMPORTED_MODULE_0__["components"],
  renderjs
)

component.options.__file = "uni_modules/tian-article/pages/article/detail.vue"
/* harmony default export */ __webpack_exports__["default"] = (component.exports);

/***/ }),

/***/ 65:
/*!***********************************************************************************************************************************************!*\
  !*** D:/xiaochengxu/uni_tiantianshangcheng/天天商城-多商户多级分销电商系统/uni_modules/tian-article/pages/article/detail.vue?vue&type=template&id=8aa676f8& ***!
  \***********************************************************************************************************************************************/
/*! exports provided: render, staticRenderFns, recyclableRender, components */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony import */ var _H_software_HBuilderX_3_4_7_20220422_HBuilderX_plugins_uniapp_cli_node_modules_dcloudio_vue_cli_plugin_uni_packages_vue_loader_lib_loaders_templateLoader_js_vue_loader_options_H_software_HBuilderX_3_4_7_20220422_HBuilderX_plugins_uniapp_cli_node_modules_dcloudio_vue_cli_plugin_uni_packages_webpack_preprocess_loader_index_js_ref_16_0_H_software_HBuilderX_3_4_7_20220422_HBuilderX_plugins_uniapp_cli_node_modules_dcloudio_webpack_uni_mp_loader_lib_template_js_H_software_HBuilderX_3_4_7_20220422_HBuilderX_plugins_uniapp_cli_node_modules_dcloudio_vue_cli_plugin_uni_packages_webpack_uni_app_loader_page_meta_js_H_software_HBuilderX_3_4_7_20220422_HBuilderX_plugins_uniapp_cli_node_modules_dcloudio_vue_cli_plugin_uni_packages_vue_loader_lib_index_js_vue_loader_options_H_software_HBuilderX_3_4_7_20220422_HBuilderX_plugins_uniapp_cli_node_modules_dcloudio_webpack_uni_mp_loader_lib_style_js_detail_vue_vue_type_template_id_8aa676f8___WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! -!./node_modules/@dcloudio/vue-cli-plugin-uni/packages/vue-loader/lib/loaders/templateLoader.js??vue-loader-options!./node_modules/@dcloudio/vue-cli-plugin-uni/packages/webpack-preprocess-loader??ref--16-0!./node_modules/@dcloudio/webpack-uni-mp-loader/lib/template.js!./node_modules/@dcloudio/vue-cli-plugin-uni/packages/webpack-uni-app-loader/page-meta.js!./node_modules/@dcloudio/vue-cli-plugin-uni/packages/vue-loader/lib??vue-loader-options!./node_modules/@dcloudio/webpack-uni-mp-loader/lib/style.js!./detail.vue?vue&type=template&id=8aa676f8& */ 66);
/* harmony reexport (safe) */ __webpack_require__.d(__webpack_exports__, "render", function() { return _H_software_HBuilderX_3_4_7_20220422_HBuilderX_plugins_uniapp_cli_node_modules_dcloudio_vue_cli_plugin_uni_packages_vue_loader_lib_loaders_templateLoader_js_vue_loader_options_H_software_HBuilderX_3_4_7_20220422_HBuilderX_plugins_uniapp_cli_node_modules_dcloudio_vue_cli_plugin_uni_packages_webpack_preprocess_loader_index_js_ref_16_0_H_software_HBuilderX_3_4_7_20220422_HBuilderX_plugins_uniapp_cli_node_modules_dcloudio_webpack_uni_mp_loader_lib_template_js_H_software_HBuilderX_3_4_7_20220422_HBuilderX_plugins_uniapp_cli_node_modules_dcloudio_vue_cli_plugin_uni_packages_webpack_uni_app_loader_page_meta_js_H_software_HBuilderX_3_4_7_20220422_HBuilderX_plugins_uniapp_cli_node_modules_dcloudio_vue_cli_plugin_uni_packages_vue_loader_lib_index_js_vue_loader_options_H_software_HBuilderX_3_4_7_20220422_HBuilderX_plugins_uniapp_cli_node_modules_dcloudio_webpack_uni_mp_loader_lib_style_js_detail_vue_vue_type_template_id_8aa676f8___WEBPACK_IMPORTED_MODULE_0__["render"]; });

/* harmony reexport (safe) */ __webpack_require__.d(__webpack_exports__, "staticRenderFns", function() { return _H_software_HBuilderX_3_4_7_20220422_HBuilderX_plugins_uniapp_cli_node_modules_dcloudio_vue_cli_plugin_uni_packages_vue_loader_lib_loaders_templateLoader_js_vue_loader_options_H_software_HBuilderX_3_4_7_20220422_HBuilderX_plugins_uniapp_cli_node_modules_dcloudio_vue_cli_plugin_uni_packages_webpack_preprocess_loader_index_js_ref_16_0_H_software_HBuilderX_3_4_7_20220422_HBuilderX_plugins_uniapp_cli_node_modules_dcloudio_webpack_uni_mp_loader_lib_template_js_H_software_HBuilderX_3_4_7_20220422_HBuilderX_plugins_uniapp_cli_node_modules_dcloudio_vue_cli_plugin_uni_packages_webpack_uni_app_loader_page_meta_js_H_software_HBuilderX_3_4_7_20220422_HBuilderX_plugins_uniapp_cli_node_modules_dcloudio_vue_cli_plugin_uni_packages_vue_loader_lib_index_js_vue_loader_options_H_software_HBuilderX_3_4_7_20220422_HBuilderX_plugins_uniapp_cli_node_modules_dcloudio_webpack_uni_mp_loader_lib_style_js_detail_vue_vue_type_template_id_8aa676f8___WEBPACK_IMPORTED_MODULE_0__["staticRenderFns"]; });

/* harmony reexport (safe) */ __webpack_require__.d(__webpack_exports__, "recyclableRender", function() { return _H_software_HBuilderX_3_4_7_20220422_HBuilderX_plugins_uniapp_cli_node_modules_dcloudio_vue_cli_plugin_uni_packages_vue_loader_lib_loaders_templateLoader_js_vue_loader_options_H_software_HBuilderX_3_4_7_20220422_HBuilderX_plugins_uniapp_cli_node_modules_dcloudio_vue_cli_plugin_uni_packages_webpack_preprocess_loader_index_js_ref_16_0_H_software_HBuilderX_3_4_7_20220422_HBuilderX_plugins_uniapp_cli_node_modules_dcloudio_webpack_uni_mp_loader_lib_template_js_H_software_HBuilderX_3_4_7_20220422_HBuilderX_plugins_uniapp_cli_node_modules_dcloudio_vue_cli_plugin_uni_packages_webpack_uni_app_loader_page_meta_js_H_software_HBuilderX_3_4_7_20220422_HBuilderX_plugins_uniapp_cli_node_modules_dcloudio_vue_cli_plugin_uni_packages_vue_loader_lib_index_js_vue_loader_options_H_software_HBuilderX_3_4_7_20220422_HBuilderX_plugins_uniapp_cli_node_modules_dcloudio_webpack_uni_mp_loader_lib_style_js_detail_vue_vue_type_template_id_8aa676f8___WEBPACK_IMPORTED_MODULE_0__["recyclableRender"]; });

/* harmony reexport (safe) */ __webpack_require__.d(__webpack_exports__, "components", function() { return _H_software_HBuilderX_3_4_7_20220422_HBuilderX_plugins_uniapp_cli_node_modules_dcloudio_vue_cli_plugin_uni_packages_vue_loader_lib_loaders_templateLoader_js_vue_loader_options_H_software_HBuilderX_3_4_7_20220422_HBuilderX_plugins_uniapp_cli_node_modules_dcloudio_vue_cli_plugin_uni_packages_webpack_preprocess_loader_index_js_ref_16_0_H_software_HBuilderX_3_4_7_20220422_HBuilderX_plugins_uniapp_cli_node_modules_dcloudio_webpack_uni_mp_loader_lib_template_js_H_software_HBuilderX_3_4_7_20220422_HBuilderX_plugins_uniapp_cli_node_modules_dcloudio_vue_cli_plugin_uni_packages_webpack_uni_app_loader_page_meta_js_H_software_HBuilderX_3_4_7_20220422_HBuilderX_plugins_uniapp_cli_node_modules_dcloudio_vue_cli_plugin_uni_packages_vue_loader_lib_index_js_vue_loader_options_H_software_HBuilderX_3_4_7_20220422_HBuilderX_plugins_uniapp_cli_node_modules_dcloudio_webpack_uni_mp_loader_lib_style_js_detail_vue_vue_type_template_id_8aa676f8___WEBPACK_IMPORTED_MODULE_0__["components"]; });



/***/ }),

/***/ 66:
/*!***********************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************!*\
  !*** ./node_modules/@dcloudio/vue-cli-plugin-uni/packages/vue-loader/lib/loaders/templateLoader.js??vue-loader-options!./node_modules/@dcloudio/vue-cli-plugin-uni/packages/webpack-preprocess-loader??ref--16-0!./node_modules/@dcloudio/webpack-uni-mp-loader/lib/template.js!./node_modules/@dcloudio/vue-cli-plugin-uni/packages/webpack-uni-app-loader/page-meta.js!./node_modules/@dcloudio/vue-cli-plugin-uni/packages/vue-loader/lib??vue-loader-options!./node_modules/@dcloudio/webpack-uni-mp-loader/lib/style.js!D:/xiaochengxu/uni_tiantianshangcheng/天天商城-多商户多级分销电商系统/uni_modules/tian-article/pages/article/detail.vue?vue&type=template&id=8aa676f8& ***!
  \***********************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************/
/*! exports provided: render, staticRenderFns, recyclableRender, components */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "render", function() { return render; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "staticRenderFns", function() { return staticRenderFns; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "recyclableRender", function() { return recyclableRender; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "components", function() { return components; });
var components
try {
  components = {
    uniDateformat: function() {
      return Promise.all(/*! import() | uni_modules/uni-dateformat/components/uni-dateformat/uni-dateformat */[__webpack_require__.e("common/vendor"), __webpack_require__.e("uni_modules/uni-dateformat/components/uni-dateformat/uni-dateformat")]).then(__webpack_require__.bind(null, /*! @/uni_modules/uni-dateformat/components/uni-dateformat/uni-dateformat.vue */ 539))
    },
    uniLoadMore: function() {
      return Promise.all(/*! import() | uni_modules/uni-load-more/components/uni-load-more/uni-load-more */[__webpack_require__.e("common/vendor"), __webpack_require__.e("uni_modules/uni-load-more/components/uni-load-more/uni-load-more")]).then(__webpack_require__.bind(null, /*! @/uni_modules/uni-load-more/components/uni-load-more/uni-load-more.vue */ 545))
    },
    tianIcons: function() {
      return __webpack_require__.e(/*! import() | uni_modules/tian-mall/components/tian-icons/tian-icons */ "uni_modules/tian-mall/components/tian-icons/tian-icons").then(__webpack_require__.bind(null, /*! @/uni_modules/tian-mall/components/tian-icons/tian-icons.vue */ 556))
    },
    uniEasyinput: function() {
      return __webpack_require__.e(/*! import() | uni_modules/uni-easyinput/components/uni-easyinput/uni-easyinput */ "uni_modules/uni-easyinput/components/uni-easyinput/uni-easyinput").then(__webpack_require__.bind(null, /*! @/uni_modules/uni-easyinput/components/uni-easyinput/uni-easyinput.vue */ 532))
    },
    tianEmpty: function() {
      return __webpack_require__.e(/*! import() | uni_modules/tian-mall/components/tian-empty/tian-empty */ "uni_modules/tian-mall/components/tian-empty/tian-empty").then(__webpack_require__.bind(null, /*! @/uni_modules/tian-mall/components/tian-empty/tian-empty.vue */ 563))
    }
  }
} catch (e) {
  if (
    e.message.indexOf("Cannot find module") !== -1 &&
    e.message.indexOf(".vue") !== -1
  ) {
    console.error(e.message)
    console.error("1. 排查组件名称拼写是否正确")
    console.error(
      "2. 排查组件是否符合 easycom 规范，文档：https://uniapp.dcloud.net.cn/collocation/pages?id=easycom"
    )
    console.error(
      "3. 若组件不符合 easycom 规范，需手动引入，并在 components 中注册该组件"
    )
  } else {
    throw e
  }
}
var render = function() {
  var _vm = this
  var _h = _vm.$createElement
  var _c = _vm._self._c || _h
}
var recyclableRender = false
var staticRenderFns = []
render._withStripped = true



/***/ }),

/***/ 67:
/*!*****************************************************************************************************************************************!*\
  !*** D:/xiaochengxu/uni_tiantianshangcheng/天天商城-多商户多级分销电商系统/uni_modules/tian-article/pages/article/detail.vue?vue&type=script&lang=js& ***!
  \*****************************************************************************************************************************************/
/*! no static exports found */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony import */ var _H_software_HBuilderX_3_4_7_20220422_HBuilderX_plugins_uniapp_cli_node_modules_babel_loader_lib_index_js_H_software_HBuilderX_3_4_7_20220422_HBuilderX_plugins_uniapp_cli_node_modules_dcloudio_vue_cli_plugin_uni_packages_webpack_preprocess_loader_index_js_ref_12_1_H_software_HBuilderX_3_4_7_20220422_HBuilderX_plugins_uniapp_cli_node_modules_dcloudio_webpack_uni_mp_loader_lib_script_js_H_software_HBuilderX_3_4_7_20220422_HBuilderX_plugins_uniapp_cli_node_modules_dcloudio_vue_cli_plugin_uni_packages_vue_loader_lib_index_js_vue_loader_options_H_software_HBuilderX_3_4_7_20220422_HBuilderX_plugins_uniapp_cli_node_modules_dcloudio_webpack_uni_mp_loader_lib_style_js_detail_vue_vue_type_script_lang_js___WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! -!./node_modules/babel-loader/lib!./node_modules/@dcloudio/vue-cli-plugin-uni/packages/webpack-preprocess-loader??ref--12-1!./node_modules/@dcloudio/webpack-uni-mp-loader/lib/script.js!./node_modules/@dcloudio/vue-cli-plugin-uni/packages/vue-loader/lib??vue-loader-options!./node_modules/@dcloudio/webpack-uni-mp-loader/lib/style.js!./detail.vue?vue&type=script&lang=js& */ 68);
/* harmony import */ var _H_software_HBuilderX_3_4_7_20220422_HBuilderX_plugins_uniapp_cli_node_modules_babel_loader_lib_index_js_H_software_HBuilderX_3_4_7_20220422_HBuilderX_plugins_uniapp_cli_node_modules_dcloudio_vue_cli_plugin_uni_packages_webpack_preprocess_loader_index_js_ref_12_1_H_software_HBuilderX_3_4_7_20220422_HBuilderX_plugins_uniapp_cli_node_modules_dcloudio_webpack_uni_mp_loader_lib_script_js_H_software_HBuilderX_3_4_7_20220422_HBuilderX_plugins_uniapp_cli_node_modules_dcloudio_vue_cli_plugin_uni_packages_vue_loader_lib_index_js_vue_loader_options_H_software_HBuilderX_3_4_7_20220422_HBuilderX_plugins_uniapp_cli_node_modules_dcloudio_webpack_uni_mp_loader_lib_style_js_detail_vue_vue_type_script_lang_js___WEBPACK_IMPORTED_MODULE_0___default = /*#__PURE__*/__webpack_require__.n(_H_software_HBuilderX_3_4_7_20220422_HBuilderX_plugins_uniapp_cli_node_modules_babel_loader_lib_index_js_H_software_HBuilderX_3_4_7_20220422_HBuilderX_plugins_uniapp_cli_node_modules_dcloudio_vue_cli_plugin_uni_packages_webpack_preprocess_loader_index_js_ref_12_1_H_software_HBuilderX_3_4_7_20220422_HBuilderX_plugins_uniapp_cli_node_modules_dcloudio_webpack_uni_mp_loader_lib_script_js_H_software_HBuilderX_3_4_7_20220422_HBuilderX_plugins_uniapp_cli_node_modules_dcloudio_vue_cli_plugin_uni_packages_vue_loader_lib_index_js_vue_loader_options_H_software_HBuilderX_3_4_7_20220422_HBuilderX_plugins_uniapp_cli_node_modules_dcloudio_webpack_uni_mp_loader_lib_style_js_detail_vue_vue_type_script_lang_js___WEBPACK_IMPORTED_MODULE_0__);
/* harmony reexport (unknown) */ for(var __WEBPACK_IMPORT_KEY__ in _H_software_HBuilderX_3_4_7_20220422_HBuilderX_plugins_uniapp_cli_node_modules_babel_loader_lib_index_js_H_software_HBuilderX_3_4_7_20220422_HBuilderX_plugins_uniapp_cli_node_modules_dcloudio_vue_cli_plugin_uni_packages_webpack_preprocess_loader_index_js_ref_12_1_H_software_HBuilderX_3_4_7_20220422_HBuilderX_plugins_uniapp_cli_node_modules_dcloudio_webpack_uni_mp_loader_lib_script_js_H_software_HBuilderX_3_4_7_20220422_HBuilderX_plugins_uniapp_cli_node_modules_dcloudio_vue_cli_plugin_uni_packages_vue_loader_lib_index_js_vue_loader_options_H_software_HBuilderX_3_4_7_20220422_HBuilderX_plugins_uniapp_cli_node_modules_dcloudio_webpack_uni_mp_loader_lib_style_js_detail_vue_vue_type_script_lang_js___WEBPACK_IMPORTED_MODULE_0__) if(__WEBPACK_IMPORT_KEY__ !== 'default') (function(key) { __webpack_require__.d(__webpack_exports__, key, function() { return _H_software_HBuilderX_3_4_7_20220422_HBuilderX_plugins_uniapp_cli_node_modules_babel_loader_lib_index_js_H_software_HBuilderX_3_4_7_20220422_HBuilderX_plugins_uniapp_cli_node_modules_dcloudio_vue_cli_plugin_uni_packages_webpack_preprocess_loader_index_js_ref_12_1_H_software_HBuilderX_3_4_7_20220422_HBuilderX_plugins_uniapp_cli_node_modules_dcloudio_webpack_uni_mp_loader_lib_script_js_H_software_HBuilderX_3_4_7_20220422_HBuilderX_plugins_uniapp_cli_node_modules_dcloudio_vue_cli_plugin_uni_packages_vue_loader_lib_index_js_vue_loader_options_H_software_HBuilderX_3_4_7_20220422_HBuilderX_plugins_uniapp_cli_node_modules_dcloudio_webpack_uni_mp_loader_lib_style_js_detail_vue_vue_type_script_lang_js___WEBPACK_IMPORTED_MODULE_0__[key]; }) }(__WEBPACK_IMPORT_KEY__));
 /* harmony default export */ __webpack_exports__["default"] = (_H_software_HBuilderX_3_4_7_20220422_HBuilderX_plugins_uniapp_cli_node_modules_babel_loader_lib_index_js_H_software_HBuilderX_3_4_7_20220422_HBuilderX_plugins_uniapp_cli_node_modules_dcloudio_vue_cli_plugin_uni_packages_webpack_preprocess_loader_index_js_ref_12_1_H_software_HBuilderX_3_4_7_20220422_HBuilderX_plugins_uniapp_cli_node_modules_dcloudio_webpack_uni_mp_loader_lib_script_js_H_software_HBuilderX_3_4_7_20220422_HBuilderX_plugins_uniapp_cli_node_modules_dcloudio_vue_cli_plugin_uni_packages_vue_loader_lib_index_js_vue_loader_options_H_software_HBuilderX_3_4_7_20220422_HBuilderX_plugins_uniapp_cli_node_modules_dcloudio_webpack_uni_mp_loader_lib_style_js_detail_vue_vue_type_script_lang_js___WEBPACK_IMPORTED_MODULE_0___default.a); 

/***/ }),

/***/ 68:
/*!************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************!*\
  !*** ./node_modules/babel-loader/lib!./node_modules/@dcloudio/vue-cli-plugin-uni/packages/webpack-preprocess-loader??ref--12-1!./node_modules/@dcloudio/webpack-uni-mp-loader/lib/script.js!./node_modules/@dcloudio/vue-cli-plugin-uni/packages/vue-loader/lib??vue-loader-options!./node_modules/@dcloudio/webpack-uni-mp-loader/lib/style.js!D:/xiaochengxu/uni_tiantianshangcheng/天天商城-多商户多级分销电商系统/uni_modules/tian-article/pages/article/detail.vue?vue&type=script&lang=js& ***!
  \************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

"use strict";
/* WEBPACK VAR INJECTION */(function(uniCloud, uni) {Object.defineProperty(exports, "__esModule", { value: true });exports.default = void 0;
































































var _ad = _interopRequireDefault(__webpack_require__(/*! @/common/mixin/ad */ 39));


var _ad2 = _interopRequireDefault(__webpack_require__(/*! @/common/js/ad.js */ 69));function _interopRequireDefault(obj) {return obj && obj.__esModule ? obj : { default: obj };}function ownKeys(object, enumerableOnly) {var keys = Object.keys(object);if (Object.getOwnPropertySymbols) {var symbols = Object.getOwnPropertySymbols(object);if (enumerableOnly) symbols = symbols.filter(function (sym) {return Object.getOwnPropertyDescriptor(object, sym).enumerable;});keys.push.apply(keys, symbols);}return keys;}function _objectSpread(target) {for (var i = 1; i < arguments.length; i++) {var source = arguments[i] != null ? arguments[i] : {};if (i % 2) {ownKeys(Object(source), true).forEach(function (key) {_defineProperty(target, key, source[key]);});} else if (Object.getOwnPropertyDescriptors) {Object.defineProperties(target, Object.getOwnPropertyDescriptors(source));} else {ownKeys(Object(source)).forEach(function (key) {Object.defineProperty(target, key, Object.getOwnPropertyDescriptor(source, key));});}}return target;}function _defineProperty(obj, key, value) {if (key in obj) {Object.defineProperty(obj, key, { value: value, enumerable: true, configurable: true, writable: true });} else {obj[key] = value;}return obj;} //
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
var db = uniCloud.database(); // 表查询配置
var dbCollectionName = 'opendb-news-articles';var _default = { mixins: [_ad.default], data: function data() {return { id: '', isFav: false, isGetScore: false, loaded: false, where: '', content: '', commentList: [], item: {} };}, onLoad: function onLoad(e) {this.id = e.id;this.loadData();}, onShow: function onShow() {this.checkFav();}, onReachBottom: function onReachBottom() {console.log('加载下一页评论，滑动到底部，增加积分');if (this.item.task && !this.isGetScore && this.checkBindMobile("必须绑定手机才能做任务")) {this.isGetScore = true; //完成阅读，增加积分
      if (this.item.task.normal) {this.articleRead(this.item.task);}}this.loadCommentData();}, computed: { isLogin: function isLogin() {return this.$store.getters['user/isTokenValid'];}, userInfo: function userInfo() {return this.$store.state.user.userInfo;}, adConfig: function adConfig() {if (this.$store.state && this.$store.state.app.adConfig && this.$store.state.app.adConfig.article && this.$store.state.app.adConfig.article.detail) {return this.$store.state.app.adConfig.article.detail;}return {};}, bottomAdpid: function bottomAdpid() {if (this.adConfig.bottom) {return this.adConfig.bottom;}return false;}, topAdpid: function topAdpid() {if (this.adConfig.top) {return this.adConfig.top;}return false;}, canGetDoubleScore: function canGetDoubleScore() {return this.item.task && this.item.task.multiple && (this.adConfig.signin || this.adConfig.video);} }, methods: { submitComment: function submitComment(reply_comment) {var _this = this;
      if (!this.isLogin) {
        this.navToLoginNotice();
        return;
      }
      if (!this.content) {
        uni.showToast({
          icon: 'none',
          title: '请输入评论内容' });

        return;
      }
      uni.showLoading({
        title: '提交中',
        mask: true });

      var item = {
        article_id: this.id,
        user_id: db.env.uid,
        user: {
          avatar: this.userInfo.avatar,
          nickname: this.userInfo.nickname },

        like_count: 0,
        comment_type: 0,
        comment_content: this.content,
        reply_comment_id: reply_comment ? reply_comment._id : '',
        reply_user_id: reply_comment ? reply_comment.user_id : '' };

      db.collection('opendb-news-comments').
      add(item).
      then(function (_ref)

      {var result = _ref.result;
        console.log('res', result);
        uni.hideLoading();
        uni.showToast({
          title: '发布成功' });

        item._id = result.id;
        item.user_id = [_this.userInfo];
        item.comment_date = Date.now();
        var newData = [item];
        _this.buildComment(newData);
        _this.commentList = newData.concat(_this.commentList);
        _this.content = '';
      });
    },
    loadCommentData: function loadCommentData() {var _this2 = this;
      if (!this.item.comment_status) {
        console.log("文章不支持评论");
        return;
      }
      if (this.loadingType == 'noMore') {
        return;
      }
      this.loadingType == 'loading';
      this.page++;
      //默认查询第一层
      db.collection('opendb-news-comments').
      where("article_id==\"".concat(this.id, "\" && reply_comment_id==\"\"")).
      field(
      'comment_content,like_count,comment_type,reply_user_id,reply_comment_id,comment_date,user').

      orderBy('comment_date desc').
      skip((this.page - 1) * this.limit).
      limit(this.limit).
      get().
      then(function (_ref2)

      {var result = _ref2.result;
        if (result.data.length < _this2.limit) {
          _this2.loadingType = 'noMore';
        } else {
          _this2.loadingType = 'more';
        }
        _this2.buildComment(result.data);

        if (_this2.page == 1) {
          _this2.commentList = result.data;
        } else {
          _this2.commentList = _this2.commentList.concat(result.data);
        }
      });
    },
    buildComment: function buildComment(data) {
      //处理头像
      var info = {
        avatar: '/static/missing-face.png',
        nickname: '匿名' };

      data.forEach(function (item) {
        if (item.user) {
          item.user = _objectSpread(_objectSpread({},
          info),
          item.user);

        } else {
          item.user = info;
        }
      });
    },
    loadData: function loadData() {var _this3 = this;
      var data = this.getItemData();
      this.buildData(data);
      db.action('article_read').
      collection('opendb-news-articles,uni-id-users').
      foreignKey('opendb-news-articles.user_id').
      where("article_status==1 && _id==\"".concat(this.id, "\"")).
      field(
      'avatar,title,excerpt,publish_date,like_count,source_from,view_count,user_id.nickname,content,comment_count,comment_status').

      get({
        getOne: true }).

      then(function (_ref3)

      {var result = _ref3.result;
        // console.log("result.data", result.data)
        _this3.buildData(result.data);
        //更新今日已读文章列表
        if (_this3.isLogin) {
          _this3.$store.commit('mall/UPDATE_ARTICLE_READ', _this3.item._id);
        }
        _this3.loaded = true;
      });
    },
    buildData: function buildData(item) {
      if (!item) {
        return;
      }
      uni.setNavigationBarTitle({
        title: item.title });

      //微信中不支持使用过滤器
      if (item.avatar) {
        item.avatar = this.$thumbImg(item.avatar, "750x400");
      }
      if (typeof item.user_id == 'object') {
        if (item.user_id && item.user_id.length > 0) {
          item.user_id = item.user_id[0].nickname;
        } else {
          item.user_id = '';
        }
      }
      //处理文中的图片
      if (item.content) {
        item.content = this.$repairImageSize(item.content);
      }
      this.item = item;
    },
    checkFav: function checkFav() {var _this4 = this;
      db.collection('opendb-news-favorite').
      where("user_id==$cloudEnv_uid && article_id==\"".concat(this.id, "\"")).
      field('_id').
      get({
        getOne: true }).

      then(function (_ref4)

      {var result = _ref4.result;
        console.log('checkFav result', result);
        _this4.isFav = result.data.length > 0;
      }).
      catch(function (err) {
        console.log('未登录');
      });
    },
    unFav: function unFav() {var _this5 = this;
      uni.showModal({
        content: '是否确定取消收藏？',
        success: function success(res) {
          if (res.confirm) {
            uni.showLoading({
              mask: true });

            db.collection('opendb-news-favorite').
            where("user_id==$cloudEnv_uid && article_id==\"".concat(_this5.id, "\"")).
            remove().
            then(function () {
              uni.hideLoading();
              _this5.isFav = false;
              uni.showToast({
                title: '取消成功' });

            }).
            catch(function () {
              uni.hideLoading();
              uni.showToast({
                icon: 'none',
                title: '取消失败' });

            });
          }
        } });

    },
    fav: function fav() {var _this6 = this;
      if (this.isLogin) {
        uni.showLoading({
          mask: true });

        //收藏，必须登录
        db.action('article_favorite').
        collection('opendb-news-favorite').
        where({
          user_id: db.env.uid,
          article_id: this.id }).

        field('_id').
        get({
          getOne: true }).

        then(function (_ref5)

        {var result = _ref5.result;
          _this6.isFav = true;
          console.log('fav result');
          uni.hideLoading();
          uni.showToast({
            title: '收藏成功' });

        }).
        catch(function () {
          uni.hideLoading();
          uni.showToast({
            icon: 'none',
            title: '收藏失败' });

        });
      } else {
        //提示登录
        this.navToLoginNotice(function () {
          _this6.checkFav();
        });
      }
    },
    /**
        * 提示消息,页面可以单独自定义
        * @param {Object} res
        */
    finishTaskResult: function finishTaskResult(res) {
      this.item.task.log = _objectSpread(_objectSpread({},
      res), {}, {
        task: undefined });

      this.item.task.multiple = res.task.multiple;
      if (res.getDouble) {
        this.$message("\u9605\u8BFB\u7FFB\u500D\u5956\u52B1 +".concat(res.task.bounty));
      } else if (res.getScore) {
        this.$message("\u9605\u8BFB\u5956\u52B1 +".concat(res.task.bounty));
      } else if (res.needMore) {
        this.$message("\u5DF2\u5B8C\u6210".concat(res.amount, "\u6B21"));
      } else if (res.result) {}
    } } };exports.default = _default;
/* WEBPACK VAR INJECTION */}.call(this, __webpack_require__(/*! ./node_modules/@dcloudio/vue-cli-plugin-uni/packages/uni-cloud/dist/index.js */ 21)["default"], __webpack_require__(/*! ./node_modules/@dcloudio/uni-mp-weixin/dist/index.js */ 1)["default"]))

/***/ }),

/***/ 70:
/*!*************************************************************************************************************************************************!*\
  !*** D:/xiaochengxu/uni_tiantianshangcheng/天天商城-多商户多级分销电商系统/uni_modules/tian-article/pages/article/detail.vue?vue&type=style&index=0&lang=css& ***!
  \*************************************************************************************************************************************************/
/*! no static exports found */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony import */ var _H_software_HBuilderX_3_4_7_20220422_HBuilderX_plugins_uniapp_cli_node_modules_mini_css_extract_plugin_dist_loader_js_ref_6_oneOf_1_0_H_software_HBuilderX_3_4_7_20220422_HBuilderX_plugins_uniapp_cli_node_modules_css_loader_dist_cjs_js_ref_6_oneOf_1_1_H_software_HBuilderX_3_4_7_20220422_HBuilderX_plugins_uniapp_cli_node_modules_dcloudio_vue_cli_plugin_uni_packages_vue_loader_lib_loaders_stylePostLoader_js_H_software_HBuilderX_3_4_7_20220422_HBuilderX_plugins_uniapp_cli_node_modules_dcloudio_vue_cli_plugin_uni_packages_webpack_preprocess_loader_index_js_ref_6_oneOf_1_2_H_software_HBuilderX_3_4_7_20220422_HBuilderX_plugins_uniapp_cli_node_modules_postcss_loader_src_index_js_ref_6_oneOf_1_3_H_software_HBuilderX_3_4_7_20220422_HBuilderX_plugins_uniapp_cli_node_modules_dcloudio_vue_cli_plugin_uni_packages_vue_loader_lib_index_js_vue_loader_options_H_software_HBuilderX_3_4_7_20220422_HBuilderX_plugins_uniapp_cli_node_modules_dcloudio_webpack_uni_mp_loader_lib_style_js_detail_vue_vue_type_style_index_0_lang_css___WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! -!./node_modules/mini-css-extract-plugin/dist/loader.js??ref--6-oneOf-1-0!./node_modules/css-loader/dist/cjs.js??ref--6-oneOf-1-1!./node_modules/@dcloudio/vue-cli-plugin-uni/packages/vue-loader/lib/loaders/stylePostLoader.js!./node_modules/@dcloudio/vue-cli-plugin-uni/packages/webpack-preprocess-loader??ref--6-oneOf-1-2!./node_modules/postcss-loader/src??ref--6-oneOf-1-3!./node_modules/@dcloudio/vue-cli-plugin-uni/packages/vue-loader/lib??vue-loader-options!./node_modules/@dcloudio/webpack-uni-mp-loader/lib/style.js!./detail.vue?vue&type=style&index=0&lang=css& */ 71);
/* harmony import */ var _H_software_HBuilderX_3_4_7_20220422_HBuilderX_plugins_uniapp_cli_node_modules_mini_css_extract_plugin_dist_loader_js_ref_6_oneOf_1_0_H_software_HBuilderX_3_4_7_20220422_HBuilderX_plugins_uniapp_cli_node_modules_css_loader_dist_cjs_js_ref_6_oneOf_1_1_H_software_HBuilderX_3_4_7_20220422_HBuilderX_plugins_uniapp_cli_node_modules_dcloudio_vue_cli_plugin_uni_packages_vue_loader_lib_loaders_stylePostLoader_js_H_software_HBuilderX_3_4_7_20220422_HBuilderX_plugins_uniapp_cli_node_modules_dcloudio_vue_cli_plugin_uni_packages_webpack_preprocess_loader_index_js_ref_6_oneOf_1_2_H_software_HBuilderX_3_4_7_20220422_HBuilderX_plugins_uniapp_cli_node_modules_postcss_loader_src_index_js_ref_6_oneOf_1_3_H_software_HBuilderX_3_4_7_20220422_HBuilderX_plugins_uniapp_cli_node_modules_dcloudio_vue_cli_plugin_uni_packages_vue_loader_lib_index_js_vue_loader_options_H_software_HBuilderX_3_4_7_20220422_HBuilderX_plugins_uniapp_cli_node_modules_dcloudio_webpack_uni_mp_loader_lib_style_js_detail_vue_vue_type_style_index_0_lang_css___WEBPACK_IMPORTED_MODULE_0___default = /*#__PURE__*/__webpack_require__.n(_H_software_HBuilderX_3_4_7_20220422_HBuilderX_plugins_uniapp_cli_node_modules_mini_css_extract_plugin_dist_loader_js_ref_6_oneOf_1_0_H_software_HBuilderX_3_4_7_20220422_HBuilderX_plugins_uniapp_cli_node_modules_css_loader_dist_cjs_js_ref_6_oneOf_1_1_H_software_HBuilderX_3_4_7_20220422_HBuilderX_plugins_uniapp_cli_node_modules_dcloudio_vue_cli_plugin_uni_packages_vue_loader_lib_loaders_stylePostLoader_js_H_software_HBuilderX_3_4_7_20220422_HBuilderX_plugins_uniapp_cli_node_modules_dcloudio_vue_cli_plugin_uni_packages_webpack_preprocess_loader_index_js_ref_6_oneOf_1_2_H_software_HBuilderX_3_4_7_20220422_HBuilderX_plugins_uniapp_cli_node_modules_postcss_loader_src_index_js_ref_6_oneOf_1_3_H_software_HBuilderX_3_4_7_20220422_HBuilderX_plugins_uniapp_cli_node_modules_dcloudio_vue_cli_plugin_uni_packages_vue_loader_lib_index_js_vue_loader_options_H_software_HBuilderX_3_4_7_20220422_HBuilderX_plugins_uniapp_cli_node_modules_dcloudio_webpack_uni_mp_loader_lib_style_js_detail_vue_vue_type_style_index_0_lang_css___WEBPACK_IMPORTED_MODULE_0__);
/* harmony reexport (unknown) */ for(var __WEBPACK_IMPORT_KEY__ in _H_software_HBuilderX_3_4_7_20220422_HBuilderX_plugins_uniapp_cli_node_modules_mini_css_extract_plugin_dist_loader_js_ref_6_oneOf_1_0_H_software_HBuilderX_3_4_7_20220422_HBuilderX_plugins_uniapp_cli_node_modules_css_loader_dist_cjs_js_ref_6_oneOf_1_1_H_software_HBuilderX_3_4_7_20220422_HBuilderX_plugins_uniapp_cli_node_modules_dcloudio_vue_cli_plugin_uni_packages_vue_loader_lib_loaders_stylePostLoader_js_H_software_HBuilderX_3_4_7_20220422_HBuilderX_plugins_uniapp_cli_node_modules_dcloudio_vue_cli_plugin_uni_packages_webpack_preprocess_loader_index_js_ref_6_oneOf_1_2_H_software_HBuilderX_3_4_7_20220422_HBuilderX_plugins_uniapp_cli_node_modules_postcss_loader_src_index_js_ref_6_oneOf_1_3_H_software_HBuilderX_3_4_7_20220422_HBuilderX_plugins_uniapp_cli_node_modules_dcloudio_vue_cli_plugin_uni_packages_vue_loader_lib_index_js_vue_loader_options_H_software_HBuilderX_3_4_7_20220422_HBuilderX_plugins_uniapp_cli_node_modules_dcloudio_webpack_uni_mp_loader_lib_style_js_detail_vue_vue_type_style_index_0_lang_css___WEBPACK_IMPORTED_MODULE_0__) if(__WEBPACK_IMPORT_KEY__ !== 'default') (function(key) { __webpack_require__.d(__webpack_exports__, key, function() { return _H_software_HBuilderX_3_4_7_20220422_HBuilderX_plugins_uniapp_cli_node_modules_mini_css_extract_plugin_dist_loader_js_ref_6_oneOf_1_0_H_software_HBuilderX_3_4_7_20220422_HBuilderX_plugins_uniapp_cli_node_modules_css_loader_dist_cjs_js_ref_6_oneOf_1_1_H_software_HBuilderX_3_4_7_20220422_HBuilderX_plugins_uniapp_cli_node_modules_dcloudio_vue_cli_plugin_uni_packages_vue_loader_lib_loaders_stylePostLoader_js_H_software_HBuilderX_3_4_7_20220422_HBuilderX_plugins_uniapp_cli_node_modules_dcloudio_vue_cli_plugin_uni_packages_webpack_preprocess_loader_index_js_ref_6_oneOf_1_2_H_software_HBuilderX_3_4_7_20220422_HBuilderX_plugins_uniapp_cli_node_modules_postcss_loader_src_index_js_ref_6_oneOf_1_3_H_software_HBuilderX_3_4_7_20220422_HBuilderX_plugins_uniapp_cli_node_modules_dcloudio_vue_cli_plugin_uni_packages_vue_loader_lib_index_js_vue_loader_options_H_software_HBuilderX_3_4_7_20220422_HBuilderX_plugins_uniapp_cli_node_modules_dcloudio_webpack_uni_mp_loader_lib_style_js_detail_vue_vue_type_style_index_0_lang_css___WEBPACK_IMPORTED_MODULE_0__[key]; }) }(__WEBPACK_IMPORT_KEY__));
 /* harmony default export */ __webpack_exports__["default"] = (_H_software_HBuilderX_3_4_7_20220422_HBuilderX_plugins_uniapp_cli_node_modules_mini_css_extract_plugin_dist_loader_js_ref_6_oneOf_1_0_H_software_HBuilderX_3_4_7_20220422_HBuilderX_plugins_uniapp_cli_node_modules_css_loader_dist_cjs_js_ref_6_oneOf_1_1_H_software_HBuilderX_3_4_7_20220422_HBuilderX_plugins_uniapp_cli_node_modules_dcloudio_vue_cli_plugin_uni_packages_vue_loader_lib_loaders_stylePostLoader_js_H_software_HBuilderX_3_4_7_20220422_HBuilderX_plugins_uniapp_cli_node_modules_dcloudio_vue_cli_plugin_uni_packages_webpack_preprocess_loader_index_js_ref_6_oneOf_1_2_H_software_HBuilderX_3_4_7_20220422_HBuilderX_plugins_uniapp_cli_node_modules_postcss_loader_src_index_js_ref_6_oneOf_1_3_H_software_HBuilderX_3_4_7_20220422_HBuilderX_plugins_uniapp_cli_node_modules_dcloudio_vue_cli_plugin_uni_packages_vue_loader_lib_index_js_vue_loader_options_H_software_HBuilderX_3_4_7_20220422_HBuilderX_plugins_uniapp_cli_node_modules_dcloudio_webpack_uni_mp_loader_lib_style_js_detail_vue_vue_type_style_index_0_lang_css___WEBPACK_IMPORTED_MODULE_0___default.a); 

/***/ }),

/***/ 71:
/*!*****************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************!*\
  !*** ./node_modules/mini-css-extract-plugin/dist/loader.js??ref--6-oneOf-1-0!./node_modules/css-loader/dist/cjs.js??ref--6-oneOf-1-1!./node_modules/@dcloudio/vue-cli-plugin-uni/packages/vue-loader/lib/loaders/stylePostLoader.js!./node_modules/@dcloudio/vue-cli-plugin-uni/packages/webpack-preprocess-loader??ref--6-oneOf-1-2!./node_modules/postcss-loader/src??ref--6-oneOf-1-3!./node_modules/@dcloudio/vue-cli-plugin-uni/packages/vue-loader/lib??vue-loader-options!./node_modules/@dcloudio/webpack-uni-mp-loader/lib/style.js!D:/xiaochengxu/uni_tiantianshangcheng/天天商城-多商户多级分销电商系统/uni_modules/tian-article/pages/article/detail.vue?vue&type=style&index=0&lang=css& ***!
  \*****************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

// extracted by mini-css-extract-plugin
    if(false) { var cssReload; }
  

/***/ })

},[[63,"common/runtime","common/vendor"]]]);
//# sourceMappingURL=../../../../../.sourcemap/mp-weixin/uni_modules/tian-article/pages/article/detail.js.map