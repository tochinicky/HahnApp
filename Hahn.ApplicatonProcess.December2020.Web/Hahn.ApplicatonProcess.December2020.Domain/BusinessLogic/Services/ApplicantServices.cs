using FluentValidation.Results;
using Hahn.ApplicatonProcess.December2020.Data.Data;
using Hahn.ApplicatonProcess.December2020.Domain.BusinessLogic.Interface;
using Hahn.ApplicatonProcess.December2020.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.Domain.BusinessLogic.Services
{
    public class ApplicantServices : IApplicant
    {
        private readonly ApplicantContext _context;
        private readonly ILogger<ApplicantServices> _logger;

        public ApplicantServices(ApplicantContext context, ILogger<ApplicantServices> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<ApplicantObjResponse> AddApplicant(ApplicantObj applicant)
        {
            try
            {
                ApplicantValidator validator = new ApplicantValidator();

                ValidationResult results = validator.Validate(applicant);
                if (!results.IsValid)
                {
                    IList<ValidationFailure> failures = results.Errors;
                    return new ApplicantObjResponse() { ValidationResults = failures };
                }
                var app = new Applicant
                {
                    Address = applicant.Address,
                    Age = applicant.Age,
                    EMailAdress = applicant.EMailAdress,
                    FamilyName = applicant.FamilyName,
                    Hired = applicant.Hired,
                    Name = applicant.Name,
                    CountryOfOrigin = applicant.CountryOfOrigin
                };
                _logger.LogInformation($"request from applicant--- {JsonConvert.SerializeObject(app)}");
               var res = await _context.Applicants.AddAsync(app);
               await _context.SaveChangesAsync();
                
                return new ApplicantObjResponse() { Success=true};
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message + " " + ex.StackTrace);
                return new ApplicantObjResponse() { Success = false };
            }
        }

        public bool DeleteApplicant(int id)
        {
            try
            {
                Applicant app = _context.Applicants.Where(a => a.ID ==id).FirstOrDefault();
                if(app != null)
                {
                    _context.Applicants.Remove(app);
                    _context.SaveChanges();
                    _logger.LogInformation($"user with id:{id} deleted successfully");
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message + " " + ex.StackTrace);
                return false;
            }
        }
        public async Task<List<ApplicantObj>> GetAllApplicant()
        {
            try
            {
                var list = new List<ApplicantObj>();
                var res = await _context.Applicants.ToListAsync();
                foreach (var item in res)
                {
                    var ff = new ApplicantObj
                    {
                        Address = item.Address,
                        Age = item.Age,
                        CountryOfOrigin = item.CountryOfOrigin,
                        EMailAdress = item.EMailAdress,
                        FamilyName = item.FamilyName,
                        Hired = item.Hired,
                        ID = item.ID,
                        Name = item.Name
                    };
                    list.Add(ff);
                }
               
                return list;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public async Task<ApplicantObj> GetApplicant(int id)
        {
            try
            {
                var res = await _context.Applicants.Where(a => a.ID == id).FirstOrDefaultAsync();
                if(res != null)
                {
                    var getApp = new ApplicantObj
                    {
                        ID=res.ID,

                        Address = res.Address,
                        Age = res.Age,
                        CountryOfOrigin = res.CountryOfOrigin,
                        EMailAdress = res.EMailAdress,
                        FamilyName = res.FamilyName,
                        Hired = res.Hired,
                        Name = res.Name
                    };
                    return getApp;
                }
                
                return new ApplicantObj();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message + " " + ex.StackTrace);
                throw;
            }
        }

        public bool UpdateApplicant(ApplicantObj applicant)
        {
            try
            {
                ApplicantValidator validator = new ApplicantValidator();

                ValidationResult results = validator.Validate(applicant);
                if (!results.IsValid)
                {
                    return false;
                }
                Applicant app = _context.Applicants.Where(a => a.ID == applicant.ID).FirstOrDefault();
                if(app != null)
                {
                    app.Address = applicant.Address;
                    app.Age = applicant.Age;
                    app.CountryOfOrigin = applicant.CountryOfOrigin;
                    app.EMailAdress = applicant.EMailAdress;
                    app.FamilyName = applicant.FamilyName;
                    app.Hired = applicant.Hired;
                    app.Name = applicant.Name;
                    _context.SaveChangesAsync();
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message + " " + ex.StackTrace);
                return false ;
            }
        }
    }
}
