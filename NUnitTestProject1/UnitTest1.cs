using System;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.iOS;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;

namespace NUnitTestProject1
{
    public class Tests
    {

        private string accessKey = "";
        private string testName = "iOS App Test with C#";

        protected IOSDriver<IOSElement> driver = null;
        WebDriverWait wait = null;

        protected AppiumOptions caps = new AppiumOptions();

        [SetUp()]
        public void SetupTest()
        {
            caps.AddAdditionalCapability("testName", testName);
            caps.AddAdditionalCapability("accessKey", accessKey);
            caps.AddAdditionalCapability("deviceQuery", "@os='ios'"); // 59d59885e23abfde01e489394165c0ba3b106ad5
            caps.AddAdditionalCapability("app", "cloud:com.experitest.ExperiBank");
            caps.AddAdditionalCapability("bundleId", "com.experitest.ExperiBank");

            driver = new IOSDriver<IOSElement>(
                    new Uri("https://uscloud.experitest.com/wd/hub"), caps);
             wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        [Test()]
        public void test1()
        {
            driver.ExecuteScript("seetest:client.startPerformanceTransactionForApplication(\"com.experitest.ExperiBank\", \"4G-Lossy\")");
            
            driver.FindElement(By.Id("usernameTextField")).SendKeys("company");
            driver.FindElement(By.Id("passwordTextField")).SendKeys("company");
            driver.FindElement(By.Id("loginButton")).Click();

            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("Make Payment")));

            driver.ExecuteScript("seetest:client.endPerformanceTransaction(\"ExperiBank_Login_C#\")");
        }

        [Test()]
        public void test2()
        {
            driver.ExecuteScript("seetest:client.startPerformanceTransactionForApplication(\"com.experitest.ExperiBank\", \"3G-average\")");


            driver.FindElement(By.Id("usernameTextField")).SendKeys("company");
            driver.FindElement(By.Id("passwordTextField")).SendKeys("company");
            driver.FindElement(By.Id("loginButton")).Click();

            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("Make Payment")));

            driver.ExecuteScript("seetest:client.endPerformanceTransaction(\"ExperiBank_Login_C#\")");
        }

        [Test()]
        public void test3()
        {
            driver.ExecuteScript("seetest:client.startPerformanceTransactionForApplication(\"com.experitest.ExperiBank\", \"4G-High-Latency\")");

            driver.FindElement(By.Id("usernameTextField")).SendKeys("company");
            driver.FindElement(By.Id("passwordTextField")).SendKeys("company");
            driver.FindElement(By.Id("loginButton")).Click();

            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("Make Payment")));

            driver.ExecuteScript("seetest:client.endPerformanceTransaction(\"ExperiBank_Login_C#\")");
        }

        [TearDown()]
        public void TearDown()
        {
            if (driver != null)
            {
                Console.WriteLine(driver.Capabilities.GetCapability("reportUrl"));
                driver.Quit();
            }
        }

    }
}