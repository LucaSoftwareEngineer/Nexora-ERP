using Nexora_ERP_Backend.Models;

namespace Nexora_ERP_Backend.Repositories;

public sealed class VwOrdiniRiepilogoRepository(DevAziendaDbContext dbContext) : EfReadOnlyRepository<VwOrdiniRiepilogo>(dbContext), IVwOrdiniRiepilogoRepository;