'use strict';
const fs = require("fs")
const db = uniCloud.database();
/**
 * 本地执行云函数，生成db_init.json，外网无法访问
 */
exports.main = async (event, context) => {
	let origin = require('./db_init_origin.json')
	//event为客户端上传的参数
	let collections = Object.keys(origin);

	/**
	 * 导出所有数据的表
	 */
	let allDataCollection = ["opendb-admin-menus", "opendb-banner", "opendb-banner-category",
		"tian-mall-categories",
		"opendb-city-china", "opendb-mall-categories", "opendb-mall-goods", "opendb-mall-sku",
		"opendb-news-articles", "opendb-news-categories", "tian-identity", "tian-page-components",
		"tian-pages", "tian-payment-types", "uni-id-permissions", "uni-id-roles"
	]
	for await (let coll of allDataCollection) {
		//查询数据，默认只查询了100条
		origin[coll].data = await getDataByPage(coll, 1);
		console.log(`${coll}导出完成`)
	}
	console.log("全部导出完成")
	fs.writeFileSync('../database/db_init.json', JSON.stringify(origin))
	console.log("写入完成")
	return origin;
};

const getDataByPage = async (coll, page, limit = 500) => {
	let {
		data
	} = await db.collection(coll).skip((page - 1) * limit).limit(500).get();
	if (data.length == limit) {
		data = data.concat(await getDataByPage(coll, page + 1, limit))
	}
	return data;
}
