using UnityEngine;
using System.Collections;

/// <summary>
/// Lua发送的事件 LuaEvent.lua中抄过来
/// </summary>
public class LuaEvent
{
    public static string OnScreenSizeChange = "L_OnScreenSizeChange";//一般都不会用到

    public static string GetAchievement = "L_GetAchievement";

    public static string OnVideoResize = "L_OnVideoResize";
    public static string OnVideoReady = "L_OnVideoReady";
    public static string OnVideoEnd = "L_OnVideoEnd";
    public static string OnVideoFirstFrameReady = "L_OnVideoFirstFrameReady";
    public static string OnVideoError = "L_OnVideoError";
    public static string OnLowMemoryCallback = "L_OnLowMemoryCallback";
    public static string OnUpdateAnchor = "L_OnUpdateAnchor";
    public static string OnMovieActorCreate = "L_OnMovieActorCreate";
    public static string UpdateHeadIconMain = "L_UpdateHeadIconMain";

    public static string AutoDestroyTexture = "L_AutoDestroyTexture";

    public static string ShowTXActivityJHQYMainUI = "L_ShowTXActivityJHQYMainUI";
    public static string SongLiaoHonorChange = "L_SongLiaoHonorChange";
    public static string SongLiaoJiFenChange = "L_SongLiaoJiFenChange";
    public static string PvpRulerIdChange = "L_PvpRulerIdChange";
    public static string GameServerIdChange = "L_GameServerIdChange";
    public static string JingPoIdChange = "L_JingPoIdChange";
    public static string CloakIdChange = "L_CloakIdChange";
    public static string CloakRideFlagChange = "L_CloakRideFlagChange";
    public static string SpineStateCallBack = "L_SpineStateCallBack";
    public static string DTSMonsterItemListChange = "L_DTSMonsterItemListChange";
    public static string DTSDyingStateChange = "L_DTSDyingStateChange";
    public static string DTSSkillChange = "L_DTSSkillChange";
    public static string ClearAllQuickTips = "L_ClearAllQuickTips";
    public static string SceneDataChange = "L_SceneDataChange";
    public static string DTSScoreChange = "L_DTSScoreChange";
    public static string DTSDie = "L_DTSDie";

    public static string CharSkillConditionCheckInvalid = "L_CharSkillConditionCheckInvalid";
    public static string ResetVirtualBuffSNGenerator = "L_ResetVirtualBuffSNGenerator";
    public static string MainPlayerImpactDetailListUpdate = "L_MainPlayerImpactDetailListUpdate";
    public static string VigorChange = "L_VigorChange";
    public static string MaxVigorChange = "L_MaxVigorChange";
    public static string MyTitleChange = "L_MyTitleChange";

    public static string PvpModeChange = "L_PvpModeChange";
    public static string PvpValueChange = "L_PvpValueChange";

    public static string UpdatePlatformFriendGiftRedTips = "L_UpdatePlatformFriendGiftRedTips";

    public static string ZongHaoQingChange = "L_ZongHaoQingChange";
    public static string ZongMeiLiChange = "L_ZongMeiLiChange";
    public static string ZhouHaoQingChange = "L_ZhouHaoQingChange";
    public static string ZhouMeiLiChange = "L_ZhouMeiLiChange";

    public static string MyGuildIdChange = "L_MyGuildIdChange";
    public static string MyGuildNameChanged = "L_MyGuildNameChanged";

    public static string OpenRank = "L_OpenRank";
    public static string InteractWithCollection = "L_InteractWithCollection";
    public static string ScreenshotStart = "L_ScreenshotStart";
    public static string ScreenshotEnd = "L_ScreenshotEnd";

    public static string ScreenUnlockOpen = "L_ScreenUnlockOpen";//开启屏幕锁
    public static string ScreenUnlockClose = "L_ScreenUnlockClose";//关闭屏幕锁
    public static string ScreenUnlockHoldOn = "L_ScreenUnlockHoldOn";//保持屏幕锁

    public static string HuiLiuDaysChange = "L_HuiLiuDaysChange";
    public static string XiaYiChange = "L_XiaYiChange";
    public static string XiaYiGouYuChange = "L_XiaYiGouYuChange";
    public static string XiaoYongGouYuChange = "L_XiaoYongGouYuChange";
    public static string UniverseXFadeoutUI = "L_UniverseXFadeoutUI";
    public static string WaitingInLine = "L_WaitingInLine";

    public static string MyTargetOccupantChange = "L_MyTargetOccupantChange";

    //连接服务器
    public static string RequestConnect = "L_RequestConnect";

    //进度达到100%
    public static string LoadingProgressComplete = "L_LoadingProgressComplete";

    //登录界面打开 --异步
    public static string DeleteLoadingPanel = "L_DeleteLoadingPanel";

    //显示加载进度条
    public static string ShowLoadingProgressUI = "L_ShowLoadingProgressUI";

    //隐藏加载进度条
    public static string HideLoadingProgressUI = "L_HideLoadingProgressUI";

    public static string SetULogLevel = "L_SetULogLevel";

    public static string GCBankAcquireList = "L_GCBankAcquireList";
    public static string GCRetExpandBank = "L_GCRetExpandBank";
    public static string GCBankSwapItem = "L_GCBankSwapItem";
    public static string GCBankAddItem = "L_GCBankAddItem";
    public static string GCBankRemoveItem = "L_GCBankRemoveItem";
    public static string GCBankItemInfo = "L_GCBankItemInfo";
    public static string GCItemInfo = "L_GCItemInfo";

    public static string RegisterScreenShot = "L_RegisterScreenShot";
    public static string ScreenShot4Android = "L_ScreenShot4Android";
    public static string ScreenShot4iOS = "L_ScreenShot4iOS";

    public static string Native_ChangeIcon = "L_Native_ChangeIcon";

    /// <summary>
    /// 显示选角界面 参数：角色列表
    /// </summary>
    public static string ShowSelectRolePanel = "L_ShowSelectRolePanel";

    //*****组队相关******//
    public static string ShowTeamUI = "C_ShowTeamUI";

    //邀请一名玩家入队
    public static string SendInvitePlayer = "C_SendInvitePlayer";

    //加入一个玩家队伍
    public static string SendApplyPlayer = "C_SendApplyPlayer";

    //指派一名玩家当队长
    public static string SendAppointPlayer = "C_SendAppointPlayer";

    //踢人
    public static string SendKickPlayer = "C_SendKickPlayer";

    //创建队伍Click
    public static string CreateTeamBtn = "C_CreateTeamBtn";

    //组队平台Click
    //public static string TeamPlatformBtn = "C_TeamPlatformBtn";
    //退出队伍按钮Click
    public static string TeamLeaveBtn = "C_TeamLeaveBtn";

    //同意入队Click
    public static string TeamYesBtn = "C_TeamYesBtn";

    //拒绝入队Click
    public static string TeamNoBtn = "C_TeamNoBtn";

    //玩家清空申请列表
    public static string TeamCleanBtn = "C_TeamCleanBtn";

    //删除申请列表项
    public static string TeamRemoveBtn = "C_TeamRemoveBtn";

    //通过组队界面点击Item申请好友
    public static string TeamAddFriendBtn = "C_TeamAddFriendBtn";

    //队伍集合Click
    public static string TeamMusterBtn = "C_TeamMusterBtn";

    //显示组队邀请弹窗
    public static string ShowTeamMessageUI = "C_ShowTeamMessageUI";

    //取消组队跟随
    public static string TeamFollowCancel = "C_TeamFollowCancel";

    //组队弹窗确定选项Click
    public static string MessageSureBtn = "C_MessageSureBtn";

    //组队弹窗拒绝选项Click
    public static string MessageCancelBtn = "C_MessageCancelBtn";

    //取消全场景寻找队长的状态
    public static string StopFindTeamLeader = "C_StopFindTeamLeader";

