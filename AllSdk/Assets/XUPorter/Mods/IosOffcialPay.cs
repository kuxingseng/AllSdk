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
    /// Create time:2014/8/8 11:26:52 
    /// </summary>
    ///
    public class IosOffcialPay:IPay
    {
#if UNITY_IPHONE
        [DllImport("__Internal")]
        public static extern void iosOfficalPay(string productId);

		[DllImport("__Internal")]
		public static extern void iosOfficalPayRegisterMessageReceiver(string gameObjectName);
		
		[DllImport("__Internal")]
		public static extern void iosOfficalPayUnRegisterMessageReceiver(string gameObjectName);
#endif

        private string productId;

        /// <summary>
        /// 设置苹果官方支付参数
        /// </summary>
        /// <param name="productId"></param>
        public void setPayParameter(string productId)
        {
            this.productId = productId;
        }

        /// <summary>
        /// 是否有初始化操作
        /// </summary>
        public bool isSupportInit { get { return false; } }

        /// <summary>
        /// 初始化
        /// </summary>
        public void init()
        {
            
        }

        /// <summary>
        /// 支付
        /// </summary>
        public void pay()
        {
#if UNITY_IPHONE
            iosOfficalPay(productId);
#endif
        }

		/// <summary>
		/// 注册监听对象
		/// </summary>
		/// <param name="gameName">Game name.</param>
		public void registerMessageReceiver(string gameName)
		{
#if UNITY_IPHONE
			iosOfficalPayRegisterMessageReceiver (gameName);
#endif
		}

        /// <summary>
        ///向sdk发送消息
        /// </summary>
        public void sendMessageToSDK()
        {
            throw new NotImplementedException();
        }

        public string getsinglepayClassPath()
        {
            throw new NotImplementedException();
        }
    }
}
