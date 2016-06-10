﻿using System;
using System.Collections;

namespace SistemaDNS
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			NodoGeneral dominioRaiz = new NodoGeneral(new DominioBase ("."));
			DNS SistemaDNS = new DNS (dominioRaiz);

			Utils utilidad = new Utils ();

			Console.WriteLine ("************************************");
			Console.WriteLine ("**           SISTEMA DNS          **");
			Console.WriteLine ("************************************");
			Console.WriteLine ("");
			Console.WriteLine ("1. Ingresar dominio");
			Console.WriteLine ("2. Ver listado de dominios superiores");
			Console.WriteLine ("3. Ver Datos de equipo");
			Console.WriteLine ("4. Ver Equipos de un subdominio ");

			Console.WriteLine ("6. Test");
			Console.WriteLine ("7. Salir");



			string op = Console.ReadLine ();
			int opcion = int.Parse (op);

			while (opcion != 7) {
			
				if (opcion == 1) {
					Console.Clear ();
					Console.WriteLine ("************************************");
					Console.WriteLine ("**         AGREGAR DOMINIO        **");
					Console.WriteLine ("************************************");
					Console.WriteLine ("");
					Console.WriteLine ("Ingrese el nombre de dominio completo");
					string dominio = Console.ReadLine ();
					Console.WriteLine ("Ingrese dirección de IP");
					string ip = Console.ReadLine ();
					Console.WriteLine ("Ingrese los servicios separados por comas");
					string servicios = Console.ReadLine ();

					SistemaDNS.cargarDominio (dominio,ip,servicios);

				}

				if (opcion == 2) {
					Console.Clear ();
					Console.WriteLine ("************************************");
					Console.WriteLine ("**   DOMINIOS DE NIVEL SUPERIOR   **");
					Console.WriteLine ("************************************");
					Console.WriteLine ("");
					SistemaDNS.imprimirDominiosSuperior ();
					Console.WriteLine ("Presione cualquier tecla para volver...");
					Console.ReadKey ();
				}
				if (opcion == 3) {
					Console.Clear ();
					Console.WriteLine ("************************************");
					Console.WriteLine ("**         BUSCAR DOMINIO         **");
					Console.WriteLine ("************************************");
					Console.WriteLine ("");
					Console.WriteLine ("Ingrese el nombre de dominio completo");
					string dominio = Console.ReadLine ();
					SistemaDNS.buscarDomino(dominio,"");
					Console.WriteLine ("Presione cualquier tecla para volver...");
					Console.ReadKey();
				}

				if (opcion == 4) {
					Console.Clear ();
					Console.WriteLine ("************************************");
					Console.WriteLine ("**   BUSCAR EQUIPOS DE  DOMINIO   **");
					Console.WriteLine ("************************************");
					Console.WriteLine ("");
					Console.WriteLine ("Ingrese el nombre del subdominio");
					string subdominio = Console.ReadLine ();
					Console.WriteLine ("Presione cualquier tecla para volver...");
					Console.ReadKey();

				}

				if (opcion == 6) {
					Console.Clear ();
					Console.WriteLine ("************************************");
					Console.WriteLine ("**               TEST             **");
					Console.WriteLine ("************************************");
					Console.WriteLine ("");

					utilidad.testArbol (SistemaDNS);
					Console.WriteLine ("Presione cualquier tecla para volver...");
					Console.ReadKey();
				}
				Console.Clear ();
				Console.WriteLine ("************************************");
				Console.WriteLine ("**           SISTEMA DNS          **");
				Console.WriteLine ("************************************");
				Console.WriteLine ("");
				Console.WriteLine ("1. Ingresar dominio");
				Console.WriteLine ("2. Ver listado de dominios superiores");
				Console.WriteLine ("3. Ver Datos de equipo");
				Console.WriteLine ("4. Ver Equipos de un subdominio");

				Console.WriteLine ("6. Test");
				Console.WriteLine ("7. Salir");

				 op = Console.ReadLine ();
				 opcion = int.Parse (op);
			
			
			}



		}
	}
}
