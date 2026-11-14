using System;
using System.Collections.Generic;

namespace Nexora_ERP_Backend.Models;

public partial class Prodotti
{
    public int ProdottoId { get; set; }

    public string Codice { get; set; } = null!;

    public string Descrizione { get; set; } = null!;

    public int CategoriaId { get; set; }

    public int FornitoreId { get; set; }

    public decimal PrezzoListino { get; set; }

    public decimal CostoAcquisto { get; set; }

    public decimal AliquotaIva { get; set; }

    public int Giacenza { get; set; }

    public int ScortaMinima { get; set; }

    public bool Attivo { get; set; }

    public DateTime DataCreazione { get; set; }

    public virtual Categorie Categoria { get; set; } = null!;

    public virtual Fornitori Fornitore { get; set; } = null!;

    public virtual ICollection<MovimentiMagazzino> MovimentiMagazzinos { get; set; } = new List<MovimentiMagazzino>();

    public virtual ICollection<RigheOrdine> RigheOrdines { get; set; } = new List<RigheOrdine>();

    public virtual ICollection<StoricoPrezzi> StoricoPrezzis { get; set; } = new List<StoricoPrezzi>();
}
