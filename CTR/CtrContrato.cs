using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;
using System.Data;

namespace CTR
{
    public class CtrContrato
    {
        DaoContrato objDaoContrato;
        public CtrContrato()
        {
            objDaoContrato = new DaoContrato();
        }
        public void RegistrarContrato(DtoUsuario dtoUsuario, DtoContrato dtoContrato)
        {
            objDaoContrato.RegistrarContrato_PLANxSOCIO(dtoUsuario, dtoContrato);
        }
        public DataTable ListarSolicitudesContratoxUsuarioxEstado(DtoUsuario dtoUsuario, DtoContrato dtoContrato)
        {
            return objDaoContrato.ListarSolicitudesContratoxUsuarioxEstado(dtoUsuario, dtoContrato);
        }
        public DataTable ListarSolicitudesContratoxEstado(DtoContrato dtoContrato)
        {
            return objDaoContrato.ListarSolicitudesContratoxEstado(dtoContrato);
        }
        public void ActualizarContrato(DtoContrato dtoContrato)
        {
            objDaoContrato.ActualizarContrato(dtoContrato);
        }
        public void RegistrarImgPagoContrato(byte[] bytes, int id)
        {
            objDaoContrato.RegistrarImgContratoImg(bytes, id);
        }

    }
}
