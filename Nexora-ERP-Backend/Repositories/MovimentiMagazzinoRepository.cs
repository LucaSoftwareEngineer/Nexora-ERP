using Nexora_ERP_Backend.Models;

namespace Nexora_ERP_Backend.Repositories;

public sealed class MovimentiMagazzinoRepository(DevAziendaDbContext dbContext) : EfRepository<MovimentiMagazzino>(dbContext), IMovimentiMagazzinoRepository;