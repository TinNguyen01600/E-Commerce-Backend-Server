using Server.Core.src.Common;
using Server.Core.src.Entity;
using Server.Service.src.DTO;

namespace Server.Service.src.ServiceAbstract;

public interface IReviewService : IBaseService<Review, ReviewReadDTO, ReviewCreateDTO, ReviewUpdateDTO>
{
    Task<IEnumerable<ReviewReadDTO>> GetByProduct(Guid productId);
    Task<ReviewReadDTO> CreateOne(Guid userId, ReviewCreateDTO reviewCreateDto);
}
