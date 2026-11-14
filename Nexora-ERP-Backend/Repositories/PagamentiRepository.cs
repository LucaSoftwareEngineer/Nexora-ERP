using Nexora_ERP_Backend.Models;

namespace Nexora_ERP_Backend.Repositories;

public sealed class PagamentiRepository(DevAziendaDbContext dbContext) : EfRepository<Pagamenti>(dbContext), IPagamentiRepository;