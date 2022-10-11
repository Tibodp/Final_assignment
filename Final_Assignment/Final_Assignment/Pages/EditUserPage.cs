using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace Final_Assignment.Pages
{
    [TestFixture]
    class EditUserPage : BaseComponent
    {
        [Test]
        public void LoginMethod()
        {

            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://brightest-test.herokuapp.com/home";
            driver.Manage().Window.Maximize();

            WebElement email = (WebElement)driver.FindElement(By.Id("user_email"));
            WebElement paswword = (WebElement)driver.FindElement(By.Id("user_password"));
            WebElement Button = (WebElement)driver.FindElement(By.XPath("//*[@id='login-form']/footer/button"));

            email.SendKeys("test.example@brightest.be");
            paswword.SendKeys("example");
            Button.Click();
            driver.Quit();
        }




        [Test]
        public void EditUser()
        {
            //ExtentReports extent = new ExtentReports();
            //var test = extent.CreateTest("Test A", "Sample Description");


            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://brightest-test.herokuapp.com/home";
            driver.Manage().Window.Maximize();

            WebElement email = (WebElement)driver.FindElement(EmailSelector);
            WebElement paswword = (WebElement)driver.FindElement(PasswordSelector);
            WebElement LoginButton = (WebElement)driver.FindElement(LoginSelector);
            email.SendKeys("test.example@brightest.be");
            paswword.SendKeys("example");
            LoginButton.Click();


            driver.Url = "https://brightest-test.herokuapp.com/curriculum_vitae_preview/edit";

            //WebElement UpdateRésumeButton = (WebElement)driver.FindElement(UpdateRésumeSelector);

            //UpdateRésumeButton.Click();

            WebElement EditUserInfoButton = (WebElement)driver.FindElement(EditUserInfoSelector);

           EditUserInfoButton.Click();

            WebElement ProfileDescription = (WebElement)driver.FindElement(ProfileDescriptionSelector);
            WebElement Competencies = (WebElement)driver.FindElement(CompetenciesSelector);
            WebElement Education = (WebElement)driver.FindElement(EducationSelector);
            WebElement City = (WebElement)driver.FindElement(CitySelector);
            WebElement DateOfBirth = (WebElement)driver.FindElement(DateOfBirthSelector);

            ProfileDescription.Clear();

            ProfileDescription.SendKeys("testProfileDescription1 ");
            Competencies.SendKeys("testCompetencies1");
            Education.SendKeys("testEducation1");
            City.SendKeys("testCity1");
            DateOfBirth.SendKeys("10/09/1990");


            WebElement Save = (WebElement)driver.FindElement(SaveSelector);

            Save.Click();




            driver.Quit();
        }
    }
}
