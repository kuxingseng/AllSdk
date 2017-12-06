namespace Platform.Branch
{
    using allSdk;

    /// <summary>
    /// author chenshuai
    /// $Id$
    /// Create time:2016/10/12 10:42:40 
    /// </summary>
    ///
    public interface IPassport
    {
        /// <summary>
        /// 初始化SDK数据。
        /// </summary>
        IPlatform GetInitSdkvo();
        /// <summary>
        /// 平台登录数据
        /// </summary>
        IPlatform GetLoginVO();
        /// <summary>
        /// 用户中心数据 
        /// </summary>
        IPlatform GetUserCenterVO();
        /// <summary>
        /// 退出登录数据
        /// </summary>
        IPlatform GetLogoutVO();
        /// <summary>
        /// 购买前是否需要获取订单号
        /// </summary>
        bool NeedGetServerOrder { get; }
        /// <summary>
        /// 获取订单号的方法名
        /// </summary>
        string GetOrderPath { get; }
        /// <summary>
        /// 支付数据
        /// </summary>
        IPlatform GetRechargeVO(RechargeItemInfo goods, string orderData = null);
        /// <summary>
        /// 设置游戏运行状态
        /// </summary>
        void SetGameStatus(GameStatusEnum gameStatus, string nickname = null, string uid = null);
        /// <summary>
        /// 获取支付列表地址
        /// </summary>
        string GetPayListPath { get; }
        /// <summary>
        /// 是否使用默认的退出方式（安卓使用）
        /// </summary>
        bool UseDefaultQuit { get; }
        /// <summary>
        /// 处理退出事件（安卓使用）
        /// </summary>
        void QuiteAction();
        /// <summary>
        /// 点击了home键（安卓使用）
        /// </summary>
        void HomeInputAction();
    }
}
