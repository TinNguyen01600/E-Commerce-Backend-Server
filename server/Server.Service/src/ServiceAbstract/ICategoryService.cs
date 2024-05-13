using Server.Core.src.Common;
using Server.Core.src.Entity;
using Server.Service.src.DTO;

namespace Server.Service.src.ServiceAbstract
{
    public interface ICategoryService : IBaseService<Category, CategoryReadDTO, CategoryCreateDTO, CategoryUpdateDTO>
    {
    }
}