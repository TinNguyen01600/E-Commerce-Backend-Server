using AutoMapper;
using Server.Core.src.Common;
using Server.Core.src.Entity;
using Server.Core.src.RepoAbstract;
using Server.Service.src.DTO;
using Server.Service.src.ServiceAbstract;
using Server.Service.src.Shared;

namespace Server.Service.src.ServiceImplement
{
    public class ProductImageService : BaseService<ProductImage, ProductImageReadDTO, ProductImageCreateDTO, ProductImageUpdateDTO, IProductImageRepo>, IProductImageService
    {
        public ProductImageService(IProductImageRepo productImageRepo, IMapper mapper) : base(productImageRepo, mapper)
        {
        }
    }
}