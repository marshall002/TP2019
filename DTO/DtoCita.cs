using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
	public class DtoCita
	{
		public int IC_Cod { get; set; }
		public DateTime DC_FechaHoraSolicitada { get; set; }
		public string VC_Observacion { get; set; }
		public DateTime DC_FechaHoraCreada { get; set; }
		public int FK_IEC_Cod { get; set; }
		public int FK_ITC_Cod { get; set; }
		public string FK_CU_DNI { get; set; }
        public DateTime  DC_FechaReprogramada { get; set; }
    }
}
