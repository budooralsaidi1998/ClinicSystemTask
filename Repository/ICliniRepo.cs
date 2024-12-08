using ClinicSystem.models;

namespace ClinicSystem.Repository
{
    public interface ICliniRepo
    {
        void Add(Clinic addclinic);
        List<Clinic> GetClinicsBySpecialization(string specialization);
        List<Clinic> ViewClinic();
    }
}