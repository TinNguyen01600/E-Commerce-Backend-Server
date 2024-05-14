using AutoMapper;
using Server.Core.src.Entity;
using Server.Core.src.RepoAbstract;
using Server.Service.src.DTO;
using Server.Service.src.ServiceAbstract;
using Server.Service.src.Shared;

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

    public async Task<ReviewReadDTO> CreateOne(Guid userId, ReviewCreateDTO reviewCreateDto)
    {
        var newReview = _mapper.Map<ReviewCreateDTO, Review>(reviewCreateDto);
        var foundProduct = await _productRepo.GetOneByIdAsync(reviewCreateDto.ProductId);
        var foundUser = await _userRepo.GetOneByIdAsync(userId);
        if (foundProduct != null && foundUser != null)
        {
            newReview.ProductId = foundProduct.Id;
            newReview.UserId = foundUser.Id;
            var result = await _repo.CreateOneAsync(newReview);
            return _mapper.Map<Review, ReviewReadDTO>(result);
        }
        throw CustomException.NotFoundException("User or product not found");
    }

    public async Task<IEnumerable<ReviewReadDTO>> GetByProduct(Guid productId)
    {
        var foundProduct = _productRepo.GetOneByIdAsync(productId);
        if (foundProduct is not null)
        {
            var result = await _repo.GetByProduct(productId);
            return _mapper.Map<IEnumerable<Review>, IEnumerable<ReviewReadDTO>>(result);
        }
        else
        {
            throw CustomException.NotFoundException();
        }
    }
}
