using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polyclinic.Models
{
    internal class Patient
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Surename { get; set; }

        [Required]
        [StringLength(50)]
        public string Patronimic { get; set; }

        [Required]
        [StringLength(50)]
        public string Bithday { get; set; }

        [Required]
        [StringLength(50)]
        public string Address { get; set; }

        public string Info
        {
            get { return Name + " " + Surename + " " + Patronimic; }
        }

        public virtual ICollection<Doctor> Doctors { get; set; }

        public Patient()
        {
            Doctors = new List<Doctor>();
        }
    }
}
