namespace _07.Gringotts_Database
{
    using Models;
    using System;

    public class Startup
    {
        public static void Main()
        {
            var context = new GringottsContext();
            context.Database.Initialize(true);

            AddWizards(context);
            context.SaveChanges();
        }

        public static void AddWizards(GringottsContext context)
        {
            WizardDeposit dumbledore = new WizardDeposit()
            {
                FirstName = "Albus",
                LastName = "Dumbledore",
                Age = 150,
                MagicWandCreator = "Antioch Peverell",
                MagicWandSize = 15,
                DepositStartDate = new DateTime(2016, 10, 20),
                DepositExpirationDate = new DateTime(2020, 10, 20),
                DepositAmount = 20000.24f,
                DepositCharge = 0.2f,
                IsDepositExpired = false
            };

            WizardDeposit astor = new WizardDeposit()
            {
                FirstName = "Astor",
                LastName = "Astorov",
                Age = 202,
                MagicWandCreator = "Mihail Gegov",
                MagicWandSize = 21,
                DepositStartDate = new DateTime(2014, 05, 15),
                DepositExpirationDate = new DateTime(2017, 11, 28),
                DepositAmount = 5517f,
                DepositCharge = 1f,
                IsDepositExpired = true
            };

            WizardDeposit chiko = new WizardDeposit()
            {
                FirstName = "Chiko",
                LastName = "Chachev",
                Age = 85,
                MagicWandCreator = "Farq Dioqa",
                MagicWandSize = 51,
                DepositStartDate = new DateTime(2010, 01, 10),
                DepositExpirationDate = new DateTime(2018, 03, 21),
                DepositAmount = 6161,
                DepositCharge = 2f,
                IsDepositExpired = false
            };

            WizardDeposit hoasq = new WizardDeposit()
            {
                FirstName = "Hoasq",
                LastName = "Tikap",
                Age = 85,
                MagicWandCreator = "Masty",
                MagicWandSize = 25,
                DepositStartDate = new DateTime(2011, 02, 03),
                DepositExpirationDate = new DateTime(2021, 06, 07),
                DepositAmount = 1925,
                DepositCharge = 0.12f,
                IsDepositExpired = true
            };

            context.WizardDeposit.Add(dumbledore);
            context.WizardDeposit.Add(astor);
            context.WizardDeposit.Add(chiko);
            context.WizardDeposit.Add(hoasq);
        }
    }
}