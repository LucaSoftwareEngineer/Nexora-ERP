using System;
using System.Collections.Generic;

namespace Nexora_ERP_Backend.Models;

public partial class Fornitori
{
    public int FornitoreId { get; set; }

    public string RagioneSociale { get; set; } = null!;

    public string PartitaIva { get; set; } = null!;

    public string? Email { get; set; }

    public string? Telefono { get; set; }

    public string? Citta { get; set; }

    public string Nazione { get; set; } = null!;

    public bool Attivo { get; set; }

    public virtual ICollection<Prodotti> Prodottis { get; set; } = new List<Prodotti>();
}
