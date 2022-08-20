using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Aggregates;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class RegionRepository
    {
        public readonly RepositoryContext _context;

        public RegionRepository(RepositoryContext context)
        {
            _context = context;
        }

        public async Task<Region?> GetById(int id)
        {
            return await _context.Region.FindAsync(id);
        }

        public async Task<List<Region>> GetAll()
        {
            return await _context.Region.ToListAsync();
        }

        public async Task Create(Region region)
        {
            _context.Region.Add(region);
            await Save();
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
