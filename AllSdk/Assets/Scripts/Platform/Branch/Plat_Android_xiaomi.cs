namespace Platform.Branch
{
    using allSdk;

    /// <summary>
    /// author chenshuai
    /// $Id$
    /// Create time:2016/10/12 11:16:29 
    /// </summary>
    ///
    public class Plat_Android_xiaomi:IPassport
    {
        private readonly AndroidXiaomi mXiaomi = new AndroidXiaomi();
        
        /// <summary>
        /// 初始化SDK数据。
        /// </summary>
        public IPlatform GetInitSdkvo()
        {
            mXiaomi.setInitParameter("2882303761517517681", "5401751787681");
            return mXiaomi;
        }

        /// <summary>
        /// 平台登录数据
        /// </summary>
        public IPlatform GetLoginVO()
        {
            return mXiaomi;
        }

        /// <summary>
        /// 用户中心数据 
        /// </summary>
        public IPlatform GetUserCenterVO()
        {
            return mXiaomi;
        }

        /// <summary>
        /// 退出登录数据
        /// </summary>
        public IPlatform GetLogoutVO()
        {
            return mXiaomi;
        }

        /// <summary>
        /// 购买前是否需要获取订单号
        /// </summary>
        public bool NeedGetServerOrder { get { return true; } }

        /// <summary>
        /// 获取订单号的地址
        /// </summary>
        public string GetOrderPath { get { return null; } }

        /// <summary>
        /// 支付数据
        /// </summary>
        public IPlatform GetRechargeVO(RechargeItemInfo goods, string orderData = null)
        {
            //todo:get the real user info
            var userInfo = "";
//            mXiaomi.setPayParameter(orderData, "钻石", goods.Money.ToString(), "", userInfo.Vip.ToString(), userInfo.level.ToString(),
//                "", userInfo.nickname, userInfo.puid,"");
            mXiaomi.setPayParameter(orderData, "钻石", goods.Money.ToString(), "", "10", "10","", "nickname", "puid001", "");
            return mXiaomi;
        }

        /// <summary>
        /// 设置游戏运行状态
        /// </summary>
        public void SetGameStatus(GameStatusEnum gameStatus, string nickname = null, string uid = null)
        {
            //设置统计用
        }

        /// <summary>
        /// 获取支付列表地址
        /// </summary>
        public string GetPayListPath { get { return ""; } }

        /// <summary>
        /// 是否使用默认的退出方式（安卓使用）
        /// </summary>
        public bool UseDefaultQuit { get { return true; } }

        /// <summary>
        /// 处理退出事件（安卓使用）
        /// </summary>
        public void QuiteAction()
        {
            
        }

        /// <summary>
        /// 点击了home键（安卓使用）
        /// </summary>
        public void HomeInputAction()
        {
            
        }
    }
}
