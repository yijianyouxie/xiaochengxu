<template>
	<view class="container">
		<unicloud-db ref="udb" v-slot:default="{data, pagination, loading, hasMore, error}" collection="uni-id-address"
			where="user_id==$cloudEnv_uid"
			field="user_id,name,alias,mobile,mobile_area_code,province_code,city_code,area_code,address,formatted_address,zip_code,email,is_default"
			orderby="update_date desc">
			<tian-empty v-if="!loading && data.length == 0" text="暂无收货地址" marginTop="200"></tian-empty>
			<view v-if="error">{{error.message}}</view>
			<view v-else-if="data">
				<uni-list>
					<uni-list-item v-for="(item, index) in data" :key="index" showArrow :clickable="true"
						@click="navToEdit(item)" class="">
						<view slot="body">
							<view class="">
								<text>{{item.name}}</text>
								<text class="margin-left-20 font-28">{{item.mobile}}</text>
							</view>
							<view class="font-24 colorGray">
								<text>{{item.formatted_address}}</text>
								<text>{{item.address}}</text>
							</view>
						</view>
					</uni-list-item>
				</uni-list>
			</view>
			<uni-load-more v-if="hasMore" :status="loading?'loading':(hasMore ? 'more' : 'noMore')"></uni-load-more>
		</unicloud-db>
		<uni-fab ref="fab" horizontal="right" vertical="bottom" :pattern="{buttonColor:'#eb4e38'}" :pop-menu="false" @fabClick="fabClick" />
	</view>
</template>

<script>
	export default {
		data() {
			return {
				source: "", //来源，settlement，
				loadMore: {
					contentdown: '',
					contentrefresh: '',
					contentnomore: ''
				}
			}
		},
		onLoad(e) {
			if (e.source) {
				this.source = e.source;
			}
		},
		onPullDownRefresh() {
			this.$refs.udb.loadData({
				clear: true
			}, () => {
				uni.stopPullDownRefresh()
			})
		},
		onReachBottom() {
			this.$refs.udb.loadMore()
		},
		methods: {
			loadData() {
				this.$refs.udb.loadData({
					clear: true
				})
			},
			navToEdit(item) {
				if (this.source == "settlement") {
					//选中地址，
					this.getOpenerEventChannel().emit('addData', {
						address: item
					})
					setTimeout(() => uni.navigateBack(), 500)
				} else {
					this.navTo('./edit?id=' + item._id, item);
				}
			},
			fabClick() {
				this.navTo('./add')
			}
		}
	}
</script>

<style lang="scss">
	.container {
		padding: $uni-spacing-row-base;
	}
</style>
