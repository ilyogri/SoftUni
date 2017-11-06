namespace _10.Hospital_Database_Modification
{
    using System.ComponentModel.DataAnnotations;

    public class Medicament
    {
        [Key]
        public int Id { get; set; }

        public string MedicamentName { get; set; }
    }
}