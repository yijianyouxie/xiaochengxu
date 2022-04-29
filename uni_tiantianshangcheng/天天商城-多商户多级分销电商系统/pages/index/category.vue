<template>
	<view class="flex-column container">
		<view class="search under-line padding-bottom-12" id="search" :style="searchStyle">
			<tian-search-bar placeholder="搜索商品" bg_color="#f5f5f5" :disabled="true"
				@click="navTo('/pages/search/search')" style="padding-top:12rpx ;"></tian-search-bar>
		</view>
		<view class="main-category-panel-all padding-top-12">
			<view class="">
				<scroll-view class="scroll-view_W" scroll-y="true">
					<view v-for="(item, index) in categories" :key="index" @click="changeMainCategory(item)"
						class="item" :class="[item.className]" :id="'sub_'+item._id">
						<view class="font-26 text">
							<text>{{ item.name }}</text>
						</view>
					</view>
				</scroll-view>
			</view>
			<view class="flex-1 content" :class="['main-index'+mainCategory.index]">
				<!-- 主分类图广告 -->
				<view class="padding-left-32">
					<image :src="mainCategory.ad_banner" mode="aspectFill" class="cate-ad" @click="adClick"></image>
				</view>
				<view class="sub-category">
					<!-- 二级分类导航 -->
					<scroll-view scroll-x="true" class="scroll-view_H">
						<view v-for="(item,index) in subCategories" :key="index" class="scroll-view-item_H item">
							<text>{{item.name}}</text>
						</view>
					</scroll-view>
				</view>
				<scroll-view scroll-y="true" class="scroll-h3 padding-left-20" @scroll="subCategoryScroll">
					<view class="third-category">
						<view v-for="(item,index) in subCategories" :key="index" class="item">
							<view class="title">
								<text class="">{{item.name}}</text>
							</view>
							<view class="sub-items">
								<view v-for="(item2,index2) in item.children" :key="index2" class="sub-item"
									@click="loadList(item2.name)">
									<image :src="item2.icon" mode="aspectFill" class="image"></image>
									<text>{{item2.name}}</text>
								</view>
							</view>
						</view>
					</view>
				</scroll-view>
			</view>
		</view>
		<tian-goods-sku :value="goods" ref="tianSkuPop"></tian-goods-sku>
	</view>
</template>