    //组队专用队友观察
    public static string RolerViewForTeam = "C_RolerViewForTeam";
    //队伍转团队
    public static string TeamChangeToRaid = "C_TeamChangeToRaid";

    //*****组队end******//

    //*****时装相关******//
    //打开时装主界面
    public static string OpenFashionMainUI = "L_OpenFashionMainUI";

    //更新时装主界面
    public static string UpdateFashionMainUI = "L_UpdateFashionMainUI";
    public static string BabyUpdateFashionMainUI = "L_BabyUpdateFashionMainUI";

    //有新的时装被激活（用于红点）
    public static string NewFashionOrColor = "L_NewFashionOrColor";
    //去染色按钮
    public static string FashionGoToRanSe = "L_FashionGoToRanSe";
    //试穿按钮
    public static string FashionDressUp = "L_FashionDressUp";
    //时装List点击事件
    public static string FashionItem = "L_FashionItem";
    //时装染色Icon点击事件
    public static string FashionRanSeIcon = "L_FashionRanSeIcon";
    //染色相关
    //打开染色界面
    public static string OpenFashionColorUI = "L_OpenFashionColorUI";
    //打开染色界面
    public static string UpdateFashionColorUI = "L_UpdateFashionColorUI";
    public static string UpdateFreeFashionColorUI = "L_UpdateFreeFashionColorUI";
    //染色
    public static string FashionDoColor = "L_FashionDoColor";
    public static string FashionDoFreeColor = "L_FashionDoFreeColor";
    public static string FashionDressSucess = "L_FashionDressSucess";
    public static string FashionDressFail = "L_FashionDressFail";
    public static string FashionColorChange = "L_FashionColorChange";
    //*****时装end******//

    /*子女时装*/
    //有新的时装被激活（用于红点）
    public static string BabyChangeFashion = "L_BabyChangeFashion";
    public static string BabyChangeHair = "L_BabyChangeHair";

    public static string BabyNewFashionOrColor = "L_BabyNewFashionOrColor";
    public static string BabyChangeWeapon = "L_BabyChangeWeapon";
    public static string BabyChangeRoom = "L_BabyChangeRoom";
    //去染色按钮
    public static string BabyFashionGoToRanSe = "L_BabyFashionGoToRanSe";
    //试穿按钮
    public static string BabyFashionDressUp = "L_BabyFashionDressUp";
    //时装List点击事件
    public static string BabyFashionItem = "L_BabyFashionItem";
    //时装染色Icon点击事件
    public static string BabyFashionRanSeIcon = "L_BabyFashionRanSeIcon";
    //染色相关
    //打开染色界面
    public static string BabyOpenFashionColorUI = "L_BabyOpenFashionColorUI";
    //打开染色界面
    public static string BabyUpdateFashionColorUI = "L_BabyUpdateFashionColorUI";
    //染色
    public static string BabyFashionDoColor         = "L_BabyFashionDoColor";
    public static string BabyFashionDressSucess     = "L_BabyFashionDressSucess";
    public static string BabyFashionDressFail       = "L_BabyFashionDressFail";
    public static string BabyFashionColorChange     = "L_BabyFashionColorChange";
    /*子女时装*/

    //显示漂浮提示
    public static string ShowPublicTip = "L_ShowPublicTip";
    public static string ShowPublicTipAsync = "L_ShowPublicTipAsync";

    public static string ShowPublicTip2 = "L_ShowSongLiaoTips";

    public static string ShowPublicLowerTip = "L_ShowPublicLowerTip";
    public static string HidePublicLowerTip = "L_HidePublicLowerTip";

    //打开银两商店
    public static string OpenMoneyShop = "L_OpenMoneyShop";

    /// <summary>
    /// 点击技能按钮  请求使用技能
    /// </summary>
    public static string ClickSkillBtn = "L_ClickSkillBtn";
	/// <summary>
	/// 点击选中目标的目标
	/// </summary>
	public static string ClickTargetOfTargetBtn = "L_ClickTargetOfTargetBtn";

	/// <summary>
	/// 点击技能组按钮
	/// </summary>
	public static string ClickSkillGroupBtn = "L_ClickSkillGroupBtn";

    //点击MessageBox按钮
    //public static string RequestMessageBoxBtn = "L_RequestMessageBoxBtn";

    //点击TAB切换目标按钮
    public static string ClickTABBtn = "L_ClickTABBtn";

    //装备
    //穿脱装备
    public static string EquipOnOFfBtn = "L_EquipOnOFfBtn";

    //成功穿装备
    public static string UseEquipSuccess = "L_UseEquipSuccess";

    //成功卸下装备
    public static string UnEquipSuccess = "L_UnEquipSuccess";

    //强化装备
    public static string EquipQHBtn = "L_EquipQHBtn";

    //精炼装备
    public static string EquipJLBtn = "L_EquipJLBtn";

    //出售装备
    public static string EquipSellBtn = "L_EquipSellBtn";

    //福利大厅
    public static string ShowGiftMainBtn = "L_ShowGiftMainBtn";

    public static string ShowMonthlySignBtn = "L_MonthlySignBtn";
    public static string SignOrResign = "L_SignOrResign";
    public static string AskPrizeItemTips = "L_AskPrizeItemTips";
    public static string ShowMonthlySignUI = "L_ShowMonthlySignUI";

    //道具
    //出售道具
    public static string ItemSellBtn = "L_ItemSellBtn";

    //使用道具
    public static string ItemUseBtn = "L_ItemUseBtn";

    //申请道具信息
    public static string AskItemByBagIndex = "L_AskItemByBagIndex";
    //背包整理状态
    public static string ChangeBagTidyingState = "L_ChangeBagTidyingState";
    //使用道具
    public static string AskUseItem = "L_UseItem";
    public static string AskUseItemFromHomeDepot = "L_AskUseItemFromHomeDepot";

    public static string UseItemSuccess = "L_UseItemSuccess";

    //显示NPC传送信息面板
    public static string ShowNpcTransportPanel = "L_ShowNpcTransportPanel";

    public static string SelectTransportItem = "L_SelectTransportItem";
    public static string CloseSelectNpcTransportPanel = "L_CloseSelectNpcTransportPanel";

    //背包拾取
    public static string PickupTotalBtn = "L_ClickPickupTotalBtn";

    public static string DropList = "L_DropList";
    public static string PickupItem = "L_PickupItem";

    //死亡复活相关
    public static string RELIVE_SHOW = "L_RELIVE_SHOW"; //显示复活界面  arg0 是否有复活按钮，arg1 剩余时间

    public static string RELIVE_HIDDEN = "L_RELIVE_HIDDEN";//隐藏复活界面
    public static string RELIVE_TBATTLE = "L_RELIVE_TBATTLE";
    public static string RELIVE_MODIFY = "L_RELIVE_MODIFY";
    public static string RELIVE_HUA_SHAN = "L_RELIVE_HUA_SHAN";
    public static string RELIVE_GUILD_TERRITORY = "L_RELIVE_GUILD_TERRITORY";
    public static string RELIVE_QHL_PVP = "L_RELIVE_QHL_PVP";
    public static string RELIVE_NOT_SHOW = "L_RELIVE_NOT_SHOW";
    public static string RELIVE_XIALV = "L_RELIVE_XIALV";
    public static string RELIVE_NATIONWIDE = "L_RELIVE_NATIONWIDE";
    public static string RELIVE_BOOKBATTLE = "L_RELIVE_BOOKBATTLE";
    public static string RELIVE_DEFAULT = "L_RELIVE_DEFAULT";
    public static string RELIVE_HERO_DALUANDOU = "L_RELIVE_HERO_DALUANDOU";
    public static string RELIVE_GUILD_ARENA = "L_RELIVE_GUILD_ARENA";

    public static string PLAYER_DIE_RESULT = "L_PLAYER_DIE_RESULT";

    //主角死亡
    public static string MainPlayerDie = "L_MainPlayerDie";

