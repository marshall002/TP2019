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
<<<<<<< HEAD
                return @"data source=DESKTOP-UH5SKAR\LENOVOPC; initial catalog=BD_SCLAP; integrated security=SSPI;";
=======
                return @"data source=LACING202A-06; initial catalog=BD_SCLAP; integrated security=SSPI;";
>>>>>>> d767c26b0ab89324a1da59976427e705925a619b

                //return @"data source=LAPTOP-TG82GILV; initial catalog=BD_SCLAP; integrated security=SSPI;";
                //return @"data Source=DEVELOPER;Initial Catalog=DB_SCLAP;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=True;";

            }
        }
    }
}
