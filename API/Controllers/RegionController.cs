using Domain.Aggregates;
using Domain.Commands;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegionController : ControllerBase
    {
        public readonly RepositoryContext _context;

        public RegionController(RepositoryContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetRegions()
        {
            var regions = await _context.Region.ToListAsync();

            return Ok(regions);
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateRegion([FromBody] ExecuteRegionCreationCommand command)
        {
            _context.Region.Add(new()
            {
                Name = command.Name,
            });

            await _context.SaveChangesAsync();

            return Ok(command);
        }
    }
}
