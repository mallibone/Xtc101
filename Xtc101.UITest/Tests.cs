using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
using Xamarin.UITest.Android;

namespace Xtc101.UITest
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class Tests
    {
        IApp app;
        private Platform _platform;

        public Tests(Platform platform)
        {
            _platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            // TODO: If the Android app being tested is included in the solution then open
            // the Unit Tests window, right click Test Apps, select Add App Project
            // and select the app projects that should be tested.
            app = AppInitializer
                // TODO: Update this path to point to your Android app and uncomment the
                // code if the app is not included in the solution.
                //.ApkFile ("../../../Android/bin/Debug/UITestsAndroid.apk")
                .StartApp(_platform);
        }

        [Test]
        public void SubmittingAMessage_GivenATextIsEnteredAndSubmitted_ItCanBeReadFromTheSubmittedMessageField()
        {
            var expectedResult = "Hello Android";

            app.EnterText(c => c.Marked("MessageText"), expectedResult);
            app.Tap(c => c.Marked("SubmitMessage"));

            var receivedResult = app.Query(c => c.Marked("SubmittedMessage")).First().Text;
            Assert.AreEqual(expectedResult, receivedResult);
        }
    }
}

