using System;
using System.Collections.Generic;

namespace ClinicManagement.Core.Domain.Entities
{
    public class Medicine
    {
        public int MedicineId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Manufacturer { get; set; }
        public decimal UnitPrice { get; set; }
        public int StockQuantity { get; set; }
        public int ReorderLevel { get; set; }
        public string DosageForm { get; set; } // Tablet, Liquid, Capsule, etc.
        public string Strength { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        // Navigation properties
        public ICollection<PrescriptionItem> PrescriptionItems { get; set; }
    }
}
