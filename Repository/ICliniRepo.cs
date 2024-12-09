using ClinicSystem.models;

namespace ClinicSystem.Repository
{
    public interface ICliniRepo
    {
        void Add(Clinic addclinic);
        List<Clinic> GetClinicsBySpecialization(string specialization);
        Clinic GetClinicsBySpecializationOneSPE(string specializationn);
        void updateClinicSlots(string specializationn, int newSlotCount);
        List<Clinic> ViewClinic();
    }
}