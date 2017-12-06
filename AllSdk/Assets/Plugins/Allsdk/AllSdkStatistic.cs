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
    /// Create time:2014/7/18 11:14:47 
    /// </summary>
    ///
    public class AllSdkStatistic :AllSdkProtocal
    {
        private static AllSdkStatistic _instance;

        /// <summary>
        /// 获取平台控制单例
        /// </summary>
        /// <returns></returns>
        public static AllSdkStatistic instance()
        {
            //_instance = GameObject.FindObjectOfType(typeof(AllSdkStatistic)) as AllSdkStatistic;
            if (_instance == null)
            {
                var obj = new GameObject("AllSdkStatistic");
                _instance = obj.AddComponent<AllSdkStatistic>();
                Object.DontDestroyOnLoad(_instance.gameObject);
            }

            return _instance;
        }

        /// <summary>
        /// 初始化统计插件
        /// </summary>
        /// <param name="statistic"></param>
        public void initStatistic(IStatistic statistic)
        {
            statistic.initStatistic();
        }

        /// <summary>
        /// 发送统计数据
        /// </summary>
        /// <param name="statistic"></param>
        public void sendStatisticInfo(IStatistic statistic)
        {
            statistic.sendInfo();
        }

        /// <summary>
        /// 获取统计插件信息 渠道号等
        /// </summary>
        /// <param name="statistic"></param>
        /// <returns></returns>
        public string getInfo(IStatistic statistic)
        {
            return statistic.getInfo();
        }
    }
}
