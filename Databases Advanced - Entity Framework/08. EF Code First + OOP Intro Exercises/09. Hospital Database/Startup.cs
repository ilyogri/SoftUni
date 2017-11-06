namespace _09.Hospital_Database
{
    using System;
    using Models;

    public class Startup
    {
        public static void Main()
        {
            var context = new HospitalContext();

            AddPatients(context);
            context.SaveChanges();
        }

        public static void AddPatients(HospitalContext context)
        {
            context.Patients.Add(new Patient()
            {
                FirstName = "Kiko",
                LastName = "Ivanov",
                Address = "Dame Gruev",
                Email = "Kiko@abv.bg",
                BirthDate = new DateTime(1990, 5, 20),
                Picture = 51,
                HasMedicalInsurance = true,
                Diagnoses = new Diagnose() { DiagnoseName = "mnogo losho" },
                Medicaments = new Medicament() { MedicamentName = "siropche" },
                Visitations = new Visitation() { VisitationDate = new DateTime(2016, 5, 6) }
            });
            context.Patients.Add(new Patient()
            {
                FirstName = "Goshko",
                LastName = "Kottq",
                Address = "Halite",
                Email = "Goshko@abv.bg",
                BirthDate = new DateTime(1950, 6, 13),
                Picture = 101,
                HasMedicalInsurance = false,
                Diagnoses = new Diagnose() { DiagnoseName = "Tuberkoloza" },
                Medicaments = new Medicament() { MedicamentName = "Antibiotic" },
                Visitations = new Visitation() { VisitationDate = new DateTime(2011, 10, 12) }
            });
            context.Patients.Add(new Patient()
            {
                FirstName = "Afyo",
                LastName = "Matkov",
                Address = "Klucohor",
                Email = "Afyo@abv.bg",
                BirthDate = new DateTime(1979, 7, 14),
                Picture = 205,
                HasMedicalInsurance = true,
                Diagnoses = new Diagnose() { DiagnoseName = "Nastinka" },
                Medicaments = new Medicament() { MedicamentName = "Chaiche" },
                Visitations = new Visitation() { VisitationDate = new DateTime(2015, 1, 12) }
            });
        }
    }
}