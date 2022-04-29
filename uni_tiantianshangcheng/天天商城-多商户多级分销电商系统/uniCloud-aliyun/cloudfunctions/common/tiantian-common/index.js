const db = uniCloud.database();
const cmd = db.command;
const shopCollection = db.collection("tian-mall-shops");
const modles = {
	/**
	 * 根据多个店铺id，查询店铺信息
	 * @param {Object} shopIds
	 */
	async getShopsInfoByIds(shopIds) {
		let {
			data
		} = await shopCollection.where({
			_id: cmd.in(shopIds)
		}).field({
			id: 1,
			name: 1,
			src: 1,
			state: 1,
			focus: 1,
			monthSale: 1,
			page_id: 1,
			app_id: 1,
			score: 1,
			online: 1,
		}).get()
		return data.reduce((pre, item) => {
			pre[item._id] = setShopDefaultData(item);
			return pre;
		}, {})
	},
	/**
	 * 根据店铺id，查询信息
	 * @param {Object} id
	 */
	async getShopInfoById(id) {
		let {
			data
		} = await shopCollection.doc(id).field({
			id: 1,
			name: 1,
			src: 1,
			state: 1,
			focus: 1,
			monthSale: 1,
			page_id: 1,
			app_id: 1,
			score: 1,
			online: 1,
		}).get()
		if (data.length > 0) {
			return setShopDefaultData(data[0])
		}
		return {}
	}
}
/**
 * 处理店铺默认信息
 * @param {Object} data
 */
const setShopDefaultData = function(data) {
	let fields = ["focus", "monthSale", "score"]
	fields.map(key => {
		if (!data[key]) {
			data[key + "_text"] = 0
		} else {
			data[key + "_text"] = data[key]
		}
		if (key == "score" && data[key] > 3) {
			data[key + "_text"] = data[key] + " 高"
		} else if (data[key] > 100000) {
			data[key + "_text"] = parseInt(data[key] / 10000) + "万"
		}
	})
	return data;
}
module.exports = modles
