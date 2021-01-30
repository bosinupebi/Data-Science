using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium
{
    class Program
    {
        static void Main(string[] args)
        {
             var driver = new ChromeDriver();
           
              
                driver.Navigate().GoToUrl("URL");
                driver.FindElement(By.Name("Username")).SendKeys("username");
                driver.FindElement(By.Name("Password")).SendKeys("password");
                driver.FindElement(By.Name("Password")).Submit();
                System.Threading.Thread.Sleep(5000);
                driver.FindElement(By.ClassName("mwLogout")).Click();
              
       
    






        }
    }
}
