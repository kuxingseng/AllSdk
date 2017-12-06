//
//  FlGamePlatform+Pay.h
//  FlGamePlatform
//
//  Created by 亓尒词 on 13-10-17.
//  Copyright (c) 2013年 qi. All rights reserved.
//

#import <FlGamePlatform/FlGamePlatform.h>
#import "FlGamePlatformBase.h"

@interface FlGamePlatform (Pay)

/**
 * @description 初始化构造函数,购买构造方法
 */
- (void)FlUniPayAsyn:(FlBuyInfo *)buyInfo ;

@end
