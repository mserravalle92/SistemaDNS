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
						Dominio dom = (Dominio)hijo.getDatoRaiz ();
						if (dom.getEtiqueta() == dominio.getEtiqueta ()) {
							existe = true;
						}
					}

				}

				if (existe == false) {
					dominio.setTipo ("Subdominio");
					NodoGeneral nodoHijo = new NodoGeneral (dominio);
					arbol.agregarHijo (nodoHijo);
					existe = true;
				}
			} else {
				ArrayList listaHijos = arbol.getHijos ();
				foreach (ArbolGeneral hijo in listaHijos) {
					agregarDominio (dominio, hijo, padre);
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

		public void cargarDominio(string dominio){

			Utils util = new Utils ();

			ArrayList dominioDividido = util.dividirDominio (dominio);

			string etiquetaEquipo = (string)dominioDividido[dominioDividido.Count - 1];
			string padreEquipo = (string)dominioDividido[dominioDividido.Count - 2];
			string etiquetaDomSup = (string)dominioDividido [0];

			Equipo equipo = new Equipo (etiquetaEquipo);
			dominioDividido.Remove (etiquetaEquipo);

			this.agregarDominioSuperior (etiquetaDomSup,this);
			dominioDividido.Remove (etiquetaDomSup);

			foreach (string dom in dominioDividido) {
				Dominio domi = new Dominio (dom);
				this.agregarDominio (domi,this,etiquetaDomSup);
			}

			this.agregarEquipo (equipo,this,padreEquipo);

		}

	}
}



		


	


