using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArbolesGrafos
{
    public class CArbolNario
    {

        // ATRIBUTOS
        private Object aRaiz;
        private CArbolNario aPrimerHijo;
        private CArbolNario aSiguienteHermano;

        // CONSTRUCTORES
        // Sin parametros
        public CArbolNario()
        {
            aRaiz = null;
            aPrimerHijo = null;
            aSiguienteHermano = null;
        }

        // Con parametros
        public CArbolNario(Object pRaiz)
        {
            aRaiz = pRaiz;
            aPrimerHijo = null;
            aSiguienteHermano = null;
        }

        public CArbolNario(Object pRaiz, CArbolNario pPrimerHijo, CArbolNario pSiguienteHermano)
        {
            aRaiz = pRaiz;
            aPrimerHijo = pPrimerHijo;
            aSiguienteHermano = pSiguienteHermano;
        }

        // PROPIEDADES SET Y GET
        public Object Raiz
        {
            get
            {
                return aRaiz;
            }
            set
            {
                aRaiz = value;
            }
        }

        public CArbolNario PrimerHijo
        {
            get { return aPrimerHijo; }
            set { aPrimerHijo = value; }
        }

        public CArbolNario SiguienteHermano {
            get => aSiguienteHermano;
            set => aSiguienteHermano = value;
        }

        // METODOS AUXILIARES
        public bool EsVacio()
        {
            return aRaiz == null && aPrimerHijo == null && aSiguienteHermano == null;
        }

        public CArbolNario Agregar(CArbolNario SubArbolPadre, object pHijo)
        {
            /* Si árbol está vacío o SubArbolPadre es nulo, agregar hijo como raíz */
            if ((SubArbolPadre == null) && (EsVacio()))
            {
                aRaiz = pHijo;
                return this;
            }
            else
            {
                /* --- Verificar que SubArbolPadre pertenece al árbol*/
                if (SubArbolPadre == SubArbol(SubArbolPadre.Raiz))
                    return SubArbolPadre.AgregarHijo(pHijo);
                else
                {
                    Console.WriteLine("ERROR. SubArbolPadre no pertenece al árbol");
                    return null;
                }
            }
        }


        public CArbolNario AgregarHijo(object Hijo)
        {
            /* Si no existe primer hijo, agregarlo como tal */
            if (aPrimerHijo == null)
            {
                aPrimerHijo = new CArbolNario(Hijo);
                return aPrimerHijo;
            }
            else /* Agregar como hermano de primer hijo */
                return aPrimerHijo.AgregarHermano(Hijo);
        }

        public CArbolNario AgregarHermano(Object Hermano)
        {
            /* Si no existe siguiente hermano, agregarlo como tal */
            if (aSiguienteHermano == null)
            {
                aSiguienteHermano = new CArbolNario(Hermano);
                return aSiguienteHermano;
            }
            else
                return aSiguienteHermano.AgregarHermano(Hermano);
        }

        public CArbolNario SubArbol(Object pRaiz)
        {
            if (EsVacio())
                return null;
            else
                /* ---- Verifica si la raiz es del subarbol buscado */
                if (aRaiz.Equals(pRaiz))
                return this;
            else
            {
                /* ----- Buscar en el primer hijo (si existe) */
                CArbolNario ArbolAux = null;
                if (aPrimerHijo != null)
                    ArbolAux = aPrimerHijo.SubArbol(pRaiz);
                /* ---- Si no existe en primer hijo, buscar en siguiente hermano (si existe)*/
                if ((ArbolAux == null) && (aSiguienteHermano != null))
                    ArbolAux = aSiguienteHermano.SubArbol(pRaiz);
                return ArbolAux;
            }
        }

        public CArbolNario Padre(Object Hijo)
        {
            if (EsVacio())
                return null;
            else
                /* -----Verifica es hijo de la raiz actual */
                if (EsHijo(Hijo))
                return this;
            else
            {
                /* ---- Buscar en el primer hijo (si existe) */
                CArbolNario ArbolAux = null;
                if (aPrimerHijo != null)
                    ArbolAux = aPrimerHijo.Padre(Hijo);
                /* ---- Si no existe en primer hijo, buscar en siguiente hermano (si existe) */
                if ((ArbolAux == null) && (aSiguienteHermano != null))
                    ArbolAux = aSiguienteHermano.Padre(Hijo);
                return ArbolAux;
            }
        }

        public bool EsHijo(Object Hijo)
        {
            if ((EsVacio()) || (aPrimerHijo == null))
                return false;
            else
                return (aPrimerHijo.Raiz.Equals(Hijo)) ? true : aPrimerHijo.EsHermano(Hijo);
        }

        public bool EsHermano(Object Hermano)
        {
            if ((EsVacio()) || (aSiguienteHermano == null))
                return false;
            else
                return (aSiguienteHermano.Raiz.Equals(Hermano)) ? true : aSiguienteHermano.EsHermano(Hermano);
        }

        public void Eliminar(CArbolNario pArbol)
        {
            /* ------ Verificar que pArbol es parte del arbol */
            if ((pArbol != null) && (pArbol == SubArbol(pArbol.Raiz)))
            {
                /* --- Recuperar padre */
                CArbolNario ArbolPadre = Padre(pArbol.Raiz);
                /* ----- Si no existe padre, pRaiz es la raiz del arbol */
                if (ArbolPadre == null)
                {
                    /* ---- Eliminar todo el árbol */
                    aRaiz = null;
                    aPrimerHijo = null;
                    aSiguienteHermano = null;
                }
                else /* ----- Eliminar un subarbol */
                    /* ----- Verificar si pArbol a eliminar es primer hijo */
                    if (pArbol == ArbolPadre.PrimerHijo)
                {
                    CArbolNario ArbolAux = ArbolPadre.PrimerHijo.SiguienteHermano;
                    PrimerHijo = ArbolAux;
                }
                else /* ---- Objeto a eliminar no es primer hijo */
                    ArbolPadre.PrimerHijo.EliminarHermano(pArbol);
            }
        }


        protected void EliminarHermano(CArbolNario pArbol)
        {
            if (pArbol == aSiguienteHermano)
                SiguienteHermano = aSiguienteHermano.SiguienteHermano;
            else
                aSiguienteHermano.EliminarHermano(pArbol);
        }

        public void Procesar()
        {
            if (!EsVacio())
                Console.WriteLine(Raiz);
        }
        // -----------------------------------------------------------------
        public void PreOrden()
        {
            if (!EsVacio())
            {
                Procesar();
                if (aPrimerHijo != null)
                {
                    aPrimerHijo.PreOrden();
                    aPrimerHijo.RecorrerHermanoPreOrden();
                }
            }
        }
        // -----------------------------------------------------------------
        protected void RecorrerHermanoPreOrden()
        {
            if (aSiguienteHermano != null)
            {
                aSiguienteHermano.PreOrden();
                aSiguienteHermano.RecorrerHermanoPreOrden();
            }
        }
        // -----------------------------------------------------------------
        public void PosOrden()
        {
            if (aPrimerHijo != null)
            {
                aPrimerHijo.PosOrden();
                aPrimerHijo.RecorrerHermanoPosOrden();
            }
            Procesar();
        }
        // -----------------------------------------------------------------
        protected void RecorrerHermanoPosOrden()
        {
            if (aSiguienteHermano != null)
            {
                aSiguienteHermano.PosOrden();
                aSiguienteHermano.RecorrerHermanoPosOrden();
            }
        }
        // -----------------------------------------------------------------
        public void InOrden()
        {
            if (aPrimerHijo != null)
            {
                aPrimerHijo.InOrden();
            }
            Procesar();
            if (aPrimerHijo != null)
            {
                aPrimerHijo.RecorrerHermanoInOrden();
            }
        }
        // -----------------------------------------------------------------
        protected void RecorrerHermanoInOrden()
        {
            if (aSiguienteHermano != null)
            {
                aSiguienteHermano.InOrden();
                aSiguienteHermano.RecorrerHermanoInOrden();
            }
        }
        // -----------------------------------------------------------------
        public int Altura()
        {
            if (EsVacio())
                return 0;
            else
                if (aPrimerHijo != null)
            {
                int Altura1 = 1 + aPrimerHijo.Altura();
                int Altura2 = 1 + aPrimerHijo.AlturaHermanos();
                return (Altura1 > Altura2 ? Altura1 : Altura2);
            }
            else // Arbol es una hoja
                return 0;
        }
        // -----------------------------------------------------------------
        protected int AlturaHermanos()
        {
            if (aSiguienteHermano == null)
                return 0;
            else
            {
                int Altura1 = aSiguienteHermano.Altura();
                int Altura2 = aSiguienteHermano.AlturaHermanos();
                return (Altura1 > Altura2 ? Altura1 : Altura2);
            }
        }

        public void escribirArbol(String marca)
        {
            if (!EsVacio())
            {
                Console.WriteLine(marca + this.aRaiz.ToString());
                marca = marca + "->";
                if (this.aPrimerHijo != null)
                {
                    CArbolNario auxiliar = this.aPrimerHijo;
                    while (auxiliar != null)
                    {
                        auxiliar.escribirArbol(marca);
                        auxiliar = auxiliar.SiguienteHermano;
                    }
                }
            }
        }
    
        public void mostrarAbol()
        {
            escribirArbol(" ");
        }



    //public void Agregar(Object pRaiz, CArbolNario pArbol) { 

    //    if ( EsVacio())
    //    {
    //        aRaiz = pRaiz;
    //    }
    //    else
    //    {
    //        AgregarHijo(pRaiz);
    //    }
    //}


    //public void AgregarHijo(Object pRaiz)
    //{

    //    if(aPrimerHijo == null)
    //    {
    //        aPrimerHijo = new CArbolNario(pRaiz);
    //    }
    //    else
    //    {
    //        AgregarHermano(pRaiz);
    //    }
    //}

    //public void AgregarHermano(Object pRaiz)
    //{
    //    if (aSiguienteHermano == null)
    //    {
    //        aSiguienteHermano = new CArbolNario(pRaiz);
    //    }
    //    else
    //    {
    //        aSiguienteHermano.AgregarHermano(pRaiz);
    //    }
    //}
    }
}
