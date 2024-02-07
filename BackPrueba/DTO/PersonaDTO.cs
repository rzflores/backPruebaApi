using System.ComponentModel.DataAnnotations;

namespace BackPrueba.DTO
{
    public class PersonaDTO
    {
        [Required]
        public string? TipoDocumento { get; set; }
        [Required]
        [MaxLength(8)]
        public string? NumeroDocumento { get; set; }
        [Required]
        public string? Nombres { get; set; }
        [Required]
        public string? ApellidoPaterno { get; set; }
        [Required]
        public string? ApellidoMaterno { get; set; }
        [Required]
        [MaxLength(9)]
        public string? NumeroTelefono { get; set; }
        [Required]
        [EmailAddress]
        public string? CorreoElectronico { get; set; }
        [Required]
        public string? Direccion { get; set; }
        
    }
}
