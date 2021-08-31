using System;
using System.Collections.Generic;
using System.Text;

namespace MobileAgendamento.Models
{
    public class Vaccine
    {
        public int Id { get; set; }
        public int IdVaccineType { get; set; }
        public string Manufacturer { get; set; }
        public DateTime ManufacturingDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Description { get; set; }
    }
}
