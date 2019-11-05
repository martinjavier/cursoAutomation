using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Chrome;
using CasosPrueba.Pages;

namespace CasosPrueba
{
    [TestClass]
    public class Class1
    {
        public IWebDriver browserDriver;
        public string projectURL = "http://automationpractice.com/index.php";
        
        [TestMethod]
        public void TestCase_1000()
        {
            // Searching

            ChromeOptions ChromeOp = new ChromeOptions();
            ChromeOp.AddAdditionalCapability("useAutomationExtension", false);
            browserDriver = new ChromeDriver(ChromeOp);
            // Apertura de la Web
            browserDriver.Navigate().GoToUrl(projectURL);
            // Maximizar la Ventana
            browserDriver.Manage().Window.Maximize();
            // Configuración de la espera
            browserDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);

            PageIndex indexPage = new PageIndex();

            string searchValue = "dress";

            bool searchElement = indexPage.searchElement(browserDriver, searchValue);

            Console.WriteLine("Search: " + searchElement);

        }

        [TestMethod]
        public void TestCase_1001()
        {
            // Login

            ChromeOptions ChromeOp = new ChromeOptions();
            ChromeOp.AddAdditionalCapability("useAutomationExtension", false);
            browserDriver = new ChromeDriver(ChromeOp);
            // Apertura de la Web
            browserDriver.Navigate().GoToUrl(projectURL);
            // Maximizar la Ventana
            browserDriver.Manage().Window.Maximize();
            // Configuración de la espera
            browserDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);

            PageIndex indexPage = new PageIndex();

            bool clickSignIn = indexPage.clickSignInButton(browserDriver);

            Console.WriteLine("Click on SignIn: " + clickSignIn);

            bool inputValues = indexPage.signInMethod(browserDriver);

            Console.WriteLine("Input Values: " + inputValues);

        }

        [TestInitialize()]
        public void SetupTest()
        {
            // AL INICIO
        }

        [TestCleanup()]
        public void MyTestCleanUp()
        {
            // browserDriver.Close();
        }

    }
}
