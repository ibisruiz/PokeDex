using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Core.Domain.Entities
{
	public class Pokemon
	{
		public int Id { get; set; }
		public string Nombre { get; set; }
		public string ImageUrl { get; set; }

		public int RegionId { get; set; }
		public Region Region { get; set; }

        public int TipoId { get; set; }
		public Tipo Tipo { get; set; }


    }
}
