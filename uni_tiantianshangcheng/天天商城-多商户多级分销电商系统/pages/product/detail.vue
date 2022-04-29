<template>
	<view class="goods-detail-container" v-if="loaded">
		<page-meta>
			<navigation-bar :title="item.name" front-color="#000000" background-color="#ffffff"
				color-animation-timing-func="easeIn" />
		</page-meta>
		<uni-swiper-dot :info="item.goods_banner_imgs" :current="current" field="content" mode="round">
			<swiper class="swiper-box" @change="change" :current="current" :autoplay="true">
				<swiper-item v-for="(img,index) in item.goods_banner_imgs" :key="index">
					<image :src="img" mode="aspectFill" class="image"></image>
				</swiper-item>
			</swiper>
		</uni-swiper-dot>
		<view class="bg-white padding-24 padding-top-30">
			<tian-goods-price :hasCart="false" size="big" :value="item"></tian-goods-price>
			<view class="margin-top-22">
				<text class="font-32">{{item.name}}</text>
			</view>
			<view class="desc colorGray font-24 padding-bottom-18 padding-top-8" v-if="item.goods_summary">
				<text>{{item.goods_summary}}</text>
			</view>
			<view class="ti-flex between margin-top-22">
				<tian-icons v-if="item.is_real" type="wuliu" align="right" color="#787878"><text>运费：包邮</text>
				</tian-icons>
				<tian-icons type="tongji" align="right" color="#787878"><text>月售：{{item.month_sell_count}}</text>
				</tian-icons>
				<tian-icons type="kucun" align="right" color="#787878"><text>库存：{{item.remain_count}}</text>
				</tian-icons>
			</view>
		</view>
		<view class="bg-white padding-24 padding-top-30 margin-top-22" v-if="item.sku_name && item.sku_name.length>0">
			<view class="ti-flex" @click="openSku()">
				<text class="sub-title">已选</text>
				<text v-if="selectSku._id">{{selectSku.sku_name}}</text>
				<text v-else>请选择商品规格</text>
				<view class="flex-1">

				</view>
				<tian-icons type="xiangyou1" align="right" color="#787878"></tian-icons>
			</view>
		</view>
		<!-- 拼团 -->
		<view class="" v-if="item.group_buying && allGroupBuying.length>0">
			<view class="bg-white margin-top-22 ">
				<view class="ti-flex under-line sub-nav-title normal" @click="showMoreGb">
					<text class="flex-1">{{groupBuyingTotal}}人在拼单，可直接参与</text>
					<tian-icons type="xiangyou1" align="left" color="#787878">查看全部</tian-icons>
				</view>
				<groupBuyingPage :groupBuying="groupBuying" @click="btnGroupBuying"></groupBuyingPage>
			</view>
		</view>
		<!-- 店铺信息 -->
		<view class="bg-white ti-flex margin-top-22 padding-22" v-if="item.shop"
			@click="navTo('/pages/product/shop?id='+item.shop._id,item.shop)">
			<image :src="item.shop.src" mode="aspectFill" class="image-width-80 border-radius"></image>
			<view class="flex-1 margin-left-16">
				<text class="font-bold">{{item.shop.name}}</text>
				<view class="font-24">
					<text>评分</text>
					<text class="colorRed margin-left-4">{{item.shop.score_text}}</text>
					<text class="margin-left-10">月售</text>
					<text class="colorRed margin-left-4">{{item.shop.monthSale_text}}</text>
					<text class="margin-left-10">关注</text>
					<text class="colorRed margin-left-4">{{item.shop.focus_text}}</text>
					<text class="margin-left-4">人</text>
				</view>
			</view>
			<tian-icons type="xiangyou1"></tian-icons>
		</view>
		<view class="bg-white margin-top-22">
			<view class="sub-nav-title under-line ti-flex">
				<text>商品评价</text>
				<text v-if="item.comment_count">（{{item.comment_count}}）</text>
				<view class="flex-1">

				</view>

				<tian-icons type="xiangyou1" size="12" align="left"
					@click="navTo('/pages/product/comment?id='+item._id,item)">
					<text class="font-24 colorGray" style="font-weight: 400;">好评度{{item.commentGoodRate}}%</text>
				</tian-icons>

			</view>
			<view class="" v-if="item.comment_count">
				<view v-for="(comment,index) in item.comments" :key="index"
					class="margin-bottom-22 under-line padding-22">
					<view class="ti-flex">
						<image :src="comment.user.avatar" mode="aspectFill" class="user-avatar"></image>
						<view class="margin-left-12">
							<view class="">
								<text>{{comment.user.nickname}}</text>
							</view>
							<uni-rate size="12" :value="comment.rate" readonly class=""></uni-rate>
						</view>
					</view>
					<view class="font-24 margin-top-6 padding-lr-10">
						<text>{{comment.content}}</text>
					</view>
				</view>
			</view>
			<view v-else class="text-center padding-24">
				<text>暂无评价</text>
			</view>
		</view>
		<view class="bg-white margin-top-22" v-if="description && description.length>0">
			<view class="sub-nav-title under-line"><text>图文详情</text></view>
			<view v-for="(item,index) in description" :key="index">
				<j-video v-if="item.type=='video'" :url="item.content" height="220px" width="750rpx"></j-video>
				<rich-text v-else :nodes="item.content"></rich-text>
			</view>
		</view>
		<view class="bg-white margin-top-22">
			<view class="sub-nav-title under-line"><text>价格说明</text></view>
			<view class="padding-24">
				<text>权利说明：</text>
				<view v-for="(item,index) in quanyiDescription" :key="index" class="font-20 colorGray">
					<text>{{item}}</text>
				</view>
			</view>
			<view class="padding-24">
				<text>价格说明：</text>
				<view v-for="(item,index) in priceDescription" :key="index" class="font-20 colorGray">
					<text>{{item}}</text>
				</view>
			</view>
		</view>
		<tian-goods-sku v-if="loaded" :value="item" :group_buying_id="group_buying_id" :sid="defaultSkuId"
			ref="tianSkuPop" :isSubmitSku="isSubmitSku" @change="changeSku"></tian-goods-sku>
		<view class="goods-carts" v-if="loaded">
			<tian-goods-nav :options="bottomOptions" :buttonGroup="buttonGroup" :fill="true" @click="leftClick"
				@buttonClick="buttonClick">
			</tian-goods-nav>
		</view>
		<uni-popup ref="gbPopup" type="center" @change="changeGb">
			<view class="bg-white border-radius">
				<view class="closeGb">
					<tian-icons type="guanbi2" @click="closeGb()" size="26" class=""></tian-icons>
				</view>
				<scroll-view scroll-y="true" style="max-height: 300px;min-height: 200px;">
					<groupBuyingPage :groupBuying="allGroupBuying" @click="btnGroupBuying"></groupBuyingPage>
					<view class="padding-20 text-center font-20 colorGray"
						v-if="allGroupBuying.length==maxShowAllGroupBuying">
						<text>仅显示{{maxShowAllGroupBuying}}个可参与的拼单</text>
					</view>
				</scroll-view>
			</view>
		</uni-popup>
	</view>
