using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace allSdk
{
    /// <summary>
    /// author chenshuai
    /// $Id$
    /// Create time:2014/8/13 15:59:19 
    /// </summary>
    ///
    public class IosHaima:IPlatform
    {
        private string appId;

		private string orderId;
		private string productName;
		private string gameName;
		private string productPrice;
		private string userParams;

        /// <summary>
        /// 设置初始化参数
        /// </summary>
        /// <param name="appId"></param>
        public void setInitParameter(string appId)
        {
            this.appId = appId;
        }

        /// <summary>
        /// 设置支付参数
        /// </summary>
		/// <param name="orderId">商户系统中商品的订单号 1. 必选不能为空，长度 < 50 字节 2.字段中不能有 ‘&’ 或 ‘=’ 字符 3.订单号必须唯一</param>
		/// <param name="productName">名称不可为空</param>
		/// <param name="gameName">游戏名,不可为空</param>
		/// <param name="productPrice">人民币：元(double)</param>
		/// <param name="userParams">用户自定义参数，服务器异步通知时会原样回传</param>
		public void setPayParameter(string orderId, string productName, string gameName, string productPrice,
		                            string userParams)
        {
			this.orderId = orderId;
			this.productName = productName;
			this.gameName = gameName;
			this.productPrice = productPrice;
			this.userParams = userParams;
        }

        /// <summary>
        /// 平台类型
        /// </summary>
        public string type { get { return PlatformNameEnum.IOS_HAIMA.ToString(); } }

        /// <summary>
        /// 是否支持初始化操作
        /// </summary>
        public bool isSupportInit { get{return true;} }

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
        public bool isSupportAntiAddictionQuery { get { return false; } }

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
            string parameter = appId;
            AllSdkPlatform.sdkInit(parameter);
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
			string parameter = orderId + "," + productName+","+gameName+","+productPrice+","+userParams;
			AllSdkPlatform.sdkPay (parameter);
#endif
        }

        /// <summary>
        /// 登出
        /// </summary>
        public void logout()
        {
#if UNITY_IPHONE
			AllSdkPlatform.sdkLogout();
#endif
        }

        /// <summary>
        /// 打开用户中心
        /// </summary>
        public void userCenter()
        {
			#if UNITY_IPHONE
			AllSdkPlatform.sdkUserCenter();
			#endif
        }

        /// <summary>
        /// 显示悬浮菜单
        /// </summary>
        public void showToolBar()
        {
            
        }

        /// <summary>
        /// 隐藏悬浮菜单
        /// </summary>
        public void hideToolBar()
        {
            
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
