using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

namespace allSdk{

	public class IosFieliu:IPlatform{

		private string appId;
		private string appKey;
		private string companyId;

	    private bool isAutoLogin;
		
		private string orderId;
		private string price;
		private string desc;
		private string merpriv;

		private string guid;
		private string playerId;
		private string level;
		private string nickName;
		private string serverId;


		/// <summary>
		/// Sets the init parameter.
		/// </summary>
		/// <param name="appId">App identifier.</param>
		/// <param name="appKey">App key.</param>
		/// <param name="companyId">Company identifier.</param>
		public void setInitParameter(string appId, string appKey, string companyId){
			this.appId = appId;
			this.appKey = appKey;
			this.companyId = companyId;
		}

        /// <summary>
        /// 设置登录参数
        /// </summary>
        /// <param name="isAutoLogin"></param>
	    public void setLoginParameter(bool isAutoLogin)
	    {
	        this.isAutoLogin = isAutoLogin;
	    }

		/// <summary>
		/// Sets the pay paramter.
		/// </summary>
		/// <param name="orderId">Order identifier.</param>
		/// <param name="price">Price.</param>
		/// <param name="desc">Desc.</param>
		/// <param name="merpriv">Merpriv.</param>
		public void setPayParamter(string orderId,string price, string desc, string merpriv){
			
			this.orderId = orderId;
			this.price = price;
			this.desc = desc;
			this.merpriv = merpriv;
		}

		/// <summary>
		/// 设置发送的统计参数
		/// </summary>
		/// <param name="guid"></param>
		/// <param name="playerId"></param>
		/// <param name="level"></param>
		/// <param name="nickname"></param>
		/// <param name="serverId"></param>
		public void setSendInfo(string guid, string playerId, string level, string nickname, string serverId)
		{
			this.guid = guid;
			this.playerId = playerId;
			this.level = level;
			this.nickName = nickname;
			this.serverId = serverId;
		}

		/// <summary>
		/// 平台类型
		/// </summary>
		public string type { get { return PlatformNameEnum.ANDROID_FEILIU.ToString(); } }
		
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
		/// Gets a value indicating whether this <see cref="allSdk.IosFieliu"/> is support send message to sdk.
		/// </summary>
		/// <value><c>true</c> if is support send message to sdk; otherwise, <c>false</c>.</value>
		public bool isSupportSendMessageToSdk{ get {return true;}}

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

			string parameter = appId + "," + appKey + "," + companyId;
			AllSdkPlatform.sdkInit (parameter);
			#endif
		}
		
		/// <summary>
		/// 登录
		/// </summary>
		public void login()
		{
			#if UNITY_IPHONE
		    string parameter = isAutoLogin.ToString();
            AllSdkPlatform.sdkLogin(parameter);
			#endif
		}
		
		/// <summary>
		/// 支付
		/// </summary>
		public void pay()
		{
			#if UNITY_IPHONE
			string parameter = orderId + "," + price + "," + desc+","+merpriv;
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
			
			AllSdkPlatform.sdkShowToolBar ();
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
			
			AllSdkPlatform.sdkHideToolBar ();
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
		/// send message to sdk.
		/// </summary>
		public void sendMessageToSDK()
		{
			#if UNITY_IPHONE
			if (!isSupportSendMessageToSdk)
				return;

			string parameter = guid + "," + playerId + "," + level+","+nickName+","+serverId;
			AllSdkPlatform.sdkSendMessage(parameter);
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

