using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDesarrolloServiciosWeb.Utility
{
    public static class SD
    {
        /*creación de los roles*/
        public const string Role_Cliente = "Cliente";
        public const string Role_Comp = "Company";
        public const string Role_Admin = "Admin";
        public const string Role_Empleado = "Empleado";

		public const string EstadoPendiente = "Pendiente";
		public const string EstadoAprobado = "Aprobado";
		public const string EstadoProceso = "Proceso";
		public const string EstadoEnviado = "Enviado";
		public const string EstadoCancelado = "Cancelado";
		public const string EstadoRembolso = "Rembolso";

		public const string EstadoPagoPendiente = "Pendiente";
		public const string EstadoPagoAprobado = "Aprobado";
		public const string PagoEstadoRetrasado = "PagoRetrasado";
		public const string PagoEstacoRechazado = "Rechazado";

	}
}
