using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace allSdk
{
    /// <summary>
    /// author chenshuai
    /// $Id$
    /// Create time:2014/6/17 11:37:01 
	/// Modify:MaJie
    /// </summary>
    ///
    public class AndroidXiaomi:IPlatform
    {
        public string appId;
        public string appKey;

		public string serial;
		public string productName;
		public string count;
		public string userBalance;
		public string userVip;
		public string userLv;
		public string userPartyName;
		public string userRoleName;
		public string userRoleID;
		public string userServerName;  

        /// <summary>
        /// 设置初始化参数
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="appKey"></param>
        public void setInitParameter(string appId, string appKey)
        {
            this.appId = appId;
            this.appKey = appKey;
        }

        /// <summary>
        /// 设置支付参数
        /// </summary>
		/// <param name="serial">订单号</param>
		/// <param name="productName">此参数在用户支付成功后会透传给CP的服务器</param>
		/// <param name="count">必须是大于1的整数，10代表10米币，即10元人民币（不为空）</param>
		/// <param name="userBalance">用户余额</param>
		/// <param name="userVip">vip等级</param>
		/// <param name="userLv">角色等级</param>
		/// <param name="userPartyName">工会，帮派</param>
		/// <param name="userRoleName">角色名称.</param>
		/// <param name="userRoleID">角色ID</param>
		/// <param name="userServerName">所在服务器</param>
		public void setPayParameter(string serial, string productName,
		                       string count,string userBalance,
		                       string userVip,string userLv,
		                       string userPartyName,string userRoleName,
		                       string userRoleID, string userServerName)
		{
			this.serial = serial;
			this.productName = productName;
			this.count = count;
			this.userBalance = userBalance;
			this.userVip = userVip;
			this.userLv = userLv;
			this.userPartyName = userPartyName;
			this.userRoleName = userRoleName;
			this.userRoleID = userRoleID;
			this.userServerName = userServerName;  
        }

        /// <summary>
        /// 平台类型
        /// </summary>
		public string type { get { return PlatformNameEnum.ANDROID_XIAOMI.ToString(); } }

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
		public bool isSupportShowToolbar {get{return false;} }

        /// <summary>
        /// 是否支持隐藏悬浮按钮
        /// </summary>
		public bool isSupportHideToolbar { get{return false;} }

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
            if (!isSupportInit)
                return;

            object[] parameter = new object[] { this.appId, this.appKey };
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
			object[] parameter = new object[] { serial, productName, count, userBalance, userVip,userLv,userPartyName,userRoleName,userRoleID,userServerName };
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
