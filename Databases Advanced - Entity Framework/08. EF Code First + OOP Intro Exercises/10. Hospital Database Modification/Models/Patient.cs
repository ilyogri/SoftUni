using System.Text.RegularExpressions;

namespace _10.Hospital_Database_Modification
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Patient
    {
        private string email;

        [Key]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [RegularExpression("^[^_.@].+@[^.]+\\.[^.]+$")]
        public string Email
        {
            get
            { return this.email; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Email is required!");
                }
                if (!Regex.IsMatch(value, "^[^_.@].+@[^.]+\\.[^.]+$"))
                {
                    throw new ArgumentException("Not valid email!");
                }
                this.email = value;
            }
        }

        [Required]
        public DateTime BirthDate { get; set; }

        public int? Picture { get; set; }

        [Required]
        public bool HasMedicalInsurance { get; set; }

        public virtual Diagnose Diagnoses { get; set; }

        public virtual Medicament Medicaments { get; set; }

        public virtual Visitation Visitations { get; set; }
    }
}