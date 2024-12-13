using Moq;
using SWVUEL.Infrastructure.Contracts;
using SWVUEL.Infrastructure.Impl;
using SWVUEL.Infrastructure.Contracts.Entities;
using SWVUEL.Library.Impl;
using Xunit;

namespace SWVUEL.Testing.UnitTest
{
    public class RepositoryTests
    {
        [Fact]
        public async Task SyncStarshipAsync_ReturnsCorrectNames()
        {
            // Arrange
            var mockRepository = new Mock<IRepository>();

            var mockStarshipResponse = new SWVUEL.Infrastructure.Contracts.Entities.StarshipApiResponseEntity
            {
                results = new List<Starship>
                {
                    new Starship { name = "CR90 corvette", url = "https://swapi.dev/api/starships/2/" },
                    new Starship { name = "Star Destroyer", url = "https://swapi.dev/api/starships/3/" },
                    new Starship { name = "Millennium Falcon", url = "https://swapi.dev/api/starships/10/" }
                }
            };

            mockRepository.Setup(repo => repo.GetStarshipFromApiAsync())
                .ReturnsAsync(mockStarshipResponse);

            mockRepository.Setup(repo => repo.GetAllStarshipNamesAsync())
                .ReturnsAsync(mockStarshipResponse.results.Select(s => s.name).ToList());

            var service = new Service(mockRepository.Object);

            // Act
            var result = await service.SyncStarshipAsync();

            // Assert
            Assert.NotNull(result); 
            Assert.Equal(3, result.Count); 
            Assert.Contains("CR90 corvette", result);
            Assert.Contains("Star Destroyer", result);
            Assert.Contains("Millennium Falcon", result);

            mockRepository.Verify(repo => repo.GetStarshipFromApiAsync(), Times.Once);
            mockRepository.Verify(repo => repo.GetAllStarshipNamesAsync(), Times.Once);
        }
    }
}
