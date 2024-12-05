using ClinicSystem.models;
using ClinicSystem.Repository;
using Microsoft.EntityFrameworkCore;

namespace ClinicSystem.Services
{
    public class ClinicServices
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


        public int  AddClinic(Clinic clinic)
        {
       
           



            return _clinicRepo.Add(clinic);
        }


       

    }
}