    //旧UICommand
    public static string UI_COMMAND = "L_UI_COMMAND";

    /// <summary>
    /// 新加了这个MainPlayerLevelUp单独用来监听玩家等级升级
    /// 原来的LuaEvent.MainPlayerLevelChange被用残了,在初始等级的时也会用到，
    /// 导致那些仅监听等级升级的逻辑出现问题
    /// AndyChen
    /// </summary>
    public static string MainPlayerLevelUp = "L_MainPlayerLevelUp";

    //任务
    public static string ReqMissionList = "L_ReqMissionList";

    public static string ShowDialog = "L_ShowDialog";
    public static string ShowDialogByMission = "L_ShowDialogByMission";
    public static string CloseStoryDialog = "L_CloseStoryDialog";

    //剧情结束
    public static string StoryComplete = "L_StoryComplete";

    //剧情结束-带mission
    public static string StoryCompleteWithMission = "L_StoryCompleteWithMission";

    //任务提交
    public static string ReqMissionSubmit = "L_ReqMissionSubmit";

    //看风景
    public static string EnterAreaOK = "L_EnterAreaOK";

    //请求任务交付类型
    public static string ReqMissionDelivery = "L_ReqMissionDelivery";

    public static string UpdateAbandenMission = "L_UpdateAbandenMission";
    public static string DeliveryMissionShowUI = "L_DeliveryMissionShowUI";
    public static string ShowMissionReward = "L_ShowMissionReward";

    // 惩凶打图任务请求服务器种恶霸
    public static string UseTreasureMap = "L_UseTreasureMap"; // 使用宝图

    public static string CreateBanditSuccess = "L_CreateBanditSuccess"; // 创建恶霸成功，通知自动攻击 QUICK_USE_TREASUREMAP
    public static string QuickUseTreasuremap = "L_QuickUseTreasuremap"; // 快速使用宝图

    // 马贼任务
    public static string MissionMaZei_Trace = "L_MissionMaZei_Trace"; // 马贼寻路

    public static string MissionMaZei_GuaJi = "L_MissionMaZei_GuaJi"; // 马贼挂机
    public static string MissionMaZei_Surprised_Box = "L_MissionMaZei_Surprised_Box"; // 马贼任务惊喜宝箱
    public static string MissionMaZei_OperSurprised_Box = "L_MissionMaZei_OperSurprised_Box"; // 马贼任务相应惊喜宝箱

    //师门任务：好友互动
    public static string ReqMissionAskFriend = "L_ReqMissionAskFriend";

    public static string ReqMissionHelpList = "L_ReqMissionHelpList";
    public static string UpdateAskLeftTimes = "L_UpdateAskLeftTimes";
    public static string ReqAbandonShiMenMission = "L_ReqAbandonShiMenMission";
    public static string ShowMissionSelectUI = "L_ShowMissionSelectUI";
    public static string ClearAcceptShiMenState = "L_ClearAcceptShiMenState";

    //公用信息提示框
    public static string ShowMessageUI = "L_ShowMessageUI";
    public static string ShowMessageUIForRemind = "L_ShowMessageUIForRemind";

    public static string CloseMessageUI = "L_CloseMessageUI";

    //显示一个进度条
    public static string ShowProgress = "L_ShowProgress";

    //进度条结束事件
    public static string EndProgress = "L_EndProgress";

    //更新进度条(如技能读条时被攻击延长进度)
    public static string UpdateProgress = "L_UpdateProgress";

    //更新最大进度，有延长引导时间的效果
    public static string UpdateMaxProgress = "L_UpdateMaxProgress";

    //结束进度条
    public static string StopProgress = "L_StopProgress";

    //进度条UI走完
    public static string ProgressUIEnd = "L_ProgressUIEnd";

    //背包
    public static string AskBagList = "L_AskBagList";

    public static string AskItemInfo = "L_AskItemInfo";
    public static string BagSizeChange = "L_BagSizeChange";
    public static string AskEquipList = "L_AskEquipList";
    public static string OpenTag = "L_OpenTag";
    public static string ArrangeBag = "L_ArrangeBag";

    public static string SortBagItem = "L_SortBagItem";

    // 背包中有新的物品
    public static string HasNewItemInBag = "L_HasNewItemInBag";
    public static string AnimNewItemInBag = "L_AnimNewItemInBag";


    // 背包的物品信息有更新,这个是增加
    public static string ItemInfoChange = "L_ItemInfoChange";

    // 背包的物品信息有更新,这个是变化
    public static string ItemInfoChange2 = "L_ItemInfoChange2";

    // 背包关闭
    public static string BagClosed = "L_BagClosed";

    // 更新背包中物品是否为新物品的标记（用于背包小红点）
    public static string UpdateBagItemNewFlag = "L_UpdateBagItemNewFlag";

    // 选择背包格子
    public static string SelectBagCell = "L_SelectBagCell";

    //请求大混乱副本【哥很负责的告诉你：绝对是临时的，不信你瞧】
    public static string AskDaHunLuan = "L_AskDaHunLuan";

    public static string DaHunZhanUpdateStatus = "L_DaHunZhanUpdateStatus";
    public static string DaHunZhanScoreUpdate = "L_DaHunZhanScoreUpdate";

    //游戏暂停维护
    public static string GameWaitState = "L_GameWaitState";

    //npc 冒泡
    public static string ShowNpcBubble = "L_ShowNpcBubble";

    //UI相关
    public static string CloseAllPopUI = "L_CloseAllPopUI";

    //断线重连
    public static string ReconnectOnLoss = "L_ReconnectOnLoss";

    //聊天 发送gm
    public static string ReqGMChat = "L_ReqGMChat";

    public static string ReqSendChatMessage = "L_ReqSendChatMessage";
    public static string ShowChatBubble = "L_ShowChatBubble";// 显示聊天泡泡

    //public static string NotifyCanShowHorn = "L_NotifyCanShowHorn";
    //public static string ChatRecordInsertData = "L_ChatRecordInsertData";//lua通知c#记录插入数据
    public static string ChatRecordCurrChannel = "L_ChatRecordCurrChannel";

    public static string ChatClickChaterItem = "L_ChatClickChaterItem";
    public static string ClearTargetChatMessage = "L_ClearTargetChatMessage";//清空目標對象的所有聊天消息
    //录音错误，关闭录音界面
    public static string CloseChatNoticeAndStopRecord = "L_CloseChatNoticeAndStopRecord";
    public static string CloseChatNoticeAndStopRecordAsync = "L_CloseChatNoticeAndStopRecordAsync";
    //清空聊天世界频道和跨服频道记录的本地时间
    public static string ResetChatLocalTime = "L_ResetChatLocalTime";
    public static string ChatMicOpenSucc = "L_ChatMicOpenSucc";

    //选择一个主播
    public static string ChooseLiveId = "L_ChooseLiveId";

    //珍兽
    public static string ShowGeniusMain = "L_ShowGeniusMain";

    public static string CallUpPet = "L_CallUpPet";
    public static string FreePet = "L_FreePet";
    public static string GetPetAttribute = "L_GetPetAttribute";
    public static string LearnPetSkill = "L_LearnPetSkill";
    public static string ReproducePet = "L_ReproducePet";
    public static string ChangeNamePet = "L_ChangeNamePet";
    public static string TrainPet = "L_TrainPet";
    public static string XiSuiPet = "L_XiSuiPet";
    public static string PossessionPet = "L_PossessionPet";
    public static string ClickGeniusSkillBtn = "L_ClickGeniusSkillBtn";
    public static string ClickChooseSkillBookBtn = "L_ClickChooseSkillBookBtn";
    public static string ClickSkillBookCell = "L_ClickSkillBookCell";
    public static string ClickLearnSkillBtn = "L_ClickLearnSkillBtn";
    public static string AllShouHunRequest = "L_AllShouHunRequest";
    public static string AddShouHun = "L_AddShouHun";
    public static string SetPossession = "L_SetPossession";
    public static string CallUpGodPet = "C_CallUpGodPet";
    public static string GodPetJueXing = "C_GodPetJueXing";
    public static string PetInherit = "C_PetInherit";
    public static string PetInheritPreview = "C_PetInheritPreview";
    public static string PetPossStudy = "C_PetPossStudy";
    public static string PetPossLevelup = "C_PetPossLevelup";
    public static string PetPossForget = "C_PetPossForget";
    public static string PetPossPreview = "C_PetPossPreview";

