using System;
using UnityEngine;
using System.Collections;

public class  DataEvent 
{
    public static string TableLoaded = "TableLoaded";

    public static string MyPetCreate = "C_MyPetCreate";
    public static string MyChildCreate = "C_MyChildCreate";

    public static string OnSetNamePanelShow = "C_OnSetNamePanelShow";

    public static string ShowStarDungeon = "C_ShowStarDungeonUI";

    public static string MSDK_WakeUp = "C_MSDK_WakeUp";

    //事件管理器tick
    public static string EventTick = "C_EventTick";
    //GameManager初始化完毕 暂定
    public static string GameInit = "C_GameInit";

    public static string ShowNativeLog = "C_ShowNativeLog";

    public static string LuaInitFinish = "C_LuaInitFinish";

    public static string TX_AD_ActiveApp = "C_TX_AD_ActiveApp";

    public static string MSDK_WXDeeplink = "C_MSDK_WXDeeplink";

    public static string MSDK_IEG_Report = "C_MSDK_IEG_Report";
    public static string MSDK_IEG_Confirm = "C_MSDK_IEG_Confirm";
    //打包动态图集出错
    public static string DynamicAtlasResult = "C_DynamicAtlasResult";

    //GCConnect返回 通知
    public static string OnConnect = "C_OnConnect";
    //连接丢失
    public static string ConnectionLost = "C_ConnectionLost";
    //同步服务器时间
    public static string ServerTimeUpdate = "C_ServerTimeUpdate";

    public static string ItemInfoCmd = "C_ItemInfoCmd";
    public static string PetInfoCmd = "C_PetInfoCmd";

    //mainplayer是否已就绪
    public static string MainPlayerRenderReady = "C_MainPlayerReady";

    //
    public static string BackToLogin = "C_BackToLogin";
    public static string BackToLogin2C = "C_BackToLogin2C";
    public static string ChangeAccount = "C_ChangeAccount";

    public static string Platform_DiffAccount_ChangeAccount = "C_Platform_DiffAccount_ChangeAccount";

    public static string CleanPlatformAllData = "C_CleanPlatformAllData";

    // 游戏焦点变化
    public static string OnApplicationFocusChange = "C_OnApplicationFocusChange";
    public static string OnApplicationPauseChange = "C_OnApplicationPauseChange";
    //本次游戏首次登陆
    public static string FirstLogin = "C_FirstLogin";
    /// <summary>
    /// 表加载完毕
    /// </summary>
    public static string TableInit = "C_TableInit";

    //游戏初始化完毕
    public static string GameInitOk = "C_GameInitOk";

    /// <summary>
    /// bugly日志[msg, level]
    /// </summary>
    public static string BuglyLog = "C_BuglyLog";

    /// <summary>
    /// UI Command返回
    /// </summary>
    public static string OnUICommand = "C_OnUICommand";

    /// <summary>
    /// 清空所有缓存UI
    /// </summary>
    public static string ClearCacheUI = "C_ClearCacheUI";

    /// <summary>
    /// 技能初始化
    /// </summary>
    public static string SkillInit = "C_SkillInit";
	//更新技能列表
	public static string SkillListUpdate = "C_SkilListUpdate";
	//更新人物变形之后的技能列表
	public static string SkillTransStateUpdate = "C_SkillTransStateUpdate";
	//人物获得新技能
	public static string SkillAdd = "C_SkillAdd";
	//人物移除技能
	public static string SkillRemove = "C_SkillRemove";
	//技能替换
	public static string SkillReplace = "C_SkillReplace";
    //技能升级
    public static string SkillLevelUp = "C_SkillLevelUp";
	//珍兽技能改变
	public static string PetSkillChange = "C_PetSkillChange";
	//xp技能的显示与隐藏
	public static string SkillXpSkillShowAndHIde = "C_SkillXpSkillShowAndHIde";
    //切换技能心法
    public static string SkillXinFaChange = "C_SkillXinFaChange";
    /// <summary>
    /// 门派初始化
    /// </summary>
    public static string MenpaiInit = "C_MenpaiInit";

    public static string ReadyForLua = "C_ReadyForLua";

    public static string OnSplashImageHide = "C_OnGameManagerInit";

    //打开npc头像 p_param[0] == 2代表玩家 
    public static string ShowNpcHead = "C_ShowNpcHead";

    //组队相关

    //打开Message提示框
    //public static string ShowMessageBox = "C_ShowMessageBox";

    //打开装备Tips
    public static string ShowEquipTips = "C_ShowEquipTips";

    //打开坐骑Tips
    public static string ShowRideTips = "C_ShowRideTips";

    //打开道具Tips
    public static string ShowItemTips = "C_ShowItemTips";

    //打开宝石Tips
    public static string ShowGemTips = "C_ShowGemTips";

    public static string ShowGemLevelUp = "C_ShowGemLevelUp";
    // 使用物品结束
    public static string UseItemEnd = "C_UseItemEnd";

    public static string HideCurTip = "C_HideCurTip";

    //组队
    public static string UpdateTeamUI = "C_UpdateTeamUI";
    //队友信息变化 网络层通知数据层
    public static string TeamMemberInfoNet2VO = "C_TeamMemberInfoNet2VO";
    //队友信息变化 数据层通知界面
    public static string TeamMemberInfoVO2UI = "C_TeamMemberInfoVO2UI";
    // 组队跟随状态发生变化，数据层通知界面层
    public static string TeamFollowStateChange = "C_TeamFollowStateChange";
    // 队伍成员位置发生变化
    public static string TeamMemberPosChange = "C_TeamMemberPosChange";
    //关闭组队界面
    public static string TeamCloseMainUI = "C_TeamCloseMainUI";
    //入队申请信息变化 网络层通知数据层
    public static string ApplyRqstInfoNet2VO = "C_ApplyRqstInfoNet2VO";
    //入队申请信息变化 数据层通知界面
    public static string ApplyRqstInfoVO2UI = "C_ApplyRqstInfoVO2UI";
    //当队伍有人加入的时候通知（专门给红点逻辑用）
    public static string TeamMemberJoin = "C_TeamMemberJoin";
    public static string TeamMemberLeave = "C_TeamMemberLeave";//队员离队
    public static string TeamMemberUpdateHp = "C_TeamMemberUpdateHp";//单独血量更新
    public static string TeamMemberUpdateFormaitonInfo = "C_TeamMemberFormaitonInfo"; //队员阵法信息更改
    public static string TeamMemberUpdateFormaitonEye = "C_TeamMemberFormaitonEye"; //队伍阵眼信息更改

    public static string TeamPlatformLeave  = "C_TeamPlatformLeave"; //队员离开
    public static string TeamPlatformAppoint = "C_TeamPlatformAppoint"; //换队长
    public static string TeamPlatformCreate = "C_TeamPlatformCreate"; //建立队伍
    public static string TeamPlatformJoin = "C_TeamPlatformJoin"; //队员申请入队的加入队伍
    public static string TeamPlatformKick = "C_Team_Platform_Kick"; //被踢出队伍 
    public static string TeamPlatformLeaveMySelf = "C_TeamPlatformLeaveMySelf"; //我自己离开队伍  
    // 有无队伍状态变化
    public static string TeamHasOrNot = "C_TeamHasOrNot";
    // 当前队伍是否处于自动佣兵助战状态
    public static string TeamIsAutoYongbing = "C_TeamIsAutoYongbing";
    //佣兵
    public static string TeamListEventYongbing = "C_TeamListEventYongbing";
    //时装
    public static string FashionUpdateUI = "C_FashionUpdateUI";
    public static string BabyFashionUpdateUI = "C_BabyFashionUpdateUI";

    //3D UI加载完毕
    public static string Load3DUIFinish = "C_Load3DUIFinish";
    //好友
    //打开关闭好友二级菜单
    public static string ShowSecRelation = "C_ShowSecRelation";
    public static string ResponseRelationData = "C_ResponseRelationData";

    //好友操作
    
