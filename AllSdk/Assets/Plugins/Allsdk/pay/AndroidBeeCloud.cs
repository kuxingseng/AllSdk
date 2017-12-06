using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace allSdk
{

    public class AndroidBeeCloud : IPay
    {
        private string appId;
        private string appKey;
        private string wxId;
        private string isSandbox;

        private string channelType;
        private string desc;
        private string price;
        private string billNum;



        /// <summary>
        /// 初始化设置
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="appKey"></param>
        /// <param name="isSandbox">1:true;0:false</param>
        /// <param name="wxId">微信支付id，没有则""</param>
        public void setInitParameter(string appId,string appKey,string isSandbox,string wxId = "")
        {
            this.appId = appId;
            this.appKey = appKey;
            this.isSandbox = isSandbox;
            this.wxId = wxId;
        }

        /// <summary>
        /// 支付参数
        /// </summary>
        /// <param name="channelType">渠道类型：0：微信；1：支付宝；2：银联支付3：百度钱包</param>
        /// <param name="desc">商品描述</param>
        /// <param name="price">价格，单位：分</param>
        /// <param name="billNum">商户自定义订单号，不能重复</param>
        public void setPayParameter(string channelType,string desc,string price,string billNum)
        {
            this.channelType = channelType;
            this.desc = desc;
            this.price = price;
            this.billNum = billNum;
        }

        /// <summary>
        /// 单一支付类路径（android 使用）
        /// </summary>
        public string singlepayClassPath { get { return "com.example.unitybeecloud.MainActivity"; } }
        /// <summary>
        /// 是否有初始化操作
        /// </summary>
        public bool isSupportInit { get { return true; } }

        /// <summary>
        /// 初始化
        /// </summary>
        public void init()
        {
            object[] parameter = new object[]
            {
                AllSdkPay.instance().getMainCotext(),appId,appKey,isSandbox,wxId
            };
            AllSdkPay.instance().callAndroidSdkStaticFunction(SDKFunctionNameEnum.init.ToString(), parameter, singlepayClassPath);
        }

        /// <summary>
        /// 支付
        /// </summary>
        public void pay()
        {
            object[] parameter = new object[]
            {
                channelType,desc,price,billNum
            };
            AllSdkPay.instance().callAndroidSdkStaticFunction(SDKFunctionNameEnum.pay.ToString(), parameter, singlepayClassPath);
        }

        /// <summary>
        ///向sdk发送消息
        /// </summary>
        public void sendMessageToSDK()
        {
            object[] parameter = new object[]
            {
               
            };
            AllSdkPay.instance().callAndroidSdkStaticFunction(SDKFunctionNameEnum.sendMessageToSDK.ToString(), parameter, singlepayClassPath);
        }

        /// <summary>
        /// 注册监听对象
        /// </summary>
        /// <param name="gameName">Game name.</param>
        public void registerMessageReceiver(string gameName)
        {

        }

        public string getsinglepayClassPath()
        {
            return singlepayClassPath;
        }
    }
}
