﻿namespace Domain.Aggregates
{
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Password { get; set; }
        public Region? Region { get; set; }
    }
}
