using System;
using System.Collections.Generic;
using System.Text;
using Gallio.Framework;
using NUnit.Framework;
using NHibernate;
using SistemaVendas.Negocio;
using SistemaVendas.Model;
using SistemaVendas;

namespace TestProject1.Testes
{
    [TestFixture]
    public class TesteVenda : TesteBase
    {
        private ISession _session;
        
        [SetUp]
        public void Initialize()
        {
            _session = Contexto.SessionFactory.OpenSession();
        }

        [Test]
        public void TotalVendasVendedor1Ano2011Retorna100()
        {
            var ano = 2011;
            var idVendedor = 1;
            GeradorRelatorio gr = new GeradorRelatorio();
            Assert.AreEqual(100, gr.TotalVendasAnualPorVendedor(ano, idVendedor, _session));
        }

        [Test]
        public void TotalVendasVendedor10Ano2018Retorna6000000()
        {
            var ano = 2018;
            var idVendedor = 10;
            GeradorRelatorio gr = new GeradorRelatorio();
            int valorTotalEsperado = 6000000;

            Assert.AreEqual(valorTotalEsperado, gr.TotalVendasAnualPorVendedor(ano, idVendedor, _session));
        }

        [Test]
        public void TotalVendasVendedor20Ano2019Retorna0()
        {
            var ano = 2019;
            var idVendedor = 20;
            int valorTotalEsperado = 0;

            GeradorRelatorio gr = new GeradorRelatorio();
            Assert.AreEqual(valorTotalEsperado, gr.TotalVendasAnualPorVendedor(ano, idVendedor, _session));
        }

        [Test]
        public void TotalVendasVendedor50Ano2019Retorna10_22()
        {
            var ano = 2019;
            var idVendedor = 50;
            decimal valorTotalEsperado = 10.22m;

            GeradorRelatorio gr = new GeradorRelatorio();
            Assert.AreEqual(valorTotalEsperado, gr.TotalVendasAnualPorVendedor(ano, idVendedor, _session));
        }
    }
}
