using System;
using System.Collections;

namespace SistemaDNS
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Utils util = new Utils ();
			ArrayList listado = util.dividirDominio ("mariano.sistemas.unaj");
			foreach (string dom in listado) {
				Console.WriteLine (dom);
			}
		}
	}
}
