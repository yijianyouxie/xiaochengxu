import store from '@/store'
import config from '@/config.js'
let isShowLoginDialog = false;
const db = uniCloud.database()
db.on('refreshToken', function({
	token,
	tokenExpired
}) {
	store.commit('user/SET_TOKEN', {
		token,
		tokenExpired
	})
})

export function request(action, data, {
	showModal = true,
	loading = false,
	functionName = "tiantian-mall",
	checkAuthInvalid = false,
} = {}) {
	if (loading) {
		uni.showLoading({
			title: "加载中",
			mask: true
		})
	}
	return uniCloud.callFunction({
		name: functionName,
		data: {
			action,
			data
		}
	}).then(({
		result
	}) => {
		console.log("request", result)
		uni.hideLoading()
		if (!result) {
			return Promise.resolve(result)
		}
		//返回值code为统一过滤
		if (result.code) {
			let message = result.message;
			if(typeof result.code === 'string'){
				 if (result.code.indexOf('InternalServerError') === 0) {
					message = "系统繁忙";
				} else if (result.code.indexOf('TOKEN_INVALID') === 0) {
					message = "登录状态已过期，请重新登录";
					/* uni.reLaunch({
						url: config.login.url
					}) */
				}
			}
			// const err = new Error(result.message)
			// err.code = result.code
			const err = {
				...result,
				message
			}
			return Promise.reject(err)
		}
		const {
			token,
			tokenExpired,
			type,
			uid,
			userInfo
		} = result;
		if (type && type == "register") {
			userInfo._id = uid;
		}
		//续命,首次登录也有效
		if (token && tokenExpired) {
			// console.log(store)
			store.commit('user/SET_TOKEN', {
				token,
				tokenExpired,
				userInfo
			})
		}
		return Promise.resolve(result)
	}).catch(err => {
		let msg = err.message;
		if (msg.indexOf("403") != -1) {
			msg = "运营商流量限制,请稍后再试"
		} else if (msg.indexOf("request:fail") != -1) {
			msg = "联网失败,请检查网络"
		}
		uni.hideLoading()
		showModal && uni.showModal({
			content: msg || '请求服务失败',
			showCancel: false,
			success: function() {

			}
		})
		return Promise.reject(err)
	})
}

export function initRequest(Vue) {
	Vue.prototype.$request = request;
	Vue.prototype.$config = config;
}
