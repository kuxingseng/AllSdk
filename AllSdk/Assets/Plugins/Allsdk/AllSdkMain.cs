using UnityEngine;
using System.Collections;

namespace allSdk
{
    using System;

    /// <summary>
    /// author chenshuai
    /// $Id$
    /// Create time:2014/6/11 16:37:51 
    /// </summary>
    ///
    public class AllSdkMain : MonoBehaviour
    {
        private static AllSdkMain _instance;

#if UNITY_ANDROID
        private AndroidJavaObject utilsJavaObject;
        private AndroidJavaObject mainJavaObject;
#endif

        /// <summary>
        /// 获取单例
        /// </summary>
        /// <returns></returns>
        public static AllSdkMain instance()
        {
            _instance = GameObject.FindObjectOfType(typeof(AllSdkMain)) as AllSdkMain;
            if (_instance == null)
            {
                GameObject obj = new GameObject("AllSdkMain");
                _instance = obj.AddComponent<AllSdkMain>();
            }
            GameObject.DontDestroyOnLoad(_instance.gameObject);

            return _instance;
        }

        // Use this for initialization
        void Start()
        {

        }

        void Awake()
        {
            //Makes the object target not be destroyed automatically when loading a new scene
            GameObject.DontDestroyOnLoad(gameObject);

            //绑定脚本，平台、统计、分享等分开处理
            this.gameObject.AddComponent<AllSdkPlatform>();
            //this.gameObject.AddComponent("AllSdkStatistic");
        }

        // Update is called once per frame
        void Update()
        {

        }

        /// <summary>
        /// 获取手机mac地址
        /// </summary>
        /// <returns></returns>
        public string getMacAddress()
        {
#if UNITY_ANDROID
            if (mainJavaObject == null)
            {
                AndroidJavaClass mAndroidJavaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
                mainJavaObject = mAndroidJavaClass.GetStatic<AndroidJavaObject>("currentActivity");
            }
            if (utilsJavaObject == null)
                utilsJavaObject = new AndroidJavaObject("com.example.u3d.AndroidUtils");
            return utilsJavaObject.CallStatic<string>("getMacAddress", mainJavaObject);
#endif

            return "";
        }

        /// <summary>
        /// 获取手机imei
        /// </summary>
        /// <returns></returns>
        public string getDeviceId()
        {
#if UNITY_ANDROID
            if (mainJavaObject == null)
            {
                AndroidJavaClass mAndroidJavaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
                mainJavaObject = mAndroidJavaClass.GetStatic<AndroidJavaObject>("currentActivity");
            }
            if (utilsJavaObject == null)
                utilsJavaObject = new AndroidJavaObject("com.example.u3d.AndroidUtils");
            return utilsJavaObject.CallStatic<string>("getDeviceId", mainJavaObject);
#endif

            return "";
        }

        /// <summary>
        /// 获取手机号
        /// </summary>
        /// <returns></returns>
        public string getPhoneNumber()
        {
#if UNITY_ANDROID
            if (mainJavaObject == null)
            {
                AndroidJavaClass mAndroidJavaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
                mainJavaObject = mAndroidJavaClass.GetStatic<AndroidJavaObject>("currentActivity");
            }
            if (utilsJavaObject == null)
                utilsJavaObject = new AndroidJavaObject("com.example.u3d.AndroidUtils");
            return utilsJavaObject.CallStatic<string>("getPhoneNumber", mainJavaObject);
#endif

            return "";
        }

        /// <summary>
        /// 判断assetbundle是否打入包内
        /// </summary>
        /// <param name="assetBundleName">带后缀名资源</param>
        /// <returns></returns>
        public bool checkAssetbundleExist(string assetBundleName)
        {
#if UNITY_ANDROID
            if (mainJavaObject == null)
            {
                AndroidJavaClass mAndroidJavaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
                mainJavaObject = mAndroidJavaClass.GetStatic<AndroidJavaObject>("currentActivity");
            }
            if (utilsJavaObject == null)
                utilsJavaObject = new AndroidJavaObject("com.example.u3d.AndroidUtils");
            return utilsJavaObject.CallStatic<bool>("checkAssetbundleExist", mainJavaObject, assetBundleName);
#endif

            return false;
        }

        /// <summary>
        /// 获取所有动态资源列表
        /// </summary>
        /// <returns></returns>
        public string getAssetBundleList()
        {
#if UNITY_ANDROID
            if (mainJavaObject == null)
            {
                AndroidJavaClass mAndroidJavaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
                mainJavaObject = mAndroidJavaClass.GetStatic<AndroidJavaObject>("currentActivity");
            }
            if (utilsJavaObject == null)
                utilsJavaObject = new AndroidJavaObject("com.example.u3d.AndroidUtils");
            return utilsJavaObject.CallStatic<string>("getAssetBundleList", mainJavaObject);
#endif

            return "";
        }

        /// <summary>
        /// 设置是否为debug模式
        /// </summary>
        /// <param name="debugFlag"></param>
        public void setDebugMode(Boolean debugFlag)
        {
#if UNITY_ANDROID
            if (utilsJavaObject == null)
                utilsJavaObject = new AndroidJavaObject("com.example.u3d.AndroidUtils");
            utilsJavaObject.SetStatic("debugFlag", debugFlag);
#endif
        }

        /// <summary>
        /// debug模式下，可输出日志到logcat
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="logCatTagparam>
        public void log(String msg, String logCatTag)
        {
#if UNITY_ANDROID
            if (utilsJavaObject == null)
                utilsJavaObject = new AndroidJavaObject("com.example.u3d.AndroidUtils");
            utilsJavaObject.CallStatic("log", new object[] { logCatTag, msg });
#endif
        }

        /// <summary>
        /// debug模式下，可输出日志到logcat
        /// </summary>
        /// <param name="msg"></param>
        public void log(string msg)
        {
            log(msg,"unitySDK");
        }
    }
}


