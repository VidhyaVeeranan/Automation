using BusinessLibrary;
using ConsoleApp2.BusinessLibrary;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestAutomation
{
    [TestFixture]
    public class FlipKart : TestBase
    {
        IWebDriver driver;
        ChromeOptions options = new ChromeOptions();
        Home home;
        string log = string.Empty;

        public FlipKart()
        {
            options.AddArgument("--start-maximized");
            driver = new ChromeDriver(System.AppDomain.CurrentDomain.BaseDirectory + "\\References", options);
            home = new Home(driver);
        }
                
        [Test]
        public void VerifyGlobalSearchInHomePage()
        {
            string searchText = "mobiles";
            string url = "https://www.flipkart.com/";

            home.GoToURL(url);

            home.EnterTextInGlobalSearchInHomePage(searchText);

            home.ClickGlobalSearchButtonInHomePage();

            home.VerifyGlobalSearchResultHeaderInHomePage(searchText);
        }

        [Test]
        public void VerifyIfApplePageLoads()
        {
            string menu = "Electronics", subMenu = "Apple";

            driver.Navigate().GoToUrl("https://www.flipkart.com/"); 

            home.clickMenu(menu);

            home.clickMenuItem(subMenu);

            home.VerifyIfApplePageIsDisplayed();
        }

        [TearDown]
        public void CleanUp()
        {
            driver.Close();
            driver.Quit();
        }
    }
}
