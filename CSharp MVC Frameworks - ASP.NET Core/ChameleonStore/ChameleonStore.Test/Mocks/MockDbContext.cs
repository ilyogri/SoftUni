using ChameleonStore.Web.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChameleonStore.Test.Mocks
{
    public static class MockDbContext
    {
        public static ChameleonStoreContext GetContext()
        {
            var options = new DbContextOptionsBuilder<ChameleonStoreContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new ChameleonStoreContext(options);
        }
    }
}
