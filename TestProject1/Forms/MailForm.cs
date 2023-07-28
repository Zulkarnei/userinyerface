using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace Aquality.Selenium.Template.Pages
{
    public class MailForm : Form
    {
        private readonly ITextBox passwordTextBox = ElementFactory.GetTextBox(By.CssSelector(".login-form__field-row input[placeholder='Choose Password']"), "Password input");
        private readonly ITextBox emailTextBox = ElementFactory.GetTextBox(By.CssSelector(".login-form__field-row input[placeholder='Your email']"), "Email input");
        private readonly ITextBox domainTextBox = ElementFactory.GetTextBox(By.CssSelector(".login-form__fields .input--blue[placeholder='Domain']"), "Domain TextBox");
        private readonly IButton nextButton = ElementFactory.GetButton(By.CssSelector("a.button--secondary"), "Next button");
        private readonly ICheckBox termsConditionsCheckbox = ElementFactory.GetCheckBox(By.CssSelector(".checkbox__box .icon-check"), "Terms & Conditions checkbox");
        private readonly IButton dropDownButton = ElementFactory.GetButton(By.XPath("//div[contains(@class, 'dropdown--gray')]"), "Drop Down Button");
        private IList<ITextBox> mailSuffixes;

        public MailForm() : base(By.CssSelector(".login-form__container"), "First Card Form")
        {
        }

        public void ClearAndFillLoginForm(string email, string password, string mailBox)
        {
            passwordTextBox.ClearAndType(password);
            emailTextBox.ClearAndType(email);
            domainTextBox.ClearAndType(mailBox);
        }

        public void ClickTermsAndConditions()
        {
            termsConditionsCheckbox.Click();
        }

        public void ClickDropDownButton()
        {
            dropDownButton.Click();

            if (MailSuffixes.Count > 0)
            {
                int randomIndex = new Random().Next(MailSuffixes.Count);
                MailSuffixes[randomIndex].Click();
            }
        }

        public void ClickNextButton()
        {
            nextButton.Click();
        }

        private IList<ITextBox> MailSuffixes
        {
            get
            {
                if (mailSuffixes == null)
                {
                    mailSuffixes = ElementFactory.FindChildElements<ITextBox>(dropDownButton, By.ClassName("dropdown__list-item"))
                        .Where(suffix => suffix.Text != "other")
                        .ToList();
                }
                return mailSuffixes;
            }
        }
    }
}
