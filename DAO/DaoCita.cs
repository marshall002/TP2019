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
        public void RegistrarSolCita(DtoCita ObjDtoCita)
        {
            SqlCommand command = new SqlCommand("sp_RegistrarSolicitudCita", conexion);
            command.CommandType = CommandType.StoredProcedure;
            //command.Parameters.AddWithValue("@CodigoCita", cita.IC_Cod);
            command.Parameters.AddWithValue("@FechaHoraSolicitadaCita", ObjDtoCita.DC_FechaHoraSolicitada);
            command.Parameters.AddWithValue("@ObservacionCita", ObjDtoCita.VC_Observacion);
            command.Parameters.AddWithValue("@CodigoEstadoCita", ObjDtoCita.FK_IEC_Cod);
            command.Parameters.AddWithValue("@CodigoTipoCita", ObjDtoCita.FK_ITC_Cod);
            command.Parameters.AddWithValue("@CodigoUsuarioDNI", ObjDtoCita.FK_CU_DNI);
            conexion.Open();
            command.ExecuteNonQuery();
            conexion.Close();
        }
        public void RegistrarCita(DtoCita ObjDtoCita)
        {
            SqlCommand command = new SqlCommand("sp_RegistrarSolicitudCita", conexion);
            command.CommandType = CommandType.StoredProcedure;
            //command.Parameters.AddWithValue("@CodigoCita", cita.IC_Cod);
            command.Parameters.AddWithValue("@FechaHoraSolicitadaCita", ObjDtoCita.DC_FechaHoraSolicitada);
            command.Parameters.AddWithValue("@ObservacionCita", ObjDtoCita.VC_Observacion);
            command.Parameters.AddWithValue("@CodigoEstadoCita", ObjDtoCita.FK_IEC_Cod);
            command.Parameters.AddWithValue("@CodigoTipoCita", ObjDtoCita.FK_ITC_Cod);
            command.Parameters.AddWithValue("@CodigoUsuarioDNI", ObjDtoCita.FK_CU_DNI);
            conexion.Open();
            command.ExecuteNonQuery();
            conexion.Close();
        }
        public DataTable VerCitasNutri()
        {
            DataTable dtDatos = null;
            conexion.Open();
            SqlCommand command = new SqlCommand("sp_ListarCitaNutri", conexion);
            SqlDataAdapter daAdaptador = new SqlDataAdapter(command);
            command.CommandType = CommandType.StoredProcedure;
            dtDatos = new DataTable();
            daAdaptador.Fill(dtDatos);
            conexion.Close();
            return dtDatos;
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
                cita.FK_IEC_Nombre = reader[6].ToString();
                cita.FK_CU_DNI = reader[7].ToString();

                if (reader[9] != DBNull.Value)
                {
                    cita.DC_FechaReprogramada = Convert.ToDateTime(reader[9].ToString());
                }
                else
                {
                    cita.DC_FechaReprogramada = Convert.ToDateTime(reader[5].ToString());
                }


            }

            conexion.Close();
            conexion.Dispose();
        }
        public void ProReprogramarCita(int codigoCita, DateTime FechaReprogramada)
        {
            conexion.Open();
            SqlCommand command = new SqlCommand("sp_Reprogramar_Cita", conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@idCita", codigoCita);
            command.Parameters.AddWithValue("@FechaHoraReproCita", FechaReprogramada);
            command.ExecuteNonQuery();
            conexion.Close();
        }
        public void EvalReprogramarCita(DtoCita objdtoCita)
        {
            conexion.Open();
            SqlCommand command = new SqlCommand("sp_Evaluar_Cita_Repro", conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@idCita", objdtoCita.IC_Cod);
            command.Parameters.AddWithValue("@FK_IEC_Cod", objdtoCita.FK_IEC_Cod);
            command.ExecuteNonQuery();
            conexion.Close();
        }
        public void ActualizarSolCitaAdmin(DtoCita objdtocita)
        {
            SqlCommand command = new SqlCommand("sp_ActualizarSolicitudCitaAdmin", conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@CodigoCita", objdtocita.IC_Cod);
            command.Parameters.AddWithValue("@IdEstadoCita", objdtocita.FK_IEC_Cod);

            conexion.Open();
            command.ExecuteNonQuery();
            conexion.Close();
        }

        public bool ExisteCitaFecha(string fechahora,string dni)
        {
            int valor_retornado = 0;
            string query = "SELECT COUNT (*) FROM T_Cita inner join T_Usuario on PK_CU_Dni = FK_CU_Dni WHERE DC_FechaHoraSolicitada='" + fechahora + "' and FK_CU_Dni='" + dni + "'";
            SqlCommand cmd = new SqlCommand(query, conexion);
            Console.WriteLine(cmd);
            conexion.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {    //valor_retornado = reader[0].ToString();
                valor_retornado = int.Parse(reader[0].ToString());

            }
            conexion.Close();

            if (valor_retornado == 0)
                return false;
            else
                return true;
        }

    }
}
