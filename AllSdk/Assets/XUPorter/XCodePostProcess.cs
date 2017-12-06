using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEditor.XCodeEditor;
using System.Xml;
#endif
using System.IO;

public static class XCodePostProcess
{
    #if UNITY_EDITOR
    [PostProcessBuild (100)]
    public static void OnPostProcessBuild (BuildTarget target, string pathToBuiltProject)
    {
        if (target != BuildTarget.iOS) {
            Debug.LogWarning ("Target is not iPhone. XCodePostProcess will not run");
            return;
        }

        //得到xcode工程的路径
        string path = Path.GetFullPath (pathToBuiltProject);

        // Create a new project object from build target
        XCProject project = new XCProject (pathToBuiltProject);

        // Find and run through all projmods files to patch the project.
        // Please pay attention that ALL projmods files in your project folder will be excuted!
        //在这里面把frameworks添加在你的xcode工程里面
        string[] files = Directory.GetFiles (Application.dataPath, "*.projmods", SearchOption.AllDirectories);
        foreach (string file in files) {
            project.ApplyMod (file);
        }

        //设置签名的证书， 第二个参数 你可以设置成你的证书
//		project.overwriteBuildSetting ("CODE_SIGN_IDENTITY", "iPhone Developer: Xing Feng (X545V737VP)", "Release");
//		project.overwriteBuildSetting ("CODE_SIGN_IDENTITY", "iPhone Developer: Xing Feng (X545V737VP)", "Debug");
//		project.overwriteBuildSetting ("PROVISIONING_PROFILE", "sgyy_dev", "Release");
//		project.overwriteBuildSetting ("PROVISIONING_PROFILE", "sgyy_dev", "Debug"); 

		//add linking
		//project.AddOtherLinkerFlags ("-ObjC");



        // 编辑plist 文件
        //EditorPlist(path);
		//downjoyEditorPlist (path);
		//pphelperEditorPlist (path,"2369");
		//haimaEditorPlist (path,"com.timetoplay.ssyyPG");
		//aisiEditorPlist (path,"1419");
		//kuaiyongEditorPlist (path,"com.timetoplay.ssyyPG");

		//xyEditorPlist (path,"com.timetoplay.ssyyPG");
		//iiappleEditorPlist (path, "com.timetoplay.ssyyPG");
		//tongbutuiEditorPlist (path, "com.timetoplay.ssyyPG");
		//nd91EditorPlist (path, "com.timetoplay.ssyyPG");
		//aibeiPayEditorPlist (path, "com.timetoplay.ssyyPG");
		//xxEditorPlist (path, "com.timetoplay.ssyyPG");
		yundingEditorPlist (path, "com.timetoplay.ssyyPG");



        //编辑代码文件
        //EditorCode(path);
		//downjoyEditorCode (path);
		//pphelperEditorCode (path);
		//haimaEditorCode (path);
		//aisiEditorCode (path);
		//kuaiyongEditorCode (path);


		//xyEditorCode (path);
		//iiappleEditorCode (path);
		//aibeiPayEditorCode (path);
		//xxEditorCode (path);
		yundingEditorCode (path);

        // Finally save the xcode project
        project.Save ();


        //handler for special platform

    }



	private static void yundingEditorPlist(string filePath,string bundleID)
	{
		XCPlist list =new XCPlist(filePath);
		string plistAdd = @"
			<key>CFBundleURLTypes</key>
            <array>
            <dict>            
            <key>CFBundleURLSchemes</key>
            <array>
            <string>"+ bundleID+@"</string>
            </array>			
            </dict>
            </array>
			<key>UIViewControllerBasedStatusBarAppearance</key>
			<false/>
			<key>UIViewControllerBasedStatusBarAppearance - 2</key>
			<false/>
		    <key>LSApplicationQueriesSchemes</key>
		    <array>
		        <string>goxiapp520</string>
		        <string>weixin</string>
		        <string>alipay</string>
		    </array>
			<key>NSAppTransportSecurity</key>
    		<dict>
        	<key>NSAllowsArbitraryLoads</key>
        	<true/>
    		</dict>";
		
		//在plist里面增加一行
		list.AddKey(plistAdd);
		//保存
		list.Save();
	}


