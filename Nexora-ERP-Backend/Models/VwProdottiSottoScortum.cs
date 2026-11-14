using System;
using System.Collections.Generic;

namespace Nexora_ERP_Backend.Models;

public partial class VwProdottiSottoScortum
{
    public int ProdottoId { get; set; }

    public string Codice { get; set; } = null!;

    public string Descrizione { get; set; } = null!;

    public string Categoria { get; set; } = null!;

    public string Fornitore { get; set; } = null!;

    public int Giacenza { get; set; }

    public int ScortaMinima { get; set; }

    public int? Mancanti { get; set; }
}
