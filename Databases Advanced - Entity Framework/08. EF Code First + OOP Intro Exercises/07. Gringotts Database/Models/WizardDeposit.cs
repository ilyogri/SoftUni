namespace _07.Gringotts_Database.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class WizardDeposit
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(60)]
        [Required]
        public string LastName  { get; set; }

        [MaxLength(1000)]
        public string Notes { get; set; }

        [Range(0, Int32.MaxValue, ErrorMessage = "Invalid Number")]
        public int Age { get; set; }

        [MaxLength(100)]
        public string MagicWandCreator { get; set; }

        [Range(0, Int16.MaxValue, ErrorMessage = "Invalid Number")]
        public int MagicWandSize { get; set; }

        [MaxLength(20)]
        public string DepositGroup { get; set; }

        public DateTime DepositStartDate { get; set; }

        public float DepositAmount { get; set; }

        public float DepositInterest { get; set; }

        public float DepositCharge { get; set; }

        public DateTime DepositExpirationDate { get; set; }

        public bool IsDepositExpired { get; set; }
    }
}