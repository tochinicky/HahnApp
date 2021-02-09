using Hahn.ApplicatonProcess.December2020.Data.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.Domain.Models
{
   public class ApplicantContext:DbContext
    {
        public ApplicantContext(DbContextOptions<ApplicantContext> options):base(options)
        {

        }
        public DbSet<Applicant>  Applicants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Applicant>()
                .HasData(
                    new Applicant
                    {
                        ID = 1,
                        FamilyName = "Onyeamah",
                        Address = "badore road ajah, lagos",
                        EMailAdress = "tochinicky@gmail.com",
                        Hired = true,
                        CountryOfOrigin = "nigeria",
                        Name = "John Doe",
                        Age = 30
                    },
                    new Applicant
                    {
                        ID = 2,
                        Name = "Tochukwu",
                        FamilyName = "Onyeamah",
                        Address = "badore road ajah, lagos",
                        EMailAdress = "tochinicky@gmail.com",
                        Hired = true,
                        Age = 29,
                        CountryOfOrigin = "nigeria"
                    }
                );
        }
    }
}
