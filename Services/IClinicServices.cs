using ClinicSystem.models;

namespace ClinicSystem.Services
{
    public interface IClinicServices
    {
        string AddClinic(Clinic clinic);
        List<Clinic> GetAllClinic();
        List<Clinic> GetClinicsBySpecialization(string specialization);
        List<Clinic> ViewClinicDetatils();
    }
}