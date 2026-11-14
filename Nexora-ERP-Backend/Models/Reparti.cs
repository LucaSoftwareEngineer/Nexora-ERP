using System;
using System.Collections.Generic;

namespace Nexora_ERP_Backend.Models;

public partial class Reparti
{
    public int RepartoId { get; set; }

    public string Nome { get; set; } = null!;

    public string? Sede { get; set; }

    public virtual ICollection<Dipendenti> Dipendentis { get; set; } = new List<Dipendenti>();
}
