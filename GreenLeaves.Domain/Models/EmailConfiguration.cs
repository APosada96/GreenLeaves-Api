using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenLeaves.Domain.Models
{
    public class EmailConfiguration
    {
        public string? From { get; set; }
        public string? Host { get; set; }
        public int Port { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? To { get; set; }
        public string? Subject { get; set; }
        public string? Template { get; set; }
    }
}
