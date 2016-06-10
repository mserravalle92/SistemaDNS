using System;
using System.Collections;

namespace SistemaDNS
{
	public class ArbolGeneral
	{
		public NodoGeneral raiz;

		public ArbolGeneral (NodoGeneral raiz)
		{
			this.raiz = raiz;
		}
			
			private NodoGeneral getRaiz(){
				return this.raiz;
			}

			private void setRaiz(NodoGeneral raiz){
				this.raiz = new NodoGeneral(raiz);
			}

			public Object getDatoRaiz(){
				return this.raiz.getDato();
			}

			public ArrayList getHijos(){
				return this.raiz.getHijos();
			}

			public void agregarHijo(NodoGeneral hijo){

				ArrayList lista = this.raiz.getHijos();

				if (lista == null) {
					lista =  new ArrayList();
				}
				ArbolGeneral nuevoHijo = new ArbolGeneral(hijo);
				lista.Add(nuevoHijo);

				this.raiz.setHijos(lista);

			}

			public void eliminarHijo(NodoGeneral hijo){

				ArrayList listaHijos = this.raiz.getHijos();
				foreach (ArbolGeneral arbol in listaHijos) {
					if (arbol.getDatoRaiz()==hijo) {
					this.raiz.listaHijos.Remove(hijo);
					}
				}

			}
		}


	
	}


