using ClinicSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClinicSystem.Controller
{
    [ApiController]
    [Route("api/[Controller]")]

    public class bookingController:ControllerBase
    {
        private readonly IbookingSrevices _bookingService;

        public bookingController(IbookingSrevices bookService)
        {
            _bookingService = bookService;
        }

        [HttpPost("BookAppoitment")]
        public IActionResult AddBook(string namep, int clinicId, DateTime date, int slotNumber)
        {
            try
            {
                _bookingService.BookAppointment( namep,clinicId,date,slotNumber);
                return Created();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("GetBookByClinic/{namesp}")]
        public IActionResult GetAppoiByClinic(string namesp)
        {
            try
            {
                var books = _bookingService.ViewAppointmentsBySpeClinic(namesp);
                return Ok(books);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetBookByPatient/{name}")]
        public IActionResult GetAppoiByPatient(string name)
        {
            try
            {
                var books = _bookingService.ViewAppointmentsByPatient(name);
                return Ok(books);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
