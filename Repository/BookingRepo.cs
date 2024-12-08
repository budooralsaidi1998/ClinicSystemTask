using ClinicSystem.models;
using Microsoft.EntityFrameworkCore;

namespace ClinicSystem.Repository
{
    public class BookingRepo : IBookingRepo
    {
        private readonly AppDbcontext _context;

        public BookingRepo(AppDbcontext context)
        {
            _context = context;
        }

        public void Add(booking appointment)
        {
            _context.bookings.Add(appointment);
            _context.SaveChanges();
        }

        public List<booking> AppointmentByClinic(string nameClinic)
        {
            return _context.bookings
                           .Include(c => c.clinics)  // Include the clinic data in the result
                           .Where(c => c.clinics.spe == nameClinic)  // Filter by specialization
                           .ToList();  // Return the list of bookings
        }


        public List<booking> AppointmentByPaient(string namepaient)
        {
            return _context.bookings.Include(c => c.patients).Where(c => c.patients.pname == namepaient).ToList();
        }

        public booking GetById(int id)
        {
            return _context.bookings.Include(u => u.clinics).Include(b => b.patients).FirstOrDefault(br => br.bookid == id);
        }

        public List<booking> GetBookingsByClinicAndDate(int clinicId, DateTime date)
        {

            return _context.bookings.Where(b => b.cid == clinicId && b.date.Date == date.Date)
                .ToList();
        }
    }
}
