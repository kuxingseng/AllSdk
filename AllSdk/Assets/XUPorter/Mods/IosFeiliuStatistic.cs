using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace allSdk
{
    /// <summary>
    /// author chenshuai
    /// $Id$
    /// Create time:2014/7/18 12:10:16 
    /// </summary>
    ///
    public class IosFeiliuStatistic:IStatistic
    {
#if UNITY_IPHONE
		[DllImport ("__Internal")]
		public static extern void statisticInitForFeiliu (string appId, string appKey, string companyId);
		
		[DllImport ("__Internal")]
		public static extern void statisticSendInfoForFeiliu (string guid, string playerId, string level, string nickname, string serverId);

		[DllImport ("__Internal")]
		public static extern string statisticGetInfoForFeiliu ();	
#endif

        private string appId;
        private string appKey;
        private string companyId;

        private String guid;
        private string playerId;
        private string level;
        private string nickName;
        private string serverId;

        /// <summary>
        /// 设置初始化参数
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="appKey"></param>
        /// <param name="companyId"></param>
        public void setInitParameter(string appId, string appKey, string companyId)
        {
            this.appId = appId;
			this.appKey = appKey;
			this.companyId = companyId;
        }

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
        public string statisticClassPath { get; private set; }

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
#if UNITY_IPHONE
            if(!isSupportInit)
                return;

            statisticInitForFeiliu(appId,appKey,companyId);
#endif
        }

        /// <summary>
        /// 发送统计数据
        /// </summary>
        public void sendInfo()
        {
#if UNITY_IPHONE
            if (!isSupportSendInfo)
                return;

            statisticSendInfoForFeiliu(guid, playerId, level, nickName, serverId);
#endif
        }

        /// <summary>
        /// 获取信息
        /// </summary>
        public string getInfo()
        {
#if UNITY_IPHONE
            if (!isSupportGetInfo)
                return "";

            return statisticGetInfoForFeiliu();
#endif
            return "";
        }
    }
}
