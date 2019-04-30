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
		public void RegistrarSolCita(DateTime fechahorasolicitada, string observacioncita, DateTime fechahoracreada, int Id_EstadoCita, int id_TipoCita, string DniUsuario)
		{
			SqlCommand command = new SqlCommand("sp_RegistrarSolicitudCita", conexion);
			command.CommandType = CommandType.StoredProcedure;
			//command.Parameters.AddWithValue("@CodigoCita", cita.IC_Cod);
			command.Parameters.AddWithValue("@FechaHoraSolicitadaCita", fechahorasolicitada);
			command.Parameters.AddWithValue("@ObservacionCita", observacioncita);
			command.Parameters.AddWithValue("@FechaHoraCreadaCita", fechahoracreada);
			command.Parameters.AddWithValue("@CodigoEstadoCita", Id_EstadoCita);
			command.Parameters.AddWithValue("@CodigoTipoCita", id_TipoCita);
			command.Parameters.AddWithValue("@CodigoUsuarioDNI", DniUsuario);
			conexion.Open();
			command.ExecuteNonQuery();
			conexion.Close();
		}
		public void ActualizarSolCita(int codigoCita, DateTime FechaHoraSolicitada, string ObservacionDuda, int codigoTipoCita)
		{
			SqlCommand command = new SqlCommand("sp_ActualizarSolicitudCita", conexion);
			command.CommandType = CommandType.StoredProcedure;
			command.Parameters.AddWithValue("@CodigoCita", codigoCita);
			command.Parameters.AddWithValue("@FechaHoraSolicitadaCita", FechaHoraSolicitada);
			command.Parameters.AddWithValue("@ObservacionCita", ObservacionDuda);
			command.Parameters.AddWithValue("@CodigoTipoCita", codigoTipoCita);
			conexion.Open();
			command.ExecuteNonQuery();
			conexion.Close();
		}
		public DataTable VerCitasSolicitada(string CodigoUsuario)
		{
			DataTable dtDatos = null;
			conexion.Open();
			SqlCommand command = new SqlCommand("sp_ListarSolicitudesCita", conexion);
			command.Parameters.AddWithValue("@CodigoUsuarioDNI", CodigoUsuario);
			SqlDataAdapter daAdaptador = new SqlDataAdapter(command);
			command.CommandType = CommandType.StoredProcedure;
			dtDatos = new DataTable();
			daAdaptador.Fill(dtDatos);
			conexion.Close();
			return dtDatos;
		}
		public DataTable VerCitasSolicitudesAdmin()
		{
			DataTable dtDatos = null;
			conexion.Open();
			SqlCommand command = new SqlCommand("sp_ListarSolicitudesCitaAdmin", conexion);
			SqlDataAdapter daAdaptador = new SqlDataAdapter(command);
			command.CommandType = CommandType.StoredProcedure;
			dtDatos = new DataTable();
			daAdaptador.Fill(dtDatos);
			conexion.Close();
			return dtDatos;
		}
		public void EliminarSolCita(int codigoCita, int EstadoTipoCita)
		{
			SqlCommand command = new SqlCommand("sp_EliminarSolicitudCita", conexion);
			command.CommandType = CommandType.StoredProcedure;
			command.Parameters.AddWithValue("@CodigoCita", codigoCita);
			command.Parameters.AddWithValue("@CodigoEstadoCita", EstadoTipoCita);

			conexion.Open();
			command.ExecuteNonQuery();
			conexion.Close();
		}

		public void ObtenerSolCita(DtoCita cita)
		{
			SqlCommand cmd = new SqlCommand("sp_ObtenerSolicitudCita", conexion);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@codigoCita", cita.IC_Cod);
			DataSet ds = new DataSet();
			conexion.Open();
			SqlDataAdapter da = new SqlDataAdapter(cmd);
			da.Fill(ds);
			da.Dispose();

			SqlDataReader reader = cmd.ExecuteReader();

			while (reader.Read())
			{

				cita.IC_Cod = int.Parse(reader[0].ToString());
				cita.DC_FechaHoraSolicitada = Convert.ToDateTime(reader[1].ToString());
				cita.VC_Observacion = reader[2].ToString();
				cita.FK_IEC_Cod = Convert.ToInt32(reader[3].ToString());
				cita.FK_ITC_Cod = Convert.ToInt32(reader[4].ToString());
				cita.DC_FechaHoraCreada = Convert.ToDateTime(reader[5].ToString());
				cita.FK_CU_DNI = reader[6].ToString();
			}

			conexion.Close();
			conexion.Dispose();
		}
	}
}
