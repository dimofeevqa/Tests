using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DemoTests
{
    public class Tests
    {
        private WebDriver driver;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://taskboard-212f.onrender.com/");
            driver.Manage().Window.Maximize();
        }
        [TearDown]
        protected void TearDown()
        {
            driver.Dispose();
        }
        public void test1()
        {
            driver.FindElement(By.LinkText("Search")).Click();
            driver.FindElement(By.Id("keyword")).SendKeys("fsdfds");
            driver.FindElement(By.Id("search")).Click();
            driver.FindElement(By.Id("searchResult")).Click();
            Assert.That(driver.FindElement(By.Id("searchResult")).Text, Is.EqualTo("No tasks found."));
        }

        public void test2()
        {
            driver.FindElement(By.LinkText("Search")).Click();
            driver.FindElement(By.Id("keyword")).SendKeys("Edit tasks");
            driver.FindElement(By.Id("search")).Click();
            driver.FindElement(By.CssSelector("body")).Click();
            Assert.That(driver.FindElement(By.Id("searchResult")).Text, Is.EqualTo("tasks found."));
        }

        [TestCase("fsdfds", "No tasks found.")]
        [TestCase("Edit tasks", "tasks found.")]
        public void test3(string searchTerm, string expected)
        {
            driver.FindElement(By.LinkText("Search")).Click();
            driver.FindElement(By.Id("keyword")).SendKeys(searchTerm);
            driver.FindElement(By.Id("search")).Click();
            driver.FindElement(By.CssSelector("body")).Click();
            Assert.That(driver.FindElement(By.Id("searchResult")).Text, Is.EqualTo(expected));
        }
    }
}