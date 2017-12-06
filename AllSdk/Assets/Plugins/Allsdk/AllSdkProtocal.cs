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
    /// Create time:2014/6/11 16:37:51 
    /// </summary>
    ///
    public abstract class AllSdkProtocal:MonoBehaviour
    {
#if UNITY_ANDROID
        private AndroidJavaObject mAndroidJavaObject;
        private AndroidJavaObject mMainJavaObject;
        private string mJavaObjectName;
#endif

        /// <summary>
        /// 调用sdk 方法
        /// </summary>
        /// <param name="functionName">方法名</param>
        /// <param name="parameter"></param>
        /// <param name="javaObjectName">不传默认获取mainActivity,统计sdk获取特定类</param>
        public void callAndroidSdkFunction(string functionName, object[] parameter = null, string javaObjectName = "")
        {
#if UNITY_ANDROID
            if (parameter != null && parameter.Length > 0)
                getAndroidJavaObject(javaObjectName).Call(functionName, parameter);
            else
                getAndroidJavaObject(javaObjectName).Call(functionName);
#endif
        }

        /// <summary>
        /// 调用sdk 静态方法
        /// </summary>
        /// <param name="functionName">方法名</param>
        /// <param name="parameter"></param>
        /// <param name="javaObjectName">不传默认获取mainActivity,统计sdk获取特定类</param>
        public void callAndroidSdkStaticFunction(string functionName, object[] parameter = null, string javaObjectName = "")
        {
#if UNITY_ANDROID
            if (parameter != null && parameter.Length > 0)
                getAndroidJavaObject(javaObjectName).CallStatic(functionName, parameter);
            else
                getAndroidJavaObject(javaObjectName).CallStatic(functionName);
#endif
        }

        /// <summary>
        /// 调用sdk 方法，有string类型返回值
        /// </summary>
        /// <param name="functionName"></param>
        /// <param name="parameter"></param>
        /// <param name="javaObjectName">不传默认获取mainActivity,统计sdk获取特定类</param>
        /// <returns></returns>
        public string callAndroidSdkFunctionWithReturn(string functionName, object[] parameter = null, string javaObjectName = "")
        {
#if UNITY_ANDROID
            if (parameter != null && parameter.Length > 0)
                return getAndroidJavaObject(javaObjectName).Call<string>(functionName, parameter);
            else
               return getAndroidJavaObject(javaObjectName).Call<string>(functionName);
#endif
			return "";
        }

        /// <summary>
        /// 调用sdk 静态方法，有string类型返回值
        /// </summary>
        /// <param name="functionName"></param>
        /// <param name="parameter"></param>
        /// <param name="javaObjectName">不传默认获取mainActivity,统计sdk获取特定类</param>
        /// <returns></returns>
        public string callAndroidSdkStaticFunctionWithReturn(string functionName, object[] parameter = null, string javaObjectName = "")
        {
#if UNITY_ANDROID
            if (parameter != null && parameter.Length > 0)
                return getAndroidJavaObject(javaObjectName).CallStatic<string>(functionName, parameter);
            else
                return getAndroidJavaObject(javaObjectName).CallStatic<string>(functionName);
#endif
            return "";
        }



        /// <summary>
        /// 获取当前项目上下文
        /// </summary>
        /// <returns></returns>
        public AndroidJavaObject getMainCotext()
        {
#if UNITY_ANDROID
            checkAndCreateAndroidClass("");
            return mMainJavaObject;
#endif
            return null;
        }

        /// <summary>
        /// 获取对应java类
        /// </summary>
        /// <returns></returns>
        private AndroidJavaObject getAndroidJavaObject(string javaObjectName = "")
        {
#if UNITY_ANDROID
            checkAndCreateAndroidClass(javaObjectName);
            if (javaObjectName == "")
                return mMainJavaObject;
            else
                return mAndroidJavaObject;
#endif
            return null;
        }

        private void checkAndCreateAndroidClass(string javaObjectName)
        {
#if UNITY_ANDROID
            if (javaObjectName == "")
            {
                if (mMainJavaObject == null)
                {
                    AndroidJavaClass mAndroidJavaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
                    mMainJavaObject = mAndroidJavaClass.GetStatic<AndroidJavaObject>("currentActivity");
                }
            }
            else
            {
                if (mAndroidJavaObject == null || this.mJavaObjectName != javaObjectName)
                {
                    mAndroidJavaObject = new AndroidJavaObject(javaObjectName);
                    this.mJavaObjectName = javaObjectName;
                }
            }
#endif
        }


        /// <summary>
        /// 注册消息接收者
        /// </summary>
        /// <param name="receiver"></param>
        public void registerMessageReceiver(MonoBehaviour receiver)
        {
#if UNITY_ANDROID
            AndroidJavaObject jcAndroidObject = getAndroidJavaObject();
            string gameObjectName = receiver.gameObject.name;
            jcAndroidObject.Call("registerMessageReceiver", new object[] { gameObjectName });
#endif
        }

        /// <summary>
        /// 解除消息接收者
        /// </summary>
        /// <param name="receiver"></param>
        protected void unRegisterMessageReceiver(MonoBehaviour receiver)
        {
#if UNITY_ANDROID
            AndroidJavaObject jcAndroidObject = getAndroidJavaObject();
            string gameObjectName = receiver.gameObject.name;
            jcAndroidObject.Call("unRegisterMessageReceiver", new object[] { gameObjectName });
#endif
        }

        /// <summary>
        /// 注册消息接收者(Static)
        /// </summary>
        /// <param name="receiver"></param>
        public void registerMessageReceiver(MonoBehaviour receiver, string javaObjectName )
        {
#if UNITY_ANDROID
            AndroidJavaObject jcAndroidObject = getAndroidJavaObject(javaObjectName);
            string gameObjectName = receiver.gameObject.name;
            jcAndroidObject.CallStatic("registerMessageReceiver", new object[] { gameObjectName });
#endif
        }

        /// <summary>
        /// 解除消息接收者(Static)
        /// </summary>
        /// <param name="receiver"></param>
        protected void unRegisterMessageReceiver(MonoBehaviour receiver, string javaObjectName)
        {
#if UNITY_ANDROID
            AndroidJavaObject jcAndroidObject = getAndroidJavaObject(javaObjectName);
            string gameObjectName = receiver.gameObject.name;
            jcAndroidObject.CallStatic("unRegisterMessageReceiver", new object[] { gameObjectName });
#endif
        }

    }
}