    public static string CloseMap = "L_CloseMap";

    //子女
    public static string ChildrenCallUp         = "L_ChildrenCallUp"; 
    public static string ChildrenFree           = "L_ChildrenFreePet";          
    public static string ChildrenLearnSkill     = "L_ChildrenLearnPetSkill";
    public static string ChildrenChangeName     = "L_ChildrenChangeName";
    public static string ChildrenTrain          = "L_ChildrenTrain"; 
    public static string ChildrenInheritPreview = "L_ChildrenInheritPreview";

    //技能

    //神器升阶
    public static string MysticalWeaponUpgrade = "L_MysticalWeaponUpgrade";

    public static string MysticalWeaponUpgradeResult = "L_MysticalWeaponUpgradeResult"; //神器升阶结果

    public static string MysticalWeaponLevelUpResult = "L_MysticalWeaponLevelUpResult"; //神器升级结果

    public static string MysticalWeaponSkillVisible = "L_MysticalWeaponSkillVisible";   //控制神器技能显示或影藏： 0 隐藏，1：显示

    public static string MysticalWeaponSkillActived = "L_MysticalWeaponSkillActived";   //神器技能激活
    public static string MysticalWeaponSkillActivedResult = "L_MysticalWeaponSkillActivedResult";   //神器技能激活结果
    public static string MysticalWeaponCast = "L_MysticalWeaponCast";   //请求神器神铸信息
    public static string MysticalWeaponCastResult = "L_MysticalWeaponCastResult";   //神器神铸结果

    public static string MysticalWeaponLevelUp = "L_MysticalWeaponLevelUp";
    public static string GodWeaponPreShow = "L_GodWeaponPreShow";//显示神器预览界面

    //声音相关
    public static string SoundMissionComplete = "L_SoundMissionComplete"; //播放任务完成音效

    public static string SoundLevelUp = "L_SoundLevelUp"; //播放任务完成音效
    public static string SoundPlaySceneSFX = "L_SoundPlaySceneSFX"; //播放环境音效
    public static string SoundStopSceneSFX = "L_SoundStopSceneSFX"; //停止环境音效
    public static string SoundNPC = "L_SoundNPC"; //播放任务完成音效
    public static string NPCSoundSwitch = "L_NPCSoundSwitch"; //npc语音开关 1开 0关

    //新手礼包图标刷新
    public static string NewBeeIconRefresh = "L_NewBeeIconRefresh";

    //新手礼包界面刷新
    public static string NewBeeUIRefresh = "L_NewBeeUIRefresh";

    public static string ShowNewBeeGift = "L_ShowNewBeeGift";
    public static string ReceiveFirstItemForGuide = "L_ReceiveFirstItemForGuide";

    //首充图标刷新
    public static string YuanBaoCostIconRefresh = "L_YuanBaoCostIconRefresh";

    //首充界面刷新
    public static string YuanBaoCostUIRefresh = "L_YuanBaoCostUIRefresh";

    //打开剧情跳过界面
    public static string ShowMovieSkipUI = "L_ShowMovieSkipUI";

    //打开剧情倒计时界面
    public static string ShowMovieCountUI = "L_ShowMovieCountUI";

    //点击跳过
    public static string OnMovieSkip = "L_OnMovieSKip";

	public static string SkipJumpFlyAction = "L_SkipJumpFlyAction";

    //点击单人副本按钮
    public static string EnterSingleFuben = "L_EnterSingleFuben";

    //人物升级技能
    public static string CharacterClickSkill = "L_CharacterClickSkill";

    //切换心法
    public static string CharacterSwitchSkill = "L_CharacterSwitchSkill";

    //福利界面
    public static string ShowGiftIcon = "L_ShowGiftIcon";

    //显示/隐藏 切换场景ui {bool}
    public static string ShowChangeSceneUI = "L_ShowChangeSceneUI";

    //设置挂机 {bool}
    public static string SetAutoBattle = "L_SetAutoBattle";

    public static string ShowCompositeFunction = "L_ShowCompositeFunction";
    public static string ClickGeniusIcon = "L_ClickGeniusIcon";

    public static string ShowFirstTimeYuanBao = "L_ShowFirstTimeYuanBaoBtn";

    //序章中神器使用引导显示
    public static string PrologueShowWeaponUseGuid = "L_PrologueShowWeaponUseGuid";

    public static string ClickPrologueWeaponBtn = "L_ClickPrologueWeaponBtn";

    //enable or disable the clicking function of the 'PlayerHeadUI'.
    public static string EnablePlayerHeadUIClick = "L_EnablePlayerHeadUIClick";

    //自己退出帮会或者被踢
    public static string LeaveGuildMySelf = "L_LeaveGuildMySelf";
    //自己从无帮会到有帮会
    public static string JoinGuildMySelf = "L_JoinGuildMySelf";

    public static string RecruitMember = "L_RecruitMember";

    public static string ShowGuildInviteUI = "L_ShowGuildInviteUI";


    //帮会大厅
    public static string OpenGuildLobbyPanel = "L_OpenGuildLobbyPanel";

    public static string GuildLobbyForbidOption = "L_GuildLobbyForbidOption";
    public static string GuildForceClose = "L_GuildForceClose";
    //public static string GuildUpdateApplyTag = "L_GuildUpdateApplyTag";

    public static string OpenGuildWarDetail = "L_OpenGuildWarDetail"; //帮会宣战弹出界面
    public static string OpenGuildWarConcrete = "L_OpenGuildWarConcrete"; //帮会发起宣战
    public static string OpenGuildWarDeclaration = "L_OpenGuildWarDeclaration"; //帮战详情
    public static string ShowGuildWarList = "L_ShowGuildWarList"; //
    public static string ShowGuildWarNameChange = "L_ShowGuildWarNameChange"; //帮战引起的名字改变

    //帮会活动  行酒令
    public static string CheckGuildDrinkFocus = "L_CheckGuildDrinkFocus"; //行酒令 获取焦点

    public static string OpenGuildDrink = "L_OpenGuildDrink"; //行酒令 活动信息
    public static string CloseGuildDrink = "L_CloseGuildDrink"; //
    public static string OpenGuildDrinkAnswer = "L_OpenGuildDrinkAnswer"; //答题界面
    public static string OpenGuildDrinkDice = "L_OpenGuildDrinkDice"; //投骰子界面
    public static string FreshGuildDrink = "L_FreshGuildDrink"; //刷新活动信息
    public static string FreshGuildDrinkAnswer = "L_FreshGuildDrinkAnswer"; //刷新答题界面
    public static string FreshGuildDrinkDice = "L_FreshGuildDrinkDice"; //刷新投骰子

    //帮会修炼
    public static string AskXiulianList = "L_AskXiulianList"; //请求帮会修炼list

    //帮会创建与退出
    public static string GainGuild = "L_GainGuild";     //帮会从无到有

    public static string RemoveGuild = "L_RemoveGuild"; //帮会从有到无

    //relation
    public static string requestRelationList = "L_requestRelationList";

