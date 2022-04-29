import {
	request
} from '@/js_sdk/mall/request.js';
/**
 * 用户模块，管理用户登录，用户信息
 */
export default {
	namespaced: true,
	state: {
		token: uni.getStorageSync('uni_id_token'),
		tokenExpired: uni.getStorageSync('uni_id_token_expired'),
		userInfo: {},
		tasks: [], //任务
		openid: "", //微信openid
		mpWxCode: "", //微信自动登录返回code
		sessionKey: uni.getStorageSync('mpSessionKey'), //微信sessionKey  
		inviteCode: "", //邀请码，默认为管理员
		channelCode: "", //渠道编码
		push: false, //本机推送信息
		univerifyInit: false, //uni一键登录是否初始化成功
		updatePushTime: 0, //更新push信息时间
	},
	getters: {
		/**
		 * 判断登录信息是否有效
		 * @param {Object} state
		 */
		isTokenValid(state) {
			return !!state.token && state.tokenExpired > Date.now()
		},
		isInitTokenValid(state) {
			console.log("检查是否登录过期", state)
			return !!state.token && state.tokenExpired > Date.now() + 3600 * 24 * 1000
		}
	},
	mutations: {
		/**
		 * 登录保存token，用户信息
		 */
		SET_TOKEN(state, {
			token,
			tokenExpired,
			userInfo,
			openid
		}) {
			state.token = token
			state.tokenExpired = tokenExpired
			if (openid) {
				state.openid = openid;
			}
			if (userInfo) {
				//手动登录，有返回用户信息
				this.commit("user/SET_USER_INFO", userInfo);
			} else {
				//自动登录情况下，更新用户信息，初始化app，可以返回用户信息
				//this.dispatch('getUserInfo');
			}
			//用于下次自动登录
			uni.setStorageSync('uni_id_token', token)
			uni.setStorageSync('uni_id_token_expired', tokenExpired)
			console.log("设置登录状态成功")
			//更新购物车数量
			this.dispatch('mall/getCartTotal');
		},
		/**
		 * 退出登录
		 */
		REMOVE_TOKEN(state) {
			console.log("REMOVE_TOKEN");
			state.token = ''
			state.tokenExpired = 0
			state.userInfo = {}
			uni.removeStorageSync('uni_id_token')
			uni.removeStorageSync('uni_id_token_expired');
			uni.$emit('refreshCart');
		},
		SET_USER_INFO(state, userInfo) {
			// console.log("SET_USER_INFO", userInfo)
			let defUserInfo = {
				balance: 0,
				score: 0,
				coupon: 0,
				hasNickName: false,
				avatar: "/static/missing-face.png",
				nickname: "游客",
			};
			if (userInfo._id) {
				//手动登录，有返回用户信息
				let info = {
					nickname: "未设置昵称",
					hasNickName: !!userInfo.nickname, //是否设置昵称
					hasMobile: !!userInfo.mobile, //是否设置手机号
					channel_code: state.channelCode //默认为上级渠道
				}
				defUserInfo = Object.assign({}, {
					...defUserInfo,
					...info,
				})
				//刷新任务
				// this.dispatch('user/getTasks')
				//更新推送
				this.dispatch('user/updatePushClient');
			}
			state.userInfo = Object.assign({}, {
				...defUserInfo,
				...userInfo
			})
			console.log("state.userInfo.wx_openid", userInfo.wx_openid)
			//获取微信openid，根据平台区分
			if (userInfo.wx_openid) {
				state.openid = userInfo.wx_openid["app-plus"]
				//#ifdef MP-WEIXIN
				state.openid = userInfo.wx_openid["mp-weixin"]
				//#endif
			}
			//多账户
			this.commit("user/UPDATE_MULTI_ACCOUNT");
		},
		UPDATE_MULTI_ACCOUNT(state) {
			let userInfo = state.userInfo;
			if (!userInfo._id) {
				return false;
			}
			//多账户管理，写入缓存
			let key = 'tiantian-accounts';
			let accounts = uni.getStorageSync(key);
			if (!accounts) {
				accounts = []
			}
			let saveInfo = {
				...userInfo,
				token: state.token,
				tokenExpired: state.tokenExpired,
			};
			//判断是否存在
			if (accounts.filter(e => e._id == userInfo._id).length == 0) {
				//不存在，直接写入
				accounts.push(saveInfo)
			} else {
				//存在用户数据，更新一下
				accounts.forEach(e => {
					if (e._id == userInfo._id) {
						Object.assign(e, {
							...saveInfo
						})
					}
				})
			}
			uni.setStorageSync(key, accounts)
		},
		/**
		 * 设置邀请码，二级分佣
		 * @param {Object} state
		 * @param {Object} code
		 */
		SET_INVITECODE(state, code) {
			state.inviteCode = code
		},
		SET_CHANNELCODE(state, code) {
			state.channelCode = code
		},
		/**
		 * 更新推送信息
		 * @param {Object} state
		 * @param {Object} push
		 */
		UPDATE_PUSH_CLIENT(state, push) {
			state.push = push;
			this.dispatch('user/updatePushClient');
		},
		UPDATE_TASK_LOG(state, log) {
			if (state.tasks && log.task_id) {
				state.tasks.forEach(task => {
					if (task._id == log.task_id) {
						task.log = {
							...log,
							task: undefined
						}
						console.log("store UPDATE_TASK_LOG task", JSON.stringify(task))
					}
				})
			}
		},
		MP_AUTO_LOGIN(state, info) {
			this.dispatch('user/mpLogin', info);
		},
		MP_WX_CODE(state, mpWxCode) {
			state.mpWxCode = mpWxCode;
			console.log("更新微信code完成", state.mpWxCode)
		},
		UNIVERIFY_INIT(state, info) {
			state.univerifyInit = true;
		}
	},
	actions: {
		/**
		 * 登录后，更新用户信息,修改自己
		 */
		async getUserInfo({
			state,
			dispatch,
			commit
		}) {
			console.log("store getUserInfo")
			const res = await request('user/info/info', {}, {
				checkAuthInvalid: false,
				token: state.token
			});
			if (res) {
				commit('SET_USER_INFO', res)
			}
			console.log("store getUserInfo result", res);
		},
		/**
		 * 加载任务中心数据，必须登录后，才加载@@@@废弃#@@@@@
		 */
		async getTasks({
			state,
			commit
		}, payload) {
			if (state.tasks.length == 0 || payload) {
				const res = await request('user/task/all', {}, {});
				state.tasks = res;
				console.log("store getTasks", res)
			}
		},
		/**
		 * 更新推送信息
		 */
		async updatePushClient({
			state,
			commit
		}) {
			if (state.token && state.push) {
				const res = await request('user/info/push', {
					...state.push
				}, {
					checkAuthInvalid: true,
					token: state.token
				});
				console.log("store 更新用户推送信息成功", res)
			}
		},
		/**
		 * 小程序登录
		 */
		async mpLogin({
			state,
			commit
		}, payload) {
			const res = await request('user/login/' + payload.provider, {
				...payload
			});
			if (res) {
				if (res.sessionKey) {
					state.sessionKey = res.sessionKey;
					uni.setStorage({
						key: "mpSessionKey",
						data: res.sessionKey
					})
				}
				// if (res.userInfo) {
				// 	commit('SET_USER_INFO', res.userInfo)
				// }
				//commit("SET_TOKEN", res)
				//初始化应用信息
				// this.dispatch('app/init');
			}
			console.log("store mpLogin", res)
		}
	}
}
