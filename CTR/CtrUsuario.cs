using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace CTR
{
	public class CtrUsuario
	{
		DaoUsuario objDaoUsuario;
		public CtrUsuario()
		{
			objDaoUsuario = new DaoUsuario();
		}
		public void ObtenerInformacionUsuario(DtoUsuario dtoUsuario,DtoPlan dtoplan,DtoSesionFisio dtosesionfisio, DtoSesionNutri dtosesionnutri )
		{
			objDaoUsuario.ObtenerDatosSocio(dtoUsuario, dtoplan, dtosesionfisio, dtosesionnutri);
		}
		public void ObtenerNumCitasRealizadas(DtoUsuario dtoUsuario)
		{
			objDaoUsuario.ObtenerNumerodeCitasUsadas(dtoUsuario);
		}
	}
}
