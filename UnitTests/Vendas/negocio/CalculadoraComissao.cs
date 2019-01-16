using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vendas.negocio
{
    public class CalculadoraComissao
    {
        public static decimal calcular(decimal valorVenda)
        {
            if (valorVenda <= 10000)
            {
                return Math.Truncate((valorVenda * 0.05m) * 100)/100;
            }
            else
            {
                return Math.Round(valorVenda * 0.06m, 2);
            }

        }
    }
}
