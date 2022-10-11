using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Safari;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Final_Assignment.Pages
{
    public class BaseTest
    {
        protected IWebDriver driver;

        public static void takeScreenshot(string filename, IWebDriver driver)
        {
            ITakesScreenshot screenshotDriver = driver as ITakesScreenshot;
            Screenshot screenshot = screenshotDriver.GetScreenshot();
            //screenshot.SaveAsFile("C:\\report\\" + filename + ".Png", ScreenshotImageFormat.Gif);
           screenshot.SaveAsFile("C:\\report\\report" + filename + ".Png", ScreenshotImageFormat.Png);
           
        }

        public void LaunchBrowser(String browserName)
        {
            // check if running remote or local from config file
            var settings = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();
            var remote = settings["Remote"];

            if (remote == "false")
            {
                if (browserName.Equals("Firefox"))
                    driver = new FirefoxDriver();
                else if (browserName.Equals("Chrome"))
                    driver = new ChromeDriver();
                else if (browserName.Equals("Edge"))
                    driver = new EdgeDriver();
                else
                    driver = new InternetExplorerDriver();

                driver.Url = "https://brightest-test.herokuapp.com/home";
            }
            else
            {
                dynamic capabilty = GetBrowserOptions(browserName);
                Dictionary<string, object> ltOptions = new Dictionary<string, object>();
                ltOptions.Add("username", settings["UserName"]);
                ltOptions.Add("accessKey", settings["AccessKey"]);
                ltOptions.Add("platformName", "Windows 10");
                ltOptions.Add("project", settings["ProjectName"]);
                ltOptions.Add("build", settings["BuildName"]);
                ltOptions.Add("selenium_version", "4.0.0");
                ltOptions.Add("w3c", true);
                capabilty.AddAdditionalOption("LT:Options", ltOptions);

                //setup driver
                driver = new RemoteWebDriver(new Uri("https://" + settings["UserName"] + ":" + settings["AccessKey"] + settings["URL"]), capabilty.ToCapabilities());

                driver.Url = settings["Environment"];

            }
            driver.Manage().Window.Maximize();
        }

        public static IEnumerable<string> BrowserToRunWith()
        {
            var settings = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json")
               .Build();

            var browsers = settings.GetSection("BrowserSettings:Browsers").Get<String[]>();

            foreach (String browser in browsers)
            {
                yield return browser;
            }
        }

        public dynamic GetBrowserOptions(string browsername)
        {
            if (browsername == "Chrome")
                return new ChromeOptions();
            if (browsername == "Safari")
                return new SafariOptions();
            if (browsername == "Firefox")
                return new FirefoxOptions();
            if (browsername == "Edge")
                return new EdgeOptions();
            if (browsername == "Internet Explorer")
                return new InternetExplorerOptions();

            //if non, return chrome
            return new ChromeOptions();
        }
    }
}
