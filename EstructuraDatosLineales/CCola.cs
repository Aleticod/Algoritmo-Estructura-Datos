using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructuraDatosLineales
{
    public class CCola
    {
        // ---- ATRIBUTOS ----
        private Object aElemento;
        private CCola aSubcola;

        // ---- CONSTRUCTORES ----
        // ---- Constructor vacio
        public CCola()
        {
            this.aElemento = null;
            this.aSubcola = null;
        }
        // --- Constructor con parametros
        public CCola(Object pElemento, CCola pSubcola)
        {
            this.aElemento = pElemento;
            this.aSubcola = pSubcola;
        }

        // --- Metodos Setters Y Getters
        public object Elemento { get => aElemento; set => aElemento = value; }
        public CCola Subcola { get => aSubcola; set => aSubcola = value; }

        // --- PROPIEDADES O METODOS AUXILIARES

        // ---- Es vacia?
        public bool esVacia()
        {
            return aElemento == null && aSubcola == null;
        }

        // ---- Encolar
        public void encolar(Object pElemento)
        {
            if(aElemento == null)
            {
                aElemento = pElemento;
                aSubcola = new CCola();
            }
            else
            {
                aSubcola.encolar(pElemento);
            }
        }

        // ---- Desencolar
        public void desencolar()
        {
            if(!esVacia())
            {
                aElemento = aSubcola.Elemento;
                aSubcola = aSubcola.Subcola;
            }
        }

        // ---- Iesimo
        public CCola iesimo(int indice)
        {
            if(indice == 0)
            {
                return this;
            }
            else
            {
               return aSubcola.iesimo(indice - 1);
            }
        }

        // ---- Mostrar cola
        public void mostrar()
        {
            if(!esVacia())
            {
                Console.WriteLine(aElemento.ToString());
                aSubcola.mostrar();
            }
        }

        // ---- Primer elemento
        public CCola primero()
        {
            return this;
        }

        // ----- Ultimo elemento
        public CCola ultimo()
        {
            if(aSubcola.esVacia())
            {
                return this;
            }
            else
            {
                return aSubcola.ultimo();
            }
        }

        // ----- Buscar elemento
        public bool buscar(Object pElemento)
        {
            if(!esVacia())
            {
                if (pElemento.Equals(Elemento))
                {
                    return true;
                }
                else
                {
                    return aSubcola.buscar(pElemento);
                }
            }
            else
            {
                return false;
            }
        }

        // ---- Ubicacion
        public int ubicacion(Object pElemento)
        {
            if(!esVacia())
            {
                if(aElemento.Equals(pElemento))
                {
                    return 0;
                }
                else
                {
                    return 1 + aSubcola.ubicacion(pElemento);
                }
            }
            else
            {
                return -1;
            }
        }
        // ---- Longitud
        public int longitud()
        {
            if(esVacia())
            {
                return 0;
            }
            else
            {
                return 1 + aSubcola.longitud();
            }
        }
    }
}