	private static void xxEditorPlist(string filePath,string bundleID)
	{
		XCPlist list =new XCPlist(filePath);
		string plistAdd = @"
			<key>CFBundleURLTypes</key>
            <array>
            <dict>            
            <key>CFBundleURLSchemes</key>
            <array>
            <string>"+ bundleID+@"</string>
            </array>			
            </dict>
            </array>
			<key>CFBundleAllowMixedLocalizations</key>
			<true/>
			<key>NSLocationAlwaysUsageDescription</key>
			<string></string>
			<key>NSLocationWhenInUseUsageDescription</key>
			<string></string>
			<key>LSApplicationQueriesSchemes</key>
			<array>
				<string>cydia</string>
				<string>xxassistant</string>
				<string>xxassistantsdk</string>
				<string>alipay</string>
				<string>weixin</string>
				<string>wechat</string>
			</array>
			<key>NSAppTransportSecurity</key>
    		<dict>
        	<key>NSAllowsArbitraryLoads</key>
        	<true/>
    		</dict>";
		
		//在plist里面增加一行
		list.AddKey(plistAdd);
		//保存
		list.Save();
	}

	private static void iiappleEditorPlist(string filePath,string bundleID)
	{
		XCPlist list =new XCPlist(filePath);
		string plistAdd = @"
			<key>CFBundleURLTypes</key>
            <array>
            <dict>            
            <key>CFBundleURLSchemes</key>
            <array>
            <string>"+ bundleID+@"</string>
            </array>			
            </dict>
            </array>
			 <key>NSAppTransportSecurity</key>
    		<dict>
        	<key>NSAllowsArbitraryLoads</key>
        	<true/>
    		</dict>";
		
		//在plist里面增加一行
		list.AddKey(plistAdd);
		//保存
		list.Save();
	}

	private static void itoolsEditorPlist(string filePath,string bundleID)
	{
		XCPlist list =new XCPlist(filePath);
		string plistAdd = @"
			<key>CFBundleURLTypes</key>
            <array>
            <dict>            
            <key>CFBundleURLSchemes</key>
            <array>
            <string>"+ bundleID+@"</string>
            </array>			
            </dict>
            </array>
			<key>LSApplicationQueriesSchemes</key>
    		<array>
        	<string>ailplay</string>
        	<string>QQ41C2A839</string>
    		</array>
    		<key>NSAppTransportSecurity</key>
    		<dict>
        	<key>NSAllowsArbitraryLoads</key>
        	<true/>
    		</dict>";
		
		//在plist里面增加一行
		list.AddKey(plistAdd);
		//保存
		list.Save();
	}

	
	private static void xyEditorPlist(string filePath,string bundleID)
	{
		XCPlist list =new XCPlist(filePath);
		string plistAdd = @"
			<key>CFBundleURLTypes</key>
            <array>
            <dict>            
            <key>CFBundleURLSchemes</key>
            <array>
            <string>"+ bundleID +@".alipay</string>
            </array>			
            </dict>
            </array>
			<key>LSApplicationQueriesSchemes</key>
			<array>
				<string>alipay</string>
				<string>aliminipayauth</string>
				<string>wechat</string>
				<string>weixin</string>
				<string>xyzsapp</string>
			</array>
            <key>NSAppTransportSecurity</key>
    		<dict>
        	<key>NSAllowsArbitraryLoads</key>
        	<true/>
    		</dict>";
		
		//在plist里面增加一行
		list.AddKey(plistAdd);
		//保存
		list.Save();
	}

	private static void nd91EditorPlist(string filePath,string bundleID)
	{
		XCPlist list =new XCPlist(filePath);
		string plistAdd = @"
			<key>CFBundleURLTypes</key>
            <array>
            <dict>            
            <key>CFBundleURLSchemes</key>
            <array>
            <string>91-" + bundleID +@"</string>
            </array>	
			<key>CFBundleURLName</key>
            <string>"+bundleID+@"</string>		
            </dict>
            </array>
            <key>NSAppTransportSecurity</key>
    		<dict>
        	<key>NSAllowsArbitraryLoads</key>
        	<true/>
    		</dict>";
		
		//在plist里面增加一行
		list.AddKey(plistAdd);
		//保存
		list.Save();
	}
	
	private static void kuaiyongEditorPlist(string filePath,string bundleID)
	{
		XCPlist list =new XCPlist(filePath);
		string plistAdd = @"
			<key>CFBundleURLTypes</key>
            <array>
            <dict>            
            <key>CFBundleURLSchemes</key>
            <array>
            <string>" + bundleID +@"</string>
            </array>	
			<key>CFBundleURLName</key>
            <string>com.ky.xSDK.alipay</string>		
            </dict>
            </array>
            <key>NSAppTransportSecurity</key>
            <dict>
            <key>NSAllowsArbitraryLoads</key>
            <true/>
            </dict>";
		
		//在plist里面增加一行
		list.AddKey(plistAdd);
		//保存
		list.Save();
	}


