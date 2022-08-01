using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructuraDatosLineales
{
    public class CLista
    {
        // Atributos
        private Object aElemento;
        private CLista aSublista;

        // Metodo constructor
        public CLista()
        {
            aElemento = null;
            aSublista = null;
        }

        public CLista(Object pElemento, CLista pLista)
        {
            aElemento = pElemento;
            aSublista = pLista;
        }

        

        // Propiedades set y get
        public Object Elemento
        {
            get { return aElemento; }
            set { aElemento = value; }
        }

        public CLista Sublista
        {
            get { return aSublista; }
            set { aSublista = value; }
        }

        // Propiedad longitud
        public int longitud
        {
            get
            {
                if (aElemento == null)
                {
                    return 0;
                }
                else
                {
                    return aSublista.longitud + 1;
                }
            }
        }

        // Metodos auxiliares (Comportamiento)

        public bool esVacia()
        {
            return aElemento == null && aSublista == null;
        }

        public void agregar(Object pElemento)
        {
            if (esVacia())
            {
                Elemento = pElemento;
                aSublista = new CLista();
            }
            else
            {
                aSublista.agregar(pElemento);
            }
        }

        public void insertar(Object pElemento, int indice)
        {
            if (indice == 0)
            {
                Object aux = aElemento;
                CLista auxLista = aSublista;
                Elemento = pElemento;
                Sublista = new CLista(aux, aSublista);
            }
            else
            {
                aSublista.insertar(pElemento, indice -  1);
            }
        }
        
        public void mostrar ()
        {
            if(!esVacia())
            {
                Console.WriteLine(Elemento.ToString());
                aSublista.mostrar();
            }
        }

        public void eliminar()
        {
            if (!esVacia())
            {
                if (aSublista.esVacia())
                {
                    aElemento = null;
                    aSublista = null;
                }
                else
                {
                    aSublista.eliminar();
                }
            }
        }

        public void eliminarIesimo ( int indice)
        {
            if(indice == 0)
            {
                aElemento = aSublista.aElemento;
                aSublista = aSublista.aSublista;
            }

            else
            {
                aSublista.eliminarIesimo(indice - 1);
            }
        }

        public int ubicacion (Object pElemento)
        {   
            if (!esVacia())
            {
                if(pElemento.Equals(aElemento))
                {
                    return 0;
                }
                else
                {
                    return aSublista.ubicacion(pElemento) + 1;
                }
            }
            else
            {
                return -1;
            }
        }

        public CLista iesimo(int indice)
        {
            if(!esVacia())
            {
                if(indice == 0)
                {
                    return this;
                }
                else
                {
                    return aSublista.iesimo(indice - 1);
                }
            }
            return null;
        }

        public void modificar(Object pElemento, int indice)
        {
            if (indice == 0)
            {
                aElemento = pElemento;
            }

            else
            {
                aSublista.modificar(pElemento, indice - 1);
            }
        }

        public CLista ultimo()
        {
            if (aSublista.esVacia())
            {
                return this;
            }
            else
            {
                return aSublista.ultimo();
            }
        }

    }
}
