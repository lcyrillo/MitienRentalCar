using Autofac.Extras.Moq;
using Microsoft.Extensions.Configuration;
using Mitien.RentalCar.Business.Interfaces.Repositories;
using Mitien.RentalCar.Business.ResponseModels;
using Mitien.RentalCar.Repository.Repositories;
using Moq;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Xunit;

namespace Mitien.RentalCar.Tests.UnitTests.Mitien.RentalCar.Repository.Test;

public class UserTypeRepositoryUnityTest
{
    [Fact]
    public async Task GetAllUserTypes_OnSuccess_ReturnStatusCode200()
    {
        // Arrange
        using (var mock = AutoMock.GetLoose())
        {
            mock.Mock<SqlConnection>()
                .Setup(x => x.Database)
                .Returns("SqlServer");


            var mockIConfiguration = new Mock<IConfiguration>();
            mockIConfiguration
                .Setup(repo => repo.GetConnectionString("SqlServer"))
                .Returns("");

            var mockUserTypeRepo = new Mock<IUserTypeRepository>();
            mockUserTypeRepo
                .Setup(repo => repo.GetAll())
                .ReturnsAsync(new List<UserTypeResponseModel>());

            var sut = new UserTypeRepository(mockIConfiguration.Object);
        

            // Act
            var result = await sut.GetAll();

            // Assert
            mockUserTypeRepo.Verify(
                repo => repo.GetAll(),
                Times.Once()
            );
        }
    }
}

