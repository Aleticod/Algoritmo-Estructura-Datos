using System;
using System.Collections;
using System.Collections.Generic;
using ArbolesGrafos;

namespace AppGrafos
{
    public class Procesar
    {

		CGrafo grafoPrueba = new CGrafo();
		CGrafo newGrafo = new CGrafo();
		public Procesar()
		{
			//CREAMOS LOS VERTICES
			Vertice verticeA = new Vertice("A");
			Vertice verticeB = new Vertice("B");
			Vertice verticeC = new Vertice("C");
			Vertice verticeD = new Vertice("D");
			Vertice verticeE = new Vertice("E");
	

			//Agregamos los datos que contienen los vertices...

			verticeA.agregarDato("A");
			verticeA.agregarDato(1);
			verticeB.agregarDato("B");
			verticeB.agregarDato(2);
			verticeC.agregarDato("C");
			verticeC.agregarDato(3);
			verticeD.agregarDato("D");
			verticeD.agregarDato(4);
			verticeE.agregarDato("E");
			verticeE.agregarDato(5);

			//Agregamos los vertices al CGrafo

			grafoPrueba.agregarVertice(verticeA);
			grafoPrueba.agregarVertice(verticeB);
			grafoPrueba.agregarVertice(verticeC);
			grafoPrueba.agregarVertice(verticeD);
			grafoPrueba.agregarVertice(verticeE);


			//Conectamos los vertices entre sí...

			grafoPrueba.conectarVertices(verticeA, verticeB, 1);
			grafoPrueba.conectarVertices(verticeB, verticeA, 1);
			grafoPrueba.conectarVertices(verticeA, verticeE, 2);
			grafoPrueba.conectarVertices(verticeE, verticeA, 2);
			grafoPrueba.conectarVertices(verticeB, verticeE, 3);
			grafoPrueba.conectarVertices(verticeE, verticeB, 3);
			grafoPrueba.conectarVertices(verticeB, verticeD, 2);
			grafoPrueba.conectarVertices(verticeD, verticeB, 2);
			grafoPrueba.conectarVertices(verticeE, verticeD, 1);
			grafoPrueba.conectarVertices(verticeD, verticeE, 1);
			grafoPrueba.conectarVertices(verticeB, verticeC, 4);
			grafoPrueba.conectarVertices(verticeC, verticeB, 4);
			grafoPrueba.conectarVertices(verticeD, verticeC, 1);
			grafoPrueba.conectarVertices(verticeC, verticeD, 1);



			//Ahora agregamos el segundo dato que tienen las aristas

			grafoPrueba.agregarNuevoPeso(verticeA, verticeB, 1);
			grafoPrueba.agregarNuevoPeso(verticeA, verticeE, 2);
			grafoPrueba.agregarNuevoPeso(verticeB, verticeE, 3);
			grafoPrueba.agregarNuevoPeso(verticeB, verticeD, 2);
			grafoPrueba.agregarNuevoPeso(verticeE, verticeD, 1);
			grafoPrueba.agregarNuevoPeso(verticeB, verticeC, 4);
			grafoPrueba.agregarNuevoPeso(verticeD, verticeC, 1);

		}

		public void ini()
		{
			Console.Clear();
			Console.WriteLine("             MENU                   ");
			Console.WriteLine("1 - Grafo precargado");
			Console.WriteLine("2 - Nuevo Grafo");
			Console.WriteLine("3 - Para cerrar la aplicación");
			String e = Console.ReadLine();
			int E = int.Parse(e);

			switch (E)
			{
				case 1:
					grafoPre();
					break;
				case 2:
					nuevoGrafo();
					break;
				case 3:
					Environment.Exit(0);
					break;
					//aca tenemos que encontrar la forma de hacer que el programa se cierre
			}
		}

