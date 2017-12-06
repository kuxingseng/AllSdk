//
//  DJPlatform.h
//  DownjoySDK2.0
//
//  Created by soon on 13-9-27.
//  Copyright (c) 2013年 downjoy. All rights reserved.
//

#import <UIKit/UIKit.h>

@class UserInfomation;

typedef enum {
    RechangeResultTypeSuccess = 0,     //充值成功
    RechangeResultTypeFail,                  //充值失败
    RechangeResultTypeWait,                //充值等待
}RechangeResultType;

typedef enum {
    PaymentResultTypeFinish = 0,   //支付完成
    PaymentResultTypeUnfinish,      //支付未完成
    PaymentResultTypeCancel      //支付取消
}PaymentResultType;
typedef enum {
    TopLeftPosition=1,   //上左
    TopMiddlePosition,   //上中
    TopRightPosition,   //上右
    
    CenterLeftPosition,   //中左
    CenterRightPosition,   //中右
    
    BottomLeftPosition,   //上左
    BottomMiddlePosition,   //上中
    BottomRightPosition,   //上右
}AssistivePositionType;
@interface DJPlatform : NSObject

@property (copy, nonatomic) NSString *merchantId;
@property (copy, nonatomic) NSString *appId;
@property (copy, nonatomic) NSString *appKey;
@property (copy, nonatomic) NSString *serverId;
@property (copy, nonatomic) NSString *channelId;
@property (copy, nonatomic) NSString *appScheme;

@property (nonatomic, assign) AssistivePositionType  assistivePosition;//设置浮漂按钮在屏幕中的位置

//未设置assistivePosition情况下，也可以自定义浮漂坐标中心位置,二者只需设其一
@property (nonatomic, assign) CGPoint  assistiveCoordinate;

@property (readonly, nonatomic) UserInfomation *userInfomation;

@property (assign, nonatomic) BOOL hasAmountInputBox; //设置订单支付是否可输入金额

//返回一个SDK对象
+(DJPlatform *) defaultDJPlatform;

//设置屏幕方向
- (void) setDJScreenOrientation:(UIInterfaceOrientationMask) screenOrientation;

//获取用户Mid（乐号）
- (NSString *) currentMemberId;

//获取用户Token
- (NSString *) currentToken;

//登陆状态
- (BOOL) DJCheckLoginStatus;

//登陆
- (void) DJLogin;

//注销
- (void) DJLogout;

//个人中心
- (void) appearDJMemberCenter;

//隐藏个人中心
- (void) disappearDJMemberCenterWithNotification:(BOOL) flag;

//设置当乐快捷按钮是否隐藏
- (void) setDJAssistiveTouchHidden:(BOOL) hidden;

//请求会员信息
-(UserInfomation *) DJReadMemberInfo;

//充值&消费
 //建议extInfo不要传中文，可能会出现问题
-(void) DJPayment:(float)money productName:(NSString *)productName extInfo:(NSString *)extInfo;

//当乐钱包充值
- (void) DJpaymentForDJWallet:(NSString *) extInfo;

//设置自动登陆
-(void) setIsAutoLogin:(BOOL)isAuto;

//***************************************
//cocos2dx可能要用到
- (void) setDJRootView:(UIView *)view;

@end