    public static string strangerToFriend = "C_strangerToFriend";
    public static string strangerToBlack = "C_strangerToBlack";
	public static string tempToFriend = "C_tempToFriend";
	public static string blackToFriend = "C_blackToFriend"; 
	public static string AddToBlackName = "C_AddToBlackName";
	public static string BlackToEnemy = "C_BlackToEnemy";
    public static string EnemyToBlack = "C_EnemyToBlack";
    public static string EnemyToFriend = "C_EnemyToFriend";
    public static string FriendToEnemy = "C_FriendToEnemy";
    public static string AddEnemyName = "C_AddEnemyName";
    public static string DelFromFriend = "C_DelFromFriend";
    public static string DelFromBlackName = "C_DelFromBlackName";
    public static string DelFromEnemyName = "C_DelFromEnemyName";
	public static string updateFriendList = "C_updateFriendList";
	public static string updateTempFriendList = "C_updateTempFriendList";
	public static string updateBlackNameList = "C_updateBlackNameList";
	public static string noSearchResult = "C_noSearchResult";
	public static string setFromLevelToDefault = "C_setFromLevelToDefault";
	public static string setToLevelToDefault = "C_setToLevelToDefault";
	public static string confirmFromAndToLevel = "C_confirmFromAndToLevel";
	public static string updateMood = "C_updateMood";
    public static string relationMessageBox = "C_relationMessageBox";

    public static string updateSingleFriend = "C_updateSingleFriend";
    public static string updateFinderList = "C_updateFinderList";
    public static string updateInquireUI = "C_updateInjuryUI";
    public static string updateRecenterUI = "C_updateRecenterUI";
    public static string updateRecenterSingle = "C_updateRecenterSingle";
    public static string addFriendByRelationUIChat = "C_addFriendByRelationUIChat";
    public static string updateFriendByRelationUIChat = "C_updateFriendByRelationUIChat";
    public static string updateAddFriendRecently = "C_updateAddFriendRecently";
    public static string updateCellBySecondUI = "C_updateCellBySecondUI";
    public static string updateCellByViewPlayer = "C_updateCellByViewPlayer";
    public static string chatAfterAddFriend = "C_chatAfterAddFriend";
    public static string updateBrotherInfo = "C_updateBrotherInfo";
    public static string updateLocalBlackNameData = "C_updateLocalBlackNameData";

    public static string friendAdd = "C_friendAdd";
    public static string friendDel = "C_friendDel";

    public static string addEnemyNotEnough = "C_addEnemyNotEnough";
	//主角数据初始化完毕
	public static string MainPlayerDataInitialized = "C_MainPlayerDataInitialized";

    public static string MainPlayerDetailDataUpdated = "C_MainPlayerDetailDataUpdated";

    //珍兽数据初始化完毕
    //public static string PetDataInitialized = "C_PetInitialized";

    //珍兽数据刷新
    public static string PetDataUpdate = "C_PetDataUpdate";
    public static string ChildrenDataUpdate = "C_ChildrenDataUpdate";
    //人物身上珍兽GUID情况
    public static string CharacterPetData = "C_CharacterPetData";
    public static string CharacterChildrenData = "C_CharacterChildrenData";
    //珍兽等级提升
    public static string PetLevelChange = "C_PetLevelChange";
    //
    public static string ChildrenLevelChange = "C_ChildrenLevelChange";
    //场景开始进入
    public static string StartChangeScene = "C_StartChangeScene";
	//场景进入完成
	public static string EnterSceneOK = "C_EnterSceneOK";
    //场景类型变更
    public static string SceneTypeChange = "C_SceneTypeChange";

    public static string ShowCreateRoleUI = "C_ShowCreateRoleUI";

    //寻路信息载入完成，可以开始寻路
    public static string NavigationLoadOk = "C_NavigationLoadOk";

    //服务器通知客户端显示UI修改 {0正常 1单人副本}
    public static string OnServerSceneUIChange = "C_OnServerSceneUIChange";

    //副本状态发生改变 <scriptId/stateId>
    public static string OnFubenState = "C_OnFubenState";

    //public static string ResetSceneAreaSound = "C_ResetSceneAreaSound";

	//主角经验改变
	public static string ExperienceChange = "C_ExperienceChange";
    public static string BattleChange = "C_BattleChange";
    public static string ExperienceFull = "C_ExperienceFull";

	//主角目标改变
	public static string MainPlayerTargetChange = "C_MainPlayerTargetChange";

	//主角等级改变
	public static string MainPlayerLevelChange = "C_MainPlayerLevelChange";
    public static string OtherPlayerLevelChange = "C_OtherPlayerLevelChange";
    public static string OtherPlayerWeaponOpenFlag = "C_OtherPlayerWeaponOpenFlag";
    //主角战斗力改变
    public static string MainPlayerBattleScoreChange = "C_MainPlayerBattleScoreChange";


    //主角时装ID改变
    public static string MainPlayerFashionIDChange = "C_MainPlayerFashionIDChange";
    //主角染色ID改变
    public static string MainPlayerColorIDChange = "C_MainPlayerColorIDChange";

    //主角称号点缀改变
    public static string MainPlayerSuperTitleFashionShoulderChange = "C_MainPlayerSuperTitleFashionShoulderChange";
    public static string MainPlayerSuperTitleFashionBeltChange = "C_MainPlayerSuperTitleFashionBeltChange";
    public static string MainPlayerSuperTitleFashionShoesChange = "C_MainPlayerSuperTitleFashionShoesChange";
    public static string MainPlayerSuperTitleFashionDisableChange = "C_MainPlayerSuperTitleFashionDisableChange";

    //主角时装ID和染色ID改变
    public static string MainPlayerFashionAndColorChange = "C_MainPlayerFashionIDAndColorIDChange";
    //主角神器阶级改变
    public static string MainPlayerWeaponRankChange = "C_MainPlayerWeaponRankChange";
    //武器幻化
    public static string GodWeaponLookChange = "C_GodWeaponLookChange";
    //同步服务器当前时间(玩家心跳里边, 每隔20s给你同步一次)
    public static string GodweaponOpenTimeSyn = "C_GodweaponOpenTimeSyn";
    //同步开始计时的时间( 玩家登陆场景时同步 )
    public static string GodweaponOpenTime = "C_GodweaponOpenTime";
    //返回开启神器的结果( <=-1 为错误码. 1:开启成功 )
    //-1: 由于IsCanLogic不能操作 -2: 已经开启过神器 -3: 任务没有完成 -4: 未开始倒计时 -5: 倒计时时间未到
    //public static string GodweaponOpenResult = "C_GodweaponOpenResult";
    //主角神器等级改变
    public static string MainPlayerWeaponLevelChange = "C_MainPlayerWeaponLevelChange";
	//main player health point change
	public static string MainPlayerHpPercentChange="C_MainPlayerHpPercentChange";
    //生命值上限发生改变
    public static string MainPlayerMaxHpChange = "C_MainPlayerMaxHpChange";
    //当主玩家受伤或治疗的当前百分比值
    public static string MainPlayerPushDamage = "C_MainPlayerPushDamage";
    //主角选中目标的生命值发生了改变
	public static string TargetNPC_HpChange="C_TargetNPC_HpChange";
    //目标的生命值上限发生了改变
    public static string TargetMaxHpChange = "C_TargetMaxHpChange";
    //主角选中目标的法力值发生了改变
    public static string Target_MpChange = "C_TargetMpChange";
	//main player magic point change
	public static string MainPlayerMpChange="C_MainPlayerMpChange";
    //披风护盾值发生变化
    public static string MainPlayerCloakShieldChange = "C_MainPlayerCloakShieldChange";
    public static string MainPlayerCloakShieldPercentChange = "C_MainPlayerCloakShieldPercentChange";
    //披风护盾值上限发生变化
    public static string MainPlayerMaxCloakShieldChange = "C_MainPlayerMaxCloakShieldChange";
    public static string MainPlayerCloakCDChange = "C_MainPlayerCloakCDChange";
    public static string MainPlayerCloakMaxCDChange = "C_MainPlayerCloakMaxCDChange";
    //目标披风护盾值发生变化
    public static string TargetCloakShieldChange = "C_TargetCloakShieldChange";
    public static string TargetCloakShieldPercentChange = "C_TargetCloakShieldPercentChange";
    //目标披风护盾值上限发生变化
    public static string TargetMaxCloakShieldChange = "C_TargetMaxCloakShieldChange";

