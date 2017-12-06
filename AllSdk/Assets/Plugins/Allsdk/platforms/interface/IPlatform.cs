using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace allSdk
{
    using System.Security.Cryptography.X509Certificates;

    /// <summary>
    /// author chenshuai
    /// $Id$
    /// Create time:2014/6/16 10:55:22 
    /// </summary>
    ///
    public interface IPlatform
    {
        /// <summary>
        /// 平台类型
        /// </summary>
        string type { get; }

        /// <summary>
        /// 是否支持初始化操作
        /// </summary>
        bool isSupportInit { get; }

        /// <summary>
        /// 是否支持登出
        /// </summary>
        bool isSupportLogout { get; }

        /// <summary>
        /// 是否支持打开用户中心
        /// </summary>
        bool isSupportUserCenter { get; }

        /// <summary>
        /// 是否支持打开悬浮按钮
        /// </summary>
        bool isSupportShowToolbar { get; }

        /// <summary>
        /// 是否支持隐藏悬浮按钮
        /// </summary>
        bool isSupportHideToolbar { get; }

        /// <summary>
        /// 是否支持退出操作
        /// </summary>
        bool isSupportQuit { get; }

		/// <summary>
		/// 是否支持向sdk发送信息、统计信息等
		/// </summary>
		bool isSupportSendMessageToSdk{ get; }

        /// <summary>
        /// 是否支持防沉迷查询
        /// </summary>
        bool isSupportAntiAddictionQuery { get; }

        /// <summary>
        /// 是否支持实名制注册
        /// </summary>
        bool isSupportRealNameRegister { get; }

        /// <summary>
        /// 初始化
        /// </summary>
        void init();

        /// <summary>
        /// 登录
        /// </summary>
        void login();

        /// <summary>
        /// 支付
        /// </summary>
        void pay();

        /// <summary>
        /// 登出
        /// </summary>
        void logout();

        /// <summary>
        /// 打开用户中心
        /// </summary>
        void userCenter();

        /// <summary>
        /// 显示悬浮菜单
        /// </summary>
        void showToolBar();

        /// <summary>
        /// 隐藏悬浮菜单
        /// </summary>
        void hideToolBar();

        /// <summary>
        /// 退出游戏
        /// </summary>
        void quit();

		/// <summary>
		///向sdk发送消息
		/// </summary>
		void sendMessageToSDK();

        /// <summary>
        /// 防沉迷查询
        /// </summary>
        void antiAddictionQuery();

        /// <summary>
        /// 实名制注册
        /// </summary>
        void realNameRegister();

        /// <summary>
        /// 判断是否需要更新
        /// </summary>
        void checkNeedUpdate();

        /// <summary>
        /// 开始省流量更新
        /// </summary>
        void startSaveUpdate();

        /// <summary>
        /// 开始普通更新
        /// </summary>
        void startCommonUpdate();

    }
}
