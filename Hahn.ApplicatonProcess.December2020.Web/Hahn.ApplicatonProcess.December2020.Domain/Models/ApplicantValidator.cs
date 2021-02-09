using FluentValidation;
using Hahn.ApplicatonProcess.December2020.Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.Domain.Models
{
    public class ApplicantValidator: AbstractValidator<ApplicantObj>
    {
        public ApplicantValidator()
        {
            RuleFor(applicant => applicant.Name).NotNull().MinimumLength(5);
            RuleFor(applicant => applicant.FamilyName).NotNull().MinimumLength(5);
            RuleFor(applicant => applicant.Address).NotNull().MinimumLength(10);
            RuleFor(applicant => applicant.EMailAdress).NotNull().EmailAddress();
            RuleFor(applicant => applicant.Age).InclusiveBetween(20, 60);
            RuleFor(applicant => applicant.Hired).NotNull();
            RuleFor(app => app.CountryOfOrigin).NotNull().SetValidator(new CountryValidator());
        }
    }
}
