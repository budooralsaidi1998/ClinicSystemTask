using ClinicSystem.models;
using ClinicSystem.Repository;
using Microsoft.EntityFrameworkCore;

namespace ClinicSystem.Services
{
    public class ClinicServices : IClinicServices
    {

        private readonly ICliniRepo _clinicRepo;

        public ClinicServices(ICliniRepo clinicRepo)
        {
            _clinicRepo = clinicRepo;
        }

        public List<Clinic> ViewClinicDetatils()
        {

            return _clinicRepo.ViewClinic().ToList();

        }

        public string AddClinic(Clinic clinic)
        {
            if (string.IsNullOrWhiteSpace(clinic.spe))
            {
                throw new ArgumentException("speclication is  required.");
            }



            if (clinic.num_of_slots >= 20)
            {
                throw new ArgumentException("maxmum is 20");
            }


            _clinicRepo.Add(clinic);

            return "Added Successfully.";
        }

        public List<Clinic> GetAllClinic()
        {
            var clinicview = _clinicRepo.ViewClinic().OrderByDescending(b => b.num_of_slots).ToList();
            if (clinicview == null || clinicview.Count == 0)
            {
                throw new InvalidOperationException("No clinic found.");
            }
            return clinicview;
        }

        public List<Clinic> GetClinicsBySpecialization(string specialization)
        {
            var clinics = _clinicRepo.ViewClinic().Where(c => c.spe == specialization).ToList();

            if (clinics.Count == 0)
            {
                throw new InvalidOperationException("No clinics found with the given specialization.");
            }

            return clinics;
        }

        public void UpdateAvailableSlots(int clinicId)
        {
            var clinic = _clinicRepo.ViewClinic().FirstOrDefault(c => c.Id == clinicId);
            if (clinic == null)
            {
                throw new InvalidOperationException("Clinic not found.");
            }


            if (clinic.num_of_slots > 0)
            {
                clinic.num_of_slots -= 1;
                _clinicRepo.updateClinicSlots(clinic.spe, clinic.num_of_slots);
            }
            else
            {
                throw new InvalidOperationException("No available slots left.");
            }
        }




    }
}
