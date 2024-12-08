using ClinicSystem.models;

namespace ClinicSystem.Services
{
    public interface IbookingSrevices
    {
        string BookAppointment(string namep, int clinicId, DateTime date, int slotNumber);
        bool IsSlotAvailable(int clinicId, DateTime date, int slotNumber);
        List<booking> ViewAppointmentsByPatient(string name);
        List<booking> ViewAppointmentsBySpeClinic(string specialization);
    }
}