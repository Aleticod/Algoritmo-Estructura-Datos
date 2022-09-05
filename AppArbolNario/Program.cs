using System;
using ArbolesGrafos;


namespace AppArbolNario
{
    class Program
    {



        public static int menu()
        {
            int opcion;
            Console.WriteLine("\n---- Control de la Cola de Clientes -----");
            Console.WriteLine(" 1.- Agregar ancestro");
            Console.WriteLine(" 2.- Agregar hijo");
            Console.WriteLine(" 3.- Eliminar arbol");
            Console.WriteLine(" 4.- Buscaar arbol");
            Console.WriteLine(" 5.- Mostrar altura");
            Console.WriteLine(" 6.- Mostrar arbol");
            Console.WriteLine(" 7.- Mostrar recorrido pre-orden");
            Console.WriteLine(" 8.- Mostrar recorrido in-orden");
            Console.WriteLine(" 9.- Mostrar recorrido pos-orden");
            Console.WriteLine(" 10.- Salir\n");

            Console.Write("Ingrese una opción -> ");
            opcion = Convert.ToInt32(Console.ReadLine());
            return opcion;
            
        }

        public static void agregarAncestro(CArbolNario arbol)
        {
            if (arbol.EsVacio())
            {
                string elemento;
                Console.WriteLine("Ingrese el elemento ancestro: ");
                elemento = Console.ReadLine();
                arbol.Agregar(null, elemento);
            }

            else
            {
                Console.WriteLine("El arbol ya tiene ancestro");
            }
        }

        public static void agregarHijo(CArbolNario arbol)
        {
            if (!arbol.EsVacio())
            {
                string padre;
                string hijo;
                Console.WriteLine("Ingrese el padre al cual quieres agregar: ");
                padre = Console.ReadLine();
                Console.WriteLine("Ingrese el elemetno hijo: ");
                hijo = Console.ReadLine();
                if (!arbol.SubArbol(padre).EsVacio())
                {
                    arbol.Agregar(arbol.SubArbol(padre), hijo);
                }
                else
                {
                    Console.WriteLine("No esxiste el subarbol");
                }
            }
            else
            {
                Console.WriteLine( "El arbol esta vacio, debira agregar un ancestro.");
            }

        }

        public static void eliminarArbol(CArbolNario arbol)
        {
            if (!arbol.EsVacio())
            {
                string elemento;
                Console.WriteLine("El valor del arbol que desea elimnar: ");
                elemento = Console.ReadLine();
                arbol.Eliminar(arbol.SubArbol(elemento));
            }
            else
            {
                Console.WriteLine("El arbol esta vacio");
            }
        }

        public static void buscarArbol(CArbolNario arbol)
        {
            if (arbol.EsVacio())
            {
                Console.WriteLine("El arbol esta vacio");
            }
            else
            {
                string elemento;
                Console.WriteLine( "Ingrese el valor a buscar");
                elemento = Console.ReadLine();
                if (!arbol.SubArbol(elemento).EsVacio())
                {
                    Console.WriteLine("El arbol si existe");
                }
                else
                {
                    Console.WriteLine("El arbol no existe");
                }
            }
        }

        public static void mostrarAltura(CArbolNario arbol)
        {
            int altura = arbol.Altura();
            Console.WriteLine($"La altura del arbol es {altura}");
        }

        public static void mostrarArbol(CArbolNario arbol)
        {
            if(!arbol.EsVacio())
            {
                arbol.mostrarAbol();
            }
            else
            {
                Console.WriteLine("El arbol esta vacio");
            }
        }


        public static void mostrarPreOrden(CArbolNario arbol)
        {
            if (!arbol.EsVacio())
            {
                arbol.PreOrden();
            }
            else
            {
                Console.WriteLine("El arbol esta vacio");
            }
        }

        public static void mostrarInOrden(CArbolNario arbol)
        {
            if (!arbol.EsVacio())
            {
                arbol.InOrden();
            }
            else
            {
                Console.WriteLine("El arbol esta vacio");
            }
        }


        public static void mostrarPosOrden(CArbolNario arbol)
        {
            if (!arbol.EsVacio())
            {
                arbol.PosOrden();
            }
            else
            {
                Console.WriteLine("El arbol esta vacio");
            }
        }

        static void Main(string[] args)
        {

            CArbolNario arbol = new CArbolNario();
            arbol.Agregar(null, "a");
            arbol.Agregar(arbol.SubArbol("a"), "b");
            arbol.Agregar(arbol.SubArbol("a"), "c");
            arbol.Agregar(arbol.SubArbol("a"), "d");
            arbol.Agregar(arbol.SubArbol("c"), "e");
            arbol.Agregar(arbol.SubArbol("c"), "f");
            arbol.Agregar(arbol.SubArbol("d"), "g");

            int opcion = menu();
            do
            {
                switch (opcion)
                {
                    case 1:
                        agregarAncestro(arbol);
                        break;
                    case 2:
                        agregarHijo(arbol);
                        break;
                    case 3:
                        eliminarArbol(arbol);
                        break;
                    case 4:
                        buscarArbol(arbol);
                        break;
                    case 5:
                        mostrarAltura(arbol);
                        break;
                    case 6:
                        mostrarArbol(arbol);
                        break;
                    case 7:
                        mostrarPreOrden(arbol);
                        break;
                    case 8:
                        mostrarInOrden(arbol);
                        break;
                    case 9:
                        mostrarPosOrden(arbol);
                        break;
                    case 10:
                        break;
                    default:
                        Console.WriteLine("Ingrese un valor valido");
                        break;
                }
                opcion = menu();
            } while (opcion != 4);
        }
    }
}
