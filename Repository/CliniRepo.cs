using ClinicSystem.models;

namespace ClinicSystem.Repository
{
    public class CliniRepo : ICliniRepo
    {
        private readonly AppDbcontext _context;

        public CliniRepo(AppDbcontext context)
        {
            _context = context;
        }

        public List<Clinic> ViewClinic()
        {

            return _context.clinics.ToList();
        }

        public void Add(Clinic addclinic)
        {

            _context.clinics.Add(addclinic);
            _context.SaveChanges();
        }



    }
}
