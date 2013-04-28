using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Negar: Operacion
    {
        public Negar()
        {
            cInput = 1;
            name = "Negar";
        }

        public override Variable Calcular(Variable input)
        {
            resultado.AgregarValor(input.Valor[0] * (-1), 0);
            return resultado;
        }
    }
}
