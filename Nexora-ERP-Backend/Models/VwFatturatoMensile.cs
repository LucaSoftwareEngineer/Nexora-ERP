using System;
using System.Collections.Generic;

namespace Nexora_ERP_Backend.Models;

public partial class VwFatturatoMensile
{
    public int? Anno { get; set; }

    public int? Mese { get; set; }

    public int? NumeroFatture { get; set; }

    public decimal? Imponibile { get; set; }

    public decimal? Iva { get; set; }

    public decimal? Totale { get; set; }
}
