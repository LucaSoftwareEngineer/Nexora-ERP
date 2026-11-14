using System;
using System.Collections.Generic;

namespace Nexora_ERP_Backend.Models;

public partial class Pagamenti
{
    public int PagamentoId { get; set; }

    public int FatturaId { get; set; }

    public DateOnly DataPagamento { get; set; }

    public decimal Importo { get; set; }

    public string Metodo { get; set; } = null!;

    public virtual Fatture Fattura { get; set; } = null!;
}
