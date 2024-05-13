using AutoMapper;
using Server.Core.src.Entity;
using Server.Core.src.RepoAbstract;
using Server.Service.src.DTO;
using Server.Service.src.ServiceAbstract;

namespace Server.Service.src.ServiceImplement;

public class ReviewService : BaseService<Review, ReviewReadDTO, ReviewCreateDTO, ReviewUpdateDTO, IReviewRepo>, IReviewService
{
    private readonly IReviewRepo _reviewService;
    private readonly IProductRepo _productRepo;
    private readonly IUserRepo _userRepo;

    public ReviewService(IReviewRepo reviewRepo, IMapper mapper, IProductRepo productRepo, IUserRepo userRepo) : base(reviewRepo, mapper)
    {
        _reviewService = reviewRepo;
        _productRepo = productRepo;
        _userRepo = userRepo;
    }

    public Task<ReviewReadDTO> CreateOne(Guid userId, ReviewCreateDTO reviewCreateDto)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<ReviewReadDTO>> GetByProduct(Guid productId)
    {
        throw new NotImplementedException();
    }
}
