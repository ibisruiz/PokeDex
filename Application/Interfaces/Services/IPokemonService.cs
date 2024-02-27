using PokeDex.Core.Application.ViewModels;
using PokeDex.Core.Application.ViewModels.Pokemon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeDex.Core.Application.Interfaces.Services
{
    public interface IPokemonService
    {
        Task<List<PokemonViewModel>> GetAllViewModel();
        Task<SavePokemonViewModel> GetByIdSaveViewModel(int id);
        Task Add(SavePokemonViewModel vm);
        Task Update(SavePokemonViewModel vm);
        Task Delete(int id);
        Task<List<PokemonViewModel>> GetAllViewModelWithFilter(FilterPokemonViewModel filter);

    }
}
