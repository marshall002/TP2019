using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
	public class DtoPlan
	{
		public int PK_IP_Cod { get; set; }
		public string IP_Cantidad { get; set; }
		public DateTime DP_Fecha_Inicio { get; set; }
		public DateTime DP_Fecha_Fin { get; set; }
		public int FK_IM_Cod { get; set; }
		public int FK_IB_Cod { get; set; }
		public int FK_ISN_Cod { get; set; }
	}

}
