using System;

namespace SistemaDNS
{
	public class DominioBase
	{
		string etiqueta;
		string tipo;

		public DominioBase (string etiqueta)
		{
			this.etiqueta = etiqueta;
		}

		public string getEtiqueta(){
			return this.etiqueta;
		}

		public void setTipo(string tipo)
		{
			this.tipo = tipo;
		}

		public string getTipo()
		{
			return this.tipo;
		}
		
	}
}

