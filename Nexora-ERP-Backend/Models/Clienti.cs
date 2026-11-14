using System;
using System.Collections.Generic;

namespace Nexora_ERP_Backend.Models;

public partial class Clienti
{
    public int ClienteId { get; set; }

    public string RagioneSociale { get; set; } = null!;

    public string PartitaIva { get; set; } = null!;

    public string? Email { get; set; }

    public string? Telefono { get; set; }

    public string? Indirizzo { get; set; }

    public string? Citta { get; set; }

    public string? Cap { get; set; }

    public string? Provincia { get; set; }

    public string Nazione { get; set; } = null!;

    public DateTime DataCreazione { get; set; }

    public bool Attivo { get; set; }

    public virtual ICollection<Fatture> Fattures { get; set; } = new List<Fatture>();

    public virtual ICollection<Ordini> Ordinis { get; set; } = new List<Ordini>();
}
