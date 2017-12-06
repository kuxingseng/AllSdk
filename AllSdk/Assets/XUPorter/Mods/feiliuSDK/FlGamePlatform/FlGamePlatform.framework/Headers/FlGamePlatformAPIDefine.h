//
//  FlGamePlatformAPIDefine.h
//  FlGamePlatform
//
//  Created by 亓尒词 on 13-10-17.
//  Copyright (c) 2013年 qi. All rights reserved.
//

#import <Foundation/Foundation.h>

typedef enum _FLUIInterfaceOrientation
{
	FLUIInterfaceOrientationPortrait,       /**< 竖屏 */
	FLUIInterfaceOrientationLandscape,      /**< 横屏 */
} FLUIInterfaceOrientation;

typedef	enum _FL_LOGIN_STATUS
{
	FL_LOGIN_STATUS_LOGINOUT = 0,           /**< 未登录 */
	FL_LOGIN_STATUS_ISLOGIN = 1,            /**< 登录 */
	FL_LOGIN_STATUS_GUEST = 2,              /**< 游客*/
}	FL_LOGIN_STATUS;

typedef enum  _FLToolBarPlace
{
	FLToolBarAtTopLeft = 1,                 /**< 左上 */
	FLToolBarAtTopRight,                    /**< 右上 */
    FLToolBarAtMiddleLeft,                  /**< 左中 */
	FLToolBarAtMiddleRight,                 /**< 右中 */
	FLToolBarAtBottomLeft,                  /**< 左下 */
	FLToolBarAtBottomRight,                 /**< 右下 */
}	FLToolBarPlace;

typedef enum  _FLToolBarMenuStype
{
	FLToolBarMenuAll = 1,                         /**< 全部包含 */
    FLToolBarMenuAccountAndBBS,            /**< 包含帐号管理和社区 */
    FLToolBarMenuExceptMoreGame,           /**< 除去更多游戏 */
    FLToolBarMenuExceptPayRecord,           /**< 除去订单查询 */
    FLToolBarMenuOnlyAccount,                 /**< 只有帐号管理 */
}	FLToolBarMenuStype;

/**
 @brief 飞流支付信息
 @note 购买价格保留2位小数
 */
@interface FlBuyInfo : NSObject

@property (nonatomic, retain) NSString *cporderId;				/**< 合作商的订单号，必须保证唯一，双方对账的唯一标记*/
@property (nonatomic, assign) int productPrice;				    /**< 商品价格，默认单位为分 */
@property (nonatomic, retain) NSString *payDescription;		    /**< 购买描述，可选，没有为空 */
@property (nonatomic, retain) NSString *merpriv;                /**< 预留字段，可作为cp传参使用，可选，没有为空 */
@end


/**
 @brief 游戏信息
 */
@interface CPGameInfo : NSObject

@property (nonatomic, retain) NSString *guid;				    /**< cp的用户唯一标志符，可选，没有为空 */
@property (nonatomic, retain) NSString * playerId;				/**< cp的用户角色id，可选，没有为空 */
@property (nonatomic, retain) NSString *level;		            /**< cp的用户角色等级，可选，没有为空 */
@property (nonatomic, retain) NSString *nickname;               /**< cp的用户角色名称，可选，没有为空 */
@property (nonatomic, retain) NSString *serverId;               /**< cp的用户角色服务器id，可选，没有为空 */
@end



