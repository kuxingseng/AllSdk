using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace allSdk
{
    /// <summary>
    /// author chenshuai
    /// $Id$
    /// Create time:2014/7/21 16:06:58 
    /// </summary>
    ///
    public class IosItools:IPlatform
    {
        private string appId;
        private string appKey;
		private bool isSupportOrientationPortrait;
		private bool isSupportPortraitUpsideDown;
		private bool isSupportLandscapeLeft;
		private bool isSupportLandscapeRight;
      

		private string productName;
        private string amount;
        private string orderId;

        /// <summary>
        /// 设置初始化参数
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="appKey"></param>
        /// <param name="orientation">设置支持的方向:1.OrientationPortrait 2.portraitUpsideDown 3.landscapeLeft 4.landscapeRight</param>
        
		public void setInitParameter(string appId, string appKey, bool isSupportOrientationPortrait,bool isSupportPortraitUpsideDown,bool isSupportLandscapeLeft,bool isSupportLandscapeRight)
        {
            this.appId = appId;
            this.appKey = appKey;
			this.isSupportOrientationPortrait = isSupportOrientationPortrait;
			this.isSupportPortraitUpsideDown = isSupportPortraitUpsideDown;
			this.isSupportLandscapeLeft = isSupportLandscapeLeft;
			this.isSupportLandscapeRight = isSupportLandscapeRight;
        }

        /// <summary>
		////设置支付参数
        /// </summary>
        /// <param name="productName">Product name.</param>
        /// <param name="amount">Amount.</param>
        /// <param name="orderId">Order identifier.</param>
        public void setPayParameter(string productName, string amount, string orderId)
        {
			this.productName = productName;
            this.amount = amount;
            this.orderId = orderId;
        }

        /// <summary>
        /// 平台类型
        /// </summary>
		public string type { get{return PlatformNameEnum.IOS_ITOOLS.ToString();} }
			
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
        /// Gets a value indicating whether this <see cref="allSdk.IPlatform"/> is support send message to sdk.
        /// </summary>
        /// <value><c>true</c> if is support send message to sdk; otherwise, <c>false</c>.</value>
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
			if(!isSupportInit)
				return;

			string parameter = appId + "," + appKey + "," + isSupportOrientationPortrait + "," + isSupportPortraitUpsideDown + "," + isSupportLandscapeLeft+ "," + isSupportLandscapeRight;
			AllSdkPlatform.sdkInit (parameter);
#endif
        }

        /// <summary>
        /// 登录
        /// </summary>
        public void login()
        {
#if UNITY_IPHONE
			AllSdkPlatform.sdkLogin ();
#endif
        }

        /// <summary>
        /// 支付
        /// </summary>
        public void pay()
        {
#if UNITY_IPHONE
			string parameter = productName + "," + amount + "," + orderId;
			AllSdkPlatform.sdkPay (parameter);
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
			if(!isSupportShowToolbar)
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
        ///send message to sdk.
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
