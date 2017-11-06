namespace _12.Remove_Inactive_Users
{
    using System;
    using System.Linq;
    using _08.Create_User;

    public class Program
    {
        public static void Main()
        {
            var date = DateTime.Parse(Console.ReadLine());
            var context = new UsersContext();
            var inactiveUsers = context
                .Users
                .Where(u => u.LastTimeLoggedIn < date)
                .ToList();
            inactiveUsers.ForEach(u => u.IsDeleted = true);
            context.SaveChanges();
            var deletedUsersCount = inactiveUsers.Count;

            if (deletedUsersCount == 0)
            {
                Console.WriteLine("No users have been deleted");
            }
            else
            {
                Console.WriteLine($"{deletedUsersCount} users have been deleted");
            }
        }
    }
}