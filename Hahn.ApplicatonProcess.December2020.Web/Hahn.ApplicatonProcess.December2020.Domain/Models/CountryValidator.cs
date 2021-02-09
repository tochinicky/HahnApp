using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.Domain.Models
{
   public class CountryValidator: AsyncValidatorBase
    {

        public CountryValidator() :
            base("Country name '{PropertyValue}' is not valid.")
        {

        }

        protected override async Task<bool> IsValidAsync(PropertyValidatorContext context,
            CancellationToken cancellation)
        {
            using (var _httpclient = new HttpClient())
            {
                ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
                var get =await _httpclient.GetAsync($"https://restcountries.eu/rest/v2/name/{context.PropertyValue}?fullText=true");
                return get.IsSuccessStatusCode;
            }
          
        }
    }
}
