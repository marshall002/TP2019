using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class ConexionBD
    {
		public static string CadenaConexion
		{
			get
			{
				return "data source=MMASCO; initial catalog=BD_SGCLAP; integrated security=SSPI;";
			}
		}
	}
}
