using Xamarin.UITest;

namespace Xtc101.UITest
{
    public class AppInitializer
    {
        public static IApp StartApp(Platform platform)
        {
            if (platform == Platform.Android)
            {
                return ConfigureApp
                    .Android
                    // Run Release Android project on Simulator and then uncomment line bellow (you can run the tests under the debug config)
                    //.ApkFile("../../../Xtc101/bin/Release/com.companyname.xtc101.apk")
                    .PreferIdeSettings()
                    .StartApp();
            }

            return ConfigureApp
                .iOS
                .PreferIdeSettings()
                .StartApp();
        }
    }
}