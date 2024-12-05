using ClinicSystem.models;

namespace ClinicSystem.Repository
{
    public class PatientRepo : IPatientRepo
    {
        private readonly AppDbcontext _context;

        public PatientRepo(AppDbcontext context)
        {
            _context = context;
        }

        public List<Patient> ViewPaient()
        {

            return _context.patients.ToList();
        }

        public void Add(Patient addpient)
        {

            _context.patients.Add(addpient);
            _context.SaveChanges();
        }


    }
}
