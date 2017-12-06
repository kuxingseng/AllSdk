using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace allSdk
{
    using UnityEngine;

    /// <summary>
    /// author chenshuai
    /// $Id$
    /// Create time:2014/6/11 17:13:20 
    /// </summary>
    ///
    public class AllSdkPlatform : AllSdkProtocal
    {
        private static AllSdkPlatform _instance;
        
        public delegate void InitSuccessCallabck(string info = "");
        private InitSuccessCallabck mInitSuccessCallabck;

        public delegate void LogoutSuccessCallback(string info = "");
        private LogoutSuccessCallback mLogoutSuccessCallback;

        public delegate void LoginSuccessCallback(String info = "");
        private LoginSuccessCallback mLoginSuccessCallback;

        public delegate void PaySuccessCallback(string info = "");
        private PaySuccessCallback mPaySuccessCallback;

        public delegate void QuitSuccssCallback(string info = "");
        private QuitSuccssCallback mQuitSuccssCallback;

        public delegate void AntiAddictionQueryCallback(string info = "");
        private AntiAddictionQueryCallback mAntiAddictionQueryCallback;

        public delegate void AppOrYYBDownloadFailCallback(string info="");
        private AppOrYYBDownloadFailCallback mAppOrYybDownloadFailCallback;

        public delegate void CheckNeedUpdateCallback(string info = "");
        private CheckNeedUpdateCallback mCheckNeedUpdateCallback;

        public delegate void GetFriendsInfoCallback(string info = "");
        private GetFriendsInfoCallback mGetFriendsInfoCallback;

        public delegate void SwitchUserCallback(string info = "");
        private SwitchUserCallback mSwitchUserCallback;

#if UNITY_IPHONE
		[DllImport ("__Internal")]
		public static extern void sdkRegisterMessageReceiver (string gameObjectName);
		
		[DllImport ("__Internal")]
		public static extern void sdkUnRegisterMessageReceiver (string gameObjectName);

		[DllImport ("__Internal")]
		public static extern void sdkInit (string parameter = "");		
		
		[DllImport ("__Internal")]
		public static extern void sdkLogin (string parameter = "");
		
		[DllImport ("__Internal")]
		public static extern void sdkPay (string parameter = "");
				
		[DllImport ("__Internal")]
		public static extern void sdkShowToolBar (string parameter = "");
		
		[DllImport ("__Internal")]
		public static extern void sdkHideToolBar (string parameter = "");

		[DllImport ("__Internal")]
		public static extern void sdkLogout (string parameter = "");

		[DllImport ("__Internal")]
		public static extern void sdkUserCenter (string parameter = "");

		[DllImport ("__Internal")]
		public static extern void sdkQuit (string parameter = "");

		[DllImport ("__Internal")]
		public static extern void sdkSendMessage (string parameter = "");
#endif

        /// <summary>
        /// 获取平台控制单例
        /// </summary>
        /// <returns></returns>
        public static AllSdkPlatform instance()
        {
            //_instance = GameObject.FindObjectOfType(typeof(AllSdkPlatform)) as AllSdkPlatform;
            if (_instance == null)
            {
                var obj = new GameObject("AllSdkPlatform");
                _instance = obj.AddComponent<AllSdkPlatform>();
                Object.DontDestroyOnLoad(_instance.gameObject);
            }  

            return _instance;
        }
        
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="platform"></param>
        /// <param name="mlogoutSuccessCallback">登出回调</param>
        /// <param name="minitSuccessCallabck">初始化成功回调</param>
        /// <param name="mquitSuccssCallback">退出sdk回调</param>
        /// <param name="mantiAddictionQueryCallback">防沉迷查询回调（360）</param>
        /// <param name="mappDownloadFailCallback">下载更新失败回调（tencent）</param>
        /// <param name="mchCheckNeedUpdateCallback">检查更新回调（tencent）</param>
        /// <param name="mgetFriendsInfoCallback">获取好友信息回调（tencent）</param>
        /// <param name="mswitchUserCallback">切换账号回调（kuaiyong-快用）</param>
        public void init(IPlatform platform,LogoutSuccessCallback mlogoutSuccessCallback = null,
            InitSuccessCallabck minitSuccessCallabck = null, QuitSuccssCallback mquitSuccssCallback = null,
            AntiAddictionQueryCallback mantiAddictionQueryCallback = null, AppOrYYBDownloadFailCallback mappDownloadFailCallback=null,
            CheckNeedUpdateCallback mchCheckNeedUpdateCallback=null, GetFriendsInfoCallback mgetFriendsInfoCallback=null,SwitchUserCallback mswitchUserCallback=null)
        {
            this.mLogoutSuccessCallback = mlogoutSuccessCallback;
            this.mInitSuccessCallabck = minitSuccessCallabck;
            this.mQuitSuccssCallback = mquitSuccssCallback;
            this.mAntiAddictionQueryCallback = mantiAddictionQueryCallback;
            this.mAppOrYybDownloadFailCallback = mappDownloadFailCallback;
            this.mCheckNeedUpdateCallback = mchCheckNeedUpdateCallback;
            this.mGetFriendsInfoCallback = mgetFriendsInfoCallback;
            this.mSwitchUserCallback = mswitchUserCallback;

            platform.init();
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="platform"></param>
        /// <param name="mloginSuccessCallback"></param>
        public void login(IPlatform platform, LoginSuccessCallback mloginSuccessCallback)
        {
            this.mLoginSuccessCallback = mloginSuccessCallback;
            platform.login();
        }

        /// <summary>
        /// 支付
        /// </summary>
        /// <param name="platform"></param>
        /// <param name="mpaySuccessCallback"></param>
        public void pay(IPlatform platform, PaySuccessCallback mpaySuccessCallback = null)
        {
            this.mPaySuccessCallback = mpaySuccessCallback;
            platform.pay();
        }

        /// <summary>
        /// 登出
        /// </summary>
        /// <param name="platform"></param>
        public void logout(IPlatform platform)
        {
            platform.logout();
        }

        /// <summary>
        /// 打开用户中心
        /// </summary>
        /// <param name="platform"></param>
        public void userCenter(IPlatform platform)
        {
            platform.userCenter();
        }

        /// <summary>
        /// 退出
        /// </summary>
        /// <param name="platform"></param>
        public void quit(IPlatform platform)
        {
            platform.quit();
        }

        /// <summary>
        /// 打开悬浮按钮
        /// </summary>
        /// <param name="platform"></param>
        public void showToolbar(IPlatform platform)
        {
			platform.showToolBar ();
        }

        /// <summary>
        /// 隐藏悬浮工具栏
        /// </summary>
        /// <param name="platform"></param>
        public void hideToolbar(IPlatform platform)
        {
            platform.hideToolBar();
        }

		/// <summary>
		/// Sends the message to SDK.
		/// </summary>
		/// <param name="platform">Platform.</param>
		public void sendMessageToSDK(IPlatform platform)
		{
			platform.sendMessageToSDK ();
		}

        /// <summary>
        /// 防沉迷查询
        /// </summary>
        /// <param name="platform"></param>
        public void antiAddictionQuery(IPlatform platform)
        {
            platform.antiAddictionQuery();
        }

        /// <summary>
        /// 实名制注册
        /// </summary>
        /// <param name="platform"></param>
        public void realNameRegister(IPlatform platform)
        {
            platform.realNameRegister();
        }

        /// <summary>
        /// 判断是否需要更新
        /// </summary>
        /// <param name="platform"></param>
        public void checkNeedUpdate(IPlatform platform)
        {
            platform.checkNeedUpdate();
        }

        /// <summary>
        /// 开始省流量更新
        /// </summary>
        /// <param name="platform"></param>
        public void startSaveUpdate(IPlatform platform)
        {
            platform.startSaveUpdate();
        }

        /// <summary>
        /// 开始普通更新
        /// </summary>
        /// <param name="platform"></param>
        public void startCommonUpdate(IPlatform platform)
        {
            platform.startCommonUpdate();
        }


        /// <summary>
        /// 切换账号成功回调
        /// </summary>
        /// <param name="info"></param>
        void  onSwitchUserSuccess(string info)
        {
            if (mSwitchUserCallback != null)
            {
                mSwitchUserCallback(info);
            }
        }
        /// <summary>
        /// 登录成功，返回登录信息
        /// </summary>
        /// <param name="info"></param>
        void onLoginSuccess(String info)
        {
            if (mLoginSuccessCallback != null)
            {
                mLoginSuccessCallback(info);
            }
        }

        /// <summary>
        /// 初始化成功回调
        /// </summary>
        /// <param name="info"></param>
        void onInitSuccess(string info)
        {
            if (mInitSuccessCallabck != null)
            {
                mInitSuccessCallabck(info);
            }
        }

        /// <summary>
        /// 登出成功回调
        /// </summary>
        /// <param name="info"></param>
        void onLogoutSuccess(string info)
        {
            AllSdkMain.instance().log(info);
            if (mLogoutSuccessCallback != null)
            {
                mLogoutSuccessCallback(info);
            }
        }

        /// <summary>
        /// 支付成功回调
        /// </summary>
        /// <param name="info"></param>
        void onPaySuccess(string info)
        {
            if (mPaySuccessCallback != null)
                mPaySuccessCallback(info);
        }

        /// <summary>
        /// 退出成功回调
        /// </summary>
        /// <param name="info"></param>
        void onQuitSuccess(string info)
        {
            if (mQuitSuccssCallback != null)
                mQuitSuccssCallback(info);
        }

        /// <summary>
        /// 防沉迷查询返回
        /// </summary>
        /// <param name="info"></param>
        void onAntiAddictionQuery(string info)
        {
            if (mAntiAddictionQueryCallback != null)
                mAntiAddictionQueryCallback(info);
        }

        /// <summary>
        /// 判断是否有更新
        /// </summary>
        /// <param name="info"></param>
        void onCheckNeedUpdate(string info)
        {
            if (mCheckNeedUpdateCallback != null)
                mCheckNeedUpdateCallback(info);
        }

        /// <summary>
        /// 下载应用或者应用宝失败回调
        /// </summary>
        /// <param name="info"></param>
        void onAppOrYybDownloadFail(string info)
        {
            if (mAppOrYybDownloadFailCallback != null)
                mAppOrYybDownloadFailCallback(info);
        }

        /// <summary>
        /// 获取好友信息成功回调
        /// </summary>
        /// <param name="info"></param>
        void onGetFriendsInfoSuccess(string info)
        {
            if (mGetFriendsInfoCallback != null)
                mGetFriendsInfoCallback(info);
        }

        void Awake()
        {
#if UNITY_ANDROID
            registerMessageReceiver(this);
#endif

#if UNITY_IPHONE
			Debug.Log("iphone registerMessageReceiver");
			AllSdkPlatform.sdkRegisterMessageReceiver(this.gameObject.name);
#endif
        }

        void onDestory()
        {
#if UNITY_ANDROID
            unRegisterMessageReceiver(this);
#endif

#if UNITY_IPHONE
			Debug.Log("iphone unRegisterMessageReceiver");
			AllSdkPlatform.sdkUnRegisterMessageReceiver(this.gameObject.name);
#endif
        }
    }
}
