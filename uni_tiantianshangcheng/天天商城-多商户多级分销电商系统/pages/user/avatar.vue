<template>
	<view class="container">
		<view class="page-body uni-content-info">
			<view class="cropper-content">
				<view v-if="isShowImg" class="uni-corpper"
					:style="'width:' + cropperInitW + 'px;height:' + cropperInitH + 'px;background:#000000'">
					<view class="uni-corpper-content"
						:style="'width:' + cropperW + 'px;height:' + cropperH + 'px;left:' + cropperL + 'px;top:' + cropperT + 'px'">
						<image :src="imageSrc" :style="'width:' + cropperW + 'px;height:' + cropperH + 'px'"></image>
						<view class="uni-corpper-crop-box" @touchstart.stop="contentStartMove"
							@touchmove.stop="contentMoveing" @touchend.stop="contentTouchEnd"
							:style="'left:' + cutL + 'px;top:' + cutT + 'px;right:' + cutR + 'px;bottom:' + cutB + 'px'">
							<view class="uni-cropper-view-box">
								<view class="uni-cropper-dashed-h"></view>
								<view class="uni-cropper-dashed-v"></view>
								<view class="uni-cropper-line-t" data-drag="top" @touchstart.stop="dragStart"
									@touchmove.stop="dragMove"></view>
								<view class="uni-cropper-line-r" data-drag="right" @touchstart.stop="dragStart"
									@touchmove.stop="dragMove"></view>
								<view class="uni-cropper-line-b" data-drag="bottom" @touchstart.stop="dragStart"
									@touchmove.stop="dragMove"></view>
								<view class="uni-cropper-line-l" data-drag="left" @touchstart.stop="dragStart"
									@touchmove.stop="dragMove"></view>
								<view class="uni-cropper-point point-t" data-drag="top" @touchstart.stop="dragStart"
									@touchmove.stop="dragMove"></view>
								<view class="uni-cropper-point point-tr" data-drag="topTight"></view>
								<view class="uni-cropper-point point-r" data-drag="right" @touchstart.stop="dragStart"
									@touchmove.stop="dragMove"></view>
								<!-- <view class="uni-cropper-point point-rb" data-drag="rightBottom" @touchstart.stop="dragStart" @touchmove.stop="dragMove"></view> -->
								<view class="uni-cropper-point point-b" data-drag="bottom" @touchstart.stop="dragStart"
									@touchmove.stop="dragMove" @touchend.stop="dragEnd"></view>
								<view class="uni-cropper-point point-bl" data-drag="bottomLeft"></view>
								<view class="uni-cropper-point point-l" data-drag="left" @touchstart.stop="dragStart"
									@touchmove.stop="dragMove"></view>
								<view class="uni-cropper-point point-lt" data-drag="leftTop"></view>
							</view>
						</view>
					</view>
				</view>
			</view>
			<canvas canvas-id="myCanvas"
				:style="'position:absolute;border: 1px solid red; width:' + imageW + 'px;height:' + imageH + 'px;top:-9999px;left:-9999px;'"></canvas>
			<button class="buttons" :disabled="isSubmit" @click="getImageInfo">确定裁剪并保存</button>
		</view>
	</view>
</template>