    //main player rage change
    public static string MainPlayerRageChange="C_MainPlayerRageChange";
	//main player money change
	public static string MainPlayerMoneyChange = "C_MainPlayerMoneyChange";
	//main player yuan bao change
	public static string MainPlayerYuanBaoChange = "C_MainPlayerYuanBaoChange";
	//main player bind yuan bao change
	public static string MainPlayerBindYuanBaoChange = "C_MainPlayerBindYuanBaoChange";
	//main player jiao zi change
	public static string MainPlayerMoneyJZChange = "C_MainPlayerMoneyJZChange";
    // main player ying xiong ling change
    public static string MainPlayerHeroOrderChange = "C_MainPlayerHeroOrderChange";
    //许愿果数量变化
    public static string MainPlayerWishFruitChange = "C_MainPlayerWishFruitChange";
    //帮会通宝变换
    public static string MainPlayerGuildTongBaoChange = "C_MainPlayerGuildTongBaoChange";
    //玩家结义值改变 
    public static string MainPlayerSwearValueChange = "C_MainPlayerSwearValueChange";
    //玩家活跃度改变
    public static string MainPlayerActivePointChange = "C_MainPlayerActivePointChange";
    //杀怪数量
    public static string MainPlayerKillMonsterNumChange = "C_MainPlayerKillMonsterNumChange";
    //装备强化目标等级改变
    public static string EquipEnhanceTargetLevelChange = "C_EquipEnhanceTargetLevelChange";
    //玩家buff改变了
    public static string MainPlayerBuffChange = "C_MainPlayerBuffChange";
	//主角初始化完毕
	public static string MainPlayerInitialized = "C_MainPlayerInitialized";
    //主角开始自动战斗
    public static string MainPlayerStartAutoBattle = "C_MainPlayerStartAutoBattle";
    //主角停止自动战斗
    public static string MainPlayerStopAutoBattle = "C_MainPlayerStopAutoBattle";
    //主角自动战斗开启锁定BOSS
    public static string LockMonsterFlagInAutoBattle = "C_LockedMonsterFlagUpdate";
    //主角自动战斗开启锁定的BOSS数据
    public static string LockMonsterInfoInAutoBattle = "C_LockedMonsterDataUpdate";
    
	//主角销毁
	public static string MainPlayerRelease = "C_MainPlayerRelease";
    //主角停止移动 (只触发一次 而且肯定是真实有效的停止)
    public static string MainPlayerStopMove = "C_MainPlayerStopMove";
    //主角开始移动 (只在开始移动触发一次 {type:int, data:object} 0普通 1追踪 2其它)
    public static string MainPlayerStartMove = "C_MainPlayerStartMove";
    //一次完整的走路结束
    public static string MainPlayerMoveOver = "C_MainPlayerMoveOver";
    //主角 joymove开始
    public static string MainPlayerJoyMoveStart = "C_MainPlayerJoyMoveStart";
    //主角 joymove 结束(注意结束 是自身结束 )
    public static string MainPlayerJoyMoveEnd = "C_MainPlayerJoyMoveEnd";
    //主角请求移动走路
    public static string MainPlayerRequestMove = "C_MainPlayerRequestMove";
    //主角心法类型切换了
    public static string MainPlayerXinfaTypeChange = "C_MainPlayerXinfaTypeChange";
    //主角属性改变
    public static string MainPlayerAttrChange = "C_MainPlayerAttrChange";
	//主角门派发生改变
	public static string MainPlayeMenPaiChange = "C_MainPlayeMenPaiChange";
    //主角世界频道发言免费次数变更
    public static string MainPlayerWorlChatFreeTimes = "C_MainPlayerWorlChatFreeTimes";
    //主角天外频道发言免费次数变更
    public static string MainPlayerTianWaiChatFreeTimes = "C_MainPlayerTianWaiChatFreeTimes";

    //主角生日
    public static string MainPlayerBirthday = "C_MainPlayerBirthday";
    //各个功能服务器开关
    public static string ConfigFlagState = "C_ConfigFlagState";

    //怪物死亡
    public static string MonsterDie = "C_MonsterDie";
    //召唤兽死亡
    public static string SummonerDie = "C_MonsterDie";

    //怪物创建 动态/静态{serverId}
    public static string MonsterCreate = "C_MonsterCreate";


    //珍兽
    public static string PetDie = "C_PetDie";
    //子女
    public static string ChildrenDie = "C_ChildrenDie";
    //玩家死亡 目标表示其它玩家的死亡
    public static string PlayerDie = "C_PlayerDie";
    //选中目标
    public static string TargetSelect = "C_TargetSelect";
    //取消选定目标
    public static string TargetSelectCancel = "C_TargetSelectCancel";
    //目标死亡
    public static string TargetDie = "C_TargetDie";
    //目标buff改变
    public static string TargetBuffChange = "C_TargetBuffChange";
    //目标pushdamage血量百分比
    public static string TargetPushDamage = "C_TargetPushDamage";
    //任务列表有变动
    public static string MissionUpdate = "C_MissionUpdate";
    //任务移除/完成 {missionIndex, missionId}
    public static string MissionRemove = "C_MissionRemove";
    //任务增加
    public static string MissionAdd = "C_MissionAdd";
    //任务接受
    public static string MissionAccept = "C_MissionAccept";
    //任务进度修改
    public static string MissionModify = "C_MissionModify";
    //任务列表返回
    public static string MissionListBack = "C_MissionListBack";

    public static string MissionComplete = "C_MissionComplete";

    //普通采集完毕 (objId)
    public static string MissionCollectComplete = "C_MissionCollectComplete";

    //追踪到达特殊采集任务点
    public static string ArriveCollectPos = "C_ArriveCollectPos";

    //师门任务：好友互动
    public static string RespMissionFriendAskHelp = "C_RespMissionFriendAskHelp";
    public static string UpdateCurMissionId = "C_UpdateCurMissionId";
    public static string AskAcceptMission = "C_AskAcceptMission";
    public static string SceneryMissionType = "C_SceneryMissionType";
    public static string DeliveryMissionType = "C_DeliveryMissionType";
    //物品掉落
    public static string ItemBoxDrop = "C_ItemBoxDrop";
    public static string PickupTotalBtn = "C_ClickPickupTotalBtn";
    public static string PickupBtn = "C_ClickPickupBtn";
    public static string DropList = "C_DropList";
    public static string PickResult = "C_PickResult";
    public static string GenerateDropItem = "C_GenerateDropItem";
    public static string GenerateDropItemEffect = "C_GenerateDropItemEffect";
    public static string MoveDropItemToPlayerPostion = "C_MoveDropItemToPlayerPostion";

    //背包返回
    public static string AskBagList = "C_AskBagList";
    public static string NotifyEquip = "C_NotifyEquip";
    public static string ItemInfo = "C_ItemInfo";
    public static string BagSizeChange = "C_BagSizeChange";
    public static string ModelFinish = "C_ModelFinish";
    public static string AskEquipList = "C_AskEquipList";
    public static string OpenTag = "C_OpenTag";
    public static string BagRefresh = "C_BagRefresh";
    public static string BagEquipRefresh = "C_BagEquipRefresh";
    public static string BagSingleRefresh = "C_BagSingleRefresh";
    public static string UpdateBaglistToLua = "L_UpdateBaglistToLua";

    //福利
    public static string ShowGiftMainUI = "C_ShowGiftMainUI";
    public static string OpenGiftTag = "C_OpenGiftTag";
    public static string SignOrResignRefresh = "C_SignOrResignRefresh";
    public static string GetTimePrizeItemRefresh = "C_GetTimePrizeItemRefresh";
    public static string OnLineGiftQiFuResult = "C_OnLineGiftQiFuResult";
    public static string OnLineGetGiftResult = "C_OnLineGetGiftResult";
    public static string RefreshOnLineGift = "L_RefreshOnLineGift";
    public static string RefreshMonthlySign = "L_RefreshMonthlySign";

	//one key change equip
	public static string ShowEquipPrompt = "C_ShowEquipPrompt";
	public static string CloseEquipPrompt = "C_CloseEquipPrompt";

    public static string ShowQuickTips = "C_ShowQuickTips";
    public static string FreshQuickTips = "C_FreshQuickTips";
    public static string CloseQuickTipst = "C_CloseQuickTipst";
    public static string IsQuickTipsOpen = "C_IsQuickTipsOpen";
    public static string RemoveQuickTips = "C_RemoveQuickTips";


	//other player data initialized
	//public static string otherPlayerDataInitialized = "C_otherPlayerDataInitialized";

	//monster data initialized
	//public static string monsterDataInitialized = "C_monsterDataInitialized";

    public static string ShowPlayerAttr = "C_ShowPlayerAttr";

	//other player list change
	public static string otherPlayerListChange = "C_otherPlayerListChange";

