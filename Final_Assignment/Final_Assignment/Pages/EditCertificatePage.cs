using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace Final_Assignment.Pages
{
    [TestFixture]
    class EditCertificatePage : BaseComponent
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
        public void EditCertificate()
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


            // WebElement UpdateRésumeButton = (WebElement)driver.FindElement(UpdateRésumeSelector);
            //UpdateRésumeButton.Click();


            driver.Url = "https://brightest-test.herokuapp.com/curriculum_vitae_preview/edit";


            WebElement EditCertificate = (WebElement)driver.FindElement(EditCertificateSelector);
            EditCertificate.Click();


            WebElement CertificateName = (WebElement)driver.FindElement(CertificateNameSelector);
            CertificateName.Click();
            CertificateName.Clear();
            CertificateName.SendKeys("testCertificateName2");



            WebElement Save = (WebElement)driver.FindElement(SaveSelector);

            Save.Click();


            driver.Quit();
        }
    }
}

