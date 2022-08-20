using Domain.Aggregates;
using Domain.Commands;
using Domain.ValueObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository;
using System;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeviceController : ControllerBase
    {
        public readonly DeviceRepository _deviceRepository;
        public readonly RegionRepository _regionRepository;

        public DeviceController(RepositoryContext context)
        {
            _deviceRepository = new DeviceRepository(context);
            _regionRepository = new RegionRepository(context);
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetDevices()
        {
            var devices = await _deviceRepository.GetAll();

            return Ok(devices);
        }

        [HttpPost]
        [Route("execute/installation")]
        public async Task<IActionResult> ExecuteInstallation([FromBody] ExecuteDeviceInstallationCommand command)
        {
            var region = await _regionRepository.GetById(command.RegionId);
            if (region == null)
            {
                return BadRequest("Region not found");
            }

            var device = new Device()
            {
                Region = region,
                Status = command.Status,
                InstallationDate = DateTimeOffset.UtcNow,
            };

            await _deviceRepository.Create(device);

            return Ok();
        }

        [HttpPut]
        [Route("execute/maintenance")]
        public async Task<IActionResult> ExecuteMaintenance([FromBody] DeviceMaintenanceCommand command)
        {
            var device = await _deviceRepository.GetById(command.DeviceId);
            if (device == null)
            {
                return BadRequest("Device not found");
            }

            var region = await _regionRepository.GetById(command.RegionId);
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
                device.Region = await _regionRepository.GetById(command.RegionId);
            }

            device.LastMaintenanceDate = DateTimeOffset.UtcNow;

            await _deviceRepository.Update(device);

            return Ok(device);
        }
    }
}
