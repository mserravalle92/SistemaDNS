using System;

namespace SistemaDNS
{
	public class Equipo:DominioBase
	{
		string ip;
		string servicios;

		public Equipo (string etiqueta):base(etiqueta)
		{
		}

		public void setIP(string ip)
		{
			this.ip = ip;
		}

		public string getIP()
		{
			return this.ip;
		}

		public void setServicios(string servicios)
		{
			this.servicios = servicios;
		}

		public string getServicios()
		{
			return this.servicios;
		}


	}
}

