namespace _10.Hospital_Database_Modification.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;
    using Models;

    public class Doctor
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Specialty { get; set; }

        public List<Visitation> Visitation { get; set; }
    }
}