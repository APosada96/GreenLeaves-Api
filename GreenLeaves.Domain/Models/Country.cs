using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenLeaves.Domain.Models
{

    public class Country
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(20)")]
        public string? Name { get; set; }
        public ICollection<State>? states { get; set; }
        public ICollection<City>? cities { get; set; }
    }
}
