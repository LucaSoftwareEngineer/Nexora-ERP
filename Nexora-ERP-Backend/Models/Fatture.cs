using System;
using System.Collections.Generic;

namespace Nexora_ERP_Backend.Models;

public partial class Fatture
{
    public int FatturaId { get; set; }

    public short Anno { get; set; }

    public int Numero { get; set; }

    public int OrdineId { get; set; }

    public int ClienteId { get; set; }

    public DateOnly DataFattura { get; set; }

    public DateOnly DataScadenza { get; set; }

    public decimal Imponibile { get; set; }

    public decimal Iva { get; set; }

    public decimal Totale { get; set; }

    public string Stato { get; set; } = null!;

    public virtual Clienti Cliente { get; set; } = null!;

    public virtual Ordini Ordine { get; set; } = null!;

    public virtual ICollection<Pagamenti> Pagamentis { get; set; } = new List<Pagamenti>();
}
