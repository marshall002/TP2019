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


                //return @"data source=ALE\SQLEXPRESS; initial catalog=BD_SCLAP; integrated security=SSPI;";
                //return @"data source=LACING202A-06; initial catalog=BD_SCLAP; integrated security=SSPI;";
                //return @"data source=LACING202A-06; initial catalog=BD_SCLAP; integrated security=SSPI;";

                //return @"data source=LAPTOP-TG82GILV; initial catalog=BD_SCLAP; integrated security=SSPI;";
                return @"data source=LAPTOP-UEI1JFVM; initial catalog=BD_SGCLAP; integrated security=SSPI;";

                //return @"data source=LACING202A-03; initial catalog=BD_SCLAP; integrated security=SSPI;";
                //return @"data source=LAPTOP-TG82GILV; initial catalog=BD_SCLAP; integrated security=SSPI;";


            }
        }
    }
}
