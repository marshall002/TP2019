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
    public class DaoUsuario
    {
        SqlConnection conexion;
        public DaoUsuario()
        {
            conexion = new SqlConnection(ConexionBD.CadenaConexion);
        }
        public void ObtenerDatosSocio(DtoUsuario usuario, DtoPlan plan, DtoSesionFisio sesionfisio, DtoSesionNutri sesionnutri)
        {
            SqlCommand cmd = new SqlCommand("sp_ObtenerDatosUsuario", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@DNISocio", usuario.PK_CU_Dni);
            DataSet ds = new DataSet();
            conexion.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            da.Dispose();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                usuario.PK_CU_Dni = reader[0].ToString();
                usuario.VU_Nombre = reader[1].ToString();
                usuario.VU_APaterno = reader[2].ToString();
                usuario.VU_AMaterno = reader[3].ToString();
                usuario.CU_Celular = reader[4].ToString();
                usuario.DU_FechaNacimiento = Convert.ToDateTime(reader[5].ToString());
                usuario.FK_IP_Cod = Convert.ToInt32(reader[6].ToString());
                usuario.FK_ITU_Cod = Convert.ToInt32(reader[7].ToString());
                plan.DP_Fecha_Fin = Convert.ToDateTime(reader[8].ToString());
                sesionfisio.ISF_Cantidad = int.Parse(reader[9].ToString());
                sesionnutri.ISN_Cantidad = int.Parse(reader[10].ToString());
            }
            conexion.Close();
            conexion.Dispose();
        }

        public void ObtenerNumerodeCitasUsadas(DtoUsuario usuario)
        {
            SqlCommand cmd = new SqlCommand("sp_ObtenerCitasDisponiblesxUsuario", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CodigoUsuarioDNI", usuario.PK_CU_Dni);
            DataSet ds = new DataSet();
            conexion.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            da.Dispose();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                usuario.IC_Citas_Fisio_Usadas = int.Parse(reader[0].ToString());
                usuario.IC_Citas_Nutri_Usadas = int.Parse(reader[1].ToString());
            }
            conexion.Close();
            conexion.Dispose();
        }

        public DataTable ListarDNIUsuario()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_Desplegable_Socio", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                return dt;
            }
            catch
            {
                return null;
            }
        }


        public int validacionLogin(string usuario, string clave)
        {

            int valor_retornado = 0;
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM T_USUARIO as U WHERE" +
                " U.PK_CU_Dni = '" + usuario + "' AND U.VU_Contraseña = '" + clave + "'", conexion);



            Console.WriteLine(cmd);
            conexion.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {    //valor_retornado = reader[0].ToString();
                valor_retornado = int.Parse(reader[0].ToString());

            }
            conexion.Close();

            return valor_retornado;
        }


        public DtoUsuario datosUsuario(String usuario)
        {
            SqlCommand cmd = new SqlCommand("select U.FK_ITU_Cod," +
                "U.VU_Nombre," +
                "U.VU_APaterno," +
                "U.VU_Correo " +
                "from T_Usuario as U " +
                "where U.PK_CU_Dni = '" + usuario + "'", conexion);

            DtoUsuario usuarioDto = new DtoUsuario();

            conexion.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                usuarioDto.FK_ITU_Cod = int.Parse(reader[0].ToString());
                usuarioDto.VU_Nombre = reader[1].ToString();
                usuarioDto.VU_APaterno = reader[2].ToString();
                usuarioDto.VU_Correo = reader[3].ToString();

            }
            conexion.Close();

            return usuarioDto;
        }
    }
}
