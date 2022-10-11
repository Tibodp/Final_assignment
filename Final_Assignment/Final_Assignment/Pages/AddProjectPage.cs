using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace Final_Assignment.Pages
{
    [TestFixture]
    class AddProjectPage : BaseComponent
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
        public void AddProject()
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



            //WebElement UpdateRésumeButton = (WebElement)driver.FindElement(UpdateRésumeSelector);
            //UpdateRésumeButton.Click();


            driver.Url = "https://brightest-test.herokuapp.com/curriculum_vitae_preview/edit";
            //WebElement CurriculumVitaButton = (WebElement)driver.FindElement(CurriculumVitaeSelector);
            //CurriculumVitaButton.Click();
            //WebElement LatestVersionCVButton = (WebElement)driver.FindElement(LatestVersionCVSelector);
            //LatestVersionCVButton.Click();
            // WebElement PreviewDraftCVButton = (WebElement)driver.FindElement(PreviewDraftCVSelector);
            //PreviewDraftCVButton.Click();
            //WebElement EditCurriculumVitaeButton = (WebElement)driver.FindElement(EditCurriculumVitaeSelector);
            //EditCurriculumVitaeButton.Click();


   
            WebElement AddProjectButton = (WebElement)driver.FindElement(AddProjectSelector);

            AddProjectButton.Click();

            WebElement ProjectName = (WebElement)driver.FindElement(ProjectNameSelector);
            WebElement ProjectRole = (WebElement)driver.FindElement(ProjectRoleSelector);
            WebElement StartDate = (WebElement)driver.FindElement(StartDateSelector);
            WebElement EndDate = (WebElement)driver.FindElement(EndDateSelector);
            WebElement ProjectDescription = (WebElement)driver.FindElement(ProjectDescriptionSelector);
            WebElement ProjectTasks = (WebElement)driver.FindElement(ProjectTasksSelector);
            WebElement ProjectTools = (WebElement)driver.FindElement(ProjectToolsSelector);
            WebElement ProjectIndustry = (WebElement)driver.FindElement(ProjectIndustrySelector);
            WebElement ProjectMethodology = (WebElement)driver.FindElement(ProjectMethodologySelector);



            ProjectName.SendKeys("testName1");
            ProjectRole.SendKeys("testRole1");
            StartDate.SendKeys("01/09/2022");
            EndDate.SendKeys("30/11/2022");
            ProjectDescription.SendKeys("testDescription1");
            ProjectTasks.SendKeys("testTask1");
            ProjectTools.SendKeys("testTool1");
            ProjectIndustry.SendKeys("testIndustry1");
            ProjectMethodology.SendKeys("testMethodology1");


            WebElement Save = (WebElement)driver.FindElement(SaveSelector);

            Save.Click();

            driver.Quit();
        }
    }
}



