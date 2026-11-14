using Nexora_ERP_Backend.Models;

namespace Nexora_ERP_Backend.Repositories;

public sealed class ClientiRepository(DevAziendaDbContext dbContext) : EfRepository<Clienti>(dbContext), IClientiRepository;