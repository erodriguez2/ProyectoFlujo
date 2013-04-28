using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Flujo
    {
        private List<Operacion> operaciones;
        public List<Operacion> Operaciones
        {
            get { return operaciones; }
            set { operaciones = value; }
        }
        private bool basico;
        public bool Basico
        {
            get { return basico; }
        }
        private int[] padres;
        public int[] Padres
        {
            get { return padres; }
        }

        public Flujo(bool basico,int a,int b)
        {
            operaciones = new List<Operacion>();
            this.basico = basico;
            if(!basico)
            {
                padres = new int[]{a,b};
            }

        }

        public void AgregarOperacion(int x)
        {
            if (x == 1)
            {
                operaciones.Add(new Sumar());
            }
            if(x==2)
            {
                operaciones.Add(new Restar());
            }
            if (x == 3)
            {
                operaciones.Add(new Negar());
            }
            if (x == 4)
            {
                operaciones.Add(new Sumatoria());
            }
            if (x == 5)
            {
                operaciones.Add(new Inverso());
            }
        }
    }
}
