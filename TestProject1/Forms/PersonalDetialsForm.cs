using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace Aquality.Selenium.Template.Pages
{ 
    public class PersonalDetialsForm : Form
    {
        public PersonalDetialsForm() : base(By.ClassName("personal-details"), "Third Card Form")
        {
        }
    }
}
