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
                    .Debug()
                    .StartApp(Xamarin.UITest.Configuration.AppDataMode.Clear);
            }

            return ConfigureApp
                .iOS
                .PreferIdeSettings()
                .StartApp();
        }
    }
}