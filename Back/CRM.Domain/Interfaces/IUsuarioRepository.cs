using CRM.Domain.Entities;
using CRM.Domain.Interfaces.Base;

namespace CRM.Domain.Interfaces;

public interface IUsuarioRepository :
    IAddRepository<Usuario>,
    IReadRepository<Usuario>,
    IRemoveRepository<Usuario>,
    IUpdateRepository<Usuario>,
    IUnitOfWork;