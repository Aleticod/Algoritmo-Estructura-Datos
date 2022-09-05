using System;
using System.Collections;
using System.Collections.Generic;

namespace ArbolesGrafos
{
    public class CGrafo
    {
		ArrayList vertices = new ArrayList();
		int[,] matriz;
		

		public void agregarVertice(Vertice v)
		{
			vertices.Add(v);
			int cant = vertices.Count;
			matriz = new int[cant, cant];
		}

		public void agregarNuevoPeso(Vertice vO, Vertice vD, object p)
		{
			foreach (Vertice element in vertices)
			{
				if (element == vO)
				{
					element.agregarNuevoPeso(vD, p);
				}
			}
		}

		public void eliminarVertice(Vertice v)
		{
			foreach (Vertice element in vertices)
			{
				if (v == element)
				{
					int n = vertices.IndexOf(v);
					v.setNombre("ElementoBorrado");
					for (int i = 0; i < matriz.GetLength(0); i++)
					{
						matriz[i, n] = -1;
						matriz[n, i] = -1;
					}
					break;
				}
			}
			Console.WriteLine();

		}

		public ArrayList getListaDeVertices()
		{
			return vertices;
		}

		public void conectarVertices(Vertice vOrigen, Vertice vDestino, object peso)
		{
			int origen = vertices.IndexOf(vOrigen);
			int destino = vertices.IndexOf(vDestino);
			matriz[origen, destino] = (int)peso;
			//matrizPesos[origen, destino] = (int)peso;
			vOrigen.agregarAdyacente(vDestino, peso);

		}

		

		public void desconectarVertices(Vertice vO, Vertice vD)
		{
			int origen = vertices.IndexOf(vO);
			int destino = vertices.IndexOf(vD);
			matriz[origen, destino] = 0;
			vO.eliminarAdyacente(vD);

		}

		public int[,] getMatriz()
		{
			return matriz;
		}

		public void imprimirMatriz()
		{
			Console.WriteLine();
			Console.WriteLine("La matriz es: ");
			for (int i = 0; i < matriz.GetLength(1); i++)
			{
				for (int j = 0; j < matriz.GetLength(1); j++)
				{

					Console.Write("[" + matriz[i, j] + "]");
				}
				Console.WriteLine();
			}
			Console.WriteLine();
			Console.WriteLine("ACLARACION: El valor -1 especifica que un vertice fue eliminado del grafo. ");
		}

		public ArrayList listaDeAdyacentes(Vertice v)
		{
			ArrayList adyacentes = new ArrayList();
			adyacentes = v.getAdyacentes();
			return adyacentes;
		}

		public void vertice()
		{
			Console.WriteLine();
			Console.Write("Ingresa una posicion para encontrar un vertice: ");
			String l = Console.ReadLine();
			int posicion = int.Parse(l);
			posicion = posicion - 1;
			Vertice verti = (Vertice)vertices[posicion];
			Console.WriteLine();
			Console.WriteLine("El nombre del vertice seleccionado es: " + verti.getNombre());
			Console.Write("Y sus datos son: ");
			ArrayList datos = new ArrayList();
			datos = verti.getDatos();
			foreach (var element in datos)
			{
				Console.Write("[" + element + "]");
			}


		}

		public ArrayList buscarCaminosPorDistancia(Vertice verO, ArrayList vertices, int distancia, int cont)
		{
			ArrayList adyacentes = new ArrayList();
			adyacentes = listaDeAdyacentes(verO);
			if (cont == distancia)
			{
				vertices.Add(verO);
			}
			else
			{
				cont++;
				foreach (Vertice v in adyacentes)
				{
					buscarCaminosPorDistancia(v, vertices, distancia, cont);

				}
			}

			return vertices;

		}


		public ArrayList buscarTodosLosCaminos(Vertice verO, Vertice VerD, ArrayList caminoActual, ArrayList todosLosCaminos, ArrayList adyacentes)
		{

			adyacentes = listaDeAdyacentes(verO);
			caminoActual.Add(verO);
			verO.marcarVisitado();
			
			if (verO == VerD)
			{
				todosLosCaminos.Add(caminoActual.Clone());
			}
			else
			{
				foreach (Vertice v in adyacentes)
				{
					if (v.getVisitado() == false)
					{
						buscarTodosLosCaminos(v, VerD, caminoActual, todosLosCaminos, adyacentes);
						//v.desmarcar();
						//caminoActual.Remove(v);
					}

				}
			}
			verO.desmarcar();
			caminoActual.Remove(verO);
			return todosLosCaminos;
		}

		public List<int> dijkstra (int verticeO, int verticeD, int nroVertices )
        {
			
			int[,] tabla = new int[nroVertices, 3];
			for (int k = 0; k < nroVertices; k++)
			{
				tabla[k, 0] = 0;
				tabla[k, 1] = int.MaxValue;
				tabla[k, 2] = 0;
			}
			tabla[verticeO, 1] = 0;
			//mostrarTabla(tabla);

			// verticeO Dijkstra
			int Distancia = 0;
			int actual = verticeO;
			do
			{
				tabla[actual, 0] = 1;
				for (int columna = 0; columna < nroVertices; columna++)
				{
					if (matriz[actual, columna] != 0)
					{
						Distancia = (matriz[actual, columna] + tabla[actual, 1]);
						if (Distancia < tabla[columna, 1])
						{
							tabla[columna, 1] = Distancia;
							tabla[columna, 2] = actual;

						}
					}
				}

				int IndiceMenor = -1;
				int DistanciaMenor = int.MaxValue;
				for (int j = 0; j < nroVertices; j++)
				{
					if (tabla[j, 1] < DistanciaMenor && tabla[j, 0] == 0)
					{
						IndiceMenor = j;
						DistanciaMenor = tabla[j, 1];
					}
				}
				actual = IndiceMenor;
			} while (actual != -1);

			//mostrarTabla(tabla);

			List<int> Ruta = new List<int>();
			int nodo = verticeD;

			while (nodo != verticeO)
			{
				Ruta.Add(nodo);
				nodo = tabla[nodo, 2];
			}
			Ruta.Add(verticeO);
			Ruta.Reverse();
			return Ruta;
		}

		public static void mostrarTabla(int[,] tabla)
        {
			int n = 0;
			for (n = 0; n <	tabla.GetLength(0); n++ )
            {
                Console.WriteLine("{0} -> {1}\t{2}\t{3}", n, tabla[n,0], tabla[n,1], tabla[n,2]);
            }
            Console.WriteLine("-----------------------------------");
        }

	}
	
}
