using System;

namespace ClinicManagement.Core.Domain.Entities
{
    public class AppointmentService
    {
        public int AppointmentServiceId { get; set; }
        public int AppointmentId { get; set; }
        public int ServiceId { get; set; }
        public int Quantity { get; set; }

        // Navigation properties
        public Appointment Appointment { get; set; }
        public Service Service { get; set; }
    }
}