	private static void tongbutuiEditorPlist(string filePath,string bundleID)
	{
		XCPlist list =new XCPlist(filePath);
		string plistAdd = @"
			<key>CFBundleURLTypes</key>
            <array>
            <dict>            
            <key>CFBundleURLSchemes</key>
            <array>
            <string>" + bundleID +@"-tb</string>
            </array>	
			<key>CFBundleURLName</key>
            <string>" +bundleID+@"</string>		
            </dict>
            </array>
            <key>NSAppTransportSecurity</key>
            <dict>
            <key>NSAllowsArbitraryLoads</key>
            <true/>
            </dict>";
		
		//在plist里面增加一行
		list.AddKey(plistAdd);
		//保存
		list.Save();
	}
	
	private static void aisiEditorPlist(string filePath,string appid)
	{
		XCPlist list =new XCPlist(filePath);
		string plistAdd = @"
			<key>CFBundleURLTypes</key>
            <array>
            <dict>            
            <key>CFBundleURLSchemes</key>
            <array>
            <string>As"+appid+@"</string>
            </array>
			<key>CFBundleURLName</key>
            <string></string>		
			</dict> 
			</array>
			<key>LSApplicationQueriesSchemes</key>
			<array>
			<string>alipay</string> 
			<string>weixin</string> 
			<string>mqqapiwallet</string>
            </array>
            <key>NSAppTransportSecurity</key>
            <dict>
            <key>NSAllowsArbitraryLoads</key>
            <true/>
            </dict>";
		
		//在plist里面增加一行
		list.AddKey(plistAdd);
		//保存
		list.Save();
	}

	private static void haimaEditorPlist(string filePath,string bundleID)
	{
		XCPlist list =new XCPlist(filePath);
		string plistAdd = @"
			<key>CFBundleURLTypes</key>
            <array>
            <dict>            
            <key>CFBundleURLSchemes</key>
            <array>
            <string>ZHPAY-"+bundleID+@"</string>
            </array>
			<key>CFBundleURLName</key>
            <string>"+bundleID+@"</string>
            </dict>
            </array>
            <key>NSAppTransportSecurity</key>
            <dict>
            <key>NSAllowsArbitraryLoads</key>
            <true/>
            </dict>";
		
		//在plist里面增加一行
		list.AddKey(plistAdd);
		//保存
		list.Save();
	}

	private static void aibeiPayEditorPlist(string filePath,string bundleID)
	{
		XCPlist list =new XCPlist(filePath);
		string plistAdd = @"
			<key>CFBundleURLTypes</key>
            <array>
            <dict>            
            <key>CFBundleURLSchemes</key>
            <array>
            <string>iapppay.alipay."+bundleID+@"</string>
            </array>
			<key>CFBundleURLName</key>
            <string>iapppay.alipay</string>
            </dict>
            </array>
			<key>NSAppTransportSecurity</key>
			<dict>
			<key>NSAllowsArbitraryLoads</key>
			<true/>
			</dict>";
		
		//在plist里面增加一行
		list.AddKey(plistAdd);
		//保存
		list.Save();
	}


	private static void downjoyEditorPlist(string filePath)
	{
		XCPlist list =new XCPlist(filePath);
		string plistAdd = @"
			<key>CFBundleURLTypes</key>
            <array>
            <dict>            
            <key>CFBundleURLSchemes</key>
            <array>
            <string>sdk</string>
            </array>
			<key>URL identifier</key>
            <string>com.downjoy.sdk</string>
            </dict>
            </array>";
		
		//在plist里面增加一行
		list.AddKey(plistAdd);
		//保存
		list.Save();
	}

	private static void pphelperEditorPlist (string filePath,string appId)
	{
		XCPlist list =new XCPlist(filePath);
		string plistAdd = @"
			<key>CFBundleURLTypes</key>
            <array>
            <dict>            
            <key>CFBundleURLSchemes</key>
            <array>
            <string>teiron" + appId +@"</string>
            </array>
            </dict>
            </array>
			<key>NSAppTransportSecurity</key>
			<dict>
			<key>NSAllowsArbitraryLoads</key>
			<true/>
			</dict>";
		
		//在plist里面增加一行
		list.AddKey(plistAdd);

		//保存
		list.Save();
	}

