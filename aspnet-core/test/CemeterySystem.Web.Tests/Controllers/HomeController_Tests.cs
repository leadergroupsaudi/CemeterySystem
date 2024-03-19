using System.Threading.Tasks;
using CemeterySystem.Models.TokenAuth;
using CemeterySystem.Web.Controllers;
using Shouldly;
using Xunit;

namespace CemeterySystem.Web.Tests.Controllers
{
    public class HomeController_Tests: CemeterySystemWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}