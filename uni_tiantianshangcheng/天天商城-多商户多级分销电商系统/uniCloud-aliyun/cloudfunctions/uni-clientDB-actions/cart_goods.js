// 开发文档：https://uniapp.dcloud.io/uniCloud/clientdb?id=action
const {
	getShopsInfoByIds
} = require("tiantian-common")
module.exports = {
	before: async (state, event) => {

	},
	after: async (state, event, error, result) => {
		if (error) {
			throw error
		}
		let divider = "&gt;";
		//查询店铺信息
		let shopMap = {},
			shopIds = [];
		//把商品数据合并到购物车里面，
		result.data.forEach(item => {
			item.cart_id = item._id;
			//加入购物车时候的价格
			item.add_price = item.price;
			let goods = item.goods_id;
			let sku = item.sku_id;
			if (goods && goods.length > 0) {
				delete goods[0]._id;
				Object.assign(item, {
					...goods[0]
				})
			}
			//处理多规格
			if (sku && sku.length > 0) {
				delete sku[0]._id;
				Object.assign(item, {
					...sku[0]
				})
				//处理多规格名称为+
				item.sku_name = item.sku_name.split(divider).join("+")
			}
			if (item.shop_id) {
				shopIds.push(item.shop_id)
			}
		})
		if (shopIds.length > 0) {
			shopMap = await getShopsInfoByIds(shopIds);
			result.data.forEach(item => {
				if (item.shop_id) {
					item.shop = shopMap[item.shop_id]
				}
			});
			result.shops = Object.values(shopMap)
		}
		return result
	}
}
