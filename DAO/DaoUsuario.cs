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

        public void RegistrarSocio(DtoUsuario objRec)
        {
            SqlCommand cmd = new SqlCommand("sp_RegistrarSocio", conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@PK_CU_Dni", objRec.PK_CU_Dni);
            cmd.Parameters.AddWithValue("@VU_Nombre", objRec.VU_Nombre);
            cmd.Parameters.AddWithValue("@VU_APaterno", objRec.VU_APaterno);
            cmd.Parameters.AddWithValue("@VU_AMaterno", objRec.VU_AMaterno);
            cmd.Parameters.AddWithValue("@VU_Correo", objRec.VU_Correo);
            cmd.Parameters.AddWithValue("@DU_FechaNacimiento", objRec.DU_FechaNacimiento);
            cmd.Parameters.AddWithValue("@NU_Contrasenia", objRec.VU_Contrasenia);
            cmd.Parameters.AddWithValue("@CU_Celular", objRec.CU_Celular);
            cmd.Parameters.AddWithValue("@VU_Direccion", objRec.VU_Direccion);

            conexion.Open();
            cmd.ExecuteNonQuery();
            conexion.Close();
        }


        public void ObtenerDatosSocioPlan(DtoUsuario usuario, DtoPlan plan, DtoSesionFisio sesionfisio, DtoSesionNutri sesionnutri)
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
                if (reader[6] != DBNull.Value)
                {
                    usuario.FK_IC_Cod = Convert.ToInt32(reader[6].ToString());
                }
                else
                {
                    usuario.FK_IC_Cod = 0;
                }
                usuario.FK_ITU_Cod = Convert.ToInt32(reader[7].ToString());
                usuario.IC_Citas_Fisio_Usadas = Convert.ToInt32(reader[8].ToString());
                usuario.IC_Citas_Nutri_Usadas = Convert.ToInt32(reader[9].ToString());
                usuario.VU_Correo =reader[10].ToString();
                usuario.VU_Direccion = reader[11].ToString();
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
                " U.PK_CU_Dni = '" + usuario + "' AND U.VU_Contrasenia = '" + clave + "'", conexion);



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
                "U.VU_AMaterno," +
                "U.VU_Correo, " +
                "U.PK_CU_Dni," +
                "U.VU_Direccion," +
                "U.CU_Celular," +
                "U.FK_IC_Cod," +
                "U.DU_FechaNacimiento" +
                " from T_Usuario as U " +
                "where U.PK_CU_Dni = '" + usuario + "'", conexion);

            DtoUsuario usuarioDto = new DtoUsuario();
            DtoPlan planDto = new DtoPlan();
            DtoTipoUsuario tipousuarioDto = new DtoTipoUsuario();



            conexion.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                tipousuarioDto.PK_TU_Cod = int.Parse(reader[0].ToString());
                usuarioDto.FK_ITU_Cod = int.Parse(reader[0].ToString());
                usuarioDto.VU_Nombre = reader[1].ToString();
                usuarioDto.VU_APaterno = reader[2].ToString();
                usuarioDto.VU_AMaterno = reader[3].ToString();
                usuarioDto.VU_Correo = reader[4].ToString();
                usuarioDto.PK_CU_Dni = reader[5].ToString();
                usuarioDto.VU_Direccion = reader[6].ToString();
                usuarioDto.CU_Celular = reader[7].ToString();

                if (reader[8] != DBNull.Value)
                {
                    usuarioDto.FK_IC_Cod = int.Parse(reader[8].ToString());
                    planDto.PK_IP_Cod = int.Parse(reader[8].ToString());
                }
                else
                {
                }
                usuarioDto.DU_FechaNacimiento = DateTime.Parse(reader[9].ToString());

            }
            conexion.Close();

            return (usuarioDto);
        }
    }
}
