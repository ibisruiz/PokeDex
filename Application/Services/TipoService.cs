using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokeDex.Core.Application.ViewModels.Tipo;
using PokeDex.Core.Application.Interfaces.Repositories;
using Pokedex.Core.Domain.Entities;
using PokeDex.Core.Application.Interfaces.Services;

namespace PokeDex.Core.Application.Services
{
    public class TipoService : ITipoService
    {
        private readonly ITipoRepository _tipoRepository;

        public TipoService(ITipoRepository tipoRepository)
        {
            _tipoRepository = tipoRepository;
        }

        public async Task<List<TipoViewModel>> GetAllViewModel()
        {
            var tipoList = await _tipoRepository.GetAllWithIncludeAsync(new List<string> { "Pokemones" });
            return tipoList.Select(tipo => new TipoViewModel
            {
                Id = tipo.Id,
                Name = tipo.Name,
                PokemonQuantity = tipo.Pokemones.Count()
            }).ToList();
        }

        public async Task Add(SaveTipoViewModel vm)
        {
            Tipo tipo = new Tipo();
            tipo.Id = vm.Id;
            tipo.Name = vm.Name;

            await _tipoRepository.AddAsync(tipo);
        }

        public async Task<SaveTipoViewModel> GetByIdSaveViewModelT(int id)
        {
            var tipo = await _tipoRepository.GetByIdAsync(id);
            SaveTipoViewModel vm = new();
            vm.Id = tipo.Id;
            vm.Name = tipo.Name;
            return vm;
        }

        public async Task Update(SaveTipoViewModel vm)
        {
            Tipo tipo = new Tipo();
            tipo.Id = vm.Id;
            tipo.Name = vm.Name;

            await _tipoRepository.UpdateAsync(tipo);
        }

        public async Task Delete(int id)
        {
            var tipo = await _tipoRepository.GetByIdAsync(id);
            await _tipoRepository.DeleteAsync(tipo);
        }
    }
}