    public static string orderRelation = "L_orderRelation";
    public static string requestDefaultFinderList = "L_requestDefaultFinderList";
    public static string updateFinderList = "L_updateFinderList";
    public static string updateRelationList = "L_updateRelationList";
    public static string addFriend = "L_addFriend";
    public static string requestSearchByNameOrId = "L_requestSearchByNameOrId";
    public static string requestSearchByName = "L_requestSearchByName";
    public static string requestSearchByCondition = "L_requestSearchByCondition";
    public static string getSecondRelationUiInfo = "L_getSecondRelationUiInfo";
    public static string requestModifyMood = "L_requestModifyMood";
    public static string switchRelationTab = "L_switchRelationTab";
    public static string setRelationTabNumber = "L_setRelationTabNumber";
    public static string setOrderType = "L_setOrderType";
    public static string openSearchUI = "L_openSearchUI";
    public static string addFriendByPropelline = "L_addFriendByPropelline";

    public static string NewRecenter = "L_NewRecenter"; //最近列表超过上限后 新添加的人  发这个事件
    public static string ClearRelationChat = "L_ClearRelationChat"; //删除聊天信息

    public static string requestRecenter = "L_requestRecenter";//请求最近的人列表
    public static string relationChat = "L_relationChat";//聊天切换
    public static string requestSecondFromRecently = "L_requestSecondFromRecently";//最近列表的人请求二级菜单
    //家具
    public static string FinishLoadFurnitureShowForUI = "L_FinishLoadFurnitureShowForUI";
    public static string FinishLoadToyShowForUI = "L_FinishLoadToyShowForUI";
    //坐骑
    public static string ShowRideDetailUI = "L_ShowRideDetailUI";

    public static string FinishLoadRideShowForUI = "L_FinishLoadRideShowForUI";
    public static string UpdateRideDetailUI = "L_UpdateRideDetailUI";
    public static string RideDetailBtnUpdate = "L_RideDetailBtnUpdate";

    //public static string RideControlOK = "L_RideControlOK";
    public static string UpdateRideCDEffect = "L_UpdateRideCDEffect";//用于刷新坐骑按钮的CD特效

    public static string DeleteFirstLoadingUI = "L_DeleteFirstLoadingUI";
    public static string RefreshRideDetailModelAction = "L_RefreshRideDetailModelAction";

    //multiplayer copy
    public static string showCopyEnterPromptUI = "L_showCopyEnterPromptUI";

    public static string showCopyCountDownUI = "L_showCopyCountDownUI";

    //public static string updateCountDownTime = "L_updateCountDownTime";
    public static string showOneKeyAddFriendUI = "L_showOneKeyAddFriendUI";

    public static string addFriendByOneKey = "L_addFriendByOneKey";
    public static string leaveMultiplayerCopy = "L_leaveMultiplayerCopy";
    public static string ShowCopyTargetUI = "L_ShowCopyTargetUI";
    public static string ShowCopyEventUI = "L_ShowCopyEventUI";
    public static string CopyRequestFindNPC = "L_CopyRequestFindNPC";
    public static string CopyEventFindNPC = "L_CopyEventFindNPC";
    public static string CloseAllMultiPlayerUI = "L_CloseAllMultiPlayerUI";

    //更改场景名字
    public static string UpdateSceneName = "L_UpdateSceneName";

    //副本大厅按钮显示
    public static string ShowMultiPlayerBtn = "L_ShowMultiPlayerBtn";

    public static string showMultiPlayerHall = "L_showMultiPlayerHall";
    public static string askCopySceneCount = "L_askCopySceneCount";

    //摄像机与世界地图的事件
    public static string MapNotifyCameraMove = "L_MapNotifyCameraMove";

    public static string MapNotifyCameraStop = "L_MapNotifyCameraStop";
    public static string ResetCamera = "L_ResetCamera";
    public static string Cam25D = "L_Cam25D";
    public static string CamEnableFollw = "L_CamEnableFollw";
    public static string FixeCamDistance = "L_FixeCamDistance";

    //寻路时调用的事件
    public static string PathfindingNotifyStart = "L_PathfindingNotifyStart";

    public static string PathfindingNotifyOver = "L_PathfindingNotifyOver";
    public static string TriggerGotoTarget = "L_TriggerGotoTarget";
    //1，人物寻路停止
    //2，控制摇杆移动
    //3，发生moveCommand(正在寻路中，然后切换寻路；同意组队跟随)
    public static string ClearSpecialPathFindFlag = "L_ClearSpecialPathFindFlag";

    //打开冶炼UI
    public static string ShowSmeltPanel = "L_ShowSmeltPanel";

    //打开强化UI
    public static string ShowAugmentUI = "L_ShowAugmentUI";

    //请求强化装备
    public static string ReqEnhanceEquipSlot = "L_ReqEnhanceEquipSlot";

    public static string ShowGemPanel = "L_ShowGemPanel";

    // 镶嵌成功
    public static string GemInlaySuccess = "L_GemInlaySuccess";

    // 宝石卸下成功
    public static string GemRemoveSuccess = "L_GemRemoveSuccess";

    // 宝石提升成功
    public static string GemLevelUpSuccess = "L_GemLevelUpSuccess";

    // 宝石合成成功
    public static string GemComposeSuccess = "L_GemComposeSuccess";

    // 更新镶嵌信息
    public static string UpdateInlayInfo = "L_UpdateInlayInfo";

    // 请求宝石镶嵌信息
    public static string AskGemContainer = "L_AskGemContainer";

    //装备熔炼
    public static string ShowFurnaceUI = "L_ShowFurnaceUI";

    public static string FurnaceGetAllEquip = "L_FurnaceGetAllEquip";//获取装备列表
    public static string FurnaceReq = "L_FurnaceReq";//请求一键熔炼
    public static string FurnaceReqReward = "L_FurnaceReqReward";//请求领取熔炼礼包

    public static string UpdateNetDelay = "L_UpdateNetDelay";//刷新当前网络延迟

    //提示坐骑小红点
    public static string ShowRideRedTips = "L_ShowRideRedTips";

    //登录
    public static string NewRoleCamMovieEnd = "L_NewRoleCamMovieEnd";

    public static string ReqCreateRole = "L_ReqCreateRole"; //请求创建角色
    public static string ShowLoadingUI = "L_ShowLoadingUI";

    public static string ShowLoadingUI4PlatformFriend = "L_ShowLoadingUI4PlatformFriend";
    public static string RefreshPlatformFriendsUI = "L_RefreshPlatformFriendsUI";

    public static string ShowLoadingUI4LoginTXPermission = "L_ShowLoadingUI4LoginTXPermission";

    //public static string DiffAccount_WXAutoPermission = "L_DiffAccount_WXAutoPermission";
    public static string MSDK_WXAutoPermission = "L_MSDK_WXAutoPermission";

    public static string MSDK_GetIPInfoCallback = "L_MSDK_GetIPInfoCallback";//获得IP所属地信息的回调

    public static string CSharpMSDKLogout = "L_CSharpMSDKLogout";

    public static string AskLoginServerShowLoadingUI = "L_AskLoginServerShowLoadingUI"; // 由于AskLoginServer显示loading界面如果超时，需要显示severPageUI，所以特写
    public static string CloseLoadingUI = "L_CloseLoadingUI";
    public static string AddLoadingUITime = "L_AddLoadingUITime";//每收到一条协议增加时间
    public static string OpenSelectRoleUI = "L_OpenSelectRoleUI";//打开选择角色UI
    public static string EnterGameServer = "L_EnterGameServer";
    public static string CloseAllLoginUI = "L_CloseAllLoginUI";//关闭所有登录相关UI
    public static string ReqQuitGame = "L_ReqQuitGame";//请求服务器退出游戏
    public static string ShowLoadingUIForTime = "L_ShowLoadingUIForTime";//打开LoadingUI一段时间
    public static string IPhoneGenerationIsLow = "L_IPhoneGenerationIsLow";// 是低端机
    public static string RequestLoginNotice = "L_RequestLoginNotice";// 请求公告
    public static string RequestLoginServer = "L_RequestLoginServer";// 请求登陆login服务器

