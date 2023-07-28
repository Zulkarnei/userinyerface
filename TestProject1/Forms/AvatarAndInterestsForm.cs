using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;
using AutoIt;
using Aquality.Selenium.Template.Utilities;

namespace Aquality.Selenium.Template.Pages
{
    public class AvatarAndInterestsForm : Form
    {
        private IList<ICheckBox> checkBoxes;
        private ICheckBox unselectAllCheckbox;
        private ICheckBox unselectAllCheckboxInput;
        private readonly ITextBox checkBoxContainer = ElementFactory.Get<ITextBox>(By.ClassName("avatar-and-interests__interests-list"), "Check Box Container");
        private readonly IButton nextButton = ElementFactory.GetButton(By.CssSelector("button[name='button'][type='button'].button.button--stroked.button--white.button--fluid"), "Next Button");
        private readonly ILink uploadButton = ElementFactory.GetLink(By.CssSelector("a.avatar-and-interests__upload-button"), "Upload Button");
        private readonly ILabel avatarImage = ElementFactory.GetLabel(By.ClassName("avatar-and-interests__avatar-image"), "Avatar Image");


        public AvatarAndInterestsForm() : base(By.CssSelector("div.avatar-and-interests__form"), "Second Card Form")
        {
        }

        public void ChooseInterests(int requiredInterests)
        {
            checkBoxes = checkBoxContainer.FindChildElements<ICheckBox>(By.ClassName("avatar-and-interests__interests-list__item"));
            unselectAllCheckbox = checkBoxes.First(box => box.Text.Equals("Unselect all"));
            unselectAllCheckboxInput = unselectAllCheckbox.FindChildElement<ICheckBox>(By.ClassName("checkbox__box"));

            unselectAllCheckboxInput.Click();

            var checkBoxValues = checkBoxes
                .Where(box => !box.Text.Equals("Unselect all") && !box.Text.Equals("Select all"))
                .Select(box => box.Text)
                .ToList();

            for (int i = 0; i < requiredInterests; i++)
            {
                int randomIndex = RandomUtil.GetRandomIndex(checkBoxValues.Count);
                string interestText = checkBoxValues[randomIndex];

                var interestCheckbox = checkBoxes.First(box => box.Text.Equals(interestText));
                var interestCheckboxInput = interestCheckbox.FindChildElement<ICheckBox>(By.ClassName("checkbox__box"));
                interestCheckboxInput.Click();

                checkBoxValues.RemoveAt(randomIndex);
            }
        }

     


        public void ClickNextButton()
        {
            
            nextButton.WaitAndClick();
        }

        public void UploadImage()
        {
            string avatarImagePath = PathUtil.GetAvatarImagePath();
            uploadButton.Click();
            AutoItX.Sleep(1000);
            AutoItX.Send(avatarImagePath);
            AutoItX.Send("{ENTER}");
            avatarImage.State.WaitForDisplayed();
     
        }
    }
}
