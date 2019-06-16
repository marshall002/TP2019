using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using System.Data;


namespace CTR
{
    public class CtrMonitoriarCitaFisio
    {

        DaoMonitorearCitaFisio objDaoMonitorearCitaFisio;

        public CtrMonitoriarCitaFisio()
        {
            objDaoMonitorearCitaFisio = new DaoMonitorearCitaFisio();
        }

        public DataTable VMonitoriarCitaFisio()
        {
            return objDaoMonitorearCitaFisio.ListarMonitoriarCitaFisio();
        }

    }
}
