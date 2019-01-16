using System.Configuration;
using System.IO;
using System.Reflection;
using SistemaVendas.Negocio;
using NUnit.Framework;

namespace TestProject1
{
    [SetUpFixture]
    public class AssemblyInitializer
    {
        [OneTimeSetUp]
        public static void AssemblyInitialize()
        {
            var baseDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            ConfiguracaoDeTestes.InicializarVariaveisDeTeste(baseDir, StringDeConexao);
            ConfigurarNHibernateESubirEsquemaDoBancoDeDadosDeDominio();
        }

        [OneTimeTearDownAttribute]
        public static void AssemblyCleanup()
        {
            //o metodo abaixo carregaria no DB um cenario de backup do banco de dados apos os testes serem rodados.
            //OperacoesDeTestes.CarregarBancoDeDados(ConfiguracaoDeTestes.Esquema, ConfiguracaoDeTestes.DadosDeBackup);
            Contexto.SessionFactory.Dispose();
        }

        private static void ConfigurarNHibernateESubirEsquemaDoBancoDeDadosDeDominio()
        {
            Configurador.Configurar(
                true,
                true);
        }

        public static string StringDeConexao
        {
            get
            {
                var connectionString = ConfigurationManager.ConnectionStrings["ExemploConexao"].ConnectionString;
                return connectionString;
            }
        }
    }
}