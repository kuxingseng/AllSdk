using UnityEngine;
using System.Collections;
using System.Linq;
using System.Text;

namespace allSdk
{
    public class AndroidYK : IPlatform
    {
        //String Amount, String OrderId, String NotifyUri, String ProductId, String ProductName
        public string Amount;
        public string OrderId;
        public string NotifyUri;
        public string ProductId;
        public string ProductName;


/// <summary>
/// 设置支付参数
/// </summary>
/// <param name="Amount"></param>
/// <param name="OrderId"></param>
/// <param name="NotifyUri"></param>
/// <param name="ProductId"></param>
/// <param name="ProductName"></param>
        public void setPayParameter(string Amount, string OrderId, string NotifyUri, string ProductId, string ProductName)
        {
            this.Amount = Amount;
            this.OrderId = OrderId;
            this.NotifyUri = NotifyUri;
            this.ProductId = ProductId;
            this.ProductName = ProductName;
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
        /// Gets a value indicating whether this <see cref="allSdk.IosFieliu"/> is support send message to sdk.
        /// </summary>
        /// <value><c>true</c> if is support send message to sdk; otherwise, <c>false</c>.</value>
        public bool isSupportSendMessageToSdk { get { return false; } }

        /// <summary>
        /// 是否支持防沉迷查询
        /// </summary>
        public bool isSupportAntiAddictionQuery { get { return false; } }

        /// <summary>
        /// 是否支持实名制注册
        /// </summary>
        public bool isSupportRealNameRegister { get { return false; } }


     //=========================================================================================================================================
        /// <summary>
        /// 初始化
        /// </summary>
        public void init()
        {
            if (!isSupportInit)
                return;

            AllSdkPlatform.instance().callAndroidSdkFunction(SDKFunctionNameEnum.init.ToString());
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
            object[] parameter = new object[] {  this.Amount, this.OrderId, this.NotifyUri, this.ProductId, this.ProductName };
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