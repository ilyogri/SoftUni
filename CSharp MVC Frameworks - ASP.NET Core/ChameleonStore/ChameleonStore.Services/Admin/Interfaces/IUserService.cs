using ChameleonStore.Common.Areas.Admin.Users.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChameleonStore.Services.Admin.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserListingModel>> GetAllAsync(string currentUserId);
    }
}
