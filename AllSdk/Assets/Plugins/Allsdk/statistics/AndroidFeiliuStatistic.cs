using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace allSdk
{
    /// <summary>
    /// author chenshuai
    /// $Id$
    /// Create time:2014/7/29 15:59:25 
    /// </summary>
    ///
    public class AndroidFeiliuStatistic:IStatistic
    {
        private String guid;
        private string playerId;
        private string level;
        private string nickName;
        private string serverId;

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
        /// 统计插件类路径（android 使用）
        /// </summary>
        public string statisticClassPath { get { return "com.example.unityfeiliustatistic.FeiliuStatistic"; } }

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
        public bool isSupportGetInfo { get { return true; } }

        /// <summary>
        /// 初始化统计插件
        /// </summary>
        public void initStatistic()
        {
            if (isSupportInit)
            {
#if UNITY_ANDROID
                object[] parameter = new object[] { AllSdkStatistic.instance().getMainCotext() };
                AllSdkStatistic.instance().callAndroidSdkStaticFunction(StatisticFunctionEnum.initStatistic.ToString(), parameter, statisticClassPath);
#endif
            }   
        }

        /// <summary>
        /// 发送统计数据
        /// </summary>
        public void sendInfo()
        {
            if (isSupportSendInfo)
            {
                object[] parameter = new object[] { this.guid, this.playerId, this.level, this.nickName, this.serverId };
                AllSdkStatistic.instance().callAndroidSdkStaticFunction(StatisticFunctionEnum.sendInfo.ToString(), parameter, statisticClassPath);
            }
        }

        /// <summary>
        /// 获取信息
        /// </summary>
        public string getInfo()
        {
#if UNITY_ANDROID
            if (isSupportGetInfo)
            {

                object[] parameter = new object[] { AllSdkStatistic.instance().getMainCotext() };
                return AllSdkStatistic.instance().callAndroidSdkStaticFunctionWithReturn(StatisticFunctionEnum.getInfo.ToString(),parameter,statisticClassPath);
            }   
            else
                return "";
#endif
            return "";
        }
    }
}
