using System;
using NUnit.Framework;
using Xamarin.UITest;

namespace FifteenPercentDrop.UITests
{

    //[TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class AboutPageTests
    {
        IApp app;
        Platform platform;

        public AboutPageTests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        public void VisitAllPages()
        {
            app.Tap("About");
            app.WaitForElement(x => x.Marked("Created By"));
            app.Tap("Calculator");
            app.WaitForElement(x => x.Marked("HYBRID"));
            Assert.Pass();
        }

        [Test]
        public void VisitSourceCode()
        {
            //app.Repl();
            app.WaitForElement("About");
            app.Repl();

            app.Tap("About");
            app.Repl();
            app.WaitForElement("Source Code");
            app.Tap("Source Code");
            app.Repl();
            app.WaitForElement("Toolbar");
            app.Tap("Toolbar");
            app.WaitForElement("Source Code");
            app.Tap("Source Code");
            app.WaitForElement("Toolbar");
            Assert.Pass();
        }

    }
}