		public void grafoPre()
		{
			ArrayList lista = grafoPrueba.getListaDeVertices();
			Console.Clear();
			Console.WriteLine("           GRAFOS            ");
			Console.WriteLine("1 - para agregar vértice (No funciona)");
			Console.WriteLine("2 - para eliminar un vértice");
			Console.WriteLine("3 - para conectar o desconectar aristas de los vértices");
			Console.WriteLine("4 - para imprimir la matriz de adyacencias");
			Console.WriteLine("5 - para imprimir la lista de vertices del Grafo");
			Console.WriteLine("6 - para encontrar un vértice");
            Console.WriteLine("7 - para encontrar el recorrido mas corto mediante Dijkstra");
			Console.WriteLine("8 - para volver");
			String a = Console.ReadLine();
			int A = int.Parse(a);

			switch (A)
			{
				case 1:
					Console.Clear();
					Console.Write("Ingresa el nombre del nuevo vértice: ");
					String nombre = Console.ReadLine();
					Vertice vertice = new Vertice(nombre);
					Console.WriteLine();
					Console.Write("Ingresa el dato que contiene el vértice: ");
					object dato = Console.ReadLine();
					vertice.agregarDato(dato);
					grafoPrueba.agregarVertice(vertice);
					Console.WriteLine();
					Console.Write("Agregar nuevo dato al vértice? y/n: ");
					String dec = Console.ReadLine();
					if (dec == "y")
					{
						Console.WriteLine();
						Console.Write("Ingresa el dato a agregar en el vértice: ");
						object datnew = Console.ReadLine();
						vertice.agregarDato(datnew);
						Console.WriteLine("Nuevo dato agregado. Presiona cualquier tecla para continuar.");
						Console.ReadKey(true);
						grafoPre();
						break;
					}
					else
						Console.WriteLine();
					Console.WriteLine("Vértice agregado al CGrafo. Presiona cualquier tecla para continuar...");
					Console.ReadKey(true);
					grafoPre();
					break;

				case 2:
					Console.Clear();
					Console.Write("Ingresa la posicion del vértice a eliminar: ");
					String b = Console.ReadLine();
					int B = int.Parse(b);
					B--;
					Vertice v = (Vertice)lista[B];
					Console.WriteLine("El vertice seleccionado es: " + v.getNombre() + ". Estas seguro de eliminarlo? (si/no)");
					String c = Console.ReadLine();
					if (c == "si")
					{
						grafoPrueba.eliminarVertice(v);
						Console.WriteLine();
						Console.WriteLine("El vértice ha sido eliminado del CGrafo. Presiona cualquier tecla para continuar. ");
					}
					if (c == "no")
					{
						Console.WriteLine();
						Console.WriteLine("El vértice no ha sido eliminado del CGrafo. Presiona cualquier tecla para continuar. ");
					}
					Console.ReadKey(true);
					grafoPre();
					break;

				case 3:
					Console.Clear();
					Console.Write("Ingresa la posicion del primer vértice: ");
					String primero = Console.ReadLine();
					Console.Write("Ingresa la posición del segundo vértice: ");
					String segundo = Console.ReadLine();
					int pr = int.Parse(primero);
					int sg = int.Parse(segundo);
					pr--;
					sg--;
					Vertice pv = (Vertice)lista[pr];
					Vertice sv = (Vertice)lista[sg];
					int pos1 = lista.IndexOf(pv);
					int pos2 = lista.IndexOf(sg);
					Console.Clear();
					Console.WriteLine("Los vértices seleccionados son: " + pv.getNombre() + " y " + sv.getNombre());
					Console.WriteLine("Ingresa 1 para conectar los vértices");
					Console.WriteLine("Ingresa 2 para desconectar los vértices");
					Console.WriteLine("Ingresa 3 para volver");
					String op = Console.ReadLine();
					int opcion = int.Parse(op);
					switch (opcion)
					{
						case 1:
							Console.Clear();
							Console.Write("Ingresa su peso: ");
							object peso = Console.ReadLine();
							grafoPrueba.conectarVertices(pv, sv, peso);
							Console.WriteLine();
							Console.WriteLine("Los vértices " + pv.getNombre() + " y " + sv.getNombre() + " fueron conectados");
							Console.WriteLine();
							Console.WriteLine("Presiona cualquier tecla para continuar.");
							Console.ReadKey(true);
							grafoPre();
							break;

						case 2:
							Console.Clear();
							grafoPrueba.desconectarVertices(pv, sv);
							Console.WriteLine("Los vértices " + pv.getNombre() + " y " + sv.getNombre() + " fueron desconectados.");
							Console.WriteLine();
							Console.WriteLine("Presiona cualquier tecla para continuar.");
							Console.ReadKey(true);
							grafoPre();
							break;

						case 3:
							grafoPre();
							break;
					}
					Console.ReadKey(true);
					grafoPre();
					break;

				case 4:
					Console.Clear();
					grafoPrueba.imprimirMatriz();
					Console.WriteLine();
					Console.WriteLine("Presiona cualquier tecla para continuar.");
					Console.ReadKey(true);
					grafoPre();
					break;

				case 5:
					Console.Clear();
					Console.WriteLine("La lista de vértices del CGrafo es: ");

					foreach (Vertice element in lista)
					{
							Console.Write("[" + element.getNombre() + "]");
					}
					Console.WriteLine();
					Console.WriteLine();
					Console.WriteLine("Presiona cualquier tecla para continuar.");
					Console.ReadKey(true);
					grafoPre();
					break;

				case 6:
					Console.Clear();
					Console.WriteLine("Para buscar por posicion ingresa 1");
					Console.WriteLine("Para buscar por nombre ingresa 2");
					String d = Console.ReadLine();
					int D = int.Parse(d);
					switch (D)
					{
						case 1:
							Console.Clear();
							Console.Write("Ingresa la posicion del vértice a buscar: ");
							String e = Console.ReadLine();
							int E = int.Parse(e);
							E--;
							Vertice v1 = (Vertice)lista[E];
							ArrayList datos = new ArrayList();
							datos = v1.getDatos();
							Console.WriteLine();
							Console.WriteLine("El vértice seleccionado es: " + v1.getNombre());
							Console.WriteLine("Y sus datos son: ");
							foreach (var element in datos)
							{
								Console.Write("[" + element.ToString() + "]");
							}
							Console.WriteLine();
							Console.WriteLine();
							Console.WriteLine("Presiona una tecla para continuar.");
							Console.ReadKey(true);
							grafoPre();
							break;

						case 2:
							Console.Clear();
							Console.Write("Ingresa el nombre del vértice a buscar: ");
							String vert = Console.ReadLine();
							foreach (Vertice element in lista)
							{
								if (element.getNombre() == vert)
								{
									ArrayList dat = new ArrayList();
									dat = element.getDatos();
									Console.WriteLine();
									Console.WriteLine("Los datos de " + element.getNombre() + " son: ");
									foreach (var data in dat)
									{
										Console.Write("[" + data.ToString() + "]");
									}
									int pos = lista.IndexOf(element);
									pos++;
									Console.WriteLine();
									Console.WriteLine("POSICION en la lista de vértices: " + pos);
									Console.WriteLine();
								}
							}

							Console.WriteLine("Presiona cualquier tecla para continuar.");
							Console.ReadKey(true);
							grafoPre();
							break;
					}

					break;

				case 7:
					Console.Clear();
					Console.Write("Ingresa el nombre del vertice Inicio: ");
					String vInicio = Console.ReadLine();
					int posicion = 0;
					foreach (Vertice element in lista)
					{
						if (element.getNombre() == vInicio)
						{
							posicion = lista.IndexOf(element);
							posicion++;
							Console.WriteLine();
							Console.WriteLine();
						}
					}

					int inicio = posicion-1;
					Console.Write("Ingresa el nombre del vertice Fina: ");
					String vFinal = Console.ReadLine();
					posicion = 0;
					foreach (Vertice element in lista)
					{
						if (element.getNombre() == vFinal)
						{
							posicion = lista.IndexOf(element);
							posicion++;
							Console.WriteLine();
							Console.WriteLine();
						}
					}

					int final = posicion-1;
					int nroVertices = 0;

					foreach (Vertice element in lista)
					{
						nroVertices++;
					}

					List<int> ruta = grafoPrueba.dijkstra(inicio, final, nroVertices);


					string nombreVertice = "";
					foreach (int pos in ruta)
                    {
						int auxiliar = 0;
						foreach (Vertice element in lista)
						{
							if (pos == auxiliar)
                            {
								nombreVertice = element.getNombre();
								break;
							}
							else
                            {
								auxiliar++;
                            }
						}

						Console.Write($"{nombreVertice}->");
					}
                    Console.WriteLine(" ");
					Console.WriteLine("Presiona cualquier tecla para continuar.");
					Console.ReadKey(true);
					grafoPre();
					break;

				case 8:
					ini();
					break;
			}
		}

