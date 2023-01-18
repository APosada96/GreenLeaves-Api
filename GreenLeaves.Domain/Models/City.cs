using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenLeaves.Domain.Models
{
    
    public class City
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(20)")]
        public string? Name { get; set; }

       
        [ForeignKey("Country")]
        public int IdCountry { get; set; }
        
        public Country? Country { get; set; }

       
        [ForeignKey("State")]
        public int IdState { get; set; }
       
        public State? State { get; set; }

    }
}
