using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace allSdk
{

    public class AndroidAliPay : IPay
    {
        private string orderInfo;



        /// <summary>
        /// 初始化设置
        /// </summary>
        public void setInitParameter()
        {

        }

        /// <summary>
        /// 支付参数
        /// </summary>
        /// <param name="orderInfo">订单信息</param>
        public void setPayParameter(string orderInfo)
        {
            this.orderInfo = orderInfo;
        }

        /// <summary>
        /// 单一支付类路径（android 使用）
        /// </summary>
        public string singlepayClassPath { get { return "com.example.unityalipay.MainActivity"; } }
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
                AllSdkPay.instance().getMainCotext()
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
                AllSdkPay.instance().getMainCotext(),orderInfo
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
