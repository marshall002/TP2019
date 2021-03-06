﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data.SqlClient;
using System.Data;
using System.Net.Mail;
using System.Net;


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


        public void ObtenerDatosSocioPlan(DtoUsuario usuario, DtoContrato contrato,DtoSesionFisio sesionfisio, DtoSesionNutri sesionnutri)
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
                usuario.IC_Citas_Fisio_Usadas = Convert.ToInt32(reader[7].ToString());
                usuario.IC_Citas_Nutri_Usadas = Convert.ToInt32(reader[8].ToString());
                usuario.VU_Correo = reader[9].ToString();
                usuario.VU_Direccion = reader[10].ToString();
                contrato.DC_Fecha_Vencimiento= Convert.ToDateTime(reader[11].ToString());
                sesionfisio.ISF_Cantidad= Convert.ToInt32(reader[12].ToString());
                sesionnutri.ISN_Cantidad= Convert.ToInt32(reader[13].ToString());
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
                usuarioDto.DU_FechaNacimiento = DateTime.Parse(reader[8].ToString());
            }
            conexion.Close();
            return (usuarioDto);
        }

        public int BuscarUsuario(string llaveDNI)
        {
            int valor_retornado = 0;
            string select = "select COUNT(*) from T_Usuario where PK_CU_Dni = '" + llaveDNI+"'";
            SqlCommand Comando = new SqlCommand(select, conexion);

            conexion.Open();
            SqlDataReader reader = Comando.ExecuteReader();

            if (reader.Read())
            {
                valor_retornado = int.Parse(reader[0].ToString());

            }
            conexion.Close();

            return valor_retornado;
        }

    }
}
