using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace allSdk
{
    /// <summary>
    /// author chenshuai
    /// $Id$
    /// Create time:2014/9/2 14:16:30 
    /// </summary>
    ///
    public class AndroidOppo:IPlatform
    {
        private string appKey;
        private string appSecret;
        private bool isLandScape;

        private string orderId;
        private string attach;
        private int amount;
        private string productName;
        private string productDesc;
        private string callbackUrl;

        private int gameId;
        private string service;
        private string role;
        private string grade;

        /// <summary>
        /// 设置初始化参数
        /// </summary>
        /// <param name="appKey"></param>
        /// <param name="appSecret"></param>
        /// <param name="isLandScape"></param>
        public void setInitParameter(string appKey, string appSecret, bool isLandScape)
        {
            this.appKey = appKey;
            this.appSecret = appSecret;
            this.isLandScape = isLandScape;
        }

        /// <summary>
        /// 设置支付参数
        /// </summary>
        /// <param name="orderId">订单号，保证每次请求唯一，限制长度100</param>
        /// <param name="attach">自定义回调字段，限制长度200</param>
        /// <param name="amount">消耗可币的金额，单位为分（1可币=1RMB）</param>
        /// <param name="productName">商品名称，限制长度50</param>
        /// <param name="productDesc">商品描述，限制长度100</param>
        /// <param name="callbackUrl">回调地址，不可带参数</param>
        public void setPayParameter(string orderId, string attach, int amount, string productName,
            string productDesc, string callbackUrl)
        {
            this.orderId = orderId;
            this.attach = attach;
            this.amount = amount;
            this.productName = productName;
            this.productDesc = productDesc;
            this.callbackUrl = callbackUrl;
        }

        /// <summary>
        /// 设置发送只sdk的信息
        /// </summary>
        /// <param name="gameId">游戏id,开发者后台申请</param>
        /// <param name="service">用户所在区服</param>
        /// <param name="role">角色名称</param>
        /// <param name="grade">角色等级</param>
        public void setSendMessageParameter(int gameId, string service, string role, string grade)
        {
            this.gameId = gameId;
            this.service = service;
            this.role = role;
            this.grade = grade;
        }

        /// <summary>
        /// 平台类型
        /// </summary>
        public string type { get { return PlatformNameEnum.ANDROID_OPPO.ToString(); } }

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
        public bool isSupportSendMessageToSdk { get { return true; } }

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
                object[] parameter = new object[] { appKey, appSecret, isLandScape };
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
            object[] parameter = new object[] { orderId,attach,amount,productName,productDesc,callbackUrl };
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
            {
                object[] parameter = new object[] { gameId,service,role,grade };
                AllSdkPlatform.instance().callAndroidSdkFunction(SDKFunctionNameEnum.sendMessageToSDK.ToString(), parameter);
            }
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
