using System;
using System.Collections.Generic;

namespace Nexora_ERP_Backend.Models;

public partial class VwOrdiniRiepilogo
{
    public int OrdineId { get; set; }

    public string NumeroOrdine { get; set; } = null!;

    public DateOnly DataOrdine { get; set; }

    public string Stato { get; set; } = null!;

    public int ClienteId { get; set; }

    public string Cliente { get; set; } = null!;

    public string Commerciale { get; set; } = null!;

    public int? NumeroRighe { get; set; }

    public decimal Imponibile { get; set; }
}
