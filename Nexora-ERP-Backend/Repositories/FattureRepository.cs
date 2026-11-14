using Nexora_ERP_Backend.Models;

namespace Nexora_ERP_Backend.Repositories;

public sealed class FattureRepository(DevAziendaDbContext dbContext) : EfRepository<Fatture>(dbContext), IFattureRepository;