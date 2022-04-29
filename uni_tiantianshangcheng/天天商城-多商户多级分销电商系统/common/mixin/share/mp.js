// #ifdef MP-WEIXIN
//https://uniapp.dcloud.io/api/plugins/share?id=onshareappmessage
export default {
	onShareAppMessage(res) {
		if (this.share) {
			return this.share;
		}
		return {

		};
	},
	onShareTimeline(res) {
		if (this.share) {
			return this.share;
		}
		return {

		};
	}
}
//#endif
