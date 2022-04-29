<template>
	<view class="cart-goods-list-container">
		<tian-empty v-if="!isLogin || (emptyData)" text="购物车空空如也"></tian-empty>
		<view class="cart-goods-list">
			<checkbox-group @change="change">
				<view v-for="(shopItem,index0) in shopDataList" :key="index0" class="margin-top-20">
					<view class="ti-flex font-24" @click="navTo('/pages/product/shop?id='+shopItem._id,shopItem)">
						<image :src="shopItem.src" mode="aspectFill" class="image-width-46 border-radius"></image>
						<text class="margin-left-16">{{shopItem.name}}</text>
						<tian-icons type="xiangyou1" size="14" color="#cccccc" class="margin-left-16"
							style="display: block;"></tian-icons>
					</view>
					<view v-for="(item,index) in shopItem.children" :key="index" class="goods">
						<checkbox :value="item._id" :checked="options.ids.indexOf(item._id)!=-1"></checkbox>
						<image :src="item.goods_thumb" mode="aspectFill" class="image-width-168 goods-image"
							@click="navToDetail(item)"></image>
						<view class="goods-content">
							<view class="title" @click="navToDetail(item)">
								<text>{{item.name}}</text>
							</view>
							<view>
								<text class="sub-title" v-if="item.sku_name">{{item.sku_name}}</text>
								<text class="sub-title colorRed margin-left-10"
									v-if="item.subTitle">{{item.subTitle}}</text>
							</view>
							<tian-goods-price :hasCart="false" :hasAmount="true" :value="item" @change="changeAmount">
							</tian-goods-price>
						</view>
					</view>
				</view>
			</checkbox-group>
		</view>
		<view class="cart-options" v-if="isLogin && !emptyData">
			<label @click="selectAll">
				<checkbox value="all" :checked="isSelectAll"></checkbox>全选
			</label>
			<button type="primary" size="mini" :disabled="btnDisenable" @click="deletes"
				class="margin-left-20">删除</button>
			<view class="flex-1">

			</view>
			<view class="total">
				<text>总计</text>
				<text class="price">{{total/100}}</text>
			</view>
			<button type="warn" size="mini" :disabled="btnDisenable"
				@click="submit">去结算({{options.ids.length}})</button>
		</view>
	</view>
</template>

