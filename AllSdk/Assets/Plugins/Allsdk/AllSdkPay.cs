using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace allSdk
{
    using UnityEngine;

    /// <summary>
    /// author chenshuai
    /// $Id$
    /// Create time:2014/8/8 10:00:36 
    /// </summary>
    ///
    public class AllSdkPay:AllSdkProtocal
    {

        private static AllSdkPay _instance;
        private string mJavaObjectName = "";

        public delegate void SinglePaySuccessCallback(string info = "");
        private SinglePaySuccessCallback mSinglePaySuccessCallback;

        /// <summary>
        /// 获取平台控制单例
        /// </summary>
        /// <returns></returns>
        public static AllSdkPay instance()
        {
            //_instance = GameObject.FindObjectOfType(typeof(AllSdkPay)) as AllSdkPay;
            if (_instance == null)
            {
                var obj = new GameObject("AllSdkPay");
                _instance = obj.AddComponent<AllSdkPay>();
                Object.DontDestroyOnLoad(_instance.gameObject);
            }

            return _instance;
        }

        /// <summary>
        /// 初始化支付
        /// </summary>
        /// <param name="pay"></param>
        public void initSdkPay(IPay pay)
        {
            if (pay.isSupportInit)
                pay.init();
            registerMessageReceiver(pay);
        }

        /// <summary>
        /// 支付
        /// </summary>
        /// <param name="pay"></param>
        public void sdkPay(IPay pay, SinglePaySuccessCallback msinglePaySuccess = null)
        {
            this.mSinglePaySuccessCallback = msinglePaySuccess;

#if UNITY_IPHONE
			pay.registerMessageReceiver(this.gameObject.name);
#endif
            pay.pay();
        }

        public void sendMessageToSDK(IPay pay)
        {
            pay.sendMessageToSDK();
        }

        /// <summary>
        /// 单一支付方式，支付成功回调
        /// </summary>
        /// <param name="info"></param>
        void onSinglePaySuccess(string info)
        {
            if (mSinglePaySuccessCallback != null)
                mSinglePaySuccessCallback(info);
        }

        private void registerMessageReceiver(IPay pay)
        {
            mJavaObjectName = pay.getsinglepayClassPath();
            registerMessageReceiver(this, mJavaObjectName);
        }


        void Awake()
        {
#if UNITY_ANDROID
            //registerMessageReceiver(this);
#endif
        }

        void onDestory()
        {
#if UNITY_ANDROID
            unRegisterMessageReceiver(this, mJavaObjectName);
#endif
        }
    }
}
