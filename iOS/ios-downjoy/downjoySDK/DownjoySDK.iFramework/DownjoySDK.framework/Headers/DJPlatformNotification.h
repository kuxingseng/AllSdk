//
//  DJPlatformNotification.h
//  DownjoySDK2.0
//
//  Created by soon on 13-10-10.
//  Copyright (c) 2013年 downjoy. All rights reserved.
//

#import <UIKit/UIKit.h>

#ifndef DownjoySDK2_0_DJPlatformNotification_h
#define DownjoySDK2_0_DJPlatformNotification_h

//常用通知
UIKIT_EXTERN NSString *const kDJPlatformLoginResultNotification;              //登录成功通知
UIKIT_EXTERN NSString *const kDJPlatformRigisterNotification;                    //注册成功通知
UIKIT_EXTERN NSString *const kDJPlatformLogoutResultNotification;            //登出完成后通知
UIKIT_EXTERN NSString *const kDJPlatformPaymentResultNotification;          //支付结果通知
UIKIT_EXTERN NSString *const kDJPlatformRechargeResultNotification;         //充值结果通知

//进入（退出）SDK需要暂停（继续）游戏的可监听下面两个通知
UIKIT_EXTERN NSString *const kDJPlatformOpenNotification;                        //当乐SDK开启通知
UIKIT_EXTERN NSString *const kDJPlatformCloseNotification;                        //当乐SDK关闭通知

//不常用通知
UIKIT_EXTERN NSString *const kDJPlatformErrorNotification;                         //调用接口出错时通知
UIKIT_EXTERN NSString *const kDJPlatfromAlixQuickPayEnd;                         //支付宝快捷支付结束通知


#endif
