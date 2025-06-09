using System;

namespace ClinicManagement.Core.Domain.Entities
{
    public class Service
    {
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
        public string Description { get; set; }
        public decimal Cost { get; set; }
        public int? Duration { get; set; } // in minutes
        public bool IsActive { get; set; }
    }
}
