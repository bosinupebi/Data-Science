using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using NUnit.Framework;
using System.Threading;
using OpenQA.Selenium.Support.UI;

namespace UnitTestProject1
{
    [TestFixture]
    public class UserLoginTest: TestFixtureBase
    {
        string URL = "https://condocontrolcentral.com:500/login";
        [Test]
        public void UserLoginMultipleWorkspace()
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl(URL);
            DoLoginAdminMultipleWorkspace(driver);
            Assert.AreEqual(driver.Url, "https://condocontrolcentral.com:500/login/multiple-workspace?NextPage=");
            driver.Quit();
        }
        [Test]
        public void UserLoginSingleWorkspace()
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl(URL);
            DoLoginAdminOneWorkspace(driver);
            Assert.AreEqual(driver.Url, "https://condocontrolcentral.com:500/my/my-home");
            driver.Quit();
    
        }
        [Test]
        public void UserLoginPortfolio()
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl(URL);
            DoLoginPortfolio(driver);
            Assert.AreEqual(driver.Url, "");
            driver.Quit();
        }
        [Test]
        public void UserLoginInvalidLogin()
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl(URL);
            driver.FindElement(By.Name("Username")).SendKeys("");
            driver.FindElement(By.Name("Password")).SendKeys("notpwd");
            driver.FindElement(By.Name("Password")).Submit();
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='validation-summary-errors text-danger']")));
            Assert.IsTrue(element.Displayed);
            driver.Quit();
        }
        [Test]
        public void UserLoginUsername()
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl(URL);
            DoLoginUsername(driver);
            Assert.AreEqual(driver.Url, "https://condocontrolcentral.com:500/my/my-home");
            driver.Quit();
        }
        [Test]
        public void UserForgotPassword()
        {
            var driver = new ChromeDriver();
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));
            driver.Navigate().GoToUrl(URL);
            DoForgotPassword(driver);
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//span[@id='ContentPlaceHolder1_msgLabel']")));
            Assert.IsTrue(element.Displayed);
            driver.Quit();
        }
    }
}
