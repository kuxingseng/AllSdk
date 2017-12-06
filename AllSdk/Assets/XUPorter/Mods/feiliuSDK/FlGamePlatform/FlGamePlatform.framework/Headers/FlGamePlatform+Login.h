//
//  FlGamePlatform+Login.h
//  FlGamePlatform
//
//  Created by 亓尒词 on 13-10-17.
//  Copyright (c) 2013年 qi. All rights reserved.
//
#import <Foundation/Foundation.h>
#import "FlGamePlatformBase.h"

@interface FlGamePlatform (Login)

/**
 * @description 普通登录方法
 * @param autoLogin: 是否二次登录自动登录，,YES 自动,NO 不自动
 */

-(void)FlLogin:(BOOL)autoLogin;

/**
 * @description 普通登录的基础上增加了对游客登录
 */

-(void)FlLoginEx ;

/**
 * @description 返回当前的登录状态
 */

-(FL_LOGIN_STATUS)FlLoginStatus ;

/**
 * @description 初始化构造函数,sdk运行所需的游戏基础信息
 * @param guid: 第三方cp的用户唯一标志符
 * @param playerId: 第三方cp的用户角色id
 * @param level: 第三方cp的用户角色等级
 * @param nickname: 第三方cp的用户角色名称
 * @param serverId: 第三方cp的用户角色服务器id
 */
-(void)FlSendGamePlayerInfo:(CPGameInfo *)gameInfo ;

@end
