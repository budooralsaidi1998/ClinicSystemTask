using ClinicSystem.models;

namespace ClinicSystem.Repository
{
    public interface ICliniRepo
    {
        void Add(Clinic addclinic);
        List<Clinic> ViewClinic();
    }
}