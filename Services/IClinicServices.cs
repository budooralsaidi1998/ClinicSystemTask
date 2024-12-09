using ClinicSystem.models;

namespace ClinicSystem.Services
{
    public interface IClinicServices
    {
        string AddClinic(Clinic clinic);
        List<Clinic> GetAllClinic();
        List<Clinic> GetClinicsBySpecialization(string specialization);
        void UpdateAvailableSlots(int clinicId);
        List<Clinic> ViewClinicDetatils();
    }
}