		public void nuevoGrafo()
		{

			ArrayList listanueva = new ArrayList();
			listanueva = newGrafo.getListaDeVertices();
			Console.Clear();
			Console.WriteLine("            NUEVO CGrafo         ");
			Console.WriteLine("1 - VERTICES");
			Console.WriteLine("2 - ARISTAS");
			Console.WriteLine("3 - Imprimir matriz de adyacencias");
			Console.WriteLine("4 - Imprimir lista de vértices del Grafo");
			Console.WriteLine("5 - Encontrar un vértice en el Grafo");
			Console.WriteLine("6 - para encontrar el recorrido mas corto mediante Dijkstra");
			Console.WriteLine("7 - Volver al menú principal");
			String a = Console.ReadLine();
			int A = int.Parse(a);

			switch (A)
			{
				case 1:
					Console.Clear();
					Console.WriteLine("1 - Agregar vértice al Grafo");
					Console.WriteLine("2 - Agregar nuevo dato a un vértice");
					Console.WriteLine("3 - Eliminar un vértice");
					Console.WriteLine("4 - Volver");
					String b = Console.ReadLine();
					int B = int.Parse(b);

					switch (B)
					{
						case 1:
							Console.Clear();
							Console.Write("Ingresa el nombre del vértice: ");
							String nombre = Console.ReadLine();
							Console.WriteLine();
							Console.Write("Ingresa el dato que contiene el vértice: ");
							String data = Console.ReadLine();
							Vertice nvoVer = new Vertice(nombre);
							nvoVer.agregarDato(data);
							newGrafo.agregarVertice(nvoVer);
							Console.WriteLine();
							Console.WriteLine();
							Console.WriteLine("El vértice ha sido agregado al CGrafo. Presiona cualquier tecla para continuar...");
							Console.ReadKey(true);
							nuevoGrafo();
							break;

						case 2:
							Console.Clear();
							Console.Write("Ingresa la posicion del vértice: ");
							String p = Console.ReadLine();
							int P = int.Parse(p);
							P--;
							Console.WriteLine();
							Console.Write("Ingresa el dato a agregar: ");
							String datonuevo = Console.ReadLine();
							Vertice v = (Vertice)listanueva[P];
							v.agregarDato(datonuevo);
							Console.WriteLine();
							Console.WriteLine();
							Console.WriteLine("El dato ha sido agregado al vértice " + v.getNombre() + ". Presiona cualquier tecla para continuar...");
							Console.ReadKey(true);
							nuevoGrafo();
							break;

						case 3:
							Console.Clear();
							Console.Write("Ingresa la posicion del vértice a eliminar: ");
							String o = Console.ReadLine();
							int O = int.Parse(o);
							O--;
							Vertice vert = (Vertice)listanueva[O];
							Console.WriteLine("El vertice seleccionado es: " + vert.getNombre() + ". Estas seguro de eliminarlo? (si/no)");
							String c = Console.ReadLine();
							if (c == "si")
							{
								newGrafo.eliminarVertice(vert);
								Console.WriteLine();
								Console.WriteLine("El vértice ha sido eliminado del CGrafo. Presiona cualquier tecla para continuar. ");
							}
							if (c == "no")
							{
								Console.WriteLine();
								Console.WriteLine("El vértice no ha sido eliminado del CGrafo. Presiona cualquier tecla para continuar. ");
							}
							Console.ReadKey(true);
							nuevoGrafo();
							break;

						case 4:
							nuevoGrafo();
							break;
					}
					break;

				case 2:
					Console.Clear();
					Console.WriteLine("1 - Conectar vertices");
					Console.WriteLine("2 - Desconectar vértices");
					Console.WriteLine("3 - Ver el peso entre dos vértices");
					String d = Console.ReadLine();
					int D = int.Parse(d);

					switch (D)
					{
						case 1:
							Console.Clear();
							Console.Write("Ingresa la posicion del primer vértice: ");
							String primero = Console.ReadLine();
							Console.Write("Ingresa la posición del segundo vértice: ");
							String segundo = Console.ReadLine();
							int pr = int.Parse(primero);
							int sg = int.Parse(segundo);
							pr--;
							sg--;
							Vertice pv = (Vertice)listanueva[pr];
							Vertice sv = (Vertice)listanueva[sg];
							Console.Write("Ingresa el peso que contiene la arista: ");
							String pesoS = Console.ReadLine();
							int peso = int.Parse(pesoS);
							newGrafo.conectarVertices(pv, sv, peso);
							newGrafo.conectarVertices(sv, pv, peso);
							Console.WriteLine();
							Console.Write("Los vértices han sido conectados. Presiona cualquier tecla para continuar...");
							Console.ReadKey(true);
							nuevoGrafo();
							break;

						case 2:
							Console.Clear();
							Console.Write("Ingresa la posicion del primer vértice: ");
							String primervertice = Console.ReadLine();
							Console.Write("Ingresa la posición del segundo vértice: ");
							String segundovertice = Console.ReadLine();
							int pr2 = int.Parse(primervertice);
							int sg2 = int.Parse(segundovertice);
							pr2--;
							sg2--;
							Vertice pv2 = (Vertice)listanueva[pr2];
							Vertice sv2 = (Vertice)listanueva[sg2];
							newGrafo.desconectarVertices(pv2, sv2);
							Console.WriteLine();
							Console.WriteLine("Los vértices " + pv2.getNombre() + " y " + sv2.getNombre() + " han sido desconectados.");
							Console.WriteLine("Presiona cualquier tecla para continuar...");
							Console.ReadKey(true);
							nuevoGrafo();
							break;

						case 3:
							Console.Clear();
							Console.Write("Ingresa la posicion del primer vértice: ");
							String pvp = Console.ReadLine();
							Console.Write("Ingresa la posición del segundo vértice: ");
							String svp = Console.ReadLine();
							int pr3 = int.Parse(pvp);
							int sg3 = int.Parse(svp);
							pr3--;
							sg3--;
							Vertice pv3 = (Vertice)listanueva[pr3];
							Vertice sv3 = (Vertice)listanueva[sg3];
							ArrayList ady = new ArrayList();
							ady = pv3.getAristas();
							ArrayList dato = new ArrayList();
							foreach (Aristas element in ady)
							{
								if (element.getVerDes() == sv3)
								{
									dato = element.getPeso();
								}
							}
							Console.WriteLine();
							Console.Write("El peso entre " + pv3.getNombre() + " y " + sv3.getNombre() + " es: ");
							foreach (var element in dato)
							{
								Console.WriteLine("[" + element + "]");
							}
							Console.WriteLine();
							Console.WriteLine();
							Console.WriteLine("Presiona cualquier tecla para continuar...");
							Console.ReadKey(true);
							nuevoGrafo();
							break;
					}
					break;

				case 3:
					Console.Clear();
					newGrafo.imprimirMatriz();
					Console.WriteLine();
					Console.WriteLine("Presiona cualquier tecla para continuar...");
					Console.ReadKey(true);
					nuevoGrafo();
					break;

				case 4:
					Console.Clear();
					Console.WriteLine("La lista de vértices del CGrafo es: ");
					foreach (Vertice element in listanueva)
					{
						Console.Write("[" + element.getNombre() + "]");
					}
					Console.WriteLine();
					Console.WriteLine();
					Console.WriteLine("Presiona cualquier tecla para continuar.");
					Console.ReadKey(true);
					nuevoGrafo();
					break;

				case 5:
					Console.Clear();
					Console.WriteLine("Para buscar por posicion ingresa 1");
					Console.WriteLine("Para buscar por nombre ingresa 2");
					String f = Console.ReadLine();
					int F = int.Parse(f);
					switch (F)
					{
						case 1:
							Console.Clear();
							Console.Write("Ingresa la posicion del vértice a buscar: ");
							String e = Console.ReadLine();
							int E = int.Parse(e);
							E--;
							Vertice v1 = (Vertice)listanueva[E];
							ArrayList datos = new ArrayList();
							datos = v1.getDatos();
							Console.WriteLine();
							Console.WriteLine("El vértice seleccionado es: " + v1.getNombre());
							Console.WriteLine("Y sus datos son: ");
							foreach (var element in datos)
							{
								Console.Write("[" + element.ToString() + "]");
							}
							Console.WriteLine();
							Console.WriteLine();
							Console.WriteLine("Presiona una tecla para continuar...");
							Console.ReadKey(true);
							nuevoGrafo();
							break;

						case 2:
							Console.Clear();
							Console.Write("Ingresa el nombre del vértice a buscar: ");
							String vert = Console.ReadLine();
							foreach (Vertice element in listanueva)
							{
								if (element.getNombre() == vert)
								{
									ArrayList dat = new ArrayList();
									dat = element.getDatos();
									Console.WriteLine();
									Console.WriteLine("Los datos de " + element.getNombre() + " son: ");
									foreach (var data in dat)
									{
										Console.Write("[" + data.ToString() + "]");
									}
									int pos = listanueva.IndexOf(element);
									pos++;
									Console.WriteLine();
									Console.WriteLine("POSICION en la lista de vértices: " + pos);
									Console.WriteLine();
								}
							}

							Console.WriteLine("Presiona cualquier tecla para continuar.");
							Console.ReadKey(true);
							nuevoGrafo();
							break;

					}
					break;

				case 6:
					Console.Clear();
					Console.Write("Ingresa el nombre del vertice Inicio: ");
					String vInicio = Console.ReadLine();
					int posicion = 0;
					foreach (Vertice element in listanueva)
					{
						if (element.getNombre() == vInicio)
						{
							posicion = listanueva.IndexOf(element);
							posicion++;
							Console.WriteLine();
							//Console.WriteLine("POSICION en la lista de vértices: " + pos);
							Console.WriteLine();
						}
					}
					//Console.WriteLine("Indique inicio: ");
					//string datoI = Console.ReadLine();
					int inicio = posicion - 1;
					Console.Write("Ingresa el nombre del vertice Fina: ");
					String vFinal = Console.ReadLine();
					posicion = 0;
					foreach (Vertice element in listanueva)
					{
						if (element.getNombre() == vFinal)
						{
							posicion = listanueva.IndexOf(element);
							posicion++;
							Console.WriteLine();
							//Console.WriteLine("POSICION en la lista de vértices: " + pos);
							Console.WriteLine();
						}
					}
					//Console.WriteLine("Indique Final: ");
					//string datoF = Console.ReadLine();
					int final = posicion - 1;
					int nroVertices = 0;

					foreach (Vertice element in listanueva)
					{
						nroVertices++;
					}

					List<int> ruta = newGrafo.dijkstra(inicio, final, nroVertices);


					string nombreVertice = "";
					foreach (int pos in ruta)
					{
						int auxiliar = 0;
						foreach (Vertice element in listanueva)
						{
							if (pos == auxiliar)
							{
								nombreVertice = element.getNombre();
								break;
							}
							else
							{
								auxiliar++;
							}

						}

						Console.Write($"{nombreVertice}->");
					}
					Console.WriteLine(" ");
					Console.WriteLine("Presiona cualquier tecla para continuar.");
					Console.ReadKey(true);
					nuevoGrafo();
					break;

				case 7:
					ini();
					break;
			}
		}
	}
}
