using ClinicSystem.models;
using ClinicSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClinicSystem.Controller
{
    [ApiController]
    [Route("api/[Controller]")]

    public class ClinicController:ControllerBase
    {
        private readonly IClinicServices _ClinicService;

        public ClinicController(IClinicServices clinicser)
        {
            _ClinicService = clinicser;
        }

        [HttpPost]
        public IActionResult AddClinic(string spec, int num )
        {
            try
            {
                string newClinicId = _ClinicService.AddClinic(new Clinic
                {
                    spe = spec,
                    num_of_slots = num
          
                });

                return Created(string.Empty, newClinicId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("GetAllClinic")]
        public IActionResult GetAllClinic()
        {
            try
            {
                var clinic = _ClinicService.GetAllClinic();
                return Ok(clinic);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
