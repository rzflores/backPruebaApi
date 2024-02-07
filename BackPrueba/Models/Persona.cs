using System;
using System.Collections.Generic;

namespace BackPrueba.Models;

public partial class Persona
{
    public Guid Id { get; set; }

    public string? TipoDocumento { get; set; }

    public string? NumeroDocumento { get; set; }

    public string? Nombres { get; set; }

    public string? ApellidoPaterno { get; set; }

    public string? ApellidoMaterno { get; set; }

    public string? NumeroTelefono { get; set; }

    public string? CorreoElectronico { get; set; }

    public string? Direccion { get; set; }

    public int? Eliminado { get; set; }
}
