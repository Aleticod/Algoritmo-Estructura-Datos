using System;
using EstructuraDatosLineales;

namespace AppPilaRecursiva
{
    class Program
    {
        static void Main(string[] args)
        {
            CPila pila = new CPila();

            pila.apilar(0);
            pila.apilar(1);
            pila.apilar(2);
            pila.apilar(3);
            pila.apilar(4);
            pila.apilar(5);
            Console.WriteLine(pila.longitud);
            pila.mostrar();
            pila.iesimo(4);
            Console.WriteLine(pila.primero().Elemento);
            Console.WriteLine(pila.ultimo().Elemento);
            Console.WriteLine(pila.buscar(5));
            Console.WriteLine(pila.ubicacion(5));
        }
    }
}
