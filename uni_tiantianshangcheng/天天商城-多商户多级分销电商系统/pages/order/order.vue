<template>
	<view class="">
		<view class=" tab-header">
			<view class="ti-flex">
				<view v-for="(item,index) in tabList" :key="index" class="tabs flex-1 text-center"
					@click="changeTab(item)" :class="{current:item.checked}">
					<text>{{item.text}}</text>
				</view>
			</view>
		</view>
		<view class="tab-header-seize"></view>
		<unicloud-db ref="udb" v-slot:default="{data, loading, error, options,hasMore}" collection="tian-mall-orders"
			action="check_order" @load="loadData"
			field="state,goods,discount,freight,address,delivers,pickUpCode,total_fee,cart_count,create_time,group_buying"
			:where="where" :options="options" orderby="create_time desc" manual>
			<tian-empty v-if="!loading && data.length == 0" text="暂时还没有订单" marginTop="300"></tian-empty>
			<view class="padding-lr-20 " v-else>
				<view v-for="(item,index) in data" :key="index" class=" bg-white border-radius margin-top-22">
					<view class="under-line padding-22" @click="navTo('/pages/order/detail?id='+item._id,item)">
						<view class="ti-flex between">
							<uni-dateformat class="font-20" :date="item.create_time" format="yyyy/MM/dd hh:mm:ss"
								:threshold="[0, 0]"></uni-dateformat>
							<text :style="{color: item.state.color}">{{item.state.text}}</text>
						</view>
						<view v-for="(goods,index2) in item.goods" :key="index2" class="ti-flex margin-top-12">
							<image :src="goods.goods_thumb" mode="aspectFill" class="image-width-120 border-radius">
							</image>
							<view class="flex-1 padding-left-12">
								<view class="">
									<text>{{goods.name}}</text>
								</view>
								<view class="">
									<text class="font-24">{{goods.sku_name}}</text>
								</view>
								<view class="ti-flex between">
									<view class="">
										<text class="price">{{goods.price/100}}</text>
										<text v-if="goods.use_score"
											class="font-20">+{{goods.use_score}}{{scoreName}}</text>
									</view>
									<text class="">x{{goods.amount}}</text>
								</view>
							</view>
						</view>
					</view>
					<view class="" v-if="item.pickUpCode">
						<view class="ti-flex font-32 padding-lr-24 padding-top-10">
							<text class="flex-1">账号</text>
							<text class="flex-1">密码</text>
						</view>
						<view class="ti-flex font-32 padding-lr-24 padding-top-10 colorRed"
							v-for="(puc,index2) in item.pickUpCode" :key="index2">
							<text class="flex-1">{{puc.account}}</text>
							<text class="flex-1">{{puc.password}}</text>
							<text v-if="puc.isUse">已使用</text>
							<text v-else class="colorGreen">未使用</text>
						</view>
					</view>
					<view class="padding-lr-22 padding-bottom-12">
						<view class="margin-top-12" v-if="item.hasMoreGoods">
							<button type="primary" size="mini" @click="showMore(item,1)"
								v-if="item.showGoodsType==0">更多商品</button>
							<button type="default" size="mini" @click="showMore(item,0)"
								v-if="item.showGoodsType==1">收起商品</button>
						</view>
						<view class="font-24 text-right margin-top-12">
							<text>共{{item.cart_count}}件商品，总金额</text>
							<text class="price font-32 margin-right-0">{{item.total_fee/100}}</text>
							<block v-if="item.discount>0">
								<text>，优惠</text>
								<text class="price font-32 margin-right-0">{{item.discount/100}}</text>
							</block>
						</view>
						<view class="font-24 text-right margin-top-12 colorBlue" v-if="item.delivers">
							<view v-for="(deli,index2) in item.delivers" :key="index2" v-if="deli.company">
								<text>{{deli.company}}：</text>
								<text>{{deli.number}}</text>
							</view>
						</view>
						<view class="font-24 text-right margin-top-12">
							<button type="default" v-if="item.canCancel" size="mini" class="margin-right-16"
								@click="cancelOrder(item)">取消订单</button>
							<button type="default" size="mini" v-if="item.state.value == -1"
								@click="deleteOrder(item)">删除订单</button>
							<block v-if="item.state.value == 0">
								<button type="primary" size="mini" @click="payOrder(item)">去支付</button>
							</block>
							<block v-if="item.state.value == 2">
								<button type="primary" size="mini" @click="finishOrder(item)">确定收货</button>
							</block>						
						</view>
					</view>

				</view>
			</view>
			<uni-load-more v-if="loading || hasMore" :status="loading?'loading':(hasMore ? 'more' : 'noMore')">
			</uni-load-more>
		</unicloud-db>

		<tian-payment :value="order" ref="payment" @success="paymentSuccess" @close="closePayment" :confirm="false">
		</tian-payment>
	</view>
