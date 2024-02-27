using Microsoft.EntityFrameworkCore;
using Pokedex.Core.Domain.Entities;
using Pokedex.Infrastructure.Persistence.Contexts;
using PokeDex.Core.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Infrastructure.Persistence.Repositories
{
    public class PokemonRepository : GenericRepository<Pokemon>, IPokemonRepository
    {
        private readonly ApplicationContext _dbContext;


        public PokemonRepository(ApplicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

    } 
}
