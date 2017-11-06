namespace _11.Get_Users_by_Email_Provider
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;
    using _08.Create_User;

    public class GetUsersByEmailProvider
    {
        public static void Main()
        {
            var domain = Console.ReadLine();
            var context = new UsersContext();

            var users = context
                .Users
                .ToList();

            foreach (var u in users)
            {
                if (Regex.IsMatch(u.Email, domain))
                {
                     Console.WriteLine(u.Username);
                }
            }
        }
    }
}