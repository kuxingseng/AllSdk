using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace allSdk
{
    using System.Security.Policy;

    /// <summary>
    /// author chenshuai
    /// $Id$
    /// Create time:2014/8/14 17:41:43 
    /// </summary>
    ///
    public class IosAisi:IPlatform
    {
        private string appId;
        private string appKey;

        private string price;
        private string billNo;
        private string billTitle;
        private string roleId;
        private string zoneId;


        /// <summary>
        /// 设置初始化参数
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="appKey"></param>
        public void setInitParameter(string appId, string appKey)
        {
            this.appId = appId;
            this.appKey = appKey;
        }

        /// <summary>
        /// 设置支付参数
        /// </summary>
        /// <param name="price">商品价格（必须是⼤大于等于1的整数）</param>
        /// <param name="billNo">⼚厂商订单号，由⼚厂商服务器⽣生成</param>
        /// <param name="billTitle">订单标题</param>
        /// <param name="roleId">游戏⾓角⾊色id（为0表⽰示忽略）</param>
        /// <param name="zoneId">分区id（需要和开发者后台的分区编号对应，如果没有分区则传⼊入0）</param>
        public void setPayParameter(string price, string billNo, string billTitle, string roleId, string zoneId)
        {
            this.price = price;
            this.billNo = billNo;
            this.billTitle = billTitle;
            this.roleId = roleId;
            this.zoneId = zoneId;
        }
        /// <summary>
        /// 平台类型
        /// </summary>
        public string type { get { return PlatformNameEnum.IOS_AISI.ToString(); } }

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
#if UNITY_IPHONE
            string parameter = appId + "," + appKey ;
            AllSdkPlatform.sdkInit(parameter);
#endif
        }

        /// <summary>
        /// 登录
        /// </summary>
        public void login()
        {
#if UNITY_IPHONE
			AllSdkPlatform.sdkLogin ();
#endif
        }

        /// <summary>
        /// 支付
        /// </summary>
        public void pay()
        {   
#if UNITY_IPHONE
			string parameter = price + "," + billNo+","+billTitle+","+roleId+","+zoneId;
			AllSdkPlatform.sdkPay (parameter);
#endif
        }

        /// <summary>
        /// 登出
        /// </summary>
        public void logout()
        {
#if UNITY_IPHONE
			AllSdkPlatform.sdkLogout ();
#endif
        }

        /// <summary>
        /// 打开用户中心
        /// </summary>
        public void userCenter()
        {
#if UNITY_IPHONE
			AllSdkPlatform.sdkUserCenter ();
#endif
        }

        /// <summary>
        /// 显示悬浮菜单
        /// </summary>
        public void showToolBar()
        {
            
        }

        /// <summary>
        /// 隐藏悬浮菜单
        /// </summary>
        public void hideToolBar()
        {
            
        }

        /// <summary>
        /// 退出游戏
        /// </summary>
        public void quit()
        {
            
        }

        /// <summary>
        ///向sdk发送消息
        /// </summary>
        public void sendMessageToSDK()
        {
            
        }

        /// <summary>
        /// 防沉迷查询
        /// </summary>
        public void antiAddictionQuery()
        {
            
        }

        /// <summary>
        /// 实名制注册
        /// </summary>
        public void realNameRegister()
        {
           
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
