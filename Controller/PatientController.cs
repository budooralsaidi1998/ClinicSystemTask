using ClinicSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClinicSystem.Controller
{
    [ApiController]
    [Route("api/[Controller]")]
    public class PatientController
    {
        private readonly IPatientServices _PatientService;

        public PatientController(IPatientServices pa)
        {
            _PatientService = pa;
        }
    }
}   
