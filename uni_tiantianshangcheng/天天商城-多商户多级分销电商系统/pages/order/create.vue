<template>
	<view class="container">
		<view class="head-bg" v-if="formData.needAddress"></view>
		<view class="line-panel bg-white border-radius" v-if="formData.needAddress">
			<view class="tabs">
				<view class="tab-header ti-flex text-center padding-12">
					<view class="flex-1">
						<text>快递配送</text>
					</view>
					<!-- <view class="flex-1 left-line tilt">
						<text>同城配送</text>
					</view> -->
				</view>
			</view>
			<view class="address padding-22" @click="navTo('/pages/address/list?source=settlement')">
				<view class="ti-flex padding-bottom-22" v-if="formData.address && formData.address._id">
					<tian-icons type="shouhuodizhi1" size="24"></tian-icons>
					<view class="margin-left-20 flex-1">
						<view class="padding-bottom-12">
							<text class="font-32">{{formData.address.name}}</text>
							<text class="margin-left-20 font-28">{{formData.address.mobile}}</text>
						</view>
						<view class="colorGray font-24">
							<text>{{formData.address.formatted_address}}</text>
							<text>{{formData.address.address}}</text>
						</view>
					</view>
					<tian-icons type="xiangyou1" color="#cccccc"></tian-icons>
				</view>
				<tian-empty v-else text="请选择收货地址" iconSize="36" mode="shouhuodizhi"></tian-empty>
			</view>
			<view class="line-box">
				<view v-for="(item,index) in 40" :key="index" class="line-icon"></view>
			</view>
		</view>
		<view class="cart-goods-list">
			<view v-for="(item,index) in formData.goodsList" :key="index" class="goods">
				<image :src="item.goods_thumb" mode="aspectFill" class="image-width-168 goods-image"></image>
				<view class="goods-content">
					<view class="title">
						<text>{{item.name}}</text>
					</view>
					<view v-if="item.sku_name">
						<text class="sub-title">{{item.sku_name}}</text>
					</view>
					<tian-goods-price :hasCart="false" :hasAmount="false" :readAmount="true" :value="item">
					</tian-goods-price>
				</view>
			</view>

			<uni-list class="margin-top-22">
				<uni-list-item title="买家留言" link :note="formData.remarks" clickable @click="changeComment">
				</uni-list-item>
				<uni-list-item title="优惠券" link :rightText="coupons" to="/pages/order/coupons"></uni-list-item>
				<uni-list-item title="发票" link :rightText="invoice" clickable @click="changeInvoice"></uni-list-item>
				<uni-list-item v-if="!formData.mustUseScore" title="使用积分" link :note="scoreText"
					:rightText="scoreResultText" clickable @click="changeScore"></uni-list-item>
			</uni-list>

			<uni-list class="margin-top-22">
				<uni-list-item title="商品小计" :rightText="goodsTotalText"></uni-list-item>
				<uni-list-item title="优惠" :rightText="discountText"></uni-list-item>
				<uni-list-item title="积分兑换" :rightText="scoreMoneyResultText"></uni-list-item>
				<uni-list-item title="运费" :rightText="freightText"></uni-list-item>
			</uni-list>
		</view>

		<view class="fix-bottom padding-22">
			<view class="">
				<text>合计:</text>
				<text class="price font-32">{{totalText}}</text>
			</view>
			<view class="padding-left-50">
				<button type="warn" class="padding-left-50 padding-right-50" @click="submit">确定下单</button>
			</view>
		</view>
		<uni-popup ref="scorePopup" type="dialog">
			<uni-popup-dialog mode="input" :value="formData.usedScore?formData.usedScore:''" message="成功消息" title="使用积分"
				placeholder="请输入使用数量" :duration="2000" @confirm="confirmEditScore"></uni-popup-dialog>
		</uni-popup>
		<uni-popup ref="remarkPopup" type="dialog">
			<uni-popup-dialog mode="input" :value="formData.remarks" message="成功消息" title="买家留言" placeholder="请输入留言"
				:duration="2000" @confirm="confirmEditComment"></uni-popup-dialog>
		</uni-popup>
		<tian-payment :value="order" ref="payment" @successed="paySuccess" @close="closePayment" :confirm="true">
		</tian-payment>
	</view>
</template>

