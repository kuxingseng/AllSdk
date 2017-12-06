using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace allSdk
{
    using System.Security.Cryptography;

    /// <summary>
    /// author chenshuai
    /// $Id$
    /// Create time:2014/8/5 10:09:07 
    /// </summary>
    ///
    public class AndroidAnzhi:IPlatform
    {
        private string appKey;
        private string appSecret;
        private string gameName;
        private string channelName;

        private string orderId;
        private string price;
        private string desc;
        private string ext;

        /// <summary>
        /// 设置初始化参数
        /// </summary>
        /// <param name="appKey"></param>
        /// <param name="appSecret"></param>
        /// <param name="gameName">游戏名称</param>
        /// <param name="channelName">渠道名称</param>
        public void setInitParameter(string appKey, string appSecret, string gameName, string channelName)
        {
            this.appKey = appKey;
            this.appSecret = appSecret;
            this.gameName = gameName;
            this.channelName = channelName;
        }

        /// <summary>
        /// 设置支付参数
        /// </summary>
        /// <param name="orderId">预留位置可传0</param>
        /// <param name="price">单位（元）</param>
        /// <param name="desc">支付信息，向用户暴露，比如商品名不能为空</param>
        /// <param name="ext">用于游戏客户端与游戏服务端之间数据通信，支付完成后安智平台会将扩展信息内容传递给游戏服务端</param>
        public void setPayParameter(string orderId, string price, string desc, string ext)
        {
            this.orderId = orderId;
            this.price = price;
            this.desc = desc;
            this.ext = ext;
        }

        /// <summary>
        /// 平台类型
        /// </summary>
        public string type { get { return PlatformNameEnum.ANDROID_ANZHI.ToString(); }}

        /// <summary>
        /// 是否支持初始化操作
        /// </summary>
        public bool isSupportInit { get { return true; } }

        /// <summary>
        /// 是否支持登出
        /// </summary>
        public bool isSupportLogout { get { return true; } }

        /// <summary>
        /// 是否支持打开用户中心
        /// </summary>
        public bool isSupportUserCenter { get { return true; } }

        /// <summary>
        /// 是否支持打开悬浮按钮
        /// </summary>
        public bool isSupportShowToolbar { get { return true; } }

        /// <summary>
        /// 是否支持隐藏悬浮按钮
        /// </summary>
        public bool isSupportHideToolbar { get { return true; } }

        /// <summary>
        /// 是否支持退出操作
        /// </summary>
        public bool isSupportQuit { get { return false; } }

        /// <summary>
        /// 是否支持向sdk发送信息、统计信息等
        /// </summary>
        public bool isSupportSendMessageToSdk { get { return false; } }

        /// <summary>
        /// 是否支持防沉迷查询
        /// </summary>
        public bool isSupportAntiAddictionQuery { get { return false; } }

        /// <summary>
        /// 是否支持实名制注册
        /// </summary>
        public bool isSupportRealNameRegister { get { return false; } }

        /// <summary>
        /// 初始化
        /// </summary>
        public void init()
        {
            if (isSupportInit)
            {
                object[] parameter = new object[] { appKey, appSecret, gameName, channelName };
                AllSdkPlatform.instance().callAndroidSdkFunction(SDKFunctionNameEnum.init.ToString(),parameter);
            }   
        }

        /// <summary>
        /// 登录
        /// </summary>
        public void login()
        {
            AllSdkPlatform.instance().callAndroidSdkFunction(SDKFunctionNameEnum.login.ToString());
        }

        /// <summary>
        /// 支付
        /// </summary>
        public void pay()
        {
            object[] parameter = new object[] { int.Parse(orderId), float.Parse(price), this.desc, this.ext };
            AllSdkPlatform.instance().callAndroidSdkFunction(SDKFunctionNameEnum.pay.ToString(), parameter);
        }

        /// <summary>
        /// 登出
        /// </summary>
        public void logout()
        {
            if (isSupportLogout)
                AllSdkPlatform.instance().callAndroidSdkFunction(SDKFunctionNameEnum.logout.ToString());
        }

        /// <summary>
        /// 打开用户中心
        /// </summary>
        public void userCenter()
        {
            if (isSupportUserCenter)
                AllSdkPlatform.instance().callAndroidSdkFunction(SDKFunctionNameEnum.userCenter.ToString());
        }

        /// <summary>
        /// 显示悬浮菜单
        /// </summary>
        public void showToolBar()
        {
            if (isSupportShowToolbar)
                AllSdkPlatform.instance().callAndroidSdkFunction(SDKFunctionNameEnum.showToolBar.ToString());
        }

        /// <summary>
        /// 隐藏悬浮菜单
        /// </summary>
        public void hideToolBar()
        {
            if (isSupportHideToolbar)
                AllSdkPlatform.instance().callAndroidSdkFunction(SDKFunctionNameEnum.hideToolBar.ToString());
        }

        /// <summary>
        /// 退出游戏
        /// </summary>
        public void quit()
        {
            if (isSupportQuit)
                AllSdkPlatform.instance().callAndroidSdkFunction(SDKFunctionNameEnum.quit.ToString());
        }

        /// <summary>
        ///向sdk发送消息
        /// </summary>
        public void sendMessageToSDK()
        {
            if (isSupportSendMessageToSdk)
                AllSdkPlatform.instance().callAndroidSdkFunction(SDKFunctionNameEnum.sendMessageToSDK.ToString());
        }

        /// <summary>
        /// 防沉迷查询
        /// </summary>
        public void antiAddictionQuery()
        {
            if (isSupportAntiAddictionQuery)
                AllSdkPlatform.instance().callAndroidSdkFunction(SDKFunctionNameEnum.antiAddictionQuery.ToString());
        }

        /// <summary>
        /// 实名制注册
        /// </summary>
        public void realNameRegister()
        {
            if (isSupportRealNameRegister)
                AllSdkPlatform.instance().callAndroidSdkFunction(SDKFunctionNameEnum.realNameRegister.ToString());
        }

        /// <summary>
        /// 判断是否需要更新
        /// </summary>
        public void checkNeedUpdate()
        {
            
        }

        /// <summary>
        /// 开始省流量更新
        /// </summary>
        public void startSaveUpdate()
        {
            
        }

        /// <summary>
        /// 开始普通更新
        /// </summary>
        public void startCommonUpdate()
        {
           
        }
    }
}
