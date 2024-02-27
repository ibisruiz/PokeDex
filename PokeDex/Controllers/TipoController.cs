using Microsoft.AspNetCore.Mvc;
using PokeDex.Core.Application.Interfaces.Services;
using PokeDex.Core.Application.ViewModels.Region;
using PokeDex.Core.Application.ViewModels.Tipo;

namespace PokeDex.Controllers
{
    public class TipoController : Controller
    {
        private readonly ITipoService _tipoService;

        public TipoController(ITipoService tipoService)
        {
            _tipoService = tipoService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _tipoService.GetAllViewModel());
        }
        public IActionResult Create()
        {
            return View("SaveTipo", new SaveTipoViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(SaveTipoViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveTipo", vm);
            }
            await _tipoService.Add(vm);
            return RedirectToRoute(new { controller = "Tipo", action = "Index" });
        }

        public async Task<IActionResult> Edit(int id)
        {
            return View("SaveTipo", await _tipoService.GetByIdSaveViewModelT(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SaveTipoViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveTipo", vm);
            }
            await _tipoService.Update(vm);
            return RedirectToRoute(new { controller = "Tipo", action = "Index" });
        }

        public async Task<IActionResult> DeleteTipo(int id)
        {
            return View(await _tipoService.GetByIdSaveViewModelT(id));
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            await _tipoService.Delete(id);
            return RedirectToRoute(new { controller = "Tipo", action = "Index" });
        }
    }
}
