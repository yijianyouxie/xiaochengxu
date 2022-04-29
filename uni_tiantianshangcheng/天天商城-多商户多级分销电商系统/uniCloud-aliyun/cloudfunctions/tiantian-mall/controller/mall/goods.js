const {
	Controller
} = require('uni-cloud-router')
module.exports = class GoodsController extends Controller {
	/**
	 * 收藏/取消
	 */
	async favorite() {
		let {
			goods_id,
			isFav
		} = this.ctx.data;
		const {
			uid,
		} = this.ctx.auth;
		return await this.service.mall.goods.setFavorite(uid, goods_id, isFav)
	}
	async categories() {
		return this.service.mall.category.all()
	}
	async imports() {
		let data = {};
		if (!this.ctx.data["name"]) {
			//标题不能为空
			return false;
		}
		for (let key in this.ctx.data) {
			//去除多余的空格，换行
			let item = this.ctx.data[key].replace(/\n/g, "");
			//多图提取第一张为封面图
			if (key == "goods_banner_imgs") {
				item = JSON.parse(item);
				//没有单独上传封面图的情况,把多图拿一张来做封面
				if (item.length > 0 && !this.ctx.data["goods_thumb"]) {
					data["goods_thumb"] = item[0]
					item.shift();
				}
			} else if (key == "category_id") {
				item = [item]
			} else if (key == "price" || key == "market_price") {
				item = parseInt(item)
			}
			data[key] = item;
		}
		return this.service.mall.goods.addGoodsByApi(data);
	}
}
