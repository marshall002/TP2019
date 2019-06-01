using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAO
{
    public class DaoTipo_Ejercicio
    {
        SqlConnection conexion;
        public DaoTipo_Ejercicio()
        {
            conexion = new SqlConnection(ConexionBD.CadenaConexion);
        }

        public DataTable CDatosTEJercicios()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_CargarTEjercicio", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                return dt;
            }
            catch
            {
                return null;
            }
        }
    }
}
