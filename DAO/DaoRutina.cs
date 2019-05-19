using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using DTO;

namespace DAO
{
    public class DaoRutina
    {
        SqlConnection conexion;
        public DaoRutina()
        {
            conexion = new SqlConnection(ConexionBD.CadenaConexion);
        }

        public DataTable VerRutina(string CodigoTipoRutina)
		{
			DataTable dtDatos = null;
			conexion.Open();
			SqlCommand command = new SqlCommand("sp_ListarRutina", conexion);
			command.Parameters.AddWithValue("@CodigoTipoRutina", CodigoTipoRutina);
			SqlDataAdapter daAdaptador = new SqlDataAdapter(command);
			command.CommandType = CommandType.StoredProcedure;
			dtDatos = new DataTable();
			daAdaptador.Fill(dtDatos);
			conexion.Close();
			return dtDatos;
		}

        public void RegistrarRutina(DateTime fechaHoraInicio, DateTime fechaHoraFin)
        {
            SqlCommand command = new SqlCommand("sp_RegistrarRutina", conexion);
            command.CommandType = CommandType.StoredProcedure;
            //command.Parameters.AddWithValue("@CodigoCita", cita.IC_Cod);
            command.Parameters.AddWithValue("@FechaHoraInicio", fechaHoraInicio);
            command.Parameters.AddWithValue("@FechaHoraFin", fechaHoraFin);
            conexion.Open();
            command.ExecuteNonQuery();
            conexion.Close();
        }
        public void RegistrarEjercicio(String nombre, Double duracion, String observacion)
        {
            SqlCommand command = new SqlCommand("sp_RegistrarEjercicio", conexion);
            command.CommandType = CommandType.StoredProcedure;
            //command.Parameters.AddWithValue("@CodigoCita", cita.IC_Cod);
            command.Parameters.AddWithValue("@nombreEjercicio", nombre);
            command.Parameters.AddWithValue("@duracionEjercicio", duracion);
            command.Parameters.AddWithValue("@observacionEjercicio", observacion);
            conexion.Open();
            command.ExecuteNonQuery();
            conexion.Close();
        }
    }
}
