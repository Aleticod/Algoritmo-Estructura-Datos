using System;
using System.Collections;

namespace ArbolesGrafos
{
    public class Aristas
    {
		ArrayList peso = new ArrayList();
		Vertice verD;
		Vertice verO;


		public Aristas(Vertice verorigen, Vertice verdestino, object p)
		{
			peso.Add(p);
			verO = verorigen;
			verD = verdestino;
		}

		public ArrayList getPeso()
		{
			return peso;
		}

		public Vertice getVerOri()
		{
			return verO;
		}

		public Vertice getVerDes()
		{
			return verD;
		}

		public void agregarPeso(object p)
		{
			peso.Add(p);
		}
	}
}
