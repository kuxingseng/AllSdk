using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace allSdk
{
    /// <summary>
    /// author chenshuai
    /// $Id$
    /// Create time:2014/8/27 15:47:51 
    /// </summary>
    ///
    public class IosTalkingData:IStatistic
    {
#if UNITY_IPHONE
		[DllImport ("__Internal")]
		public static extern void statisticInitForTalkingdata (string appKey, string channelId);
		
		[DllImport ("__Internal")]
		public static extern void statisticSendInfoForTalkingdata (string infoType, string userId, string orderId, string amount, string currency);
	
#endif

        /// <summary>
        /// 发送消息类型
        /// </summary>
        private string infoType;

        private string appKey;
        private string channelId;

        private string userId;
        private string orderId;
        private int amount;
        private string currency;

        /// <summary>
        /// 设置初始化参数
        /// </summary>
        /// <param name="appKey"></param>
        /// <param name="channelId"></param>
        public void setInitParameter(string appKey, string channelId)
        {
            this.appKey = appKey;
            this.channelId = channelId;
        }

        /// <summary>
        /// 设置注册参数
        /// </summary>
        /// <param name="userId"></param>
        public void setRegisterParameter(string userId)
        {
            this.infoType = TalkingdataFunctionEnum.onRegister.ToString();
            this.userId = userId;
        }

        /// <summary>
        /// 设置登录参数
        /// </summary>
        /// <param name="userId"></param>
        public void setLoginParameter(string userId)
        {
            this.infoType = TalkingdataFunctionEnum.onLogin.ToString();
            this.userId = userId;
        }

        /// <summary>
        /// 设置支付成功参数
        /// </summary>
        /// <param name="userId">设定帐户唯一标识，用于区分一个用户，最多64 个字符</param>
        /// <param name="orderId">订单ID，最多64 个字符。用于唯一标识一次交易</param>
        /// <param name="amount">现金金额或现金等价物的额度，货币单位为分，币种以后面的currrency 为标准</param>
        /// <param name="currency">请使用国际标准组织ISO 4217 中规范的3 位字母代码标记货币类型。目前支持的货币种类有：人民币CNY，港元 HKD，台币：TWD，美元USD；欧元EUR；英镑 GBP，日元 JPY</param>
        public void setPayParameter(string userId, string orderId, int amount, string currency)
        {
            this.infoType = TalkingdataFunctionEnum.onPay.ToString();
            this.userId = userId;
            this.orderId = orderId;
            this.amount = amount;
            this.currency = currency;
        }

        /// <summary>
        /// 设置自定事件类型
        /// </summary>
        /// <param name="customerType"></param>
        public void setCustomeParameter(TalkingdataFunctionEnum customerType)
        {
            this.infoType = customerType.ToString();
        }

        /// <summary>
        /// 统计插件类路径（android 使用）
        /// </summary>
        public string statisticClassPath { get; private set; }

        /// <summary>
        /// 是否有初始化操作
        /// </summary>
        public bool isSupportInit { get { return true; } }

        /// <summary>
        /// 是否可发送信息
        /// </summary>
        public bool isSupportSendInfo { get { return true; } }

        /// <summary>
        /// 是否可获取信息
        /// </summary>
        public bool isSupportGetInfo { get { return false; } }

        /// <summary>
        /// 初始化统计插件
        /// </summary>
        public void initStatistic()
        {
#if UNITY_IPHONE
			if(isSupportInit){
				statisticInitForTalkingdata(this.appKey,this.channelId);
			}
#endif
        }

        /// <summary>
        /// 发送统计数据
        /// </summary>
        public void sendInfo()
        {
#if UNITY_IPHONE
			if(isSupportSendInfo){
				statisticSendInfoForTalkingdata(this.infoType,this.userId,this.orderId,this.amount.ToString(),this.currency);
			}
#endif
        }

        /// <summary>
        /// 获取信息
        /// </summary>
        public string getInfo()
        {
            return "";
        }
    }
}
