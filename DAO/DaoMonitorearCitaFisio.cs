using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    public class DaoMonitorearCitaFisio
    {

        SqlConnection conexion;

        public DaoMonitorearCitaFisio()
        {
            conexion = new SqlConnection(ConexionBD.CadenaConexion);
        }

        public DataTable ListarMonitoriarCitaFisio()
        {
            DataTable dtDatos = null;
            conexion.Open();
            SqlCommand command = new SqlCommand("SP_ListarMonitorearCitaFisio", conexion);
            SqlDataAdapter daAdaptador = new SqlDataAdapter(command);
            command.CommandType = CommandType.StoredProcedure;
            dtDatos = new DataTable();
            daAdaptador.Fill(dtDatos);
            conexion.Close();


            return dtDatos;
        }
    }
}
