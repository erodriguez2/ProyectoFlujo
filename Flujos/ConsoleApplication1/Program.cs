using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Controlador de flujos";
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("BIENVENIDO A NUESTRO GRAN CONTROLADOR DE FLUJO! :D");
            Console.ResetColor();
            Maestro MasterOfPuppets = new Maestro();
            MasterOfPuppets.Ejecutar();
        }
    }
}
