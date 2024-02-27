using Microsoft.AspNetCore.Mvc;
using PokeDex.Core.Application.Interfaces.Services;
using PokeDex.Core.Application.ViewModels.Region;

namespace PokeDex.Controllers
{
    public class RegionController : Controller
    {
        private readonly IRegionService _regionService;

        public RegionController(IRegionService regionService)
        {
            _regionService = regionService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _regionService.GetAllViewModel());
        }
        public IActionResult Create()
        {
            return View("SaveRegion", new SaveRegionViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(SaveRegionViewModel vm) 
        {
            if (!ModelState.IsValid)
            {
                return View("SaveRegion", new SaveRegionViewModel());
            }
            await _regionService.Add(vm);
            return RedirectToRoute(new { controller = "Region", action = "Index" });
        }

        public async Task<IActionResult> Edit (int id)
        {
            return View("SaveRegion", await _regionService.GetByIdSaveViewModelR(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SaveRegionViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveRegion", new SaveRegionViewModel());
            }
            await _regionService.Update(vm);
            return RedirectToRoute(new { controller = "Region", action = "Index" });
        }

        public async Task<IActionResult> DeleteRegion(int id)
        {
            return View(await _regionService.GetByIdSaveViewModelR(id));
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            await _regionService.Delete(id);
            return RedirectToRoute(new { controller = "Region", action = "Index" });
        }
    }
}
