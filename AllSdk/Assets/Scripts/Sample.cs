namespace Assets.Scripts
{
    using Platform;
    using UnityEngine;
    using UnityEngine.UI;

    /// <summary>
    /// author chenshuai
    /// $Id:$
    /// Create time:2017/12/6 16:36:40 
    /// Desc:
    /// </summary>
    ///
    public class Sample:MonoBehaviour
    {
        public Button InitButton;
        public Button LoginButton;
        public Button PayButton;
        public Button UserCenterButton;
        public Button LogoutButton;

        public Text LogText;

        private void Start()
        {
            InitButton.onClick.AddListener(() =>
            {
                LogText.text = "初始化...";
                PassportController.Instance().InitSdk();
            });

            LoginButton.onClick.AddListener(() => {
                LogText.text = "登录...";
                PassportController.Instance().Login(log=>LogText.text = "登录成功:"+log);
            });

            PayButton.onClick.AddListener(() =>
            {
                LogText.text = "支付...";
                PassportController.Instance().Recharge(new RechargeItemInfo {Money = 6},"test");
            });

            UserCenterButton.onClick.AddListener(() =>
            {
                LogText.text = "用户中心...";
                PassportController.Instance().ShowPlatUserCenter();
            });

            LogoutButton.onClick.AddListener(() =>
            {
                LogText.text = "登出...";
                PassportController.Instance().Logout();
            });
        }
    }
}
