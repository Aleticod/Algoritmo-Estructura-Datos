using System;
using System.Collections.Generic;
using System.Text;

namespace AppReniec
{
    class CPersona
    {
        // --- ATRIBUTOS
        private string aDni;
        private string aNombresApellidos;
        private string aCiudad;

        // --- CONSTRUCTORES
        public CPersona ()
        {
            aDni = "";
            aNombresApellidos = "";
            aCiudad = "";
        }

        public CPersona (string pDni, string pNombresApellidos, string pCiudad)
        {
            aDni = pDni;
            aNombresApellidos = pNombresApellidos;
            aCiudad = pCiudad;
        }

        // --- PROPIEDADES
        public string Dni
        {
            get
            {
                return aDni;
            }
            set
            {
                aDni = value;
            }
        }

        public string NombresApellidos
        {
            get
            {
                return aNombresApellidos;
            }
            set
            {
                aNombresApellidos = value;
            }
        }

        public string Ciudad
        {
            get
            {
                return aCiudad;
            }
            set
            {
                aCiudad = value;
            }
        }

        // --- METODOS AUXILIARES
        public void ingresarDatos()
        {
            Console.WriteLine("Ingrese el DNI: ");
            aDni = Console.ReadLine();
            Console.WriteLine("Ingrese nombres y apellidos: ");
            aNombresApellidos = Console.ReadLine().ToUpper();
            Console.WriteLine("Ingrese la ciudad");
            aCiudad = Console.ReadLine().ToUpper();
        }

        public void mostrarDatos()
        {
            Console.WriteLine($"{aDni}\t{aNombresApellidos}\t{aCiudad}");
        }

        public override string ToString()
        {
            //return base.ToString();
            return $"{aDni}";
        }

        public override bool Equals(object obj)
        {
            return this.ToString().Equals(obj.ToString());
        }
    }
}
