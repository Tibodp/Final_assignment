using AventStack.ExtentReports;
using Final_Assignment.Pages;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Safari;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Assignment
{
    [TestFixture]
    [Parallelizable]
    public class Tests : BaseTest
    {

        [Test]
        [TestCaseSource(typeof(BaseTest), "BrowserToRunWith")]
        public void LoginMethod(String browserName)
        {
            LaunchBrowser(browserName);
            ExtentReports extent = new ExtentReports();
            var test = extent.CreateTest("Test A", "Sample Description");

            driver.Url = "https://brightest-test.herokuapp.com/home";

            WebElement email = (WebElement)driver.FindElement(By.XPath("//*[@id='user_email']"));
            WebElement paswword = (WebElement)driver.FindElement(By.XPath("//*[@id='user_password']"));
            WebElement Button = (WebElement)driver.FindElement(By.XPath("//*[@id='login-form']/footer/button"));

            email.SendKeys("test.example@brightest.be");
            paswword.SendKeys("example");
            Button.Click();

            extent.Flush();
            //driver.Quit();
        }

        [Test]
        public void LoginMethodCloudSync()
        {
            IWebElement email = (WebElement)driver.FindElement(By.XPath("//*[@id='user_email']"));
            email.SendKeys("test.example@brightest.be");

            IWebElement paswword = (WebElement)driver.FindElement(By.XPath("//*[@id='user_password']"));
            paswword.SendKeys("example");

            IWebElement LoginButton = (WebElement)driver.FindElement(By.XPath("//*[@id='login-form']/footer/button"));
            LoginButton.Click();

        }

        [Test]
        [TestCaseSource(typeof(BaseTest), "BrowserToRunWith")]
        public void AddAndDeleteProject(String browserName)
        {
            LaunchBrowser(browserName);
            //Login
            IWebElement email = (WebElement)driver.FindElement(By.XPath("//*[@id='user_email']"));
            email.SendKeys("test.example@brightest.be");

            IWebElement paswword = (WebElement)driver.FindElement(By.XPath("//*[@id='user_password']"));
            paswword.SendKeys("example");

            IWebElement LoginButton = (WebElement)driver.FindElement(By.XPath("//*[@id='login-form']/footer/button"));
            LoginButton.Click();

            //Update Résume
            WebElement UpdateRésumeButton = (WebElement)driver.FindElement(By.XPath("//*[@id='main']/div[2]/p/a"));

            UpdateRésumeButton.Click();

            WebElement AddProjectButton = (WebElement)driver.FindElement(By.XPath("(//*[@id='wid-id-8']/div/div[2]/div/div/form/footer/a)[1]"));

            AddProjectButton.Click();

            WebElement ProjectName = (WebElement)driver.FindElement(By.XPath("//*[@id='project_name']"));
            WebElement ProjectRole = (WebElement)driver.FindElement(By.XPath("//*[@id='project_role']"));
            WebElement StartDate = (WebElement)driver.FindElement(By.XPath("//*[@id='project_start_date']"));
            WebElement EndDate = (WebElement)driver.FindElement(By.XPath("//*[@id='project_end_date']"));
            WebElement ProjectDescription = (WebElement)driver.FindElement(By.XPath("//*[@id='project_description']"));
            WebElement ProjectTasks = (WebElement)driver.FindElement(By.XPath("//*[@id='project_tasks']"));
            WebElement ProjectTools = (WebElement)driver.FindElement(By.XPath("//*[@id='project_tools']"));
            WebElement ProjectIndustry = (WebElement)driver.FindElement(By.XPath("//*[@id='project_industry']"));
            WebElement ProjectMethodology = (WebElement)driver.FindElement(By.XPath("//*[@id='project_methodology']"));

            ProjectName.SendKeys("Test Project");
            ProjectRole.SendKeys("Tester");
            StartDate.SendKeys("12/09/2022");
            EndDate.SendKeys("13/09/2022");
            ProjectDescription.SendKeys("Dit is een Test voor de POC");
            ProjectTasks.SendKeys("POC maken");
            ProjectTools.SendKeys("C#, Selenium, NUnit");
            ProjectIndustry.SendKeys("Birghtest");
            ProjectMethodology.SendKeys("Opleiding");

            WebElement Save = (WebElement)driver.FindElement(By.Name("commit"));

            Save.Click();

            WebElement Delete = (WebElement)driver.FindElement(By.XPath("//*[@id='wid-id-8']/div/div[2]/div/div/table/tbody/tr/td[9]/a[1]/i"));

            Delete.Click();

            IAlert simpleAlert = driver.SwitchTo().Alert();

            simpleAlert.Accept();

        }

        [Test]
        [TestCaseSource(typeof(BaseTest), "BrowserToRunWith")]
        public void FillInOtherSpecifications(String browserName)
        {
            LaunchBrowser(browserName);

            //Login
            IWebElement email = (WebElement)driver.FindElement(By.XPath("//*[@id='user_email']"));
            email.SendKeys("test.example@brightest.be");

            IWebElement paswword = (WebElement)driver.FindElement(By.XPath("//*[@id='user_password']"));
            paswword.SendKeys("example");

            IWebElement LoginButton = (WebElement)driver.FindElement(By.XPath("//*[@id='login-form']/footer/button"));
            LoginButton.Click();

            //Update Résume
            WebElement UpdateRésumeButton = (WebElement)driver.FindElement(By.XPath("//*[@id='main']/div[2]/p/a"));

            UpdateRésumeButton.Click();

            //Add Certificate
            WebElement AddCertificateButton = (WebElement)driver.FindElement(By.XPath("(//*[@id='wid-id-8']/div/div[2]/div/div/form/footer/a)[2]"));

            AddCertificateButton.Click();

            WebElement CertificateName = (WebElement)driver.FindElement(By.XPath("//*[@id='certificate_certificate']"));
            WebElement CertificateDistributor = (WebElement)driver.FindElement(By.XPath("//*[@id='certificate_distributor']"));
            WebElement EarnedYear = (WebElement)driver.FindElement(By.XPath("//*[@id='certificate_year']"));

            CertificateName.SendKeys("Test Certificate");
            CertificateDistributor.SendKeys("Tester");
            EarnedYear.SendKeys("2022");

            WebElement Save = (WebElement)driver.FindElement(By.Name("commit"));

            Save.Click();

            //Add Skill
            WebElement AddSkillButton = (WebElement)driver.FindElement(By.XPath("(//*[@id='wid-id-8']/div/div[2]/div/div/form/footer/a)[3]"));

            AddSkillButton.Click();

            WebElement SkillName = (WebElement)driver.FindElement(By.XPath("//*[@id='technical_skill_technical_skill']"));
            WebElement SkillLevel = (WebElement)driver.FindElement(By.XPath("//*[@id='technical_skill_level']"));

            SkillName.SendKeys("Test Skill");
            SkillLevel.SendKeys("Basic");

            WebElement Save2 = (WebElement)driver.FindElement(By.Name("commit"));

            Save2.Click();

            //Add Training
            WebElement AddTrainingButton = (WebElement)driver.FindElement(By.XPath("(//*[@id='wid-id-8']/div/div[2]/div/div/form/footer/a)[4]"));

            AddTrainingButton.Click();

            WebElement TrainingName = (WebElement)driver.FindElement(By.XPath("//*[@id='training_training']"));
            WebElement TrainingDistributor = (WebElement)driver.FindElement(By.XPath("//*[@id='training_distributor']"));
            WebElement EarnedYearTraining = (WebElement)driver.FindElement(By.XPath("//*[@id='training_year']"));
            WebElement Topics = (WebElement)driver.FindElement(By.XPath("//*[@id='training_topics']"));

            TrainingName.SendKeys("Test Training");
            TrainingDistributor.SendKeys("Brightest");
            EarnedYearTraining.SendKeys("2022");
            Topics.SendKeys("Hello Trianing");

            WebElement Save3 = (WebElement)driver.FindElement(By.Name("commit"));

            Save3.Click();

            //Add Language
            WebElement AddLanguageButton = (WebElement)driver.FindElement(By.XPath("(//*[@id='wid-id-8']/div/div[2]/div/div/form/footer/a)[5]"));

            AddLanguageButton.Click();

            WebElement LanguageName = (WebElement)driver.FindElement(By.XPath("//*[@id='language_language']"));
            WebElement SpokenLevel = (WebElement)driver.FindElement(By.XPath("//*[@id='language_level_spoken']"));
            WebElement WrittenLevel = (WebElement)driver.FindElement(By.XPath("//*[@id='language_level_written']"));
            WebElement Comprehension = (WebElement)driver.FindElement(By.XPath("//*[@id='language_level_comprehension']"));

            LanguageName.SendKeys("Test Language");
            SpokenLevel.SendKeys("Fluent");
            WrittenLevel.SendKeys("Advanced");
            Comprehension.SendKeys("Intermediate");

            WebElement Save4 = (WebElement)driver.FindElement(By.Name("commit"));

            Save4.Click();

            WebElement DeleteCertificate = (WebElement)driver.FindElement(By.XPath("//*[@id='wid-id-8']/div/div[2]/div/div/table/tbody/tr/td[4]/a[1]/i"));


            DeleteCertificate.Click();

            IAlert simpleAlert = driver.SwitchTo().Alert();

            simpleAlert.Accept();

            WebElement DeleteSkill = (WebElement)driver.FindElement(By.XPath("//*[@id='wid-id-8']/div/div[2]/div/div/table/tbody/tr/td[3]/a[1]/i"));

            DeleteSkill.Click();

            driver.SwitchTo().Alert();

            simpleAlert.Accept();

            WebElement DeleteTraining = (WebElement)driver.FindElement(By.XPath("(//*[@id='wid-id-8']/div/div[2]/div/div/table/tbody/tr/td[5]/a[1]/i)[1]"));

            DeleteTraining.Click();

            driver.SwitchTo().Alert();

            simpleAlert.Accept();

            WebElement DeleteLanguage = (WebElement)driver.FindElement(By.XPath("(//*[@id='wid-id-8']/div/div[2]/div/div/table/tbody/tr/td[5]/a[1]/i)[1]"));

            DeleteLanguage.Click();

            driver.SwitchTo().Alert();

            simpleAlert.Accept();

        }

        [TearDown]
        public void CleanUp()
        {
            driver.Quit();
        }

    }
}