	//On Finder Path Complete
	public static string OnFinderPathComplete = "C_OnFinderPathComplete";
    //子女
    public static string LearnChildrenSkill = "C_LearnChildrenSkill";
    public static string TrainChildren = "C_TrainChildren";
    public static string UpdateChildrenUI = "C_UpdateChildrenUI";
    public static string ChangeNameChildren = "C_ChangeNameChildren";
    public static string UpdateChildrenBattleState = "C_UpdateChildrenBattleState";
    public static string UpdateChildrenCount = "C_UpdateChildrenCount";
    public static string OperatorResult             = "C_OperatorResult";
	
	//子女性格
    public static string UpdateChildrenCharacterId = "C_UpdateChildrenCharacterId";
    public static string UpdateChildrenCharacterFreedomPoint = "C_UpdateChildrenCharacterFreedomPoint";
    public static string UpdateChildrenCharacterData = "C_UpdateChildrenCharacterData";
	//子女时装
    public static string UpdateChildrenFashionModel = "C_UpdateChildrenFashionModel";
    //子女动作
    public static string UpdateChildrenChatMood = "C_UpdateChildrenChatMood";
    //珍兽
    public static string OnPetExpChange = "C_OnPetExpChange";
    public static string CallUpPet = "C_CallUpPet";
    public static string FreePet = "C_FreePet";
    public static string GetPetAttribute = "C_GetPetAttribute";
    public static string LearnPetSkill = "C_LearnPetSkill";
    public static string ReproducePet = "C_ReproducePet";
    public static string ChangeNamePet = "C_ChangeNamePet";
    public static string TrainPet = "C_TrainPet";
    public static string XiSuiPet = "C_XiSuiPet";
    public static string ManipulateReturn = "C_ManipulateReturn";
    public static string GeniusGotoBattle = "C_GeniusGotoBattle";
    public static string PossessionPet = "C_PossessionPet";
    public static string CatchPet = "C_CatchPet";
	public static string FutiPet = "C_FutiPet";
	public static string RomovePet = "C_RomovePet";
	public static string NewPetData = "C_NewPetData";
    public static string RemoveChildren = "C_RemoveChildren";
	public static string LearnPetSkillIsNull = "C_LearnPetSkillIsNull";
    public static string PetReproduceFinish = "C_PetReproduceFinish";
    public static string PetReproduceTake = "C_PetReproduceTake";
    public static string AllShouHunRequest = "C_AllShouHunRequest";
    public static string AddShouHun = "C_AddShouHun";
    public static string HideSkillTip = "C_HideSkillTip";
    public static string UpdatePetUI = "C_UpdatePetUI";
    public static string NewMonster = "C_NewMonster";
    public static string DelMonster = "C_DelMonster";
    public static string UpdateRedPoint = "C_UpdateRedPoint";
	public static string mainPlayerModelLoadFinished = "C_mainPlayerModelLoadFinished";
	public static string CallUpGodPet = "C_CallUpGodPet";  //召唤神兽
    public static string GodPetJueXing = "C_GodPetJueXing";  //神兽觉醒
    public static string OpenBreedUI = "C_OpenBreedUI";
    public static string OpenTeamBreedUI = "C_OpenTeamBreedUI";
    public static string OpenTakenBreedUI = "C_OpenTakenBreedUI";
    public static string SyncBreedTime = "C_SyncBreedTime";
    public static string SyncBreedData = "C_SyncBreedData";
    public static string SyncTeamBreedStar = "C_SyncTeamBreedStar";
    public static string SyncBreedStar = "C_SyncBreedStar";
    public static string SyncBreedSnapShot = "C_SyncBreedSnapShot";
    public static string SyncBreedResult = "C_SyncBreedResult";
    public static string SyncSingleBreedResult = "C_SyncSingleBreedResult";
    public static string PetPossBuffInfo = "C_PetPossBuffInfo";

    //close world map and district map when start crossing scene transport.
    public static string closeWorldAndDistrictMap = "C_closeWorldAndDistrictMap";
    public static string PetPreview = "C_PetPreview";
    //播放影片
    public static string PlayMovie = "C_PlayMovie";
    //影片开始
    public static string MovieStart = "C_MovieStart";
    //影片一段结束
    public static string MovieStateComplete = "C_MovieStateComplete";
    //影片结束
    public static string MovieComplete = "C_MovieComplete";
    //影片动作摄像机启动
    public static string MovieCameraEnable = "C_MovieCameraEnable";
	//开始播放轻功动画
	public static string JumpFlyActionStart = "C_JumpFlyActionStart";
	//停止轻功动画
	public static string JumpFlyActionStop = "C_JumpFlyActionStop";

    //character动作结束 character
    public static string CharacterActionEnd = "C_CharacterActionEnd";
    public static string MainPlayerOnRideActionEnd = "C_MainPlayerOnRideActionEnd";
    //切换心法
    public static string CharacterSwitchSkill = "C_CharacterSwitchSkill";
    //人物一键升级技能
    public static string CharacterOnKeyClickSkill = "C_CharacterOnKeyClickSkill";
    //换场景关闭掉落界面
    public static string CloseDropItem = "C_CloseDropItem";

    //QTE 成功
    public static string QTESuccess = "C_QTESuccess";
    //QTE 失败
    public static string QTEFail = "C_QTEFail";

	//obstruct transparent state change
	public static string obstructTransparentStateChange = "C_obstructTransparentStateChange";

    //帮会
    public static string GuildAskListResult = "C_GuildAskListResult"; //帮会列表请求返回
    public static string GuildCreateOK = "C_GuildCreateOK"; //帮派申请列表返回

    public static string GuildAskMemberListResult = "C_GuildAskMemberListResult"; //帮会成员列表请求返回

    public static string GuildInitBaseInfo          = "C_GuildInitBaseInfo"; //帮派基础信息初始信息
    public static string GuildUpdateLobbyGuildInfo  = "C_GuildUpdateLobbyGuildInfo"; //帮会大厅中刷新帮会信息
    public static string GuildUpdateSelfGuildInfo   = "C_GuildUpdateSelfGuildInfo"; //更新自己帮派信息
    public static string GuildUpdateMembersInfo     = "C_GuildUpdateMembersInfo"; //刷新客户端数据
    public static string GuildUpdateDetails         = "C_GuildUpdateDetails"; //帮派详细信息
    public static string GuildUpdateEventList       = "C_GuildUpdateEventList"; //帮会事件列表请求返回

    public static string GuildError = "C_GuildError";
    public static string GuildCreateError = "C_GuildCreateError"; //帮派申请列表返回
    public static string GuildJoinError = "C_GuildJoinError";
    public static string GuildManagerError = "C_GuildManagerError";

    public static string GuildChangeDesc = "C_GuildChangeDesc";
    public static string GuildLevelWord = "C_GuildLevelWord";

    public static string GuildBuildSuccess = "C_GuildBuildSuccess"; //帮会建筑升级醒目提示

    public static string GuildDirectJoinSuccess = "C_GuildDirectJoinSuccess"; //学徒加入返回成功后处理

    public static string GuildAppointReturn = "C_GuildAppointReturn"; //帮会任命返回
    public static string GuildTangAppointReturn = "C_GuildTangAppointReturn"; //帮会任命返回
    public static string GuildProtectLockReturn = "C_GuildProtectLockReturn"; //帮会管理辅助（新人保护锁定）
    public static string GuildDemissReturn = "C_GuildDemissReturn"; //帮会禅让返回

    public static string GuildApplyChieftainReturn = "C_GuildApplyChieftainReturn"; //帮主申请返回

    public static string ReturnXiulianList = "C_ReturnXiulianList"; //帮会修炼list返回

    public static string GuildArmyCapital = "C_GuildArmyCapital"; //帮会捐献军资

    //坐骑
    public static string ReqServerRideUpDown = "C_ReqServerRideUpDown";//请求服务器上下马
    public static string UpdateRideCurIndex = "C_UpdateRideCurIndex"; //刷新当前坐骑的Index
    ////public static string ReqActiveRideItem = "C_ReqActiveRideItem";//请求激活坐骑Item
    //public static string ReqCallRide = "C_ReqCallRide";//请求召唤坐骑
    public static string ShowBaseRideBtn = "C_ShowBaseRideBtn";//打开坐骑在BaseUI里面的按钮
    //public static string AutoUpRideRequest = "C_AutoUpRideRequest";//距离足够远的时候自动发送上马请求