    public static string UICameraNoGary = "L_UICameraNoGary";

    public static string ChangeCurServerState = "L_ChangeCurServerState";

    public static string ShowRechargeMain = "L_ShowRechargeMain";

    public static string VersionCheckFailed = "L_VersionCheckFailed"; // 版本校验错误

    //热更新部分
    public static string StartNewDownloadProcedure = "L_StartNewDownloadProcedure";

    //新手引导用到的事件
    public static string Guide_TraceMission = "L_Guide_TraceMission";   //点击左侧任务按钮

    public static string Guide_ActiveRide = "L_Guide_ActiveRide";   //点击装备坐骑界面的装备按钮
    public static string Guide_ActiveFashion = "L_Guide_ActiveFashion";//点击快捷提示界面的时装使用按钮
    public static string Guide_RideUpDown = "L_Guide_RideUpDown";   //点击使用骑乘
    public static string Guide_Mission_Complete = "L_Guide_Mission_Complete";  //任务 完成可交付 时发送
    public static string Guide_NewBeeGiftUI_Scroll = "L_Guide_NewBeeGiftUI_Scroll"; //滚动乾坤袋视图

    public static string TrigerGuideEvent = "L_TrigerGuideEvent"; //新手指引

    //UI
    public static string CheckClosedUI = "L_CheckClosedUI"; //关闭UI会发送的事件 id

    public static string CheckOpenUI = "L_CheckOpenUI";//打开UI会发送的事件 id

    /// <summary>
    /// 珍兽TIPS显示 参数 SData_ChatPet 实体
    /// </summary>
    public static string ShowPetAttrTips = "L_ShowPetAttrTips";

    //声音
    //播放主角随机受击音效
    public static string SoundRoleBeHit = "L_SoundRoleBeHit";

    // 名字板 作废
    //public static string UpdateNamePadAllNpcMissionState = "L_UpdateNamePadAllNpcMissionState";

    public static string UpdateNamePadNpcMissionState = "L_UpdateNamePadNpcMissionState";
    public static string UpdateNamePadMasterMissionState = "L_UpdateNamePadMasterMissionState";

    // 掉落名字版
    public static string SetDropNamePadInfo = "L_SetDropNamePadInfo";

    //卡牌相关
    public static string UpdateHeroCardInfo = "L_UpdateHeroCardInfo";//刷新玩家的卡牌数据

    public static string UpdateMaterialList = "L_UpdateMaterialList";//刷新玩家的材料数据
    public static string ShowHeroMainPanelUI = "L_ShowHeroMainPanelUI"; //打开英雄谱总UI
    public static string ShowHeroCardUI = "L_ShowHeroCardUI"; //打开英雄谱列表
    public static string ShowHeroMakeUI = "L_ShowHeroMakeUI"; //打开结交卡牌UI
    public static string ShowHeroDetailUI = "L_ShowHeroDetailUI";//打开卡牌详情UI
    public static string ReqHeroLevelUp = "L_ReqHeroLevelUp";//卡牌升级
    public static string ReqHeroCardInfo = "L_ReqHeroCardInfo";//请求卡牌列表
    //public static string ReqActiveHero = "L_ReqActiveHero";//请求激活卡牌

    public static string ApplicationCaptureScreenShotFinish = "L_ApplicationCaptureScreenShotFinish";
    public static string ApplicationCaptureScreenShotFail = "L_ApplicationCaptureScreenShotFail";
    public static string ApplicationCaptureScreenShotLocalFinish = "L_ApplicationCaptureScreenShotLocalFinish";
    public static string ApplicationCaptureScreenShotLocalFail = "L_ApplicationCaptureScreenShotLocalFail";

    public static string SaveTexture2DToLocalFinish = "L_SaveTexture2DToLocalFinish";

    public static string OnProcedureChange = "L_OnProcedureChange";

    public static string SetUpPetNamePad = "L_SetUpPetNamePad";

    // 鼠标按下和鼠标释放的中间事件
    public static string OnPressReleaseBeforeClick = "L_PressReleaseBeforeClick";

    //
    public static string Input_OnPress = "L_Input_OnPress";

    public static string OnReceiveSystemAnnouncement = "L_OnReceiveSystemAnnouncement";

    //腾讯公告
    public static string TencentScrollNotice = "L_TencentScrollNotice";

    public static string OpenRoleViewPanel = "L_OpenRoleViewPanel";

    //英雄试练
    public static string OpenHeroTrialsBox = "L_OpenHeroTrialsBox";

    //刷新当前正在升级的建筑状态！！！
    public static string RefreshCurrBuildingStatus = "L_RefreshCurrBuildingStatus";

    public static string EnterFuBen = "L_EnterFuBen";
    public static string ShowWebQuestionIcon = "L_ShowWebQuestionIcon";

    //PK相关
    public static string OpenPKRuleMain = "L_OpenPKRuleMain";

    public static string OpenPKDeathMain = "L_OpenPKDeathMain";
    public static string NewGuildWarRefresh = "L_NewGuildWarRefresh";
    public static string CloseGuildWarIcon = "L_CloseGuildWarIcon";
    public static string ShowGuildWar = "L_ShowGuildWar";
    public static string ShowOpenPkBtn = "L_ShowOpenPkBtn";
    public static string ChangePkValueGC = "L_ChangePkValueGC";
    public static string ShowPkNotice = "L_ShowPkNotice";

    //监狱相关
    public static string NewHellWarRefresh = "L_NewHellWarRefresh";

    public static string CloseHellWar = "L_CloseHellWar";
    public static string ShowHellWar = "L_ShowHellWar";
    public static string OpenHellWarDeclaration = "L_OpenHellWarDeclaration";

    //挑战
    public static string ShowContestFieldUI = "L_ShowContestFieldUI";

    public static string RequestChallenge = "L_RequestChallenge";
    public static string RefuseChallenge = "L_RefuseChallenge";

    //宣战
    public static string SendDeclarationPlayer = "L_SendDeclarationPlayer";

    //打开发型、发色、头像
    public static string OpenHairdoMain = "L_OpenHairdoMain";

    public static string OpenHairdoColourMain = "L_OpenHairdoColourMain";
    public static string OpenHeadIconMain = "L_OpenHeadIconMain";

    //组队平台
    public static string OpenTeamPlatform = "C_OpenTeamPlatform";
    public static string ServerOpenTeamPlatform = "C_ServerOpenTeamPlatform";

    public static string CloseTeamPlatform = "C_CloseTeamPlatform";
    public static string UpdateTeamPlatform = "C_UpdateTeamPlatform";
    public static string UpdateContentTeam = "C_UpdateContentTeam";

    //相机对于不同坐骑的偏移
    public static string RideForCameraOffset = "L_RideForCameraOffset";

    //变强相关
    public static string ShowStrongPanel = "L_ShowStrongPanel";

    public static string CloseStrongIcon = "L_CloseStrongIcon";
    public static string ShowStrongIcon = "L_ShowStrongIcon";

    //资源找回信息（刷新红点）
    public static string AskResourceInfo = "L_AskResourceInfo";

    //累计充值奖励领取
    public static string RechargeAward = "L_RechargeAward";

    //野外BOSS
    public static string ShowYeWaiBossTargetUI = "L_ShowYeWaiBossTargetUI";

    public static string CloseYeWaiBossTargetUI = "L_CloseYeWaiBossTargetUI";
    public static string UpdateYeWaiBossTargetUI = "L_UpdateYeWaiBossTargetUI";
    public static string RefreshYeWaiBossListItem = "L_RefreshYeWaiBossListItem"; //刷新BOSS数量
    public static string Receive_YeWaiBossBarData = "L_ReceiveYeWaiBossBarData"; //服务端返回的野外BOSS浮动条信息
    public static string Receive_YeWaiBossMapData = "L_ReceiveYeWaiBossMapData"; //服务端返回的野外BOSS地图信息
    public static string UpdateDistrictMapByYeWaiBoss = "L_UpdateDistrictMapByYeWaiBoss"; //更新地图上的野外BOSS信息

