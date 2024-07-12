using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Logic_Layer.Entity
{
    public class Cities
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [ForeignKey("Country")]
        public int CountryId { get; set; }
        public string CityName { get; set; }
        [NotMapped]
        public virtual Countries Country { get; set; }
    }
}
