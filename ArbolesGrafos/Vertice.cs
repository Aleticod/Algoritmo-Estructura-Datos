using System;
using System.Collections;

namespace ArbolesGrafos
{
    public class Vertice
    {
		ArrayList datos = new ArrayList();
		String nombre;
		Boolean visitado;
		ArrayList adyacentes = new ArrayList();

		public Vertice(String n)
		{
			nombre = n;
		}


		public ArrayList getDatos()
		{
			return datos;
		}

		public String getNombre()
		{
			return (nombre);
		}

		public void setNombre(String n)
		{
			nombre = n;
		}

		public Boolean getVisitado()
		{
			return visitado;
		}

		public void agregarDato(object dato)
		{
			datos.Add(dato);
		}

		public void marcarVisitado()
		{
			visitado = true;
		}

		public void desmarcar()
		{
			visitado = false;
		}


		public void agregarAdyacente(Vertice verD, object peso)
		{
			Aristas arista = new Aristas(this, verD, peso);
			adyacentes.Add(arista);

		}

		public void eliminarAdyacente(Vertice verDestino)
		{
			foreach (Aristas element in adyacentes)
			{
				if (element.getVerDes() == verDestino)
				{
					adyacentes.Remove(element);
					break;
				}
			}
		}

		public ArrayList getAdyacentes()
		{
			ArrayList ady = new ArrayList();
			foreach (Aristas element in adyacentes)
			{
				ady.Add(element.getVerDes());
			}

			return ady;
		}

		public ArrayList getAristas()
		{
			return adyacentes;
		}

		public void agregarNuevoPeso(Vertice vD, object p)
		{
			foreach (Aristas element in adyacentes)
			{
				if (element.getVerDes() == vD)
				{
					element.agregarPeso(p);
				}
			}
		}
	}
}
