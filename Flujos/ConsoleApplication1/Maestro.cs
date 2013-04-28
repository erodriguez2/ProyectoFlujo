using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Maestro
    {
        List<Proyecto> proyectos;

        public Maestro()
        {
            proyectos = new List<Proyecto>();
        }
        public void Ejecutar()
        {
            bool continuar = true;
            while(continuar)
            {
                Console.WriteLine("Ingrese la opcion que desea aplicar: \n1- Crear Proyecto\n2- Abrir Proyecto\n0- Salir");
                string inputS = Console.ReadLine();
                int inputI = Convert.ToInt32(inputS);
                string name;
                if(inputI == 1)
                {
                    Console.WriteLine("Ingrese el nombre del proyecto: ");
                    name = Console.ReadLine();
                    proyectos.Add(new Proyecto(name));
                }
                else if (inputI == 2)
                {
                    Console.WriteLine("Ingrese el nombre del proyecto: ");
                    name = Console.ReadLine();
                    foreach (Proyecto p in proyectos)
                    {
                        if (p.Nombre == name)
                        {
                            p.Abrir();
                        }
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("GRACIAS POR UTILIZAR NUESTRO GRAN CONTROLADOR DE FLUO! :D");
                    Console.ReadKey();
                    continuar = false;
                }
            }
        }
    }
}
