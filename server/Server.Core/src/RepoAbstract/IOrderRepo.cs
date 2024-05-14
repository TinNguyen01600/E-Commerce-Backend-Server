using Server.Core.Entity;
using Server.Core.src.Common;

namespace Server.Core.src.RepoAbstract;

public interface IOrderRepo : IBaseRepo<Order>
{
    Task<IEnumerable<Order>> GetByUser(Guid userId);
}
