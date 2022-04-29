## 天天商城 
基于uniapp+unicloud+uniId开发的多级分销电商系统，突破传统b2c运营模式，引入uniAd广告功能，实现0元可购物、积分+现金购物模式，玩一玩就能得到自己心仪的商品。  
本系统支持一键发布到H5，Android，iOS，微信小程序等小程序系统  

### 小程序体验
![宴席助理](https://vkceyugu.cdn.bspapp.com/VKCEYUGU-adaad390-fa4a-4f33-b3f2-412eeffa13a0/c53304e4-4e4a-45f9-ba60-4121ac3d1970.jpg?x-oss-process=image/resize,m_fill,w_200,h_200)
![永福市场小程序](https://vkceyugu.cdn.bspapp.com/VKCEYUGU-3fbab731-e993-47e6-882f-a74e444709a3/eb960efa-b306-47c9-a481-a8043d3fc2bc.jpg?x-oss-process=image/resize,m_fill,w_200,h_200)
![这有米小程序](https://vkceyugu.cdn.bspapp.com/VKCEYUGU-3fbab731-e993-47e6-882f-a74e444709a3/f6ce02f9-de81-4c78-b5b1-e30e1ef6f3dc.png?x-oss-process=image/resize,m_fill,w_200,h_200)
![惠民](https://vkceyugu.cdn.bspapp.com/VKCEYUGU-3fbab731-e993-47e6-882f-a74e444709a3/b782fca8-ebaa-4082-8d83-69b599e3f495.png?x-oss-process=image/resize,m_fill,w_200,h_200)

### 后台地址
[https://ext.dcloud.net.cn/plugin?id=6767](https://ext.dcloud.net.cn/plugin?id=6767)  

### 安装步骤
#### 在线安装（推荐）：
1. 在插件市场点击“导入插件并试用”或者购买源码授权版，
2. 同意付费插件试用协议，
3. 选择绑定的服务空间，
4. 勾选部署云函数，初始化db_init后（全部勾选），点击“直接部署服务空间”，
5. 如果有提示覆盖公共模块，点击“覆盖并重新部署”。  
6. 等待服务器自动执行安装操作

#### 手动安装：
1. 在插件市场点击“导入插件并试用”或者购买源码授权版，
2. 同意付费插件试用协议，
3. 选择绑定的服务空间，
4. 点击跳过
5. 继续导入HBuilderX（[安装最新编辑器](https://www.dcloud.io/hbuilderx.html)）
6. 编辑器提示新建项目
7. uniCloud目录右键，运行云服务空间安装向导
8. 选择第三步选择的云服务空间
9. 下一步，并开始部署

### uni-id插件相比官方新增功能
* 增加百度小程序登录，授权获取手机号
* 增加头条小程序登录
* 增加注册连带写入邀请者
* 增加推广渠道信息，uni-id-channel

### uni-pay插件相比官方新增功能
* 增加微信付款到零钱
* 增加服务商模式下单、添加特约商户分账接收方、完结分账

### 批量上传商品
#### 火车头批量采集并上传
1. 下载[采集模块](https://vkceyugu.cdn.bspapp.com/VKCEYUGU-3fbab731-e993-47e6-882f-a74e444709a3/ff065592-9fac-4a2b-b201-51bd405314aa.wpm)，导入到火车头
2. web发布配置，选择“天天商城”，网页编码选择utf-8；全局变量填写/common/uni-config-center/tiantian-mall/config.json内apiToken值，此token不能为空；网址地址填写云函数URL化后，复制完整地址，例如：https://xxx.com/http/mall；登录方式选择不登录；上述配置完成后，点击获取列表，将获得商品分类；填写配置名后添加
3. 发布提交的字段包含：price，market_price，name，goods_banner_imgs（图片地址数组），category_id

### 系统参数配置
系统统一配置均依靠uni-config-center，原始目录是/uni_modules/uni-config-center/uniCloud/cloudfunctions/common/uni-config-center  编辑器自动映射后uniCloud/cloudfunctions/common/uni-config-center  
* uni-config-center/uni-id/config.json
	* 可修改app、小程序appid登录配置；
	* 短信key和secret；
	* 一键登录key和secret
* uni-config-center/tiantian-mall/config.json，
	* 可修改支付通知地址（domain）；
	* 支付类型（payment）与参数；
	* 广告位（adConfig）配置；
	* 微信企业转账到零钱配置（transfers）；
	* 短信登录模板id（service）；
	* 推送配置（push）；
	* 同城配送（delivery）；
	* 快递配送（express）；
	* 用户推荐团队（user）；
	* 前端自定义参数（customer）；
	* 前端分享（share）；
	* 商城分成返利、积分等（mall）
* uni-config-center/__UNI__9E9D6A0/config.json 如果一套后台，发布到多个应用，这个目录结构的参数，可以独立配置参数，与tiantian-mall/config.json合并，这里配置优先，可变参数例如：支付、广告
	
### 咨询QQ群
* 交流QQ群：298724327  

### 柔然科技承接软件定制开发
* 联系人：文经理
* QQ：343169893
* [柔然科技官网www.cqsort.com](http://www.cqsort.com/)

### 测试与案例
#### 测试地址 
H5预览 [http://tian.cqsort.com/](http://tian.cqsort.com/)  
后台体验
http://tian.cqsort.com/admin/  
账号：test  
密码：123456  

Android版 [天天商城apk](https://bsppub.oss-cn-shanghai.aliyuncs.com/VKCEYUGU-3fbab731-e993-47e6-882f-a74e444709a3/521f5b3b-9058-4175-8682-74209a236d83.apk)  
![扫码下载](https://vkceyugu.cdn.bspapp.com/VKCEYUGU-3fbab731-e993-47e6-882f-a74e444709a3/c604889b-b866-4237-b03b-002ba1cde695.png)  
#### 客户案例
![这有米二维码](https://vkceyugu.cdn.bspapp.com/VKCEYUGU-3fbab731-e993-47e6-882f-a74e444709a3/a6e00621-de8d-46ef-9744-e543075ae4a8.png)   
![惠民](https://vkceyugu.cdn.bspapp.com/VKCEYUGU-3fbab731-e993-47e6-882f-a74e444709a3/e549bd0b-8106-4c4b-9bb0-cb30c73a5bac.png)  
![惠民apk](https://vkceyugu.cdn.bspapp.com/VKCEYUGU-3fbab731-e993-47e6-882f-a74e444709a3/f9fb4dd9-1003-49b9-9e5a-91a6833768a4.png)
[惠民.apk](https://vkceyugu.cdn.bspapp.com/VKCEYUGU-3fbab731-e993-47e6-882f-a74e444709a3/7acd57cb-a07b-46e4-806b-09c96e736c00.apk)

### 功能导读
![图](https://vkceyugu.cdn.bspapp.com/VKCEYUGU-3fbab731-e993-47e6-882f-a74e444709a3/7e78ab50-b29f-4bd7-8045-1e0df4d22b90.png)

### 目录结构
```
    |-- App.vue
    |-- changelog.md
    |-- config.js
    |-- main.js
    |-- manifest.json
    |-- package-lock.json
    |-- package.json
    |-- pages.json
    |-- README.md
    |-- uni.scss
    |-- uni_modules.config.json
    |-- .hbuilderx
    |   |-- debug.config.json
    |   |-- launch.json
    |-- common
    |   |-- css
    |   |   |-- font_2479288_9cqg4e7ml9.css
    |   |   |-- github-markdown.css
    |   |   |-- style.scss
    |   |   |-- theme.scss
    |   |-- js
    |   |   |-- ad.js
    |   |   |-- cache.js
    |   |   |-- filter.js
    |   |   |-- form.js
    |   |   |-- marked.js
    |   |   |-- moments.js
    |   |   |-- uqrcode.js
    |   |   |-- util.js
    |   |-- mixin
    |       |-- ad.js
    |       |-- map.js
    |       |-- mixin.js
    |       |-- upload.js
    |       |-- share
    |           |-- mp.js
    |-- components
    |   |-- j-msg
    |   |   |-- j-msg.nvue
    |   |-- j-video
    |       |-- j-video.vue
    |-- data
    |   |-- app_qq_login.json
    |   |-- app_weibo_login.json
    |   |-- app_wx_login.json
    |   |-- ctx.json
    |-- js_sdk
    |   |-- implemented
    |   |   |-- h5.js
    |   |-- mall
    |   |   |-- interceptor.js
    |   |   |-- plugin.js
    |   |   |-- request.js
    |   |   |-- util.js
    |   |-- validator
    |       |-- tian-user-cashouts.js
    |       |-- uni-id-address.js
    |-- pages
    |   |-- address
    |   |   |-- add.vue
    |   |   |-- detail.vue
    |   |   |-- edit.vue
    |   |   |-- list.vue
    |   |-- admin
    |   |   |-- admin.vue
    |   |-- app
    |   |   |-- about.vue
    |   |   |-- article.vue
    |   |   |-- contact.vue
    |   |   |-- feedback.vue
    |   |   |-- pages.vue
    |   |   |-- share.vue
    |   |   |-- web.vue
    |   |-- index
    |   |   |-- agreement.vue
    |   |   |-- cart.vue
    |   |   |-- category.vue
    |   |   |-- index.vue
    |   |   |-- search.vue
    |   |   |-- user.vue
    |   |   |-- mixin
    |   |       |-- tabbar.js
    |   |-- login
    |   |   |-- login.vue
    |   |   |-- mixin
    |   |       |-- app.js
    |   |       |-- mp-alipay.js
    |   |       |-- mp-weixin.js
    |   |-- msg-center
    |   |   |-- msg-center.nvue
    |   |-- order
    |   |   |-- coupons.vue
    |   |   |-- create.vue
    |   |   |-- detail.vue
    |   |   |-- invoice.vue
    |   |   |-- message.vue
    |   |   |-- order.vue
    |   |-- product
    |   |   |-- detail.vue
    |   |   |-- favorite.vue
    |   |   |-- visite.vue
    |   |-- user
    |       |-- account.vue
    |       |-- achievement.vue
    |       |-- avatar.vue
    |       |-- balances.vue
    |       |-- cashout.vue
    |       |-- coupons.vue
    |       |-- info.vue
    |       |-- invite.vue
    |       |-- scores.vue
    |       |-- setinviter.vue
    |       |-- tasks.vue
    |       |-- score
    |       |   |-- cashout.vue
    |       |   |-- ranking.vue
    |       |   |-- transfer.vue
    |       |-- team
    |           |-- member.vue
    |           |-- team.vue
    |-- static
    |   |-- errorImage.jpg
    |   |-- loadingbg.jpg
    |   |-- logo.png
    |   |-- missing-face.png
    |   |-- play.png
    |   |-- font
    |   |   |-- iconfont.ttf
    |   |   |-- iconfont.woff
    |   |   |-- iconfont.woff2
    |   |-- images
    |   |   |-- invite.jpg
    |   |   |-- qrcode_bg.png
    |   |-- tab
    |       |-- tab-cart-current.png
    |       |-- tab-cart.png
    |       |-- tab-cate-current.png
    |       |-- tab-cate.png
    |       |-- tab-home-current.png
    |       |-- tab-home.png
    |       |-- tab-my-current.png
    |       |-- tab-my.png
    |       |-- tab-play-current.png
    |       |-- tab-play.png
    |       |-- tab_video.png
    |       |-- tab_video_current.png
    |-- store
    |   |-- index.js
    |   |-- modules
    |       |-- app.js
    |       |-- mall.js
    |       |-- user.js
    |-- uniCloud-aliyun
    |   |-- cloudfunctions
    |   |   |-- tiantian-day-cron
    |   |   |   |-- index.js
    |   |   |   |-- package-lock.json
    |   |   |   |-- package.json
    |   |   |   |-- util.js
    |   |   |-- tiantian-mall
    |   |   |   |-- config.js
    |   |   |   |-- index.js
    |   |   |   |-- package-lock.json
    |   |   |   |-- package.json
    |   |   |   |-- tiantian-mall.param.json
    |   |   |   |-- controller
    |   |   |   |   |-- app.js
    |   |   |   |   |-- payment.js
    |   |   |   |   |-- utils.js
    |   |   |   |   |-- admin
    |   |   |   |   |   |-- order.js
    |   |   |   |   |   |-- score_day_statistics.js
    |   |   |   |   |   |-- tian_user_cashouts.js
    |   |   |   |   |   |-- uni_id_score.js
    |   |   |   |   |   |-- user.js
    |   |   |   |   |-- mall
    |   |   |   |   |   |-- cart.js
    |   |   |   |   |   |-- express.js
    |   |   |   |   |   |-- goods.js
    |   |   |   |   |   |-- order.js
    |   |   |   |   |-- system
    |   |   |   |   |   |-- app.js
    |   |   |   |   |-- user
    |   |   |   |       |-- info.js
    |   |   |   |       |-- login.js
    |   |   |   |       |-- score.js
    |   |   |   |       |-- task.js
    |   |   |   |-- middleware
    |   |   |   |   |-- auth.js
    |   |   |   |   |-- cache.js
    |   |   |   |   |-- config.js
    |   |   |   |   |-- init.js
    |   |   |   |   |-- permission.js
    |   |   |   |-- service
    |   |   |       |-- util.js
    |   |   |       |-- expresses
    |   |   |       |   |-- kuai100.js
    |   |   |       |-- mall
    |   |   |       |   |-- cart.js
    |   |   |       |   |-- express.js
    |   |   |       |   |-- goods.js
    |   |   |       |   |-- order.js
    |   |   |       |-- order
    |   |   |       |   |-- mall.js
    |   |   |       |   |-- readme.md
    |   |   |       |-- payment
    |   |   |       |   |-- alipay.js
    |   |   |       |   |-- balance.js
    |   |   |       |   |-- delivery.js
    |   |   |       |   |-- readme.md
    |   |   |       |   |-- unipay.js
    |   |   |       |   |-- wxpay.js
    |   |   |       |-- system
    |   |   |       |   |-- app.js
    |   |   |       |-- task
    |   |   |       |   |-- article.js
    |   |   |       |-- user
    |   |   |           |-- address.js
    |   |   |           |-- order.js
    |   |   |           |-- repair.js
    |   |   |           |-- score.js
    |   |   |           |-- task.js
    |   |   |           |-- user.js
    |   |   |-- uni-clientDB-actions
    |   |       |-- backup.js
    |   |       |-- cart.js
    |   |       |-- cart_goods.js
    |   |       |-- check_goods_favorite.js
    |   |       |-- check_order.js
    |   |       |-- genId.js
    |   |       |-- goods_member.js
    |   |       |-- goods_skus.js
    |   |       |-- goods_visite.js
    |   |       |-- mobile.js
    |   |-- database
    |       |-- db_init.json
    |       |-- JQL查询.jql
    |       |-- mall-cart.jql
    |       |-- mall-categories.jql
    |       |-- mall-goods.jql
    |       |-- mall-sku.jql
    |       |-- news-article-read.jql
    |       |-- opendb-admin-menus.schema.json
    |       |-- opendb-city-china.schema.json
    |       |-- opendb-mall-goods-days.schema.json
    |       |-- opendb-verify-codes.schema.json
    |       |-- tian-identity.schema.json
    |       |-- tian-mall-coupon-users.schema.json
    |       |-- tian-mall-coupons.schema.json
    |       |-- tian-mall-orders-backup.schema.json
    |       |-- tian-mall-orders.schema.json
    |       |-- tian-mall-shops.schema.json
    |       |-- tian-page-components.schema.json
    |       |-- tian-pages.schema.json
    |       |-- tian-payment-types.schema.json
    |       |-- tian-user-cashouts.schema.json
    |       |-- uni-id-address.schema.json
    |       |-- uni-id-balances.schema.json
    |       |-- uni-id-base-order.schema.json
    |       |-- uni-id-log.schema.json
    |       |-- uni-id-permissions.schema.json
    |       |-- uni-id-roles.schema.json
    |       |-- uni-id-score-cashout.schema.json
    |       |-- uni-id-score-day-statistics.schema.json
    |       |-- uni-id-score-transfer.schema.json
    |       |-- uni-id-scores.schema.json
    |       |-- uni-id-task-log.schema.json
    |       |-- uni-id-task.schema.json
    |       |-- uni-id-users.schema.json
    |       |-- user-invite.jql
	|-- uni_modules
		|-- tian-article
		|   |-- changelog.md
		|   |-- package.json
		|   |-- pages.json
		|   |-- readme.md
		|   |-- components
		|   |   |-- tian-article
		|   |       |-- layouts.js
		|   |       |-- tian-article.vue
		|   |-- pages
		|   |   |-- article
		|   |       |-- detail.vue
		|   |-- uniCloud
		|       |-- cloudfunctions
		|       |   |-- uni-clientDB-actions
		|       |       |-- article_favorite.js
		|       |       |-- article_read.js
		|       |       |-- article_read_check.js
		|       |-- database
		|           |-- opendb-news-article-read.schema.json
		|           |-- opendb-news-articles.schema.json
		|           |-- opendb-news-categories.schema.json
		|           |-- opendb-news-comments.schema.json
		|           |-- opendb-news-favorite.schema.json
		|-- tian-banner
		|   |-- changelog.md
		|   |-- package.json
		|   |-- readme.md
		|   |-- components
		|   |   |-- tian-banner
		|   |       |-- tian-banner.vue
		|   |-- uniCloud
		|       |-- database
		|           |-- opendb-banner-category.schema.json
		|           |-- opendb-banner.schema.json
		|-- tian-empty
		|   |-- changelog.md
		|   |-- package.json
		|   |-- readme.md
		|   |-- components
		|       |-- tian-empty
		|           |-- tian-empty.vue
		|-- tian-express
		|   |-- changelog.md
		|   |-- package.json
		|   |-- readme.md
		|   |-- components
		|       |-- tian-express
		|       |   |-- express.js
		|       |   |-- tian-express.vue
		|       |-- tian-express-detail
		|           |-- tian-express-detail.vue
		|-- tian-grides
		|   |-- changelog.md
		|   |-- package.json
		|   |-- readme.md
		|   |-- components
		|       |-- tian-grides
		|           |-- tian-grides.vue
		|-- tian-icons
		|   |-- changelog.md
		|   |-- package.json
		|   |-- readme.md
		|   |-- components
		|       |-- tian-icons
		|           |-- tian-icons.vue
		|-- tian-mall
		|   |-- changelog.md
		|   |-- package.json
		|   |-- readme.md
		|   |-- components
		|   |   |-- tian-goods-join-list
		|   |   |   |-- tian-goods-join-list.vue
		|   |   |-- tian-goods-list
		|   |   |   |-- tian-goods-list.vue
		|   |   |-- tian-goods-nav
		|   |   |   |-- tian-goods-nav.vue
		|   |   |-- tian-goods-price
		|   |   |   |-- tian-goods-price.vue
		|   |   |-- tian-goods-sku
		|   |   |   |-- tian-goods-sku.vue
		|   |   |-- tian-mall
		|   |       |-- tian-mall.vue
		|   |-- uniCloud
		|       |-- database
		|           |-- opendb-mall-cart.schema.json
		|           |-- opendb-mall-categories.schema.json
		|           |-- opendb-mall-comments.schema.json
		|           |-- opendb-mall-express.schema.json
		|           |-- opendb-mall-goods-favorite.schema.json
		|           |-- opendb-mall-goods-visite.schema.json
		|           |-- opendb-mall-goods.schema.json
		|           |-- opendb-mall-sku.schema.json
		|-- tian-pages
		|   |-- changelog.md
		|   |-- package.json
		|   |-- readme.md
		|   |-- components
		|       |-- tian-pages
		|           |-- tian-pages.vue
		|-- tian-payment
		|   |-- changelog.md
		|   |-- package.json
		|   |-- readme.md
		|   |-- components
		|       |-- tian-payment
		|           |-- tian-payment.vue
		|-- tian-search-bar
		|   |-- changelog.md
		|   |-- package.json
		|   |-- readme.md
		|   |-- components
		|       |-- tian-search-bar
		|           |-- tian-search-bar.vue
		|-- tian-single-user
		|   |-- changelog.md
		|   |-- package.json
		|   |-- readme.md
		|   |-- components
		|       |-- tian-single-user
		|           |-- tian-single-user.vue
		|-- tian-skeleton
		|   |-- changelog.md
		|   |-- package.json
		|   |-- readme.md
		|   |-- components
		|       |-- tian-skeleton
		|           |-- tian-skeleton.vue
		|-- tian-tab-pages
		|   |-- changelog.md
		|   |-- package.json
		|   |-- readme.md
		|   |-- components
		|       |-- tian-tab-pages
		|           |-- tian-tab-pages.vue
```