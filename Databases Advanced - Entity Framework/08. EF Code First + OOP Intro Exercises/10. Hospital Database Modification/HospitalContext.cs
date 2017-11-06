namespace _10.Hospital_Database_Modification
{
    using System.Data.Entity;
    using Models;

    public class HospitalContext : _09.Hospital_Database.HospitalContext
    {
        public virtual DbSet<Doctor> Doctors { get; set; }

        public virtual DbSet<Visitation> Visitations { get; set; }

        public virtual DbSet<Diagnose> Diagnoses { get; set; }

        public virtual DbSet<Medicament> Medicaments { get; set; }

        public virtual DbSet<Patient> Patients { get; set; }

    }
}