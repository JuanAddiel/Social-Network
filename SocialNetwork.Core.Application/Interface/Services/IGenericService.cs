using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Core.Application.Interface.Services
{
    public interface IGenericService<SaveViewModel,ViewModel,Entity>
        where SaveViewModel : class
        where ViewModel : class
        where Entity : class
    {
        Task<IEnumerable<ViewModel>> GetAll();
        Task<SaveViewModel> GetById(int id);
        Task<SaveViewModel> Add(SaveViewModel entity);
        Task Update(SaveViewModel entity, int id);
        Task<SaveViewModel> Delete(int id);
    }
}
