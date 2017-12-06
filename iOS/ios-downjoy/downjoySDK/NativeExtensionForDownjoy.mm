//
//  NativeExtensionForDownjoy.m
//  NativeExtensions
//
//  Created by chenshuai on 14-7-22.
//  Copyright (c) 2014年 muhe. All rights reserved.
//

#import "NativeExtensionForDownjoy.h"
#import <DownjoySDK/DJPlatform.h>
#import <DownjoySDK/UserInfomation.h>
#import <DownjoySDK/DJPlatformNotification.h>

static NSMutableArray *array = nil;

@implementation NativeExtensionForDownjoy

-(void)initSdk:(NSString *)appId appKey:(NSString*)appKey merchantId:(NSString*)merchantId serverId:(NSString*)serverId scheme:(NSString*)scheme hasAmountInputBox:(NSString*)hasAmountInputBox
{
    //添加监听
    [self receiveDJPlatformSDKNotification];
    
    //初始化SDK, 这些数据CP从我们的后台获取
    [[DJPlatform defaultDJPlatform] setAppId:appId];
    [[DJPlatform defaultDJPlatform] setAppKey:appKey];
    [[DJPlatform defaultDJPlatform] setMerchantId:merchantId];
    [[DJPlatform defaultDJPlatform] setServerId:serverId];
    
    //设置屏幕方向
    [[DJPlatform defaultDJPlatform] setDJScreenOrientation:UIInterfaceOrientationMaskLandscape];
    //设置浮漂在屏幕中的位置
    [[DJPlatform defaultDJPlatform] setAssistivePosition:BottomRightPosition];
    
    //设置是否隐藏当乐快捷按钮（建议显示出来）
    [[DJPlatform defaultDJPlatform] setDJAssistiveTouchHidden:NO];
    
    //设置购买道具是否有金额输入框（默认不显示）
    [[DJPlatform defaultDJPlatform] setHasAmountInputBox:[hasAmountInputBox boolValue]];
    
    //应用Scheme，在iOS系统中，app之间通信的ID，用支付宝快捷支付的时候需要
    [[DJPlatform defaultDJPlatform] setAppScheme:scheme];
    
    NSLog(@"appId:%@, appKey:%@, merchantId:%@, serverId:%@, scheme:%@, hasAmountInputBox:%@",appId,appKey,merchantId,serverId,scheme,[hasAmountInputBox boolValue]?@"YES":@"NO");
}

//登录接口
-(void)login
{
    [[DJPlatform defaultDJPlatform] DJLogin];
}

//个人中心接口
-(void)userCenter
{
    [[DJPlatform defaultDJPlatform] appearDJMemberCenter];
}

//当乐钱包充值
//extInfo  CP备注信息
-(void)payWallet
{
    [[DJPlatform defaultDJPlatform] DJpaymentForDJWallet:@"extInfo"];
}

//道具支付
//extInfo  CP备注信息
//建议extInfo不要传中文，可能会出现问题
-(void)pay:(NSString*)price porductName:(NSString*)productName extInfo:(NSString*)extInfo
{
    [[DJPlatform defaultDJPlatform] DJPayment:[price floatValue] productName:productName extInfo:extInfo];
}

//注销（登出）
-(void)logout
{
    [[DJPlatform defaultDJPlatform]DJLogout];
}

//切换账号
-(void)changeAccount
{
    [[DJPlatform defaultDJPlatform] setIsAutoLogin:NO];
    [[DJPlatform defaultDJPlatform] DJLogin];
}

