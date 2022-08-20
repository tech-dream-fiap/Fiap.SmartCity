using Domain.Aggregates;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class DeviceRepository
    {
        public readonly RepositoryContext _context;

        public DeviceRepository(RepositoryContext context)
        {
            _context = context;
        }

        public async Task<Device?> GetById(int id)
        {
            return await _context.Device
                .Include(x => x.Region)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Device>> GetAll()
        {
            return await _context.Device.ToListAsync();
        }

        public async Task Create(Device device)
        {
            _context.Device.Add(device);
            await Save();
        }

        public async Task Update(Device device)
        {
            _context.Device.Update(device);
            await Save();
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
