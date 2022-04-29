const {
	Controller
} = require('uni-cloud-router')
module.exports = class CartController extends Controller {
	/**
	 * 删除购物车
	 */
	async remove() {
		let {
			ids
		} = this.ctx.data;
		const {
			uid,
		} = this.ctx.auth;
		if (!uid || !ids || ids.length == 0) {
			return false;
		}
		return await this.service.mall.cart.remove(uid, ids)
	}
}
