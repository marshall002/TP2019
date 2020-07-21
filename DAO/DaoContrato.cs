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
    }

}
