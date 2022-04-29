<template>
	<view class="container">
		<web-view v-if="src" :src="src"></web-view>
	</view>
</template>

<script>
	export default {
		data() {
			return {
				src: ""
			}
		},
		onLoad(options) {
			this.src = this.getItemData();
			this.loadData();
		},
		methods: {
			async loadData() {
				// #ifdef APP-PLUS
				var pages = getCurrentPages();
				var page = pages[pages.length - 1];
				var currentWebview = page.$getAppWebview();
				console.log(currentWebview.id); //获得当前webview的id
				console.log(currentWebview.isVisible()); //查询当前webview是否可见
				// #endif
			}
		}
	}
</script>

<style lang="scss">
	page {
		background: #FFFFFF;
	}
</style>
