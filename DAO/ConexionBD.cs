﻿using System;
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
                return @"data source=DEVELOPER; initial catalog=BD_SCLAP; integrated security=SSPI;";

                //return @"data source=LAPTOP-TG82GILV; initial catalog=BD_SCLAP; integrated security=SSPI;";
                //return @"data Source=DEVELOPER;Initial Catalog=DB_SCLAP;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=True;";

            }
        }
    }
}
