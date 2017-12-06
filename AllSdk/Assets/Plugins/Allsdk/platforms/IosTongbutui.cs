using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace allSdk
{
    /// <summary>
    /// author chenshuai
    /// $Id$
    /// Create time:2014/7/22 18:00:11 
    /// </summary>
    ///
    public class IosTongbutui:IPlatform
    {
		private string appId;
		private int    orientation;

		private string orderSerial;
		private string needPayRMB;
		private string payDescription;

		private int place;

		/// <summary>
		/// set init parameters
		/// </summary>
		/// <param name="appId">App identifier.</param>
		/// <param name="orientation">设置支持的方向:1.OrientationPortrait 2.portraitUpsideDown 3.landscapeLeft 4.landscapeRight</param>
		public void setInitParameter(string appId,int orientation=1 )
		{
			this.appId = appId;
			this.orientation = orientation;
		}

		/// <summary>
		/// Sets the pay parameter.
		/// </summary>
		/// <param name="orderSerial">Order serial.</param>
		/// <param name="needPayRMB">Need pay RM.yuan</param>
		/// <param name="payDescription">Pay description.</param>
		public void setPayParameter(string orderSerial, string needPayRMB, string payDescription)
		{
			this.orderSerial = orderSerial;
			this.needPayRMB = needPayRMB;
			this.payDescription = payDescription;
		}

		/// <summary>
		/// Sets the tool bar parameter.
		/// </summary>
		/// <param name="place">Place.</param>
		/// /**
//		/*  悬浮工具栏位置
//		typedef enum  _TBToolBarPlace{
//			
//			TBToolBarAtTopLeft = 1,   /* 左上 */
//			
//			TBToolBarAtTopRight,      /* 右上 */
//			
//			TBToolBarAtMiddleLeft,    /* 左中 */
//			
//			TBToolBarAtMiddleRight,   /* 右中 */
//			
//			TBToolBarAtBottomLeft,    /* 左下 */
//			
//			TBToolBarAtBottomRight,   /* 右下 */
//			
//		}TBToolBarPlace;
		public void setToolBarParameter(int place)
		{
			this.place = place;
		}

        /// <summary>
        /// 平台类型
        /// </summary>
		public string type { get{ return PlatformNameEnum.IOS_TONGBUTUI.ToString (); } }

        /// <summary>
        /// 是否支持初始化操作
        /// </summary>
		public bool isSupportInit { get{ return true; } }

        /// <summary>
        /// 是否支持登出
        /// </summary>
		public bool isSupportLogout { get{ return true; } }

        /// <summary>
        /// 是否支持打开用户中心
        /// </summary>
		public bool isSupportUserCenter { get{ return true; } }

        /// <summary>
        /// 是否支持打开悬浮按钮
        /// </summary>
		public bool isSupportShowToolbar { get{return true;} }

        /// <summary>
        /// 是否支持隐藏悬浮按钮
        /// </summary>
		public bool isSupportHideToolbar { get{ return true; } }

        /// <summary>
        /// 是否支持退出操作
        /// </summary>
		public bool isSupportQuit { get{ return false; } }

        /// <summary>
        /// 是否支持向sdk发送信息、统计信息等
        /// </summary>
		public bool isSupportSendMessageToSdk { get{ return false; } }

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
			string parameter = appId + "," + orientation;
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
			string parameter = orderSerial + "," + needPayRMB+","+payDescription;
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

			string parameter = place+"";
			AllSdkPlatform.sdkShowToolBar(parameter);
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