<script>
	import {
		cloudUploadFile
	} from "@/common/mixin/upload.js"
	export default {
		/**
		 * 页面的初始数据
		 */
		data() {
			return {
				imageSrc: '',
				isShowImg: false,
				SCREEN_WIDTH: 0,
				SCREEN_HEIGHT: 0,
				// 初始化的宽高
				cropperInitW: 0,
				cropperInitH: 0,
				// 动态的宽高
				cropperW: 0,
				cropperH: 0,
				// 动态的left top值
				cropperL: 0,
				cropperT: 0,

				transL: 0,
				transT: 0,

				// 图片缩放值
				scaleP: 0,
				imageW: 0,
				imageH: 0,

				// 裁剪框 宽高
				cutL: 0,
				cutT: 0,
				cutB: 0,
				cutR: '100%',
				qualityWidth: 0,
				innerAspectRadio: 1,
				ratio: 1 /**宽高比例*/ ,
				pageinfo: {
					PAGE_X: 0, // 手按下的x位置
					PAGE_Y: 0, // 手按下y的位置
					PR: 0, // dpi
					T_PAGE_X: 0, // 手移动的时候x的位置
					T_PAGE_Y: 0, // 手移动的时候Y的位置
					CUT_L: 0, // 初始化拖拽元素的left值
					CUT_T: 0, // 初始化拖拽元素的top值
					CUT_R: 0, // 初始化拖拽元素的
					CUT_B: 0, // 初始化拖拽元素的
					CUT_W: 0, // 初始化拖拽元素的宽度
					CUT_H: 0, //  初始化拖拽元素的高度
					IMG_RATIO: 0, // 图片比例
					IMG_REAL_W: 0, // 图片实际的宽度
					IMG_REAL_H: 0, // 图片实际的高度
					DRAFG_MOVE_RATIO: 1, //移动时候的比例,
					INIT_DRAG_POSITION: 100, // 初始化屏幕宽度和裁剪区域的宽度之差，用于设置初始化裁剪的宽度
					DRAW_IMAGE_W: 0 //设置生成的图片宽度
				}

			};
		},
		/**
		 * 生命周期函数--监听页面加载
		 */
		onLoad(options) {
			const sysInfo = this.systemInfo;
			this.qualityWidth = this.pageinfo.DRAW_IMAGE_W = this.cutB = this.cropperW = this.cropperInitW = this
				.SCREEN_WIDTH =
				sysInfo.screenWidth;
			this.cropperH = this.cropperInitH = this.SCREEN_HEIGHT = sysInfo.safeArea.height - sysInfo.navigationBarHeight;
			this.pageinfo.PR = sysInfo.pixelRatio;
		},

		/**
		 * 生命周期函数--监听页面初次渲染完成
		 */
		onReady() {
			uni.getStorage({
				key: 'avatar',
				success: e => {
					console.log(e);
					this.imageSrc = e.data;
					this.loadImage();
				}
			});
		},
		methods: {
			setData(obj) {
				let that = this;
				Object.keys(obj).forEach(function(key) {
					that.$set(that.$data, key, obj[key]);
				});
			},
			loadImage() {
				var _this = this;
				uni.showLoading({
					title: '图片加载中...'
				});

				uni.getImageInfo({
					src: _this.imageSrc,
					success: res => {
						this.pageinfo.IMG_RATIO = res.width / res.height;
						if (this.pageinfo.IMG_RATIO >= 1) {
							this.pageinfo.IMG_REAL_W = this.SCREEN_WIDTH;
							this.pageinfo.IMG_REAL_H = this.SCREEN_WIDTH / this.pageinfo.IMG_RATIO;
						} else if (this.SCREEN_WIDTH / this.SCREEN_HEIGHT < this.pageinfo.IMG_RATIO) {
							console.log('SCREEN_WIDTH/this.SCREEN_HEIGHT,this.pageinfo.IMG_RATIO', this
								.SCREEN_WIDTH / this.SCREEN_HEIGHT,
								this.pageinfo.IMG_RATIO);
							this.pageinfo.IMG_REAL_W = this.SCREEN_WIDTH;
							this.pageinfo.IMG_REAL_H = this.SCREEN_WIDTH / this.pageinfo.IMG_RATIO;
						} else {
							//超出屏幕高度,缩小尺寸
							this.pageinfo.IMG_REAL_H = this.SCREEN_HEIGHT;
							this.pageinfo.IMG_REAL_W = this.SCREEN_HEIGHT * this.pageinfo.IMG_RATIO;
						}
						let minRange = this.pageinfo.IMG_REAL_W < this.pageinfo.IMG_REAL_H ? this.pageinfo
							.IMG_REAL_W : this.pageinfo.IMG_REAL_H;
						this.pageinfo.INIT_DRAG_POSITION = minRange > this.pageinfo.INIT_DRAG_POSITION ? this
							.pageinfo.INIT_DRAG_POSITION :
							minRange;
						// 根据图片的宽高显示不同的效果   保证图片可以正常显示
						console.log('实际宽高', res.width, res.height);
						console.log('显示宽高', this.pageinfo.IMG_REAL_W, this.pageinfo.IMG_REAL_H);
						if (this.pageinfo.IMG_RATIO >= 1) {
							let cutT = 0;
							let cutB = cutT;
							let cutL = (this.pageinfo.IMG_REAL_W - this.pageinfo.IMG_REAL_H) / 2;
							let cutR = cutL;
							_this.setData({
								cropperW: this.SCREEN_WIDTH,
								cropperH: this.SCREEN_WIDTH / this.pageinfo.IMG_RATIO,
								// 初始化left right
								cropperL: 0,
								cropperT: (this.SCREEN_HEIGHT - this.pageinfo.IMG_REAL_H) / 2,
								cutL: cutL,
								cutT: cutT,
								cutR: cutR,
								cutB: cutB,
								// 图片缩放值
								imageW: this.pageinfo.IMG_REAL_W,
								imageH: this.pageinfo.IMG_REAL_H,
								scaleP: this.pageinfo.IMG_REAL_W / this.SCREEN_WIDTH,
								qualityWidth: this.pageinfo.DRAW_IMAGE_W,
								innerAspectRadio: this.pageinfo.IMG_RATIO
							});
						} else {
							let cutL = 0;
							let cutR = cutL;
							let cutT = (this.pageinfo.IMG_REAL_H - this.pageinfo.IMG_REAL_W) /
								2; //图片高-宽//Math.ceil((this.SCREEN_WIDTH - this.pageinfo.INIT_DRAG_POSITION) / 2);
							let cutB = cutT;
							console.log(cutT);
							_this.setData({
								cropperW: this.pageinfo.IMG_REAL_W,
								cropperH: this.pageinfo.IMG_REAL_H,
								// 初始化left right
								cropperL: (this.SCREEN_WIDTH - this.pageinfo.IMG_REAL_W) / 2,
								cropperT: (this.SCREEN_HEIGHT - this.pageinfo.IMG_REAL_H) / 2,

								cutL: cutL,
								cutT: cutT,
								cutR: cutR,
								cutB: cutB,
								// 图片缩放值
								imageW: this.pageinfo.IMG_REAL_W,
								imageH: this.pageinfo.IMG_REAL_H,
								scaleP: this.pageinfo.IMG_REAL_W / this.SCREEN_WIDTH,
								qualityWidth: this.pageinfo.DRAW_IMAGE_W,
								innerAspectRadio: this.pageinfo.IMG_RATIO
							});
						}
						_this.setData({
							isShowImg: true
						});
						uni.hideLoading();
					}
				});
			},
			// 拖动时候触发的touchStart事件
			contentStartMove(e) {
				this.pageinfo.PAGE_X = e.touches[0].pageX;
				this.pageinfo.PAGE_Y = e.touches[0].pageY;
			},

			// 拖动时候触发的touchMove事件
			contentMoveing(e) {
				var dragLengthX = (this.pageinfo.PAGE_X - e.touches[0].pageX) * this.pageinfo.DRAFG_MOVE_RATIO;
				var dragLengthY = (this.pageinfo.PAGE_Y - e.touches[0].pageY) * this.pageinfo.DRAFG_MOVE_RATIO;
				// 左移
				if (dragLengthX > 0) {
					if (this.cutL - dragLengthX < 0) dragLengthX = this.cutL;
				} else {
					if (this.cutR + dragLengthX < 0) dragLengthX = -this.cutR;
				}

				if (dragLengthY > 0) {
					if (this.cutT - dragLengthY < 0) dragLengthY = this.cutT;
				} else {
					if (this.cutB + dragLengthY < 0) dragLengthY = -this.cutB;
				}
				this.setData({
					cutL: this.cutL - dragLengthX,
					cutT: this.cutT - dragLengthY,
					cutR: this.cutR + dragLengthX,
					cutB: this.cutB + dragLengthY
				});

				this.pageinfo.PAGE_X = e.touches[0].pageX;
				this.pageinfo.PAGE_Y = e.touches[0].pageY;
			},

			contentTouchEnd() {},

			// 获取图片
			getImageInfo() {
				var _this = this;
				uni.showLoading({
					title: '图片生成中',
					mask: true
				});
				if (this.isSubmit) {
					return;
				}
				this.isSubmit = true;
				// 将图片写入画布
				const ctx = uni.createCanvasContext('myCanvas');
				ctx.drawImage(_this.imageSrc, 0, 0, this.pageinfo.IMG_REAL_W, this.pageinfo.IMG_REAL_H);
				ctx.draw(true, () => {
					// 获取画布要裁剪的位置和宽度   均为百分比 * 画布中图片的宽度    保证了在微信小程序中裁剪的图片模糊  位置不对的问题 canvasT = (_this.cutT / _this.cropperH) * (_this.imageH / pixelRatio)
					var canvasW = ((_this.cropperW - _this.cutL - _this.cutR) / _this.cropperW) * this.pageinfo
						.IMG_REAL_W;
					var canvasH = ((_this.cropperH - _this.cutT - _this.cutB) / _this.cropperH) * this.pageinfo
						.IMG_REAL_H;
					var canvasL = (_this.cutL / _this.cropperW) * this.pageinfo.IMG_REAL_W;
					var canvasT = (_this.cutT / _this.cropperH) * this.pageinfo.IMG_REAL_H;
					uni.canvasToTempFilePath({
						x: canvasL,
						y: canvasT,
						width: canvasW,
						height: canvasH,
						destWidth: canvasW,
						destHeight: canvasH,
						quality: 0.8,
						fileType: 'jpg',
						canvasId: 'myCanvas',
						success: res => {
							let day = new Date();
							let field = uni.getStorageSync("avatarField");
							if (!field) {
								field = "user";
							}
							//// 在H5平台下，tempFilePath 为 base64
							let p = [field, 'images', day.getFullYear(), day.getMonth() + 1, day
								.getDate(), day.getTime() + '.jpg'
							];
							let cloudPath = p.join('/');
							uni.showLoading({
								title: '图片上传中'
							});
							//上传到服务器
							cloudUploadFile(res.tempFilePath, cloudPath).then(url => {
								console.log("url", url)
								try {
									/* , {
										[field]: url
									} */
									// _this.getOpenerEventChannel().emit('addData')
									this.$prePage().editData({
										[field]: url
									})
								} catch (e) {
									console.log("getOpenerEventChannel fail", e)
								}
								this.$success('上传成功');
								setTimeout(() => {
									uni.navigateBack({
										delta: 1
									});
								}, 1500);
							}, err => {
								this.isSubmit = false;
								uni.showModal({
									title: '上传失败',
									showCancel: false
								});
							})
						}
					});
				});
			},

			// 设置大小的时候触发的touchStart事件
			dragStart(e) {
				this.pageinfo.T_PAGE_X = e.touches[0].pageX;
				this.pageinfo.T_PAGE_Y = e.touches[0].pageY;
				this.pageinfo.CUT_L = this.cutL;
				this.pageinfo.CUT_R = this.cutR;
				this.pageinfo.CUT_B = this.cutB;
				this.pageinfo.CUT_T = this.cutT;
			},

			// 设置大小的时候触发的touchMove事件
			dragMove(e) {
				var _this = this;
				var dragType = e.target.dataset.drag;
				switch (dragType) {
					case 'right':
						var dragLength = (this.pageinfo.T_PAGE_X - e.touches[0].pageX) * this.pageinfo.DRAFG_MOVE_RATIO;
						if (this.pageinfo.CUT_R + dragLength < 0) dragLength = -this.pageinfo.CUT_R;
						if (this.pageinfo.CUT_B + dragLength < 0) dragLength = -this.pageinfo.CUT_B;
						this.setData({
							cutR: this.pageinfo.CUT_R + dragLength,
							cutB: this.pageinfo.CUT_B + dragLength //1：1比例
						});
						break;
					case 'left':
						var dragLength = (this.pageinfo.T_PAGE_X - e.touches[0].pageX) * this.pageinfo.DRAFG_MOVE_RATIO;
						if (this.pageinfo.CUT_L - dragLength < 0) dragLength = this.pageinfo.CUT_L;
						if (this.pageinfo.CUT_L - dragLength > this.cropperW - this.cutR) dragLength = this.pageinfo
							.CUT_L - (this.cropperW -
								this.cutR);
						if (this.pageinfo.CUT_B - dragLength < 0) dragLength = this.pageinfo.CUT_B;

						this.setData({
							cutL: this.pageinfo.CUT_L - dragLength,
							cutB: this.pageinfo.CUT_B - dragLength //1：1比例
						});
						break;
					case 'top':
						var dragLength = (this.pageinfo.T_PAGE_Y - e.touches[0].pageY) * this.pageinfo.DRAFG_MOVE_RATIO;
						if (this.pageinfo.CUT_T - dragLength < 0) dragLength = this.pageinfo.CUT_T;
						if (this.pageinfo.CUT_T - dragLength > this.cropperH - this.cutB) dragLength = this.pageinfo
							.CUT_T - (this.cropperH -
								this.cutB);
						if (this.pageinfo.CUT_R - dragLength < 0) dragLength = this.pageinfo.CUT_R;

						this.setData({
							cutT: this.pageinfo.CUT_T - dragLength,
							cutR: this.pageinfo.CUT_R - dragLength //1：1比例
						});
						break;
					case 'bottom':
						var dragLength = (this.pageinfo.T_PAGE_Y - e.touches[0].pageY) * this.pageinfo.DRAFG_MOVE_RATIO;
						if (this.pageinfo.CUT_B + dragLength < 0) dragLength = -this.pageinfo.CUT_B;
						if (this.pageinfo.CUT_L + dragLength < 0) dragLength = -this.pageinfo.CUT_L;
						this.setData({
							cutB: this.pageinfo.CUT_B + dragLength,
							cutL: this.pageinfo.CUT_L + dragLength //1：1比例
						});
						break;
					case 'rightBottom':
						/* var dragLengthX = (this.pageinfo.T_PAGE_X - e.touches[0].pageX) * this.pageinfo.DRAFG_MOVE_RATIO;
						var dragLengthY = (this.pageinfo.T_PAGE_Y - e.touches[0].pageY) * this.pageinfo.DRAFG_MOVE_RATIO;

						if (this.pageinfo.CUT_B + dragLengthY < 0) dragLengthY = -this.pageinfo.CUT_B;
						if (this.pageinfo.CUT_R + dragLengthX < 0) dragLengthX = -this.pageinfo.CUT_R;
						let cutB = this.pageinfo.CUT_B + dragLengthY;
						let cutR = this.pageinfo.CUT_R + dragLengthX;

						this.setData({
							cutB: cutB,
							cutR: cutR
						}); */
						break;
					default:
						break;
				}
			}
		}
	};
