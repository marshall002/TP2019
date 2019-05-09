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
				return @"data source=DESKTOP-4DLDR9D\SQLEXPRESS; initial catalog=BD_SLAP1; integrated security=SSPI;";
			}
            //mira estrella sincronizo :v 
		}
	}
}
