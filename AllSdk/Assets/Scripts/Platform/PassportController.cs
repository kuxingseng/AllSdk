namespace Platform
{
    using System;
    using allSdk;
    using Branch;
    using UnityEngine;

#if UNITY_IPHONE
    using UnityEngine.iOS;
#endif

    /// <summary>
    /// author chenshuai
    /// $Id$
    /// Create time:2016/10/12 10:37:23 
    /// </summary>
    ///
    public class PassportController 
    {
        private static PassportController mController = null; // 控制器实例
        private IPassport mInstance = null; // 平台的实例
        private bool mIsPlatReady = false; // 是否有接入的平台，没有则使用其他登录方式

        private const string mClassSpace = "Platform.Branch."; // 平台的namespace
        
        public static PassportController Instance()
        {
            if (mController == null)
            {
                mController = new PassportController();
                mController.init();
            }
            return mController;
        }

        /// <summary>
        /// 初始化
        /// </summary>
        private void init()
        {
            try
            {
#if !UNITY_EDITOR
            try
            {
                //todo:可根据配置获取平台名
                //mInstance = (IPassport)Activator.CreateInstance(Type.GetType(ClassSpace + "Plat_" + PlatformName));
                mInstance = (IPassport)Activator.CreateInstance(Type.GetType(mClassSpace + "Plat_Android_xiaomi"));
                mIsPlatReady = true;
                //AllSdkMain.instance().setDebugMode(true);
            }
            catch (Exception ex)
            {
                mIsPlatReady = false;
            }
#else
                mIsPlatReady = false;
#endif
            }
            catch (Exception ex)
            {
                mIsPlatReady = false;
            }
        }

        /// <summary>
        /// 初始化平台SDK
        /// </summary>
        public void InitSdk()
        {
            if (mIsPlatReady)
            {
                var platform = mInstance.GetInitSdkvo();
                AllSdkPlatform.instance().init(platform, logoutCallBack, null, QuiteGame);
            }
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="callback"></param>
        public void Login(AllSdkPlatform.LoginSuccessCallback callback)
        {
            if (mIsPlatReady)
            {
                AllSdkPlatform.instance().login(mInstance.GetLoginVO(), callback);
            }
            else
            {
               //一键登录等
            }
        }


        /// <summary>
        /// 显示用户中心
        /// </summary>
        public void ShowPlatUserCenter()
        {
            if (mIsPlatReady)
            {
                AllSdkPlatform.instance().userCenter(mInstance.GetUserCenterVO());
            }
        }

       /// <summary>
        /// 分享
       /// </summary>
       /// <param name="contentTitle"></param>
       /// <param name="contentDescription"></param>
       /// <param name="photoURL"></param>
       /// <param name="contentURL"></param>
        public void Share(string contentTitle = "", string contentDescription = "", Uri photoURL = null, Uri contentURL = null)
        {
            
        }

        /// <summary>
        /// 退出登录
        /// </summary>
        public void Logout()
        {
            if (mIsPlatReady)
            {
                AllSdkPlatform.instance().logout(mInstance.GetLogoutVO());
            }
        }

        /// <summary>
        /// 获取支付列表地址
        /// </summary>
        public string GetPayListPath
        {
            get
            {
                if (mIsPlatReady)
                {
                    return mInstance.GetPayListPath;
                }
                return "";
            }
        }

        /// <summary>
        /// 购买前是否需要获取订单号
        /// </summary>
        public bool NeedGetServerOrder
        {
            get
            {
                if (mIsPlatReady)
                {
                    return mInstance.NeedGetServerOrder;
                }
                return false;
            }
        }

        /// <summary>
        /// 获取订单号的地址
        /// </summary>
        public string GetOrderPath
        {
            get
            {
                string result = null;
                if (mIsPlatReady)
                {
                    result = mInstance.GetOrderPath;
                }
                if (string.IsNullOrEmpty(result))
                {
                    result = "GetOrderNo";  //默认
                }
                return result;
            }
        }

        /// <summary>
        /// 支付
        /// </summary>
        /// <param name="goods"></param>
        /// <param name="orderData"></param>
        /// <param name="payCallback"></param>
        public void Recharge(RechargeItemInfo goods, string orderData = null,AllSdkPlatform.PaySuccessCallback payCallback=null)
        {
            if (mIsPlatReady)
            {
                if (mInstance.GetRechargeVO(goods, orderData) != null)
                    AllSdkPlatform.instance().pay(mInstance.GetRechargeVO(goods, orderData), payCallback);
            }
            else
            {
                //其他支付方式
            }
        }
        
        /// <summary>
        /// 设置游戏状态
        /// </summary>
        public void SetGameStatus(GameStatusEnum gameStatus, string nickname = null, string uid = null)
        {
            if (mIsPlatReady && mInstance != null)
            {
                mInstance.SetGameStatus(gameStatus, nickname, uid);
            }
        }

        /// <summary>
        /// 是否使用默认的退出方式（安卓使用）
        /// </summary>
        public bool UseDefaultQuit
        {
            get
            {
                if (mIsPlatReady)
                {
                    return mInstance.UseDefaultQuit;
                }
                else
                {
                    return true;
                }
            }

        }

        /// <summary>
        /// 处理退出事件（安卓使用）
        /// </summary>
        public void QuiteAction()
        {
            if (mIsPlatReady)
            {
                mInstance.QuiteAction();
            }
        }

        /// <summary>
        /// 点击了home键（安卓使用）
        /// </summary>
        public void InputHome()
        {
            if (mIsPlatReady)
            {
                mInstance.HomeInputAction();
            }
        }
        /// <summary>
        /// 退出游戏的方法
        /// </summary>
        public void QuiteGame(string desc = "")
        {
            Application.Quit();
        }

        /// <summary>
        /// 退出登录的回调
        /// </summary>
        private void logoutCallBack(string desc)
        {
           
        }
    }

    public class MacInfo
    {
        public string Mac;
    }
    
    //模拟支付数据，应该由项目传入
    public class RechargeItemInfo
    {
        public int Money;
    }
}
