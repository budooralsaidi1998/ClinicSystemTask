using ClinicSystem.models;
using ClinicSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClinicSystem.Controller
{
    [ApiController]
    [Route("api/[Controller]")]
    public class PatientController:ControllerBase
    {
        private readonly IPatientServices _PatientService;

        public PatientController(IPatientServices pa)
        {
            _PatientService = pa;
        }




        [HttpPost]
        public IActionResult AddPatient(string name, int age, string gender)
        {
            try
            {

                if (!Enum.TryParse<GenderType>(gender, true, out var genderEnum))
                {
                    return BadRequest("Invalid gender value. Please provide 'Male', 'Female', or 'Other'.");
                }

                string newPatient = _PatientService.AddPatient(new Patient
                {
                    pname = name,
                    age = age,
                    RGender = genderEnum
                });

                return Created(string.Empty, newPatient);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
