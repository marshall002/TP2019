using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

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
    }
}
