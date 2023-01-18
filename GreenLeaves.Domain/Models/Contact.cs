using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenLeaves.Domain.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(20)")]
        public string? Name { get; set; }

        [Required]
        [Column(TypeName = "INT")]
        public int Telephone { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(30)")]
        public string? Email { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(30)")]
        public string? Date { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(40)")]
        public string? CityAndState { get; set; }
    }
}
