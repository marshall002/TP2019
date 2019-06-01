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
    public class CtrTipo_Ejercicio
    {
        DaoTipo_Ejercicio objDaoTipo_Ejercicio;

        public CtrTipo_Ejercicio()
        {
            objDaoTipo_Ejercicio = new DaoTipo_Ejercicio();
        }

        public DataTable CargaDatosTEjercicio()
        {
            return objDaoTipo_Ejercicio.CDatosTEJercicios();
        }
    }
}
