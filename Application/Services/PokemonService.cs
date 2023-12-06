using Pokedex.Core.Domain.Entities;
using PokeDex.Core.Application.Interfaces.Repositories;
using PokeDex.Core.Application.Interfaces.Services;
using PokeDex.Core.Application.ViewModels;
using PokeDex.Core.Application.ViewModels.Pokemon;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace PokeDex.Core.Application.Services
{
    public class PokemonService : IPokemonService
    {


        private readonly IPokemonRepository _pokemonRepository;
        private readonly IRegionRepository _regionRepository;
        private readonly ITipoRepository _tipoRepository;

        public PokemonService(IPokemonRepository pokemonRepository, IRegionRepository regionRepository, ITipoRepository tipoRepository)
        {
            _pokemonRepository = pokemonRepository;
            _regionRepository = regionRepository;
            _tipoRepository = tipoRepository;
        }

        public async Task<List<PokemonViewModel>> GetAllViewModel() 
        {
            var pokemonList = await _pokemonRepository.GetAllWithIncludeAsync(new List<string> { "Region", "Tipo" });

            return pokemonList.Select(pokemon => new PokemonViewModel
            {
                Id = pokemon.Id,
                Nombre = pokemon.Nombre,
                ImageUrl = pokemon.ImageUrl,
                RegionId = pokemon.Region.Id,
                RegionName = pokemon.Region.Name,
                TipoId = pokemon.TipoId,
                TipoNombre = pokemon.Tipo.Name
            }).ToList();                        
        }

        public async Task<List<PokemonViewModel>> GetAllViewModelWithFilter(FilterPokemonViewModel filter)
        {
            var pokemonList = await _pokemonRepository.GetAllWithIncludeAsync(new List<string> { "Region", "Tipo" });

            var listViewModel = pokemonList.Select(pokemon => new PokemonViewModel
            {
                Id = pokemon.Id,
                Nombre = pokemon.Nombre,
                ImageUrl = pokemon.ImageUrl,
                RegionId = pokemon.Region.Id,
                RegionName = pokemon.Region.Name,
                TipoId = pokemon.TipoId,
                TipoNombre = pokemon.Tipo.Name

            }).ToList();

            if (filter.FilterRegionId != null)
            {
                listViewModel = listViewModel.Where(pokemon => pokemon.RegionId == filter.FilterRegionId.Value).ToList();
            }

            return listViewModel;

        }

        public async Task Add(SavePokemonViewModel vm)
        {
            Pokemon pokemon = new Pokemon();
            pokemon.Nombre = vm.Nombre;
            pokemon.ImageUrl = vm.ImageUrl;
            pokemon.RegionId = vm.RegionId;
            pokemon.TipoId = vm.TipoId;

            await _pokemonRepository.AddAsync(pokemon);
        }

        public async Task<SavePokemonViewModel> GetByIdSaveViewModel(int id)
        {
            var pokemon = await _pokemonRepository.GetByIdAsync(id);
            SavePokemonViewModel vm = new();
            vm.Id = pokemon.Id;
            vm.Nombre = pokemon.Nombre;
            vm.ImageUrl = pokemon.ImageUrl;
            vm.RegionId = pokemon.RegionId;
            vm.TipoId = pokemon.TipoId;
            
            return vm;
        }

        public async Task Update(SavePokemonViewModel vm)
        {
            Pokemon pokemon = new Pokemon();
            pokemon.Id = vm.Id;
            pokemon.Nombre = vm.Nombre;
            pokemon.ImageUrl = vm.ImageUrl;
            pokemon.RegionId = vm.RegionId;
            pokemon.TipoId = vm.TipoId;

            await _pokemonRepository.UpdateAsync(pokemon);
        }

        public async Task Delete(int id)
        {
            var pokemon = await _pokemonRepository.GetByIdAsync(id);
            await _pokemonRepository.DeleteAsync(pokemon);
        }
        
    }
}
