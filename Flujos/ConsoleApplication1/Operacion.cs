using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    [Serializable]
    abstract class Operacion
    {
        protected Variable resultado = new Variable();
        public Variable Resultado
        {
            get { return resultado; }
        }
        protected int cInput;
        public int CInput
        {
            get { return cInput; }
        }
        protected string name;
        public string Name
        {
            get { return name; }
        }
        public abstract Variable Calcular(Variable input);
    }
}
