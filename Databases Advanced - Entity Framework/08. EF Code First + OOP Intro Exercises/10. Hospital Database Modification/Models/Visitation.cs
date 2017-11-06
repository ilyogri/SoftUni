using _10.Hospital_Database_Modification.Models;

namespace _10.Hospital_Database_Modification
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Visitation
    {
        [Key]
        public int Id { get; set; }

        public DateTime VisitationDate { get; set; }

        public List<string> Comments { get; set; }

        public Doctor Doctor { get; set; }
    }
}