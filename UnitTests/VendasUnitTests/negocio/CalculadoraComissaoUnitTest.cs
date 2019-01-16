using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vendas.negocio;

namespace TestProject
{
    [TestClass]
    public class CalculadoraComissaoUnitTest
    {
        [TestMethod]
        public void venda_igual_a_12k_comissao_6_por_cento()
        {
            int valorVenda = 12000;
            int valorComissaoEsperado = 720;

            decimal valorComissao = CalculadoraComissao.calcular(valorVenda);

            Assert.AreEqual(valorComissaoEsperado, valorComissao);
        }

        [TestMethod]
        public void venda_menor_igual_que_10k_comissao_5_por_cento()
        {
            int valorVenda = 10000;
            int valorComissaoEsperado = 500;

            decimal valorComissao = CalculadoraComissao.calcular(valorVenda);

            Assert.AreEqual(valorComissaoEsperado, valorComissao);
        }

        [TestMethod]
        public void venda_menor_igual_que_5k_comissao_5_por_cento()
        {
            int valorVenda = 5000;
            int valorComissaoEsperado = 250;

            decimal valorComissao = CalculadoraComissao.calcular(valorVenda);

            Assert.AreEqual(valorComissaoEsperado, valorComissao);
        }

        [TestMethod]
        public void venda_igual_a_55_59_comissao_5_por_cento()
        {
            decimal valorVenda = 55.59m;
            decimal valorComissaoEsperado = 2.77m;

            decimal valorComissao = CalculadoraComissao.calcular(valorVenda);

            Assert.AreEqual(valorComissaoEsperado, valorComissao);
        }
    }

    
}
