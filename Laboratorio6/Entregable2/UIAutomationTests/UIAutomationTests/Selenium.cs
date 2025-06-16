using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using System;
using System.Threading;

namespace UIAutomationTests
{
    public class Selenium
    {
        IWebDriver _driver;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
        }

        [Test]
        public void Crear_Nuevo_Pais_Test()
        {
            var URL = "http://localhost:8080/";
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl(URL);

            //navegar al formulario de crear pa�s
            var agregarBtn = _driver.FindElement(By.XPath("//button[contains(text(),'Agregar Pais')]"));
            agregarBtn.Click();

            //esperar a que cargue el formulario
            Thread.Sleep(1000);

            //llenar los campos del formulario
            _driver.FindElement(By.Id("nombre")).SendKeys("Hait�");
            _driver.FindElement(By.Id("continente")).SendKeys("Am�rica");
            _driver.FindElement(By.Id("idioma")).SendKeys("Franc�s");

            //enviar el formulario
            _driver.FindElement(By.XPath("//button[contains(text(),'Guardar')]")).Click();

            //esperar que redirija
            Thread.Sleep(1000);

            //verificar que el pais esta en la lista
            var bodyText = _driver.FindElement(By.TagName("body")).Text;
            Assert.IsTrue(bodyText.Contains("Testlandia"), "El pa�s no fue creado correctamente.");

        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
            _driver.Dispose();
        }
    }
}