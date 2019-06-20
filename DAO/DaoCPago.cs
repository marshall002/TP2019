using DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace DAO
{
    
    public class DaoCPago
    {
        SqlConnection conexion;
        public DaoCPago()
        {
            conexion = new SqlConnection(ConexionBD.CadenaConexion);
        }
        public DataTable VerCPagos(string nombre)
        {
            DataTable dtDatos = null;
            conexion.Open();
            SqlCommand command = new SqlCommand("sp_ListarVPagos", conexion);
            command.Parameters.AddWithValue("@Nombre", nombre);
            SqlDataAdapter daAdaptador = new SqlDataAdapter(command);
            command.CommandType = CommandType.StoredProcedure;
            dtDatos = new DataTable();
            daAdaptador.Fill(dtDatos);
            conexion.Close();
            return dtDatos;
        }
        public DtoCPago VerComprobante(int idcomprobante)
        {
            DataTable dtDatos = null;
            conexion.Open();
            SqlCommand command = new SqlCommand("sp_ListarCPagos", conexion);
            command.Parameters.AddWithValue("@ID", idcomprobante);
            SqlDataAdapter daAdaptador = new SqlDataAdapter(command);
            command.CommandType = CommandType.StoredProcedure;
            dtDatos = new DataTable();
            daAdaptador.Fill(dtDatos);
            var model = new DtoCPago();
            var xd = dtDatos.Rows[0].ItemArray;
            var obj = xd[0];
            model.IMC_Imagen = Convert.ToBase64String(ObjectToByteArray(xd[0]));
            model.DCP_Monto = Convert.ToDouble(xd[1]);
            model.VCP_NOperacion = xd[2].ToString();
            conexion.Close();
            return model;
        }
        public DtoCPago VerCPago(int idcomprobante)
        {
            DataTable dtDatos = null;
            conexion.Open();
            SqlCommand command = new SqlCommand("sp_VerCPagos", conexion);
            command.Parameters.AddWithValue("@ID", idcomprobante);
            SqlDataAdapter daAdaptador = new SqlDataAdapter(command);
            command.CommandType = CommandType.StoredProcedure;
            dtDatos = new DataTable();
            daAdaptador.Fill(dtDatos);
            var model = new DtoCPago();
            var xd = dtDatos.Rows[0].ItemArray;
            var obj = xd[0];
            model.IMC_Imagen = Convert.ToBase64String(ObjectToByteArray(xd[0]));
            model.DCP_Monto = Convert.ToDouble(xd[1]);
            model.VCP_NOperacion = xd[2].ToString();
            model.ICP_NFisio= Convert.ToInt32(xd[3].ToString());
            model.ICP_NNutri= Convert.ToInt32(xd[4].ToString());
            conexion.Close();
            return model;
        }
        private byte[] ObjectToByteArray(Object obj)
        {
            if (obj == null)
                return null;

            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            bf.Serialize(ms, obj);

            return ms.ToArray();
        }
        public void AceptPago(int codigoCompr)
        {
            SqlCommand command = new SqlCommand("sp_AEstadoCompro", conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@idCom", codigoCompr);

            conexion.Open();
            command.ExecuteNonQuery();
            conexion.Close();
        }
        public void RechazarPago(int codigoCompr)
        {
            SqlCommand command = new SqlCommand("sp_REstadoCompro", conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@idCom", codigoCompr);

            conexion.Open();
            command.ExecuteNonQuery();
            conexion.Close();
        }
        public DataTable VerComprobantePago()
        {
            DataTable dtDatos = null;
            conexion.Open();
            SqlCommand command = new SqlCommand("sp_ListarRealizarPagos", conexion);
            SqlDataAdapter daAdaptador = new SqlDataAdapter(command);
            command.CommandType = CommandType.StoredProcedure;
            dtDatos = new DataTable();
            daAdaptador.Fill(dtDatos);
            conexion.Close();
            return dtDatos;
        }
        public void RegistrarComprobantePago(DtoCPago ObjDTOCP, string imag)
        {

            SqlCommand command = new SqlCommand("sp_RegistrarComprobantePago", conexion);
            command.CommandType = CommandType.StoredProcedure;
            //command.Parameters.AddWithValue("@CodigoCita", cita.IC_Cod);command.Parameters.AddWithValue("@FechaHoraSolicitadaCita", ObjDtoCita.DC_FechaHoraSolicitada);
            command.Parameters.AddWithValue("@Imagen", imag);
            command.Parameters.AddWithValue("@Noperaciones", ObjDTOCP.VCP_NOperacion);
            command.Parameters.AddWithValue("@NFisio", ObjDTOCP.ICP_NFisio);
            command.Parameters.AddWithValue("@NNutri", ObjDTOCP.ICP_NNutri);
            command.Parameters.AddWithValue("@Monto", ObjDTOCP.DCP_Monto);
            command.Parameters.AddWithValue("@CodigoUsuarioDNI", ObjDTOCP.FK_CU_Dni);
            conexion.Open();
            command.ExecuteNonQuery();
            conexion.Close();
        }

        public void ActualizarRegistrarPago(DtoCPago ObjDTOCP)
        {
            SqlCommand command = new SqlCommand("sp_ActualizarPago", conexion);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@CodigoComprobantePago", ObjDTOCP.PK_ICP_Cod);
            command.Parameters.AddWithValue("@Imagen", ObjDTOCP.IMC_Imagen);
            command.Parameters.AddWithValue("@ObservacionComprobantePago", ObjDTOCP.VCP_NOperacion);
            command.Parameters.AddWithValue("@NFisio", ObjDTOCP.ICP_NFisio);
            command.Parameters.AddWithValue("@NNutri", ObjDTOCP.ICP_NNutri);
            command.Parameters.AddWithValue("@Monto", ObjDTOCP.DCP_Monto);

            conexion.Open();
            command.ExecuteNonQuery();
            conexion.Close();
        }
    }
}
