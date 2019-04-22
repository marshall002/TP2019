using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
	public class DtoUsuario
	{
		public int PK_CU_Dni { get; set; }
		public string VU_Nombre { get; set; }
		public string VU_APaterno { get; set; }
		public DateTime DU_FechaNacimiento	{ get; set; }
		public string CU_Celular { get; set; }
		public string VU_Direccion { get; set; }
		public string VU_Correo { get; set; }
		public string FK_ITU_Cod { get; set; }
		public string FK_ID_Cod { get; set; }
		public string FK_IP_Cod { get; set; }
	}
}
