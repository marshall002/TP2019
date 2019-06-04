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
        public DateTime DR_FechaRutina { get; set; }
        public DateTime DR_FechaHoraRegistro { get; set; }
        public int FK_ITR_Cod { get; set; }
        public string VR_Descripcion{ get; set; }


    }
}
