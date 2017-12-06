using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace allSdk
{
	/// <summary>
	/// </summary>

    public class AndroidQxz : IPlatform
	{
		public string appId;
		

		public string productName;
        public string productDescript;
		public string productPrice;
		public string exaData;
		
		/// <summary>
		/// 设置初始化参数
		/// </summary>
		/// <param name="appId"></param>
		public void setInitParameter(string appId)
		{
			this.appId = appId;
		}

        /// <summary>
        /// 支付调用
        /// </summary>
        /// <param name="productName">商品名称</param>
        /// <param name="productDescript">商品描述</param>
        /// <param name="productPrice">商品价格</param>
        /// <param name="exaData">透传信息</param>
        public void setPayParameter(string productName, string productDescript, string productPrice, string exaData)
		{
            this.productName = productName;
            this.productDescript = productDescript;
            this.productPrice = productPrice;
            this.exaData = exaData;		
		}
		/// <summary>
		/// 平台类型
		/// </summary>
		public string type{ get { return PlatformNameEnum.ANDROID_Qxz.ToString(); } }
		
		/// <summary>
		/// 是否支持初始化操作
		/// </summary>
		public bool isSupportInit { get{return true;} }
		
		/// <summary>
		/// 是否支持登出
		/// </summary>
		public bool isSupportLogout { get{return false;} }
		
		/// <summary>
		/// 是否支持打开用户中心
		/// </summary>
		public bool isSupportUserCenter { get{return false;} }
		
		/// <summary>
		/// 是否支持打开悬浮按钮
		/// </summary>
		public bool isSupportShowToolbar{ get{return true;} }
		
		/// <summary>
		/// 是否支持隐藏悬浮按钮
		/// </summary>
		public bool isSupportHideToolbar { get{return true;} }
		
		/// <summary>
		/// 是否支持退出操作
		/// </summary>
		public bool isSupportQuit { get{return false;} }
		
		/// <summary>
		/// Gets a value indicating whether this <see cref="allSdk.IosFieliu"/> is support send message to sdk.
		/// </summary>
		/// <value><c>true</c> if is support send message to sdk; otherwise, <c>false</c>.</value>
		public bool isSupportSendMessageToSdk{ get {return false;}}

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
			if (!isSupportInit)
				return;
			
			object[] parameter = new object[] { this.appId };
			AllSdkPlatform.instance().callAndroidSdkFunction(SDKFunctionNameEnum.init.ToString(), parameter);
		}
		
		/// <summary>
		/// 登录
		/// </summary>
		public void login()
		{
			AllSdkPlatform.instance().callAndroidSdkFunction(SDKFunctionNameEnum.login.ToString());
		}
		
		/// <summary>
		/// 支付
		/// </summary>
		public void pay()
		{
            object[] parameter = new object[] { productName, productDescript, productPrice, exaData };
			AllSdkPlatform.instance().callAndroidSdkFunction(SDKFunctionNameEnum.pay.ToString(), parameter);
		}
		
		/// <summary>
		/// 登出
		/// </summary>
		public void logout()
		{
			if (!isSupportLogout)
				return;
			
			AllSdkPlatform.instance().callAndroidSdkFunction(SDKFunctionNameEnum.logout.ToString());
		}
		
		/// <summary>
		/// 打开用户中心
		/// </summary>
		public void userCenter()
		{
			if (!isSupportUserCenter)
				return;
			
			AllSdkPlatform.instance().callAndroidSdkFunction(SDKFunctionNameEnum.userCenter.ToString());
		}
		
		/// <summary>
		/// 显示悬浮菜单
		/// </summary>
		public void showToolBar()
		{
			if (!isSupportShowToolbar)
				return;
			
			AllSdkPlatform.instance().callAndroidSdkFunction(SDKFunctionNameEnum.showToolBar.ToString());
		}
		
		/// <summary>
		/// 隐藏悬浮菜单
		/// </summary>
		public void hideToolBar()
		{
			if (!isSupportHideToolbar)
				return;
			
			AllSdkPlatform.instance().callAndroidSdkFunction(SDKFunctionNameEnum.hideToolBar.ToString());
		}
		
		/// <summary>
		/// 退出游戏
		/// </summary>
		public void quit()
		{
			if (!isSupportQuit)
				return;
			
			AllSdkPlatform.instance().callAndroidSdkFunction(SDKFunctionNameEnum.quit.ToString());
		}
		
		/// <summary>
		/// send message to sdk.
		/// </summary>
		public void sendMessageToSDK()
		{
			if (!isSupportSendMessageToSdk)
				return;
			
			AllSdkPlatform.instance ().callAndroidSdkFunction (SDKFunctionNameEnum.sendMessageToSDK.ToString ());
		}

        /// <summary>
        /// 防沉迷查询
        /// </summary>
        public void antiAddictionQuery()
        {
            if (isSupportAntiAddictionQuery)
                AllSdkPlatform.instance().callAndroidSdkFunction(SDKFunctionNameEnum.antiAddictionQuery.ToString());
        }

        /// <summary>
        /// 实名制注册
        /// </summary>
        public void realNameRegister()
        {
            if (isSupportRealNameRegister)
                AllSdkPlatform.instance().callAndroidSdkFunction(SDKFunctionNameEnum.realNameRegister.ToString());
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
