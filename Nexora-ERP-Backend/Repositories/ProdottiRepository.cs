using Nexora_ERP_Backend.Models;

namespace Nexora_ERP_Backend.Repositories;

public sealed class ProdottiRepository(DevAziendaDbContext dbContext) : EfRepository<Prodotti>(dbContext), IProdottiRepository;