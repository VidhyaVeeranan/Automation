using ConsoleApp2.BusinessLibrary;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestAutomation.PageObjects;

namespace BusinessLibrary
{
    public class Home : TestBase
    {
        HomePage homePage;
        IWebDriver driver;

        public Home(IWebDriver driver1)
        {
            homePage = new HomePage(driver1);
            driver = driver1;
        }

        /// <summary>
        /// Method to enter text in global search text box in home page
        /// Author: Vidhya
        /// </summary>
        /// <param name="text"></param>
        public void GoToURL(string text)
        {
            try
            {
                WriteToFile("Navigating to url: " + text);
                driver.Navigate().GoToUrl(text);
            }
            catch
            {
                Assert.Fail("Search is not working fine in home page");
            }
        }

        /// <summary>
        /// Method to click on close button on the popup in home page
        /// Author: Vidhya
        /// </summary>
        public void clickCloseButton()
        {
            homePage.closeButton().Click();
        }

        /// <summary>
        /// Method to click on menu name
        /// Author: Vidhya
        /// </summary>
        /// <param name="menu"></param>
        public void clickMenu(string menu)
        {
            clickCloseButton();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMinutes(2);
            Thread.Sleep(5000);
            Actions action = new Actions(driver);
            action.MoveToElement(homePage.menuButton()).Build().Perform();
            Thread.Sleep(2000);
            WriteToFile("Clicking on menu: " + menu);
        }

        /// <summary>
        /// Method to click on submenu
        /// Author: Vidhya
        /// </summary>
        /// <param name="menuItem"></param>
        public void clickMenuItem(string menuItem)
        {
            homePage.menuItemButton().Click();
            WriteToFile("Header: " + homePage.applePageHeader().Text);
        }

        /// <summary>
        /// Method to enter text in global search text box in home page
        /// Author: Vidhya
        /// </summary>
        /// <param name="text"></param>
        public void EnterTextInGlobalSearchInHomePage(string text)
        {
            try
            {
                clickCloseButton();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMinutes(2);
                homePage.globalSearchTextBox().SendKeys(text);
                WriteToFile("Entering text in global search test box: " + text);
            }
            catch
            {
                Assert.Fail("Search is not working fine in home page");
            }
        }

        /// <summary>
        /// Method to click on search button right after the global search text box in home page
        /// Author: Vidhya
        /// </summary>
        public void ClickGlobalSearchButtonInHomePage()
        {
            try
            {
                homePage.globalSearchButton().Click();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMinutes(2);
                WriteToFile("Clicked on global search button");
            }
            catch
            {
                Assert.Fail("Search is not working fine in home page");
            }
        }              

        /// <summary>
        /// Method to verify the search result header text in home page
        /// Author: Vidhya
        /// </summary>
        /// <param name="searchText"></param>
        public void VerifyGlobalSearchResultHeaderInHomePage(string searchText)
        {
            try
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMinutes(2);
                Assert.AreEqual(searchText, homePage.searchResultText().Text, "Global search result header is not showing the text: " + searchText);
                WriteToFile("Verified search result header with text: " + searchText);
            }
            catch
            {
                Assert.Fail("Search is not working fine in home page");
            }
        }

        /// <summary>
        /// Method to verify if the page for 'Apple' loads properly
        /// Author: Vidhya
        /// </summary>
        public void VerifyIfApplePageIsDisplayed()
        {
            try
            {
                Assert.IsTrue(homePage.applePageHeader().Displayed);
                WriteToFile("The page for 'Apple' is loading properly");
            }
            catch
            {
                Assert.Fail("Page for apple products is not displayed");
            }
        }
    }
}
