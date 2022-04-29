export default {
	// #ifdef MP-WEIXIN
	data() {
		return {
			mpCodeTimer: 0,
			mpWxCode: '',
		}
	},
	onLoad() {
		wx.getUserProfile({
			desc: '用于完善会员资料', // 声明获取用户个人信息后的用途，后续会展示在弹窗中，请谨慎填写
			success: (res) => {
				console.log("wx.getUserProfile res",res)
			}
		})
	},
	onShow() {
		this.getMpWxCode();
	},
	methods: {
		/**
		 * 微信授权登录
		 */
		async wxLogin() {
			uni.login({
				provider: "weixin",
				success: (loginRes) => {
					console.log('loginRes', loginRes);
					console.log('inviteCode', this.inviteCode);
					//微信获取用户信息，并登录 
					this.$request("user/login/weixin", {
						inviteCode: this.inviteCode,
						channelCode: this.$store.state.user.channelCode,
						code: res.code,
					}).then(res2 => {
						this.loginSuccess(res2);
					}, err => {
						//更新失败
					})
				}
			});
		},
		//微信小程序登录，获得用户信息，更新到服务器，只存在一次
		mpWxGetUserInfo(userInfoData) {
			uni.getUserInfo({
				provider: "weixin",
				success: (res) => {
					this.$request("user/login/weixin", {
						code: this.mpWxCode,
						channelCode: this.$store.state.user.channelCode,
						encryptedData: res.encryptedData,
						iv: res.iv,
						userInfo: res.userInfo
					}).then(res2 => {
						this.loginSuccess(res2);
					}, err => {
						//更新失败
					})
				}
			})
		},
		//获取code
		getMpWxCode() {
			uni.login({
				provider: 'weixin',
				success: res => {
					this.mpWxCode = res.code;
				}
			})
		},

	}
	// #endif
}
