<template>
	<view>
		<uni-popup ref="popup" :animation="!0" :maskClick="false" type="center">
			<view class="bg-white border-radius margin-40 " style="overflow: hidden;">
				<view class="text-center padding-top-40">
					<text>用户协议及隐私条款</text>
				</view>
				<view class="font-24  under-line padding-40">
					<text>欢迎使用APP，我们非常重视您的隐私保护和个人信息保护，在您使用APP服务之前，请认真阅读</text>
					<text class="colorBlue" @click="navTo('/pages/app/web',appConfig.fwxy)">《用户服务协议》</text>
					<text>和</text>
					<text class="colorBlue" @click="navTo('/pages/app/web',appConfig.yszc)">《隐私条款》</text>
					<text>全部内容，您同意并接受全部条款后开始使用我们的服务</text>
				</view>
				<view class="ti-flex text-center ">
					<view class="flex-1" @click="unAgree()">
						<text>不同意</text>
					</view>
					<view class="flex-1 bg-blue padding-22 colorWhite" @click="agree()">
						<text>同意并继续</text>
					</view>
				</view>
			</view>
		</uni-popup>
	</view>
</template>

<script>
	export default {
		data() {
			return {
				agreeTime: 0,
				key: "app_agreement"
			};
		},
		onLoad() {
			this.agreeTime = uni.getStorageSync(this.key);
			if (this.agreeTime) {
				uni.switchTab({
					url: "/pages/index/index"
				})
			}
		},
		computed: {
			appConfig() {
				return this.$config.app;
			}
		},
		mounted() {
			if (!this.agreeTime) {
				this.showPop()
				uni.hideLoading()
			}
		},
		methods: {
			unAgree() {
				this.$refs.popup.close()
			},
			agree() {
				uni.setStorage({
					key: this.key,
					data: Date.now()
				})
				uni.switchTab({
					url: "/pages/index/index"
				})
			},

			showPop() {
				this.$refs.popup.open()
			}
		}
	}
</script>

<style lang="scss">

</style>
