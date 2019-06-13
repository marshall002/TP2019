using DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTR
{
    public class CtrCPago
    {
        DaoCPago objDaoCPago;
        public CtrCPago()
        {
            objDaoCPago = new DaoCPago();
        }
        public DataTable VComPago()
        {
            return objDaoCPago.VerCPagos();
        }
    }
}
