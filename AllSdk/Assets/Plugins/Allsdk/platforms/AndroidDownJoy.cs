using UnityEngine;
using System.Collections;
using System.Linq;
using System.Text;

namespace allSdk
{
    public class AndroidDownJoy : IPlatform
    {
        public string merchantId;
        public string appId;
        public string serverSeqNum;
        public string appKey;


        public int money;
        public string productName;
        public string extInfo;

        //=========================================================================================================================================
        /// <summary>
        /// 设置初始化参数
        /// </summary>
        /// <param name="merchantId">接入时由当乐分配的厂商ID</param>
        /// <param name="appId">接入时由当乐分配的游戏/应用ID</param>
        /// <param name="serverSeqNum">接入时由当乐分配的服务器序列号，用以标识和使用不同的计费通知地址</param>
        /// <param name="appKey">接入时由当乐分配的游戏/应用密钥</param>
        public void setInitParameter(string merchantId, string appId, string serverSeqNum, string appKey)
        {
            //String merchantId, string appId, String serverSeqNum, String appKey
            this.merchantId = merchantId;
            this.appId = appId;
            this.serverSeqNum = serverSeqNum;
            this.appKey = appKey;
        }

        /// <summary>
        /// 设置支付参数
        /// </summary>
        /// <param name="money">支付总额，单位：元</param>
        /// <param name="productName">商品名称</param>
        /// <param name="extInfo">cp 自定义信息，计费结果通知时原样返回</param>
        public void setPayParameter(int money, string productName, string extInfo)
        {
            this.money = money;
            this.productName = productName;
            this.extInfo = extInfo;
        }

        //=========================================================================================================================================
        /// <summary>
        /// 平台类型
        /// </summary>
        public string type { get; private set; }

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
        /// Gets a value indicating whether this <see cref="allSdk.IosFieliu"/> is support send message to sdk.
        /// </summary>
        /// <value><c>true</c> if is support send message to sdk; otherwise, <c>false</c>.</value>
        public bool isSupportSendMessageToSdk { get { return false; } }

        /// <summary>
        /// 是否支持防沉迷查询
        /// </summary>
        public bool isSupportAntiAddictionQuery { get{return false;} }

        /// <summary>
        /// 是否支持实名制注册
        /// </summary>
        public bool isSupportRealNameRegister { get{return false;} }

        //=========================================================================================================================================
        /// <summary>
        /// 初始化
        /// </summary>
        public void init()
        {
            if (!isSupportInit)
                return;

            object[] parameter = new object[] { merchantId, appId, serverSeqNum, appKey };
            AllSdkPlatform.instance().callAndroidSdkFunction(SDKFunctionNameEnum.init.ToString(), parameter);
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
            object[] parameter = new object[] { money, productName, extInfo };
            AllSdkPlatform.instance().callAndroidSdkFunction(SDKFunctionNameEnum.pay.ToString(), parameter);
        }

        /// <summary>
        /// 登出
        /// </summary>
        public void logout()
        {
            if (!isSupportLogout)
                return;

            AllSdkPlatform.instance().callAndroidSdkFunction(SDKFunctionNameEnum.logout.ToString());
        }

        /// <summary>
        /// 打开用户中心
        /// </summary>
        public void userCenter()
        {
            if (!isSupportUserCenter)
                return;

            AllSdkPlatform.instance().callAndroidSdkFunction(SDKFunctionNameEnum.userCenter.ToString());
        }

        /// <summary>
        /// 显示悬浮菜单
        /// </summary>
        public void showToolBar()
        {
            if (!isSupportShowToolbar)
                return;

            AllSdkPlatform.instance().callAndroidSdkFunction(SDKFunctionNameEnum.showToolBar.ToString());
        }

        /// <summary>
        /// 隐藏悬浮菜单
        /// </summary>
        public void hideToolBar()
        {
            if (!isSupportHideToolbar)
                return;

            AllSdkPlatform.instance().callAndroidSdkFunction(SDKFunctionNameEnum.hideToolBar.ToString());
        }

        /// <summary>
        /// 退出游戏
        /// </summary>
        public void quit()
        {
            if (!isSupportQuit)
                return;

            AllSdkPlatform.instance().callAndroidSdkFunction(SDKFunctionNameEnum.quit.ToString());
        }

        //=========================================================================================================================================
        /// <summary>
        /// send message to sdk.
        /// </summary>
        public void sendMessageToSDK()
        {
            if (!isSupportSendMessageToSdk)
                return;

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
