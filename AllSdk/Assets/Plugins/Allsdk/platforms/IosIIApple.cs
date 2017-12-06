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
    public class IosIIApple:IPlatform
    {
        private string appKey;
		private string channelId;
		private string isVer;
		private string isShowATView;
		private string cuKey;
		private string isRepeatPay;
		private string isLastXcode6;

		private string amount;
		private string productName;
		private string extInfo;

 
 
		/// <summary>
		/// 设置初始化参数
		/// </summary>
		/// <param name="appKey">App key.运营提供</param>
		/// <param name="channelId">渠道号，问运营</param>
        /// <param name="isVer">"0":横版游戏, "1":竖版游戏.</param>
		/// <param name="isShowATView">悬浮按钮显示开关，"0"：隐藏，“1”：显示</param>
		/// <param name="cuKey">由运营人员提供</param>
		/// <param name="isRepeatPay">开启，支付成功后跳回支付宝，关闭则跳回游戏;“0”：否，“1”：是<</param>
        /// <param name="isLastXcode6">Xcode版本是否大于等于6.“0”：否，“1”：是</param>
		public void setInitParameter(string appKey, string channelId, string isVer, string isShowATView, string cuKey, string isRepeatPay, string isLastXcode6)
        {
			this.appKey = appKey;
			this.channelId = channelId;
			this.isVer = isVer;
			this.isShowATView = isShowATView;
			this.cuKey = cuKey;
			this.isRepeatPay = isRepeatPay;
			this.isLastXcode6 = isLastXcode6;
        }


		/// <summary>
		/// 设置支付参数
		/// </summary>
		/// <param name="amount">金额.</param>
		/// <param name="productName">产品名称</param>
		/// <param name="extInfo">透传信息，原样返回服务端</param>
		public void setPayParameter(string amount, string productName, string extInfo)
        {
			this.amount = amount;
			this.productName = productName;
			this.extInfo = extInfo;
        }

        /// <summary>
        /// 平台类型
        /// </summary>
		public string type { get{return PlatformNameEnum.IOS_IIAPPLE.ToString();} }
			
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

			string parameter = appKey + "," + channelId + "," + isVer + "," + isShowATView + "," + cuKey+ "," + isRepeatPay + "," + isLastXcode6;
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
			string parameter = amount + "," + productName + "," + extInfo;
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
