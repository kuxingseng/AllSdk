//
//  UserInfomation.h
//  DownjoySDK2.0
//
//  Created by soon on 13-10-10.
//  Copyright (c) 2013年 downjoy. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface UserInfomation : NSObject


@property (nonatomic, copy) NSString *userName;     //用户名
@property (nonatomic, copy) NSString *nickName;     //昵称
@property (nonatomic, copy) NSString *token;     //token
@property (nonatomic, copy) NSString *mid;      //乐号
@property (nonatomic, copy) NSString *errorMsg;
@property (nonatomic, copy) NSString *avatarUrl;     //头像
@property (nonatomic, copy) NSString *level;     //级别
@property (nonatomic, copy) NSString *gender;     //性别

@property (nonatomic, copy) NSString *phoneNum;     //手机号
@property (nonatomic, copy) NSNumber *isBandNum;     //绑定号码

@property (nonatomic, readonly) NSString *forumURLString;
@property (nonatomic, readonly) NSString *channelURLString;


+(UserInfomation *) userInfomationWithDictionary:(NSDictionary *) dictionary;

@end
