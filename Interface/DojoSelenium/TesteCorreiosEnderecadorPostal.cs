using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DojoSelenium
{
    [TestFixture] 
    public class TesteCorreiosEnderecadorPostal
    {
        private IWebDriver driver;

        [Test]
        public void EmitirEtiqueta()
        {
            driver = new ChromeDriver();

            driver.Navigate().GoToUrl("http://www2.correios.com.br/enderecador/");
            driver.FindElement(By.CssSelector("body > div.back > div.tabs > div:nth-child(2) > div > div > div.column2 > div.content > div.ctrlcontent > p:nth-child(4) > a:nth-child(1)")).Click(); ;

            PreencherDados();

            driver.FindElement(By.CssSelector("#btGerarEtiquetas")).Click();

            driver.Close();
            driver.Quit();
        }


        public void PreencherDados()
        {
            PreencherCEPeRemetente("82030340");

            PreencherNomeEPromocaoRemetente("Dina S/A", "promo");

            PreencherNumeroRemetente("165");

            driver.FindElement(By.CssSelector("body > div.back > div.tabs > div:nth-child(2) > div > div > div.column2 > div.content > div.ctrlcontent > form > div:nth-child(11) > div > span:nth-child(4) > label > input[type='text']:nth-child(3)")).SendKeys("80002900");

            driver.FindElement(By.CssSelector("body")).Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.CssSelector("body > div.back > div.tabs > div:nth-child(2) > div > div > div.column2 > div.content > div.ctrlcontent > form > div:nth-child(9) > div > span:nth-child(4) > label > input")));

            driver.FindElement(By.CssSelector("body > div.back > div.tabs > div:nth-child(2) > div > div > div.column2 > div.content > div.ctrlcontent > form > div:nth-child(11) > div > span:nth-child(6) > label > input")).SendKeys("Blá Blá Blá");
            driver.FindElement(By.CssSelector("body > div.back > div.tabs > div:nth-child(2) > div > div > div.column2 > div.content > div.ctrlcontent > form > div:nth-child(11) > div > span:nth-child(7) > label > input")).SendKeys("Promo");
            driver.FindElement(By.CssSelector("body > div.back > div.tabs > div:nth-child(2) > div > div > div.column2 > div.content > div.ctrlcontent > form > div:nth-child(11) > div > span:nth-child(10) > label > input")).SendKeys("100");
        }

        private void PreencherNumeroRemetente(String numero)
        {
            driver.FindElement(By.CssSelector("body > div.back > div.tabs > div:nth-child(2) > div > div > div.column2 > div.content > div.ctrlcontent > form > div:nth-child(9) > div > span:nth-child(8) > label > input")).SendKeys(numero);
        }

        private void PreencherNomeEPromocaoRemetente(String nome, String promo)
        {
            driver.FindElement(By.CssSelector("body > div.back > div.tabs > div:nth-child(2) > div > div > div.column2 > div.content > div.ctrlcontent > form > div:nth-child(9) > div > span:nth-child(4) > label > input")).SendKeys(nome);
            driver.FindElement(By.CssSelector("body > div.back > div.tabs > div:nth-child(2) > div > div > div.column2 > div.content > div.ctrlcontent > form > div:nth-child(9) > div > span:nth-child(5) > label > input")).SendKeys(nome);
        }

        private void PreencherCEPeRemetente(String cep)
        {
            driver.FindElement(By.Id("cep_1")).SendKeys(cep);
            driver.FindElement(By.CssSelector("body")).Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.CssSelector("body > div.back > div.tabs > div:nth-child(2) > div > div > div.column2 > div.content > div.ctrlcontent > form > div:nth-child(9) > div > span:nth-child(4) > label > input")));

        }
    }
}
