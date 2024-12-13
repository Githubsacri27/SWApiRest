using Moq;
using SWVUEL.Infrastructure.Contracts.Entities;
using SWVUEL.Infrastructure.Contracts;
using SWVUEL.Library.Impl;

namespace SWVUEL.Testing.UnitTest
{
    public class ServiceTests
    {
        [Fact]
        public async Task GetStarshipNameAndModelByIdAsync_WithValidId_ReturnsNameAndModel()
        {
            // Arrange
            var mockRepository = new Mock<IRepository>();
            var service = new Service(mockRepository.Object);
            int validId = 1;
            var expectedStarship = new Starship { id = validId, name = "CR90 corvette", model = "Corvette" };

            mockRepository.Setup(repo => repo.GetStarshipByIdAsync(validId))
                          .ReturnsAsync(expectedStarship);

            // Act
            var result = await service.GetStarshipNameAndModelByIdAsync(validId);

            // Assert
            Assert.Equal("CR90 corvette", result.Name);
            Assert.Equal("Corvette", result.Model);
        }

        [Fact]
        public async Task GetStarshipNameAndModelByIdAsync_WithNonExistentId_ReturnsNull()
        {
            // Arrange
            var mockRepository = new Mock<IRepository>();
            var service = new Service(mockRepository.Object);
            int nonExistentId = 99;

            mockRepository.Setup(repo => repo.GetStarshipByIdAsync(nonExistentId))
                          .ReturnsAsync((Starship)null); // Simula que no existe

            // Act
            var result = await service.GetStarshipNameAndModelByIdAsync(nonExistentId);

            // Assert
            Assert.Null(result.Name);
            Assert.Null(result.Model);
        }

        [Fact]
        public async Task GetStarshipNameAndModelByIdAsync_WithInvalidId_ThrowsArgumentException()
        {
            // Arrange
            var mockRepository = new Mock<IRepository>();
            var service = new Service(mockRepository.Object);
            int invalidId = -1;

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() => service.GetStarshipNameAndModelByIdAsync(invalidId));
        }
    }
}