</template>

<script>
	export default {
		data() {
			return {
				maxGoodsLength: 3,
				type: "all",
				where: "user_id==$cloudEnv_uid && is_delete==0",
				order: {},
				tabList: [],
				options: {}
			};
		},
		onLoad(e) {
			this.type = e.type
			this.initTabs();
			this.buildCondition();
		},
		onReady() {
			this.$refs.udb.loadData()
		},
		// 页面生命周期，下拉刷新后触发
		onPullDownRefresh() {
			this.$refs.udb.loadData({
				clear: true
			}, () => {
				// 停止下拉刷新
				uni.stopPullDownRefresh()
			})
		},
		onReachBottom() {
			this.$refs.udb.loadMore();
		},
		computed: {
			scoreName() {
				return this.$store.state.app.customer.scoreName;
			}
		},
		methods: {
			loadData(data) {
				data.forEach(item => {
					if (item.goods) {
						item.goods.forEach(goods => {
							goods.goods_thumb = this.$thumbImg(goods.goods_thumb, '168x168')
						})
						item.hasMoreGoods = false;
						if (item.goods.length > 3) {
							item.origin_goods = item.goods;
							item.goods = item.goods.filter((e, index) => index < this.maxGoodsLength);
							item.hasMoreGoods = true;
							item.showGoodsType = 0;
						}
					}
				})
			},
			showMore(item, type) {
				if (type) {
					item.goods = item.origin_goods
				} else {
					item.goods = item.goods.filter((e, index) => index < this.maxGoodsLength);
				}
				item.showGoodsType = type;
			},
			buildCondition() {
				let base = "user_id==$cloudEnv_uid && is_delete==0";
				let tab = this.tabList.filter(e => e.type == this.type);
				if (tab && tab.length > 0 && tab[0].condition) {
					base += " &&" + tab[0].condition;
				}
				console.log(base)
				this.where = base;
			},
			changeTab(item) {
				this.type = item.type;
				this.tabList.forEach(e => {
					e.checked = e.type == item.type;
				})
				this.buildCondition();
			},
			initTabs() {
				let tabs = [{
					type: "all",
					text: "全部",
					condition: "",
				}, {
					type: "unpay",
					text: "待付款",
					condition: "state==0",
				}, {
					type: "undelivery",
					text: "待发货",
					condition: "state==1",
				}, {
					type: "unreceived",
					text: "待收货",
					condition: "state==2",
				}, {
					type: "finish",
					text: "已完成",
					condition: "state==3",
				}];
				this.tabList = tabs.map(e => {
					e.checked = e.type == this.type;
					return e;
				})
			},
			payOrder(item) {
				item.module = "mall";
				this.order = item;
				this.$refs.payment.open();
			},
			finishOrder(item) {
				this.confirmAction(() => {
					this.$request("mall/order/finish", {
						id: item._id
					}, {
						loading: true
					}).then(res => {
						this.$success("订单收货成功")
						this.reLoadData()
					})
				}, "是否确定收到货物？否则钱财两空。")
			},
			deleteOrder(item) {
				this.$refs.udb.remove(item._id, {
					action: "backup",
					success: (res) => { // 更新成功后的回调
						this.$success("订单删除成功")
						this.reLoadData()
					}
				})
			},
			cancelOrder(item) {
				this.confirmAction(() => {
					//取消订单，并返回上一页
					this.$request('payment/cancel', {
						id: item._id,
						module: "mall"
					}).then(res => {
						this.$message('取消成功');
						this.reLoadData()
					});
				}, "是否确定取消订单？")

			},
			closePayment() {},
			paymentSuccess(item) {
				console.log("支付成功，刷新列表")
				this.$refs.udb.loadData({
					clear: true
				})
			},
			reLoadData() {
				setTimeout(() => {
					this.$refs.udb.loadData({
						clear: true
					})
				}, 2000)
			}
		}
	}
</script>

<style lang="scss">
	page {
		height: 100%;
	}

	.tab-header {
		background: $uni-bg-color;
		padding: $uni-spacing-row-base 10rpx 10rpx;
		position: fixed;
		top: var(--window-top);
		left: 0;
		right: 0;
		z-index: 9;

		.tabs {
			padding-bottom: 12rpx;
			font-size: 30rpx;
			position: relative;
			margin-left: 12rpx;
			align-self: baseline;
			overflow: visible;
			white-space: nowrap;
		}

		.current {
			color: $uni-red;
			font-weight: 600;
			position: relative;

			&::after {
				content: " ";
				border-bottom: 4rpx solid $uni-red;
				position: absolute;
				left: 50%;
				right: 4rpx;
				bottom: 0;
				width: 60rpx;
				margin-left: -30rpx;
			}
		}
	}

	.tab-header-seize {
		height: 80rpx;
	}
</style>
