using AutoMapper;
using Server.Core.src.Entity;
using Server.Core.src.RepoAbstract;
using Server.Service.src.DTO;
using Server.Service.src.ServiceAbstract;

namespace Server.Service.src.ServiceImplement
{
    public class CategoryService : BaseService<Category, CategoryReadDTO, CategoryCreateDTO, CategoryUpdateDTO, ICategoryRepo>, ICategoryService
    {
        public CategoryService(ICategoryRepo categoryRepo, IMapper mapper) : base(categoryRepo, mapper)
        {
        }
    }
}