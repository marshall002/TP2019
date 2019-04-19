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
	public class DaoCita
	{
		SqlConnection conexion;
		public DaoCita()
		{
			conexion = new SqlConnection(ConexionBD.CadenaConexion);
		}
		//public void RegistrarCita(DtoCita cita)
		//{
		//	SqlCommand command = new SqlCommand("sp_insertCita", conexion);
		//	command.CommandType = CommandType.StoredProcedure;
		//	command.Parameters.AddWithValue("@CodigoCita", cita.nombre);
		//	command.Parameters.AddWithValue("@FechaHoraSolicitadaCita", cita.tipo_programa);
		//	command.Parameters.AddWithValue("@ObservacionCita", cita.turno);
		//	command.Parameters.AddWithValue("@FechaHoraCreadaCita", cita.capacidad);
		//	command.Parameters.AddWithValue("@CodigoEstadoCita", cita.fechaInicio);
		//	command.Parameters.AddWithValue("@CodigoTipoCita", cita.fechaFin);
		//	command.Parameters.AddWithValue("@CodigoUsuarioDNI", cita.estado);
		//	conexion.Open();
		//	command.ExecuteNonQuery();
		//	conexion.Close();

			
		//}
		public DataTable VerCitasSolicitada(int idEstadoCita, string CodigoUsuario)
		{
			DataTable dtDatos = null;
			conexion.Open();
			SqlCommand command = new SqlCommand("sp_ListarSolicitudesCita", conexion);
			command.Parameters.AddWithValue("@CodigoEstadoCita", idEstadoCita);
			command.Parameters.AddWithValue("@CodigoUsuarioDNI", CodigoUsuario);

			SqlDataAdapter daAdaptador = new SqlDataAdapter(command);
			command.CommandType = CommandType.StoredProcedure;
			dtDatos = new DataTable();
			daAdaptador.Fill(dtDatos);
			conexion.Close();
			return dtDatos;
		}
	}
}
