using Nexora_ERP_Backend.Models;
using Nexora_ERP_Backend.Repositories;
using Nexora_ERP_Backend.Services.Interfaces;

namespace Nexora_ERP_Backend.Services.Implementations;

public sealed class RigheOrdineService(IRigheOrdineRepository repository) : BaseService<RigheOrdine>(repository), IRigheOrdineService;