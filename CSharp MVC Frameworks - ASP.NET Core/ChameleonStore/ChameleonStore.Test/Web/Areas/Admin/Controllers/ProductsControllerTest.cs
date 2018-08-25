using ChameleonStore.Web;
using ChameleonStore.Web.Areas.Admin.Controllers;
using FluentAssertions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace ChameleonStore.Test.Web.Areas.Admin.Controllers
{
    public class ProductsControllerTest
    {
        [Fact]
        public void CoursesControllerShouldBeInAdminArea()
        {
            // Arrange
            var controller = typeof(ProductsController);

            // Act
            var areaAttribute = controller
                .GetCustomAttributes(true)
                .FirstOrDefault(a => a.GetType() == typeof(AreaAttribute))
                as AreaAttribute;

            // Assert
            areaAttribute.Should().NotBeNull();
            areaAttribute.RouteValue.Should().Be(WebConstants.AdminArea);
        }

        [Fact]
        public void CoursesControllerShouldBeOnlyForAdminUsers()
        {
            // Arrange
            var controller = typeof(ProductsController);

            // Act
            var areaAttribute = controller
                .GetCustomAttributes(true)
                .FirstOrDefault(a => a.GetType() == typeof(AuthorizeAttribute))
                as AuthorizeAttribute;

            // Assert
            areaAttribute.Should().NotBeNull();
            areaAttribute.Roles.Should().Be(WebConstants.AdministratorRole);
        }
    }
}
