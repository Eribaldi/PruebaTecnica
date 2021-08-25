using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaTecnica.Models
{
    public class Estado
    {
        public int Id { get; set; }
        public Estados NombreEstado { get; set; }
        public DateTime FechaCreacion { get; set; }

        public enum Estados
        {
            Activo,
            Cancelado,
            Agente_Libre
        }
    }
}
