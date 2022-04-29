const {
	Service
} = require('uni-cloud-router')
module.exports = class CollectionService extends Service {
	async getAll(collection, condition) {
		this.collection = this.db.collection(collection);
		this.condition = condition;
		return this.getDataByPage(1);
	}

	async getDataByPage(page, limit = 500) {
		let {
			data
		} = await this.collection.where(this.condition).skip((page - 1) * limit).limit(limit).get();
		if (data.length == limit) {
			//查询下一页
			let nextPage = await this.getDataByPage(page + 1, limit);
			data = data.concat(nextPage)
		}
		return data;
	}
}