<script>
	export default {
		data() {
			return {
				symbol: "￥",
				message: "无",
				coupons: "未选择",
				invoice: "不开发票",

				goodsTotal: 0,
				order: {

				},
				formData: {
					coupon: "", //优惠券ID
					invoice: "", //发票信息，英文分号隔开
					discount: 0,
					freight: 0,
					score: 0,
					total: 0,
					needAddress: false,
					mustUseScore: false,
					exchangePointsForCash: false,
					remarks: "无",
					delivery_type: "express",
					canUseScore: 0,
					usedScore: 0,
					score2moneyRate: 0,
					address: {},
					goodsList: []
				}
			}
		},
		computed: {
			freightText() {
				if (this.formData.freight == 0) {
					return "免运费";
				}
				return this.symbol + (this.formData.freight / 100).toFixed(2);
			},
			discountText() {
				return this.symbol + (this.formData.discount / 100).toFixed(2);
			},
			totalText() {
				let scoreMoney = 0;
				if (this.formData.exchangePointsForCash) {
					scoreMoney = (this.formData.usedScore * this.formData
						.score2moneyRate)
				}
				return ((this.goodsTotal - this.formData.discount) / 100 - scoreMoney).toFixed(2);
			},
			goodsTotalText() {
				return this.symbol + (this.goodsTotal / 100).toFixed(2);
			},
			scoreText() {
				return "总积分:" + this.formData.score + "，其中" + this.formData.canUseScore + "积分可用";
			},
			scoreResultText() {
				if (this.formData.usedScore < 1) {
					return "不使用";
				}
				return "已选择" + this.formData.usedScore + "积分";
			},
			scoreMoneyResultText() {
				return this.formData.usedScore + "";
			},
			userInfo() {
				return this.$store.state.user.userInfo;
			}
		},
		onShow() {
			//预结算,商品id，购物车,获取默认收货地址
			this.editData(this.getItemData())
			this.loadData()
		},
		onUnload() {
			//移除临时数据，防止污染前面的页面
			uni.removeStorage({
				key: this.itemDataKey
			})
		},
		methods: {
			loadData() {
				//获取默认收货地址，可用优惠券，默认发票信息，运费
				this.$request("mall/order/settlement", {
					...this.formData,
					address: undefined,
					goodsList: undefined
				}, {
					loading: true
				}).then(res => {
					this.editData(res);
					console.log("settlement res", res)
				}, err => {
					this.navTimeBack()
				})
				this.buildTotal()
			},
			buildTotal() {
				let total = 0;
				//本地计算商品总金额
				this.formData.goodsList.map(goods => {
					//享受会员价
					total += goods.price * goods.amount;
				})
				this.goodsTotal = total;
			},
			editData(item) {
				for (let key in item) {
					this.$set(this.formData, key, item[key]);
				}
				this.goodsTotal = item.total;
				// this.formData = Object.assign(this.formData, item);
			},
			changeScore() {
				if (this.userInfo.score < 1) {
					this.$message("积分不足")
					return false;
				}
				if (this.formData.canUseScore < 1) {
					this.$message("积分不可用")
					return false;
				}
				this.$refs.scorePopup.open()
			},
			confirmEditScore(val) {
				if (val < 0) {
					val = 0;
				}
				if (val > this.formData.canUseScore) {
					val = this.formData.canUseScore;
				}
				this.formData.usedScore = +val;
			},
			changeInvoice(){
				uni.showModal({
					editable:true,
					title:"请输入发票抬头",
					placeholderText:"请输入公司/个人名称",
					success: (res) => {
						if(res.confirm){
							console.log(res.content)
							this.invoice = res.content;
							this.formData.invoice = res.content;
						}
					}
				})
			},
			changeComment() {
				this.$refs.remarkPopup.open()
			},
			confirmEditComment(val) {
				this.formData.remarks = val;
			},
			submit() {
				if (this.formData.needAddress && !this.formData.address._id) {
					this.$message("收货地址不能为空")
					return;
				}
				if (!this.formData.goodsList) {
					this.$message("商品不能为空")
					return;
				}
				console.log({
					...this.formData,
					address: undefined,
					goodsList: undefined,
					submit: true,
					address_id: this.formData.address._id
				})
				//提交订单，并在当前页面弹出支付页面
				this.$request("mall/order/settlement", {
					...this.formData,
					address: undefined,
					goodsList: undefined,
					submit: true,
					address_id: this.formData.address._id
				}, {
					loading: true
				}).then(res => {
					//this.editData(res);
					console.log("settlement res", res)
					this.order = res;
					this.$refs.payment.open();
				}, err => {
					console.log("下单失败")
				})
			},
			closePayment() {},
			paySuccess(order) {
				console.log("pay success", order)
				if (order.id.indexOf(",") > -1) {
					uni.redirectTo({
						url: `/pages/order/order?type=undelivery`
					})
				} else {
					uni.redirectTo({
						url: `/pages/order/detail?id=` + order.id
					})
				}
			},
		}
	}
</script>

<style lang="scss">
	.container {
		padding: $uni-spacing-row-base;
	}

	.head-bg {
		background: $uni-red;
		height: 200rpx;
		position: absolute;
		left: 0;
		right: 0;
		top: 0;
	}

	.tab-header {
		background: #e6434047;
	}

	.line-panel {
		position: relative;
		z-index: 9;

		.line-box {
			position: absolute;
			left: 0;
			bottom: 0;
			flex-wrap: nowrap;
			width: 100%;
			height: 2px;
			overflow: hidden;
			display: flex;

			.line-icon {
				flex-shrink: 0;
				width: 8px;
				height: 2px;
				margin-right: 4px;
				background-color: #518def;
				transform: skewX(-45deg);

				&:nth-child(2n) {
					background-color: #e42311;
				}
			}
		}
	}

	.cart-goods-list {
		padding-bottom: calc(var(--window-bottom) + 120rpx);

		.goods {
			margin-top: 14rpx;
			background: $uni-bg-color;
			padding: 20rpx 12rpx 14rpx;
			display: flex;
			align-items: center;
			border-radius: $uni-border-radius-base;
		}

		.goods-image {
			display: inline-block;
			width: 138rpx;
			height: 138rpx;
			border-radius: 12rpx;
			margin-left: 22rpx;
		}

		.goods-content {
			flex: 1;
			margin-left: 24rpx;
			display: flex;
			flex-direction: column;
			justify-content: space-between;
		}

		.title {
			font-size: 28rpx;
		}

		.sub-title {
			font-size: 20rpx;
			padding: 6rpx 12rpx;
			border-radius: 6rpx;
			margin: 12rpx 0 18rpx;
			background: $uni-bg-color-grey;
			display: inline-block;
		}
	}

	.fix-bottom {
		bottom: 0;
		position: fixed;
		z-index: 9;
		left: 0;
		right: 0;
		background: $uni-bg-color;
		display: flex;
		justify-content: flex-end;
		align-items: center;
	}
</style>
