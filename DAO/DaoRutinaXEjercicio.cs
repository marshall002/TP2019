using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DaoRutinaXEjercicio
    {
        SqlConnection conexion;
        public DaoRutinaXEjercicio()
        {
            conexion = new SqlConnection(ConexionBD.CadenaConexion);
        }
        public DataTable ListRutina(DateTime fechaRutina, int idRutina)
        {
            DataTable dtDatos = null;
            conexion.Open();
            SqlCommand command = new SqlCommand("sp_ListarRutinaFecha", conexion);
            command.Parameters.AddWithValue("@fecha", fechaRutina);
            command.Parameters.AddWithValue("@trutina", idRutina);
            SqlDataAdapter daAdaptador = new SqlDataAdapter(command);
            command.CommandType = CommandType.StoredProcedure;
            dtDatos = new DataTable();
            daAdaptador.Fill(dtDatos);
            conexion.Close();
            return dtDatos;
        }

        public void ActualizarRutina(int idRutXEjer, DateTime FechaRut, string Ejerci, string TEjercicio)
        {
            SqlCommand command = new SqlCommand("sp_ActualizarSolicitudCita", conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@codigoRutinaxEj", idRutXEjer);
            command.Parameters.AddWithValue("@fechaHoraRut", FechaRut);
            command.Parameters.AddWithValue("@ejercicio", Ejerci);
            command.Parameters.AddWithValue("@tejercicio", TEjercicio);
            conexion.Open();
            command.ExecuteNonQuery();
            conexion.Close();
        }
    }
}