    public static string MainPlayer_UpRide = "C_MainPlayer_UpRide";
    public static string MainPlayer_DownRide = "C_MainPlayer_DownRide";
    public static string MainPlayerPassenageMultiRide_Down = "C_MainPlayerPassenageMultiRide_Down";

    //服务器要求显示messageBox [id, param1, param2.....]
    public static string OnServerShowMessageBox = "C_OnServerShowMessageBox";
    //服务器要求显示messageBox [id, param1, param2.....](帮会运镖用)
    public static string OnServerShowMessageBoxUsedDart = "C_OnServerShowMessageBoxUsedDart";

    //副本大厅
    public static string ShowMultiPlayerBtn = "C_ShowMultiPlayerBtn";
    public static string showMultiPlayerHall = "C_showMultiPlayerHall";
    public static string askCopySceneCount = "C_askCopySceneCount";
    public static string CopyFindNPC = "C_CopyFindNPC";
    
    //活动大厅
    public static string ReqGetActivityList = "C_ReqGetActivityList";

    public static string OnActivityListBack = "C_OnActivityListBack";

	public static string updateNamePad = "C_updateNamePad";
    public static string updateDropNamePad = "C_updateDropNamePad";
    //请求领取奖励
    public static string ReqGetActivityReward = "C_ReqGetActivityReward";

    //activity md值修改 {md, 领取的index}
    public static string OnActivityMDChange = "C_OnActivityMDChange";

    //public static string ChangeScene = "C_ChangeScene";

    //虚拟键盘完全弹出
    public static string KeyBoardShowComplete = "C_KeyBoardShowComplete";
    //战斗力有变化
    public static string BattleScoreChange = "C_BattleScoreChange";

    //清除界面战力提升特效残留
    public static string ClearScoreEffect = "C_ClearScoreEffect";
    /// <summary>
    /// 快捷功能项初始化
    /// </summary>
    public static string ShortuctMenuInit = "C_ShortuctMenuInit";

    //收到服务器返回的装备位的数据更新
    public static string UpdateEquipSlotData = "C_UpdateEquipSlotData";
    // 更新镶嵌信息
    public static string UpdateEquipSlotInlay = "C_UpdateEquipSlotInlay";
    // 镶嵌
    public static string InlayGem = "C_InlayGem";
    // 卸下
    public static string RemoveGem = "C_RemoveGem";
    // 提升
    public static string UpgradeGem = "C_UpgradeGem";
    // 合成
    public static string ComposeGem = "C_ComposeGem";

    //聊天
    public static string ShowChatMessage = "C_ShowChatMessage";//显示聊天信息
    public static string ShowHornMessage = "C_ShowHornMessage";//显示小喇叭信息
    public static string ChatFindPath = "C_ChatFindPath";//聊天链接自动寻路
    public static string ChatShowTips = "C_ChatShowTips";//显示tips
    public static string SetCityLocation0 = "C_SetCityLocation0";//记录当前城市名
    public static string SetCityLocation = "C_SetCityLocation";//记录当前城市名
    public static string UpdateVoiceChatContent = "C_UpdateVoiceChatContent";//更新语音聊天后的内容
    public static string UpdateVoiceBtnState = "C_UpdateVoiceBtnState";//语音播放时，改变语音播放按钮状态
    public static string UpdateVoiceBtnStateAsync = "C_UpdateVoiceBtnStateAsync";//语音播放时，改变语音播放按钮状态,异步发送
    public static string UpdateVoiceBtnStateWithGuid = "C_UpdateVoiceBtnStateWithGuid";//语音播放时，改变语音播放按钮状态,唯一guid
    //public static string AnalyzeChatConent = "C_AnalyzeChatConent";//解析聊天内容
    public static string ChatExtraData = "C_ChatExtraData";//聊天额外数据
    public static string SendChatMessage = "C_SendChatMessage";//聊天发送数据
    public static string SendVoiceChatFileID = "C_SendVoiceChatFileID";//将获取的fileID发给lua
    public static string UpdateChatContent = "C_UpdateChatContent";// 更新聊天内容
    public static string LiveInfoReturn = "C_LiveInfoReturn";//主播信息列表返回(仅列表)
    public static string UpdateLiveUI = "C_UpdateLiveUI";//刷新主播界面UI
    public static string JoinRoomSuc = "C_JoinRoomSuc";// 加入主播房间成功
    public static string LiveListReturn = "C_LiveListReturn";// 主播列表返回(所有信息包括图片)
    public static string RequestInfoReturn = "C_RequestInfoReturn";// 请求加入主播房间过程的错误码返回
    public static string OpenSpeakerErrorReturn = "C_OpenSpeakerErrorReturn";// 请求打开openspeak的错误码返回
    public static string JoinRoomOverTime = "C_JoinRoomOverTime";// 加入主播房间超时
    public static string QuitRoomReturn = "C_QuitRoomReturn";// 退出主播房间
    public static string BeginVoiceBtnStateAsync = "C_BeginVoiceBtnStateAsync";// 开始语音播放
    public static string BeginVoiceRecord = "C_BeginVoiceRecord";// 开始录制语音
    public static string StopVoiceRecord = "C_StopVoiceRecord";// 结束录制语音
    public static string GVoicePluginJoinRoomSuc = "C_GVoicePluginJoinRoomSuc";// GVoice并使用插件情况下家房间成功
    public static string GVoicePluginQuitRoomSuc = "C_GVoicePluginQuitRoomSuc";// GVoice并使用插件情况下退房间成功
    public static string SaveAtMeMessage = "C_SaveAtMeMessage";//保存@消息
    //生活技能
    public static string RefreshLifeSkillUI = "C_RefreshLifeSkillUI"; //刷新界面
    public static string LifeSkillRefreshMatNum = "C_LifeSkillRefreshMatNum"; //刷新材料ICON上的数量

    //装备熔炼

    public static string UpdateEquipFurnaceVal = "C_UpdateEquipFurnaceVal";//刷新装备熔炼值

    //登录
    public static string LoginCamMovieShow = "C_LoginCamMovieShow";//登录和选服的摄像机动画
    public static string LoginEndCamShow = "C_LoginEndCamShow";//登录和选服的摄像机动画结束后Cam
    public static string SelectRoleCamMovieShow = "C_SelectRoleCamMovieShow";//选服后到选角前~播放动画
    public static string SelectRoleEndCamShow = "C_SelectRoleEndCamShow";//选服后到选角前~播放动画完成后Cam
    public static string LoginDelMainBG = "C_LoginDelMainBG";//需要删除登录场景的背景图片
    public static string CreateRoleCamMovieEnd = "C_CreateRoleCamMovieEnd";//创建角色的摄像机动画播放完毕
    public static string SelectRoleUIShow = "C_SelectRoleUIShow";//初始化显示选角UI
    public static string CreateRoleMovie = "C_CreateRoleMovie"; //播放创建角色的时候动画
    public static string MSDKAutoLogin = "C_MSDKAutoLogin";//初始化成功后自动登录
    public static string MSDK_WakeUpNeedLogin = "C_MSDK_WakeUpNeedLogin";
    public static string ShowServerPageUI = "C_ShowServerPageUI";
    public static string OnServerPageUIShow = "C_OnServerPageUIShow";
    public static string MSDK_Account_OpenId = "C_MSDK_Account_OpenId";
    public static string MSDK_Account_Logout = "C_MSDK_Account_Logout";
    public static string ShowServerPageForMSDK = "C_ShowServerPageForMSDK";//MSDK登录成功发送
    public static string IPhoneGenerationIdentify = "C_IPhoneGenerationIdentify";//iPhone机型判断，用来提示信息
    public static string AnimationWrapMode = "C_AnimationWrapMode"; // 播放动画的方式 
    public static string LoginCamTianShanRuChangEnd = "C_LoginCamTianShanRuChangEnd"; // 天山入场动画结束 
    public static string LoginCamEMeiRuChangEnd = "C_LoginCamEMeiRuChangEnd"; // 峨眉入场动画结束 
    public static string LoginCamGaiBangRuChangEnd = "C_LoginCamGaiBangRuChangEnd"; // 丐帮入场动画结束 
    public static string LoginCamXiaoYaoRuChangEnd = "C_LoginCamXiaoYaoRuChangEnd"; // 逍遥入场动画结束 
    public static string ShowAccountVideo = "C_ShowAccountVideo"; // 播放创建角色的动画  
    public static string HideAccountVideo = "C_HideAccountVideo"; // 停止创建角色的动画   
    public static string ChangeMenPaiAmbientLight = "C_ChangeMenPaiAmbientLight"; // 登陆场景更改环境光   
    public static string SetLoginShadow = "C_SetLoginShadow"; // 登陆场景角色阴影   
    public static string SetLoginSelectRoleShadow = "C_SetLoginSelectRoleShadow"; //  登陆场景选择角色阴影 
    public static string OnShowRadialBlur = "C_OnShowRadialBlur"; //  径向模糊特效
    public static string OnSetLoginSceneEffect = "C_OnSetLoginSceneEffect"; //  控制特效
    public static string OnSetLoginSceneCamera = "C_OnSetLoginSceneCamera"; //  控制摄像机景深
    public static string OnLoginSceneCancelDelay = "OnLoginSceneCancelDelay"; //  取消特效延迟
    public static string OnShowRainEffect = "C_OnShowRainEffect"; //  雨滴屏特效
    public static string ChangeSceneModel = "C_ChangeSceneModel"; //  切换场景模型

