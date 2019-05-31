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
       
        public int retornaRutinaId(string fecha,int tipoR)
        {
            return objDRU.retornaidRutina(fecha,tipoR);
        }
        public int retornaHoraId(string hora)
        {
            return objDRU.retornaidHora(hora);
        }
        public int retornaNumeroParticipantes(int idr, int idh)
        {
            return objDRU.retornaNparticipantes(idr,idh);
        }
        public void registrarUsuario_rutina(DtoUsuario_X_Rutina dtour)
        {
            objDRU.RegistrarRutinaUsuario(dtour);
        }
        public bool buscarfechaInsc(string fechahora, string dni,int codtr)
        {
            return objDRU.ExisteInscripcion(fechahora,dni,codtr);
        }
        public void actualizarUsuario_rutina(DtoUsuario_X_Rutina dtour, string fecha)
        {
            objDRU.ActualizarRutinaUsuario(dtour,fecha);
        }
        public void eliminarUsuario_rutina(DtoUsuario_X_Rutina dtour)
        {
            objDRU.EliminarRutinaUsuario(dtour);
        }
        public bool validarHoraRepetida(String dni,int idR, int idH)
        {
            return objDRU.Validacion_Hora_Repetido(dni, idR,idH);
        }
        public bool validarNClasesXdia(string fecha,string dni)
        {
            return objDRU.Validacion_Num_claseXdia(fecha, dni);
        }

    }
}
