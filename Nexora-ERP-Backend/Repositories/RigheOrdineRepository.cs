using Nexora_ERP_Backend.Models;

namespace Nexora_ERP_Backend.Repositories;

public sealed class RigheOrdineRepository(DevAziendaDbContext dbContext) : EfRepository<RigheOrdine>(dbContext), IRigheOrdineRepository;