    //登录协议
    public static string StartLoginProcedure = "C_StartLoginProcedure"; //开启登录流程~
    public static string EnterLoginSceneOK = "C_EnterLoginSceneOK";//加载登录场景OK
    public static string InitCreateRoleUI = "C_InitCreateRoleUI"; //初始化创建角色UI：用于随机角色~然后播角色动画
    public static string StartCreateRoleProduce = "C_StartCreateRoleProduce"; //开启创建角色流程
    public static string CharLoginServer = "C_CharLoginServer"; //选好角色后进入服务器
    public static string ReadyToShowSelectRoleUI = "C_ReadyToShowSelectRoleUI";//这里开启SelectUserProduce的Tick开关
    public static string ClearReLoginState = "C_ClearReLoginState";//用于清除LoginServer断线重连的状态~
    public static string Change2LoginProduce = "C_Change2LoginProduce";//用于在选角创角UI点击返回按钮后~produce也跟着返回
    public static string SavePlayerSelectRoleIdx = "C_SavePlayerSelectRoleIdx";//记录一下玩家选择的角色在角色列表的下标
    public static string ShowLoginAccountUI = "C_ShowLoginAccountUI";//打开账号登录UI

    public static string StartEnterGameServer = "C_StartEnterGameServer"; // 热更新检查完通知进入游戏服务器

    //平台好友
    public static string TXRelationNotify = "C_TXRelationNotify";
    public static string GetTXPlatfromInfo= "C_GetTXPlatfromInfo";

    public static string PlatformFriendServerInvite = "C_PlatformFriendServerInvite";
    public static string PlatformFriendInvite = "C_PlatformFriendInvite";
    public static string PlatformFriendShare = "C_PlatformFriendShare";
    public static string PostFriendsData2Server = "C_PostFriendsData2Server";

    //更新其他玩家装备
    public static string OtherPlayerDataUpdate = "C_OtherPlayerDataUpdate";
    public static string OtherPlayerUpdateEquip = "C_OtherPlayerUpdateEquip";
    public static string OtherPlayerUpdatePet = "C_OtherPlayerUpdatePet";
    // 角色心情 
    public static string PlayerLuckWord = "C_PlayerLuckWord";
    public static string RequestCPrivateInfo = "C_RequestCPrivateInfo";
    public static string AskGuildWarlist = "C_AskGuildWarlist";

    // 邮件相关 
    public static string MailNewInfo = "C_MailNewInfo"; // 邮件详细信息 
    public static string LinkOnClick_LinkStr = "C_LinkOnClick_LinkStr"; // 点击邮件中的链接事件处理   

    //副本相关
    public static string SingleFubenPlayerEnter = "C_SingleFubenPlayerEnter"; //单人副本玩家进入 涉及切换副本音乐

    //英雄试练界面
    public static string SetHeroTrialsData = "C_SetHeroTrialsData";
    //public static string Receive_SweepsResult = "C_Receive_SweepsResult";
    //public static string Receive_ResetCountResult = "C_Receive_ResetCountResult";
    //public static string Receive_ChallengeResult = "C_Receive_ChallengeResult";
    //public static string Receive_BoxResult = "C_Receive_BoxResult";
    //科举
    public static string Show_ExamMainPanel = "C_Show_ExamMainPanel";

    //城市建筑刷新
    public static string RefreshCityBuildingInfo = "C_RefreshCityBuildingInfo";
    //创建rendertexture返回
    public static string Return_RenderTex = "C_Return_RenderTex";
    public static string Return_RenderTex_ContestField = "C_Return_RenderTex_ContestField";

    public static string WGCResult = "C_WGCResult";
    public static string GCGuildReturnType = "C_GCGuildReturnType";

    public static string WGCGuildBattleListAttr = "C_WGCGuildBattleListAttr";//帮会队伍列表
    // 更新其他玩家镶嵌信息
    public static string UpdateOtherPlayerInlayInfo = "C_UpdateOtherPlayerInlayInfo";

    //MSDK 相关
    //登录相关
    public static string MSDK_Login = "C_MSDK_Login";//使用MSDK登录
    public static string MSDK_OpenURL = "C_MSDK_OpenURL";
    public static string MSDK_OpenURL_ForPR2 = "C_MSDK_OpenURL_ForPR2";
    public static string MSDK_OpenURL_ForPandora = "C_MSDK_OpenURL_ForPandora";
    public static string MSDK_OpenURL_PORTRAIT = "C_MSDKOpenURL_PORTRAIT";

    public static string MSDK_OpenURL_ForQQVip = "C_MSDK_OpenURL_ForQQVip";
    public static string GSDK_Start = "C_GSDK_Start";//启动GSDK
    public static string GSDK_End = "C_GSDK_End";//关闭GSDK
    //public static string GSDK_GoFront = "C_GSDK_GoFront";
    //public static string GSDK_GoBack = "C_GSDK_GoBack";
    //public static string GSDK_Init = "C_GSDK_Init";
    public static string MSDK_DifferentAccount = "C_MSDK_DifferentAccount";
    public static string MSDK_DiffAccount_WX_LoginServer = "C_MSDK_DiffAccount_WX_LoginServer";
    public static string MSDK_RealName_Auth = "C_MSDK_RealName_Auth";
    public static string KickLoginCurRoleName = "C_KickLoginCurRoleName";

    public static string TXQQVipChange = "C_TXQQVipChange";
	public static string TXQQVipChange_OtherPlayer = "C_TXQQVipChange_OtherPlayer";

    public static string MSDK_GetIPInfo = "C_MSDK_GetIPInfo";//获得IP所属地信息

    //坐骑相关
    //public static string UpdateCurRideIndex = "C_UpdateCurRideIndex";//刷新当前使用的坐骑在坐骑背包中的Index（从1开始~CS中已加1）
    public static string UpdateAllRideData = "C_UpdateAllRideData";//刷新所有坐骑数据


    //返回日志
    public static string MSDK_Login_Succ = "C_MSDK_Login_Succ";
    public static string MSDK_Login_Fail = "C_MSDK_Login_Fail";//登录失败
    public static string MSDK_AutoLogin_Fail = "C_MSDK_AutoLogin_Fail";//自动登录失败
    public static string GET_Telephony = "C_GET_Telephony";
    public static string BatteryChange_Android = "C_BatteryChange_Android";//Android 电池电量改变
    public static string BatteryChange = "C_BatteryChange";//通知lua
    public static string GetBatteryLevel_IOS = "C_GetBatteryLevel_IOS";//IOS 获取电量
    public static string AndroidOnKeyDown = "C_AndroidOnKeyDown";//安卓获取点击
    public static string UserUpMessage = "C_UserUpMessage";//用户反馈接口
    public static string UserUpMessageBack = "C_UserUpMessageBack";//用户反馈接口回调
    public static string IOS_InitAPNS = "C_IOS_InitAPNS";//IOS 初始化信鸽
    public static string MSDK_RemLoadingSafe = "MSDK_RemLoadingSafe";

    public static string AD_AttirbutionDetialCallBack2Lua = "C_AD_AttirbutionDetialCallBack2Lua";

    public static string Native_GetSimulatorVTEnable = "Native_GetSimulatorVTEnable";

    //支付相关
    public static string MidasPay_Goods4Pandora_iOS = "C_MidasPay_Goods4Pandora_iOS";
    public static string MidasPay_Goods4Pandora_Android = "C_MidasPay_Goods4Pandora_Android";

    public static string MidasPay_Goods_iOS = "C_MidasPay_Goods_iOS";
    public static string MidasPay_Goods_Android = "C_MidasPay_Goods_Android";

