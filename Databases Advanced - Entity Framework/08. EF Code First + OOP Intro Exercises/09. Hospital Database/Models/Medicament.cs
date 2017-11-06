namespace _09.Hospital_Database.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Medicament
    {
        [Key]
        public int Id { get; set; }

        public string MedicamentName { get; set; }
    }
}