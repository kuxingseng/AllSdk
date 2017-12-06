namespace Platform
{
    /// <summary>
    /// author chenshuai
    /// $Id$
    /// Create time:2016/10/12 10:53:54 
    /// </summary>
    ///
    public enum GameStatusEnum
    {
        /// <summary>
        /// 游戏初始化成功，仅触发一次
        /// </summary>
        InitSuccess,

        /// <summary>
        /// 登录成功。
        /// </summary>
        LoginSuccess,

        /// <summary>
        /// 创建角色成功。包含用户名及UID
        /// </summary>
        CreateRoleSuccess,

        /// <summary>
        /// 退出登录成功。
        /// </summary>
        LogOutSuccess,

        /// <summary>
        /// 用户等级提升。包含用户名及UID
        /// </summary>
        UserLevelUp,

        /// <summary>
        /// 用户登录且加载完成，主界面显示。包含用户名及UID
        /// </summary>
        MainUIShow,

        /// <summary>
        /// 游戏暂停（切换到后台）
        /// </summary>
        ApplicationPause,

        /// <summary>
        /// 游戏恢复（从后台恢复）
        /// </summary>
        ApplicationResume,
        
        /// <summary>
        /// 新手引导结束
        /// </summary>
        NewLeaderEnd
    }
}
