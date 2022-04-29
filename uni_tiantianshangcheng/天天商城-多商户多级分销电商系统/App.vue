<script>
	//#ifdef APP-PLUS
	import checkUpdate from "@/uni_modules/uni-upgrade-center-app/utils/check-update";
	//#endif
	import {
		mapState,
		mapActions,
		mapMutations
	} from 'vuex';
	import Vue from 'vue';
	import {
		getQueryString
	} from '@/common/js/util.js'
	let inviteCode = "";
	let channelCode = "";
	export default {
		onLaunch: function(options) {
			console.log('App Launch', options)
			if (!options.query) {
				options.query = {}
			}
			//微信普通二维码扫码进入
			if (options.query.q) {
				let url = decodeURIComponent(options.query.q);
				Object.assign(options.query, {
					...getQueryString(url)
				});
				delete options.query.q
				console.log("options.query", options.query)
			}
			//推广渠道id，后台存在渠道表
			if (options.query.channel) {
				channelCode = options.query.channel;
				console.log("渠道", channelCode);
				this.setChannelCode(options.query.channel);
			}
			//邀请者
			if (options.query.u) {
				inviteCode = options.query.u;
				console.log("invite", inviteCode)
				this.setInviteCode(options.query.u);
			} else {
				this.getInviteFromClipboard();
			}
			//设置默认信息
			this.setDefaultInfo({});
			//如果存在登录信息，自动登录
			this.autoLogin(options.query);
			//#ifdef APP-PLUS
			//检测更新
			checkUpdate().then(res => {
				console.log("检查更新结果", res)
			});
			this.initUniverify();
			this.checkPush();
			//#endif
			this.initSize(uni.getSystemInfoSync());
			//如果首次没有联网，init会加载失败
			uni.onNetworkStatusChange((e) => {
				if (e.isConnected) {
					console.log("isConnected")
					this.autoLogin(options.query);
				}
			})
		},
		onShow: function() {
			console.log('App Show')
		},
		onHide: function() {
			console.log('App Hide')
		},
		computed: {
			//...mapState('user', ['inviteCode']),
		},
		methods: {
			...mapMutations({
				setInviteCode(commit, code) {
					//更新邀请码
					commit('user/SET_INVITECODE', code)
				},
				setChannelCode(commit, code) {
					//更新邀请码
					commit('user/SET_CHANNELCODE', code)
				},
				setDefaultInfo(commit, info) {
					//更新邀请码
					commit('user/SET_USER_INFO', info)
				},
				setPushClient(commit, push) {
					//更新push，如果用户未登录，只是将push参数存到store，
					//等待用户登录完成之后，再调用action：user/updatePushClient
					commit('user/UPDATE_PUSH_CLIENT', push)
				},
				setUniverifyInit(commit) {
					//APP初始化一键登录成功
					commit('user/UNIVERIFY_INIT')
				},
			}),
			...mapActions({
				initApp: 'app/init',
				mpLogin: 'user/mpLogin',
			}),
			/**
			 * 从上一次缓存，自动登录,store已经从缓存中读取上一次的token 
			 */
			async autoLogin(query) {
				if (!this.$store.getters['user/isInitTokenValid']) {
					console.log("获取APP信息，需要用户详细信息")
				}
				//小程序每次都需要新登录，因为sessionKey有不确定的时间限制
				this.micLogin();
				this.initApp({
					...query
				});
			},
			async getInviteFromClipboard() {
				//#ifdef APP-PLUS
				uni.getClipboardData({
					success: (res) => {
						//检测是不是正确的邀请码
						uniCloud.database().collection("uni-id-users").where(
							`my_invite_code=="${res.data}"`).field(
							"avatar,nickname").limit(1).get().then(({
							result
						}) => {
							if (result.data && result.data.length > 0) {
								this.setInviteCode(res.data);
								console.log("getInviteFromClipboard", res.data);
							} else {
								console.log("粘贴板邀请码无效")
							}
						})
					},
					fail: (e) => {}
				});
				//#endif
			},
			/**
			 * 小程序自动登录，
			 */
			async micLogin(state) {
				//#ifdef MP
				console.log("小程序用户自动登录开始")
				uni.getProvider({
					service: 'oauth',
					success: (res) => {
						console.log(res)
						let provider = res.provider[0];
						uni.login({
							provider: provider,
							success: (loginRes) => {
								console.log('授权code', loginRes);
								this.mpLogin({
									provider,
									channelCode,
									inviteCode: inviteCode,
									code: loginRes.code
								});
								console.log("小程序用户自动登录结束")
							}
						});
					}
				});
				//#endif
			},
			/**
			 * 初始化uni一键登录
			 */
			async initUniverify(index) {
				let _this = this;
				// #ifdef APP-PLUS
				console.log("开始一键登录")
				/* const univerifyManager = uni.getUniverifyManager()
				univerifyManager.preLogin({
					provider: 'univerify',
					success() { //预登录成功
						// 显示一键登录选项
						console.log("一键登录初始化成功")
						// _this.setUniverifyInit();
					}
				}) */
				uni.preLogin({
					provider: 'univerify',
					success() { //预登录成功
						// 显示一键登录选项
						console.log("一键登录初始化成功")
						_this.setUniverifyInit();
					},
					fail(res) { // 预登录失败
						// 不显示一键登录选项（或置灰）
						// 根据错误信息判断失败原因，如有需要可将错误提交给统计服务器
						console.log(res.errCode)
						console.log(res.errMsg)
						//去掉多次检测
						if (index < 30) {
							//重试2次
							setTimeout(() => {
								_this.initUniverify(index + 1)
							}, index * index * 1000)
						}
					},
					complete() {
						console.log("一键登录complete")
					}
				})
				// #endif
			},
			checkPush() {
				// #ifdef APP-PLUS
				//监听push推送通知
				plus.push.addEventListener('receive', ({
					type,
					title,
					content,
					payload
				}) => { //console.log(type,title,content,payload);
					console.log(type, 'type');
					if (type == 'receive' || uni.getSystemInfoSync().platform !=
						"ios") { //如果type!='receive'是自己本地插件的push消息栏，“拦截”避免死循环'，安卓系统没有这个问题
						if (typeof payload != 'object') {
							payload = JSON.parse(payload)
						} //判断是否为object，不是的话手动转一下。hbuilderx 3.0以上版本已经修复此问题可省略
						plus.push.createMessage(content, JSON.stringify(payload), {
							title: payload.title,
							subtitle: payload.content
						});
					}
				});
				//监听点击通知栏
				plus.push.addEventListener('click', function({
					payload
				}) {
					if (typeof payload != 'object') {
						payload = JSON.parse(payload)
					}

					let pages = getCurrentPages();
					let currentWebview = pages[pages.length - 1].$getAppWebview();
					if (currentWebview.__uniapp_route != 'pages/msg-center/msg-center') {
						uni.navigateTo({
							url: '/pages/msg-center/msg-center'
						})
					}
					uni.$emit('readMsg', payload)
				});
				//获取push参数
				plus.push.getClientInfoAsync(
					info => {
						console.log('push.getClientInfoAsync', info);
						this.setPushClient(info)
					},
					err => {
						console.log('push.getClientInfoAsync', err);
					}
				);
				// #endif
			},
			/**
			 * 存储设备信息 参考colorUI
			 * @param {Object} 
			 */
			initSize(e) {
				const systemInfo = e;
				let navigationBarHeight;
				let custom = {};
				// #ifndef MP
				custom = {
					height: 36,
					width: 88
				};
				navigationBarHeight = 44;
				// #endif
				// #ifdef MP-WEIXIN
				custom = wx.getMenuButtonBoundingClientRect();
				navigationBarHeight = custom.bottom + custom.top - e.statusBarHeight * 2;
				// #endif	
				// #ifdef MP-TOUTIAO
				custom = tt.getMenuButtonBoundingClientRect();
				navigationBarHeight = custom.bottom + custom.top - e.statusBarHeight * 2;
				// #endif	
				systemInfo.custom = custom;
				systemInfo.navigationBarHeight = navigationBarHeight;
				systemInfo.development = process.env.NODE_ENV == "development";
				console.log(systemInfo);
				Vue.prototype.systemInfo = systemInfo;
			},
		}
	}
</script>

<style lang="scss">
	/*每个页面公共css */
	/* #ifndef APP-NVUE */
	@import "common/css/font_2479288_9cqg4e7ml9.css";
	@import "common/css/theme.scss";
	@import "common/css/style.scss";
	/* #endif */
</style>
