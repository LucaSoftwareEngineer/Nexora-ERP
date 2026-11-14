using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Nexora_ERP_Backend.Models;

public partial class DevAziendaDbContext : DbContext
{
    public DevAziendaDbContext()
    {
    }

    public DevAziendaDbContext(DbContextOptions<DevAziendaDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categorie> Categories { get; set; }

    public virtual DbSet<Clienti> Clientis { get; set; }

    public virtual DbSet<Dipendenti> Dipendentis { get; set; }

    public virtual DbSet<Fatture> Fattures { get; set; }

    public virtual DbSet<Fornitori> Fornitoris { get; set; }

    public virtual DbSet<MovimentiMagazzino> MovimentiMagazzinos { get; set; }

    public virtual DbSet<Ordini> Ordinis { get; set; }

    public virtual DbSet<Pagamenti> Pagamentis { get; set; }

    public virtual DbSet<Prodotti> Prodottis { get; set; }

    public virtual DbSet<Reparti> Repartis { get; set; }

    public virtual DbSet<RigheOrdine> RigheOrdines { get; set; }

    public virtual DbSet<StoricoPrezzi> StoricoPrezzis { get; set; }

    public virtual DbSet<Utenti> Utentis { get; set; }

    public virtual DbSet<VwFatturatoMensile> VwFatturatoMensiles { get; set; }

    public virtual DbSet<VwOrdiniRiepilogo> VwOrdiniRiepilogos { get; set; }

    public virtual DbSet<VwProdottiSottoScortum> VwProdottiSottoScorta { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categorie>(entity =>
        {
            entity.HasKey(e => e.CategoriaId);

            entity.ToTable("Categorie");

            entity.HasIndex(e => e.Nome, "UQ_Categorie_Nome").IsUnique();

            entity.Property(e => e.Descrizione).HasMaxLength(300);
            entity.Property(e => e.Nome).HasMaxLength(100);
        });

        modelBuilder.Entity<Clienti>(entity =>
        {
            entity.HasKey(e => e.ClienteId);

            entity.ToTable("Clienti");

            entity.HasIndex(e => e.RagioneSociale, "IX_Clienti_RagioneSociale");

            entity.HasIndex(e => e.PartitaIva, "UQ_Clienti_PIva").IsUnique();

            entity.Property(e => e.Attivo).HasDefaultValue(true, "DF_Clienti_Attivo");
            entity.Property(e => e.Cap)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Citta).HasMaxLength(100);
            entity.Property(e => e.DataCreazione).HasDefaultValueSql("(sysdatetime())", "DF_Clienti_DataCreazione");
            entity.Property(e => e.Email).HasMaxLength(150);
            entity.Property(e => e.Indirizzo).HasMaxLength(200);
            entity.Property(e => e.Nazione)
                .HasMaxLength(50)
                .HasDefaultValue("Italia", "DF_Clienti_Nazione");
            entity.Property(e => e.PartitaIva)
                .HasMaxLength(11)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Provincia)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.RagioneSociale).HasMaxLength(150);
            entity.Property(e => e.Telefono).HasMaxLength(30);
        });

        modelBuilder.Entity<Dipendenti>(entity =>
        {
            entity.HasKey(e => e.DipendenteId);

            entity.ToTable("Dipendenti");

            entity.HasIndex(e => e.ManagerId, "IX_Dipendenti_ManagerId");

            entity.HasIndex(e => e.RepartoId, "IX_Dipendenti_RepartoId");

            entity.HasIndex(e => e.Email, "UQ_Dipendenti_Email").IsUnique();

            entity.Property(e => e.Attivo).HasDefaultValue(true, "DF_Dipendenti_Attivo");
            entity.Property(e => e.Cognome).HasMaxLength(50);
            entity.Property(e => e.Email).HasMaxLength(150);
            entity.Property(e => e.Nome).HasMaxLength(50);
            entity.Property(e => e.Stipendio).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Manager).WithMany(p => p.InverseManager)
                .HasForeignKey(d => d.ManagerId)
                .HasConstraintName("FK_Dipendenti_Manager");

            entity.HasOne(d => d.Reparto).WithMany(p => p.Dipendentis)
                .HasForeignKey(d => d.RepartoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Dipendenti_Reparti");
        });

        modelBuilder.Entity<Fatture>(entity =>
        {
            entity.HasKey(e => e.FatturaId);

            entity.ToTable("Fatture");

            entity.HasIndex(e => e.ClienteId, "IX_Fatture_ClienteId");

            entity.HasIndex(e => e.DataFattura, "IX_Fatture_Data");

            entity.HasIndex(e => e.OrdineId, "IX_Fatture_OrdineId");

            entity.HasIndex(e => new { e.Anno, e.Numero }, "UQ_Fatture_AnnoNumero").IsUnique();

            entity.Property(e => e.Imponibile).HasColumnType("decimal(12, 2)");
            entity.Property(e => e.Iva).HasColumnType("decimal(12, 2)");
            entity.Property(e => e.Stato)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasDefaultValue("Emessa", "DF_Fatture_Stato");
            entity.Property(e => e.Totale).HasColumnType("decimal(12, 2)");

            entity.HasOne(d => d.Cliente).WithMany(p => p.Fattures)
                .HasForeignKey(d => d.ClienteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Fatture_Clienti");

            entity.HasOne(d => d.Ordine).WithMany(p => p.Fattures)
                .HasForeignKey(d => d.OrdineId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Fatture_Ordini");
        });

        modelBuilder.Entity<Fornitori>(entity =>
        {
            entity.HasKey(e => e.FornitoreId);

            entity.ToTable("Fornitori");

            entity.HasIndex(e => e.PartitaIva, "UQ_Fornitori_PIva").IsUnique();

            entity.Property(e => e.Attivo).HasDefaultValue(true, "DF_Fornitori_Attivo");
            entity.Property(e => e.Citta).HasMaxLength(100);
            entity.Property(e => e.Email).HasMaxLength(150);
            entity.Property(e => e.Nazione)
                .HasMaxLength(50)
                .HasDefaultValue("Italia", "DF_Fornitori_Nazione");
            entity.Property(e => e.PartitaIva)
                .HasMaxLength(11)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.RagioneSociale).HasMaxLength(150);
            entity.Property(e => e.Telefono).HasMaxLength(30);
        });

        modelBuilder.Entity<MovimentiMagazzino>(entity =>
        {
            entity.HasKey(e => e.MovimentoId);

            entity.ToTable("MovimentiMagazzino");

            entity.HasIndex(e => new { e.ProdottoId, e.DataMovimento }, "IX_Movimenti_ProdottoId");

            entity.Property(e => e.Causale).HasMaxLength(200);
            entity.Property(e => e.Tipo)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.HasOne(d => d.Prodotto).WithMany(p => p.MovimentiMagazzinos)
                .HasForeignKey(d => d.ProdottoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Movimenti_Prodotti");
        });

        modelBuilder.Entity<Ordini>(entity =>
        {
            entity.HasKey(e => e.OrdineId);

            entity.ToTable("Ordini");

            entity.HasIndex(e => e.ClienteId, "IX_Ordini_ClienteId");

            entity.HasIndex(e => e.DataOrdine, "IX_Ordini_DataOrdine");

            entity.HasIndex(e => e.DipendenteId, "IX_Ordini_DipendenteId");

            entity.HasIndex(e => e.NumeroOrdine, "UQ_Ordini_Numero").IsUnique();

            entity.Property(e => e.Note).HasMaxLength(500);
            entity.Property(e => e.NumeroOrdine)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Stato)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("Bozza", "DF_Ordini_Stato");

            entity.HasOne(d => d.Cliente).WithMany(p => p.Ordinis)
                .HasForeignKey(d => d.ClienteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ordini_Clienti");

            entity.HasOne(d => d.Dipendente).WithMany(p => p.Ordinis)
                .HasForeignKey(d => d.DipendenteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ordini_Dipendenti");
        });

        modelBuilder.Entity<Pagamenti>(entity =>
        {
            entity.HasKey(e => e.PagamentoId);

            entity.ToTable("Pagamenti");

            entity.HasIndex(e => e.FatturaId, "IX_Pagamenti_FatturaId");

            entity.Property(e => e.Importo).HasColumnType("decimal(12, 2)");
            entity.Property(e => e.Metodo)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.Fattura).WithMany(p => p.Pagamentis)
                .HasForeignKey(d => d.FatturaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Pagamenti_Fatture");
        });

        modelBuilder.Entity<Prodotti>(entity =>
        {
            entity.HasKey(e => e.ProdottoId);

            entity.ToTable("Prodotti", tb => tb.HasTrigger("trg_Prodotti_StoricoPrezzi"));

            entity.HasIndex(e => e.CategoriaId, "IX_Prodotti_CategoriaId");

            entity.HasIndex(e => e.FornitoreId, "IX_Prodotti_FornitoreId");

            entity.HasIndex(e => e.Codice, "UQ_Prodotti_Codice").IsUnique();

            entity.Property(e => e.AliquotaIva)
                .HasDefaultValue(22m, "DF_Prodotti_Iva")
                .HasColumnType("decimal(4, 2)");
            entity.Property(e => e.Attivo).HasDefaultValue(true, "DF_Prodotti_Attivo");
            entity.Property(e => e.Codice)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CostoAcquisto).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.DataCreazione).HasDefaultValueSql("(sysdatetime())", "DF_Prodotti_DataCreazione");
            entity.Property(e => e.Descrizione).HasMaxLength(200);
            entity.Property(e => e.PrezzoListino).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Categoria).WithMany(p => p.Prodottis)
                .HasForeignKey(d => d.CategoriaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Prodotti_Categorie");

            entity.HasOne(d => d.Fornitore).WithMany(p => p.Prodottis)
                .HasForeignKey(d => d.FornitoreId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Prodotti_Fornitori");
        });

        modelBuilder.Entity<Reparti>(entity =>
        {
            entity.HasKey(e => e.RepartoId);

            entity.ToTable("Reparti");

            entity.HasIndex(e => e.Nome, "UQ_Reparti_Nome").IsUnique();

            entity.Property(e => e.Nome).HasMaxLength(100);
            entity.Property(e => e.Sede).HasMaxLength(100);
        });

        modelBuilder.Entity<RigheOrdine>(entity =>
        {
            entity.HasKey(e => e.RigaId);

            entity.ToTable("RigheOrdine");

            entity.HasIndex(e => e.ProdottoId, "IX_RigheOrdine_ProdottoId");

            entity.HasIndex(e => new { e.OrdineId, e.ProdottoId }, "UQ_RigheOrdine_OrdineProdotto").IsUnique();

            entity.Property(e => e.AliquotaIva).HasColumnType("decimal(4, 2)");
            entity.Property(e => e.ImportoRiga)
                .HasComputedColumnSql("(CONVERT([decimal](12,2),([Quantita]*[PrezzoUnitario])*((1)-[ScontoPerc]/(100.0))))", true)
                .HasColumnType("decimal(12, 2)");
            entity.Property(e => e.PrezzoUnitario).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ScontoPerc).HasColumnType("decimal(5, 2)");

            entity.HasOne(d => d.Ordine).WithMany(p => p.RigheOrdines)
                .HasForeignKey(d => d.OrdineId)
                .HasConstraintName("FK_RigheOrdine_Ordini");

            entity.HasOne(d => d.Prodotto).WithMany(p => p.RigheOrdines)
                .HasForeignKey(d => d.ProdottoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RigheOrdine_Prodotti");
        });

        modelBuilder.Entity<StoricoPrezzi>(entity =>
        {
            entity.HasKey(e => e.StoricoId);

            entity.ToTable("StoricoPrezzi");

            entity.Property(e => e.DataModifica).HasDefaultValueSql("(sysdatetime())", "DF_StoricoPrezzi_Data");
            entity.Property(e => e.PrezzoNuovo).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.PrezzoPrecedente).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Utente).HasMaxLength(128);

            entity.HasOne(d => d.Prodotto).WithMany(p => p.StoricoPrezzis)
                .HasForeignKey(d => d.ProdottoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StoricoPrezzi_Prodotti");
        });

        modelBuilder.Entity<Utenti>(entity =>
        {
            entity.HasKey(e => e.UtenteId);

            entity.ToTable("Utenti");

            entity.HasIndex(e => e.Username, "UQ_Utenti_Username").IsUnique();

            entity.Property(e => e.Attivo).HasDefaultValue(true, "DF_Utenti_Attivo");
            entity.Property(e => e.PasswordHash).HasMaxLength(32);
            entity.Property(e => e.Ruolo).HasMaxLength(30);
            entity.Property(e => e.Username).HasMaxLength(50);

            entity.HasOne(d => d.Dipendente).WithMany(p => p.Utentis)
                .HasForeignKey(d => d.DipendenteId)
                .HasConstraintName("FK_Utenti_Dipendenti");
        });

        modelBuilder.Entity<VwFatturatoMensile>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_FatturatoMensile");

            entity.Property(e => e.Imponibile).HasColumnType("decimal(38, 2)");
            entity.Property(e => e.Iva).HasColumnType("decimal(38, 2)");
            entity.Property(e => e.Totale).HasColumnType("decimal(38, 2)");
        });

        modelBuilder.Entity<VwOrdiniRiepilogo>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_OrdiniRiepilogo");

            entity.Property(e => e.Cliente).HasMaxLength(150);
            entity.Property(e => e.Commerciale).HasMaxLength(101);
            entity.Property(e => e.Imponibile).HasColumnType("decimal(38, 2)");
            entity.Property(e => e.NumeroOrdine)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Stato)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VwProdottiSottoScortum>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_ProdottiSottoScorta");

            entity.Property(e => e.Categoria).HasMaxLength(100);
            entity.Property(e => e.Codice)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Descrizione).HasMaxLength(200);
            entity.Property(e => e.Fornitore).HasMaxLength(150);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
