namespace FootballManager
{
    using Models;

    public class Program
    {
        public static void Main()
        {
            var context = new FMContext();

            context.Teams.Add(new Team()
            {
                Name = "Real Madrid"
            });
            context.SaveChanges();
        }
    }
}