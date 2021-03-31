using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using OpenQA.Selenium.Support;
using System.Reflection;
using System.Collections.Generic;
using SeleniumExtras.PageObjects;
using NUnit.Framework;


namespace CodilitySearchTest
{
    public  class SearchTest
    {
        IWebDriver Driver ;
        By sb = By.Id("search-button");
        By si = By.Id("search-input");
        private IWebElement searchbox;
        private IWebElement searchinput;
  
        [SetUp]
        public  void test_Openbrowser()
        {
            Driver = new ChromeDriver();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Driver.Url = "https://codility-frontend-prod.s3.amazonaws.com/media/task_static/qa_csharp_search/862b0faa506b8487c25a3384cfde8af4/static/attachments/reference_page.html";
            searchbox = Driver.FindElement(sb);
            searchinput = Driver.FindElement(si);
         }

        [Test]
        public  void test_Castle()
        {
            searchinput.Clear();
            searchinput.SendKeys("castle");
            searchbox.Click();
            IWebElement CastleSearchResults = Driver.FindElement((By.Id("error-no-results")));
            Assert.IsTrue(CastleSearchResults.Displayed);
            Assert.IsTrue(searchbox.Displayed);
            Assert.IsTrue(searchinput.Displayed);
        }
        
        [Test]
        public  void test_Port()
        {
            searchinput.Clear();
            searchinput.SendKeys("Port");
            searchbox.Click();
            IWebElement PortSearchResults = Driver.FindElement((By.XPath(".//ul[@id='search-results']/li")));
            Assert.IsTrue(PortSearchResults.Displayed);
        }

        [Test]
        public  void test_Blank()
        {
            searchinput.Clear();
            searchinput.SendKeys("");
            searchbox.Click();
            IWebElement emptySearchFeedback = Driver.FindElement(By.Id("error-empty-query"));
            Assert.IsTrue(emptySearchFeedback.Displayed);
        }

        [Test]
        public  void test_Isla()
        {
            searchinput.Clear();
            searchinput.SendKeys("isla");
            searchbox.Click();
            var islaSearchResults = Driver.FindElements((By.XPath(".//ul[@id='search-results']/li"))).Count;
            if (islaSearchResults > 0)
            {
                Console.WriteLine("Returned atleast one result: " + islaSearchResults);
            }
        }

        [TearDown]
        public void test_closeBrowser()
        {
            Driver.Quit();
        }
    }
}