    private static void EditorPlist(string filePath)
    {
     
        XCPlist list =new XCPlist(filePath);
		string bundle = "com.yusong.momo";

        string PlistAdd = @"  
            <key>CFBundleURLTypes</key>
            <array>
            <dict>
            <key>CFBundleTypeRole</key>
            <string>Editor</string>
            <key>CFBundleURLIconFile</key>
            <string>Icon@2x</string>
            <key>CFBundleURLName</key>
            <string>"+bundle+@"</string>
            <key>CFBundleURLSchemes</key>
            <array>
            <string>ww123456</string>
            </array>
            </dict>
            </array>";
		        
        //在plist里面增加一行
        list.AddKey(PlistAdd);
        //在plist里面替换一行
		list.ReplaceKey("<string>com.koramgame.${PRODUCT_NAME}</string>","<string>"+bundle+"</string>");
        //保存
        list.Save();

    }

    private static void EditorCode(string filePath)
    {
		//读取UnityAppController.mm文件
		XClass UnityAppController = new XClass(filePath + "/Classes/Unity/CMVideoSampling.mm");
		
		//在指定代码中替换一行
		UnityAppController.Replace("#include <OpenGLES/ES2/gl.h>","#include <OpenGLES/ES2/glext.h>");
    }


	private static void yundingEditorCode(string filePath)
	{
		//读取UnityAppController.mm文件
		XClass UnityAppController = new XClass(filePath + "/Classes/UnityAppController.mm");
		
		//在指定代码后面增加一行代码
		
		UnityAppController.WriteBelow("#include \"PluginBase/AppDelegateListener.h\"","#import <IDS/IDSHeader.h>");
		
		//在指定代码后面增加一行代码
		UnityAppController.WriteBelow("AppController_SendNotificationWithArg(kUnityOnOpenURL, notifData);","[[idsPP sharedInstance] parseURL:url application:application];");
        //在指定代码后面增加一行代码
        UnityAppController.WriteBelow("AppController_SendNotificationWithArg(kUnityOnOpenURL, notifData);", "[[idsPP sharedInstance] trackByOpenUrl:url fromApplication:sourceApplication];");
		
	}

	private static void xxEditorCode(string filePath)
	{
		//读取UnityAppController.mm文件
		XClass UnityAppController = new XClass(filePath + "/Classes/UnityAppController.mm");
		
		//在指定代码后面增加一行代码
		
		UnityAppController.WriteBelow("#include \"PluginBase/AppDelegateListener.h\"","#import \"GPGameSDK_Pay.h\"");
		
		//在指定代码后面增加一行代码
		UnityAppController.WriteBelow("AppController_SendNotificationWithArg(kUnityOnOpenURL, notifData);","[[GPGameSDK_Pay defaultGPGamePay] openUrlResponse:url];");
		
	}


	private static void iiappleEditorCode(string filePath)
	{
		//读取UnityAppController.mm文件
		XClass UnityAppController = new XClass(filePath + "/Classes/UnityAppController.mm");
		
		//在指定代码后面增加一行代码
		
		UnityAppController.WriteBelow("#include \"PluginBase/AppDelegateListener.h\"","#import \"IIApple.h\"");
		
		//在指定代码后面增加一行代码
		UnityAppController.WriteBelow("AppController_SendNotificationWithArg(kUnityOnOpenURL, notifData);","[IIApple application:application openURL:url sourceApplication:sourceApplication annotation:annotation];");
		
	}

	private static void itoolsEditorCode(string filePath)
	{
		//读取UnityAppController.mm文件
		XClass UnityAppController = new XClass(filePath + "/Classes/UnityAppController.mm");
		
		//在指定代码后面增加一行代码
		UnityAppController.WriteBelow("#include \"PluginBase/AppDelegateListener.h\"","#import <AlipaySDK/AlipaySDK.h>");

		UnityAppController.WriteBelow("#include \"PluginBase/AppDelegateListener.h\"","#import \"HXAppPlatformKitPro.h\"");
		
		//在指定代码后面增加一行代码
		UnityAppController.WriteBelow("AppController_SendNotificationWithArg(kUnityOnOpenURL, notifData);","    if ([url.host isEqualToString:@\"safepay\"]) {"
        +" [[AlipaySDK defaultService] processOrderWithPaymentResult:url standbyCallback:^(NSDictionary *resultDic) {"
        +  "NSLog(@\"result = %@\", resultDic);"
		+  "[HXAppPlatformKitPro alipayCallBack:resultDic];}];}");
		
	}
	
//	private static void xyEditorCode(string filePath)
//	{
//		//读取UnityAppController.mm文件
//		XClass UnityAppController = new XClass(filePath + "/Classes/UnityAppController.mm");
//		
//		//在指定代码后面增加一行代码
//		UnityAppController.WriteBelow("#include \"PluginBase/AppDelegateListener.h\"","#import  <XYPlatform/XYPlatform.h>");
//		
//		//在指定代码后面增加一行代码
//		UnityAppController.WriteBelow("- (NSUInteger) application:(UIApplication *)application supportedInterfaceOrientationsForWindow:(UIWindow *)window{","return [[XYPlatform defaultPlatform] application:application supportedInterfaceOrientationsForWindow:window];" );
//
//		
//	}

