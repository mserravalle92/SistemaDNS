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
	}
}

