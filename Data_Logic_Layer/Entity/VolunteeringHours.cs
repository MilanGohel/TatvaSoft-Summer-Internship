using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Data_Logic_Layer.Entity.CMS;

namespace Data_Logic_Layer.Entity
{
    public class VolunteeringHours:BaseEntity
    {
        [Key]
        public int? Id { get; set; }
        [ForeignKey("User")]
        public int? UserId { get; set; }
        [ForeignKey("Mission")]
        public int? MissionId {  get; set; }
        public string? MissionName {  get; set; }
        public DateTime? DateVolunteered { get; set; }
        public string? Hours { get; set; }
        public string? Minutes {  get; set; }
        public string? Message { get; set; }
        [NotMapped]
        public virtual User User { get; set; }
        [NotMapped]
        public virtual Mission Mission { get; set; }
    }
    public class VolunteeringGoals : BaseEntity
    {
        [Key]
        public int? Id { get; set; }
        [ForeignKey("User")]
        public int? UserId { get; set; }
        [ForeignKey("Mission")]
        public int? MissionId { get; set; }
        public string? MissionName { get; set; }
        public DateTime? Date { get; set; }
        public int? Action { get; set; }
        public string? Message { get; set; }
        [NotMapped]
        public virtual User User { get; set; }
        [NotMapped]
        public virtual Mission Mission { get; set; }

    }
}
