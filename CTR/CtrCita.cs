﻿using System;
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
		public void registrarSolicitudCita(DateTime fechasol, string obsCita, DateTime fechacreacion, int idEstado, int idTipo, string DNIUsuario)
		{
			objDaoCita.RegistrarSolCita(fechasol, obsCita, fechacreacion, idEstado, idTipo, DNIUsuario);
		}
        public void registrarCita(DtoCita objDtoCita)
        {
            objDaoCita.RegistrarSolCita2(objDtoCita);
        }
        public void actualizarSolicitudCita(int Codigo, DateTime fechahorasolicitada, string dudaconsulta, int idTipoCita)
		{
			objDaoCita.ActualizarSolCita(Codigo, fechahorasolicitada, dudaconsulta, idTipoCita);
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

    }
}
