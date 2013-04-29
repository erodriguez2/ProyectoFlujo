using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;



namespace ConsoleApplication1
{

    class Maestro
    {
        private List<Proyecto> proyectos;

        public Maestro()
        {
            proyectos = new List<Proyecto>();
        }
        public void Ejecutar()
        {
            bool continuar = true;
            while(continuar)
            {
                Console.WriteLine("Ingrese la opcion que desea aplicar: \n1- Crear Proyecto\n2- Abrir Proyecto\n3- Guardar Proyecto \n4- Cargar Proyecto\n0- Salir");
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
                            Console.Clear();
                            p.Abrir();
                        }
                    }
                }
                else if (inputI == 3) { Guardar(); }
                else if (inputI == 4) { Cargar(); }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("GRACIAS POR UTILIZAR NUESTRO GRAN CONTROLADOR DE FLUO! :D");
                    Console.ReadKey();
                    continuar = false;
                }
            }
            

        }
public void Guardar(){

    string direccion = @"C:\Users\jose miguel\Desktop\universidad\progra\Cambios\mem";
    FileStream fs = new FileStream(direccion, FileMode.Open);
    IFormatter formato = new BinaryFormatter();
    formato.Serialize(fs,this.proyectos); 
    fs.Close();

}
private void Cargar()
{

    string fileName = @"C:\Users\jose miguel\Desktop\universidad\progra\Cambios\mem"; 
    IFormatter formato = new BinaryFormatter();
    FileStream fs = new FileStream(fileName, FileMode.Open);
    List<Proyecto> aux = formato.Deserialize(fs) as List<Proyecto>;
    this.proyectos = aux;
    fs.Close(); 
}



        }
    }

