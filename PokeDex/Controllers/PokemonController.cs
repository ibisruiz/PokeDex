using Microsoft.AspNetCore.Mvc;
using PokeDex.Core.Application.Interfaces.Services;
using PokeDex.Core.Application.ViewModels.Pokemon;

namespace PokeDex.Controllers 
{
    public class PokemonController : Controller
    {
        private readonly IPokemonService _pokemonService;
        private readonly IRegionService _regionService;
        private readonly ITipoService _tipoService;

        public PokemonController(IPokemonService pokemonService, IRegionService regionService, ITipoService tipoService) 
        {
            _pokemonService = pokemonService;
            _regionService = regionService;
            _tipoService = tipoService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _pokemonService.GetAllViewModel());
        }

        public async Task<IActionResult> Create()
        {            
            SavePokemonViewModel vm = new();
            vm.Regiones = await _regionService.GetAllViewModel();
            vm.Tipos = await _tipoService.GetAllViewModel();
            return View("SavePokemon", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SavePokemonViewModel vm)
        { 

            if (!ModelState.IsValid)
            {
                vm.Regiones = await _regionService.GetAllViewModel();
                vm.Tipos = await _tipoService.GetAllViewModel();
                return View("SavePokemon", vm);
            }

            await _pokemonService.Add(vm);
            return RedirectToRoute(new { controller = "Pokemon", action = "Index" });

        }

        public async Task<IActionResult> Edit(int id)
        {
            SavePokemonViewModel vm = await _pokemonService.GetByIdSaveViewModel(id);
            vm.Regiones = await _regionService.GetAllViewModel();
            vm.Tipos = await _tipoService.GetAllViewModel();
            return View("SavePokemon", vm);
        }
        

        [HttpPost]
        public async Task<IActionResult> Edit(SavePokemonViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                vm.Regiones = await _regionService.GetAllViewModel();
                vm.Tipos = await _tipoService.GetAllViewModel();
                return View("SavePokemon", vm);
            }
            await _pokemonService.Update(vm);
            return RedirectToRoute(new { controller = "Pokemon", action = "Index" });
        }

        public async Task<IActionResult> DeletePokemon(int id)
        {
            return View(await _pokemonService.GetByIdSaveViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            await _pokemonService.Delete(id);
            return RedirectToRoute(new { controller = "Pokemon", action = "Index" });
        }

    }
}