- (void) receiveDJPlatformSDKNotification
{
    //登录成功回调
    [[NSNotificationCenter defaultCenter] addObserver:self
                                             selector:@selector(dealDJPlatformLoginResultNotify:)
                                                 name:kDJPlatformLoginResultNotification object:nil];
    //注册成功回调
    [[NSNotificationCenter defaultCenter] addObserver:self
                                             selector:@selector(dealDJPlatformRigisterNotify:)
                                                 name:kDJPlatformRigisterNotification object:nil];
    //注销（登出）回调
    [[NSNotificationCenter defaultCenter] addObserver:self
                                             selector:@selector(dealDJPlatformLogoutResultNotify:)
                                                 name:kDJPlatformLogoutResultNotification object:nil];
    //支付结果回调
    [[NSNotificationCenter defaultCenter] addObserver:self
                                             selector:@selector(dealDJPlatformPaymentResultNotify:)
                                                 name:kDJPlatformPaymentResultNotification object:nil];
    //充值结果回调
    [[NSNotificationCenter defaultCenter] addObserver:self
                                             selector:@selector(dealDJPlatformRechargeResultNotify:)
                                                 name:kDJPlatformRechargeResultNotification object:nil];
    //CP如果关心开启和关闭SDK，则监听下面两个通知（游戏需要暂停、恢复的）
    //开启SDK
    [[NSNotificationCenter defaultCenter] addObserver:self
                                             selector:@selector(dealDJPlatformOpenNotify:)
                                                 name:kDJPlatformOpenNotification object:nil];
    //关闭SDK
    [[NSNotificationCenter defaultCenter] addObserver:self
                                             selector:@selector(dealDJPlatformCloseNotify:)
                                                 name:kDJPlatformCloseNotification object:nil];
    
}

//登录成功
-(void) dealDJPlatformLoginResultNotify:(NSNotification *) notify
{
    UserInfomation *memberInfo = [notify object]; //玩家信息
    //NSString *content=[NSString stringWithFormat:@"mid:%@,username:%@,nickname:%@,token:%@,avatar_url:%@, gender:%@", memberInfo.mid, memberInfo.userName, memberInfo.nickName, memberInfo.token, memberInfo.avatarUrl, memberInfo.gender];
    
    //NSLog(@"memberInfo:%@",content);
    
    NSString *param = @"{";
    param = [param stringByAppendingFormat:@"\"mid\":\"%@\"",memberInfo.mid];
    param = [param stringByAppendingFormat:@",\"userName\":\"%@\"",memberInfo.userName];
    param = [param stringByAppendingFormat:@",\"nickName\":\"%@\"",memberInfo.nickName];
    param = [param stringByAppendingFormat:@",\"token\":\"%@\"",memberInfo.token];
    param = [param stringByAppendingString:@"}"];
    
    [self sendU3dMessage:@"onLoginSuccess" param:param];
    
}

//注册成功（会同时发出登录成功的通知，如cp不关心注册结果，则只需监听登录通知即可）
-(void) dealDJPlatformRigisterNotify:(NSNotification *) notify
{
    NSLog(@"init success");
}

//注销结果
-(void) dealDJPlatformLogoutResultNotify : (NSNotification *) notify {
    NSDictionary *dict = notify.object;
    NSString *msg = [dict objectForKey:@"error_msg"];
    NSNumber *code = [dict objectForKey:@"error_code"];
    
    NSString *message = nil;
    if (code.intValue == 0) {  //code == 0 表示注销成功
        message = @"用户已经登出";
        [self sendU3dMessage:@"onLogoutSuccess" param:@"onLogoutSuccess"];
    } else {
        message = [NSString stringWithFormat:@"%@|%@", code, msg];
    }
    NSLog(@"logout:%@",message);
}

//支付结果
-(void) dealDJPlatformPaymentResultNotify : (NSNotification *) notify
{
    NSDictionary *dict = notify.object;
    NSString *orderNo = [dict objectForKey:@"orderNo"];
    NSNumber *code = [dict objectForKey:@"code"];
    NSString *message = nil;
    if (code.integerValue == PaymentResultTypeFinish){   //支付结果状态码
        message = @"支付完成";
        [self sendU3dMessage:@"onPaySuccess" param:@"onPaySuccess"];
    }else if(code.integerValue == PaymentResultTypeUnfinish)
          message = @"支付未完成";
    NSString *content=[NSString stringWithFormat:@"%@\norderNo:%@", message, orderNo];
    NSLog(@"PaymentResult:%@",content);
}

//充值结果
-(void) dealDJPlatformRechargeResultNotify : (NSNotification *) notify
{
    NSDictionary *dict = notify.object;
    NSNumber *code = [dict objectForKey:@"code"];
    NSString *message = nil;
    if (code.integerValue == RechangeResultTypeSuccess)   //支付结果状态码
         message = @"充值成功";
    else if(code.integerValue == RechangeResultTypeFail)
         message = @"充值失败";
    else if(code.integerValue == RechangeResultTypeWait)
         message = @"充值等待";
    
    NSLog(@"RechargeResult:%@",message);
    
}

//开启SDK
-(void) dealDJPlatformOpenNotify : (NSNotification *) notify
{
    NSLog(@"plat open");
}

