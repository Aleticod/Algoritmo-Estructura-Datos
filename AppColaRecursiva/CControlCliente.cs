using System;
using System.Collections.Generic;
using System.Text;
using EstructuraDatosLineales;

namespace AppColaRecursiva
{
    class CControlCliente
    {
        // --- ATRIBUTOS
        private CCola aCola;

        // --- CONSTRUCTORES
        // ----- Constructor vacio
        public CControlCliente()
        {
            aCola = new CCola();
        }

        // ---- Constructor con parametros
        public CControlCliente(CCola pCola)
        {
            aCola = pCola;
        }

        // --- METODOS SET Y GET
        public CCola Cola { get => aCola; set => aCola = value; }

        // --- METODOS AUXILIARES Y PROPIEDADES
        public int menu()
        {
            int opcion;

            Console.WriteLine("\n---- Control de la Cola de Clientes -----");
            Console.WriteLine(" 1.- Encolar a un cliente");
            Console.WriteLine(" 2.- Desencolar (Atender) a un cliente");
            Console.WriteLine(" 3.- Mostrar la cola de clientes");
            Console.WriteLine(" 4.- Mostrar la longitud de la cola");
            Console.WriteLine(" 5.- Mostrar el primer elemento de la cola");
            Console.WriteLine(" 6.- Mostrar el ultimo elemento de la cola");
            Console.WriteLine(" 7.- Mostrar el iesimo elemento de la cola");
            Console.WriteLine(" 8.- Buscar un cliente en la cola");
            Console.WriteLine(" 9.- Ubicación de un ciente en la cola");
            Console.WriteLine(" 10.- Salir\n");

            Console.Write("Ingrese una opción -> ");
            opcion = Convert.ToInt32(Console.ReadLine());
            return opcion;
        }

        // --- Añadir un cliente a la cola
        public void encolarCliente()
        {
            CCliente cliente = new CCliente();
            cliente.ingresarDatos();
            Cola.encolar(cliente);
            Console.WriteLine("Se realizó con exito");
        }

        // --- Atender a un cliente de la cola
        public void desencolarCliente()
        {
            Cola.desencolar();
            Console.WriteLine("Se retiró al cliente de la cola");
        }

        // --- Mostrar los cliente de la cola
        public void mostrarClientes()
        {
            //int longitudCola = Cola.longitud();
            Console.WriteLine("DNI      NOMBRES Y APELLIDOS");
            Cola.mostrar();
            //for (int i = 0; i < longitudCola; i++)
            //{
            //    CCliente cliente = new CCliente();
            //    cliente = (CCliente)Cola.iesimo(i).Elemento;
            //    Console.Write($"  {i + 1}    ");
            //    cliente.mostrarDatos();
            //}
        }

        // --- Longitud de la cola
        public void mostrarLongitud()
        {
            int longitud;
            longitud = Cola.longitud();
            Console.WriteLine($"La longtitud de la cola es: {longitud} clientes");
        }

        // ---- Primer cliente a ser atendido
        public void mostrarPrimerCliente()
        {
            CCliente cliente = new CCliente();
            cliente = (CCliente)Cola.primero().Elemento;
            Console.WriteLine("PRIMER CLIENTE EN LA COLA");
            cliente.mostrarDatos();
        }

        // ---- Ultimo cliente a ser atendido
        public void mostrarUltimoCliente()
        {
            CCliente cliente = new CCliente();
            cliente = (CCliente)Cola.ultimo().Elemento;
            Console.WriteLine("ULTIMO CLIENTE EN LA COLA");
            cliente.mostrarDatos();
        }

        // ---- Cliente en la posición
        public void mostrarIesimoCliente()
        {
            int indice;
            CCliente cliente = new CCliente();
            Console.Write("Ingrese el indice: ");
            indice = Convert.ToInt32(Console.ReadLine());
            if(indice <= Cola.longitud())
            {
                cliente = (CCliente)Cola.iesimo(indice - 1).Elemento;
                Console.WriteLine($"EL CLIENTE EN LA UBICACION {indice} ES");
                cliente.mostrarDatos();
            }
            else
            {
                Console.WriteLine("El indice esta fuera del rango");
            }
        }

        // ---- Buscar un cliente por sus datos
        public void buscarCliente()
        {
            string dni;
            bool existe = false;
            Console.WriteLine("Ingrese el dni del cliente");
            dni = Console.ReadLine();
            for (int i = 0; i < Cola.longitud(); i++)
            {
                CCliente cliente = new CCliente();
                cliente = (CCliente)Cola.iesimo(i).Elemento;
                if (dni == cliente.Dni)
                {
                    existe = true;
                    break;
                }
            }
            if(existe)
            {
                Console.WriteLine("El cliente si está en la cola");
            }
            else
            {
                Console.WriteLine("El cliente no está en la cola");
            }
        }

        public void mostrarUbicacionCliente()
        {
            int indice;
            Console.WriteLine("Ingrese los datos del cliente");
            CCliente cliente = new CCliente();
            cliente.ingresarDni();
            indice = Cola.ubicacion(cliente);
            if(indice != -1)
            {
                Console.WriteLine($"El cliente está en la ubicacion: {indice}");
            }
            else
            {
                Console.WriteLine("El cliente no se encuentra en la cola");
            }
        }
        public void ejecutar()
        {
            CControlCliente cola = new CControlCliente();
            int opcion;

            opcion = menu();
            do
            {
                switch (opcion)
                {
                    case 1:
                        cola.encolarCliente();
                        break;
                    case 2:
                        cola.desencolarCliente();
                        break;
                    case 3:
                        cola.mostrarClientes();
                        break;
                    case 4:
                        cola.mostrarLongitud();
                        break;
                    case 5:
                        cola.mostrarPrimerCliente();
                        break;
                    case 6:
                        cola.mostrarUltimoCliente();
                        break;
                    case 7:
                        cola.mostrarIesimoCliente();
                        break;
                    case 8:
                        cola.buscarCliente();
                        break;
                    case 9:
                        mostrarUbicacionCliente();
                        break;
                    case 10:
                        break;
                    default:
                        Console.WriteLine("Ingrese una opcion valida (1-10)");
                        break;
                }
                opcion = menu();
            } while (opcion != 10);
            
        }
    }
}
