// 开发文档：https://uniapp.dcloud.io/uniCloud/clientdb?id=action
const db = uniCloud.database();
const cmd = db.command;
const cartCollection = db.collection("opendb-mall-cart");
module.exports = {
	before: async (state, event) => {
		//判断当前用户是否已经插入了此条商品到购物车
		const {
			uid
		} = state.auth;
		const {
			goods_id,
			sku_id,
			amount
		} = state.newData;
		const oldCart = await cartCollection.where({
			user_id: uid,
			goods_id,
			sku_id,
		}).field({
			amount: 1
		}).get();
		console.log("查询原购物车信息", uid, goods_id, sku_id, oldCart.data.length)
		if (oldCart.data.length == 0) {
			//需要新增
			if (amount > 0) {
				console.log("新增购物车")
				//添加购物车
				await cartCollection.add({
					user_id: uid,
					goods_id,
					sku_id,
					create_date: Date.now(),
					amount: 0
				})
			} else {
				//减少购物车，商品都不存在
			}
		}
		//最后修改时间
		state.newData.update_date = Date.now();
		state.newData.amount = cmd.inc(amount);
		//去掉商品图片的裁剪
		if (state.newData.goods_thumb) {
			state.newData.goods_thumb = state.newData.goods_thumb.split("?")[0]
		}
	},
	after: async (state, event, error, result) => {
		if (error) {
			throw error
		}
		console.log("after购物车")
		return result
	}
}
