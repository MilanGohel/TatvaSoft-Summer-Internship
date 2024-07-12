using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Logic_Layer.Entity
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<User>  User { get; set; }
        public DbSet<UserDetail> UserDetail { get; set; }
        public DbSet<Countries> Countries { get; set; }
        public DbSet<Cities> Cities { get; set; }
        public DbSet<Mission> Mission { get; set; } 
        public DbSet<MissionTheme> MissionTheme { get; set; }
        public DbSet<MissionApplication> MissionApplication { get; set; }
        public DbSet<MissionSkill> MissionSkill { get; set; }   
        public DbSet<CMS> CMS { get; set; }
        public DbSet<VolunteeringHours> VolunteeringHours { get; set; }
        public DbSet<VolunteeringGoals> VolunteeringGoals { get; set; }
        public DbSet<ContactUs> ContactUs { get; set; }

    }
}
