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
    class ErrorHandlingScreenshot : BaseTest
    {
        new IWebDriver driver = null;
        ExtentReports extent = null;
        ExtentTest test = null;



        [OneTimeSetUp]
        public void ExtentStart()
        {
            extent = new ExtentReports();
            //var htmlreporter = new ExtentHtmlReporter(@"C:\\report\\report" + DateTime.Now.ToString("_MMddyyyy_hhmmtt") + ".html");
            var htmlreporter = new ExtentHtmlReporter(@"C:\\report\\report" + DateTime.Now.ToString("_MMddyyyy_hhmmtt") + ".html");
            extent.AttachReporter(htmlreporter);

        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            extent.Flush();

        }


        [Test]
        public void TestFailedScreenshot()
        {
            driver = new ChromeDriver();

            try
            {
                test = extent.CreateTest("Test Failed Screenshot Certificate Methode", "Sample Description").Info("Test Started");
                driver.Manage().Window.Maximize();
                test.Log(Status.Info, "Browser launched");
                driver.Url = "https://brightest-test.herokuapp.com/home";
                driver.Manage().Window.Maximize();
                WebElement email = (WebElement)driver.FindElement(By.Id("user_email"));
                WebElement paswword = (WebElement)driver.FindElement(By.Id("user_password"));
                WebElement LoginButton = (WebElement)driver.FindElement(By.XPath("//*[@id='login-form']/footer/button"));
                email.SendKeys("test.example@brightest.be");
                paswword.SendKeys("example");
                LoginButton.Click();
                string title = driver.Title;
                Assert.AreEqual("Home - Automation Test", title);
                test.Log(Status.Fail, "Test Failed");


                // driver.Url = "https://brightest-test.herokuapp.com/curriculum_vitae_preview/edit";
                // WebElement AddCertificateButton = (WebElement)driver.FindElement(By.LinkText("Add"));
                // AddCertificateButton.Click();
            }
            catch (Exception e)
            {
                // test.Log(Status.Fail, e.ToString());
                takeScreenshot("screenshot", driver);
                //test.Log(Status.Info, "Screenshot - " + test.AddScreenCaptureFromPath(@"C:\\report\\report\\ErrorScreenshot.Png"));
                test.Log(Status.Fail, "screenshot - " + test.AddScreenCaptureFromPath(@"C:\\report\\report\\screenshot.Png"));


                throw;
            }

            finally
            {
                if (driver != null)
                {

                    driver.Quit();
                }
            }
        }

    }
}
