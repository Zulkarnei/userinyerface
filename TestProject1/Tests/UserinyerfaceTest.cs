using Aquality.Selenium.Template.Utilities;
using Aquality.Selenium.Template.Pages;


namespace Aquality.Selenium.Template.NUnit.Tests
{
    public class UserinyerfaceTest : BaseTest
    {   
        private readonly MainPage mainPage = new MainPage();
        private readonly HomePage homePage = new HomePage();
        private readonly MailForm mailForm = new MailForm();
        private readonly AvatarAndInterestsForm avatarAndInterestsForm = new AvatarAndInterestsForm();
        private readonly CookiesForm cookiesForm = new CookiesForm();
        private readonly HelpForm helpForm = new HelpForm();
        private readonly PersonalDetialsForm personalDetialsForm = new PersonalDetialsForm();

        [Test]
        public void TestOfRegistrationSteps()
        {
            string email = RandomUtil.GenerateEmailPrefix();
            string password = RandomUtil.GenerateCustomPassword(email);
            string mailbox = RandomUtil.GenerateMailBox();
            int requiredInterests = JsonReader.GetRequiredInterests();
            Assert.IsTrue(mainPage.State.IsDisplayed);
            mainPage.ClickNextPageLink();
            Assert.IsTrue(mailForm.State.IsDisplayed);
            mailForm.ClearAndFillLoginForm(email, password,mailbox);
            mailForm.ClickDropDownButton();
            mailForm.ClickTermsAndConditions();
            mailForm.ClickNextButton();
            Assert.IsTrue(avatarAndInterestsForm.State.IsDisplayed);
            //avatarAndInterestsForm.ChooseInterests(requiredInterests);
            //avatarAndInterestsForm.UploadImage();
            //avatarAndInterestsForm.ClickNextButton();
            //Assert.IsTrue(personalDetialsForm.State.IsDisplayed);
        }
        [Test]
        public void TestOfHelpForm()
        {
            mainPage.ClickNextPageLink();
            Assert.IsTrue(homePage.State.IsDisplayed);
            helpForm.ClickSendToBottomButton();
            Assert.IsTrue(helpForm.IsHelpFormHidden());

        }
        [Test]
        public void TestOfCookiesForm()
        {
            mainPage.ClickNextPageLink();
            Assert.IsTrue(homePage.State.IsDisplayed);
            cookiesForm.AcceptCookies();
            Assert.IsFalse(cookiesForm.State.IsDisplayed);
        }
        [Test]
        public void TestOfTimer()
        {
            mainPage.ClickNextPageLink();
            Assert.That(homePage.GetTimerValue(), Does.StartWith("00:00"));
        }
    }
}
