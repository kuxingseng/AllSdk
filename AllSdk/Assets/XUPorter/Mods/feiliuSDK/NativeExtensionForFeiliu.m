//
//  NativeExtensionForFeiliu.m
//  HelloIOS
//
//  Created by chenshuai on 14-7-3.
//  Copyright (c) 2014年 muhe. All rights reserved.
//

#import "NativeExtensionForFeiliu.h"
#import <FlGamePlatform/FlGamePlatform.h>

static NSMutableArray *array = nil;

@implementation NativeExtensionForFeiliu

//初始化
- (void) initSDK:(NSString*)appId appKey:(NSString*)appKey companyId:(NSString*)companyId
{
    NSLog(@"initSdk...%@,%@,%@",appId,appKey,companyId);
    //设置初始化参数
    FlInitConfigure *congigure = [[FlInitConfigure alloc]init];
    congigure.appId=appId;
    congigure.appKey=appKey;
    congigure.companyId=companyId;
    
    //初始化SDK
    [[FlGamePlatform defaultPlatform] FlGamePlatformInit:congigure];
    
    //设置SDK界面屏幕方向
    //[[FlGamePlatform defaultPlatform] FlSetScreenOrientation:FLUIInterfaceOrientationPortrait]; //竖屏
    [[FlGamePlatform defaultPlatform]FlSetScreenOrientation:FLUIInterfaceOrientationLandscape]; //横屏
    
    //设置监听
    [[NSNotificationCenter defaultCenter] addObserver:self selector:@selector(loginQuit:) name:kFlCPCancelLoginNotification object:nil];
    
    [[NSNotificationCenter defaultCenter] addObserver:self selector:@selector(loginFish:) name:kFlCPSuccessLoginNotification object:nil];
    
    [[NSNotificationCenter defaultCenter] addObserver:self selector:@selector(setAccount) name:kFlCPSuccessSetAccountNotification object:nil];
    
    [[NSNotificationCenter defaultCenter] addObserver:self selector:@selector(cancelPay) name:kFlCPCancelPayNotification object:nil];
    
    [[NSNotificationCenter defaultCenter] addObserver:self selector:@selector(successPay) name:kFlCPSuccessPayNotification object:nil];
    
    [[NSNotificationCenter defaultCenter] addObserver:self selector:@selector(FLSLoginOut)name:(NSString *) kFlCPLoginOutNotification object:nil];
}

//登陆
-(void) login
{
    NSLog(@"login here...");
    [[FlGamePlatform defaultPlatform] FlLogin:YES];
}

//支付
-(void) pay:(NSString*)cpOrderId productPrice:(NSString*)productPrice payDesc:(NSString*)payDesc merpriv:(NSString*)merpriv
{
    FlBuyInfo *buyInfo =[[FlBuyInfo alloc]init];
    buyInfo.cporderId = cpOrderId;
    buyInfo.productPrice = [productPrice intValue];
    buyInfo.payDescription = payDesc;
    buyInfo.merpriv = merpriv;
    [[FlGamePlatform defaultPlatform] FlUniPayAsyn:buyInfo];
}

//显示浮动工具栏
-(void) showToolBar
{
    [[FlGamePlatform defaultPlatform] FlShowToolBar:FLToolBarAtMiddleRight toolBarMenuType:FLToolBarMenuAll];
}

//隐藏悬浮工具栏
-(void)hideToolBar
{
    [[FlGamePlatform defaultPlatform] FlHideToolBar];
}

//发送统计信息
-(void)sendGamePlayerInfo:(NSString*)guid playerId:(NSString*)playerId level:(NSString*)level nickName:(NSString*)nickName serverId:(NSString*)serverId
{
    CPGameInfo *gameInfo = [[CPGameInfo alloc]init];
    [gameInfo setGuid:guid];
    [gameInfo setPlayerId:playerId];
    [gameInfo setLevel:level];
    [gameInfo setNickname:nickName];
    [gameInfo setServerId:serverId];
    
    [[FlGamePlatform defaultPlatform] FlSendGamePlayerInfo:gameInfo];
    NSLog(@"send game player info: guid:%@, playerId:%@, level:%@, nickName:%@, serverId:%@",guid,playerId,level,nickName,serverId);
    
}

-(void)loginQuit:(NSNotification *)notify
{
    NSLog(@"loginQuit...");
}

