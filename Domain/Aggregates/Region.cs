﻿using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Domain.Aggregates
{
    public class Region
    {
        public int Id { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        [JsonIgnore] [NotMapped]
        public IList<User>? Users { get; set; }
        [JsonIgnore] [NotMapped]
        public IList<Device>? Devices { get; set; }
    }
}
