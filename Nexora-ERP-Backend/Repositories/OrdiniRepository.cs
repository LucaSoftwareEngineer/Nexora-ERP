using Nexora_ERP_Backend.Models;

namespace Nexora_ERP_Backend.Repositories;

public sealed class OrdiniRepository(DevAziendaDbContext dbContext) : EfRepository<Ordini>(dbContext), IOrdiniRepository;