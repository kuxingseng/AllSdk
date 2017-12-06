using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace allSdk
{
    /// <summary>
    /// author chenshuai
    /// $Id$
    /// Create time:2014/7/29 17:15:34 
    /// </summary>
    ///
    public enum StatisticFunctionEnum
    {
        sendInfo,           //发送统计数据
        initStatistic,      //初始化统计sdk
        getInfo             //获取sdk信息
    }

    /// <summary>
    /// talkingata发送消息事件定义
    /// </summary>
    public enum TalkingdataFunctionEnum
    {          
        onResume,   //
        onPause,      
        setAccount,        //设置账号
        onEvent,    //自定义事件

        onRegister,   //注册
        onLogin,      //登录
        onPay,        //支付
        onCustEvent1,    //自定义事件1
        onCustEvent2,    //自定义事件2
        onCustEvent3,    //自定义事件3
        onCustEvent4,    //自定义事件4
        onCustEvent5,    //自定义事件5
        onCustEvent6,    //自定义事件6
        onCustEvent7,    //自定义事件7
        onCustEvent8,    //自定义事件8
        onCustEvent9,    //自定义事件9
        onCustEvent10    //自定义事件10
    }
    
}
