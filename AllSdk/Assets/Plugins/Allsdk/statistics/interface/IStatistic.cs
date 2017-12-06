using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace allSdk
{
    public interface IStatistic
    {
        /// <summary>
        /// 统计插件类路径（android 使用）
        /// </summary>
        string statisticClassPath { get; }

        /// <summary>
        /// 是否有初始化操作
        /// </summary>
        bool isSupportInit { get; }

        /// <summary>
        /// 是否可发送信息
        /// </summary>
        bool isSupportSendInfo { get; }

        /// <summary>
        /// 是否可获取信息
        /// </summary>
        bool isSupportGetInfo { get; }

        /// <summary>
        /// 初始化统计插件
        /// </summary>
        void initStatistic();

        /// <summary>
        /// 发送统计数据
        /// </summary>
        void sendInfo();

        /// <summary>
        /// 获取信息
        /// </summary>
        string getInfo();
    }
}
