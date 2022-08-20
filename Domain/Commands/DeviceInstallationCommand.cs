using Domain.ValueObjects;

namespace Domain.Commands
{
    public class ExecuteDeviceInstallationCommand
    {
        public int RegionId { get; set; }
        public DeviceStatus Status { get; set; }
    }
}
