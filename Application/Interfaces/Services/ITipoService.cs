using PokeDex.Core.Application.ViewModels.Tipo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeDex.Core.Application.Interfaces.Services
{
    public interface ITipoService
    {
        Task<List<TipoViewModel>> GetAllViewModel();
        Task<SaveTipoViewModel> GetByIdSaveViewModelT(int id);
        Task Add(SaveTipoViewModel vm);        
        Task Update(SaveTipoViewModel vm);
        Task Delete(int id);
    }
}
