using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace Aquality.Selenium.Template.Pages
{
    public class MainPage : Form
    {
        private readonly ILink nextPageLink = ElementFactory.GetLink(By.CssSelector(".start__link"), "Next page link");

        public MainPage() : base(By.Id("app"), "Main Page")
        {
        }

        public void ClickNextPageLink()
        {
            nextPageLink.Click();
        }
    }
}
