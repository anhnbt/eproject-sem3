using System;
using System.Collections.Generic;

namespace ClinicManagement.Core.Domain.Entities
{
    public class Prescription
    {
        public int PrescriptionId { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public int? RecordId { get; set; }
        public DateTime PrescriptionDate { get; set; }
        public string Notes { get; set; }

        // Navigation properties
        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }
        public PatientRecord Record { get; set; }
        public ICollection<PrescriptionItem> PrescriptionItems { get; set; }
    }
}
