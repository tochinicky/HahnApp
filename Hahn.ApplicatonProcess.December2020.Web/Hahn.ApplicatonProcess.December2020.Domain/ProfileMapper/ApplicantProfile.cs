using AutoMapper;
using Hahn.ApplicatonProcess.December2020.Data.Data;
using Hahn.ApplicatonProcess.December2020.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.Domain.ProfileMapper
{
   public class ApplicantProfile:Profile
    {
        public ApplicantProfile()
        {
            // Mapping properties from Applicant to ApplicantObject  
            CreateMap<ApplicantObj, Applicant>()
                .ForMember(dest =>
                   dest.FamilyName,
                    opt => opt.MapFrom(src => src.FamilyName))
                .ForMember(dest =>
                    dest.Address,
                    opt => opt.MapFrom(src => src.Address))
                .ForMember(dest =>
                    dest.Age,
                    opt => opt.MapFrom(src => src.Age))
                .ForMember(dest =>
                    dest.EMailAdress,
                    opt => opt.MapFrom(src => src.EMailAdress))
                .ForMember(dest =>
                    dest.Name,
                    opt => opt.MapFrom(src => src.Name))
                .ForMember(dest =>
                    dest.Hired,
                    opt => opt.MapFrom(src => src.Hired))
                .ReverseMap();

            // ForMember is used incase if any field doesn't match
        }
    }
}