    public static string MidasPay_NeedLogin = "C_MidasPay_NeedLogin";//支付Err：登录授权无效
    public static string MidasPay_CallBack = "C_MidasPay_CallBack";//支付回调：失败成功都在这个里面
    public static string MidasNet_CallBack = "C_MidasNet_CallBack";//获取营销活动信息回调
    public static string MidasPay_Init = "C_MidasPay_Init";//支付初始化
    public static string MidasPay_LaunchPay = "C_MidasPay_LaunchPay";//拉起支付
    public static string Midas_Request_Balance = "C_Midas_Request_Balance";
    public static string MidasPayCallBack2Lua = "C_MidasPayCallBack2Lua";
    public static string MidasPay_LaunchPay4Card = "C_MidasPay_LaunchPay4Card";
    public static string MidasPay_Init_Login = "C_MidasPay_Init_Login";//支付初始化 登陆界面充值
    public static string Midas_Request_Balance_Login = "C_Midas_Request_Balance_Login";

    public static string MSDK_Webview = "C_MSDK_Webview"; //内置网页


    public static string Pay_PayCallBack4Game = "C_Pay_PayCallBack4Game";
    public static string Pay_PaySuccess4Game = "C_Pay_PaySuccess4Game";
    public static string Pay_PayFail4Game = "C_Pay_PayFail4Game";

    public static string MSDK_UpdatePlayerLoginRet = "C_MSDK_UpdatePlayerLoginRet";//获取当前票据


    public static string MidasPay_TokenError = "C_MidasPay_TokenError";//微信票据过期
    public static string MSDK_RefreshWXToken = "C_MSDK_RefreshWXToken";//刷新微信票据
    public static string MSDK_RefreshWXToken_Result = "C_MSDK_RefreshWXToken_Result";//刷新微信票据成功
    public static string MidasPay_Error_StopAllPay = "C_MidasPay_Error_StopAllPay";

    public static string MidasPay_Error_TokenOverdue = "C_MidasPay_Error_TokenOverdue";

    public static string MidasIAP_OrderSuccess = "C_MidasIAP_OrderSuccess";//下单成功
    public static string MidasIAP_PaySuccess = "C_MidasIAP_PaySuccess";//苹果支付成功
    public static string MidasIAP_SendProductSuccess = "C_MidasIAP_SendProductSuccess";//发货成功

    public static string MidasIAP_ParamError = "C_MidasIAP_ParamError";//参数错误
    public static string MidasIAP_OrderFail = "C_MidasIAP_OrderFail";//下单失败
    public static string MidasIAP_PayFail = "C_MidasIAP_PayFail";//苹果支付失败
    public static string MidasIAP_SendProductFail = "C_MidasIAP_SendProductFail";//发货失败
    public static string MidasIAP_GetRestoreInfoFail = "C_MidasIAP_GetRestoreInfoFail";//读取补发商品信息失败
    public static string MidasIAP_NetWorkError = "C_MidasIAP_NetWorkError";//网络问题导致支付失败

    public static string MSDK_Share_QQPhoto = "C_MSDK_Share_QQPhoto";
    public static string MSDK_Share_WXPhoto = "C_MSDK_Share_WXPhoto";

    public static string MSDK_Share_QQStruct = "C_MSDK_Share_QQStruct";
    public static string MSDK_Share_WXStruct = "C_MSDK_Share_WXStruct";

    public static string MSDK_Share_WXHyperlink = "C_MSDK_Share_WXHyperlink";
    public static string MSDK_Share_ServerShare_WX = "C_MSDK_Share_ServerShare_WX";
    public static string MSDK_Share_ServerShare_QQ = "C_MSDK_Share_ServerShare_QQ";
    public static string MSDK_Share_WX_MiniApp = "C_MSDK_Share_WX_MiniApp";
    public static string MSDK_Share_WX_HaoWan = "C_MSDK_Share_WX_HaoWan";

    public static string Report4Log = "C_Report4Log";
    public static string UpdateLocalMessage = "C_UpdateLocalMessage";

    public static string ShowPlayerLevelUp = "C_ShowPlayerLevelUp";//播放玩家升级UI特效
    public static string MissionHaveDone = "C_MissionHaveDone";//任务完成

    public static string RelationChanged = "C_RelationChanged"; // 与主角的关系发生变化
    public static string ObjectVisibleChange = "C_ObjectBecomeVisible"; // 可见性发生变化
    public static string OtherPlayerVisibleChange = "C_OtherPlayerVisibleChange"; // 可见性发生变化
    //新手引导
    public static string TrigerCloseGuideEvent = "C_TrigerCloseGuideEvent"; //外部触发关闭指定的新手指引 

    //发型和发色改变
    public static string MainPlayerHairModelChange = "C_MainPlayerHairModelChange"; //发型改变
    public static string MainPlayerHairColorChange = "C_MainPlayerHairColorChange"; //发色改变	
    public static string MainPlayerChildrenHairChange = "C_MainPlayerChildrenHairChange"; //发型改变
    //public static string MainPlayerChildrenHairColorChange = "C_MainPlayerChildrenHairColorChange"; //发色改变	
    public static string MainPlayerFaceChange = "C_MainPlayerFaceChange"; //脸型改变	
    public static string PKModeChanged = "C_PKModeChanged"; //PK模式变更
    public static string PERSONAL_ENEMY_ADDED = "C_PERSONAL_ENEMY_ADDED";//有宣战玩家进入
    //帮会宴请
    public static string GuildFeteCardItemInfo = "C_GuildFeteCardItemInfo";//宴请酬情牌详细信息获取了
    public static string GetItemInfo = "C_GetItemInfo";//请求物品详细信息
    //暗器
    public static string TESTHIDDENInfo = "C_TESTHIDDENInfo";//测试暗器信息

    //四绝庄
    public static string SetSiJueZhuangUI = "C_SetSiJueZhuangUI"; //打开或关闭四绝庄

    //系统设置返回
    public static string SendSystemData = "C_SendSystemData";
    // 创建对象和删除后，进行通知
    public static string NotifyCreatedObj = "C_NotifyCreatedObj";
    public static string NotifyDeletedObj = "C_NotifyDeletedObj";

    //突破
    public static string BreakoutLevel = "C_BreakoutLevel";

    //复活界面添加仇人返回
    public static string ReliveAddEnemy = "C_ReliveAddEnemy";

    //分享回调
    public static string ShareCallBack = "C_ShareCallBack";

    // 兑换货币成功
    public static string ExchangMoneySuc = "C_ExchangMoneySuc";

    // 系统设置
    public static string GameSettingInfo = "C_GameSettingInfo";

    //触发自动挂机
    public static string TriggerAutoBattle = "C_TriggerAutoBattle";

    //帮会程序基础信息更新
    public static string UpdateGuildCityBaseAttr = "C_UpdateGuildCityBaseAttr";

    //查询寻路失败或成功
    public static string FindPathResult = "C_FindPathResult";

    public static string OpenVMPSDK = "C_OpenVMPSDK";
    public static string InitVMPSDK = "C_InitVMPSDK";
    public static string SetReportVMPSDK = "C_SetReportVMPSDK";

    //System.cfg加载完毕
    public static string SystemCFGLoadFinish = "C_SystemCFGLoadFinish";
    public static string PreInitCFGLoadFinish = "C_PreInitCFGLoadFinish";

    public static string InitSaveBattery = "C_InitSaveBattery";

    public static string TXVIP_Type = "C_TXVIP_Type";
    public static string TXVIP_ChangeType = "C_TXVIP_ChangeType";
    public static string GUITXVIPInfo = "C_GUITXVIPInfo";
    public static string UpdatePlatformInfo4LoginPrivilege = "C_UpdatePlatformInfo4LoginPrivilege";

    public static string TXPlatfromAddQQFriend = "C_TXPlatfromAddQQFriend";
    //public static string TXOpenWXCenter = "C_TXOpenWXCenter";
    public static string DayNightRefreshTXPlatform = "C_DayNightRefreshTXPlatform";

    //帮会绑群
    public static string QueryGroup = "C_QueryGroup"; //查询群信息
    public static string CreateGroup = "C_CreateGroup"; //创建群
    public static string DismissGroup = "C_DismissGroup"; //解除群
    public static string JoinGroup = "C_JoinGroup"; //加入群
    public static string SendMessageToGroup = "C_SendMessageToGroup"; //发送群消息

