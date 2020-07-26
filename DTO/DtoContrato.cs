using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DtoContrato
    {
        public int PK_IC_Cod { get; set; }
        public string VC_DEscripcion { get; set; }
        public DateTime DC_Fecha_Creacion { get; set; }
        public DateTime DC_Fecha_Evaluacion { get; set; }
        public DateTime DC_Fecha_Inicio{ get; set; }
        public int FK_IEC_Cod { get; set; }
        public int FK_IP_Cod { get; set; }
        public string FK_CU_Dni { get; set; }
        public DateTime DC_Fecha_Vencimiento { get; set; }
        public byte[] VBC_Imagen { get; set; }
    }
}
