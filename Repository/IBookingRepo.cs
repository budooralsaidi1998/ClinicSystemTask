using ClinicSystem.models;

namespace ClinicSystem.Repository
{
    public interface IBookingRepo
    {
        void Add(booking appointment);
        List<booking> AppointmentByClinic(string nameClinic);
        List<booking> AppointmentByPaient(string namepaient);
        List<booking> GetBookingsByClinicAndDate(int clinicId, DateTime date);
        booking GetById(int id);
    }
}