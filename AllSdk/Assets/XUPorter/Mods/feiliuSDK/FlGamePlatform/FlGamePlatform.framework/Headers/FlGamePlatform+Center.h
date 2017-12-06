//
//  FlGamePlatform+Center.h
//  FlGamePlatform
//
//  Created by 亓尒词 on 13-10-17.
//  Copyright (c) 2013年 qi. All rights reserved.
//

#import <FlGamePlatform/FlGamePlatform.h>

@interface FlGamePlatform (Center)

/**
 * @description 初始化构造函数,公告页面构造方法
 * @param serverId 服务器ID
 */

- (void)FlAnnouncement:(NSString*)serverId ;


/**
 * @description 初始化构造函数,客服页面构造方法
 */

- (void)FlCustomService ;


/**
 * @description 初始化构造函数,进入飞流社区的方法
 */
@end
