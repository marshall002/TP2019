using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class ConexionBD
    {
        public static string CadenaConexion
        {
            get
            {
                return @"data source=DESKTOP-IJNOKHP\SQLEXPRESS; initial catalog=BD_SCLAP; integrated security=SSPI;";
            }
        }
    }
}
