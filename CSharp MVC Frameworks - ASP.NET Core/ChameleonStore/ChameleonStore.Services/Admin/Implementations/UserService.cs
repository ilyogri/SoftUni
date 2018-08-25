using AutoMapper;
using ChameleonStore.Common.Areas.Admin.Users.ViewModels;
using ChameleonStore.Services.Admin.Interfaces;
using ChameleonStore.Web.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChameleonStore.Services.Admin.Implementations
{
    public class UserService : BaseEFService, IUserService
    {
        public UserService(
            ChameleonStoreContext context,
            IMapper mapper)
            : base(context, mapper)
        {
        }

        public async Task<IEnumerable<UserListingModel>> GetAllAsync(string currentUserId)
        {
            var users = await this.Context
                .Users
                .Where(u => u.Id != currentUserId)
                .Include(u => u.Orders)
                .ToListAsync();

            var model = this.Mapper.Map<IEnumerable<UserListingModel>>(users);

            return model;
        }
    }
}
