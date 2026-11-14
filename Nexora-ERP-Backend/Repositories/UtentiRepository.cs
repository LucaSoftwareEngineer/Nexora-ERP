using Nexora_ERP_Backend.Models;

namespace Nexora_ERP_Backend.Repositories;

public sealed class UtentiRepository(DevAziendaDbContext dbContext) : EfRepository<Utenti>(dbContext), IUtentiRepository;