    //背包整理
    public static string TidyBag = "L_TidyBag";

    //分享
    public static string SharePhotoFinish = "L_SharePhotoFinish";

    public static string Share4FriendGift = "L_Share4FriendGift";

    public static string SavePhotoFinish = "L_SavePhotoFinish";
    public static string SavePhotoEnd = "L_SavePhotoEnd";
    public static string CaptureScreenShotToTexture2D = "L_CaptureScreenShotToTexture2D";
    public static string CaptureScreenShotToTexture2D4Grace = "L_CaptureScreenShotToTexture2D4Grace";

    //玩家商店
    public static string Midas_ShowLoading = "L_Midas_ShowLoading";

    public static string ShowPlayerShop = "L_ShowPlayerShop";
    public static string ClosePlayerShopIcon = "L_ClosePlayerShopIcon";
    public static string ShowPlayerShopIcon = "L_ShowPlayerShopIcon";

    public static string UploadLog = "L_UploadLog";

    //帮会运镖
    public static string OpenGuildDart = "L_OpenGuildDart"; //打开运镖界面

    public static string CloseGuildDart = "L_CloseGuildDart"; //关闭运镖界面
    public static string UpdateGuildDart = "L_UpdateGuildDart"; //更新运镖界面
    public static string ReceiveDartData = "L_ReceiveDartData"; //接收运镖车数据
    public static string ReceiveDartTime = "L_ReceiveDartTime"; //接收运镖时间
    public static string OpenGuildDartUI = "L_OpenGuildDartUI";
    public static string CloseGuildDartUI = "L_CloseGuildDartUI";
    public static string GuildDartConfirm = "L_GuildDartConfirm";//使用运镖令二次确认


    //服务器列表加载开始事件
    public static string InitServerListStart = "L_InitServerListStart";
    //服务器列表加载结束事件
    public static string InitServerListEnd = "L_InitServerListEnd";
    //新服务器列表加载开始事件
    public static string InitServerListStartNew = "L_InitServerListStart_New";
    //新服务器列表加载结束事件
    public static string InitServerListEndNew = "L_InitServerListEnd_New";
    //通知目录服有错误数据
    public static string NotifyDirServer = "L_NotifyDirServer";

    public static string SeverKick = "L_SeverKick"; //服务器踢人事件
    public static string LCRetCreateChar = "L_LCRetCreateChar"; //全服限制创建角色数量

    //多倍经验相关
    public static string GetExpPoolInfo = "L_GetExpPoolInfo";

    public static string ShowExpPoolInfo = "L_ShowExpPoolInfo";

    //反贼
    public static string Receive_RebelPositionData = "L_ReceiveRebelPositionData";

    //突破
    public static string BreakoutLevel = "L_BreakoutLevel";

    //帮会杀星
    public static string OpenGuildAssassin = "L_OpenGuildAssassin";

    public static string ShaXingInfo = "L_ShaXingInfo";
    public static string ShaXingFriendInfo = "L_ShaXingFriendInfo";

    //等级提升准备扫描
    public static string ScanEquipFromBag = "L_ScanEquipFromBag";

    //帮会修炼
    public static string OpenGuildPractice = "L_OpenGuildPractice";

    //敌对设置
    public static string OpenGuildBattleUI = "L_OpenGuildBattleUI";

    public static string CloseGuildBattleUI = "L_CloseGuildBattleUI";
    public static string UpdateGuildHostileSetting = "L_UpdateGuildHostileSetting";
    public static string RefreshGuildBattleListUI = "L_RefreshGuildBattleListUI";

    //帮会红包
    public static string Guild_ActiveRedPacket = "L_Guild_ActiveRedPacket";

    //第一次进入游戏
    public static string FirstInGame = "L_FirstInGame";

    //转菊花（避免等待时间过长界面无响应）
    public static string ShowWaitLoading = "L_ShowWaitLoading";

    public static string CloseWaitLoading = "L_CloseWaitLoading";

    //游戏社区
    public static string ShowGameTribeIcon = "L_ShowGameTribeIcon";

    public static string CloseGameTribeIcon = "L_CloseGameTribeIcon";

    //累计充值奖励的红点
    public static string UpdateRechargeRedPoint = "L_UpdateRechargeRedPoint";

    //弹出加好友界面
    public static string ShowFriendMessageUI = "L_ShowFriendMessageUI";

    // 序章
    public static string StartIntroduction = "L_StartIntroduction";

    public static string StopIntroduction = "L_StopIntroduction";
    public static string ShowMysticalWeaponUI = "L_ShowMysticalWeaponUI";
    public static string ClickGetMysticalWeaponButton = "L_ClickGetMysticalWeaponButton";

    // 婚姻
    public static string CoupleInfo = "L_CoupleInfo";
    public static string ShowCoupleMainUI = "L_ShowCoupleMainUI";
    public static string ShowCoupleSkillUI = "L_ShowCoupleSkillUI";
    public static string CoupleHallListInfo = "L_CoupleHallListInfo";
    public static string ConfirmEnterCoupleHall = "L_ConfirmEnterCoupleHall";
    public static string CoupleFireWorks = "L_CoupleFireWorks";
    public static string CoupleGotoOrGetUpBed = "L_CoupleGotoOrGetUpBed";
    public static string MainPlayerCanMove = "L_MainPlayerCanMove";
    public static string CouplePromptForThanks = "L_CouplePromptForThanks";

    public static string OnlineFriendListReturn = "L_OnlineFriendListReturn";
    public static string ReturnSingleOnlineResult = "L_ReturnSingleOnlineResult";
    //平台好友
    public static string ShowPlatformFriendsUI = "L_ShowPlatformFriendsUI";
    public static string FinishCombinePlatformGameData = "L_FinishCombinePlatformGameData";
    public static string GetPlatformFriendsData = "L_GetPlatformFriendsData";

    //Apple
    public static string IssueShortcut = "L_IssueShortcut";

    public static string IssueBroadcast = "L_IssueBroadcast";
    public static string RequestBroadcast = "L_RequestBroadcast";
    public static string UpdateYueKaRedPoint = "L_UpdateYueKaRedPoint";

    //玩家商店
    public static string CloseLoadingUI_PlayerShop = "L_CloseLoadingUI_PlayerShop";

    //七日
    public static string RefreshSevenDay = "L_RefreshSevenDay";

    public static string ShowWXGameCenterUI = "L_ShowWXGameCenterUI";
    public static string ShowQQGameCenterUI = "L_ShowQQGameCenterUI";

    public static string ServerTokenNull = "L_ServerTokenNull";

    //测试事件
    public static string DebugHuaShanSword = "C_DebugHuaShanSword";

    //点击视频事件
    public static string OpenPlayMovie = "L_OpenPlayMovie";

    public static string BroadCastChangedName = "L_BroadCastChangedName";
    //刷新
    public static string UpdateSuperTitle = "C_UpdateSuperTitle";

    public static string ShowGuildAppointTip = "L_ShowGuildAppointTip";

    public static string ShowQuackExpUI = "L_ShowQuackExpUI";

    public static string MsdkNotice = "L_MsdkNotice";

    public static string ShowGuildBonusUI = "L_ShowGuildBonusUI";
    //意见反馈
    public static string ShowFeedbackIcon = "L_ShowFeedbackIcon";
    public static string ShowFeedback = "L_ShowFeedback";

    //企鹅电竞
    public static string TencentESport = "L_TencentESport";

    public static string ShowIDIPMessage = "L_ShowIDIPMessage";

    public static string OpenIOSReviewSwitch = "L_OpenIOSReviewSwitch";

    public static string OpenGuildGroupSwitch = "L_OpenGuildGroupSwitch";

    //闹洞房钱提示
    public static string CouplePromptOnBedByMoney = "L_CouplePromptOnBedByMoney";

