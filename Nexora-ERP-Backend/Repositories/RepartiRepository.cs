using Nexora_ERP_Backend.Models;

namespace Nexora_ERP_Backend.Repositories;

public sealed class RepartiRepository(DevAziendaDbContext dbContext) : EfRepository<Reparti>(dbContext), IRepartiRepository;