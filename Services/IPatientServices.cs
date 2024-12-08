using ClinicSystem.models;

namespace ClinicSystem.Services
{
    public interface IPatientServices
    {
        string AddPatient(Patient patint);
        List<Patient> GetAllPatient();
        List<Patient> GetPatientByName(string name);
    }
}