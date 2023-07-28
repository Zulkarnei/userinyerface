using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace Aquality.Selenium.Template.Pages
{
    public class HomePage : Form
    {
        private readonly ILabel timerLabel = ElementFactory.GetLabel(By.CssSelector(".timer.timer--white.timer--center"), "Timer Label");

        public HomePage() : base(By.CssSelector("#app .login-form__container"), "Login Page")
        {
        }

        public string GetTimerValue()
        {
            return timerLabel.Text;
        }
    }
}
