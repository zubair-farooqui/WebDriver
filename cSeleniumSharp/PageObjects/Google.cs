using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cSeleniumSharp.PageObjects
{
    class Google
    {
        private IWebDriver driver;

        [FindsBy(How = How.Name, Using = "q")]
        //[CacheLookup]
        public IWebElement QuerySerch { get; set; }

        public Google(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void Search(String SearchText)
        {
            QuerySerch.Clear();
            QuerySerch.SendKeys(SearchText);
            QuerySerch.Submit();
        }
    }
}
