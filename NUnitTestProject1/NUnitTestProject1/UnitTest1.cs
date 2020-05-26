using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace NUnitTestProjectAnya
{
    public class Tests
    {
        private IWebDriver driver;


        [OneTimeSetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:5000/");
            driver.Manage().Window.Maximize();
        }

        [Test, Order(1)]
        public void Login()
        {
            driver.FindElement(By.XPath("//input[@id='Name']")).SendKeys("user");
            driver.FindElement(By.XPath("//input[@id='Password']")).SendKeys("user");
            driver.FindElement(By.XPath("//input[@class='btn btn-default']")).Click();

            Assert.AreEqual("Home page", driver.FindElement(By.XPath("//div[h2= 'Home page']")).Text);
        }

        [Test, Order(2)]
        public void Add()
        {

            driver.FindElement(By.XPath("//div[h2='Home page']//preceding::a[@href ='/Product']")).Click();
            driver.FindElement(By.XPath("//a[@class = 'btn btn-default']")).Click();
            driver.FindElement(By.XPath("//input[@id = 'ProductName']")).SendKeys("морс");
            driver.FindElement(By.XPath("//select[@id= 'CategoryId']/child::option[@value = '7']")).Click();
            driver.FindElement(By.XPath("//select[@id= 'SupplierId']/child::option[@value = '5']")).Click();
            driver.FindElement(By.XPath("//input[@id = 'UnitPrice']")).SendKeys("30");
            driver.FindElement(By.XPath("//input[@id = 'QuantityPerUnit']")).SendKeys("95");
            driver.FindElement(By.XPath("//input[@id = 'UnitsInStock']")).SendKeys("6");
            driver.FindElement(By.XPath("//input[@id = 'UnitsOnOrder']")).SendKeys("74");
            driver.FindElement(By.XPath("//input[@id = 'ReorderLevel']")).SendKeys("8");
            driver.FindElement(By.XPath("//input[@type = 'submit']")).Click();

            Assert.AreEqual("Create new", driver.FindElement(By.XPath("//a[@href='/Product/Create']")).Text);

        }

        [Test, Order(3)]
        public void Logout()
        {

            driver.FindElement(By.XPath("//a[@href='/Account/Logout']")).Click();

            Assert.AreEqual("Login", driver.FindElement(By.XPath("//div[h2=\"Login\"]")).Text);
        }


        [OneTimeTearDown]
        public void CleanUp()
        {
            driver.Close();
            driver.Quit();
        }

    }
}
