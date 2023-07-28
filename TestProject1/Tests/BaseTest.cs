
using Aquality.Selenium.Browsers;
using Aquality.Selenium.Template.Utilities;

namespace Aquality.Selenium.Template.NUnit.Tests
{
    public abstract class BaseTest
    {

       
        protected BaseTest()
        {
        }

        [SetUp]
        protected void Setup()
        {
            var browser = AqualityServices.Browser;
            browser.Maximize();
            browser.GoTo(JsonReader.GetBaseUrl());
            browser.WaitForPageToLoad();
        }

        [TearDown]
        protected void AfterTest()
        {
            if (AqualityServices.IsBrowserStarted)
            {
                AqualityServices.Browser.Quit();
            }
        }
    }
}
