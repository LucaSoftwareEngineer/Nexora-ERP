using System;
using System.Collections.Generic;

namespace Nexora_ERP_Backend.Models;

public partial class Dipendenti
{
    public int DipendenteId { get; set; }

    public string Nome { get; set; } = null!;

    public string Cognome { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateOnly DataAssunzione { get; set; }

    public int RepartoId { get; set; }

    public int? ManagerId { get; set; }

    public decimal Stipendio { get; set; }

    public bool Attivo { get; set; }

    public virtual ICollection<Dipendenti> InverseManager { get; set; } = new List<Dipendenti>();

    public virtual Dipendenti? Manager { get; set; }

    public virtual ICollection<Ordini> Ordinis { get; set; } = new List<Ordini>();

    public virtual Reparti Reparto { get; set; } = null!;

    public virtual ICollection<Utenti> Utentis { get; set; } = new List<Utenti>();
}
