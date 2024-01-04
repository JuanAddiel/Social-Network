using AutoMapper;
using SocialNetwork.Core.Application.Interface.Repositories;
using SocialNetwork.Core.Application.Interface.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Core.Application.Services
{
    public class GenericService<SaveViewModel, ViewModel, Entity> : IGenericService<SaveViewModel, ViewModel, Entity>
        where SaveViewModel : class
        where ViewModel : class
        where Entity : class
    {
        private readonly IGenericRepository<Entity> _repository;
        private readonly IMapper _mapper;
        public GenericService(IGenericRepository<Entity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public virtual async Task<SaveViewModel> Add(SaveViewModel entity)
        {
            Entity entry = _mapper.Map<Entity>(entity);
            entry = await _repository.Add(entry);
            SaveViewModel result = _mapper.Map<SaveViewModel>(entry);
            return result;

        }

        public virtual async Task<SaveViewModel> Delete(int id)
        {
            var entity = await _repository.GetById(id);
            entity = await _repository.Delete(entity);
            SaveViewModel result = _mapper.Map<SaveViewModel>(entity);
            return result;
        }

        public virtual async Task<IEnumerable<ViewModel>> GetAll()
        {
            var entities = await _repository.GetAll();
            return _mapper.Map<IEnumerable<ViewModel>>(entities);
        }

        public virtual async Task<SaveViewModel> GetById(int id)
        {
            var entity = await _repository.GetById(id);
            SaveViewModel result = _mapper.Map<SaveViewModel>(entity);
            return result;
        }

        public virtual async Task Update(SaveViewModel entity, int id)
        {
            Entity entry = _mapper.Map<Entity>(entity);
            await _repository.Update(entry, id);
        }
    }
}
