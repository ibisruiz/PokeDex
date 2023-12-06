
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokeDex.Core.Application.ViewModels.Region;
using PokeDex.Core.Application.Interfaces.Repositories;
using Pokedex.Core.Domain.Entities;
using PokeDex.Core.Application.Interfaces.Services;

namespace PokeDex.Core.Application.Services
{
    public class RegionService : IRegionService
    {
        private readonly IRegionRepository _regionRepository;

        public RegionService(IRegionRepository regionRepository)
        {
            _regionRepository = regionRepository;
        }

        public async Task<List<RegionViewModel>> GetAllViewModel()
        {
            var regionList = await _regionRepository.GetAllWithIncludeAsync(new List<string> { "Pokemones" });

            return regionList.Select(region => new RegionViewModel 
            {
                Id = region.Id,
                Name = region.Name,
                PokemonQuantity = region.Pokemones.Count()
            }).ToList();      
        }

        public async Task Add(SaveRegionViewModel vm)
        {
            Region region = new Region();
            region.Id = vm.Id;
            region.Name = vm.Name;

            await _regionRepository.AddAsync(region);
        }

        public async Task<SaveRegionViewModel> GetByIdSaveViewModelR(int id)
        {
            var region = await _regionRepository.GetByIdAsync(id);
            SaveRegionViewModel vm = new();
            vm.Id = region.Id;
            vm.Name = region.Name;
            return vm;
        }

        public async Task Update(SaveRegionViewModel vm)
        {
            Region region = new Region();
            region.Id = vm.Id;
            region.Name = vm.Name;

            await _regionRepository.UpdateAsync(region);
        }

        public async Task Delete(int id)
        {
            var region = await _regionRepository.GetByIdAsync(id);
            await _regionRepository.DeleteAsync(region);
        }
    }
}
