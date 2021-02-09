using Hahn.ApplicatonProcess.December2020.Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.Domain.Models
{
    public class SeedData
    {
       public static void AddTestData(ApplicantContext context)
        {
            var app = new Applicant
            {
                Name = "Tochukwu",
                FamilyName = "Onyeamah",
                Address = "badore road ajah, lagos",
                EMailAdress = "tochinicky@gmail.com",
                Hired = true,
                Age = 29,
                CountryOfOrigin = "nigeria"
            };
            context.AddAsync(app);
            context.SaveChangesAsync();
        }
    }
}
