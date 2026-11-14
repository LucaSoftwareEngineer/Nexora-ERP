using System;
using System.Collections.Generic;

namespace Nexora_ERP_Backend.Models;

public partial class Utenti
{
    public int UtenteId { get; set; }

    public string Username { get; set; } = null!;

    public byte[] PasswordHash { get; set; } = null!;

    public string Ruolo { get; set; } = null!;

    public int? DipendenteId { get; set; }

    public DateTime? UltimoAccesso { get; set; }

    public bool Attivo { get; set; }

    public virtual Dipendenti? Dipendente { get; set; }
}
