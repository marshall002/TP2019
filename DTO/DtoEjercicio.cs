using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DtoEjercicio
    {
        public int PK_IE_Cod { get; set; }
        public string VE_Nombre { get; set; }
        public int FK_ITE_Cod { get; set; }
    }
}
