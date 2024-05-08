using Server.Core.src.Common;
using Server.Service.src.DTO;

namespace Server.Service.src.ServiceAbstract;

public interface IPaymentService
{
    public Task<IEnumerable<ReadPaymentDTO>> GetAllPaymentsOfOrders(QueryOptions options);
    public Task<IEnumerable<ReadPaymentDTO>> GetAllPaymentsOfUser(QueryOptions options);
    public Task<ReadPaymentDTO> CreatePaymentOfOrder(CreatePaymentDTO payment);
}
