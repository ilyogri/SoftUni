namespace _10.Hospital_Database_Modification
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Diagnose
    {
        [Key]
        public int Id { get; set; }

        public string DiagnoseName { get; set; }

        public List<string> Comments { get; set; }
    }
}