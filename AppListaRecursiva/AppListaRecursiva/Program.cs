// See https://aka.ms/new-console-template for more information
using System;
using EstructuraDatosLineales;

namespace AppListaRecursiva
{
    public class Program
    {
        static void Main(string[] args)
        {
            CLista lista = new CLista();

            lista.agregar(0);
            lista.agregar(1);
            lista.agregar(2);
            lista.agregar(3);
            lista.agregar(4);
            lista.agregar(6);
            //Console.WriteLine(lista.longitud);
            //lista.insertar(5, 5);
            //lista.mostrar();
            //Console.WriteLine(lista.longitud);
            //lista.eliminar();
            //lista.mostrar();
            //lista.eliminarIesimo(2);
            //lista.mostrar();
            //Console.WriteLine(lista.ubicacion(4));
            lista.iesimo(3);

        }
        
    }
}
