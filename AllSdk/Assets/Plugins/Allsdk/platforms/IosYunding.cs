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
    public class IosYunding:IPlatform
    {
        private string appId;
        private string appKey;
		private string UmengKey;
		private string TalkingDataKey;
		private string IDSOrientation;

		private string GoodsCode;


		private string servId;
		private string ServName;
		private string roleId;
		private string roleName;
		private string roleGrade;

        private string eventName;
        private string amount;
        private string currencyCode;

		private int sendMessageType;


        /// <summary>
        /// 设置初始化参数
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="appKey"></param>
        /// <param name="UmengKey"></param>
        /// <param name="TalkingDataKey"></param>
        /// <param name="IDSOrientation">"5"竖版转向，"6"横版转向</param>
		public void setInitParameter(string appId, string appKey, string UmengKey,string TalkingDataKey,string IDSOrientation)
        {
            this.appId = appId;
            this.appKey = appKey;
			this.UmengKey = UmengKey;
			this.TalkingDataKey = TalkingDataKey;
			this.IDSOrientation = IDSOrientation;
        }


        /// <summary>
        /// 设置支付参数
        /// </summary>
        /// <param name="GoodsCode">后台配置的商品code</param>
		public void setPayParameter(string GoodsCode)
        {
			this.GoodsCode = GoodsCode;
        }


		/*
		 描述:设置游戏区服名字，区服id，用户选择完区服的时候调用该方法
		     特别的，当用户曾经登录过，不出现区服界面而直接进入游戏，
		     这时候也需要重新调用该方法
		 条件:必须
		 */
        /// <summary>
        /// 
        /// </summary>
        /// <param name="servId">区服id</param>
        /// <param name="ServName">区服名称</param>
		public void setServIdParameter(string servId,string ServName)
		{
			this.sendMessageType = 0;
			this.servId = servId;
			this.ServName = ServName;
		}

		/*
		 描述:设置游戏角色id，游戏角色名字，用户选择角色的时候调用该方法
		     特别的，当用户曾经登录过，不出现角色选择界面而直接进入游戏，
		     这时候也需要重新调用该方法
		 条件:必须
		 */
        /// <summary>
        /// 
        /// </summary>
        /// <param name="roleId">角色id</param>
        /// <param name="roleName">角色名</param>
        /// <param name="roleGrade">角色等级</param>
		public void setRoleIdParameter(string roleId,string roleName,string roleGrade)
		{
			this.sendMessageType = 1;
			this.roleId = roleId;
			this.roleName = roleName;
			this.roleGrade = roleGrade;
		}


		/*
		 描述:设置游戏角色等级 实时报道
		     强烈建议用客户端实时报道角色等级，每次用户等级升级的
		     时候，调用该方法。
		 条件:必须
		 */
        /// <summary>
        /// 
        /// </summary>
        /// <param name="roleId">角色id</param>
        /// <param name="roleGrade">角色等级</param>
		public void setRoleGradeParameter(string roleId,string roleGrade)
		{
			this.sendMessageType = 2;
			this.roleId = roleId;
			this.roleGrade = roleGrade;
		}


        /*
 描述:正版iap消费跟踪

 条件:必须
 */

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventName">列如"6元"</param>
        /// <param name="amount">例如“6.00”</param>
        /// <param name="currencyCode">例如“RMB”</param>
        public void setTrackActionForEventIdOrNameParameter(string eventName, string amount,string currencyCode)
        {
            this.sendMessageType = 3;
            this.eventName = eventName;
            this.amount = amount;
            this.currencyCode = currencyCode;
        }

        /// <summary>
        /// 平台类型
        /// </summary>
		public string type { get{return PlatformNameEnum.IOS_YUNDING.ToString();} }
			
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
        public bool isSupportSendMessageToSdk { get { return true; } }

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

			string parameter = appId + "," + appKey + "," + UmengKey + "," + TalkingDataKey + "," + IDSOrientation;
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
			string parameter = GoodsCode;
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

			if (this.sendMessageType == 0)
			{
				string parameter = sendMessageType + "," + servId + "," + ServName;
				AllSdkPlatform.sdkSendMessage(parameter);
			}
			else if (this.sendMessageType == 1)
			{
				string parameter =sendMessageType + "," +  roleId + "," + roleName + "," + roleGrade;
				AllSdkPlatform.sdkSendMessage(parameter);
			}
			else if (this.sendMessageType == 2)
			{
				string parameter =sendMessageType + "," +  roleId + "," + roleGrade;
				AllSdkPlatform.sdkSendMessage(parameter);
			}
            else if (this.sendMessageType == 3)
			{
				string parameter =sendMessageType + "," +  eventName + "," + amount + "," +currencyCode;
				AllSdkPlatform.sdkSendMessage(parameter);
			}
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
