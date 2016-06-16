using System;
using System.Collections;


namespace SistemaDNS
{
	public class Utils
	{
		public Utils ()
		{
		}

		public ArrayList dividirDominio(string dominio){
			char delim = '.';

			string[] doms = dominio.Split (delim);

			ArrayList dominioSeparado = new ArrayList ();

			for (int i = doms.Length-1; i >= 0; i--) {
				dominioSeparado.Add (doms [i]);
			}

			return dominioSeparado;
		}

		public string invertirDominio(string dominio){

			string[] separado = dominio.Split('.');
			string dominioInvertido="";

			for (int i=separado.Length-1; i >= 0; i-- ) {
				if (i != 0) {
					if (separado [i] != "") {
						dominioInvertido += separado [i] + ".";
					}
				
				} else {
					dominioInvertido += separado [i];

				}
			}

			return dominioInvertido;
		}

		public void testArbol(ArbolGeneral arbol){

			ArrayList listaHijos = arbol.getHijos ();
			DominioBase datoRaiz = (DominioBase)arbol.getDatoRaiz ();
			Console.WriteLine (datoRaiz.getEtiqueta ());

			if (listaHijos != null) {
				foreach (ArbolGeneral arbolHijo in listaHijos) {
					testArbol (arbolHijo);
				}
			}

		}

		public void precargaDominios(DNS dns){
			
			string dominio1 = "mail.google.com";
			string ip1 = "192.168.110.5";
			string servicios1 = "mensajeria por SMTP";
			dns.cargarDominio (dominio1,ip1,servicios1);

			string dominio2 = "mariano.local.com";
			string ip2 = "192.168.1.1";
			string servicios2 = "servidor de archivos";
			dns.cargarDominio (dominio2,ip2,servicios2);

			string dominio3 = "matias.local.com";
			string ip3 = "192.168.1.2";
			string servicios3 = "servidor de archivos";
			dns.cargarDominio (dominio3,ip3,servicios3);

			string dominio4 = "router.cisco.argentina.ar";
			string ip4 = "172.248.1.1";
			string servicios4 = "traduccion de IP";
			dns.cargarDominio (dominio4,ip4,servicios4);
			
		}

	}
}

