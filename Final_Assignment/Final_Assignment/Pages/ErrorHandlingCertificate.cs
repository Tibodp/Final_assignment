using AventStack.ExtentReports;
using AventStack.ExtentReports.Model;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace Final_Assignment.Pages
{
    [TestFixture]
    class ErrorHandlingCertificate : BaseTest
    {
        public By AddCertificateSelector => By.XPath("(//*[@id='wid-id-8']/div/div[2]/div/div/form/footer/a)[2]");
        public By CertificateNameSelector => By.XPath("//*[@id='certificate_certificate']");
        public By CertificateDistributorSelector => By.XPath("//*[@id='certificate_distributor']");
        public By EarnedYearSelector => By.XPath("//*[@id='certificate_year']");
        public By SaveSelector => By.Name("commit");


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
        public void AddCertificateError()
        {
            //ExtentReports extent = new ExtentReports();
            //var test = extent.CreateTest("Test A", "Sample Description");
            //var test1 = extent.StartTest("Test A", "Sample Description");
            // test.Log(Status.Info,"Validating the input field");

            ExtentReports extent = new ExtentReports();
            var htmlreporter = new ExtentHtmlReporter(@"C:\report\report" + DateTime.Now.ToString("_MMddyyyy_hhmmtt") + ".html");
            extent.AttachReporter(htmlreporter);
            var test = extent.CreateTest("Test A", "Sample Description");
            test.Log(Status.Info, "Validating test A");
            IWebDriver driver = new ChromeDriver();
            try
            {

                driver.Url = "https://brightest-test.herokuapp.com/home";
                driver.Manage().Window.Maximize();

                WebElement email = (WebElement)driver.FindElement(By.Id("user_email"));
                WebElement paswword = (WebElement)driver.FindElement(By.Id("user_password"));
                WebElement LoginButton = (WebElement)driver.FindElement(By.XPath("//*[@id='login-form']/footer/button"));
                email.SendKeys("test.example@brightest.be");
                paswword.SendKeys("example");
                LoginButton.Click();
                driver.Url = "https://brightest-test.herokuapp.com/curriculum_vitae_preview/edit";



                //WebElement UpdateRésumeButton = (WebElement)driver.FindElement(UpdateRésumeSelector);
                //UpdateRésumeButton.Click();

                WebElement AddCertificateButton = (WebElement)driver.FindElement(AddCertificateSelector);
                AddCertificateButton.Click();

                WebElement CertificateName = (WebElement)driver.FindElement(CertificateNameSelector);
                WebElement CertificateDistributor = (WebElement)driver.FindElement(CertificateDistributorSelector);
                WebElement CertificateEarnedYear = (WebElement)driver.FindElement(EarnedYearSelector);

                CertificateName.SendKeys("");
                CertificateDistributor.SendKeys("");
                CertificateEarnedYear.SendKeys("");

                WebElement Save = (WebElement)driver.FindElement(SaveSelector);
                Save.Click();

            }
            catch (Exception e)
            {

                takeScreenshot("Error Screenshot", driver);
                test.Log(Status.Info, "Scrrenshot - " + test.AddScreenCaptureFromPath("C:\\report\\Error Screenshot.jpeg"));
            
                extent.Flush();

                //driver.Quit();
            }
        }
    }
}