</script>

<style>
	/* pages/uni-cropper/index.wxss */
	page {
		background: #000;
		height: 100%;
	}

	.container {
		height: 100%;
	}

	.uni-content-info {
		/* position: fixed;
		top: 0;
		left: 0;
		right: 0;
		bottom: 0;
		display: block;
		align-items: center;
		flex-direction: column; */
	}

	.cropper-config {
		padding: 40upx 0;
		position: absolute;
		bottom: 0;
		left: 0;
		width: 100%;
	}

	.cropper-content {
		min-height: 750rpx;
		width: 100%;
	}

	.uni-corpper {
		position: relative;
		overflow: hidden;
		-webkit-user-select: none;
		-moz-user-select: none;
		-ms-user-select: none;
		user-select: none;
		-webkit-tap-highlight-color: transparent;
		-webkit-touch-callout: none;
		box-sizing: border-box;
	}

	.uni-corpper-content {
		position: relative;
		overflow: hidden;
	}

	.uni-corpper-content image {
		display: block;
		width: 100%;
		min-width: 0 !important;
		max-width: none !important;
		height: 100%;
		min-height: 0 !important;
		max-height: none !important;
		image-orientation: 0deg !important;
		margin: 0 auto;
	}

	/* 移动图片效果 */

	.uni-cropper-drag-box {
		position: absolute;
		top: 0;
		right: 0;
		bottom: 0;
		left: 0;
		cursor: move;
		background: rgba(0, 0, 0, 0.6);
		z-index: 1;
	}

	/* 内部的信息 */

	.uni-corpper-crop-box {
		position: absolute;
		background: rgba(255, 255, 255, 0.3);
		z-index: 2;
	}

	.uni-corpper-crop-box .uni-cropper-view-box {
		position: relative;
		display: block;
		width: 100%;
		height: 100%;
		overflow: visible;
		outline: 1rpx solid #69f;
		outline-color: rgba(102, 153, 255, 0.75);
	}

	/* 横向虚线 */

	.uni-cropper-dashed-h {
		position: absolute;
		top: 33.33333333%;
		left: 0;
		width: 100%;
		height: 33.33333333%;
		border-top: 1rpx dashed rgba(255, 255, 255, 0.5);
		border-bottom: 1rpx dashed rgba(255, 255, 255, 0.5);
	}

	/* 纵向虚线 */

	.uni-cropper-dashed-v {
		position: absolute;
		left: 33.33333333%;
		top: 0;
		width: 33.33333333%;
		height: 100%;
		border-left: 1rpx dashed rgba(255, 255, 255, 0.5);
		border-right: 1rpx dashed rgba(255, 255, 255, 0.5);
	}

	/* 四个方向的线  为了之后的拖动事件*/

	.uni-cropper-line-t {
		position: absolute;
		display: block;
		width: 100%;
		background-color: #69f;
		top: 0;
		left: 0;
		height: 1rpx;
		opacity: 0.1;
		cursor: n-resize;
	}

	.uni-cropper-line-t::before {
		content: '';
		position: absolute;
		top: 50%;
		right: 0rpx;
		width: 100%;
		-webkit-transform: translate3d(0, -50%, 0);
		transform: translate3d(0, -50%, 0);
		bottom: 0;
		height: 41rpx;
		background: transparent;
		z-index: 11;
	}

	.uni-cropper-line-r {
		position: absolute;
		display: block;
		background-color: #69f;
		top: 0;
		right: 0rpx;
		width: 1rpx;
		opacity: 0.1;
		height: 100%;
		cursor: e-resize;
	}

	.uni-cropper-line-r::before {
		content: '';
		position: absolute;
		top: 0;
		left: 50%;
		width: 41rpx;
		-webkit-transform: translate3d(-50%, 0, 0);
		transform: translate3d(-50%, 0, 0);
		bottom: 0;
		height: 100%;
		background: transparent;
		z-index: 11;
	}

	.uni-cropper-line-b {
		position: absolute;
		display: block;
		width: 100%;
		background-color: #69f;
		bottom: 0;
		left: 0;
		height: 1rpx;
		opacity: 0.1;
		cursor: s-resize;
	}

	.uni-cropper-line-b::before {
		content: '';
		position: absolute;
		top: 50%;
		right: 0rpx;
		width: 100%;
		-webkit-transform: translate3d(0, -50%, 0);
		transform: translate3d(0, -50%, 0);
		bottom: 0;
		height: 41rpx;
		background: transparent;
		z-index: 11;
	}

	.uni-cropper-line-l {
		position: absolute;
		display: block;
		background-color: #69f;
		top: 0;
		left: 0;
		width: 1rpx;
		opacity: 0.1;
		height: 100%;
		cursor: w-resize;
	}

	.uni-cropper-line-l::before {
		content: '';
		position: absolute;
		top: 0;
		left: 50%;
		width: 41rpx;
		-webkit-transform: translate3d(-50%, 0, 0);
		transform: translate3d(-50%, 0, 0);
		bottom: 0;
		height: 100%;
		background: transparent;
		z-index: 11;
	}

	.uni-cropper-point {
		width: 5rpx;
		height: 5rpx;
		background-color: #69f;
		opacity: 0.75;
		position: absolute;
		z-index: 3;
	}

	.point-t {
		top: -3rpx;
		left: 50%;
		margin-left: -3rpx;
		cursor: n-resize;
	}

	.point-tr {
		top: -3rpx;
		left: 100%;
		margin-left: -3rpx;
		cursor: n-resize;
	}

	.point-r {
		top: 50%;
		left: 100%;
		margin-left: -3rpx;
		margin-top: -3rpx;
		cursor: n-resize;
	}

	.point-rb {
		left: 100%;
		top: 100%;
		-webkit-transform: translate3d(-50%, -50%, 0);
		transform: translate3d(-50%, -50%, 0);
		cursor: n-resize;
		width: 36rpx;
		height: 36rpx;
		background-color: #69f;
		position: absolute;
		z-index: 1112;
		opacity: 1;
	}

	.point-b {
		left: 50%;
		top: 100%;
		margin-left: -3rpx;
		margin-top: -3rpx;
		cursor: n-resize;
	}

	.point-bl {
		left: 0%;
		top: 100%;
		margin-left: -3rpx;
		margin-top: -3rpx;
		cursor: n-resize;
	}

	.point-l {
		left: 0%;
		top: 50%;
		margin-left: -3rpx;
		margin-top: -3rpx;
		cursor: n-resize;
	}

	.point-lt {
		left: 0%;
		top: 0%;
		margin-left: -3rpx;
		margin-top: -3rpx;
		cursor: n-resize;
	}

	/* 裁剪框预览内容 */

	.uni-cropper-viewer {
		position: relative;
		width: 100%;
		height: 100%;
		overflow: hidden;
	}

	.uni-cropper-viewer image {
		position: absolute;
		z-index: 2;
	}

	.buttons {
		position: fixed;
		bottom: 30rpx;
		width: 94%;
		left: 3%;
		z-index: 99;
	}
</style>
