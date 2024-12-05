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

        public booking AppointmentByClinic(string nameClinic)
        {
            return _context.bookings.Include(c => c.clinics).FirstOrDefault(c => c.clinics.spe == nameClinic);
        }


        public booking AppointmentByPaient(string namepaient)
        {
            return _context.bookings.Include(c => c.patients).FirstOrDefault(c => c.patients.pname == namepaient);
        }
    }
}
