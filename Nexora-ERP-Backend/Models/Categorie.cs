using System;
using System.Collections.Generic;

namespace Nexora_ERP_Backend.Models;

public partial class Categorie
{
    public int CategoriaId { get; set; }

    public string Nome { get; set; } = null!;

    public string? Descrizione { get; set; }

    public virtual ICollection<Prodotti> Prodottis { get; set; } = new List<Prodotti>();
}
