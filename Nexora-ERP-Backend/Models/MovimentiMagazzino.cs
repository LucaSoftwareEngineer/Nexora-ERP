using System;
using System.Collections.Generic;

namespace Nexora_ERP_Backend.Models;

public partial class MovimentiMagazzino
{
    public int MovimentoId { get; set; }

    public int ProdottoId { get; set; }

    public DateOnly DataMovimento { get; set; }

    public string Tipo { get; set; } = null!;

    public int Quantita { get; set; }

    public string? Causale { get; set; }

    public virtual Prodotti Prodotto { get; set; } = null!;
}
