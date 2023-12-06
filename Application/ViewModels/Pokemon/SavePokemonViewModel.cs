using PokeDex.Core.Application.ViewModels.Region;
using PokeDex.Core.Application.ViewModels.Tipo;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeDex.Core.Application.ViewModels.Pokemon
{
    public class SavePokemonViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Debe colocar el nombre del Pokemon")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Debe agregar una imagen")]
        public string ImageUrl { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Debe agregar una region")]
        public int RegionId { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Debe agregar un tipo")]
        public int TipoId { get; set; }

        public List <RegionViewModel>? Regiones { get; set; }
        public List<TipoViewModel>? Tipos { get; set; }


    }
}
