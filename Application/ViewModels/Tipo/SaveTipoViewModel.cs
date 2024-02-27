using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeDex.Core.Application.ViewModels.Tipo
{
    public class SaveTipoViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Debe colocar un nombre para el tipo de pokemon")]
        public string Name { get; set; }
    }
}