<script>
	const db = uniCloud.database();
	import tabbarMixin from './mixin/tabbar'
	export default {
		mixins: [tabbarMixin],
		data() {
			return {
				goods: {},
				mainCategory: {},
				categories: [],
				subCategories: [],
				subCateHeight: 100,
				options: {
					scrollLeft: 0,
					scrollTop: 0,
					sv: "",
					mainCurrentId: "",
					subCurrentId: ""
				}
			};
		},
		onLoad(e) {
			if (e.id) {
				this.options.mainCurrentId = e.id;
			}
			//选中主分类触发器
			/* uni.$on('changeMainCid', (e) => {
				//默认选中id,没有点击分类之前，是没有这个事件的
				this.changeMainCategory({
					_id: e
				})
			}); */
			this.loadData()
		},
		computed: {
			goodsCondition() {
				console.log("change goods condition")
				return `category_id=="${this.options.subCurrentId}"`
			},
			searchStyle() {
				//#ifdef MP
				return `padding-top:${this.systemInfo.custom.top}px;`
				//#endif
				return ""
			}
		},
		onShow() {},
		onHide() {
			//防止弹窗隐藏了导航栏
			uni.showTabBar()
			setTimeout(() => {
				this.$refs.tianSkuPop.close();
			}, 500)
		},
		mounted() {
			/* const query = uni.createSelectorQuery().in(this);
			query.select('#search').boundingClientRect(data => {
				console.log(data, this.systemInfo)
			}).exec(); */
		},
		methods: {
			subCategoryScroll(e) {
				//@TODO 二级分类联动
				// console.log("subCategoryScroll", e.detail.scrollTop)
			},
			loadList(text = '') {
				getApp().globalData.searchText = text;
				uni.navigateTo({
					url: "/pages/product/list"
				})
			},
			loadData() {
				db.collection("tian-mall-categories").where("status==true").field(
						"parent_id,name,icon,sort,ad_banner,ad_open_url")
					.orderBy(
						"sort asc").get({
						getTree: true
					}).then(({
						result
					}) => {
						let firstItem = false;
						result.data.forEach((item, mIndex) => {
							item.index = mIndex;
							if (!item.ad_banner) {
								//默认广告图
								item.ad_banner =
									"https://vkceyugu.cdn.bspapp.com/VKCEYUGU-3fbab731-e993-47e6-882f-a74e444709a3/11b41427-1164-4254-a723-aacec29d1eb6.jpg";
							} else {
								item.ad_banner = this.$thumbImg(item.ad_banner, '450x150');
							}
							item.icon = this.$thumbImg(item.icon, '80x80');
							//参数传递，匹配是否正确
							if (this.options.mainCurrentId && item._id == this.options.mainCurrentId) {
								firstItem = item;
							}
							item.children.forEach((child, index) => {
								//第三极分类的图片
								if (child.children) {
									child.children.forEach(e3 => {
										e3.icon = this.$thumbImg(e3.icon, '130x130');
									})
								}
							})
						})
						this.categories = result.data;

						if (!firstItem) {
							firstItem = this.categories[0]
						}
						this.changeMainCategory(firstItem)
					})
			},
			/**
			 * 广告图跳转
			 */
			adClick() {
				if (this.mainCategory.ad_open_url) {
					this.navTo(this.mainCategory.ad_open_url)
				}
			},
			changeMainCategory(item) {
				let index = -1;

				this.categories.forEach((e, i) => {
					if (e._id == item._id) {
						index = i;
					}
					e.className = ""
				});
				if (index == -1) {
					//主分类id不在范围内
					console.log("主分类id不在范围内", item)
					return false;
				} else if (this.options.mainCurrentId == item._id) {
					console.log("重复点击无效", item)
					return false;
				}
				this.options.mainCurrentId = item._id
				// console.log("item._id", index, item)
				this.mainCategory = this.categories[index];
				this.mainCategory.className = "current"
				this.subCategories = this.categories[index].children;
				// this.subCateHeight = this.subCategories.length * 40;
				if (this.subCategories.length > 0) {
					this.options.subCurrentId = this.subCategories[0]._id;
				} else {
					//没有子分类，默认查询主分类商品
					this.options.subCurrentId = this.options.mainCurrentId;
				}

				if (index != 0) {
					this.categories[index - 1].className = "prev"
				}
				if (index != this.categories.length - 1) {
					this.categories[index + 1].className = "next"
				}
				/* setTimeout(() => {
					this.options.scrollLeft = index * 60 - 50;
					//console.log("this.options.scrollLeft", this.options.scrollLeft)
				}, 300) */
			},
			changeSubCategory(item, index) {
				this.options.subCurrentId = item._id;
				setTimeout(() => {
					this.options.scrollTop = index * 30 - 60;
					//console.log("this.options.scrollLeft", this.options.scrollTop)
				}, 300)
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
		}
	}
</script>

<style lang="scss">
	page {
		background: #FFFFFF;
		height: 100%;
		width: 100%;
	}

	.search {
		padding-top: var(--status-bar-height);
		// #ifdef MP
		padding-top: 0;
		// #endif
		background: #FFFFFF;
	}

	// $windowHeight:calc(100vh - (var(--window-top)) - (var(--window-bottom)) - var(--status-bar-height));

	.container {
		// height: $windowHeight;
		display: flex;
		height: 100%;
		width: 100%;
	}

	.container>view {
		width: 100%;
	}

	.main-category-panel-all {
		background: #f2f2f2;
		flex: 1;
		height: calc(100vh - (var(--window-top)) - (var(--window-bottom)) - var(--status-bar-height) - 110rpx);
		// #ifdef MP
		height: calc(100vh - (var(--window-top)) - (var(--window-bottom)) - var(--status-bar-height) - 134rpx);
		// #endif
		display: flex;
		width: 100%;
		overflow-x: hidden;

		.cate-ad {
			width: 450rpx;
			height: 150rpx;
		}
	}

	.scroll-view_W {
		width: 236rpx;
		height: 100%;
		text-align: center;
		background: #FFFFFF;
		background: #f2f2f2;

		.item {
			height: 86rpx;
			font-size: 28rpx;
			line-height: 86rpx;
			background: #FFFFFF;

			.text {
				background: #f2f2f2;
			}
		}

		.current {
			font-size: 30rpx;

			.text {
				background: #fff;
			}
		}

		.prev .text {
			border-radius: 0 0 30rpx 0;
			overflow: hidden;
		}

		.next .text {
			border-radius: 0 30rpx 0 0;
			overflow: hidden;
		}
	}

	.scroll-view-item_H {
		// padding-left: $uni-spacing-row-base;

		&:last-child {
			margin-right: $uni-spacing-row-base;
		}

		.text {
			margin-top: 8rpx;
			padding: 0rpx $uni-spacing-row-sm;
			line-height: 1.4;
		}

		&.current {
			.text {
				background: $uni-red;
				color: #FFFFFF;
				border-radius: 12rpx;
			}
		}
	}

	.content {
		background: #FFFFFF;
		padding-top: 30rpx;
		border-radius: 30rpx 0 0 0;
		height: calc(100% - 30rpx);

		&.main-index0 {
			border-radius: 0;
		}
	}

	.sub-category {
		// border-top: 2rpx solid $uni-bg-color-grey;
		background: #FFFFFF;
		width: 510rpx;
		padding: 10rpx 0;

		scroll-view {
			// white-space: nowrap;
		}

		.item {
			white-space: nowrap;
			font-size: 22rpx;
			text-align: center;
			line-height: 48rpx;
			background: $uni-bg-color-grey;
			border-radius: 60rpx;
			margin-left: 14rpx;
			width: 160rpx;

			&.current {
				background: $uni-bg-color;
				color: $uni-red;
				font-weight: 600;
			}
		}
	}

	.scroll-h3 {
		height: calc(100% - 230rpx);
	}

	.third-category {
		padding-bottom: 60rpx;

		.item {}

		.title {
			font-weight: 600;
			padding: 25rpx 0;
		}

		.sub-items {
			display: flex;
			flex-wrap: wrap;
			text-align: center;
			font-size: 24rpx;
			// justify-content: space-between;
			padding-right: 30rpx;

			.sub-item {
				width: 33.33%;
			}
		}

		.image {
			width: 133rpx;
			height: 133rpx;
			display: block;
			margin: 6rpx auto;
		}
	}

	.goods-list-panel {
		width: 100%;
		height: 100%;
		flex: 1;
	}
</style>
