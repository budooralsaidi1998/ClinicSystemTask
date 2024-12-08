using ClinicSystem.models;
using ClinicSystem.Repository;

namespace ClinicSystem.Services
{
    public class PatientServices : IPatientServices
    {
        private readonly IPatientRepo _patientRepo;

        public PatientServices(IPatientRepo patientrepo)
        {
            _patientRepo = patientrepo;
        }


        public string AddPatient(Patient patint)
        {
            if (string.IsNullOrWhiteSpace(patint.pname))
            {
                throw new ArgumentException("name of patient is  required.");
            }

            _patientRepo.Add(patint);

            return "Added Successfully.";
        }

        public List<Patient> GetAllPatient()
        {
            var patientview = _patientRepo.ViewPaient().OrderByDescending(b => b.pname).ToList();
            if (patientview == null || patientview.Count == 0)
            {
                throw new InvalidOperationException("No patient found.");
            }
            return patientview;
        }

        public List<Patient> GetPatientByName(string name)
        {
            var patientview = _patientRepo.GetIDPatient(name);
            if (patientview == null )
            {
                throw new InvalidOperationException("No patient found.");
            }
            return patientview;
        }
    }
}
