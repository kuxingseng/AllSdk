using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace allSdk
{
    /// <summary>
    /// author chenshuai
    /// $Id$
    /// Create time:2014/8/6 15:10:24 
    /// </summary>
    ///
    public class AndroidLenovo:IPlatform
    {
        private string appId;

        private String appKey;
        private String waresId;
        private String notifyUrl;
        private String exOrderno;
		private	String price;
        private String cpprivateinfo;

        /// <summary>
        /// 设置初始化参数
        /// </summary>
        /// <param name="appId">应用代码，长度为20 位的字符串</param>
        public void setInitParameter(string appId)
        {
            this.appId = appId;
        }

        /// <summary>
        /// 设置支付参数
        /// </summary>
        /// <param name="appKey">应用密钥</param>
        /// <param name="appId">应用代码，长度为20 位的字符串</param>
        /// <param name="waresId">商品编码 接入时商户自建</param>
        /// <param name="notifyUrl">交易结果同步回调地址 可选字段。如果客户端不设置，那么取服务端配置同步的地址</param>
        /// <param name="exOrderno">外部订单号，长度小于50字节的字符串，本字段不能为空，且字段中不能有”&”或者”=”字符</param>
        /// <param name="price">开放价格策略填真实兑换的金额(单位为分)。其他策略填0</param>
        /// <param name="cpprivateinfo">商户私有信息。最大长度 128。本字段不能为空，且字段中不能有”&”或者”=”字符。</param>
        public void setPayParameter(String appKey, String appId, String waresId, String notifyUrl, String exOrderno,
            String price, String cpprivateinfo)
        {
            this.appKey = appKey;
            this.appId = appId;
            this.waresId = waresId;
            this.notifyUrl = notifyUrl;
            this.exOrderno = exOrderno;
            this.price = price;
            this.cpprivateinfo = cpprivateinfo;
        }

        /// <summary>
        /// 平台类型
        /// </summary>
        public string type { get { return PlatformNameEnum.ANDROID_LENOVO.ToString(); } }

        /// <summary>
        /// 是否支持初始化操作
        /// </summary>
        public bool isSupportInit { get { return true; } }

        /// <summary>
        /// 是否支持登出
        /// </summary>
        public bool isSupportLogout { get { return false; } }

        /// <summary>
        /// 是否支持打开用户中心
        /// </summary>
        public bool isSupportUserCenter { get { return false; } }

        /// <summary>
        /// 是否支持打开悬浮按钮
        /// </summary>
        public bool isSupportShowToolbar { get { return false; } }

        /// <summary>
        /// 是否支持隐藏悬浮按钮
        /// </summary>
        public bool isSupportHideToolbar { get { return false; } }

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
        public bool isSupportAntiAddictionQuery { get{return false;} }

        /// <summary>
        /// 是否支持实名制注册
        /// </summary>
        public bool isSupportRealNameRegister { get{return false;} }

        /// <summary>
        /// 初始化
        /// </summary>
        public void init()
        {
            if (isSupportInit)
            {
                object[] parameter = new object[] { appKey };
                AllSdkPlatform.instance().callAndroidSdkFunction(SDKFunctionNameEnum.init.ToString(), parameter);
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
            object[] parameter = new object[] { appKey,appId,waresId,notifyUrl,exOrderno,price,cpprivateinfo };
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
