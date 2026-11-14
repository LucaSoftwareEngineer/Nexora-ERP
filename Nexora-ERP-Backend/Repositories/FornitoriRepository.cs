using Nexora_ERP_Backend.Models;

namespace Nexora_ERP_Backend.Repositories;

public sealed class FornitoriRepository(DevAziendaDbContext dbContext) : EfRepository<Fornitori>(dbContext), IFornitoriRepository;