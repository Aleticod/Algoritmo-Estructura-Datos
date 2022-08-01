using System;
using System.Collections.Generic;
using System.Text;
using EstructuraDatosLineales;

namespace AppReniec
{
    class CControlReniec
    {
        // --- ATRIBUTOS
        private CLista aHabilitados;
        private CPila aAccesitarios;
        private CLista aCiudad;

        // --- CONSTRUCTOR
        public  CControlReniec()
        {
            aHabilitados = new CLista();
            aAccesitarios = new CPila();
        }

        public CControlReniec(CLista pHabilitados, CPila pAccesitarios)
        {
            aHabilitados = pHabilitados;
            aAccesitarios = pAccesitarios;
        }

        // --- PROPIEDADES
        public CLista Habilitados
        {
            get
            {
                return aHabilitados;
            }
            set
            {
                aHabilitados = value;
            }
        }
        public CPila Accesitarios
        {
            get
            {
                return aAccesitarios;
            }
            set
            {
                aAccesitarios = value;
            }
        }

        public int menu()
        {
            int opcion;

            Console.WriteLine("\n---- CONTROL RENIEC -----");
            Console.WriteLine(" 1.- Añadir una persona a habilitados");
            Console.WriteLine(" 2.- Añadir una persona a accesitarios");
            Console.WriteLine(" 3.- Mostrar personas habilitadas");
            Console.WriteLine(" 4.- Mostrar personas accesitarias");
            Console.WriteLine(" 5.- Cambiar un habilitado por un accesitario");
            Console.WriteLine(" 6.- Mostrar lista segun ciudad");
            Console.WriteLine(" 7.- Salir\n");

            Console.Write("Ingrese una opción -> ");
            opcion = Convert.ToInt32(Console.ReadLine());
            return opcion;
        }

        // Añadir una persona a la lista de habilitados
        public void añadirHabilitado ()
        {
            CPersona persona = new CPersona();
            persona.ingresarDatos();
            aHabilitados.agregar(persona);
            Console.WriteLine("Se realizó con éxito!!");
        }

        public void añadirAccesitario()
        {
            CPersona persona = new CPersona();
            persona.ingresarDatos();
            aAccesitarios.apilar(persona);
            Console.WriteLine("Se realizó con éxito!!");
        }

        // El mostrar se hizo con un buble for debido a que
        // El metodo to string retorna solo el DNI para la comparacion
        public void mostrarHabilitados()
        {
            Console.WriteLine("DNI      NOMBRES Y APELLIDOS\tCIUDAD");
            int longitud = aHabilitados.longitud;
            for (int i = 0; i < longitud; i++)
            {
                CPersona persona = new CPersona();
                persona = (CPersona)aHabilitados.iesimo(i).Elemento;
                persona.mostrarDatos();
            }
        }

        public void mostrarAccesitarios()
        {
            Console.WriteLine("DNI      NOMBRES Y APELLIDOS\tCIUDAD");
            int longitud = aAccesitarios.longitud;
            for (int i = 0; i < longitud; i++)
            {
                CPersona persona = new CPersona();
                persona = (CPersona)aAccesitarios.iesimo(longitud - i - 1).Elemento;
                persona.mostrarDatos();
            }
        }
        
        public void intercambiar ()
        {
            CPersona persona = new CPersona();
            Console.WriteLine("Ingres el DNI a intercambiar: ");
            persona.Dni = Console.ReadLine();
            int pos = aHabilitados.ubicacion(persona);
            aHabilitados.modificar((CPersona)aAccesitarios.ultimo().Elemento, pos);
            aAccesitarios.desapilar();
        }

        public void generarPorCiudad()
        {
            string ciudad;
            CLista aCiudad = new CLista();
            CPersona persona = new CPersona();
            Console.WriteLine("Ingresa la ciudad: ");
            ciudad = Console.ReadLine().ToUpper();
            int nroHabilitados = aHabilitados.longitud;
            for (int i = 0; i < nroHabilitados; i++)
            {
                persona = (CPersona) aHabilitados.iesimo(i).Elemento;
                if(persona.Ciudad.Equals(ciudad))
                {
                    aCiudad.agregar(persona);
                }
            }

            Console.WriteLine("DNI      NOMBRES Y APELLIDOS\tCIUDAD");
            int longitud = aCiudad.longitud;
            for (int i = 0; i < longitud; i++)
            {
                persona = (CPersona)aCiudad.iesimo(i).Elemento;
                persona.mostrarDatos();
            }
        }


        public void ejecutar()
        {
            int opcion;

            opcion = menu();
            do
            {
                switch (opcion)
                {
                    case 1:
                        añadirHabilitado();
                        break;
                    case 2:
                        añadirAccesitario();
                        break;
                    case 3:
                        mostrarHabilitados();
                        break;
                    case 4:
                        mostrarAccesitarios();
                        break;
                    case 5:
                        intercambiar();
                        break;
                    case 6:
                        generarPorCiudad();
                        break;
                    default:
                        Console.WriteLine("Ingrese una opcion valida (1-7)");
                        break;
                }
                opcion = menu();
            } while (opcion != 7);
        }
    }
}
