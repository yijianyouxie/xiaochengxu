const {
	Service
} = require('uni-cloud-router')
const {
	getTodayTime,
} = require('../util');
module.exports = class GoodsService extends Service {
	constructor(ctx) {
		super(ctx)
		this.collection = this.db.collection('opendb-mall-goods');
		this.favCollection = this.db.collection('opendb-mall-goods-favorite');
		this.skuCollection = this.db.collection('opendb-mall-sku');
		this.goodsDayscollection = this.db.collection('opendb-mall-goods-days')
	}
	async getGoodsSkuByCart(goodsData, member, useScoreRate, usedScore, score2moneyRate, exchange_points_for_cash) {
		let divider = "&gt;";
		let discount = 0;
		let total = 0;
		let use_score_total = 0;
		let needScore = 0;
		let shopIds = [];
		let gids = goodsData.map(car => car.goods_id);
		let skuids = goodsData.map(car => car.sku_id);
		let goodsDataMap = await this.getGoodsByIds(gids, true);
		let skuDataMap = await this.getGoodsSkuByIds(skuids, true);
		let disable = false;
		let needAddress = false;
		let group_buying_id = "",
			group_buying = false;
		goodsData.forEach(goods => {
			goods.discount = 0;
			//商品数量必须是整数
			goods.amount = goods.amount > 1 ? parseInt(goods.amount) : 1;
			if (goods.group_buying) {
				group_buying = goods.group_buying;
				group_buying_id = goods.group_buying_id;
			}
			goods = Object.assign(goods, {
				...goodsDataMap[goods.goods_id],
				...skuDataMap[goods.sku_id],
			})
			if (group_buying && goods.group_buying) {
				//拼单优惠
				if (goods.group_buying_discount > 0) {
					goods.discount += goods.group_buying_discount * goods.amount;
					// discount += goods.group_buying_discount * goods.amount;
				}
			} else {
				//删除拼单信息
				delete goods.group_buying;
			}
			//库存不足
			goods.disable = goods.stock - goods.amount < 0;
			if (goods.disable) {
				disable = true;
			}
			if (goods.is_real) {
				needAddress = true;
			}
			//处理多规格名称为+
			goods.sku_name = goods.sku_name ? goods.sku_name.split(divider).join("+") : "";
			total += goods.total = goods.price * goods.amount;
			//会员商品，显示会员价格
			if (goods.is_vip && member && member.enable) {
				//完全是整数乘除，避免double类型错误
				goods.discount += (goods.price * goods.amount * (100 - parseInt(member.rate * 100))) /
					100;
				goods.member = member;
			}
			//使用积分总数/商品总数=使用比例，这里只用作初次预结算
			if (goods.use_score_rate && goods.use_score_rate > 0 && score2moneyRate > 0) {
				//需要多少积分金钱，单位是分，必须是整数
				goods.scoreMoney = parseInt(goods.use_score_rate * goods.price);
				//转换为积分个数
				let scoreCount = goods.scoreMoney / score2moneyRate / 100;
				goods.use_score = scoreCount;
				use_score_total += scoreCount * goods.amount;
				//商品原总价
				goods.origin_price = goods.price;
				//积分+现金模式
				if (!usedScore) {
					if (exchange_points_for_cash) {
						goods.price = goods.price - goods.scoreMoney;
					}
					needScore += goods.use_score * goods.amount;
				}
			} else if (goods.use_score) {
				//直接使用积分
				goods.scoreMoney = goods.use_score * score2moneyRate * 100;
				goods.origin_price = goods.price;
				use_score_total += goods.use_score * goods.amount;
				if (!usedScore) {
					if (exchange_points_for_cash) {
						goods.price = parseInt((goods.price - goods.scoreMoney).toFixed(2));
					}
					needScore += goods.use_score * goods.amount;
				}
			}
			if (goods.shop_id && shopIds.indexOf(goods.shop_id) == -1) {
				shopIds.push(goods.shop_id);
			}

			discount += goods.discount;
		})
		if (disable) {
			return {
				code: -1,
				message: '商品库存不足'
			}
		}
		if (usedScore) {
			//分摊商品积分，分摊比例
			let rate = usedScore / use_score_total;
			console.log("分摊比例", usedScore, use_score_total, rate);
			goodsData.forEach(goods => {
				if (goods.use_score) {
					//实际使用积分数量
					goods.use_score = goods.use_score * rate;
					//积分转成金额，计算商品单价，单位为分
					goods.scoreMoney = goods.use_score * score2moneyRate * 100;
					if (exchange_points_for_cash) {
						goods.price = goods.origin_price - goods.scoreMoney;
					}
					goods.total_use_score = goods.use_score * goods.amount;
					needScore += goods.total_use_score;
				}
			});
		}
		let shopList = await this.service.mall.shop.getInfoByIds(shopIds);
		if (shopList) {
			//把商品放到店铺里面
			goodsData.map(goods => {
				shopList[goods.shop_id].goodsList.push(goods)
			})
			shopList = Object.values(shopList)
		}
		console.log("shopList", shopList)
		console.log("goodsData", goodsData)
		return {
			discount,
			total,
			needScore,
			group_buying,
			group_buying_id,
			use_score_total,
			shopIds,
			shopList,
			needAddress
		};
	}
	async addGoodsByApi(data) {
		//都按单规格来处理
		return this.collection.add({
			"seller_note": "",
			"market_price": 0,
			"price": 100,
			"goods_sn": Date.now() + '' + (Math.random() + '').substr(2, 5),
			...data,
			"add_date": Date.now(),
			"last_modify_date": Date.now(),
			"remain_count": parseInt(Math.random() * 500),
			"month_sell_count": parseInt(Math.random() * 100),
			"total_sell_count": parseInt(Math.random() * 5100),
			"comment_count": 0,
			"is_real": true,
			"is_on_sale": true,
			"is_alone_sale": true,
			"is_best": false,
			"is_new": true,
			"is_hot": false,
		})
	}

	async getGoodsByIds(ids, isMap = false) {
		const cmd = this.db.command;
		let res = await this.collection.where({
			_id: cmd.in(ids),
			is_on_sale: true
		}).field({
			_id: 1,
			goods_sn: 1,
			name: 1,
			is_vip: 1,
			category_id: 1,
			express_id: 1,
			goods_thumb: 1,
			remain_count: 1,
			use_score: 1,
			shop_id: 1,
			is_real: 1, //是否实物
			offline_time: 1, //下架时间
			use_score_rate: 1,
			rebate_score_rate: 1,
			rebate_money_rate: 1,
			rebate_self_money: 1,
			rebate_service: 1,
			rebate_pension_dividends: 1,
			rebate_score_dividends: 1,
			get_service_month: 1,
			vip_level_id: 1,
			group_buying: 1,
			group_buying_discount: 1,
			price: 1,
			market_price: 1,
		}).get();
		if (isMap) {
			//单规格库存
			res.data.forEach(item => {
				item.stock = item.remain_count;
			})
			return this.buildMap(res);
		}
		return res.data;
	}

	async getGoodsSkuByIds(ids, isMap = false) {
		if (ids && ids.length > 0) {
			const cmd = this.db.command;
			let res = await this.skuCollection.where({
				_id: cmd.in(ids),
			}).field({
				_id: 1,
				sku_name: 1,
				goods_thumb: 1,
				stock: 1,
				price: 1,
				market_price: 1,
			}).get();
			if (isMap) {
				res.data.forEach(item => {
					//删除缩略图字段
					if (!item.goods_thumb) {
						delete item.goods_thumb;
					}
				})
				return this.buildMap(res);
			}
			return res.data;
		}
		return {}
	}

	async setFavorite(uid, goods_id, isFav) {
		let res = await this.favCollection.where({
			goods_id: goods_id,
			user_id: uid
		}).field({
			goods_id: 1
		}).limit(1).get();
		if (isFav) {
			//已收藏
			if (res.data.length > 0) {
				return true;
			}
			await this.favCollection.add({
				goods_id: goods_id,
				user_id: uid,
				create_date: Date.now(),
				update_date: Date.now(),
			})
			return true;
		} else {
			if (res.data.length == 0) {
				return false;
			}
			await this.favCollection.doc(res.data[0]._id).remove();
			return false;
		}
	}


	buildMap(res) {
		let data = {}
		res.data.map(item => {
			data[item._id] = {
				...item,
				_id: undefined
			}
		})
		return data;
	}
	/**
	 * 更新商品每日销量
	 * @param {Object} goodsList
	 */
	async updateGoodsDaySales(goodsList) {
		// console.log("goodsList", goodsList)
		const cmd = this.db.command;
		let today = getTodayTime(0, 1);
		let goods = {};
		goodsList.map(g => {
			if (!goods[g.goods_id]) {
				goods[g.goods_id] = g.amount * 1
			} else {
				goods[g.goods_id] += g.amount * 1
			}
		})
		//转换成
		let goods_save = {}
		let goods_new_save = {}
		for (let id in goods) {
			goods_save[id] = cmd.inc(goods[id])
			goods_new_save[id] = goods[id]
		}
		console.log("goods", goods)
		//更新商品的销量统计,不可撤销，后面定时器更新商品月售
		let {
			updated
		} = await this.goodsDayscollection.where({
			day: today
		}).update({
			goods: goods_save
		})
		//需要新增
		if (updated == 0) {
			return await this.goodsDayscollection.add({
				day: today,
				goods: goods_new_save
			})
		}
		return {
			updated
		}
	}
	/**
	 * 更新商品销量
	 * @param {Object} goodsList
	 */
	async updateGoodsSkuSales(goodsList) {
		const cmd = this.db.command;
		let today = getTodayTime(0, 1);
		//按数量统计商品，然后分批递增
		let goodsAmount = {};
		let skuAmount = {};
		goodsList.map(g => {
			if (!goodsAmount[g.amount]) {
				goodsAmount[g.amount] = [];
			}
			goodsAmount[g.amount].push(g.goods_id);
			if (g.sku_id) {
				if (!skuAmount[g.amount]) {
					skuAmount[g.amount] = [];
				}
				skuAmount[g.amount].push(g.sku_id);
			}
		})
		console.log(goodsAmount, skuAmount)
		//对象转换成数组
		let goodsList2 = [];
		for (let amount in goodsAmount) {
			goodsList2.push({
				amount: parseInt(amount),
				ids: goodsAmount[amount]
			})
		}
		for (let g of goodsList2) {
			await this.collection.where({
				_id: cmd.in(g.ids)
			}).update({
				month_sell_count: cmd.inc(g.amount),
				total_sell_count: cmd.inc(g.amount),
				remain_count: cmd.inc(g.amount * -1),
			})
		}

		let skuList2 = [];
		for (let amount in skuAmount) {
			skuList2.push({
				amount: parseInt(amount),
				ids: skuAmount[amount]
			})
		}
		for (let g of skuList2) {
			await this.skuCollection.where({
				_id: cmd.in(g.ids)
			}).update({
				stock: cmd.inc(g.amount * -1),
			})
		}
	}
}
