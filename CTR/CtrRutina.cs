using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace CTR
{
    public class CtrRutina
    {
        DaoRutina objdaorutina;
        public CtrRutina()
        {
            objdaorutina = new DaoRutina();
        }
        public void Registrar_Rutina(DtoRutina objdtorutina)
        {
            objdaorutina.RegistrarRutina(objdtorutina);
        }
        public void Obtener_Rutina(DtoRutina objdtorutina)
        {
            objdaorutina.ObtenerRutina(objdtorutina);
        }
        public void Actualizar_Rutina(DtoRutina objdtorutina)
        {
            objdaorutina.ActualizarRutina(objdtorutina);

        }
        public void Eliminar_Rutina(DtoRutina objdtorutina)
        {
            objdaorutina.EliminarRutina(objdtorutina);

        }
    }
}
