using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenLeaves.Domain.Models
{
    public class ContactViewModel
    {
        public string? Name { get; set; }
        public int Telephone { get; set; }
        public string? Email { get; set; }
        public string? Date { get; set; }
        public string? CityAndState { get; set; }
    }
}
