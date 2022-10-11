using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Text;

namespace Final_Assignment.Pages
{
    public class BaseComponent
    {
        // element selectors to be moved to individual page classes
        public By EmailSelector => By.XPath("//*[@id='user_email']");
        public By PasswordSelector => By.XPath("//*[@id='user_password']");
        public By LoginSelector => By.XPath("//*[@id='login-form']/footer/button");
        public By CurriculumVitaeSelector => By.XPath("//*[@id='left-panel']/nav/ul/li[4]/a/span");
        public By LatestVersionCVSelector => By.XPath("//*[@id='left-panel']/nav/ul/li[4]/ul/li[1]/a/i");
        public By PreviewDraftCVSelector => By.XPath("//*[@id='left-panel']/nav/ul/li[4]/ul/li[2]/a/i");
        //public By EditCurriculumVitaeSelector => By.XPath("//*[@id='left-panel']/nav/ul/li[4]/ul/li[3]/a/i");
        public By EditCurriculumVitaeSelector => By.XPath("//*[@id='left-panel']/nav/ul/li[4]/ul/li[3]/a");


        public By UpdateRésumeSelector => By.XPath("//*[@id='main']/div[2]/p/a");
        public By AddProjectSelector => By.XPath("(//*[@id='wid-id-8']/div/div[2]/div/div/form/footer/a)[1]");
        public By ProjectNameSelector => By.XPath("//*[@id='project_name']");
        public By ProjectRoleSelector => By.XPath("//*[@id='project_role']");
        public By StartDateSelector => By.XPath("//*[@id='project_start_date']");
        public By EndDateSelector => By.XPath("//*[@id='project_end_date']");
        public By ProjectDescriptionSelector => By.XPath("//*[@id='project_description']");
        public By ProjectTasksSelector => By.XPath("//*[@id='project_tasks']");
        public By ProjectToolsSelector => By.XPath("//*[@id='project_tools']");
        public By ProjectIndustrySelector => By.XPath("//*[@id='project_industry']");
        public By ProjectMethodologySelector => By.XPath("//*[@id='project_methodology']");
        public By AddCertificateSelector => By.XPath("(//*[@id='wid-id-8']/div/div[2]/div/div/form/footer/a)[2]");
        public By CertificateNameSelector => By.XPath("//*[@id='certificate_certificate']");
        public By CertificateDistributorSelector => By.XPath("//*[@id='certificate_distributor']");
        public By EarnedYearSelector => By.XPath("//*[@id='certificate_year']");
        public By AddSkillSelector => By.XPath("(//*[@id='wid-id-8']/div/div[2]/div/div/form/footer/a)[3]");
        public By SkillNameSelector => By.XPath("//*[@id='technical_skill_technical_skill']");
        public By SkillLevelSelector => By.XPath("//*[@id='technical_skill_level']");
        public By AddTrainingSelector => By.XPath("(//*[@id='wid-id-8']/div/div[2]/div/div/form/footer/a)[4]");
        public By TrainingNameSelector => By.XPath("//*[@id='training_training']");
        public By TrainingDistributorSelector => By.XPath("//*[@id='training_distributor']");
        public By EarnedYearTrainingSelector => By.XPath("//*[@id='training_year']");
        public By TopicsSelector => By.XPath("//*[@id='training_topics']");
        public By AddLanguageSelector => By.XPath("(//*[@id='wid-id-8']/div/div[2]/div/div/form/footer/a)[5]");
        public By LanguageNameSelector => By.XPath("//*[@id='language_language']");
        public By SpokenLevelSelector => By.XPath("//*[@id='language_level_spoken']");
        public By WrittenLevelSelector => By.XPath("//*[@id='language_level_written']");
        public By ComprehensionSelector => By.XPath("//*[@id='language_level_comprehension']");
        public By SaveSelector => By.Name("commit");
        public By DeleteSelector => By.XPath("//*[@id='wid-id-8']/div/div[2]/div/div/table/tbody/tr/td[9]/a[1]/i");
        public By DeleteCertificateSelector => By.XPath("//*[@id='wid-id-8']/div/div[2]/div/div/table/tbody/tr/td[4]/a[1]/i");
        // public By DeleteCertificateSelector => By.XPath("//*[@id='wid-id-8']/div/div[2]/div/div/table/tbody/tr/td[4]/a[1]/i");
        public By DeleteSkillSelector => By.XPath("//*[@id='wid-id-8']/div/div[2]/div/div/table/tbody/tr/td[3]/a[1]/i");
        public By DeleteTrainingSelector => By.XPath("(//*[@id='wid-id-8']/div/div[2]/div/div/table/tbody/tr/td[5]/a[1]/i)[1]");
        public By DeleteLanguageSelector => By.XPath("(//*[@id='wid-id-8']/div/div[2]/div/div/table/tbody/tr/td[5]/a[1]/i)[1]");
        public By EditCertificateSelector => By.XPath("//*[@id='wid-id-8']/div/div[2]/div/div/table/tbody/tr/td[4]/a[2]/i");
        public By EditProjectSelector => By.XPath("//*[@id='wid-id-8']/div/div[2]/div/div/table/tbody/tr/td[9]/a[2]/i");
        public By DeleteProjectSelector => By.XPath("//*[@id='wid-id-8']/div/div[2]/div/div/table/tbody/tr/td[9]/a[1]/i");
        //public By DeleteProjectSelector => By.XPath("//*[@id='wid-id-8']/div/div[2]/div/div/table/tbody/tr/td[9]/a[1]");
        public By EditUserInfoSelector = By.XPath("//*[@id='wid-id-8']/div/div[2]/form/footer/a");
        public By ProfileDescriptionSelector = By.XPath("//*[@id='user_profile']");
        public By CompetenciesSelector = By.XPath("//*[@id='user_competencies']");
        public By EducationSelector = By.XPath("//*[@id='user_education']");
        public By CitySelector = By.XPath("//*[@id='user_city']");
        public By DateOfBirthSelector = By.XPath("//*[@id='user_date_of_birth']");










    }
}
