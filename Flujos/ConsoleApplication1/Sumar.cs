using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Sumar: Operacion
    {
        public Sumar()
        {
            cInput = 2;
            name = "Sumar";
        }

        public override Variable Calcular(Variable input)
        {
            resultado.AgregarValor(input.Valor[0] + input.Valor[1],0);
            return resultado;
        }
    }
}
