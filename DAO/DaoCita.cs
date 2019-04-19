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
		public void RegistrarSolCita(DtoCita cita)
		{
			SqlCommand command = new SqlCommand("sp_insertCita", conexion);
			command.CommandType = CommandType.StoredProcedure;
			command.Parameters.AddWithValue("@CodigoCita", cita.IC_Cod);
			command.Parameters.AddWithValue("@FechaHoraSolicitadaCita", cita.DC_FechaHoraSolicitada);
			command.Parameters.AddWithValue("@ObservacionCita", cita.VC_Observacion);
			command.Parameters.AddWithValue("@FechaHoraCreadaCita", cita.DC_FechaHoraCreada);
			command.Parameters.AddWithValue("@CodigoEstadoCita", cita.FK_IEC_Cod);
			command.Parameters.AddWithValue("@CodigoTipoCita", cita.FK_ITC_Cod);
			command.Parameters.AddWithValue("@CodigoUsuarioDNI", cita.FK_CU_DNI);
			conexion.Open();
			command.ExecuteNonQuery();
			conexion.Close();
		}
		//public void RegistrarCita(int codigoCita, DateTime FechaHoraSolicitada, string ObservacionDuda, DateTime FechaHoraCreada, int codigoEstadoCita, int codigoTipoCita, int codigoUsuarioDni)
		//{
		//	SqlCommand command = new SqlCommand("sp_insertCita", conexion);
		//	command.CommandType = CommandType.StoredProcedure;
		//	command.Parameters.AddWithValue("@CodigoCita", codigoCita);
		//	command.Parameters.AddWithValue("@FechaHoraSolicitadaCita", FechaHoraSolicitada);
		//	command.Parameters.AddWithValue("@ObservacionCita", ObservacionDuda);
		//	command.Parameters.AddWithValue("@FechaHoraCreadaCita", FechaHoraCreada);
		//	command.Parameters.AddWithValue("@CodigoEstadoCita", codigoEstadoCita);
		//	command.Parameters.AddWithValue("@CodigoTipoCita", codigoTipoCita);
		//	command.Parameters.AddWithValue("@CodigoUsuarioDNI", codigoUsuarioDni);
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
