import config from '@/config.js'
export default {
	data() {
		return {
			page: 0, //页码
			limit: 20, //每页加载数据量
			loadingType: "loading", //more加载前 loading加载中 noMore没有更多
			// loaded: false, //加载完毕，与uni-indexed-list-item的data冲突，如果不在这里申明，页面里面判断也是undefined，达到false效果，但是不会watch，需要的页面自行申明
			isSubmit: false, //是否正在提交数据
			share: {}, //分享内容
			barTitle: "", //导航栏标题
			itemDataKey: "navigateToItemData",
			isShowLoginDialog: false
		}
	},
	watch: {
		barTitle(newVal) {
			uni.setNavigationBarTitle({
				title: newVal
			});
		}
	},
	onLoad() {
		if (this.barTitle) {
			//设置导航栏标题,有利于国际化
			uni.setNavigationBarTitle({
				title: this.barTitle
			});
		}
	},
	methods: {
		log(data) {
			console.log(JSON.parse(JSON.stringify(data)))
		},

		/**
		 * navigatorTo跳转页面
		 * @param {String} url
		 * @param {Object} item 传递到下一界面的值
		 * @param {Object} options
		 * @param {Boolean} options.login 是否检测登录  
		 */
		navTo(url, item, options = {}) {
			if (!url) {
				return;
			}
			console.log("url", url)
			if ((~url.indexOf('login=true') || options.login) && !this.$store.getters['user/isTokenValid']) {
				// url = config.login.url;
				this.navToLoginNotice();
				return;
			}
			//是否绑定手机号
			if ((~url.indexOf('mobile=true')) && !this.$store.state.user.userInfo.mobile) {
				url = "/pages/login/bindmobile";
			}
			if (url.indexOf("miniProgram") != -1) {
				//触发本地方法，带简单参数
				let args = url.split(",");
				//跳转其他小程序https://uniapp.dcloud.io/api/other/open-miniprogram?id=navigatetominiprogram
				uni.navigateToMiniProgram({
					appId: args[1],
					path: args[2],
					extraData: args[3] ? JSON.parse(args[3]) : {},
				})
				return;
			} else if (url.indexOf("http://") != -1 || url.indexOf("https://") != -1) {
				//如果是网址，则打开页面
				item = url;
				url = "/pages/app/web"
			} else if (url.indexOf("::") != -1) {
				//触发本地方法，带简单参数
				let args = url.split(",");
				let funcs = args.shift();
				try {
					this[funcs.substr(2)](item, ...args);
				} catch (e) {
					console.log(e)
					uni.showToast({
						title: e.message || "网络异常",
						icon: "none"
					})
				}
				return;
			}
			if (item) {
				uni.setStorageSync(this.itemDataKey, item);
			} else {
				uni.removeStorage({
					key: this.itemDataKey
				})
			}
			uni.navigateTo({
				url,
				events: {
					refreshData: () => {
						//一般整页刷新
						this.loadData()
					},
					addData: (e) => {
						console.log("mixin addData", e)
						//用于某一项数据的更新
						this.editData(e)
					}
				},
				fail: () => {
					console.log("navigateTo fail")
					//改用switch
					uni.switchTab({
						url: url,
						success: () => {
							//分类页面，特殊处理参数
							if (url.indexOf("index/category") != -1 && url.indexOf("id") != -
								1) {
								let cid = url.substr(url.indexOf("id=") + 3);
								uni.$emit("changeMainCid", cid)
								setTimeout(() => {
									//防止分类没有初始化，点两下也无所谓
									uni.$emit("changeMainCid", cid)
								}, 1000)
							}
						}
					})
				}
			})
		},
		/**
		 * 重定向到新页面
		 * @param {Object} url
		 * @param {Object} item
		 */
		redirectToItem(url, item) {
			if (item) {
				uni.setStorageSync(this.itemDataKey, item);
			}
			uni.redirectTo({
				url: url
			})
		},
		navToLoginNotice(callback, fullScreen = true, toLogin = true) {
			//是否已经弹出
			if (this.isShowLoginDialog) {
				return false;
			}
			let errorMsg = "一键登录失败，请打开手机流量";
			let isMustUniverifyLogin = this.$store.getters['app/isMustUniverifyLogin'];
			let univerifyInit = this.$store.state.user.univerifyInit;
			//app默认直接弹出一键登录授权
			//#ifdef APP-PLUS
			//https://uniapp.dcloud.io/univerify
			uni.login({
				provider: 'univerify',
				univerifyStyle: {
					fullScreen: fullScreen,
					otherLoginButton: {
						visible: !isMustUniverifyLogin
					}
				},
				success: (res) => { // 登录成功
					uni.showLoading({
						title: "登录中"
					})
					console.log(res.authResult); // {openid:'登录授权唯一标识',access_token:'接口返回的 token'}
					this.$request("user/login/univerify", {
						...res.authResult,
						inviteCode: this.$store.state.user.inviteCode,
						channelCode: this.$store.state.user.channelCode,
					}).then((res2) => {
						uni.hideLoading();
						console.log("一键登录完成", res2)
						//this.$store.commit('user/SET_TOKEN', res2)
						if (callback) {
							callback(res2)
						}
					}, err => {
						uni.hideLoading();
						this.$message(errorMsg);
					}).finally(() => {
						uni.closeAuthView();
					})
				},
				fail: (res) => { // 登录失败
					if (isMustUniverifyLogin) {
						this.$message(errorMsg);
					} else if (res.errCode == 40004) {
						
					} else if (res.errCode == 30003) {
						//用户关闭验证界面
					} else if (res.errCode == 30002) {
						//点击其他登录方式
						if (toLogin) {
							this.navToLogin();
						}
					} else if (!toLogin) {
						this.$message(errorMsg);
					} else {
						// this.showLoginNotice();
					}

					console.log(res.errCode)
					console.log(res.errMsg)
					uni.closeAuthView()
				}
			})
			if (univerifyInit) {
				return;
			}
			//#endif
			this.showLoginNotice();
		},
		showLoginNotice() {
			uni.showModal({
				title: config.login.title,
				content: config.login.content,
				cancelText: config.login.cancelText,
				confirmText: config.login.confirmText,
				success: (res) => {
					if (res.confirm) {
						this.navToLogin();
					}
					this.isShowLoginDialog = false;
				},
				fail: () => {
					this.isShowLoginDialog = false;
				}
			});
		},
		navToLogin() {
			uni.navigateTo({
				url: config.login.url
			})
		},
		/**
		 * 定时返回，用于提交成功后，消息显示完成后，跳转其他页面
		 * @param {String} isRefresh 是否刷新上一页数据
		 * @param {Object} time 跳转时间
		 */
		navTimeBack(isRefresh, time = 2000, callback = false) {
			setTimeout(() => {
				if (isRefresh) {
					try {
						//需要上一个页面定义loadData
						this.getOpenerEventChannel().emit('refreshData')
					} catch (e) {
						console.log("刷新上一页数据错误");
					}
				}
				uni.navigateBack({})
				if (callback) {
					callback()
				}
			}, time);
		},
		/**
		 * 获取上一个页面传过来的数据,对象是最好的，不要来数组
		 * @param {Boolean} isAutoSet 是否设置到data数据中
		 */
		getItemData(isAutoSet) {
			let data = uni.getStorageSync(this.itemDataKey);
			if (isAutoSet && data) {
				//数组不允许设置
				//console.log(typeof(data))
				if (typeof(data) == "array") {
					return data;
				}
				for (let key in data) {
					this[key] = data[key];
				}
			}
			return data;
		},
		setRootData(data) {
			for (let key in data) {
				this[key] = data[key];
			}
		},
		/**
		 * 定时跳转，用于提交成功后，消息显示完成后，跳转其他页面
		 * @param {String} url
		 * @param {Object} options
		 * @param {Boolean} options.login 是否检测登录  
		 * @param {Object} time 跳转时间
		 */
		navTimeTo(url, options = {}, time = 2000) {
			setTimeout(() => {
				this.navTo(url, options);
			}, time);
		},
		imageOnLoad(data, key) {
			//这里有问题，页面数据重新刷新后，图片地址为改变的时候，不触发图片的load事件，
			setTimeout(() => {
				this.$set(data, 'loaded', true);
			}, 100)
		},
		showMyPopups(key) {
			this.$api.throttle(() => {
				this.$refs[key].open();
			}, 200)
		},
		hideMyPopups(key) {
			this.$refs[key].close();
		},
		stopPrevent() {},
		/**
		 * 获取分享参数，先进入首页，再跳转内页
		 * @param {Object} path
		 */
		getShareContent(path, query = [], redirect) {
			let imageUrl, title = "";
			if (this.userInfo && this.userInfo.my_invite_code) {
				query.push('u=' + this.userInfo.my_invite_code);
			}
			if (redirect) {
				path = "/pages/index/index";
				query.push(`rdt=${redirect}`)
			}
			if (!this.share.title || this.share.title.trim() == "") {
				//读取首页分享
				this.share = uni.getStorageSync("app_share");
			}
			if (this.share) {
				if (this.share.pageLinkQuery) {
					query.push(this.share.pageLinkQuery);
				}
				if (this.share.title) {
					title = this.share.title;
				}
				//自定义图片路径，可以是本地文件路径、代码包文件路径或者网络图片路径。支持PNG及JPG。显示图片长宽比是 5:4。
				if (this.share.imageUrl) {
					imageUrl = this.share.imageUrl;
				}
			}
			console.log({
				title,
				imageUrl,
				path: path + "?" + query.join('&')
			})
			return {
				title,
				imageUrl,
				path: path + "?" + query.join('&')
			};
		},
		/**
		 * 弹窗二次封装
		 * @param {Object} callback
		 * @param {Object} content
		 * @param {Object} title
		 */
		confirmAction(callback, content = "", title = "") {
			console.log("confirmAction")
			//弹出确定操作
			uni.showModal({
				title,
				content,
				success: (res) => {
					if (res.confirm) {
						callback();
					}
				}
			})
		},
		/**
		 * 默认单个用户信息
		 * @param {Object} data
		 */
		buildUserInfo(data) {
			let defs = {
				balance: 0,
				score: 0,
				coupon: 0,
				avatar: '/static/missing-face.png',
				nickname: '匿名',
			}
			for (let key in defs) {
				if (!data[key]) {
					data[key] = defs[key]
				}
			}
		},
		/**
		 * 默认用户信息列表
		 * @param {Object} data
		 */
		buildMember(data) {
			let info = {
				balance: 0,
				score: 0,
				coupon: 0,
				avatar: '/static/missing-face.png',
				nickname: '匿名'
			};
			data.forEach(item => {
				for (let key in info) {
					if (!item[key]) {
						item[key] = info[key];
					}
				}
			});
		},
		checkBindMobile(content) {
			let info = this.$store.state.user.userInfo;
			if (this.$store.getters['user/isTokenValid'] && this.$store.state.app && this.$store.state.app
				.mustBindMobile && !info.mobile) {
				//必须绑定手机===登录
				console.log("绑定手机号")
				uni.showModal({
					title: "绑定手机",
					content,
					success: (res) => {
						if (res.confirm) {
							this.navTo("/pages/login/bindmobile");
						}
					}
				})
				return false;
			}
			return true;
		},
		setGlobalShareContent(share) {
			if (!share) {
				share = this.$store.state.app.share;
			}
			let userInfo = this.$store.state.user.userInfo;
			if (share && userInfo && userInfo._id) {
				for (let key in share) {
					share[key] = this.$stringFormat(share[key], {
						...userInfo
					}, true);
				}
				console.log("setGlobalShareContent share", share)
				this.share = share;
			}
		},
		adLoad(e) {
			console.log("adLoad: ", e);
		},
		adError(e) {
			// console.log("adError: ", e);
		},
		adClose(e) {
			console.log("adClose: ", e);
		},
	},
}
