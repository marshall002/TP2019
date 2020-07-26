using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data.SqlClient;
using System.Data;

namespace DAO
{
    public  class DaoContrato
    {
        SqlConnection conexion;
        public DaoContrato()
        {
            conexion = new SqlConnection(ConexionBD.CadenaConexion);
        }
        public void RegistrarContrato_PLANxSOCIO(DtoUsuario dtoUsuario, DtoContrato dtoContrato)
        {
            SqlCommand cmd = new SqlCommand("sp_RegistrarPlanxSocio", conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@PK_CU_Dni", dtoUsuario.PK_CU_Dni);
            cmd.Parameters.AddWithValue("@PK_IP_Cod", dtoContrato.FK_IP_Cod);
            cmd.Parameters.AddWithValue("@VC_Descripcion", dtoContrato.VC_DEscripcion);
            cmd.Parameters.AddWithValue("@DC_Fecha_Inicio", dtoContrato.DC_Fecha_Inicio);

            conexion.Open();
            cmd.ExecuteNonQuery();
            conexion.Close();
        }
        public DataTable ListarSolicitudesContratoxUsuarioxEstado(DtoUsuario dtoUsuario,DtoContrato dtoContrato)
        {
            DataTable dtSolicitudes = null;
            conexion.Open();
            SqlCommand command = new SqlCommand("sp_ListarSolicitudesContratoxUsuarioxEstado", conexion);
            command.Parameters.AddWithValue("@PK_IC_Dni", dtoUsuario.PK_CU_Dni);
            command.Parameters.AddWithValue("@FK_IEC_Cod", dtoContrato.FK_IEC_Cod);
            SqlDataAdapter daAdaptador = new SqlDataAdapter(command);
            command.CommandType = CommandType.StoredProcedure;
            dtSolicitudes = new DataTable();
            daAdaptador.Fill(dtSolicitudes);
            conexion.Close();
            return dtSolicitudes;
        }
        public DataTable ListarSolicitudesContratoxEstado(DtoContrato dtoContrato)
        {
            DataTable dtSolicitudes = null;
            conexion.Open();
            SqlCommand command = new SqlCommand("sp_ListarSolicitudesContratoxEstado", conexion);
            command.Parameters.AddWithValue("@FK_IEC_Cod", dtoContrato.FK_IEC_Cod);
            SqlDataAdapter daAdaptador = new SqlDataAdapter(command);
            command.CommandType = CommandType.StoredProcedure;
            dtSolicitudes = new DataTable();
            daAdaptador.Fill(dtSolicitudes);
            conexion.Close();
            return dtSolicitudes;
        }
        public void ActualizarContrato(DtoContrato dtoContrato)
        {
            SqlCommand command = new SqlCommand("sp_ActualizarEstadoContrato", conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@PK_IC_Cod", dtoContrato.PK_IC_Cod);
            command.Parameters.AddWithValue("@FK_IEC_Cod", dtoContrato.FK_IEC_Cod);
            conexion.Open();
            command.ExecuteNonQuery();
            conexion.Close();
        }
        public void RegistrarImgContratoImg(byte[] bytes, int id)
        {
            SqlCommand command = new SqlCommand("SP_Actualizar_Img_Contrato", conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@idMol", id);
            command.Parameters.AddWithValue("@imagen", bytes);
            conexion.Open();
            command.ExecuteNonQuery();
            conexion.Close();
        }
    }

}
