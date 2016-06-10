using System;
using System.Collections;

namespace SistemaDNS
{
	public class NodoGeneral
	{
		public ArrayList listaHijos;
		object dato;

		public NodoGeneral (object dato)
		{
			this.dato = dato;
		}

		public object getDato(){
			return this.dato;
		}

		public void setDato(object elem){
			this.dato = elem;
		}

		public ArrayList getHijos(){
			return this.listaHijos;
		}

		public void setHijos(ArrayList hijos){
			this.listaHijos = hijos;
		}
	}
}

