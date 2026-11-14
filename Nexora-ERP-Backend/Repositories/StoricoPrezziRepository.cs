using Nexora_ERP_Backend.Models;

namespace Nexora_ERP_Backend.Repositories;

public sealed class StoricoPrezziRepository(DevAziendaDbContext dbContext) : EfRepository<StoricoPrezzi>(dbContext), IStoricoPrezziRepository;