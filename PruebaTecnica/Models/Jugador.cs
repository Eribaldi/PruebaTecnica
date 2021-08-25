using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PruebaTecnica.Models
{
    public class Jugador
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        [Display(Name = "Fecha de Nacimiento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime FechaNacimiento { get; set; }
        public string Pasaporte { get; set; }
        public string Direccion { get; set; }
        public string Sexo { get; set; }

        [Display(Name = "Equipo")]
        public int EquipoId { get; set; }
        public Equipo Equipo { get; set; }

        [Display(Name = "Estado")]
        public int EstadoId { get; set; }
        public Estado Estado { get; set; }


    }
}