</template>

<script>
	const db = uniCloud.database();
	import tabbarMixin from '../index/mixin/tabbar';
	import groupBuyingPage from './components/group-buying.vue';
	import mpShareMixin from '@/common/mixin/share/mp';
	export default {
		mixins: [tabbarMixin, mpShareMixin],
		components: {
			groupBuyingPage,
		},
		data() {
			return {
				loaded: false,
				current: 0,
				bottomOptions: [],
				buttonGroup: [],
				selectSku: {},
				defaultSkuId: "",
				group_buying_id: "",
				item: {},
				description: [],
				allGroupBuying: [],
				groupBuying: [],
				groupBuyingTotal: 0,
				maxShowAllGroupBuying: 10,
				isSubmitSku: 0
			};
		},
		onLoad(e) {
			//只有商品id
			this.item = this.getItemData();
			if (!this.item) {
				this.item = {}
			}
			if (this.item._id) {
				this.loaded = true;
			}
			if (e.id) {
				this.item._id = e.id;
			}
			//默认选中规格
			if (e.sku) {
				this.defaultSkuId = e.sku;
			}
			//临时用一下轮播图
			if (this.item.goods_thumb) {
				this.item.goods_banner_imgs = [this.$thumbImg(this.item.goods_thumb, '750x750')];
			}
			this.loadData()
		},
		//下拉刷新
		onPullDownRefresh() {
			console.log('刷新整页');
			uni.stopPullDownRefresh();
			this.current = 0;
			this.updateBottomOptions();
			this.loadData()
		},
		onShow() {
			if (this.loaded) {
				this.getGroupBuying();
			}
		},
		computed: {
			quanyiDescription() {
				if (this.$store.state.app.customer.goods && this.$store.state.app.customer.goods.priceDescription.quanyi) {
					return this.$store.state.app.customer.goods.priceDescription.quanyi
				}
				return []
			},
			priceDescription() {
				if (this.$store.state.app.customer.goods && this.$store.state.app.customer.goods.priceDescription.price) {
					return this.$store.state.app.customer.goods.priceDescription.price
				}
				return []
			},
		},
		methods: {
			loadData() {
				db.action("goods_member,check_goods_favorite,goods_visite").collection("opendb-mall-goods")
					.where(
						`_id=="${this.item._id}"`).field(
						"goods_sn,name,shop_id,keywords,comments,comment_total_rate,goods_desc,goods_thumb,goods_summary,goods_banner_imgs,price,market_price,sku_name,is_vip,remain_count,month_sell_count,total_sell_count,comment_count,is_real,is_on_sale,is_alone_sale,is_best,is_new,is_hot,add_date,last_modify_date,use_score,use_score_rate,group_buying,group_buying_discount"
					).get({
						getOne: true
					}).then(({
						result
					}) => {
						this.description = [];
						//处理商品图文混排
						if (result.data.goods_desc && result.data.goods_desc.length > 0) {
							let imgsExtRegex = new RegExp("(.jpg|.png|.jpeg|.gif)$");
							let videoExtRegex = new RegExp("(.mp4|.wma|.3gp)$");
							//如果是http开头的，是资源文件，可能是图片、视频
							let contents = [];
							result.data.goods_desc.map(e => {
								if (e.indexOf("http") > -1) {
									if (videoExtRegex.test(e.toLowerCase())) {
										if (contents.length > 0) {
											this.description.push({
												type: "html",
												content: contents.join("")
											})
										}
										contents = [];
										this.description.push({
											type: "video",
											content: e
										})
										return;
									}
									//可能存在没有后缀的图片
									contents.push(`<img src="${e}" style="width:100%;display:block;"/>`);
									return;
								}
								contents.push(`<p style="padding:12px;">${e}</p>`);
							});
							if (contents.length > 0) {
								this.description.push({
									type: "html",
									content: contents.join("")
								})
							}
							console.log(this.description)
						}
						//封面图填充为第一张轮播图，显示效果最佳
						if (!result.data.goods_banner_imgs) {
							result.data.goods_banner_imgs = []
							result.data.goods_banner_imgs.unshift(result.data.goods_thumb)
						}
						this.item = result.data;
						this.loaded = true;
						this.buildData();
						this.updateBottomOptions()
						this.getGroupBuying();
					});
				this.updateBottomOptions();
				if (this.$store.state.app && this.$store.state.app.customer && this.$store.state.app.customer
					.maxShowAllGroupBuying) {
					this.maxShowAllGroupBuying = this.$store.state.app.customer.maxShowAllGroupBuying
				}
			},
			buildData(item) {
				//处理轮播图
				if (this.item.goods_banner_imgs) {
					this.item.goods_banner_imgs = this.item.goods_banner_imgs.map(img => {
						return this.$thumbImg(img, '750x750');
					})
				}
			},
			/**
			 * 商品拼单信息
			 */
			getGroupBuying() {
				if (!this.item.group_buying) {
					return;
				}
				let info = this.$store.state.user.userInfo;
				db.collection("opendb-mall-goods-group-buying,uni-id-users").where(
						`goods_id=="${this.item._id}" && state==1`)
					.field(
						"group_id,user_id.avatar,user_id._id,user_id.nickname,end_time").orderBy("create_time asc").get()
					.then(({
						result
					}) => {
						console.log(result)
						//分组
						let dataMap = {};
						this.groupBuyingTotal = 0;
						result.data.map(item => {
							//处理用户数据
							let userinfo = this.buildUserInfo(item.user_id[0]);
							if (!dataMap[item.group_id]) {
								dataMap[item.group_id] = {
									avatar: [],
									nickname: [],
									id: item.group_id,
									enable: true,
									index: this.item.group_buying,
									amount: this.item.group_buying,
								}
							}
							dataMap[item.group_id].index--;
							//不能自己给自己拼单 
							if (userinfo._id == info._id) {
								dataMap[item.group_id].enable = false;
								dataMap[item.group_id].index += 1000;
							}
							dataMap[item.group_id].avatar.push(userinfo.avatar)
							dataMap[item.group_id].nickname.push(userinfo.nickname)
							dataMap[item.group_id].amount--;
							this.groupBuyingTotal++;
						})
						this.allGroupBuying = [];
						//所有拼单
						let gb = [];
						for (let id in dataMap) {
							if (this.allGroupBuying.length < this.maxShowAllGroupBuying) {
								this.allGroupBuying.push(dataMap[id]);
							}
						}
						//按参与人数排序
						this.allGroupBuying.sort((a, b) => {
							return a.index - b.index;
						})
						//外面只显示2条
						this.allGroupBuying.map(g => {
							if (gb.length < 2) {
								gb.push(g);
							}
						})
						//只显示2条
						this.groupBuying = gb;
					})
			},
			updateBottomOptions() {
				let options = [{
					icon: 'dianpu',
					text: '首页',
				}];
				if (this.item.is_fav) {
					options.push({
						icon: 'biaoxingfill',
						color: "#ff5a1d",
						text: '已收藏'
					})
				} else {
					options.push({
						icon: 'biaoxing',
						color: "#646566",
						text: '收 藏'
					})
				}
				options.push({
					icon: 'gouwuche',
					text: '购物车',
					// info: this.cartCount
				})
				this.bottomOptions = options;
				this.buttonGroup = [{
						text: '加入购物车',
						backgroundColor: '#ffa200',
						color: '#fff'
					},
					{
						text: '立即购买',
						backgroundColor: '#ff0000',
						color: '#fff'
					}
				];
				if (this.item.group_buying) {
					this.buttonGroup = [{
						text: '立即购买',
						backgroundColor: '#aeaeae',
						color: '#fff'
					}, {
						text: '拼单购买',
						backgroundColor: '#e64340',
						color: '#fff'
					}];
				} else if (!this.item.is_real) {
					this.buttonGroup = [{
						text: '立即购买',
						backgroundColor: '#ff0000',
						color: '#fff'
					}];
				}
			},
			saveFav() {
				if (!this.isLogin) {
					this.navToLoginNotice()
					return;
				}
				this.$request("mall/goods/favorite", {
					goods_id: this.item._id,
					isFav: !this.item.is_fav
				}, {
					loading: true
				}).then(res => {
					this.item.is_fav = res;
					console.log("fav result", res)
					this.updateBottomOptions()
					this.$success(res ? "收藏成功" : "取消成功")
				})
			},
			change(e) {
				this.current = e.detail.current;
			},
			resetTabCartCount() {
				console.log("resetTabCartCount")
				this.updateBottomOptions()
			},
			leftClick(e) {
				if (e.index == 0) {
					uni.switchTab({
						url: "/pages/index/index"
					})
				} else if (e.index == 1) {
					//收藏
					this.saveFav()
				} else {
					// 跳转购物车
					uni.switchTab({
						url: "/pages/index/cart"
					})
				}
			},
			/**
			 * 点加入购物车或者立即购买打开规格弹窗
			 */
			buttonClick(e) {
				console.log("buttonClick", e.index, this.item)
				//订单类型：0加入购物车，1直接购买，2拼单购买，3虚拟商品购买
				this.isSubmitSku = e.index + 1;
				if (this.item.group_buying) {
					this.isSubmitSku = e.index + 2;
					this.group_buying_id = ""
				} else if (!this.item.is_real) {
					//非实物购买
					this.isSubmitSku = 4;
				}
				console.log("this.isSubmitSku", this.isSubmitSku)
				this.$refs.tianSkuPop.open();
			},
			/**
			 * 直接打开规格弹窗
			 */
			openSku() {
				this.isSubmitSku = 0;
				this.$refs.tianSkuPop.open();
			},
			changeSku(sku) {
				console.log("changeSku", sku)
				this.selectSku = sku;
			},
			showMoreGb() {
				if (this.allGroupBuying.length > 0) {
					this.$refs.gbPopup.open();
				}
			},
			closeGb() {
				this.$refs.gbPopup.close();
			},
			changeGb(e) {
				// console.log("changeGb", e)
			},
			btnGroupBuying(id) {
				this.$refs.gbPopup.close();
				this.isSubmitSku = 4;
				this.group_buying_id = id;
				this.$refs.tianSkuPop.open();
			}
		}
	}
</script>

<style lang="scss">
	.goods-detail-container {
		padding-bottom: 120rpx;

		.swiper-box {
			height: 750rpx;
		}

		.image {
			width: 750rpx;
			height: 750rpx;
		}

		.goods-carts {
			display: flex;
			flex-direction: column;
			position: fixed;
			z-index: 101;
			left: 0;
			right: 0;
			left: var(--window-left);
			right: var(--window-right);
			bottom: 0;
		}

		.sub-title {
			width: 88rpx;
			color: #aaaaaa;
		}

		.sub-nav-title {
			padding: 18rpx 24rpx 18rpx;
			font-weight: 600;

			&.normal {
				font-weight: normal;
			}
		}

		.user-avatar {
			position: relative;
			z-index: 100;
		}

		.more-avatar {
			margin-left: -30rpx;
		}
	}

	.closeGb {
		position: absolute;
		right: -14px;
		top: -14px;
	}
</style>
