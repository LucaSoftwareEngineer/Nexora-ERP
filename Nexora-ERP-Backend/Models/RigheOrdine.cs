using System;
using System.Collections.Generic;

namespace Nexora_ERP_Backend.Models;

public partial class RigheOrdine
{
    public int RigaId { get; set; }

    public int OrdineId { get; set; }

    public int ProdottoId { get; set; }

    public int Quantita { get; set; }

    public decimal PrezzoUnitario { get; set; }

    public decimal ScontoPerc { get; set; }

    public decimal AliquotaIva { get; set; }

    public decimal? ImportoRiga { get; set; }

    public virtual Ordini Ordine { get; set; } = null!;

    public virtual Prodotti Prodotto { get; set; } = null!;
}
