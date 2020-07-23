using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAutomation.PageObjects
{
    public class HomePage
    {
        IWebDriver driver;
        public HomePage(IWebDriver driver1)
        {
            driver = driver1;
        }

        public IWebElement closeButton()
        {
            return driver.FindElement(By.XPath("//button[text()='✕']"));
        }

        public IWebElement menuButton()
        {
            return driver.FindElement(By.XPath("//span[text()='Electronics']"));
        }

        public IWebElement menuItemButton()
        {
            return driver.FindElement(By.XPath("//a[text()='Apple']"));
        }

        public IWebElement applePageHeader()
        {
            return driver.FindElement(By.XPath("//h1[text()='Apple Store']"));
        }

        public IWebElement globalSearchTextBox()
        {
            return driver.FindElement(By.XPath("//input[@title='Search for products, brands and more']"));
        }

        public IWebElement globalSearchButton()
        {
            return driver.FindElement(By.XPath("//input[@title='Search for products, brands and more']/ancestor::div/following::button[@type='submit']"));
        }

        public IWebElement searchResultText()
        {
            return driver.FindElement(By.XPath("//span[contains(text(), 'results for')]/span"));
        }
    }
}
