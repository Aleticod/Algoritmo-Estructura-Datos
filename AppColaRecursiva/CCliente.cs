using System;
using System.Collections.Generic;
using System.Text;

namespace AppColaRecursiva
{
    class CCliente
    {
        // --- ATRIBUTOS
        private string aDni;
        private string aNombres;
        private string aApellidos;
        
        // --- CONSTRUCTORES
        // ----- Constructor vacio
        public CCliente()
        {
            this.aDni = "";
            this.aNombres = "";
            this.aApellidos = "";
        }

        // ----- Constructor con parametros

        public CCliente(string pDni, string pNombres, string pApellidos)
        {
            this.aDni = pDni;
            this.aNombres = pNombres;
            this.aApellidos = pApellidos;
        }

        // --- METODOS SETTERS Y GETTERS
        public string Dni { get => aDni; set => aDni = value; }
        public string Nombres { get => aNombres; set => aNombres = value; }
        public string Apellidos { get => aApellidos; set => aApellidos = value; }

        // METODOS AUXILIARES O PROPIEDADES
        public void ingresarDatos()
        {
            Console.WriteLine("Ingrese el DNI del cliente");
            Dni = Console.ReadLine();
            Console.WriteLine("Ingrese el Nombre del cliente");
            Nombres = Console.ReadLine().ToUpper();
            Console.WriteLine("Ingrese los Apellidos del cliente");
            Apellidos = Console.ReadLine().ToUpper();
        }

        public void ingresarDni()
        {
            Console.WriteLine("Ingrese el DNI del cliente");
            Dni = Console.ReadLine();
        }

        public void mostrarDatos()
        {
            Console.WriteLine($"{Dni} {Nombres} {Apellidos}");
        }

        public override string ToString()
        {
            //return base.ToString();
            return $"{Dni} {Nombres} {Apellidos}";
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
    }
}