-(void)loginFish:(NSNotification *)notify
{
    NSLog(@"loginSuccess");
    
    NSString *param = @"{";
    for (NSString *key in [notify userInfo])
    {
        if ([param length] == 1)
        {
            param = [param stringByAppendingFormat:@"\"%@\":\"%@\"", key, [[notify userInfo] valueForKey:key]];
        }
        else
        {
            param = [param stringByAppendingFormat:@",\"%@\":\"%@\"", key, [[notify userInfo] valueForKey:key]];
        }
    }
    [param stringByAppendingString:@"}"];
    
    [self sendU3dMessage:@"onLoginSuccess" param:param];
}

- (void)cancelPay
{
    NSLog(@"cancel pay..");
}

- (void)successPay
{
    NSLog(@"success pay...");
    [self sendU3dMessage:@"onPaySuccess" param:@"pay success"];
}

-(void)setAccount
{
    NSLog(@"set account...");
}

-(void)FLSLoginOut
{
    NSLog(@"logout...");
    [self sendU3dMessage:@"onLogoutSuccess" param:@"logout success"];
    
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

static NativeExtensionForFeiliu * native = nil;

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
            native = [[NativeExtensionForFeiliu alloc]init];
        }
        
        NSString * str = (NSString*)CreateNSString(parameter);
        NSArray *arr = [str componentsSeparatedByString:@","];
        
        [native initSDK:(NSString*)[arr objectAtIndex:0] appKey:(NSString*)[arr objectAtIndex:1] companyId:(NSString*)[arr objectAtIndex:2]];
    }
    
    void sdkLogin(const char* parameter)
    {
        if (native == nil) {
            native = [[NativeExtensionForFeiliu alloc]init];
        }
        
        [native login];
    }
    
    void sdkPay(const char* parameter)
    {
        if (native == nil) {
            native = [[NativeExtensionForFeiliu alloc]init];
        }
        
        NSString * str = (NSString*)CreateNSString(parameter);
        NSArray *arr = [str componentsSeparatedByString:@","];
        
        [native pay:(NSString*)[arr objectAtIndex:0] productPrice:(NSString*)[arr objectAtIndex:1] payDesc:(NSString*)[arr objectAtIndex:2] merpriv:(NSString *)[arr objectAtIndex:3]];
    }
    
    void sdkShowToolBar(const char* parameter)
    {
        if (native == nil) {
            native = [[NativeExtensionForFeiliu alloc]init];
        }
        
        [native showToolBar];
    }
    
    void sdkHideToolBar(const char* parameter)
    {
        if (native == nil) {
            native = [[NativeExtensionForFeiliu alloc]init];
        }
        
        [native hideToolBar];
    }
    
    //注册返回事件监听者
    void sdkRegisterMessageReceiver(const char* gameObjectName)
    {
        if (native == nil) {
            native = [[NativeExtensionForFeiliu alloc]init];
        }
        
        [native registerMessageReceiver:(NSString*)CreateNSString(gameObjectName)];
    }
    
    //删除返回事件监听者
    void sdkUnRegisterMessageReceiver(const char* gameObjectName)
    {
        if (native == nil) {
            native = [[NativeExtensionForFeiliu alloc]init];
        }
        
        [native unRegisterMessageReceiver:(NSString*)CreateNSString(gameObjectName)];
    }
    
    //登出
    void sdkLogout(const char* parameter)
    {
    }
    
    //打开用户中心
    void sdkUserCenter(const char* parameter)
    {
    }
    
    //退出
    void sdkQuit(const char* parameter)
    {
    }
    
    //向sdk发送消息
    void sdkSendMessage(const char* parameter)
    {
        if (native == nil) {
            native = [[NativeExtensionForFeiliu alloc]init];
        }
        
        NSString * str = (NSString*)CreateNSString(parameter);
        NSArray *arr = [str componentsSeparatedByString:@","];
        
        [native sendGamePlayerInfo:(NSString *)[arr objectAtIndex:0] playerId:(NSString *)[arr objectAtIndex:1] level:(NSString *)[arr objectAtIndex:2] nickName:(NSString *)[arr objectAtIndex:3] serverId:(NSString *)[arr objectAtIndex:4]];
    }
    
    
#if defined(__cplusplus)
}
#endif[arr objectAtIndex:0]
