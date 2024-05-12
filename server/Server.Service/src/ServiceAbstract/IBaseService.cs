using Server.Core.src.Common;
using Server.Core.src.Entity;

namespace Server.Service.src.ServiceAbstract;

public interface IBaseService<T, TReadDTO, TCreateDTO, TUpdateDTO> where T : BaseEntity
{
    Task<IEnumerable<TReadDTO>> GetAll(QueryOptions options);
    Task<TReadDTO> GetOneById(Guid id);
    Task<TReadDTO> CreateOne(TCreateDTO createObject);
    Task<TReadDTO> UpdateOne(Guid id, TUpdateDTO updateObject);
    Task<bool> DeleteOne(Guid id);
}