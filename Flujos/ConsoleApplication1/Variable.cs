using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Variable
    {
        private List<double> valor;
        public List<double> Valor
        {
            get { return valor; }
        }
        public Variable()
        {
            valor = new List<double>();
        }

        public void AgregarValor(double x, int index)
        {
            valor.Insert(index,x);
        }

        public void AgregarValores(List<double>valores)
        {
            valor.Clear();
            foreach (double x in valores)
            {
                valor.Add(x);
            }
        }
    }
}
