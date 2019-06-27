using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class DtoCPago
    {
        public int PK_ICP_Cod { get; set; }

        public string IMC_Imagen { get; set; }

        public string VCP_NOperacion { get; set; }
        public int ICP_NFisio { get; set; }
        public int ICP_NNutri { get; set; }
        public string VCP_Estado_Pago { get; set; }
        public double DCP_Monto { get; set; }
        public DateTime DCP_FechaHoraRealizada { get; set; }
        public int FK_CU_Dni { get; set; }
        
        public int estado { get; set; }




    }
}
