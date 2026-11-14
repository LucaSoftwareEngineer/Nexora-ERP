using System;
using System.Collections.Generic;

namespace Nexora_ERP_Backend.Models;

public partial class Ordini
{
    public int OrdineId { get; set; }

    public string NumeroOrdine { get; set; } = null!;

    public int ClienteId { get; set; }

    public int DipendenteId { get; set; }

    public DateOnly DataOrdine { get; set; }

    public string Stato { get; set; } = null!;

    public string? Note { get; set; }

    public virtual Clienti Cliente { get; set; } = null!;

    public virtual Dipendenti Dipendente { get; set; } = null!;

    public virtual ICollection<Fatture> Fattures { get; set; } = new List<Fatture>();

    public virtual ICollection<RigheOrdine> RigheOrdines { get; set; } = new List<RigheOrdine>();
}
