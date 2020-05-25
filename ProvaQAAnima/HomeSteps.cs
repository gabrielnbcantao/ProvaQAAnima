using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;

namespace ProvaQA
{
    [Binding]
    public class HomeSteps
    {
        IWebDriver driver;
        WebDriverWait wait;
        private string url = "https://automacaocombatista.herokuapp.com/home/index";

        [BeforeScenario]
        public void Init()
        {
            this.driver = new ChromeDriver();
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10000));
            driver.Manage().Window.Maximize();
        }

        [AfterScenario]
        public void Close()
        {
            this.driver.Close();
            this.driver.Dispose();
        }

        [Given(@"Um usuario acessar a tela inicial")]
        public void DadoUmUsuarioAcessarATelaInicial()
        {
            this.driver.Navigate().GoToUrl(url);
        }

        [When(@"O carregamento finalizar")]
        public void QuandoOCarregamentoFinalizar()
        {
            try
            {
                this.wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("(//a[contains(@class,'btn waves-light')])[1]")));
            }
            catch (NoSuchElementException)
            {
                Assert.Fail();
            }
        }

        [Then(@"A seguinte mensagem será exibida: Site para Automação")]
        public void EntaoASeguinteMensagemSeraExibidaSiteParaAutomacao()
        {
            string response = driver.FindElement(By.XPath("//h4[text()='Site para Automação']")).Text;
            Assert.AreEqual(response, "Site para Automação");
        }

        [Then(@"A url deve ser validada")]
        public void EntaoAUrlDeveSerValidada()
        {
            Assert.AreEqual(url, driver.Url);
        }
    }
}
