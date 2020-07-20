using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAO
{
    public class DaoPlan
    {
        SqlConnection conexion;
        public DaoPlan()
        {
            conexion = new SqlConnection(ConexionBD.CadenaConexion);
        }

        public List<DtoPlan> getPLanes()
        {
            List<DtoPlan> ListRuleta = new List<DtoPlan>();
            SqlCommand cmd = new SqlCommand("sp_ListarPlanes", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            //command.Parameters.AddWithValue("@CodigoCita", cita.IC_Cod);
            DataSet ds = new DataSet();
            conexion.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            da.Dispose();

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                DtoPlan objdtoPLan = new DtoPlan();

                objdtoPLan.PK_IP_Cod = int.Parse(reader[0].ToString());
                objdtoPLan.IP_Cantidad_Sesion_Fisio = int.Parse(reader[1].ToString());
                objdtoPLan.IE_Cantidad_Sesion_Nutri = int.Parse(reader[2].ToString());
                objdtoPLan.DP_Costo = double.Parse(reader[3].ToString());
                objdtoPLan.Congelamiento =reader[4].ToString();
                objdtoPLan.MembresiaDuracionString = reader[5].ToString();
                objdtoPLan.FrecuenciaString = reader[6].ToString();
                ListRuleta.Add(objdtoPLan);
            }
            int iGrupo = 0;
            int iPosicion = 0;
            foreach (DtoPlan oRuletaOrdenada in ListRuleta)
            {
                oRuletaOrdenada.Index = iGrupo;
                oRuletaOrdenada.Posicion = iPosicion;
                iPosicion++;
                if (iPosicion == 3)
                {
                    iGrupo++;
                    iPosicion = 0;
                }
            }
            conexion.Close();
            conexion.Dispose();

            return ListRuleta;
        }
    }
}
