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
    public class BasicTests
    {
        IApp app;
        private readonly Platform _platform;

        public BasicTests(Platform platform)
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
                //.ApkFile("../../../Xtc101.Droid/bin/Release/UITestsAndroid.apk")
                .StartApp(_platform);
        }

		[Test]
		[Ignore]
		public void Explorer()
		{
			app.Repl ();
		}

        [Test]
        public void SubmittingAMessage_GivenATextIsEnteredAndSubmitted_ItCanBeReadFromTheSubmittedMessageField()
        {
            var expectedResult = "Hello from Xamarin Test Cloud";

            app.Screenshot("Before entering text.");
            app.EnterText(c => c.Marked("MessageText"), expectedResult);
            app.Screenshot("After entering text.");
            app.Tap(c => c.Marked("SubmitMessage"));
            app.Screenshot("After submitting text.");
            var receivedResult = app.Query(c => c.Marked("SubmittedMessage")).First().Text;
            Assert.AreEqual(expectedResult, receivedResult);
        }
    }
}

