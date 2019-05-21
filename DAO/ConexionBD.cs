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
				return @"data source=LACING201B-19; initial catalog=BD_SCLAP; integrated security=SSPI;";
			}
		}
	}
}
