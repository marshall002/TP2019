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
    public class DaoEjercicio
    {
        SqlConnection conexion;
        public DaoEjercicio()
        {
            conexion = new SqlConnection(ConexionBD.CadenaConexion);
        }

        public DataTable CDatosEJercicios()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_CargarEjercicio", conexion);
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
        public DataTable CDatosEJerciciosXT(int TejeId)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_CargarEjercicioxT", conexion);
                cmd.Parameters.AddWithValue("@tejercicio", TejeId);
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