	private static void kuaiyongEditorCode(string filePath)
	{
		//读取UnityAppController.mm文件
		XClass UnityAppController = new XClass(filePath + "/Classes/UnityAppController.mm");
		
		//在指定代码后面增加一行代码
		UnityAppController.WriteBelow("#include \"PluginBase/AppDelegateListener.h\"","#import <xsdkFramework/XSDK.h>");
		
		//在指定代码后面增加一行代码
		UnityAppController.WriteBelow("AppController_SendNotificationWithArg(kUnityOnOpenURL, notifData);","if ([[XSDK instanceXSDK]handleApplication:application openURL:url sourceApplication:sourceApplication annotation:annotation]) {NSLog(@\"第三方处理\");}");

	}

	private static void aibeiPayEditorCode(string filePath)
	{
		//读取UnityAppController.mm文件
		XClass UnityAppController = new XClass(filePath + "/Classes/UnityAppController.mm");
		
		//在指定代码后面增加一行代码
		UnityAppController.WriteBelow("#include \"PluginBase/AppDelegateListener.h\"","#import <IapppayKit/IapppayKit.h>");
		
		//在指定代码后面增加一行代码
		UnityAppController.WriteBelow("AppController_SendNotificationWithArg(kUnityOnOpenURL, notifData);"," [[IapppayKit sharedInstance] handleOpenUrl:url];");
		
	}

	private static void aisiEditorCode(string filePath)
	{
		//读取UnityAppController.mm文件
		XClass UnityAppController = new XClass(filePath + "/Classes/UnityAppController.mm");
		
		//在指定代码后面增加一行代码
		UnityAppController.WriteBelow("#include \"PluginBase/AppDelegateListener.h\"","#import \"AsInfoKit.h\"");
		
		//在指定代码后面增加一行代码
		UnityAppController.WriteBelow("AppController_SendNotificationWithArg(kUnityOnOpenURL, notifData);","[[AsInfoKit sharedInstance] payResult:url sourceApplication:sourceApplication];" );

	}

//	private static void haimaEditorCode(string filePath)
//	{
//		//读取UnityAppController.mm文件
//		XClass UnityAppController = new XClass(filePath + "/Classes/UnityAppController.mm");
//		
//		//在指定代码后面增加一行代码
//		UnityAppController.WriteBelow("#include \"PluginBase/AppDelegateListener.h\"","#import \"IPAYiAppPay.h\"");
//		
//		//在指定代码后面增加一行代码
//		UnityAppController.WriteBelow("- (void)preStartUnity				{}","- (BOOL)application:(UIApplication *)application handleOpenURL:(NSURL *)url {[[IPAYiAppPay sharediAppPay] handleOpenurl: url];return YES;}" );
//
//		UnityAppController.WriteBelow ("NSMutableArray* values	= [NSMutableArray arrayWithCapacity:3];", "[[IPAYiAppPay sharediAppPay] handleOpenurl: url];");
//		
//	}

	private static void downjoyEditorCode(string filePath)
	{
		//读取UnityAppController.mm文件
		XClass UnityAppController = new XClass(filePath + "/Classes/UnityAppController.mm");

		//在指定代码后面增加一行代码
		UnityAppController.WriteBelow("#include \"PluginBase/AppDelegateListener.h\"","#import <DownjoySDK/DJPlatformNotification.h>");

		//在指定代码后面增加一行代码
		UnityAppController.WriteBelow("AppController_SendNotificationWithArg(kUnityOnOpenURL, notifData);","[[NSNotificationCenter defaultCenter] postNotificationName:kDJPlatfromAlixQuickPayEnd object:url];");

	}

	private static void pphelperEditorCode(string filePath)
	{
		//读取UnityAppController.mm文件
		XClass UnityAppController = new XClass(filePath + "/Classes/UnityAppController.mm");

		//在指定代码后面增加一行代码
		UnityAppController.WriteBelow("#include \"PluginBase/AppDelegateListener.h\"","#import <PPAppPlatformKit/PPAppPlatformKit.h>");
		
		//在指定代码后面增加一行代码
		UnityAppController.WriteBelow("AppController_SendNotificationWithArg(kUnityOnOpenURL, notifData);","[[PPAppPlatformKit share] alixPayResult:url];");

	}
#endif
}
