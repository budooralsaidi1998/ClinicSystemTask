using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;
using System.Security.Cryptography;

namespace ClinicSystem.models
{
    [PrimaryKey(nameof(pid), nameof(cid),nameof(date))]
    public class booking
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int bookid { get; set; }

        [Required]

        public DateTime  date { get; set; }

        [Required]
        public int slot_number { get; set; }

        [ForeignKey("patients")]
        public int pid { get; set; }
        public virtual Patient patients { get; set; }

        [ForeignKey("clinics")]
        public int cid { get; set; }
        public virtual Clinic clinics { get; set; }

    }
}
