const {
	Service
} = require('uni-cloud-router')
const {
	getTodayTime,
} = require('../util');
module.exports = class CategoryService extends Service {
	constructor(ctx) {
		super(ctx)
		this.collection = this.db.collection('opendb-mall-categories');
	}
	async all() {
		//都按单规格来处理
		let {
			data
		} = await this.collection.where({
			status: true
		}).field({
			name: 1,
			parent_id: 1,
			sort: 1,
		}).orderBy("sort", "asc").limit(500).get();

		let parentData = {};
		//获取父级列表
		data.filter(e => !e.parent_id).map(e => {
			delete e.parent_id;
			delete e.sort;
			parentData[e._id] = {
				...e,
				children: []
			}
		})
		//放到父级
		data.map(e => {
			let parent_id = e.parent_id;
			if (parent_id && parentData[parent_id]) {
				e.name = "|-" + e.name;
				delete e.parent_id;
				delete e.sort;
				parentData[parent_id].children.push(e)
			}
		})
		let out = [];
		for (let pid in parentData) {
			out.push(parentData[pid])
		}
		return out;
	}

}
