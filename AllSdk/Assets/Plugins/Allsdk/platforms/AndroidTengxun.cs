using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace allSdk
{
    using System.Security.Cryptography;

    /// <summary>
    /// author chenshuai
    /// $Id$
    /// Create time:2014/10/8 17:05:42 
    /// </summary>
    ///
    public class AndroidTengxun:IPlatform
    {
        private string qqAppId;
        private string qqAppKey;
        private string wxAppId;
        private string wxAppKey;
        private string offerId;
        private string evn;
        private bool isCheckUpdate;

        private string loginType;

        private string zoneId;
        private string acctType;
        private string saveValue;
        private bool isCanChange;
        private int gameCoinResId;

        private int noticeType;
        private string scenceId;

        private int scenceType;
        private String title;
        private String desc;
        private String url;
        private String imgUrl;
        private int mediaTag;
        private byte[] thumbImgData;
        private String messageExt;

        /// <summary>
        /// 设置初始化参数
        /// </summary>
        /// <param name="qqAppId"></param>
        /// <param name="qqAppKey"></param>
        /// <param name="wxAppId"></param>
        /// <param name="wxAppKey"></param>
        /// <param name="offerId"></param>
        /// <param name="evn">支付环境配置 正式：release 测试：test</param>
        /// <param name="isCheckUpdate">是否判断当前是否有更新</param>
        public void setInitParameter(string qqAppId, string qqAppKey, string wxAppId, 
            string wxAppKey, string offerId, string evn, bool isCheckUpdate)
        {
            this.qqAppId = qqAppId;
            this.qqAppKey = qqAppKey;
            this.wxAppId = wxAppId;
            this.wxAppKey = wxAppKey;
            this.offerId = offerId;
            this.evn = evn;
            this.isCheckUpdate = isCheckUpdate;
        }

        /// <summary>
        /// 设置登录参数
        /// </summary>
        /// <param name="loginType">登录类型 1：qq登录 2.微信登录</param>
        public void setLoginParameter(string loginType)
        {
            this.loginType = loginType;
        }

        /// <summary>
        /// 设置支付参数
        /// </summary>
        /// <param name="zoneId">游戏服务器大区id 游戏不分大区则默认zoneId =“1”</param>
        /// <param name="acctType">账户类型，1.基础货币 2.安全货币，默认为基础货币 </param>
        /// <param name="saveValue">用户充值数量，即游戏币的个数</param>
        /// <param name="isCanChange">充值数额是否可改 true：可改； false：不可改。目前只支持可改</param>
        /// <param name="gameCoinResId">购买游戏币图标id, 图标像素要求：48*48</param>
        public void setPayParameter(string zoneId, string acctType, string saveValue, bool isCanChange, int gameCoinResId)
        {
            this.zoneId = zoneId;
            this.acctType = acctType;
            this.saveValue = saveValue;
            this.isCanChange = isCanChange;
            this.gameCoinResId = gameCoinResId;
        }

        /// <summary>
        /// 设置显示公告参数
        /// </summary>
        /// <param name="noticeType">公告类型 0：弹出公告、滚动公告 1：弹出公告 2：滚动公告</param>
        /// <param name="scenceId"></param>
        public void setShowNoticeParameter(int noticeType, string scenceId)
        {
            this.noticeType = noticeType;
            this.scenceId = scenceId;
        }

        /// <summary>
        /// 分享结构化信息到qq
        /// </summary>
        /// <param name="scenceType">标识发送手Q会话或者Qzone 
        ///                         1：	eQQScene.QQScene_QZone: 分享到空间(4.5以上版本支持)
        ///                         2：	eQQScene.QQScene_Session: 分享到手Q会话</param>
        /// <param name="title">结构化消息的标题</param>
        /// <param name="desc">结构化消息的概要信息</param>
        /// <param name="url">内容的跳转url，填游戏对应游戏中心详情页，游戏被分享消息拉起时, MSDK会给游戏OnWakeup(WakeupRet& wr)回调, wr.extInfo中会以key-value的方式带回所有的自定义参数.</param>
        /// <param name="imgUrl">分享消息说略图URL</param>
        public void setSendToQQParameter(int scenceType, String title, String desc, String url, String imgUrl)
        {
            this.scenceType = scenceType;
            this.title = title;
            this.desc = desc;
            this.url = url;
            this.imgUrl = imgUrl;
        }

        /// <summary>
        /// 分享结构化信息到微信
        /// </summary>
        /// <param name="title">title	结构化消息的标题（注意：限制长度不超过512Bytes）</param>
        /// <param name="desc">结构化消息的概要信息（注意：限制长度不超过1KB）</param>
        /// <param name="mediaTag">请根据实际情况填入下列值的一个, 此值会传到微信供统计用, 在分享返回时也会带回此值, 可以用于区分分享来源
        ///                         0：	"MSG_INVITE";                   // 邀请
        ///                         1：	"MSG_SHARE_MOMENT_HIGH_SCORE";    //分享本周最高到朋友圈
	    ///			                2：	"MSG_SHARE_MOMENT_BEST_SCORE";    //分享历史最高到朋友圈
	    /// 				        3：	"MSG_SHARE_MOMENT_CROWN";         //分享金冠到朋友圈
	    /// 				        4：	"MSG_SHARE_FRIEND_HIGH_SCORE";     //分享本周最高给好友
	    /// 				        5：	"MSG_SHARE_FRIEND_BEST_SCORE";     //分享历史最高给好友
	    /// 				        6：	"MSG_SHARE_FRIEND_CROWN";          //分享金冠给好友
	    /// 				        7：	"MSG_friend_exceed"         // 超越炫耀
        /// 				        8：	"MSG_heart_send"            // 送心</param>
        /// <param name="thumbImgData">结构化消息的缩略图 （注意：限制内容大小不超过32KB）</param>
        /// <param name="messageExt">游戏分享是传入字符串，通过此消息拉起游戏会通过 OnWakeUpNotify(WakeupRet ret)中ret.messageExt回传给游戏</param>
        public void setSendToWeixinParameter(String title, String desc, int mediaTag, byte[] thumbImgData, String messageExt)
        {
            this.title = title;
            this.desc = desc;
            this.mediaTag = mediaTag;
            this.thumbImgData = thumbImgData;
            this.messageExt = messageExt;
        }

        /// <summary>
        /// 平台类型
        /// </summary>
        public string type { get { return PlatformNameEnum.ANDROID_TENGXUN.ToString(); }}

        /// <summary>
        /// 是否支持初始化操作
        /// </summary>
        public bool isSupportInit { get { return true; } }

        /// <summary>
        /// 是否支持登出
        /// </summary>
        public bool isSupportLogout { get { return false; } }

        /// <summary>
        /// 是否支持打开用户中心
        /// </summary>
        public bool isSupportUserCenter { get { return false; } }

        /// <summary>
        /// 是否支持打开悬浮按钮
        /// </summary>
        public bool isSupportShowToolbar { get { return true; } }

        /// <summary>
        /// 是否支持隐藏悬浮按钮
        /// </summary>
        public bool isSupportHideToolbar { get { return true; } }

        /// <summary>
        /// 是否支持退出操作
        /// </summary>
        public bool isSupportQuit { get { return false; } }

        /// <summary>
        /// 是否支持向sdk发送信息、统计信息等
        /// </summary>
        public bool isSupportSendMessageToSdk { get { return false; } }

        /// <summary>
        /// 是否支持防沉迷查询
        /// </summary>
        public bool isSupportAntiAddictionQuery { get { return false; } }

        /// <summary>
        /// 是否支持实名制注册
        /// </summary>
        public bool isSupportRealNameRegister { get { return false; } }

        /// <summary>
        /// 初始化
        /// </summary>
        public void init()
        {
            object[] parameter = new object[] { qqAppId, qqAppKey,wxAppId,wxAppKey,offerId,evn,isCheckUpdate };
            AllSdkPlatform.instance().callAndroidSdkFunction(SDKFunctionNameEnum.init.ToString(), parameter);
        }

        /// <summary>
        /// 登录
        /// </summary>
        public void login()
        {
            object[] parameter = new object[] { loginType};
            AllSdkPlatform.instance().callAndroidSdkFunction(SDKFunctionNameEnum.login.ToString(),parameter);
        }

        /// <summary>
        /// 支付
        /// </summary>
        public void pay()
        {
            object[] parameter = new object[] { zoneId,acctType,saveValue,isCanChange,gameCoinResId };
            AllSdkPlatform.instance().callAndroidSdkFunction(SDKFunctionNameEnum.pay.ToString(), parameter);
        }

        /// <summary>
        /// 登出
        /// </summary>
        public void logout()
        {
            
        }

        /// <summary>
        /// 打开用户中心
        /// </summary>
        public void userCenter()
        {
            
        }

        /// <summary>
        /// 显示悬浮菜单
        /// </summary>
        public void showToolBar()
        {
            if (isSupportShowToolbar)
                AllSdkPlatform.instance().callAndroidSdkFunction(SDKFunctionNameEnum.showToolBar.ToString());
        }

        /// <summary>
        /// 隐藏悬浮菜单
        /// </summary>
        public void hideToolBar()
        {
            if (isSupportHideToolbar)
                AllSdkPlatform.instance().callAndroidSdkFunction(SDKFunctionNameEnum.hideToolBar.ToString());
        }

        /// <summary>
        /// 退出游戏
        /// </summary>
        public void quit()
        {
            
        }

        /// <summary>
        ///向sdk发送消息
        /// </summary>
        public void sendMessageToSDK()
        {
            
        }

        /// <summary>
        /// 防沉迷查询
        /// </summary>
        public void antiAddictionQuery()
        {
            
        }

        /// <summary>
        /// 实名制注册
        /// </summary>
        public void realNameRegister()
        {
            
        }

        /// <summary>
        /// 判断是否需要更新
        /// </summary>
        public void checkNeedUpdate()
        {
            AllSdkPlatform.instance().callAndroidSdkFunction(SDKFunctionNameEnum.checkNeedUpdate.ToString());
        }

        /// <summary>
        /// 开始省流量更新
        /// </summary>
        public void startSaveUpdate()
        {
            AllSdkPlatform.instance().callAndroidSdkFunction(SDKFunctionNameEnum.startSaveUpdate.ToString());
        }

        /// <summary>
        /// 开始普通更新
        /// </summary>
        public void startCommonUpdate()
        {
            AllSdkPlatform.instance().callAndroidSdkFunction(SDKFunctionNameEnum.startCommonUpdate.ToString());
        }

        /// <summary>
        /// 显示公告
        /// </summary>
        public void showNotice()
        {
            object[] parameter = new object[] { noticeType,scenceId };
            AllSdkPlatform.instance().callAndroidSdkFunction(SDKFunctionNameEnum.showNotice.ToString(), parameter);
        }

        /// <summary>
        /// 隐藏公告
        /// </summary>
        public void hideScrollNotice()
        {
            AllSdkPlatform.instance().callAndroidSdkFunction(SDKFunctionNameEnum.hideScrollNotice.ToString());
        }

        /// <summary>
        /// 查询qq同玩好友信息
        /// </summary>
        public void queryQQGameFriendsInfo()
        {
            AllSdkPlatform.instance().callAndroidSdkFunction(SDKFunctionNameEnum.queryQQGameFriendsInfo.ToString());
        }

        /// <summary>
        /// 查询微信同玩好友信息
        /// </summary>
        public void queryWXGameFriendsInfo()
        {
            AllSdkPlatform.instance().callAndroidSdkFunction(SDKFunctionNameEnum.queryWXGameFriendsInfo.ToString());
        }

        /// <summary>
        /// 发送结构化消息到qq
        /// </summary>
        public void sendToQQ()
        {
            object[] parameter = new object[] { scenceType,title,desc,url,imgUrl };
            AllSdkPlatform.instance().callAndroidSdkFunction(SDKFunctionNameEnum.sendToQQ.ToString(), parameter);
        }

        /// <summary>
        /// 发送结构化消息到微信
        /// </summary>
        public void sendToWeixin()
        {
            object[] parameter = new object[] { title,desc,mediaTag,thumbImgData,messageExt };
            AllSdkPlatform.instance().callAndroidSdkFunction(SDKFunctionNameEnum.sendToWeiXin.ToString(), parameter);
        }
    }
}
