using Domain.ValueObjects;

namespace Domain.Aggregates
{
    public class Device
    {
        public int Id { get; set; }
        public int RegionId { get; set; }
        public string? Code { get; set; }
        public DateTimeOffset InstallationDate { get; set; }
        public DateTimeOffset LastMaintenanceDate { get; set; }
        public DeviceStatus Status { get; set; }
    }
}