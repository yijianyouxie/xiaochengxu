// 开发文档：https://uniapp.dcloud.io/uniCloud/clientdb?id=action
const db = uniCloud.database();
const cmd = db.command;
const visiteCollection = db.collection("opendb-mall-goods-visite");
const goodsCollection = db.collection("opendb-mall-goods");
const {
	getShopInfoById
} = require("tiantian-common")
module.exports = {
	before: async (state, event) => {

	},
	after: async (state, event, error, result) => {
		if (error) {
			throw error
		}
		const {
			uid
		} = state.auth;
		//判断封面图是否与大图一致，
		/* if (result.data.goods_banner_imgs && result.data.goods_banner_imgs.length > 0 && result.data
			.goods_thumb && result.data.goods_banner_imgs[0] == result.data
			.goods_thumb) {
			result.data.goods_banner_imgs.shift();
		} */
		//只有单条访问，才记录浏览量
		await checkGoodsVisite(uid, result.data._id);
		await getShopInfo(result)
		return result
	}
}
const getShopInfo = async (result) => {
	//查询店铺信息
	let shopid = result.data.shop_id;
	if (shopid) {
		result.data.shop = await getShopInfoById(shopid)
	}
}
/**
 * 根据用户信息，判断商品会员折扣
 */
const checkGoodsVisite = async (uid, id) => {
	if (!uid || !id) {
		return false;
	}
	let res = await visiteCollection.where({
		goods_id: id,
		user_id: uid
	}).update({
		update_date: Date.now()
	})
	await goodsCollection.doc(id).update({
		visite_count: cmd.inc(1)
	})
	if (res.updated == 0) {
		//新增
		return await visiteCollection.add({
			goods_id: id,
			user_id: uid,
			create_date: Date.now(),
			update_date: Date.now(),
		})
	}
	//更新时间
	return res;
}
