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
        public readonly RegionRepository _regionRepository;

        public RegionController(RepositoryContext context)
        {
            _context = context;
            _regionRepository = new RegionRepository(context);
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetRegions()
        {
            var regions = await _regionRepository.GetAll();

            return Ok(regions);
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateRegion([FromBody] ExecuteRegionCreationCommand command)
        {
            var region = new Region()
            {
                City = command.City,
                State = command.State,
            };

            await _regionRepository.Create(region);

            return Ok(command);
        }
    }
}
