using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DtoRuti
    {
        public int PK_IR_Cod { get; set; }
        public DateTime DR_FechaRutina { get; set; }
        public DateTime DR_FechaRegistro { get; set; }
        public string VR_DescripcionE { get; set; }
        public int FK_ITR_Cod { get; set; }
        public string VR_Duracion { get; set; }
        public int IR_Repeticion { get; set; }

    }
}
