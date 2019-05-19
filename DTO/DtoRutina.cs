using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DtoRutina
    {
        public int PK_IR_Cod { get; set; }
        public DateTime DR_FechaHoraInicio { get; set; }
        public DateTime DR_FechaHoraFin { get; set; }
        public int FK_IE_Cod { get; set; }
        public int FK_ITR_Cod { get; set; }

    }
}
