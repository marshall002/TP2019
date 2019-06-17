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
    }
}
