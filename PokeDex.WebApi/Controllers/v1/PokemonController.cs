using Microsoft.AspNetCore.Mvc;
using PokeDex.Core.Application.Interfaces.Services;

namespace PokeDex.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class PokemonController : BaseApiController
    {
        private readonly IPokemonService _pokemonService;

        public PokemonController(IPokemonService pokemonService)
        {
            _pokemonService = pokemonService;
        }


    }
}
