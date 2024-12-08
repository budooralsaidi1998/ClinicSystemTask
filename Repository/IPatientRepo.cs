using ClinicSystem.models;

namespace ClinicSystem.Repository
{
    public interface IPatientRepo
    {
        void Add(Patient addpient);
        List<Patient> GetIDPatient(string name);
        List<Patient> ViewPaient();
    }
}