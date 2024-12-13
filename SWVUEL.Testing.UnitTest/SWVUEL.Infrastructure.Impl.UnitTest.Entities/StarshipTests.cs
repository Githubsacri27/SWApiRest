using SWVUEL.Infrastructure.Contracts.Entities;

namespace SWVUEL.Testing.UnitTest
{
    public class StarshipTests
    {
        [Fact]
        public void Starship_WithEmptyName_ShouldBeInvalid()
        {
            // Arrange
            var starship = new Starship
            {
                name = "",
                cost_in_credits = "3500000"
            };

            // Act
            var isValid = IsStarshipValid(starship);

            // Assert
            Assert.False(isValid, "Starship should be invalid when name is empty.");
        }

        private bool IsStarshipValid(Starship starship)
        {
            if (string.IsNullOrWhiteSpace(starship.name)) return false;
            if (int.TryParse(starship.cost_in_credits, out int cost) && cost < 0) return false;

            return true;
        }
    }
}
