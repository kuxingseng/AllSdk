//
//  FlGamePlatformBase.h
//  FlGamePlatform
//
//  Created by 亓尒词 on 13-10-17.
//  Copyright (c) 2013年 qi. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "FlGamePlatformAPIDefine.h"

@interface FlInitConfigure : NSObject

@property (nonatomic, retain) NSString *appId;             /**< 分配给第三方cp的AppId*/
@property (nonatomic, retain) NSString *appKey;            /**< 分配给第三方cp的AppKey*/
@property (nonatomic, retain) NSString *companyId;       /**< 分配给第三方cp的CompanyId*/
@end




@interface FlGamePlatform : NSObject

/**
 @brief 获取NdComPlatform的实例对象
 */
+ (FlGamePlatform *)defaultPlatform;

#pragma mark -
#pragma mark SDK接入信息

/**
 * @description 初始化构造函数,加载sdk的首要方法
 */
-(void)FlGamePlatformInit:(FlInitConfigure *)configure ;

/**
 * @description 设置游戏支持的方向,sdk提供正确页面
 * @param ScreenOrientation: 定义的枚举屏幕方向参数参见枚举FLUIInterfaceOrientation
 */

-(void)FlSetScreenOrientation:(FLUIInterfaceOrientation)ScreenOrientation;


/**
 * @description 显示工具栏
 * @param toolBarPlace: 工具条位置
 * @param toolBarMenuType: 菜单按钮风格
 */
- (void)FlShowToolBar:(FLToolBarPlace)toolBarPlace
      toolBarMenuType:(FLToolBarMenuStype)toolBarMenuType;
/**
 * @description 隐藏工具栏
 */
- (void)FlHideToolBar ;

/**
 * @description 初始化构造函数,获取到我们的渠道号方法
 */
- (NSString*)FlGetFlCoopId ;


@end
