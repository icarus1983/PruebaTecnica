using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PruebaTecnica.Models
{
    public partial class Persona
    {
        public Guid Id { get; set; }
        public string Run { get; set; }
        [Required]
        public int RunCuerpo { get; set; }
        [Required]
        public string RunDigito { get; set; }
        public string Nombre { get; set; }
        [Required]
        public string Nombres { get; set; }
        [Required]
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Email { get; set; }
        [Required]
        public short SexoCodigo { get; set; }
        
        public DateTime? FechaNacimiento { get; set; }
        public short? RegionCodigo { get; set; }
        public short? CiudadCodigo { get; set; }
        public short? ComunaCodigo { get; set; }
        public string Direccion { get; set; }
        public int? Telefono { get; set; }
        public string Observaciones { get; set; }

        public virtual Comuna Comuna { get; set; }
        public virtual Sexo SexoCodigoNavigation { get; set; }
    }
}
