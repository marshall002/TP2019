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
		public DataTable VerSolicitudesCita(string CodigoUsuarioDNI)
		{
			return objDaoCita.VerCitasSolicitada(CodigoUsuarioDNI);
		}
		public DataTable VerSolicitudesCitaAdmin()
		{
			return objDaoCita.VerCitasSolicitudesAdmin();
		}
		public void registrarSolicitudCita(DtoCita objDtoCita)
        {
			objDaoCita.RegistrarSolCita(objDtoCita);
		}
        public void RegistrarCita(DtoCita objDtoCita)
        {
            objDaoCita.RegistrarCita(objDtoCita);
        }
        public void actualizarSolicitudCita(int Codigo, DateTime fechahorasolicitada, string dudaconsulta, int idTipoCita)
		{
			objDaoCita.ActualizarSolCita(Codigo, fechahorasolicitada, dudaconsulta, idTipoCita);
		}
        public DataTable LCitaNutri()
        {
            return objDaoCita.VerCitasNutri();
        }
        public void ActualizarSolCitaAdmin(DtoCita CitaSolAdmin)
        {
            objDaoCita.ActualizarSolCitaAdmin(CitaSolAdmin);
        }
        public void EliminarrSolicitudCita(int Codigo, int estadoCita)
		{
			objDaoCita.EliminarSolCita(Codigo, estadoCita);
		}
		public void ObtenerInformacionSolicitudCita(DtoCita CitaSol)
		{
			objDaoCita.ObtenerSolCita(CitaSol);
		}
        public void ReprogramarCita(int idCita,DateTime fechaReprogramadac)
        {
            objDaoCita.ProReprogramarCita(idCita,fechaReprogramadac);
        }
        public void EvaluarReprogramarCita(DtoCita objdtoCita)
        {
            objDaoCita.EvalReprogramarCita(objdtoCita);
        }

        
    }
}
