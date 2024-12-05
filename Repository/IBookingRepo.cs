using ClinicSystem.models;

namespace ClinicSystem.Repository
{
    public interface IBookingRepo
    {
        void Add(booking appointment);
        booking AppointmentByClinic(string nameClinic);
        booking AppointmentByPaient(string namepaient);
    }
}