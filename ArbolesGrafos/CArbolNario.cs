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

        public void Agregar(Object pRaiz) { 
            
        }


        public void AgregarHijo(Object pRaiz)
        {
            if (!EsVacio())
            {
                if(aPrimerHijo == null)
                {
                    aPrimerHijo = new CArbolNario(pRaiz);
                }
                else
                {
                    AgregarHermano(pRaiz);
                }
            }
        }

        public void AgregarHermano(Object pRaiz)
        {
            if (aSiguienteHermano == null)
            {
                aSiguienteHermano = new CArbolNario(pRaiz);
            }
            else
            {
                aSiguienteHermano.AgregarHermano(pRaiz);
            }
        }
    }
}
