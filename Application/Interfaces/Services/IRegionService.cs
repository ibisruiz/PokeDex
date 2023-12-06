using PokeDex.Core.Application.ViewModels.Region;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeDex.Core.Application.Interfaces.Services
{
    public interface IRegionService
    {
        Task<List<RegionViewModel>> GetAllViewModel();
        Task<SaveRegionViewModel> GetByIdSaveViewModelR(int id);
        Task Add(SaveRegionViewModel vm);
        Task Update(SaveRegionViewModel vm);
        Task Delete(int id);
    }
}
