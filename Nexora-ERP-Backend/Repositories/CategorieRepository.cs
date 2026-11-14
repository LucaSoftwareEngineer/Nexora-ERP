using Nexora_ERP_Backend.Models;

namespace Nexora_ERP_Backend.Repositories;

public sealed class CategorieRepository(DevAziendaDbContext dbContext) : EfRepository<Categorie>(dbContext), ICategorieRepository;