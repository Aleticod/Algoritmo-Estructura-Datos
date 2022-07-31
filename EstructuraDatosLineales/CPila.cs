using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructuraDatosLineales
{
    public class CPila
    {
        // --- Atributos
        private Object aElemento;
        private CPila aSubpila;

        // --- Constructor
        public CPila ()
        {
            aElemento = null;
            aSubpila = null;
        }

        public CPila (Object pElemento, CPila pSubpila)
        {
            aElemento = pElemento;
            aSubpila = pSubpila;
        }

        // --- Propiedades
        // --- Propiedades set y get
        public Object Elemento
        {
            get
            {
                return aElemento;
            }
            set
            {
                aElemento = value;
            }
        }

        public CPila Subpila
        {
            get
            {
                return aSubpila;
            }
            set
            {
                aSubpila = value;
            }
        }

        public int longitud
        {
            get
            {
                if (!esVacio())
                {
                    if (aElemento == null)
                    {
                        return 0;
                    }
                    else
                    {
                       return aSubpila.longitud + 1;
                    }
                }
                else
                {
                    return 0;
                }
            }
        }
        // --- Metodos auxiliares

        public bool esVacio()
        {
            return aElemento == null && aSubpila == null;
        }

        public void apilar(Object pElemento)
        {
            if (esVacio())
            {
                aElemento = pElemento;
                aSubpila = new CPila();
            }
            else
            {
                Object aux = aElemento;
                aElemento = pElemento;
                aSubpila = new CPila(aux, aSubpila);
            }
        }

        public void desapilar()
        {
            if(!esVacio())
            {
                aElemento = aSubpila.aElemento;
                aSubpila = aSubpila.aSubpila;
            }
            else
            {
                Console.WriteLine("La pila no tiene elementos");
            }
        }

        public void mostrar()
        {
            if (!esVacio())
            {
                Console.WriteLine(aElemento.ToString());
                aSubpila.mostrar();
            }
        }

        public void iesimo(int indice)
        {
            if(indice == longitud - 1)
            {
                Console.WriteLine(aElemento.ToString());
            }
            else
            {
                aSubpila.iesimo(indice);
            }
        }

        public CPila primero()
        {
            if(!esVacio())
            {
                if(aSubpila.esVacio())
                {
                    return this;
                }
                else
                {
                    return aSubpila.primero();
                }
            }
            else
            {
                return null;
            }
        }

        public CPila ultimo()
        {
            return this;
        }

        public bool buscar(object pElemento)
        {
            if(!esVacio())
            {
                if(pElemento.Equals(aElemento))
                {
                    return true;
                }
                else
                {
                    return aSubpila.buscar(pElemento);
                }
            }
            else
            {
                return false;
            }
        }

        public int ubicacion(Object pElemento)
        {
            if(!esVacio())
            {
                if(pElemento.Equals(aElemento))
                {
                    return longitud - 1;
                }
                else
                {
                    return aSubpila.ubicacion(pElemento);
                }
            }
            else
            {
                return -1;
            }
        }
    }
}
