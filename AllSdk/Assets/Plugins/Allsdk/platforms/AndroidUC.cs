using UnityEngine;
using System.Collections;
using System.Linq;
using System.Text;

namespace allSdk
{
    public class AndroidUC : IPlatform
    {
        public int CpId;
        public int GameId;
        public int ServerId;

        //String customArg, int ServerId, String RoleId, String RoleName, String Grade, String NotifyUrl, int Amount
        public string customArg;
        public string RoleId;
        public string RoleName;
        public string Grade;
        public string NotifyUrl;
        public int Amount;

        public string zoneId;
        public string zoneName;


        //=========================================================================================================================================
        /// <summary>
        /// 设置初始化参数
        /// </summary>
        /// <param name="CpId">CpId</param>
        /// <param name="GameId">厂商分配的 游戏ID</param>
        /// <param name="ServerId">ServerId</param>
        public void setInitParameter(int CpId, int GameId, int ServerId)
        {
            this.CpId = CpId;
            this.GameId = GameId;
            this.ServerId = ServerId;
        }
        /// <summary>
        /// 设置支付参数
        /// </summary>
        /// <param name="customArg">自定义参数 原样返回</param>
        /// <param name="ServerId">ServerId</param>
        /// <param name="RoleId">uId</param>
        /// <param name="RoleName">角色名字</param>
        /// <param name="Grade">Grade</param>
        /// <param name="NotifyUrl">回调地址（不需要）传空</param>
        /// <param name="Amount">总价</param>
        public void setPayParameter(string customArg, int ServerId, string RoleId, string RoleName, string Grade, string NotifyUrl, int Amount)
        {
            this.customArg = customArg;
            this.ServerId = ServerId;
            this.RoleId = RoleId;
            this.RoleName = RoleName;
            this.Grade = Grade;
            this.NotifyUrl = NotifyUrl;
            this.Amount = Amount;

        }

        public void setSendMessageTOSDKParameter(string RoleId, string RoleName, string Grade, string zoneId, string zoneName)
        {
            this.RoleId = RoleId;
            this.RoleName = RoleName;
            this.Grade = Grade;
            this.zoneId = zoneId;
            this.zoneName = zoneName;
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
        public bool isSupportShowToolbar { get { return true; } }

        /// <summary>
        /// 是否支持隐藏悬浮按钮
        /// </summary>
        public bool isSupportHideToolbar { get { return true; } }

        /// <summary>
        /// 是否支持退出操作
        /// </summary>
        public bool isSupportQuit { get { return true; } }

        /// <summary>
        /// Gets a value indicating whether this <see cref="allSdk.IosFieliu"/> is support send message to sdk.
        /// </summary>
        /// <value><c>true</c> if is support send message to sdk; otherwise, <c>false</c>.</value>
        public bool isSupportSendMessageToSdk { get { return true; } }

        /// <summary>
        /// 是否支持防沉迷查询
        /// </summary>
        public bool isSupportAntiAddictionQuery { get{return false;} }

        /// <summary>
        /// 是否支持实名制注册
        /// </summary>
        public bool isSupportRealNameRegister { get{return false;}}

        //=========================================================================================================================================
        /// <summary>
        /// 初始化
        /// </summary>
        public void init()
        {
            if (!isSupportInit)
                return;

            object[] parameter = new object[] { this.CpId, this.GameId, this.ServerId };
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
            object[] parameter = new object[] { this.customArg, this.ServerId, this.RoleId, this.RoleName, this.Grade, this.NotifyUrl, this.Amount };
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

            object[] parameter = new object[] { this.RoleId, this.RoleName, this.Grade, this.zoneId, this.zoneName };
            AllSdkPlatform.instance().callAndroidSdkFunction(SDKFunctionNameEnum.sendMessageToSDK.ToString(), parameter);
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
