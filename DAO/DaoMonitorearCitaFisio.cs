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
            //conexion.Open();
            SqlCommand command = new SqlCommand("SP_ListarMonitorearCitaFisio", conexion);
            SqlDataAdapter Adaptador = new SqlDataAdapter(command);
            command.CommandType = CommandType.StoredProcedure;
            dtDatos = new DataTable();
            Adaptador.Fill(dtDatos);
            conexion.Close();
            return dtDatos;
        }

        public DtoCita obtenerDatosCita(DtoCita dtoCita)
        {
            //conexion.Open();
            SqlCommand cmd = new SqlCommand("sp_obtenerDetalleCita", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@codigoCita", dtoCita.IC_Cod); //agrega un valor a la coleccion
            //Dataset : prepara una cache en memoria
            DataSet ds = new DataSet();
            conexion.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            da.Dispose();

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                dtoCita.IC_Cod = int.Parse(reader[0].ToString());
                dtoCita.DC_FechaHoraSolicitada = Convert.ToDateTime(reader[1].ToString());
                dtoCita.VC_Observacion = reader[2].ToString();
                dtoCita.FK_ITC_Cod = Convert.ToInt32(reader[3].ToString());
                dtoCita.VTC_Nombre = reader[4].ToString();
                dtoCita.FK_IEC_Cod = Convert.ToInt32(reader[5].ToString());
                dtoCita.FK_IEC_Nombre = reader[6].ToString();
                dtoCita.FK_CU_DNI = reader[7].ToString();
            }

            conexion.Close();
            conexion.Dispose();


            return dtoCita;

        }

        public void ActualizarEstadoCita(int codigoCita, int codigoEstadoCita)
        {
            SqlCommand command = new SqlCommand("sp_cambiarEstadoCita", conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@FK_IEC_Cod", codigoEstadoCita);
            command.Parameters.AddWithValue("@PK_IC_Cod", codigoCita);
            conexion.Open();
            command.ExecuteNonQuery();
            conexion.Close();
        }
    }
}
