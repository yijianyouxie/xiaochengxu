<template>
	<view class="index-container">
		<tian-tab-pages v-if="configs.component=='tian-tab-pages'" :configs="configs" :refresh="refresh"
			:loadmore="loadmore">
		</tian-tab-pages>
		<tian-pages v-else-if="configs.component=='tian-pages'" :configs="configs" :refresh="refresh"
			:loadmore="loadmore">
		</tian-pages>
		<view class="text-center padding-top-100" v-else>
			<image src="/static/loading.gif" mode="aspectFill" style="width: 32rpx;height: 32rpx;"></image>
		</view>
		<view class="bg-white padding-22 font-32" v-if="configs.install_notice" style="line-height: 1.8;">
			<text>{{configs.install_notice}}</text>
		</view>
	</view>
</template>

<script>
	import {
		mapActions,
		mapMutations,
	} from 'vuex';
	import tabbarMixin from './mixin/tabbar'
	import adMixin from '@/common/mixin/ad';
	import {
		getQueryString
	} from '@/common/js/util.js'
	import mpShareMixin from '@/common/mixin/share/mp'
	const db = uniCloud.database()
	export default {
		mixins: [tabbarMixin, mpShareMixin, adMixin],
		data() {
			return {
				refresh: 0,
				loadmore: 0,
				configs: {
					component: "",
					parent_id: '',
					title: ""
				},
				goods: {},
			}
		},
		onLoad(e) {
			//微信普通二维码扫码进入，然后跳转到二级页面
			if (e.q) {
				let url = decodeURIComponent(e.q);
				Object.assign(e, {
					...getQueryString(url)
				});
				delete e.q
				console.log("options.query", e)
			}
			//#ifdef APP-PLUS
			this.midButton();
			//#endif
			this.loadData();
			this.loadVideoAd();
			if (e.secondpage) {
				setTimeout(() => {
					let query = []
					for (let key in e) {
						if (key != "secondpage") {
							query.push(`${key}=${e[key]}`);
						}
					}
					this.navTo(e.secondpage + "?" + query.join("&"))
				}, e.time ? e.time : 2000)
			}
		},
		watch: {
			pageConfig() {
				console.log("watch pageConfig", this.pageConfig)
				this.configs = this.pageConfig;
				this.setGlobalShareContent()
			}
		},
		computed: {
			appConfig() {
				return this.$config.app;
			},
			pageConfig() {
				if (this.$store.state.app.pageConfig && this.$store.state.app.pageConfig.home) {
					return this.$store.state.app.pageConfig.home;
				}
				return {}
			},
			adConfig() {
				if (this.$store.state && this.$store.state.app.adConfig && this.$store.state.app.adConfig.tasks) {
					return this.$store.state.app.adConfig.tasks;
				}
				return {};
			},
			middleAdpid() {
				if (this.$store.state && this.$store.state.app.adConfig && this.$store.state.app.adConfig.middle) {
					return this.$store.state.app.adConfig.middle;
				}
				return false;
			},
		},
		//下拉刷新
		onPullDownRefresh() {
			console.log('刷新整页');
			uni.stopPullDownRefresh();
			this.refresh = Date.now();
		},
		onReachBottom() {
			console.log("加载下一页")
			this.loadmore = Date.now();
		},
		// 标题栏input搜索框点击
		onNavigationBarSearchInputClicked(e) {
			console.log('onNavigationBarSearchInputClicked');
			uni.navigateTo({
				url: "/pages/search/search"
			})
		},
		methods: {
			loadData() {
				//默认配置
				this.configs = this.pageConfig;
				//查询购物车总数量
				this.$store.dispatch('mall/getCartTotal');
			},
			/**
			 * 列表上打开sku
			 * @param {Object} e
			 */
			openSku(e) {
				console.log("openSku", e)
				this.goods = e;
				this.$refs.tianSkuPop.open();
			},
			midButton() {
				uni.onTabBarMidButtonTap(() => {
					if (this.middleAdpid) {
						plus.ad.showContentPage({
							adpid: this.middleAdpid
						}, (res) => {}, (err) => {});
					}
				})
			},
		}
	}
</script>

<style lang="scss">
	.index-container {
		padding-bottom: var(--window-bottom);
	}
</style>
