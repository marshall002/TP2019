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
        public DaoUsuario_X_Rutina()
        {
            conexion = new SqlConnection(ConexionBD.CadenaConexion);
        }
        public int retornaidRutina(string fecha, int tipoR)
        {
            DateTime obj = DateTime.Parse(fecha);
            string obj2 = obj.ToString("yyyy-MM-dd");
            int valor_retornado = 0;
            SqlCommand cmd = new SqlCommand("SELECT PK_IR_cod FROM T_RUTINA as R WHERE" +
                " R.DR_FechaRutina ='" + obj2 + "T00:00:00' and FK_ITR_Cod=" + tipoR, conexion);


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
        //public int retornaNParticipantes(string fecha, int tipoR)
        //{

        //    int valor_retornado = 0;
        //    SqlCommand cmd = new SqlCommand("SELECT ICL_NParticipantes FROM T_Clase as CL inner join T_Usuario_X_Rutina as UR on UR.FK_ICL_Cod = CL.PK_ICL_Cod inner join T_Rutina as R on R.PK_IR_Cod = UR.FK_IR_Cod WHERE CL.DCL_FechaHora = '" + fecha + "'and R.FK_ITR_Cod" + tipoR, conexion);

        //    Console.WriteLine(cmd);
        //    conexion.Open();
        //    SqlDataReader reader = cmd.ExecuteReader();

        //    if (reader.Read())
        //    {    //valor_retornado = reader[0].ToString();
        //        valor_retornado = int.Parse(reader[0].ToString());

        //    }
        //    conexion.Close();

        //    return valor_retornado;
        //}
        public int retornaidHora(string hora)
        {

            string query = "SELECT PK_IH_Cod FROM T_Hora WHERE TH_Hora='" + hora + "'";
            SqlCommand cmd = new SqlCommand(query, conexion);

            conexion.Open();
            int id = Convert.ToInt32(cmd.ExecuteScalar());
            conexion.Close();
            return id;

        }
        public int retornaNparticipantes(int idr,int idh)
        {

            string query = "SELECT COUNT (*) FROM T_Usuario_X_Rutina where FK_IR_Cod=" + idr + " and FK_IH_Cod="+idh;
            SqlCommand cmd = new SqlCommand(query, conexion);

            conexion.Open();
            int num = Convert.ToInt32(cmd.ExecuteScalar());
            conexion.Close();
            return num;

        }

        public bool ExisteInscripcion(string fechahora,string dni,int codTR)
        {
            int valor_retornado = 0;
            string query = "SELECT COUNT (*) FROM T_Usuario_X_Rutina inner join T_Rutina on PK_IR_Cod = FK_IR_Cod WHERE DUR_FechaHora='" + fechahora + "' and FK_CU_Dni='" + dni + "'"+
                "and FK_ITR_Cod="+codTR;
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
        public void RegistrarRutinaUsuario(DtoUsuario_X_Rutina ObjDtoUsuarioXRutina)
        {
            SqlCommand command = new SqlCommand("sp_RegistrarUsuarioXRutina", conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@pkusuario", ObjDtoUsuarioXRutina.FK_CU_Dni);
            command.Parameters.AddWithValue("@pkrutina", ObjDtoUsuarioXRutina.FK_IR_Cod);
            command.Parameters.AddWithValue("@fechahora", ObjDtoUsuarioXRutina.DR_FechaHora);
            command.Parameters.AddWithValue("@idhora", ObjDtoUsuarioXRutina.FK_IH_Cod);
            conexion.Open();
            command.ExecuteNonQuery();
            conexion.Close();
        }
        public DataTable VerRutinas_Usuario(DtoUsuario dtousuario)
        {
            DataTable dtDatos = null;
            conexion.Open();
            SqlCommand command = new SqlCommand("sp_Listar_rutinas_socio", conexion);
            command.Parameters.AddWithValue("@dni", dtousuario.PK_CU_Dni);
            SqlDataAdapter daAdaptador = new SqlDataAdapter(command);
            command.CommandType = CommandType.StoredProcedure;
            dtDatos = new DataTable();
            daAdaptador.Fill(dtDatos);
            conexion.Close();
            return dtDatos;
        }
        public void ActualizarRutinaUsuario(DtoUsuario_X_Rutina ObjDtoUsuarioXRutina,string fecha)
        {
            SqlCommand command = new SqlCommand("sp_ActualizarRutinaUsuario", conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@dni", ObjDtoUsuarioXRutina.FK_CU_Dni);
            command.Parameters.AddWithValue("@codR", ObjDtoUsuarioXRutina.FK_IR_Cod);
            command.Parameters.AddWithValue("@fechaN", fecha);
            command.Parameters.AddWithValue("@idhora", ObjDtoUsuarioXRutina.FK_IH_Cod);
            conexion.Open();
            command.ExecuteNonQuery();
            conexion.Close();
        }
        public void EliminarRutinaUsuario(DtoUsuario_X_Rutina ObjDtoUsuarioXRutina)
        {
            SqlCommand command = new SqlCommand("sp_EliminarRutinaUsuario", conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@dni", ObjDtoUsuarioXRutina.FK_CU_Dni);
            command.Parameters.AddWithValue("@codR", ObjDtoUsuarioXRutina.FK_IR_Cod);
            conexion.Open();
            command.ExecuteNonQuery();
            conexion.Close();
        }
    }

}
