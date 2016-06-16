using System;
using System.Collections;

namespace SistemaDNS
{
	public class DNS:ArbolGeneral
	{

		public DNS (NodoGeneral raiz):base(raiz)
		{
		}

		public void agregarDominio(Dominio dominio,ArbolGeneral arbol,string padre){


			NodoGeneral nodoRaiz = arbol.raiz;
			DominioBase dominioActual = (DominioBase)nodoRaiz.getDato ();
			bool existe = false;

			if (dominioActual.getEtiqueta () == padre) {

				if (arbol.getHijos () != null) {
					ArrayList listaHijos = arbol.getHijos ();

					foreach(ArbolGeneral hijo in listaHijos){
						DominioBase dom = (DominioBase)hijo.getDatoRaiz ();
						if (dom.getEtiqueta() == dominio.getEtiqueta ()) {
							existe = true;
						}
					}

				}

				if (existe == false) {
					dominio.setTipo ("Subdominio");
					NodoGeneral nodoHijo = new NodoGeneral (dominio);
					arbol.agregarHijo (nodoHijo);
				}
			} else {
				if (arbol.getHijos () != null) {
					ArrayList listaHijos = arbol.getHijos ();
					foreach (ArbolGeneral hijo in listaHijos) {
						agregarDominio (dominio, hijo, padre);
					}
				}
					
			}

		}

		public void agregarEquipo (Equipo equipo,ArbolGeneral arbol, string padre){

			NodoGeneral raizActual = arbol.raiz;
			DominioBase dominioBase = (DominioBase)raizActual.getDato ();
	
			if (dominioBase.getEtiqueta() == padre) {
				arbol.agregarHijo (new NodoGeneral (equipo));
			} else {
				if (arbol.getHijos () != null) {
					ArrayList listaHijos = arbol.getHijos ();
					foreach (ArbolGeneral arbolHijo in listaHijos) {
						agregarEquipo (equipo, arbolHijo, padre);
					}
				}

			}
		}



		public void agregarDominioSuperior(string dominio,ArbolGeneral arbol){

			Dominio dominioSup = new Dominio(dominio);
			dominioSup.setTipo ("Superior");

			NodoGeneral nodo = new NodoGeneral (dominioSup);
			bool existe = false;

			if (arbol.getHijos () != null) {
				ArrayList listaHijos = arbol.getHijos ();
				foreach(ArbolGeneral arbolHijo in listaHijos){
					DominioBase dom = (DominioBase)arbolHijo.getDatoRaiz ();
					if (dom.getEtiqueta () == dominio) {
						existe = true;
					}
				}
			}

			if (existe == false) {
				this.agregarHijo (nodo);
			}
		}

		public void cargarDominio(string dominio,string ip,string servicios){

			Utils util = new Utils ();

			ArrayList dominioDividido = util.dividirDominio (dominio);

			string etiquetaEquipo = (string)dominioDividido[dominioDividido.Count - 1];

			string padreEquipo = (string)dominioDividido[dominioDividido.Count - 2];
			string etiquetaDomSup = (string)dominioDividido [0];

			Equipo equipo = new Equipo (etiquetaEquipo);
			equipo.setTipo ("Equipo");
			equipo.setIP (ip);
			equipo.setServicios (servicios);
			dominioDividido.Remove (etiquetaEquipo);

			this.agregarDominioSuperior (etiquetaDomSup,this);

			for (int i = 1 ;i<=dominioDividido.Count-1;i++) {
				string padre = (string)dominioDividido [i-1];
				string dom = (string)dominioDividido [i];
				Dominio domi = new Dominio (dom);
				this.agregarDominio (domi,this,padre);

			}

			this.agregarEquipo (equipo,this,padreEquipo);

		}

		public void imprimirDominiosSuperior(){
		
			NodoGeneral raiz = this.raiz;
			DominioBase dominio = (DominioBase)raiz.getDato ();

			if (dominio.getTipo () == "Superior") {
				Console.WriteLine (dominio.getEtiqueta ());
			} else {
				if(raiz.getHijos()!=null){
					ArrayList listaHijos = raiz.getHijos();
					foreach(ArbolGeneral arbol in listaHijos){
						DNS dns = new DNS (arbol.raiz);
						dns.imprimirDominiosSuperior ();
					}

				}
			}
		}