//关闭SDK
-(void) dealDJPlatformCloseNotify : (NSNotification *) notify
{
    NSLog(@"plat close");
}

-(void)registerMessageReceiver:(NSString*)gameObjectName
{
    if (array == NULL) {
        array = [[NSMutableArray alloc] initWithCapacity:10];
    }
    [array addObject:gameObjectName];
    NSLog(@"registerMessageReceiver:%@",gameObjectName);
}

-(void)unRegisterMessageReceiver:(NSString*)gameObjectName
{
    if ([array containsObject:gameObjectName]) {
        [array removeObject:gameObjectName];
    }
}

- (void)sendU3dMessage:(NSString *)messageName param:(NSString *)param
{
    NSLog(@"param to string: %@",param);
    for(NSString * name in array)
    {
        NSLog(@"gameObjectName:%@",name);
        UnitySendMessage([name UTF8String], [messageName UTF8String], [param UTF8String]);
    }
}

@end

static NativeExtensionForDownjoy * native = nil;

// Converts C style string to NSString
NSString* CreateNSString (const char* string)
{
	if (string)
		return [NSString stringWithUTF8String: string];
	else
		return [NSString stringWithUTF8String: ""];
}

// Helper method to create C string copy
char* MakeStringCopy (const char* string)
{
	if (string == NULL)
		return NULL;
	
	char* res = (char*)malloc(strlen(string) + 1);
	strcpy(res, string);
	return res;
}

//供unity方法调用
#if defined(__cplusplus)
extern "C" {
#endif
    
    
    void sdkInit(const char* parameter)
    {
        if (native == nil) {
            native = [[NativeExtensionForDownjoy alloc]init];
        }
        
        NSString * str = (NSString*)CreateNSString(parameter);
        NSArray *arr = [str componentsSeparatedByString:@","];
        
        [native initSdk:(NSString *)[arr objectAtIndex:0] appKey:(NSString *)[arr objectAtIndex:1] merchantId:(NSString *)[arr objectAtIndex:2] serverId:(NSString *)[arr objectAtIndex:3] scheme:(NSString *)[arr objectAtIndex:4] hasAmountInputBox:(NSString *)[arr objectAtIndex:5]];
    }
    
    void sdkLogin(const char* parameter)
    {
        if (native == nil) {
            native = [[NativeExtensionForDownjoy alloc]init];
        }
        
        [native login];
    }
    
    void sdkPay(const char* parameter)
    {
        if (native == nil) {
            native = [[NativeExtensionForDownjoy alloc]init];
        }
        
        NSString * str = (NSString*)CreateNSString(parameter);
        NSArray *arr = [str componentsSeparatedByString:@","];
        
        [native pay:(NSString *)[arr objectAtIndex:0] porductName:(NSString *)[arr objectAtIndex:1] extInfo:(NSString *)[arr objectAtIndex:2]];
    }
    
    void sdkShowToolBar(const char* parameter)
    {
        
    }
    
    void sdkHideToolBar(const char* parameter)
    {
        
    }
    
    //注册返回事件监听者
    void sdkRegisterMessageReceiver(const char* gameObjectName)
    {
        if (native == nil) {
            native = [[NativeExtensionForDownjoy alloc]init];
        }
        
        [native registerMessageReceiver:(NSString*)CreateNSString(gameObjectName)];
    }
    
    //删除返回事件监听者
    void sdkUnRegisterMessageReceiver(const char* gameObjectName)
    {
        if (native == nil) {
            native = [[NativeExtensionForDownjoy alloc]init];
        }
        
        [native unRegisterMessageReceiver:(NSString*)CreateNSString(gameObjectName)];
    }
    
    //登出
    void sdkLogout(const char* parameter)
    {
        if (native == nil) {
            native = [[NativeExtensionForDownjoy alloc]init];
        }
        
        [native logout];
    }
    
    //打开用户中心
    void sdkUserCenter(const char* parameter)
    {
        if (native == nil) {
            native = [[NativeExtensionForDownjoy alloc]init];
        }
        
        [native userCenter];
    }
    
    //退出
    void sdkQuit(const char* parameter)
    {
    }
    
    //向sdk发送消息
    void sdkSendMessage(const char* parameter)
    {
    }
    
    
#if defined(__cplusplus)
}
#endif
