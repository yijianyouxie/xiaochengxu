<template>
	<view>
		<uni-list>
			<uni-list-item title="总人数" :rightText="statistics.total">
			</uni-list-item>
			<uni-list-item title="今日新增人数" :showArrow="true" :clickable="true" :rightText="statistics.todayUser">
			</uni-list-item>
			<uni-list-item title="今日新增积分" :showArrow="true" :clickable="true" :rightText="statistics.todayScore">
			</uni-list-item>
		</uni-list>
	</view>
</template>

<script>
	const db = uniCloud.database();
	export default {
		data() {
			return {
				statistics: {
					total: "0人",
					todayUser: "0人",
					todayScore: "0分"
				}
			}
		},
		onLoad() {
			this.getUsersCount();
		},
		methods: {
			getUsersCount() {
				let time = new Date();
				time.setHours(0);
				time.setMinutes(0);
				time.setSeconds(0);
				time.setMilliseconds(0);
				let today = time.getTime();
				//总人数
				db.collection("uni-id-users").count().then(({
					result
				}) => {
					this.statistics.total = result.total + "人";
				});
				//今日新增
				db.collection("uni-id-users").where(`register_date >= ${today}`).count().then(({
					result
				}) => {
					this.statistics.todayUser = result.total + "人";
				});
				//今日新增积分
				db.collection("uni-id-score-day-statistics").where(`day >= ${today}`).get({
					getOne: true
				}).then(({
					result
				}) => {
					this.statistics.todayScore = result.data.value + "分";
				});
			}
		}
	}
</script>

<style>

</style>
