using DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    
    public class DaoCPago
    {
        SqlConnection conexion;
        public DaoCPago()
        {
            conexion = new SqlConnection(ConexionBD.CadenaConexion);
        }
        public DataTable VerCPagos()
        {
            DataTable dtDatos = null;
            conexion.Open();
            SqlCommand command = new SqlCommand("sp_ListarVPagos", conexion);
            SqlDataAdapter daAdaptador = new SqlDataAdapter(command);
            command.CommandType = CommandType.StoredProcedure;
            dtDatos = new DataTable();
            daAdaptador.Fill(dtDatos);
            conexion.Close();
            return dtDatos;
        }
    }
}
