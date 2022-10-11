using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace Final_Assignment.Pages
{
    [TestFixture]
    class ExtentReportLogin
    {


        IWebDriver driver = null;
        ExtentReports extent = null;
        ExtentTest test = null;



        [OneTimeSetUp]
        public void ExtentStart()
        {
            extent = new ExtentReports();
            var htmlreporter = new ExtentHtmlReporter(@"C:\report\report" + DateTime.Now.ToString("_MMddyyyy_hhmmtt") + ".html");
            //var htmlreporter = new ExtentHtmlReporter(@"C:\report\report\ErrorScreenshot.html" + DateTime.Now.ToString("_MMddyyyy_hhmmtt") + ".html");
            extent.AttachReporter(htmlreporter);
            //var test = extent.CreateTest("Test A", "Sample Description");

        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            extent.Flush();

        }

        [Test]
        public void LoginMethod()
        {
            //ExtentReports extent = new ExtentReports();
            //var test = extent.CreateTest("Test A", "Sample Description");
            //var test1 = extent.StartTest("Test A", "Sample Description");
            // test.Log(Status.Info,"Validating the input field");



            try
            {
                test = extent.CreateTest("Test Passed Login Methode", "Sample Description").Info("Test Started");
                driver = new ChromeDriver();
                driver.Manage().Window.Maximize();
                test.Log(Status.Info, "Browser launched");
                driver.Url = "https://brightest-test.herokuapp.com/home";
                driver.Manage().Window.Maximize();
                WebElement email = (WebElement)driver.FindElement(By.Id("user_email"));
                WebElement paswword = (WebElement)driver.FindElement(By.Id("user_password"));
                WebElement LoginButton = (WebElement)driver.FindElement(By.XPath("//*[@id='login-form']/footer/button"));
                email.SendKeys("test.example@brightest.be");
                test.Log(Status.Info, "Email entered");
                paswword.SendKeys("example");
                test.Log(Status.Info, "Password entered");
                LoginButton.Click();
                driver.Quit();
                test.Log(Status.Pass, "Login Method passed");


            }
            catch (Exception e)
            {

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
        [Test]
        public void LoginMethodError()
        {


            try
            {
                test = extent.CreateTest("Test Failed Login Methode", "Sample Description").Info("Test Started");
                driver = new ChromeDriver();
                driver.Manage().Window.Maximize();
                test.Log(Status.Info, "Browser launched");
                driver.Url = "https://brightest-test.herokuapp.com/home";
                driver.Manage().Window.Maximize();
                WebElement email = (WebElement)driver.FindElement(By.Id("abcd"));
                email.SendKeys("test.example@brightest.be");
                test.Log(Status.Info, "Email entered");

            }
            catch (Exception e)
            {
                test.Log(Status.Fail, e.ToString());
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

