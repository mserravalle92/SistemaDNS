using System;
using System.Collections;

namespace SistemaDNS
{
	public class DNS:ArbolGeneral
	{

		public DNS (NodoGeneral raiz):base(raiz)
		{
		}



		public void agregarDominio(Dominio dominio,ArbolGeneral arbol){

			
			ArrayList listaHijos = arbol.getHijos();	
			bool existe = false;

			foreach(NodoGeneral nodo in listaHijos){
				DominioBase dominioBase = (DominioBase)nodo.getDato ();
				if (dominioBase.getEtiqueta () == dominio.getEtiqueta ()) {
					existe = true;
				}
			}
				
			if (existe == false) {
				NodoGeneral dom = new NodoGeneral (dominio);
				arbol.agregarHijo (dom);
			}
		}

		public void agregarEquipo (Equipo equipo, string padre){

			NodoGeneral raizActual = this.raiz;
			ArrayList listaHijos = raizActual.getHijos ();

			foreach (ArbolGeneral arbol in listaHijos) {
				DominioBase datoRaiz = (DominioBase)arbol.getDatoRaiz ();
				if (datoRaiz.getEtiqueta () == padre) {
					arbol.agregarHijo (new NodoGeneral (equipo));
				} else {
					agregarEquipo (equipo, padre);
				}
			}

		}

		public void agregarDominioSuperior(string dominio){

			Dominio dominioSup = new Dominio(dominio);
			dominioSup.setTipo ("Superior");

			NodoGeneral nodo = new NodoGeneral (dominioSup);

			this.agregarHijo (nodo);
		}

		public void cargarDominio(string dominio){

			Utils util = new Utils ();

			ArrayList dominioDividido = util.dividirDominio (dominio);

			string etiquetaEquipo = (string)dominioDividido[dominioDividido.Count - 1];
			string padreEquipo = (string)dominioDividido[dominioDividido.Count - 2];
			string etiquetaDomSup = (string)dominioDividido [0];

			Equipo equipo = new Equipo (etiquetaEquipo);

			this.agregarEquipo (equipo, padreEquipo);

			dominioDividido.Remove (etiquetaEquipo);

			foreach (string dom in dominioDividido) {
				Dominio domi = new Dominio (dom);
				this.agregarDominio (domi, this);
			}
		}

	}
}



		


	


