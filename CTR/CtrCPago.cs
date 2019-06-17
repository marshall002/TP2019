using DAO;
using DTO;
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
        public DataTable VComPago(string name)
        {
            return objDaoCPago.VerCPagos(name);
        }
        public DtoCPago ComprobanteP(int codigo)
        {
            return objDaoCPago.VerComprobante(codigo);
        }
        public void AceptP(int idCompro)
        {
            objDaoCPago.AceptPago(idCompro);
        }
    }
}
