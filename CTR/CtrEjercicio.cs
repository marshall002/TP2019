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
    public class CtrEjercicio
    {
        DaoEjercicio objDaoEjercicio;

        public CtrEjercicio()
        {
            objDaoEjercicio = new DaoEjercicio();
        }

        public DataTable CargaDatosEjercicio(int TipoEjercicio)
        {
            return objDaoEjercicio.CDatosEJercicios(TipoEjercicio);
        }
        public DataTable CargaDatosEjercicioXT(int TypeEjerId)
        {
            return objDaoEjercicio.CDatosEJerciciosXT(TypeEjerId);
        }
    }
}
