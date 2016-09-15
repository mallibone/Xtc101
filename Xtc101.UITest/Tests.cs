using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
using Xamarin.UITest.Android;
using Xtc101.UITest.Page;

namespace Xtc101.UITest
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class BasicTests
    {
        private IApp _app;
        private readonly Platform _platform;
        private MainPage _mainPage;

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
            _app = AppInitializer
                // TODO: Update this path to point to your Android app and uncomment the
                // code if the app is not included in the solution.
                //.ApkFile("../../../Xtc101.Droid/bin/Release/UITestsAndroid.apk")
                .StartApp(_platform);
            _mainPage = new MainPage(_app);
        }

		[Test]
		[Ignore]
		public void Explorer()
		{
			_app.Repl ();
		}

        [Test]
        public void SubmittingAMessage_GivenATextIsEnteredAndSubmitted_ItCanBeReadFromTheSubmittedMessageField()
        {
            var expectedResult = "Hello from Xamarin Test Cloud";

            _app.Screenshot("Before entering text.");
            _mainPage.Text = expectedResult;

            _app.Screenshot("After entering text.");
            _mainPage.SendMessage();

            _app.Screenshot("After submitting text.");
            var currentMessage = _mainPage.Message;

            Assert.AreEqual(expectedResult, currentMessage);
        }
    }
}

