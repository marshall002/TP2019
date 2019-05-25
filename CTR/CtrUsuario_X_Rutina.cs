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
    public class CtrUsuario_X_Rutina
    {
        DaoUsuario_X_Rutina objDRU;
         
        public CtrUsuario_X_Rutina()
        {
            objDRU = new DaoUsuario_X_Rutina();
        }
        public DataTable ListarRutinas_Usuario(DtoUsuario obju)
        {
            return objDRU.VerRutinas_Usuario(obju);
        }
        public int buscarRutina(DtoRutina dtor)
        {
            return objDRU.buscarFKRutina(dtor);
        }
        public void registrarUsuario_rutina(DtoUsuario_X_Rutina dtour)
        {
            objDRU.RegistrarRutinaUsuario(dtour);
        }
        public bool buscarfechaInsc(DtoUsuario_X_Rutina dtour)
        {
            return objDRU.ExisteInscripcion(dtour);
        }

    }
}
