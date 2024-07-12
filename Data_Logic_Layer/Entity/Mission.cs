using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Data_Logic_Layer.Entity
{
        public class CMS : BaseEntity
        {
            [Key]
            public int Id { get; set; }
            public string? Title { get; set; }
            public string? Description { get; set; }
            public string? Status { get; set; }
        }
        public class Mission : BaseEntity
        {
            [Key]
            public int Id { get; set; }
            public string? MissionTitle { get; set; }
            public string? MissionDescription { get; set; }
            public string? MissionOrganisationName { get; set; }
            public string? MissionOrganisationDetail { get; set; }
            [ForeignKey("Country")]
            public int? CountryId { get; set; }
            [ForeignKey("City")]
            public int? CityId { get; set; }
            public DateTime? StartDate { get; set; }
            public DateTime? EndDate { get; set; }
            public string? MissionType { get; set; }
            public int? TotalSheets { get; set; }
            public DateTime? RegistrationDeadLine { get; set; }
            public int? MissionThemeId { get; set; }
            public int? MissionSkillId { get; set; }
            public string? MissionImages { get; set; }
            public string? MissionDocuments { get; set; }
            public string? MissionAvailability { get; set; }
            public string? MissionVideoUrl { get; set; }
            public string? MissionThemeName { get; set; }
            public string? MissionSkillName { get; set; }
            public string? MissionDeadLineStatus { get; set; }
            public string? MissionStatus { get; set; }
            public string? MissionApplyStatus { get; set; }
            public string? MissionDataStatus { get; set; }
            public string? MissionFavouriteStatus { get; set; }
            public string? rating { get; set; }
            [NotMapped]    
            public virtual Countries? Country { get; set; }
            [NotMapped]
            public virtual Cities? City { get; set; }
            [NotMapped]
            public virtual ICollection<MissionSkill>? MissionSkills { get; set; }
        }
        

        public class MissionApplication : BaseEntity
        {
            [Key]
            public int Id { get; set; }
            public string? MissionTitle { get; set; }

            [Required]
            [ForeignKey("Missions")]
            public int? MissionId { get; set; }
            [Required]
            [ForeignKey("User")]
            public int? UserId { get; set; }
            public string? UserName { get; set; }

            public DateTime? AppliedDate { get; set; }
            public bool? Status { get; set; }
            public int? Sheet { get; set; }
            [NotMapped]
            public virtual Mission? Mission { get; set; }
            [NotMapped]
            public virtual User? User { get; set; }
        }

        public class MissionSkill : BaseEntity
        {
            [Key]
            public int Id { get; set; }

            public string? SkillName { get; set; }

            public string? Status { get; set; }
        }

        public class MissionTheme : BaseEntity
        {
            [Key]
            public int Id { get; set; }
            public string? ThemeName { get; set; }
            public string? Status { get; set; }
        }

}