    //五星评价
    public static string OpenReview = "L_iOS_OpenReview";

    // Lua 崩溃测试事件，正常是不会调用到的
    public static string LuaCrashTest = "L_LuaCrashTest";

    public static string CloseFaceActionUI = "L_CloseFaceActionUI";
    public static string ShowFaceActionMessage = "L_ShowFaceActionMessage";
    public static string ShowFaceActiontSuccess = "L_ShowFaceActiontSuccess";

    public static string BeginSimulator = "L_BeginSimulator";

    // 群组
    public static string OpenRelationGroupApplyListUI = "L_OpenRelationGroupApplyListUI";
    public static string OpenGroupCreateAndAlterUI = "L_OpenGroupCreateAndAlterUI";
    public static string OpenGroupMemberInfoUI = "L_OpenGroupMemberInfoUI";
    public static string OpenGroupMemberListUI = "L_OpenGroupMemberListUI";
    public static string OpenGroupInviteUI = "L_OpenGroupInviteUI";
    public static string OpenGroupInquiryUI = "L_OpenGroupInquiryUI";
    public static string RequestAllGroupListReturn = "L_RequestAllGroupListReturn";
    public static string AddRelationGroupReturn = "L_AddRelationGroupReturn";
    public static string DelRelationGroupReturn = "L_DelRelationGroupReturn";
    public static string RefreshRelationGroupInfoReturn = "L_RefreshRelationGroupInfoReturn";
    public static string RefreshRelationGroupNameReturn = "L_RefreshRelationGroupNameReturn";
    public static string RefreshRelationGroupNoticeReturn = "L_RefreshRelationGroupNoticeReturn";
    public static string RelationGroupUserApply = "L_RelationGroupUserApply";
    public static string RelationGroupUserJoined = "L_RelationGroupUserJoined";
    public static string RelationGroupUserQuit = "L_RelationGroupUserQuit";
    public static string RelationGroupUserKicked = "L_RelationGroupUserKicked";
    public static string RelationGroupUserDataChanged = "L_RelationGroupUserDataChanged";
    public static string DelGroupUserApply = "L_DelGroupUserApply";
    public static string FindRelationGroupReturn = "L_FindRelationGroupReturn";
    public static string DelRelationRecenterData = "L_DelRelationRecenterData";
    public static string RelationGroupUserInvite = "L_RelationGroupUserInvite";
    public static string TeamRaidRedPoint = "L_TeamRaidRedPoint";
    public static string BWTRoopRedPoint = "L_BWTRoopRedPoint";

    // 珍兽仓库
    public static string PetDepotOperationReturn = "L_PetDepotOperationReturn";
    public static string AddPetData = "L_AddPetData";

    //子女仓库
    public static string AddChildrenData = "L_AddChildrenData";
    public static string ChildrenDetailArrival = "L_ChildrenDetailArrival";
    //机器过热提示
    public static string ShowChatMessageUI_hot = "L_ShowChatMessageUI_hot";
    //更新好友备注
    public static string RefreshRelationRemark = "L_RefreshRelationRemark";

    public static string HttpPostResponseMsg = "L_HttpPostResponseMsg";
    public static string HttpGetResponseMsg = "L_HttpPGetResponseMsg";

    public static string UpdateMainPlayerHeadIconBg_CSharp = "L_UpdateMainPlayerHeadIconBg_CSharp";
    public static string UpdateOtherPlayerHeadIconBg = "L_UpdateOtherPlayerHeadIconBg";

    public static string UpdateMainPlayerHasChongLouYu = "L_UpdateMainPlayerHasChongLouYu";
    public static string UpdateOtherPlayerHasChongLouYu = "L_UpdateOtherPlayerHasChongLouYu";

    //爱的祝福相关
    public static string LoveValueUpdate = "L_LoveValueUpdate";
    public static string LoveBlessLevelUpdate = "L_LoveBlessLevelUpdate";

    public static string ReRequireLua = "L_ReRequireLua";
    public static string ReLoadLua = "L_ReLoadLua";
    public static string ReLoadLua2 = "L_ReLoadLua2";
    public static string AddTeamOrWarGroup = "L_AddTeamOrWarGroup";
    // 实时语音
    public static string RealTimeEnterRoomComplete = "L_RealTimeEnterRoomComplete";
    public static string RealTimeLeaveRoomComplete = "L_RealTimeLeaveRoomComplete";
    public static string RealTimeEnterRoomFailed = "L_RealTimeEnterRoomFailed";
    public static string RealTimeLeaveRoomFailed = "L_RealTimeLeaveRoomFailed";
    public static string ChangeRealTimeRoleComplete = "L_ChangeRealTimeRoleComplete";
    public static string NeedEnterRealTime = "L_NeedEnterRealTime";
    public static string JoinRealTimeRoom = "L_JoinRealTimeRoom";
    public static string GVoiceEnginPauseLeaveRealTime = "L_GVoiceEnginPauseLeaveRealTime";

    public static string QuitRealTimeRoom = "L_QuitRealTimeRoom";
    public static string MemberVoiceStateChange = "L_MemberVoiceStateChange";
    public static string InfoMicPosMember = "L_InfoMicPosMember";

    public static string ShowGuideSkipUI = "L_ShowGuideSkipUI";
    public static string ServerSysnQiYu = "L_ServerSysnQiYu";

    public static string SingleFriendClassChanged = "L_SingleFriendClassChanged";

    public static string SwitchJuXianKeZhanLinks = "L_SwitchJuXianKeZhanLinks";

    public static string SetRangeRadiusData = "L_SetRangeRadiusData";

    //public static string OpenHomeMedicinalUI = "L_OpenHomeMedicinalUI"; //打开炼药界面 

    public static string OpenFYPTPanel = "L_OpenFYPTPanel";
    public static string ControlCanPinch = "L_ControlCanPinch";
    public static string ControlDestroyUITexture = "L_ControlDestroyUITexture";
    public static string RefreshTServerData = "L_RefreshTServerData";

    public static string ShowBuffEffect = "C_ShowBuffEffect";
    public static string HideBuffEffect = "C_HideBuffEffect";
    public static string AddBuff = "C_AddBuff";

    

    public static string ShowBabyFashionDyeing = "C_ShowBabyFashionDyeing";

    public static string TweenEndCallBack = "L_TweenEndCallBack";
    public static string OpenTargetPanel = "L_OpenTargetPanel";

    public static string HideCompositeFunction = "L_HideCompositeFunction";

    public static string ShowSimpleTip = "L_ShowSimpleTip";
    public static string HideSimpleTip = "L_HideSimpleTip";

    public static string OnCollisionEnter = "L_OnCollisionEnter";
    public static string OnCollisionEnter2D = "L_OnCollisionEnter2D";

    public static string ChangeThemeStyle = "L_ChangeThemeStyle";
    public static string GetDownMount = "C_GetDownMount";
    public static string WebPictureEnd = "L_WebPictureEnd";

    public static string PermissionDenied = "L_PermissionDenied";

    public static string ShowQTEEffect = "L_ShowQTEEffect";
    public static string ShowSkillQTE = "L_ShowSkillQTE";
    public static string StopToyInteract = "C_StopToyInteract";

    public static string OnInteractStart = "L_OnInteractStart";
    public static string OnInteractEnd = "L_OnInteractEnd";

    // 轻功
    public static string FlyBtnUpdate = "L_FlyBtnUpdate";       // 更新轻功按钮状态
    public static string StartFly = "L_StartFly";               // 开始使用轻功
    public static string StopFly = "L_StopFly";                 // 轻功使用结束

    public static string SwitchLightmapGroup = "C_SwitchLightmapGroup";
    public static string SetGoodsListNum = "L_SetGoodsListNum";
#if TLBB_WEBGL
    public static string SequenceBegin = "L_SequenceBegin";
#endif
}
