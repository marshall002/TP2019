using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;

namespace CTR
{
    public class CtrRutinaXEjercicio
    {
        DaoRutinaXEjercicio objDaoRutinaXEjercicio;

        public CtrRutinaXEjercicio()
        {
            objDaoRutinaXEjercicio = new DaoRutinaXEjercicio();
        }

        public DataTable ListarRutinaFecha(DateTime fechaRutina,int idRutina)
        {
            return objDaoRutinaXEjercicio.ListRutina(fechaRutina,idRutina);
        }
    }
}
