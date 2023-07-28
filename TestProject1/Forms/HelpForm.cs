using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace Aquality.Selenium.Template.Pages
{
    public class HelpForm : Form
    {
        private readonly IButton sendToBottomButton = ElementFactory.GetButton(By.XPath("//button[contains(@class, 'help-form__send-to-bottom-button')]"), "Send To Bottom Button");
        private readonly ITextBox hiddenHelpForm = ElementFactory.GetTextBox(By.XPath("//div[contains(@class, 'is-hidden')]"), "Hidden Help Form");
            

        public HelpForm() : base(By.ClassName("help-form__container"), "Help Form")
        {
        }

        public void ClickSendToBottomButton()
        {
            sendToBottomButton.Click();
        }

        public bool IsHelpFormHidden()
        {
            const int hiddenFormHeight = 10;
            return ConditionalWait.WaitFor(() => hiddenHelpForm.Visual.Size.Height == hiddenFormHeight);
            //return hiddenHelpForm.State.WaitForDisplayed();
            
        }            
    }
}
