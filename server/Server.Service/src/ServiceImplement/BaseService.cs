using AutoMapper;
using Server.Core.src.Common;
using Server.Core.src.Entity;
using Server.Core.src.RepoAbstract;
using Server.Service.src.ServiceAbstract;
using Server.Service.src.Shared;

namespace Server.Service.src.ServiceImplement;

public class BaseService<T, TReadDTO, TCreateDTO, TUpdateDTO, TRepo> : IBaseService<T, TReadDTO, TCreateDTO, TUpdateDTO>
where T : BaseEntity
where TRepo : IBaseRepo<T>
{
    protected readonly TRepo _repo;
    protected IMapper _mapper;

    public BaseService(TRepo repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<IEnumerable<TReadDTO>> GetAll(QueryOptions options)
    {
        var r = await _repo.GetAllAsync(options);
        return _mapper.Map<IEnumerable<T>, IEnumerable<TReadDTO>>(r);
    }
    public virtual async Task<TReadDTO> CreateOne(TCreateDTO createObject)
    {
        var result = await _repo.CreateOneAsync(_mapper.Map<TCreateDTO, T>(createObject));
        return _mapper.Map<T, TReadDTO>(result);
    }

    async Task<bool> IBaseService<T, TReadDTO, TCreateDTO, TUpdateDTO>.DeleteOne(Guid id)
    {
        var foundItem = await _repo.GetOneByIdAsync(id);
        if (foundItem is not null)
        {
            await _repo.DeleteOneAsync(foundItem);
            return true;
        }
        else
        {
            return false;
        }
    }

    async Task<TReadDTO> IBaseService<T, TReadDTO, TCreateDTO, TUpdateDTO>.GetOneById(Guid id)
    {
        var result = await _repo.GetOneByIdAsync(id);
        if (result is not null)
        {
            return _mapper.Map<T, TReadDTO>(result);
        }
        else
        {
            throw CustomException.NotFoundException("Id not found");
        }
    }

    async Task<TReadDTO> IBaseService<T, TReadDTO, TCreateDTO, TUpdateDTO>.UpdateOne(Guid id, TUpdateDTO updateObject)
    {
        var foundItem = _repo.GetOneByIdAsync(id);
        if (foundItem is not null)
        {
            var a = await _mapper.Map(updateObject, foundItem);
            var b = await _repo.UpdateOneAsync(a);
            return _mapper.Map<T, TReadDTO>(b);
        }
        else
        {
            throw CustomException.NotFoundException("Id not found");
        }
    }
}