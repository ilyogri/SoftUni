namespace ChameleonStore.Common.Areas.Admin.Users.ViewModels
{
    public class UserListingModel
    {
        public string Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public bool IsAdmin { get; set; }

        public int OrdersMade { get; set; }
    }
}
