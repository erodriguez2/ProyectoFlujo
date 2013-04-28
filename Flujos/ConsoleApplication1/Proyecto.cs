using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Proyecto
    {
        List<Flujo> flujos;
        private bool continuar;
        private string nombre;
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public Proyecto(string nombre)
        {
            flujos = new List<Flujo>();
            continuar = true;
            this.nombre = nombre;
        }

        public void Abrir()
        {
            string inputS;
            int inputI;
            while (continuar)
            {
               
                Console.WriteLine("Ingrese la opcion que desee: \n1- Crear flujo\n2- Abrir flujo\n3- Unir flujo\n4- Ejecutar flujo\n0- Salir");
                inputS = Console.ReadLine();
                inputI = Convert.ToInt32(inputS);
                #region apreto 0
                if(inputI==0)
                { 
                    Console.Clear();
                    continuar = false;
                   
                }
#endregion
                #region apreto 1
                else if(inputI==1)
                {
                    Console.Clear();
                    Console.WriteLine("ingrese el nombre del Flujo");//mano--------------------
                    string nom = Console.ReadLine();
                    flujos.Add(new Flujo(true,-1,-1,nom));
                    Console.WriteLine("Este flujo ("+nom+") desde ahora tendrá el índice ("+(flujos.Count)+")");
                    
                }
#endregion
                #region apreto 2
                else if (inputI == 2)
                {
                    Console.Clear();
                    Console.WriteLine("Ingrese el indice del flujo que desea abrir: ");
                    string inputs21 = Console.ReadLine();
                    int inputi21 = Convert.ToInt32(inputs21);
                    List<Operacion> op = flujos[inputi21-1].Operaciones;
                    Console.WriteLine("Flujo : "+flujos[inputi21-1].Nombre);//mano-----------------------
                    if (op.Count == 0)
                    {
                        Console.WriteLine("El flujo no tiene operaciones");
                    }
                    else
                    {
                        Console.WriteLine("Las operaciones de este flujo son las siguientes: ");
                        MostrarOperaciones(op);
                    }
                    Console.WriteLine("Indique que es lo que desea hacer: \n1- Agregar operaciones al flujo\n0- Salir");
                    string inputs22 = Console.ReadLine();
                    int inputi22 = Convert.ToInt32(inputs22);
                    if(inputi22 == 1)
                    {
                        bool agregarOperaciones = true;
                        while(agregarOperaciones)
                        {
                            Console.Clear();//mano-------------------------------------------
                            flujos[inputi21 - 1].Mostrar();//mano-------------------------------------------------
                            Console.WriteLine("Indique la operacion que desea agregar: \n1- Sumar\n2- Restar\n3- Negar\n4- Sumatoria\n5- Inverso\n0- Salir");
                            string sAux = Console.ReadLine();
                            int iAux = Convert.ToInt32(sAux);
                            if (iAux == 0)
                            {
                                agregarOperaciones = false;
                            }
                            else
                            { 
                                
                                flujos[inputi21-1].AgregarOperacion(iAux);
                               
                            }
                        }
                    }
                   
                }
# endregion
                #region apreto 3
                else if (inputI == 3)
                {
                    Console.Clear();
                    Console.WriteLine("Ingrese los indices de los flujos que desea unir: ");
                    string inputs31 = Console.ReadLine();
                    string inputs32 = Console.ReadLine();
                    int inputi31 = Convert.ToInt32(inputs31);
                    int inputi32 = Convert.ToInt32(inputs32);
                    flujos.Add(new Flujo(false,inputi31-1,inputi32-1," "));//falta el nombre
                    Console.WriteLine("La union de los flujos "+inputi31+ " y "+inputi32+" tendrá el índice "+(flujos.Count));
                }
                #endregion
                #region apreto 4
                else if(inputI == 4)
                {
                    Console.Clear();
                    Variable resultado = new Variable();
                    string valors1;
                    int valori1;
                    bool primero = true;
                    Console.WriteLine("Ingrese el índice del flujo que desea ejecutar");
                    string inputs4 = Console.ReadLine();
                    int inputi4 = Convert.ToInt32(inputs4);
                    List<Operacion> operaciones = flujos[inputi4-1].Operaciones;
                    foreach(Operacion operacion in operaciones)
                    {
                        if (flujos[inputi4 - 1].Basico)
                        {
                            if(operacion.CInput == 1)
                            {
                                if (primero)
                                {
                                    Console.WriteLine("Ingrese el valor a operar");
                                    valors1 = Console.ReadLine();
                                    valori1 = Convert.ToInt32(valors1);
                                    resultado.AgregarValor(valori1,0);
                                    primero = false;
                                }
                                resultado = operacion.Calcular(resultado);
                                Console.WriteLine("La operación realizada fue: "+operacion.Name+"\nEl resultado actual es: " + resultado.Valor[0]);
                            }
                            else if (operacion.CInput == 2)
                            {
                                Console.WriteLine("Ingrese los valores a operar");
                                if (primero)
                                {
                                    valors1 = Console.ReadLine();
                                    valori1 = Convert.ToInt32(valors1);
                                    resultado.AgregarValor(valori1, 0);
                                    primero = false;
                                }
                                valors1 = Console.ReadLine();
                                valori1 = Convert.ToInt32(valors1);
                                resultado.AgregarValor(valori1, 1);
                                resultado = operacion.Calcular(resultado);
                                Console.WriteLine("La operación realizada fue: " + operacion.Name + "\nEl resultado actual es: " + resultado.Valor[0]);
                            }
                            else
                            {
                                List<double> inputs = new List<double>();
                                Console.WriteLine("Ingrese los valores que desea evaluar: \n(Para terminar pulse 't')");
                                string t = Console.ReadLine();
                                while(t != "t")
                                {
                                    double d = Convert.ToDouble(t);
                                    inputs.Add(d);
                                    t = Console.ReadLine();
                                }
                                resultado.AgregarValores(inputs);
                                if (operacion.Name != "Reunir")
                                {
                                    resultado = operacion.Calcular(resultado);
                                    Console.WriteLine("La operación realizada fue: " + operacion.Name + "\nEl resultado actual es: " + resultado.Valor[0]);
                                }
                            }
                        }
                        else
                        {
                            if (primero)
                            {
                                int[] padres = flujos[inputi4 - 1].Padres;
                                List<Operacion> op1 = flujos[padres[0]].Operaciones;
                                List<Operacion> op2 = flujos[padres[1]].Operaciones;
                                double res1 = op1[op1.Count - 1].Resultado.Valor[0];
                                double res2 = op2[op2.Count - 1].Resultado.Valor[0];
                                resultado.AgregarValor(res1, 0);
                                resultado.AgregarValor(res2, 1);
                                resultado = operacion.Calcular(resultado);
                                Console.WriteLine("La operación realizada fue: " + operacion.Name + "\nEl resultado actual es: " + resultado.Valor[0]);
                                primero = false;
                            }
                            else
                            {
                                if (operacion.CInput == 1)
                                {
                                    resultado = operacion.Calcular(resultado);
                                    Console.WriteLine("La operación realizada fue: " + operacion.Name + "\nEl resultado actual es: " + resultado.Valor[0]);
                                }
                                if (operacion.CInput == 2)
                                {
                                    Console.WriteLine("Ingrese los valores a operar");
                                    valors1 = Console.ReadLine();
                                    valori1 = Convert.ToInt32(valors1);
                                    resultado.AgregarValor(valori1, 1);
                                    resultado = operacion.Calcular(resultado);
                                    Console.WriteLine("La operación realizada fue: " + operacion.Name + "\nEl resultado actual es: " + resultado.Valor[0]);
                                }
                            }
                        }
                    }
                }
                #endregion
                else
                {
                    Console.WriteLine("señor pare de cavecear el teclado");
                }
               
            }
        }

        public void MostrarOperaciones(List<Operacion> o)
        {
            foreach(Operacion x in o)
            {
                Console.WriteLine(x.Name);
            }
        }
    }
}
