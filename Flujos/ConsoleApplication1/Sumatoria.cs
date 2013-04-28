using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Sumatoria: Operacion
    {
        public Sumatoria()
        {
            cInput = 0;
            name = "Sumatoria";
        }

        public override Variable Calcular(Variable input)
        {
            double sum = 0;
            foreach(double x in input.Valor)
            {
                sum = sum + x;
            }
            resultado.AgregarValor(sum, 0);
            return resultado;
        }
    }
}
