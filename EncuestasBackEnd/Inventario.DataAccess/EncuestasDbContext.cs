using Inventario.Entities.Surveys;
using Inventario.Entities.Surveys.Questions;
using Inventario.Entities.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.DataAccess
{
    public class EncuestasDbContext : IdentityDbContext
    {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Survey> Surveys { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<Option> Options { get; set; }

        public EncuestasDbContext(DbContextOptions<EncuestasDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Ignore<IdentityUserLogin<string>>();
            modelBuilder.Entity<Survey>()
                .HasMany(e => e.Questions)
                .WithOne(p => p.Survey)
                .HasForeignKey(p => p.SurveyID)
                .OnDelete(DeleteBehavior.Cascade);  

            modelBuilder.Entity<Question>()
                .HasMany(p => p.Options)
                .WithOne(o => o.Question)
                .HasForeignKey(o => o.QuestionId)
                .OnDelete(DeleteBehavior.Cascade);  
        }
    }
}
