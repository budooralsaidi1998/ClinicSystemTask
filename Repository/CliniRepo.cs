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

        public List<Clinic> GetClinicsBySpecialization(string specialization)
        {
            return _context.clinics
                .Where(c => c.spe == specialization)
                .ToList();
        }

        public Clinic GetClinicsBySpecializationOneSPE(string specializationn)
        {
            return _context.clinics
                .FirstOrDefault(c => c.spe == specializationn)
                ;
        }
        public void updateClinicSlots(string specializationn, int newSlotCount)
        {
            // Retrieve the clinic by specialization
            var currentClinic = GetClinicsBySpecializationOneSPE(specializationn);

            if (currentClinic != null)
            {

                currentClinic.num_of_slots = newSlotCount;


                _context.Update(currentClinic);
                _context.SaveChanges();
            }

        }
    }
}
