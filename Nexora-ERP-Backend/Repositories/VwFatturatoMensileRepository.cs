using Nexora_ERP_Backend.Models;

namespace Nexora_ERP_Backend.Repositories;

public sealed class VwFatturatoMensileRepository(DevAziendaDbContext dbContext) : EfReadOnlyRepository<VwFatturatoMensile>(dbContext), IVwFatturatoMensileRepository;