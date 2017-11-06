namespace _08.Create_User
{
    using Models;
    using System;

    public class Startup
    {
        public static void Main()
        {
            var context = new UsersContext();
           //use this in case the db is not created
            //context.Database.Initialize(true);

            AddUsers(context);
            context.SaveChanges();
        }

        public static void AddUsers(UsersContext context)
        {
            context.Users.Add(new User()
            {
                Username = "Gosta",
                Password = "aaDQ12<",
                Email = "Gosta@abv.bg",
                ProfilePicture = 6,
                RegisteredOn = new DateTime(2016, 1, 18),
                LastTimeLoggedIn = new DateTime(2017, 5, 21),
                Age = 16,
                IsDeleted = true
            });
            context.Users.Add(new User()
            {
                Username = "Misra",
                Password = "btaO1*",
                Email = "Misra@abv.bg",
                ProfilePicture = 255,
                RegisteredOn = new DateTime(2011, 6, 5),
                Age = 62,
                IsDeleted = false
            });
            context.Users.Add(new User()
            {
                Username = "Ogqam",
                Password = "llhqAF51_",
                Email = "Ogqam@yahoo.com",
                ProfilePicture = 161,
                RegisteredOn = new DateTime(2012, 5, 10),
                Age = 26,
                IsDeleted = true
            });
            context.Users.Add(new User()
            {
                Username = "Matt",
                Password = "agMF89)",
                Email = "Matt@gmail.com",
                RegisteredOn = new DateTime(2013, 9, 8),
                Age = 31,
                IsDeleted = false
            });
        }
    }
}