<script>
	const db = uniCloud.database();
	import tabbarMixin from './mixin/tabbar'
	export default {
		mixins: [tabbarMixin],
		data() {
			return {
				total: 0,
				idList: [], //购物车id总计
				idTotalList: {}, //购物车单条总价统计
				amountList: {}, //购物车数量列表
				timerId: null,
				selectIdKey: "mall_cart_select_ids",
				options: {
					ids: []
				},
				shopDataList: {},
				dataList: [],
				emptyData: true,
				isSelectAll: false,
			};
		},
		onLoad() {
			uni.$on("refreshCart", () => {
				//刷新购物车
				this.refreshData()
			})
		},
		//下拉刷新
		onPullDownRefresh() {
			console.log('刷新购物车整页');
			uni.stopPullDownRefresh();
			this.refreshData()
		},
		onShow() {
			console.log("cart onShow")
			this.refreshData()
		},
		computed: {
			btnDisenable() {
				return this.options.ids.length == 0;
			}
		},
		methods: {
			refreshData() {
				console.log("this.isLogin", this.isLogin)
				if (!this.isLogin) {
					//重置所有基础数据
					this.loadData([])
					return;
				}
				db.action("goods_member,cart_goods").collection("opendb-mall-cart,opendb-mall-goods,opendb-mall-sku")
					.where("user_id == $cloudEnv_uid").field(
						"goods_id{_id as goods_id, name as goods_name,goods_thumb,price,market_price,is_vip,shop_id,remain_count as stock,is_real,is_on_sale,is_alone_sale,is_best,is_new,is_hot,use_score,use_score_rate},sku_id{_id as sku_id,sku_name,price,market_price,stock},price,goods_name,sku_name,amount,goods_thumb,update_date"
					).orderBy("update_date desc").limit(200).get().then(({
						result
					}) => {
						this.loadData(result.data)
						this.dataList = result.data;
					})
			},
			loadData(data) {
				let total = 0;
				this.idList = [];
				this.shopDataList = {};
				//上次默认选中id
				let selectIds = uni.getStorageSync(this.selectIdKey);
				this.options.ids = selectIds ? selectIds : [];
				this.amountList = {};
				this.isSelectAll = false;

				this.emptyData = data.length == 0;
				console.log("this.emptyData", this.emptyData)
				let shopDataMap = {}
				//处理图片尺寸 | thumbImg('80x80')
				data.forEach(item => {
					this.idList.push(item._id);
					this.idTotalList[item._id] = item.price * item.amount;
					this.amountList[item._id] = item.amount;
					//最多30个字
					item.name = item.goods_name ? item.goods_name.substr(0, 30) : "";
					item.goods_thumb = this.$thumbImg(item.goods_thumb, '168x168');
					if (item.stock < item.amount) {
						item.subTitle = "库存不足"
					}
					total += item.amount;
					if (item.shop_id) {
						if (!shopDataMap[item.shop_id]) {
							shopDataMap[item.shop_id] = {
								...item.shop,
								children: []
							}
						}
						shopDataMap[item.shop_id].children.push(item)
					}
				})
				this.shopDataList = shopDataMap;
				//this.options.ids 交集
				this.options.ids = this.options.ids.filter(id => this.idList.indexOf(id) != -1);
				this.isSelectAll = this.options.ids.length == this.idList.length;
				this.$store.commit('mall/UPDATE_CART_NUMBER', +total);
				this.catTotal();
				console.log("loadData", total, data)
			},
			navToDetail(item) {
				this.navTo(`/pages/product/detail?id=${item.goods_id}&sku=${item.sku_id}`, {
					...item,
					sku_name: undefined,
					_id: item.goods_id
				})
			},
			change(e) {
				// console.log("checkbox change", e.detail.value)
				this.isSelectAll = e.detail.value.length == this.idList.length;
				this.options.ids = e.detail.value;
				this.catTotal();
				uni.setStorage({
					key: this.selectIdKey,
					data: this.options.ids
				})
			},
			changeAmount(item) {
				if (!this.isLogin) {
					return;
				}
				// console.log("changeAmount", item.amount, this.amountList[item._id])
				//数量没有改变
				if (item.amount == this.amountList[item._id]) {
					return false;
				}
				//递增或者递减
				this.$store.commit('mall/INCREMENT_CART_NUMBER', item.amount - this.amountList[item._id]);
				this.amountList[item._id] = +item.amount;
				//更新数据库
				db.collection("opendb-mall-cart").where({
					_id: item._id,
					user_id: db.env.uid
				}).update({
					amount: +item.amount
				})
				this.catTotal();
			},
			selectAll() {
				this.isSelectAll = !this.isSelectAll;
				if (this.isSelectAll) {
					this.options.ids = this.idList;
				} else {
					this.options.ids = []
				}
				this.catTotal();
				// console.log("selectAll", this.options.ids)
				uni.setStorage({
					key: this.selectIdKey,
					data: this.options.ids
				})
			},
			catTotal() {
				let total = 0;
				this.options.ids.map(id => {
					total += this.idTotalList[id];
				})
				this.total = total;
			},
			deletes() {
				// 删除购物车
				this.confirmAction(() => {
					this.$request("mall/cart/remove", {
						ids: this.options.ids
					}, {
						loading: true
					}).then(result => {
						console.log(result)
						this.$success("删除成功")
						this.refreshData()
					})
				}, "是否确定删除？")
			},
			submit() {
				if (this.options.ids.length == 0) {
					return;
				}
				// console.log("this.dataList", this.dataList)
				//检查库存
				if (this.dataList.filter(e => this.options.ids.indexOf(e._id) != -1 && e.stock < e.amount).length > 0) {
					this.$message("商品库存不足")
					return;
				}
				console.log("this.options.ids", this.options.ids)
				this.navTo("/pages/order/create", {
					type: "cart",
					cart_ids: this.options.ids,
					goodsList: this.dataList.filter(e => this.options.ids.indexOf(e._id) != -1)
				});
			}
		}
	}
</script>

<style lang="scss">
	page {
		height: 100%;
	}

	.cart-goods-list-container {
		height: 100%;

		.cart-options {
			position: fixed;
			bottom: var(--window-bottom);
			left: 0;
			right: 0;
			background: $uni-bg-color;
			display: flex;
			align-items: center;
			padding: $uni-spacing-row-base;
		}
	}

	.cart-goods-list {
		padding: 10rpx 26rpx 10rpx 16rpx;
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
			margin-top: 12rpx;
			background: $uni-bg-color-grey;
			display: inline-block;
		}
	}
</style>
