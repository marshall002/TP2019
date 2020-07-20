using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace CTR
{
    public class CtrPlan
    {
        DaoPlan objdaoplan;
        public CtrPlan()
        {
            objdaoplan = new DaoPlan();
        }
        public List<DtoPlan> ObtenerPlanes()
        {
            List<DtoPlan> ListRuleta = new List<DtoPlan>();
            ListRuleta = objdaoplan.getPLanes();
            return ListRuleta;
        }
    }
}
