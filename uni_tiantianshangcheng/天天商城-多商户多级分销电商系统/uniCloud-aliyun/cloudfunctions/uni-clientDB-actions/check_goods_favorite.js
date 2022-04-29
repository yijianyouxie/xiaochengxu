const db = uniCloud.database();
const cmd = db.command;
const favCollection = db.collection("opendb-mall-goods-favorite");
// 开发文档：https://uniapp.dcloud.io/uniCloud/clientdb?id=action
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
		let getParams = state.command.getParam({
			name: 'get',
			index: 0
		});
		//是否只返回一条
		let isGetOne = getParams && getParams.length > 0 && getParams[0]["getOne"];

		if (isGetOne) {
			let favs = await checkGoodsFavorite(uid, [result.data._id]);
			result.data.is_fav = (favs && favs.length > 0);
		} else {
			let favs = await checkGoodsFavorite(uid, result.data.map(item => item._id));
			result.data.forEach(item => {
				item.is_fav = (favs && favs.indexOf(item._id) != -1);
			})
		}
		return result
	}
}
/**
 * 根据用户信息，判断商品会员折扣
 */
const checkGoodsFavorite = async (uid, ids) => {
	if (!uid || !ids || ids.length == 0) {
		return false;
	}
	let res = await favCollection.where({
		goods_id: cmd.in(ids),
		user_id: uid
	}).field({
		goods_id: 1
	}).limit(500).get();
	console.log("checkGoodsFavorite", res.data)
	if (res.data.length == 0) {
		return false;
	}
	return res.data.map(e => {
		e.goods_id
	});
}
