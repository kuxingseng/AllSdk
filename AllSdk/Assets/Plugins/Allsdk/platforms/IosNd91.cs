using UnityEngine;
using System.Collections;

namespace allSdk
{
    public class IosNd91 : IPlatform
    {
        private string appId;
        private string appKey;
		private int    orientation;

        private string cooOrderSerial;
        private string productId;
        private string productName;
        private string productPrice;
        private string productOrignalPrice;
        private string productCount;
        private string payDescription;
       

        /// <summary>
        /// 设置初始化参数
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="appKey"></param>
		/// <param name="orientation">设置支持的方向:1.OrientationPortrait 2.portraitUpsideDown 3.landscapeLeft 4.landscapeRight</param>
		public void setInitParameter(string appId, string appKey,int orientation)
        {
            this.appId = appId;
            this.appKey = appKey;
			this.orientation = orientation;
            
        }

       /// <summary>
        /// 设置支付参数
       /// </summary>
       /// <param name="cooOrderSerial">订单号必须唯一,推荐为GUID或UUID</param>
       /// <param name="productId">自定义的产品ID</param>
       /// <param name="productName">产品名称</param>
       /// <param name="productPrice">产品现价，支付价格以此为准</param>
        /// <param name="productOrignalPrice">产品原价 ，与现价保持一致</param>
       /// <param name="productCount">产品数量</param>
       /// <param name="payDescription">服务器分区,不超过20个字符，只允许英文或数字</param>
        public void setPayParameter(string cooOrderSerial, 
            string productId, 
            string productName,
            string productPrice,
            string productOrignalPrice,
            string productCount,
            string payDescription)
        {
            this.cooOrderSerial = cooOrderSerial;
            this.productId = productId;
            this.productName = productName;
            this.productPrice = productPrice;
            this.productOrignalPrice = productOrignalPrice;
            this.productCount = productCount;
            this.payDescription = payDescription;
        }

        /// <summary>
        /// 平台类型
        /// </summary>
		public string type { get{return PlatformNameEnum.IOS_91.ToString();} }

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

			string parameter = appId + "," + appKey + "," + orientation;
			AllSdkPlatform.sdkInit (parameter);
            Debug.Log("appId===" + appId + "appKey===" + appKey);
#endif


        }

        /// <summary>
        /// 登录
        /// </summary>
        public void login()
        {
#if UNITY_IPHONE
			AllSdkPlatform.sdkLogin ();
             Debug.Log("Login_91");
#endif
        }

        /// <summary>
        /// 支付
        /// </summary>
        public void pay()
        {
#if UNITY_IPHONE
            string parameter = cooOrderSerial + "," + productId + "," + productName + "," + productPrice + "," + productOrignalPrice + "," + productCount + "," + payDescription;
			AllSdkPlatform.sdkPay (parameter);
            Debug.Log("cooOrderSerial===" + cooOrderSerial + "productId===" + productId + "productName===" + productName + "productPrice===" + productPrice);
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
			AllSdkPlatform.sdkShowToolBar();
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
			AllSdkPlatform.sdkHideToolBar();
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
