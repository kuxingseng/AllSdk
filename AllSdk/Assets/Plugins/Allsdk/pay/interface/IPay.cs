using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace allSdk
{

    public interface IPay
    {
        /// <summary>
        /// 是否有初始化操作
        /// </summary>
        bool isSupportInit { get; }

        /// <summary>
        /// 初始化
        /// </summary>
        void init();

        /// <summary>
        /// 支付
        /// </summary>
        void pay();

		/// <summary>
		/// 注册监听对象
		/// </summary>
		void registerMessageReceiver(string gameName);

        /// <summary>
        ///向sdk发送消息
        /// </summary>
        void sendMessageToSDK();

        string getsinglepayClassPath();
    }
}
