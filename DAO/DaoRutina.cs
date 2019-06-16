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
    public class DaoRutina
    {
        SqlConnection conexion;
        DtoRuti objdtoruti = new DtoRuti();
        public DaoRutina()
        {
            conexion = new SqlConnection(ConexionBD.CadenaConexion);
        }

        public DataTable VerRutina(DtoRutina objr)
		{
			DataTable dtDatos = null;
			conexion.Open();
			SqlCommand command = new SqlCommand("SP_ObtenerRutina", conexion);
			command.Parameters.AddWithValue("@DR_FechaRutina", objr.DR_FechaRutina);
            command.Parameters.AddWithValue("@FK_ITR_Cod", objr.FK_ITR_Cod);
            SqlDataAdapter daAdaptador = new SqlDataAdapter(command);
			command.CommandType = CommandType.StoredProcedure;
			dtDatos = new DataTable();
			daAdaptador.Fill(dtDatos);
			conexion.Close();
			return dtDatos;
		}

        public void RegistrarRutina(DtoRutina objDtoRutina)
        {
            SqlCommand command = new SqlCommand("SP_RegistrarRutina", conexion);
            command.CommandType = CommandType.StoredProcedure;
            //command.Parameters.AddWithValue("@CodigoCita", cita.IC_Cod);
            command.Parameters.AddWithValue("@DR_FechaRutina", objDtoRutina.DR_FechaRutina);
            command.Parameters.AddWithValue("@FK_ITR_Cod", objDtoRutina.FK_ITR_Cod);
            command.Parameters.AddWithValue("@VR_Descripcion", objDtoRutina.VR_Descripcion);

            conexion.Open();
            command.ExecuteNonQuery();
            conexion.Close();
        }
        public void ActualizarRutina(DtoRutina objDtoRutina)
        {
            SqlCommand command = new SqlCommand("SP_ActualizarRutina", conexion);
            command.CommandType = CommandType.StoredProcedure;
            //command.Parameters.AddWithValue("@CodigoCita", cita.IC_Cod);
            command.Parameters.AddWithValue("@pk_IR_Cod", objDtoRutina.PK_IR_Cod);
            command.Parameters.AddWithValue("@vc_Descripcion", objDtoRutina.VR_Descripcion);

            conexion.Open();
            command.ExecuteNonQuery();
            conexion.Close();
        }
        public void EliminarRutina(DtoRutina objDtoRutina)
        {
            SqlCommand command = new SqlCommand("SP_EliminarRutina", conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@pk_IR_Cod", objDtoRutina.PK_IR_Cod);

            conexion.Open();
            command.ExecuteNonQuery();
            conexion.Close();
        }
        public void ObtenerRutina(DtoRutina objDtoRutina)
        {
            SqlCommand cmd = new SqlCommand("SP_ObtenerRutina", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            //command.Parameters.AddWithValue("@CodigoCita", cita.IC_Cod);
            cmd.Parameters.AddWithValue("@DR_FechaRutina", objDtoRutina.DR_FechaRutina);
            cmd.Parameters.AddWithValue("@FK_ITR_Cod", objDtoRutina.FK_ITR_Cod);
            DataSet ds = new DataSet();
            conexion.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            da.Dispose();

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {

                objDtoRutina.PK_IR_Cod = int.Parse(reader[0].ToString());

                if (reader[1] != DBNull.Value)
                {
                    objDtoRutina.VR_Descripcion = reader[1].ToString();
                }
                else
                {
                    objDtoRutina.VR_Descripcion = reader[1].ToString();
                }


            }

            conexion.Close();
            conexion.Dispose();
        }
        public void RegistrarEjercicio(String nombre, Double duracion, String observacion)
        {
            SqlCommand command = new SqlCommand("sp_RegistrarEjercicio", conexion);
            command.CommandType = CommandType.StoredProcedure;
            //command.Parameters.AddWithValue("@CodigoCita", cita.IC_Cod);
            command.Parameters.AddWithValue("@nombreEjercicio", nombre);
            command.Parameters.AddWithValue("@duracionEjercicio", duracion);
            command.Parameters.AddWithValue("@observacionEjercicio", observacion);
            conexion.Open();
            command.ExecuteNonQuery();
            conexion.Close();
        }

        ///
        public void registrarRuti(DtoRuti objdtoRuti)
        {
            
            conexion.Open();
            string query = "INSERT INTO T_Ruti (DR_FechaRutina,VR_DescripcionE,ITR_TipoRutina,VR_Duracion,IR_Repeticion) VALUES (@DR_FechaRutina,@VR_DescripcionE,@ITR_TipoRutina,@VR_Duracion,@IR_Repeticion)";
            SqlCommand sqlCmd = new SqlCommand(query, conexion);
            sqlCmd.Parameters.AddWithValue("@DR_FechaRutina", objdtoRuti.DR_FechaRutina);
            sqlCmd.Parameters.AddWithValue("@VR_DescripcionE", objdtoRuti.VR_DescripcionE);
            sqlCmd.Parameters.AddWithValue("@IR_TipoRutina", objdtoRuti.FK_ITR_Cod);
            sqlCmd.Parameters.AddWithValue("@VR_Duracion", objdtoRuti.VR_Duracion);
            sqlCmd.Parameters.AddWithValue("@VR_Repeticion", objdtoRuti.IR_Repeticion);
            //test
            sqlCmd.ExecuteNonQuery();
            
        }

        public void actualizarRuti(DateTime fechaRutina, string descripcion, string duracion, int repeticion)
        {
            conexion.Open();
            DtoRuti objdtoruti = new DtoRuti();
            
            string query = "UPDATE T_Ruti SET DR_FechaRutina=@DR_FechaRutina,VR_DescripcionE=@VR_DescripcionE,VR_Duracion=@VR_Duracion,IR_Repeticion=@IR_Repeticion WHERE PK_IR_Cod = @id";
            //SqlCommand command = new SqlCommand(query, conexion);
            SqlCommand sqlCmd = new SqlCommand(query, conexion);
            sqlCmd.Parameters.AddWithValue("@DR_FechaRutina", fechaRutina);
            sqlCmd.Parameters.AddWithValue("@VR_DescripcionE", descripcion);
            sqlCmd.Parameters.AddWithValue("@VR_Duracion", duracion);
            sqlCmd.Parameters.AddWithValue("@IR_Repeticion", Convert.ToInt32(repeticion.ToString()));
            sqlCmd.ExecuteNonQuery();
            conexion.Close();
        }

        public void eliminarRuti(int codigoRuti)
        {
            conexion.Open();
            string query = "DELETE FROM T_Ruti WHERE FK_IR_Cod = @id";
            SqlCommand sqlCmd = new SqlCommand(query, conexion);
            sqlCmd.Parameters.AddWithValue("@id", Convert.ToInt32(codigoRuti.ToString()));
            sqlCmd.ExecuteNonQuery();
        }
    }
}
