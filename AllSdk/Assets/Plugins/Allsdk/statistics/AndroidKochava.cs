using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace allSdk
{
    public class AndroidKochava : IStatistic
    {
        /// <summary>
        /// 发送消息类型
        /// </summary>
        private string infoType;

        private string guid;
        private string key;

        private string data;


        /// <summary>
        /// 设置初始化参数
        /// </summary>
        public void setInitParameter(string guid)
        {
            this.guid = guid;
        }


        /// <summary>
        /// 设置自定事件类型
        /// </summary>
        public void setCustomeParameter(string key,string data)
        {
            this.infoType = "event";
            this.key = key;
            this.data = data;
        }

        //绑定身份
        public void setlinkIdentityParameter(string key,string data)
        {
            this.infoType = "linkIdentity";
            this.key = key;
            this.data = data;
        }


        /// <summary>
        /// 统计插件类路径（android 使用）
        /// </summary>
        public string statisticClassPath { get { return "com.example.unityKochava.KochavaStatistic"; } }

        /// <summary>
        /// 是否有初始化操作
        /// </summary>
        public bool isSupportInit { get { return true; } }

        /// <summary>
        /// 是否可发送信息
        /// </summary>
        public bool isSupportSendInfo { get { return true; } }

        /// <summary>
        /// 是否可获取信息
        /// </summary>
        public bool isSupportGetInfo { get { return false; } }

        /// <summary>
        /// 初始化统计插件
        /// </summary>
        public void initStatistic()
        {
#if UNITY_ANDROID
            if (isSupportInit)
            {
                object[] parameter = new object[] { AllSdkStatistic.instance().getMainCotext(),this.guid};
                AllSdkStatistic.instance().callAndroidSdkStaticFunction(StatisticFunctionEnum.initStatistic.ToString(), parameter,statisticClassPath);
            }
#endif
        }

        /// <summary>
        /// 发送统计数据
        /// </summary>
        public void sendInfo()
        {
#if UNITY_ANDROID
            if (isSupportSendInfo)
            {
                object[] parameter = new object[] { infoType, key, data };
                AllSdkStatistic.instance().callAndroidSdkStaticFunction(StatisticFunctionEnum.sendInfo.ToString(), parameter, statisticClassPath);
            }
#endif
        }

        /// <summary>
        /// 获取信息-获取channelId
        /// </summary>
        public string getInfo()
        {
//#if UNITY_ANDROID
//            if (isSupportGetInfo)
//                return AllSdkStatistic.instance().callAndroidSdkStaticFunctionWithReturn(StatisticFunctionEnum.getInfo.ToString(), null, statisticClassPath);
//            else
//                return "";
//#endif
            return "";
        }
    }
}
