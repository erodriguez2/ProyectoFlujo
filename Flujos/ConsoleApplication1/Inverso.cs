using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Inverso: Operacion
    {
        public Inverso()
        {
            cInput = 1;
            name = "Inverso";
        }

        public override Variable Calcular(Variable input)
        {
            resultado.AgregarValor(1/input.Valor[0], 0);
            return resultado;
        }
    }
}
