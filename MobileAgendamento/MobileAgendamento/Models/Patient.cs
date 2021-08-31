using System;
using System.Collections.Generic;
using System.Text;

namespace MobileAgendamento.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
