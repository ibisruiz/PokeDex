using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PokeDex.Core.Application.ViewModels.Pokemon
{
    public class PokemonViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string ImageUrl { get; set; }

        public int RegionId { get; set; }
        public string RegionName { get; set; }

        public int TipoId { get; set; }
        public string TipoNombre { get; set; }

    }
}
