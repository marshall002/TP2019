using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
	public class DtoUsuario
	{
		public string PK_CU_Dni { get; set; }
		public string VU_Nombre { get; set; }
		public string VU_APaterno { get; set; }
		public string VU_AMaterno { get; set; }
		public DateTime DU_FechaNacimiento	{ get; set; }
		public string CU_Celular { get; set; }
		public string VU_Direccion { get; set; }
		public string VU_Correo { get; set; }
        public string VU_Contraseña { get; set; }
		public int FK_ITU_Cod { get; set; }
		public int FK_ID_Cod { get; set; }
		public int FK_IP_Cod { get; set; }
		public int IC_Citas_Nutri_Usadas { get; set; }
		public int IC_Citas_Fisio_Usadas { get; set; }
	}
}
