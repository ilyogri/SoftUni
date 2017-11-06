namespace _09.Hospital_Database.Models
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
    }
}