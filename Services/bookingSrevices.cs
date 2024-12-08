using ClinicSystem.models;
using ClinicSystem.Repository;

namespace ClinicSystem.Services
{
    public class bookingSrevices : IbookingSrevices
    {
        private readonly IBookingRepo _bookingrepo;
        private readonly IClinicServices _clinicservice;
        private readonly IPatientServices _patientservices;
        private readonly IPatientRepo _patientrepo;
        private readonly ICliniRepo _clinicrepo;
        public bookingSrevices(IBookingRepo bookrepo, IClinicServices clinciservices, IPatientServices patientservices, IPatientRepo patientrepo, ICliniRepo _clinicrepoo)
        {
            _bookingrepo = bookrepo;
            _clinicservice = clinciservices;
            _patientservices = patientservices;
            _patientrepo = patientrepo;
            _clinicrepo = _clinicrepoo;
        }



        public string BookAppointment(string namep, int clinicId, DateTime date, int slotNumber)
        {

            var patient = _patientservices.GetPatientByName(namep).FirstOrDefault();

            if (patient == null)
            {
                throw new KeyNotFoundException("Patient not found.");
            }


            var clinic = _clinicservice.GetAllClinic().FirstOrDefault(c => c.Id == clinicId);
            if (clinic == null)
            {
                throw new KeyNotFoundException("Clinic not found.");
            }


            if (!IsSlotAvailable(clinicId, date, slotNumber))
            {
                throw new KeyNotFoundException("Slot is already booked.");
            }


            var booking = new booking
            {
                pid = patient.Pid,
                cid = clinic.Id,
                date = date,
                slot_number = slotNumber +1
            };

            _bookingrepo.Add(booking);

            return "Appointment booked successfully.";
        }

        public bool IsSlotAvailable(int clinicId, DateTime date, int slotNumber)
        {
            var clinic = _clinicservice.GetAllClinic().FirstOrDefault(c => c.Id == clinicId);

            if (clinic == null)
            {
                throw new KeyNotFoundException("Clinic not found.");
            }


            var bookings = _bookingrepo.GetBookingsByClinicAndDate(clinicId, date);


            var slotAlreadyBooked = bookings.Any(b => b.slot_number == slotNumber);

            return !slotAlreadyBooked;
        }

        public List<booking> ViewAppointmentsBySpeClinic(string specialization)
        {

            var clinics = _clinicservice.GetClinicsBySpecialization(specialization);

            if (clinics == null || clinics.Count == 0)
            {
                throw new KeyNotFoundException("No clinics found for the specified specialization.");
            }

            var appointments = new List<booking>();

            foreach (var clinic in clinics)
            {
                var clinicing = _bookingrepo.AppointmentByClinic(clinic.spe);

                foreach (var booking in clinicing)
                {
                    appointments.Add(new booking
                    {
                        pid = booking.pid,
                        slot_number = booking.slot_number,
                        date = booking.date,
                        cid = booking.cid
                    });
                }
            }

            return appointments;
        }

        public List<booking> ViewAppointmentsByPatient(string name)
        {

            var pa = _patientservices.GetPatientByName(name);

            if (pa == null || pa.Count == 0)
            {
                throw new KeyNotFoundException("No Patient found for specific this name .");
            }

            var appointments = new List<booking>();

            foreach (var patient in pa)
            {
                var pat = _bookingrepo.AppointmentByPaient(patient.pname);

                foreach (var booking in pat)
                {
                    appointments.Add(new booking
                    {
                        pid = booking.pid,
                        slot_number = booking.slot_number,
                        date = booking.date,
                        cid = booking.cid
                    });
                }
            }

            return appointments;
        }
    }

}