		public void buscarDomino(string dominio,string dominioActual){
			Utils util = new Utils ();

			NodoGeneral raiz = this.raiz;
			DominioBase domActual = (DominioBase)raiz.getDato ();

			dominioActual += domActual.getEtiqueta () + ".";
			string dom = dominio+'.';
			string domInv = util.invertirDominio (dominioActual);
			if (dom == domInv) {
				if (domActual.getTipo () == "Equipo") {
					Equipo equipo = (Equipo)domActual;
					Console.WriteLine ("Etiqueta: "+equipo.getEtiqueta ());
					Console.WriteLine ("IP: "+equipo.getIP ());
					Console.WriteLine ("Servicios: "+equipo.getServicios ());

				}
			} else {
				if (raiz.getHijos () != null) {
					ArrayList listaHijos = raiz.getHijos ();
					foreach (ArbolGeneral arbol in listaHijos) {
						DNS dns = new DNS (arbol.raiz);
						dns.buscarDomino (dominio, dominioActual);
					}
				}
				
			}

		}

		public void equiposDeDominio(string dominio){

			NodoGeneral raiz = this.raiz;
			DominioBase dom = (DominioBase)this.getDatoRaiz ();

			if (dom.getEtiqueta () == dominio) {
				mostrarEquipos (this);
			}
			 else {
				ArrayList listaHijos = raiz.getHijos ();
				foreach (ArbolGeneral hijo in listaHijos) {
					DNS dns = new DNS (hijo.raiz);
					dns.equiposDeDominio (dominio);
				}
			}
		}

		public void mostrarEquipos(ArbolGeneral arbol){
			if (arbol.getHijos () != null) {
				ArrayList listaHijos = arbol.getHijos ();
				foreach (ArbolGeneral hijo in listaHijos) {
					DominioBase equipo = (DominioBase)hijo.getDatoRaiz ();
					if (equipo.getTipo() == "Equipo") {
						Console.WriteLine (equipo.getEtiqueta ());
					} else {
						DNS dns = new DNS (hijo.raiz);
						dns.mostrarEquipos (hijo);

					}
				}
			}

		}

		public void eliminarEquipo (string nombreEquipo){

			NodoGeneral raiz = this.raiz;
			if (raiz.getHijos () != null) {
				ArrayList listaHijos = raiz.getHijos ();


				foreach (ArbolGeneral arbol in listaHijos) {
					NodoGeneral raizHijo = arbol.raiz;
					DominioBase dominioBase = (DominioBase)raizHijo.getDato ();

					if (dominioBase.getEtiqueta() == nombreEquipo) {
						if (dominioBase.getTipo() == "Equipo") {
							this.eliminarHijo (raizHijo);
							break;
						}
					} else {
						DNS dns = new DNS (arbol.raiz);
						dns.eliminarEquipo (nombreEquipo);
					}
				}

				this.eliminarSubdominioHoja ();
			}


		}

		public void eliminarSubdominioHoja(){
			NodoGeneral raiz = this.raiz;
			if (raiz.getHijos () != null) {

			ArrayList listaHijos = raiz.getHijos ();

				foreach (ArbolGeneral arbol in listaHijos) {
					NodoGeneral raizHijo = arbol.raiz;
					DominioBase dominioBase = (DominioBase)raizHijo.getDato ();
					if (raizHijo.getHijos () != null) {
						if (raizHijo.getHijos ().Count == 0) {
							if (dominioBase.getTipo () == "Subdominio") {
								this.eliminarHijo (raizHijo);
								break;
							}
						} else {
							DNS dns = new DNS (arbol.raiz);
							dns.eliminarSubdominioHoja ();
						}

					}
				}
			}
		}

		public void dominioEnProfundidad(int profundidad,int actual){

			int profundidadActual = actual;

			NodoGeneral raiz = this.raiz;
			DominioBase dominio = (DominioBase)raiz.getDato ();

			if (profundidad == profundidadActual) {
				Console.WriteLine (dominio.getEtiqueta ());
			} else {
				profundidadActual += 1;
				ArrayList listaHijos = raiz.getHijos ();
				foreach (ArbolGeneral arbol in listaHijos) {
					DNS dns = new DNS (arbol.raiz);
					dns.dominioEnProfundidad (profundidad, profundidadActual);
				}
			}
		
		}

	}
}



		


	


