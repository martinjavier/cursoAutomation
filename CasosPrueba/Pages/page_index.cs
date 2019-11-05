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
using CasosPrueba.Activity;

namespace CasosPrueba.Pages
{
    class PageIndex
    {
        // Elementos en la ventana

        // Search
        string validateXPATH = "//img[@class='logo img-responsive'][@alt='My Store']";
        string searchFieldXPATH = "//input[@class='search_query form-control ac_input'][@id='search_query_top']";
        string searchFieldButtonXPATH = "//button[@name='submit_search'][@class='btn btn-default button-search']";
        string buttonListXPATH = "//button[@type='submit'][@disabled='disabled']";

        // SignIn
        string signInXPATH = "//a[@class='login'][@title='Log in to your customer account']";
        string emailXPATH = "//input[@id='email']";
        string passwordXPATH = "//input[@id='passwd']";
        string signInButtonXPATH = "//button[@id='SubmitLogin']";
        string signInValidator = "//div[@class='header_user_info']//a[@title='View my customer account']//span[contains(text(), 'Jorge Argumento')]";

        // Métodos

        public bool searchElement(IWebDriver browserDriver, string searchValue)
        {
            bool finalCheck = false;
            IWebElement elementIDSearchField = null;
            elementIDSearchField = browserDriver.FindElement(By.XPath(searchFieldXPATH));
            elementIDSearchField.SendKeys(searchValue);
            IWebElement elementIDSearchButton;
            elementIDSearchButton = browserDriver.FindElement(By.XPath(searchFieldButtonXPATH));
            elementIDSearchButton.Click();
            IList<IWebElement> elementList = browserDriver.FindElements(By.XPath(buttonListXPATH));
            int cantidadDeElementos = elementList.Count();
            finalCheck = (cantidadDeElementos == 2);
            return finalCheck;
        }

        public bool clickSignInButton(IWebDriver browserDriver)
        {
            bool finalCheck = false;
            IWebElement elementID;

            // Hacer click en el botón
            elementID = browserDriver.FindElement(By.XPath(signInXPATH));
            elementID.Click();
            Utility.creatingFolder("Folder");

            // Validar el botón de SignIn
            elementID = null;
            elementID = browserDriver.FindElement(By.XPath(signInButtonXPATH));

            // Validación final
            finalCheck = (elementID != null);
            return finalCheck;
        }

        public bool signInMethod(IWebDriver browserDriver)
        {
            bool finalCheck = false;
            IWebElement elementID;

            // Ingreso el Email
            // elementID = Utility.FindElement(browserDriver, XPath);

            elementID = browserDriver.FindElement(By.XPath(emailXPATH));
            elementID.SendKeys("jorge.argumento@gmail.com");

            // Ingresar el Password
            elementID = browserDriver.FindElement(By.XPath(passwordXPATH));
            elementID.SendKeys("clavesecreta");

            // Hacer click en el botón
            elementID = browserDriver.FindElement(By.XPath(signInButtonXPATH));
            elementID.Click();

            // Validar el Login
            elementID = null;
            elementID = browserDriver.FindElement(By.XPath(signInValidator));
            finalCheck = (elementID != null);

            return finalCheck;
        }

    }
}