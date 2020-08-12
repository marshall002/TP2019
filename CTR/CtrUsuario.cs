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
    public class CtrUsuario
    {
        DaoUsuario objDaoUsuario;

        public CtrUsuario()
        {
            objDaoUsuario = new DaoUsuario();
        }
        public void ObtenerInformacionUsuario(DtoUsuario dtoUsuario, DtoContrato dtoContrato, DtoSesionFisio dtosesionfisio, DtoSesionNutri dtosesionnutri)
        {
            objDaoUsuario.ObtenerDatosSocioPlan(dtoUsuario, dtoContrato, dtosesionfisio, dtosesionnutri);
        }
        public void ObtenerNumCitasRealizadas(DtoUsuario dtoUsuario)
        {
            objDaoUsuario.ObtenerNumerodeCitasUsadas(dtoUsuario);
        }
        public DataTable ListarDNIUsuario()
        {
            return objDaoUsuario.ListarDNIUsuario();
        }

        public void RegistrarSocio(DtoUsuario objRecBE)
        {
            objDaoUsuario.RegistrarSocio(objRecBE);
        }


        public int MensajeRegistrarSocio(string llave)
        {
            //llave duplicada
            int contador = objDaoUsuario.BuscarUsuario(llave);
            return contador;
        }

        public DtoUsuario Login(DtoUsuario dtoUsuario)
        {

            int persona_id = objDaoUsuario.validacionLogin(dtoUsuario.PK_CU_Dni, dtoUsuario.VU_Contrasenia);

            if (persona_id == 0)
            {
                throw new Exception("Usuario y/o contrase&ntilde;a incorrecta(s)");
            }
            else
            {
                return objDaoUsuario.datosUsuario(dtoUsuario.PK_CU_Dni);
            }
        }

        
    }
}
