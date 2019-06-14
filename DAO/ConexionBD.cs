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
<<<<<<< Updated upstream

                return @"data source=LACING202A-09; initial catalog=BD_SCLAP; integrated security=SSPI;";

                //return @"data source=LACING202A-06; initial catalog=BD_SCLAP; integrated security=SSPI;";

=======
                //return @"data source=DESKTOP-UH5SKAR\LENOVOPC; initial catalog=BD_SCLAP; integrated security=SSPI;";
                return @"data source=LACING202A-03; initial catalog=BD_SCLAP; integrated security=SSPI;";
>>>>>>> Stashed changes

                //return @"data source=LAPTOP-TG82GILV; initial catalog=BD_SCLAP; integrated security=SSPI;";
                //return @"data Source=DEVELOPER;Initial Catalog=DB_SCLAP;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=True;";

            }
        }
    }
}
