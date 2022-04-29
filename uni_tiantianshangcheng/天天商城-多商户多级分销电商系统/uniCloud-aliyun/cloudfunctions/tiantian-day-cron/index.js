'use strict';
const db = uniCloud.database();
const cmd = db.command;
const {
	getTodayTime,
} = require('./util');
exports.main = async (event, context) => {
	let day = getTodayTime(1, true)
	//每日积分总计
	await db.collection("uni-id-score-day-statistics").add({
		"day": day,
		"value": 0
	})
	return day
};
