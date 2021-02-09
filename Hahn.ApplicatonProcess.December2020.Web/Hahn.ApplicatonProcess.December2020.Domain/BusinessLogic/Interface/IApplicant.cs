using Hahn.ApplicatonProcess.December2020.Data.Data;
using Hahn.ApplicatonProcess.December2020.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.Domain.BusinessLogic.Interface
{
    public interface IApplicant
    {
        Task<ApplicantObjResponse> AddApplicant(ApplicantObj applicant);
        Task<ApplicantObj> GetApplicant(int id);
        Task<List<ApplicantObj>> GetAllApplicant();
         bool UpdateApplicant(ApplicantObj applicant);
        bool DeleteApplicant(int id);
    }
}
