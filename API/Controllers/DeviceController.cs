using Domain.Aggregates;
using Domain.Commands;
using Domain.ValueObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeviceController : ControllerBase
    {
        public readonly RepositoryContext _context;

        public DeviceController(RepositoryContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetDevices()
        {
            var devices = await _context.Device.Include(x => x.Region).ToListAsync();

            return Ok(devices);
        }

        [HttpPost]
        [Route("execute/installation")]
        public async Task<IActionResult> ExecuteInstallation([FromBody] ExecuteDeviceInstallationCommand command)
        {
            var region = await _context.Region.FindAsync(command.RegionId);
            if (region == null)
            {
                return BadRequest("Region not found");
            }

            _context.Device.Add(new Device()
            {
                Region = region,
                InstallationDate = DateTimeOffset.Now,
                Status = command.Status,
            });

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut]
        [Route("execute/maintenance")]
        public async Task<IActionResult> ExecuteMaintenance([FromBody] ExecuteDeviceMaintenanceCommand command)
        {
            var device = _context.Device.Include(x => x.Region).Where(x => x.Id == command.DeviceId).FirstOrDefault();
            if (device == null)
            {
                return BadRequest("Device not found");
            }

            var region = await _context.Region.FindAsync(command.RegionId);
            if (region == null)
            {
                return BadRequest("Region not found");
            }

            if (device.Status == DeviceStatus.Inactive)
            {
                return BadRequest("This device is inactive");
            }

            if (device.Region?.Id != command.RegionId)
            {
                device.Region = await _context.Region.FindAsync(command.RegionId);
            }

            device.LastMaintenanceDate = DateTime.Now;

            _context.Device.Update(device);

            await _context.SaveChangesAsync();

            return Ok(device);
        }
    }
}
