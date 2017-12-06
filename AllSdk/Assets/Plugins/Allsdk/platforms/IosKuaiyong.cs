using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace allSdk
{
    /// <summary>
    /// author chenshuai
    /// $Id$
    /// Create time:2014/7/22 17:58:31 
    /// </summary>
    ///
    public class IosKuaiyong:IPlatform
    {
        private string appKey;

        private string dealseq;
        private string fee;
        private string payId;
        private string gamesvr;
		private string gameusersvr;
        private string subject;


        /// <summary>
        /// 设置初始化参数
        /// </summary>
        /// <param name="appKey"></param>
        public void setInitParameter(string appKey)
        {
            this.appKey = appKey;
        }

        /// <summary>
        /// 设置支付参数
        /// </summary>
        /// <param name="dealseq">游戏产生的订单号</param>
        /// <param name="fee">订单金额，单位：元</param>
        /// <param name="payId">7659支付系统给此游戏应用分配 的游戏id</param>
        /// <param name="gamesvr">游戏区服，如果没有特殊的需求，可填""</param>
		/// <param name="gameusersvr">游戏区服名称，不能为空</param>
		/// <param name="subject">购买产品的名称,如:100元宝</param>
        public void setPayParameter(string dealseq, string fee, string payId, string gamesvr,string gameusersvr,
		                            string subject)
        {
            this.dealseq = dealseq;
            this.fee = fee;
            this.payId = payId;
            this.gamesvr = gamesvr;
			this.gameusersvr = gameusersvr;
            this.subject = subject;
        }
        
        /// <summary>
        /// 平台类型
        /// </summary>
        public string type { get { return PlatformNameEnum.IOS_KUAIYONG.ToString(); } }

        /// <summary>
        /// 是否支持初始化操作
        /// </summary>
        public bool isSupportInit { get { return true; } }

        /// <summary>
        /// 是否支持登出
        /// </summary>
        public bool isSupportLogout { get { return true; } }

        /// <summary>
        /// 是否支持打开用户中心
        /// </summary>
        public bool isSupportUserCenter { get { return true; } }

        /// <summary>
        /// 是否支持打开悬浮按钮
        /// </summary>
        public bool isSupportShowToolbar { get { return false; } }

        /// <summary>
        /// 是否支持隐藏悬浮按钮
        /// </summary>
        public bool isSupportHideToolbar { get { return false; } }

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
        public bool isSupportAntiAddictionQuery { get{return false;} }

        /// <summary>
        /// 是否支持实名制注册
        /// </summary>
        public bool isSupportRealNameRegister { get{return false;} }

        /// <summary>
        /// 初始化
        /// </summary>
        public void init()
        {
#if UNITY_IPHONE
            if (!isSupportInit)
                return;

            AllSdkPlatform.sdkInit(appKey);
#endif
        }

        /// <summary>
        /// 登录
        /// </summary>
        public void login()
        {
#if UNITY_IPHONE
            AllSdkPlatform.sdkLogin();
#endif

        }

        /// <summary>
        /// 支付
        /// </summary>
        public void pay()
        {
#if UNITY_IPHONE
			string parameter = dealseq + "," + fee + "," + payId + "," + gamesvr +"," + gameusersvr + "," + subject;
            AllSdkPlatform.sdkPay(parameter);
#endif

        }

        /// <summary>
        /// 登出
        /// </summary>
        public void logout()
        {
#if UNITY_IPHONE
            if (!isSupportLogout)
                return;

            AllSdkPlatform.sdkLogout();
#endif

        }

        /// <summary>
        /// 打开用户中心
        /// </summary>
        public void userCenter()
        {
#if UNITY_IPHONE
            if (!isSupportUserCenter)
                return;

            AllSdkPlatform.sdkUserCenter();
#endif

        }

        /// <summary>
        /// 显示悬浮菜单
        /// </summary>
        public void showToolBar()
        {
#if UNITY_IPHONE
            if (!isSupportShowToolbar)
                return;
#endif

        }

        /// <summary>
        /// 隐藏悬浮菜单
        /// </summary>
        public void hideToolBar()
        {
#if UNITY_IPHONE
            if (!isSupportHideToolbar)
                return;
#endif

        }

        /// <summary>
        /// 退出游戏
        /// </summary>
        public void quit()
        {
#if UNITY_IPHONE
            if (!isSupportQuit)
                return;
#endif
        }

        /// <summary>
        ///向sdk发送消息
        /// </summary>
        public void sendMessageToSDK()
        {
#if UNITY_IPHONE
            if (!isSupportSendMessageToSdk)
                return;
#endif

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
            
        }

        /// <summary>
        /// 开始省流量更新
        /// </summary>
        public void startSaveUpdate()
        {
            
        }

        /// <summary>
        /// 开始普通更新
        /// </summary>
        public void startCommonUpdate()
        {
            
        }
    }
}
