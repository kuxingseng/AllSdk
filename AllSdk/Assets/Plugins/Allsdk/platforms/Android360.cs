using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace allSdk
{
    /// <summary>
    /// author chenshuai
    /// $Id$
    /// Create time:2014/8/7 15:19:42 
    /// </summary>
    ///
    public class Android360:IPlatform
    {
        private bool isLandScape;
        private bool isBgTransparent;

        private String accessToken;
        private String qihooUserId;
        private  String amount;
        private String rate;
        private String productName;
        private String productId;
        private String notifyUri;
        private String appName;
        private String appUserName;
        private String appUserId;
        private String ext1;
        private String ext2;
        private String orderId;

        /// <summary>
        /// 设置初始化参数
        /// </summary>
        /// <param name="isLandScape">是否横屏显示界面</param>
        /// <param name="isBgTransparent">否以透明背景显示界面</param>
        public void setInitParameter(bool isLandScape, bool isBgTransparent)
        {
            this.isLandScape = isLandScape;
            this.isBgTransparent = isBgTransparent;
        }

        /// <summary>
        /// 设置支付参数
        /// </summary>
        /// <param name="accessToken">用户access token</param>
        /// <param name="qihooUserId">360账号id</param>
        /// <param name="amount">所购买商品金额, 以分为单位。金额大于等于100分，360SDK运行定额支付流程； 金额数为0，360SDK运行充值流程。</param>
        /// <param name="rate">人民币不游戏充值币的兑换比例，例如2，代表1元人民币可以兑换2个游戏币，整数。</param>
        /// <param name="productName">应用自定义的商品名称，建议中文，丌建议使用英文下逗号(,)和双引号("),最大10个中文字</param>
        /// <param name="productId">应用自定义的商品id，最大16字符</param>
        /// <param name="notifyUri">应用方提供的支付结果通知uri</param>
        /// <param name="appName">游戏戒应用名称，最大16中文字</param>
        /// <param name="appUserName">应用内的用户名称，如游戏角色名。 若应用内绑定360账号和应用账号（充值丌分区服，充到统一的用户账户，各区服角色均可使用），则可用360用户名，最大16中文字。</param>
        /// <param name="appUserId">应用分配给用户的id</param>
        /// <param name="ext1">应用扩展信息1，原样返回</param>
        /// <param name="ext2">应用扩展信息1，原样返回</param>
        /// <param name="orderId">应用订单号，应用内必须唯一，最大32字符</param>
        public void setPayParameter(String accessToken, String qihooUserId, String amount,String rate,
            String productName, String productId, String notifyUri, String appName, String appUserName,
            String appUserId, String ext1, String ext2, String orderId)
        {
            this.accessToken = accessToken;
            this.qihooUserId = qihooUserId;
            this.amount = amount;
            this.rate = rate;
            this.productName = productName;
            this.productId = productId;
            this.notifyUri = notifyUri;
            this.appName = appName;
            this.appUserName = appUserName;
            this.appUserId = appUserId;
            this.ext1 = ext1;
            this.ext2 = ext2;
            this.orderId = orderId;
        }

        /// <summary>
        /// 设置防沉迷查询参数
        /// </summary>
        /// <param name="qihooUserId">360账号id</param>
        /// <param name="accessToken">用户access token</param>
        public void setAntiAddictionQueryParameter(String qihooUserId, String accessToken)
        {
            this.qihooUserId = qihooUserId;
            this.accessToken = accessToken;
        }

        /// <summary>
        /// 设置实名制注册参数
        /// </summary>
        /// <param name="qihooUserId"></param>
        public void setRealNameRegisterParameter(String qihooUserId)
        {
            this.qihooUserId = qihooUserId;
        }

        /// <summary>
        /// 平台类型
        /// </summary>
        public string type { get { return PlatformNameEnum.ANDROID_360.ToString(); } }

        /// <summary>
        /// 是否支持初始化操作
        /// </summary>
        public bool isSupportInit { get { return true; }}

        /// <summary>
        /// 是否支持登出
        /// </summary>
        public bool isSupportLogout { get { return false; } }

        /// <summary>
        /// 是否支持打开用户中心
        /// </summary>
        public bool isSupportUserCenter { get { return true; } }

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
        public bool isSupportQuit { get { return true; } }

        /// <summary>
        /// 是否支持向sdk发送信息、统计信息等
        /// </summary>
        public bool isSupportSendMessageToSdk { get { return false; } }

        /// <summary>
        /// 是否支持防沉迷查询
        /// </summary>
        public bool isSupportAntiAddictionQuery { get { return true; } }

        /// <summary>
        /// 是否支持实名制注册
        /// </summary>
        public bool isSupportRealNameRegister { get { return true; } }

        /// <summary>
        /// 初始化
        /// </summary>
        public void init()
        {
            if (isSupportInit)
            {
                object[] parameter = new object[] { isLandScape, isBgTransparent };
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
            object[] parameter = new object[]
            {
                accessToken,qihooUserId,amount,rate,productName,productId,
                notifyUri,appName,appUserName,appUserId,ext1,ext2,orderId
            };
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
            {
                AllSdkPlatform.instance().callAndroidSdkFunction(SDKFunctionNameEnum.userCenter.ToString());
            }
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
            {
                AllSdkPlatform.instance().callAndroidSdkFunction(SDKFunctionNameEnum.quit.ToString());
            }  
        }

        /// <summary>
        ///向sdk发送消息
        /// </summary>
        public void sendMessageToSDK()
        {
            if (isSupportSendMessageToSdk)
            {   
                AllSdkPlatform.instance().callAndroidSdkFunction(SDKFunctionNameEnum.sendMessageToSDK.ToString());
            }   
        }

        /// <summary>
        /// 防沉迷查询
        /// </summary>
        public void antiAddictionQuery()
        {
            if (isSupportAntiAddictionQuery)
            {
                object[] parameter = new object[] { qihooUserId, accessToken };
                AllSdkPlatform.instance().callAndroidSdkFunction(SDKFunctionNameEnum.antiAddictionQuery.ToString(), parameter);
            }   
        }

        /// <summary>
        /// 实名制注册
        /// </summary>
        public void realNameRegister()
        {
            if (isSupportRealNameRegister)
            {
                object[] parameter = new object[] {  qihooUserId };
                AllSdkPlatform.instance().callAndroidSdkFunction(SDKFunctionNameEnum.realNameRegister.ToString(), parameter);
            }   
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
