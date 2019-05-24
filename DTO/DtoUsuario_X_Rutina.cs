using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DtoUsuario_X_Rutina
    {
        public string FK_CU_Dni { get; set; }
        public int FK_IR_Cod { get; set; }
        public DateTime DR_FechaHora { get; set; }
        public bool BUR_Asistencia { get; set; }
    }
}
