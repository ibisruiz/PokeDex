using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pokedex.Infrastructure.Persistence.Contexts;
using Pokedex.Core.Domain.Entities;
using PokeDex.Core.Application.Interfaces.Repositories;

namespace Pokedex.Infrastructure.Persistence.Repositories
{
    
    public class RegionRepository : GenericRepository<Region>, IRegionRepository
    {
        private readonly ApplicationContext _dbContext;

        public RegionRepository(ApplicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        
    }
}
