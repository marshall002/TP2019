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
    public class DaoUsuario_X_Rutina
    {
        SqlConnection conexion;
        public DaoUsuario_X_Rutina() { 
        conexion = new SqlConnection(ConexionBD.CadenaConexion);
        }
        public int buscarFKRutina(DtoRutina objr)
        {
            int valor_retornado = 0;
            conexion.Open();
            SqlCommand cmd = new SqlCommand("sp_Buscar_PKRutina", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@fecha", objr.DR_FechaRutina);
            DataSet ds = new DataSet();
            conexion.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            da.Dispose();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                valor_retornado = int.Parse(reader[0].ToString());
                
            }
            conexion.Close();
            conexion.Dispose();
            
            return valor_retornado ;

        }
        public bool ExisteInscripcion(DtoUsuario_X_Rutina dur)
        {

            string query = "SELECT COUNT (*) FROM T_Usuario_X_Rutina WHERE DUR_FechaHora=@fecha and FK_CU_Dni=@dni";
            SqlCommand cmd = new SqlCommand(query, conexion);
            cmd.Parameters.AddWithValue("@fecha", dur.DR_FechaHora);
            cmd.Parameters.AddWithValue("@dni", dur.FK_CU_Dni);
            conexion.Open();
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            conexion.Close();

            if (count == 0)
                return false;
            else
                return true;

        }
        public void RegistrarRutinaUsuario(DtoUsuario_X_Rutina ObjDtoUsuarioXRutina)
        {
            SqlCommand command = new SqlCommand("sp_RegistrarUsuarioXRutina", conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@pkusuario", ObjDtoUsuarioXRutina.FK_CU_Dni);
            command.Parameters.AddWithValue("@pkrutina", ObjDtoUsuarioXRutina.FK_IR_Cod);
            command.Parameters.AddWithValue("@fechahora", ObjDtoUsuarioXRutina.DR_FechaHora);
            
            conexion.Open();
            command.ExecuteNonQuery();
            conexion.Close();
        }
        public DataTable VerRutinas_Usuario(DtoUsuario dtousuario)
        {
            DataTable dtDatos = null;
            conexion.Open();
            SqlCommand command = new SqlCommand("sp_Listar_rutinas_socio", conexion);
            command.Parameters.AddWithValue("@dni",dtousuario.PK_CU_Dni);
            SqlDataAdapter daAdaptador = new SqlDataAdapter(command);
            command.CommandType = CommandType.StoredProcedure;
            dtDatos = new DataTable();
            daAdaptador.Fill(dtDatos);
            conexion.Close();
            return dtDatos;
        }
    }
}
