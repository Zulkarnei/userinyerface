using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace Aquality.Selenium.Template.Pages
{
    public class CookiesForm : Form
    {
        private readonly IButton acceptCookiesButton = ElementFactory.GetButton(By.XPath("//button[contains(@class, 'button')]"), "Accept Cookies");


        public CookiesForm() : base(By.CssSelector(".cookies"), "Cookies Form")
        {
        }

        public void AcceptCookies()
        {
            acceptCookiesButton.Click();
        }
    }
}