    public static string QueryGroupReturn = "C_QueryGroupReturn"; //查询群信息回调
    public static string CreateGroupReturn = "C_CreateGroupReturn"; //创建群回调
    public static string DismissGroupReturn = "C_DismissGroupReturn"; //解除群回调
    public static string JoinGroupReturn = "C_JoinGroupReturn"; //加入微信群回调
    public static string SendMessageToGroupReturn = "C_SendMessageToGroupReturn"; //发送群消息回调


    public static string ShowSystemDialog = "C_ShowSystemDialog";
    public static string OnClickSystemDialogOkBtn = "C_OnClickSystemDialogOkBtn";
    public static string OnClickSystemDialogCancelBtn = "C_OnClickSystemDialogCancelBtn";
    public static string InputTouchCount1 = "C_InputTouchCount1";
    public static string ReCoverySystemBrightness = "C_ReCoverySystemBrightness";
    public static string IsEnableSaveBattery = "C_IsEnableSaveBattery";

    public static string ReceiveBet = "C_ReceiveBet";

    public static string ShowUserHelper = "C_ShowUserHelper";

    public static string PandoraEventData = "C_PandoraEventData";
    public static string PandoraSetData = "C_PandoraSetData";
    public static string PandoraRetrunGameObject = "C_PandoraRetrunGameObject";
    public static string PandoraSound = "C_PandoraSound";

    public static string ShowPlayerShopEquipTips = "C_ShowPlayerShopEquipTips";

    public static string WishTeamCheck = "C_WishTeamCheck";
    public static string WishLetter = "C_WishLetter";
    public static string WishAwardTips = "C_WishAwardTips";
    public static string PlayUIEffect = "C_PlayUIEffect";

    public static string phoneSystemDev = "C_phoneSystemDev";

    public static string SetSecurityLockState = "C_SetSecurityLockState";

    public static string GetAndShareLink = "C_GetAndShareLink";

    public static string MainPlayerScorePointChange = "C_MainPlayerScorePointChange";
    public static string MainPlayerMentorshipPointChange = "C_MainPlayerMentorshipPointChange";
    public static string MainPlayerBraveTokenChange = "C_MainPlayerBraveTokenChange";
    public static string MainPlayerPrideValueChange = "C_MainPlayerPrideValueChange";

    public static string MyPlayerReturnChanged = "C_MyPlayerReturnChanged";

    public static string OpenPlayerReturnMain = "C_OpenPlayerReturnMain";
    //战队
    public static string WarTeamRefuseJoin = "C_WarTeamRefuseJoin";
    public static string WarTeamAgreeJoin = "C_WarTeamAgreeJoin";
    public static string OpenKeFuLink = "C_OpenKeFuLink";

    public static string DebugHuaShanSword = "C_DebugHuaShanSword";

    public static string PlayerDuetRideMovieComplete = "C_PlayerDuetRideMovieComplete";


    
    public static string MentorshipTeamCreated = "C_MentorshipTeamCreated";

    public static string TianLingDanUseCountChange = "C_TianLingDanUseCountChange";

    //真武修行
    public static string MyZhenWuXiuXingLevelChanged = "C_MyZhenWuXiuXingLevelChanged";
    public static string MyZhenWuXiuXingStateChanged = "C_MyZhenWuXiuXingStateChanged";
    public static string MyZhenWuXiuXingLevel = "C_MyZhenWuXiuXingLevel";

    //禁言
    public static string OnChangeChatBanned = "C_OnChangeChatBanned";

    //浏览器
    public static string ShowBrowser = "C_ShowBrowser";
    public static string HideBrowser = "C_HideBrowser";
    public static string LoadingOn = "C_LoadingOn";
    public static string LoadingOff = "C_LoadingOff";
    
    //家园
    public static string FurnitureArrangement = "C_FurnitureArrangement";
    public static string OpenEditMode = "C_OpenEditMode";
    public static string CloseEditMode = "C_CloseEditMode";
    public static string EnterHomeMobel = "C_EnterHomeMobel";
    public static string ShowFurnitureMakeMessage = "C_ShowFurnitureMakeMessage";
    public static string ChangeFurniture = "C_ChangeFurniture";
    public static string UploadHomePlan = "C_UploadHomePlan";//家园方案上传
    /// <summary>
    /// 家园是否开启状态变化 0未开启 1开启
    /// </summary>
    public static string HomeOpenState = "C_HomeOpenState";

    /// <summary>
    /// 家园GUID INT L INT H
    /// </summary>
    public static string EnterHomeReady = "L_EnterHomeReady";

    /// <summary>
    /// 家园Game模式下 选中物品
    /// </summary>
    public static string SelectedFurniture = "C_SelectedFurniture";
    /// <summary>
    /// 家园Game模式下 选中收获物
    /// </summary>
    public static string SelectedHarvest = "C_SelectedHarvest";
    public static string CustomCameraAniComplete = "C_CustomCameraAniComplete";

    public static string MainPlayerReceiveDamage = "C_MainPlayerReceiveDamage";

    //场景草地
    public static string GrassManagerNeedUpdate = "C_GrassManagerNeedUpdate";
    //背持武器
    public static string MainPlayerBackWeapon = "C_MainPlayerBackWeapon";

    //子女答疑数据变化 
    public static string ChildrenQuestionUpdate = "C_ChildrenQuestionUpdate";
    
    public static string LockedMonsterFlagUpdate = "C_LockedMonsterFlagUpdate";
    public static string LockedMonsterDataUpdate = "C_LockedMonsterDataUpdate";

    public static string ChatVoiceStopAudio = "C_ChatVoiceStopAudio";

    public static string FMYRStatus = "C_FMYRStatus";
    public static string ChangeWuhunForm = "C_ChangeWuhunForm";

    public static string PlayFaceActionMessage = "C_PlayFaceActionMessage";
    public static string PlayFaceActionEndMessage = "C_PlayFaceActionEndMessage";
    public static string PlayFaceActionFroceStopMessage = "C_PlayFaceActionFroceStopMessage";
    //主角信用度变化
    public static string UpdateMainPlayerCredit = "C_UpdateMainPlayerCredit";
    public static string UpdateFootPrint = "C_UpdateFootPrint";
    public static string UserAgree = "C_UserAgree";
    public static string GetIOSIDFA = "C_GetIOSIDFA";
    public static string CheckPermissions = "C_CheckPermissions";
    public static string HandlePermissions = "C_HandlePermissions";
    public static string CheckPermissionResult = "C_CheckPermissionResult";

    public static string UpdateSheildState = "C_UpdateSheildState";
    public static string UpdateTargetSheildState = "C_UpdateTargetSheildState";
    //启用高精度阴影
    public static string UseHighResolution = "C_UseHighResolution";

    public static string AnnouncementUIChange = "C_AnnouncementUIChange";

    public static string PermissionResult = "C_PermissionResult";

    public static string StealtheLevelChanged = "C_StealtheLevelChanged";//主角隐身等级发生变化

    // 退出时由GameUtil.cs:SafeQuitGame触发。不要在运行时使用，调用后会退出。
    public static string ChangeIconAndroid = "C_ChangeIconAndroid";

    // 轻功
    public static string ReadyToFly = "C_ReadyToFly";       // 准备使用轻功
    public static string CancelFly = "C_CancelFly";         // 取消待使用轻功的状态

    public static string OpenUrlInGame = "C_OpenUrlInGame";

    public static string FlowGraphTips = "C_FlowGraphTips";
    //WXMiniSDK
    public static string WXMini_GetProfile = "C_WXMini_GetProfile";
    public static string WXMini_GetProfileSuccess = "C_WXMini_GetProfileSuccess";

    public static string WXMini_GetLoginCode = "C_WXMini_GetLoginCode";
    public static string WXMini_GetLoginCodeSuccess = "C_WXMini_GetLoginCodeSuccess";
    public static string WXMini_GetLoginOpenIdSuccess = "C_WXMini_GetLoginOpenIdSuccess";

    public static string WXMini_PaySuccess = "C_WXMini_PaySuccess";
    public static string WXMini_PayFail = "C_WXMini_PayFail";
    public static string WXMini_Request_Balance = "C_WXMini_Request_Balance";
    public static string WXMini_LaunchPay = "C_WXMini_LaunchPay";

#if MOVIE_FORCE_LOADOVER
    //剧情ani加载完毕
    public static string LoadMovieAniFinish = "C_LoadMovieAniFinish";
#endif


}
