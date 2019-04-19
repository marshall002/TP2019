using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAO;
using DTO;


namespace CTR
{
	public class CtrCita
	{
		DaoCita objDaoCita;
		public CtrCita()
		{
			objDaoCita = new DaoCita();
		}
		public DataTable VerSolicitudesCita(int idEstadoCita,string CodigoUsuarioDNI)
		{
			return objDaoCita.VerCitasSolicitada(idEstadoCita, CodigoUsuarioDNI);
		}
		public void registrarSolicitudCita(DtoCita CitaSol)
		{
			objDaoCita.RegistrarSolCita(CitaSol);
		}
	}
}
