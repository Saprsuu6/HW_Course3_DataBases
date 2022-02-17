using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Polyclinic.Models
{
    internal class Doctor
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
        public string Spciality { get; set; }

        [Required]
        public string PriceOfEntry { get; set; }

        [Required]
        public string Procent { get; set; }

        public string Info
        {
            get { return Name + " " + Surename + " " + Patronimic; }
        }

        public virtual ICollection<Patient> Patients { get; set; }

        public Doctor()
        {
            Patients = new List<Patient>();
        }
    }
}
