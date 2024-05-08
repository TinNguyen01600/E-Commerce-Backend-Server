using Server.Core.src.Common;
using Server.Core.src.Entity;

namespace Server.Core.src.RepoAbstract;

public interface IPaymentRepo
{
    public Task<List<Payment>> GetAllPaymentsOfOrders(QueryOptions options);
    public Task<List<Payment>> GetAllPaymentsOfUser(QueryOptions options);
    public Task<Payment> CreatePaymentOfOrder(Payment payment);
}
