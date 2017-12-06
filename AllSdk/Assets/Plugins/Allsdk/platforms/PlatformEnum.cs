using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace allSdk
{
    /// <summary>
    /// author chenshuai
    /// $Id$
    /// Create time:2014/7/8 11:22:44 
    /// </summary>
    ///
    public enum PlatformNameEnum
    {
        DEFLUAT,                    //默认
        ANDROID_FEILIU,             //android 飞流
        ANDROID_WANDOUJIA,          //android 豌豆荚
        ANDROID_91,                 //android 91
        ANDROID_XIAOMI,             //android 小米
        IOS_FEILIU,                  //ios 飞流
		IOS_ITOOLS,					//ios itools
		IOS_DOWNJOY,					//ios downjoy
        IOS_PPHELPER,               //ios pp助手
        IOS_TONGBUTUI,              //ios 同步推
        IOS_KUAIYONG,               //ios 快用
        ANDROID_DUOKU,              //android 多酷
        ANDRID_UC,                  //android uc
        ANDROID_DOWNJOY,            //android 当乐
        ANDROID_ANZHI,               //android 安智
        ANDROID_LENOVO,              //android 联想
        ANDROID_360,                 //android 360
		ANDROID_YK,                  //android 优酷
        ANDROID_CHONGCHONG,          //android 虫虫
        ANDROID_Qxz,
        ANDROID_Guopan,
        IOS_HAIMA,                   //ios 海马
        IOS_AISI,                    //ios 爱思
        IOS_91,                    //ios 91
        ANDROID_OPPO,                //android oppo(可可游戏中心)
        ANDROID_HUAWEI,              //android 华为
        ANDROID_TENGXUN,             //android 腾讯
		IOS_XY,						// IOS XY
		IOS_TJ,                      //IOS TIANJI
		IOS_IIAPPLE,                  //IOS  IIAPPLE
		IOS_XX,
		IOS_YUNDING                   //IOS yunding
    }

    /// <summary>
    /// sdk 方法枚举，对应sdk内方法名
    /// </summary>
    public enum SDKFunctionNameEnum
    {
        init,           //初始化
        login,          //登录
        pay,            //支付
        logout,         //登出
        userCenter,     //打开用户中心
        showToolBar,   //显示浮动菜单
        hideToolBar,   //隐藏浮动菜单
        quit,            //退出
		sendMessageToSDK,	//向sdk发送消息
        antiAddictionQuery, //防沉迷查询(360)
        realNameRegister,    //实名制注册（360）
        checkNeedUpdate,    //判断是否需要更新(tencent)
        startSaveUpdate,    //开始省流量更新(tencent)
        startCommonUpdate,   //开始普通更新(tencent)
        showNotice,          //显示公告(tencent)
        hideScrollNotice,       //隐藏滚动公告(tencent)
        sendToQQ,               //分享结构化消息到qq(tencent)
        sendToWeiXin,            //分享结构化消息到微信(tencent)
        queryQQGameFriendsInfo, //查询qq同玩好友信息（tecent）
        queryWXGameFriendsInfo  //查询微信同玩好友信息（tencent）
    }
}
