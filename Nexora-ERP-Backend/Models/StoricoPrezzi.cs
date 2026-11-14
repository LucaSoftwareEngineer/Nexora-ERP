using System;
using System.Collections.Generic;

namespace Nexora_ERP_Backend.Models;

public partial class StoricoPrezzi
{
    public int StoricoId { get; set; }

    public int ProdottoId { get; set; }

    public decimal PrezzoPrecedente { get; set; }

    public decimal PrezzoNuovo { get; set; }

    public DateTime DataModifica { get; set; }

    public string? Utente { get; set; }

    public virtual Prodotti Prodotto { get; set; } = null!;
}
