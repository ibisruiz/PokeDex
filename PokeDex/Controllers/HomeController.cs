using Microsoft.AspNetCore.Mvc;
using Pokedex.Infrastructure.Persistence.Contexts;
using PokeDex.Core.Application.Interfaces.Services;
using PokeDex.Core.Application.ViewModels;
using PokeDex.Core.Application.ViewModels.Pokemon;
using System.Diagnostics;

namespace PokeDex.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPokemonService _pokemonService;
        private readonly IRegionService _regionService;

        public HomeController(IPokemonService pokemonService, IRegionService regionService)
        {
            _pokemonService = pokemonService;
            _regionService = regionService;
        }

        public async Task<IActionResult> Index(FilterPokemonViewModel vm)
        {
            ViewBag.regions = await _regionService.GetAllViewModel();
            return View(await _pokemonService.GetAllViewModelWithFilter(vm));
        }

    }
}


//updated as of 12/29/2023