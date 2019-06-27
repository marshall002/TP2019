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

        public void VERPAGO(DtoCPago objusu)
        {
            objDaoCPago.VERPAGO(objusu);
        }
        public DtoCPago ComprobanteP(int codigo)
        {
            return objDaoCPago.VerComprobante(codigo);
        }
        public DtoCPago verComprobanteP(int codigo)
        {
            return objDaoCPago.VerCPago(codigo);
        }
        public void AceptP(int idCompro)
        {
            objDaoCPago.AceptPago(idCompro);
        }
        public void RechaP(int idCompro)
        {
            objDaoCPago.RechazarPago(idCompro);
        }
        public DataTable VerComprobante_Pago()
        {
            return objDaoCPago.VerComprobantePago();
        }
        public void RegistrarComprobante_Pago(DtoCPago objDTOCP, string imag)
        {
            objDaoCPago.RegistrarComprobantePago(objDTOCP, imag);
        }
        public void ActualizarComprobante_Pago(DtoCPago objDTOCP)
        {
            objDaoCPago.ActualizarRegistrarPago(objDTOCP);
        }
    }
}
