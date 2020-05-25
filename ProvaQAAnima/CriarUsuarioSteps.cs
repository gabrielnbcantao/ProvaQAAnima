using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;


namespace ProvaQA
{
    [Binding]
    public class CriarUsuarioSteps
    {
        IWebDriver driver;
        WebDriverWait wait;
        public void Init()
        {
            this.driver = new ChromeDriver();
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(1000000));
        }

        public void Close()
        {
            this.driver.Close();
            this.driver.Dispose();
        }

        [When(@"Clicar no Botão Comecar Automacao Web")]
        public void QuandoClicarNoBotaoComecarAutomacaoWeb()
        {
            try
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("(//a[contains(@class,'btn waves-light')])[1]")));
                driver.FindElement(By.XPath("(//a[contains(@class,'btn waves-light')])[1]")).Click();

            }
            catch (NoSuchElementException)
            {
                Assert.Fail();
            }
        }

        [When(@"Clicar no Botão Formulario")]
        public void QuandoClicarNoBotaoFormulario()
        {
            try
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.ClassName("collapsible-header ")));
                driver.FindElement(By.ClassName("collapsible-header ")).Click();
            }
            catch (NoSuchElementException)
            {
                Assert.Fail();
            }
        }

        [When(@"Clicar no Botão Criar Usuarios")]
        public void QuandoClicarNoBotaoCriarUsuarios()
        {
            try
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("(//div[@class='collapsible-body']//a)[1]")));
                driver.FindElement(By.XPath("(//div[@class='collapsible-body']//a)[1]")).Click();
            }
            catch (NoSuchElementException)
            {
                Assert.Fail();
            }
        }

        [When(@"Preencher Todos os Campos")]
        public void QuandoPreencherTodosOsCampos()
        {
            try
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("(//div[@class='input-field']//input)[1]")));

                Random random = new Random();
                string name = "user_" + random.Next(100);
                string lastName = "lastName_" + random.Next(100);
                string email = "email_" + random.Next(100) + "@gmail.com";
                string endereco = "endereco_" + random.Next(100);
                string universidade = "universidade_" + random.Next(100);
                string profissao = "profissao_" + random.Next(100);
                string genero = "genero_" + random.Next(100);
                string idade = random.Next(100).ToString();

                driver.FindElement(By.XPath("(//div[@class='input-field']//input)[1]")).SendKeys(name);
                driver.FindElement(By.XPath("//div[@class='input-field']//input)[2]")).SendKeys(lastName);
                driver.FindElement(By.XPath("(//div[@class='input-field']//input)[3]")).SendKeys(email);
                driver.FindElement(By.XPath("(//div[@class='input-field']//input)[4]")).SendKeys(endereco);
                driver.FindElement(By.XPath("(//div[@class='input-field']//input)[5]")).SendKeys(universidade);
                driver.FindElement(By.XPath("//div[@class='input-field']//input)[6]")).SendKeys(profissao);
                driver.FindElement(By.XPath("(//div[@class='input-field']//input)[7]")).SendKeys(genero);
                driver.FindElement(By.XPath("//input[@type='number']")).SendKeys(idade);
            }
            catch (NoSuchElementException)
            {
                Assert.Fail();
            }
        }

        [When(@"Clicar em Criar")]
        public void QuandoClicarEmCriar()
        {
            try
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//input[@value='Criar']")));
                driver.FindElement(By.XPath("//input[@value='Criar']")).Click();
            }
            catch (NoSuchElementException)
            {
                Assert.Fail();
            }
        }

        [When(@"Nao Preencher os Campos Obrigatorios")]
        public void QuandoNaoPreencherOsCamposObrigatorios()
        {

        }

        [When(@"Clicar no Botão Voltar")]
        public void QuandoClicarNoBotaoVoltar()
        {
            try
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//a[contains(@class,'btn waves-light')]")));
                driver.FindElement(By.XPath("//a[contains(@class,'btn waves-light')]")).Click();
            }
            catch (NoSuchElementException)
            {
                Assert.Fail();
            }
        }

        [Then(@"A seguinte mensagem será exibida: Usuário Criado com sucesso")]
        public void EntaoASeguinteMensagemSeraExibidaUsuarioCriadoComSucesso()
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//p[@class='light-green accent-2']")));
            String response = driver.FindElement(By.XPath("//p[@class='light-green accent-2']")).Text;

            Assert.IsTrue(response.Contains("Usuário Criado com sucesso"));
        }

        [Then(@"A aplicação retornará erro")]
        public void EntaoAAplicacaoRetornaraErro()
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='error_explanation']//h2[1]")));
            String response = driver.FindElement(By.XPath("//div[@id='error_explanation']//h2[1]")).Text;

            Assert.IsTrue(response.Contains("errors proibiu que este usuário fosse salvo"));
        }

        [Then(@"Sera Direcionado para tela de Automacao")]
        public void EntaoSeraDirecionadoParaTelaDeAutomacao()
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//h5[@class='orange-text center ']")));
            String response = driver.FindElement(By.XPath("//h5[@class='orange-text center ']")).Text;
            Assert.AreEqual(response, "Bem vindo ao Site de Automação do Batista.");
        }
    }
}
