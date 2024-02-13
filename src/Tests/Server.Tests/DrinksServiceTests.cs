using ReactBffProxy.Server;

namespace Server.Tests;

public class DrinksServiceTests
{
    [Fact]
    public void GetAll_ReturnsAllDrinks()
    {
        // Arrange
        var drinksService = new DrinksService();

        // Act
        var drinks = drinksService.GetAll();

        // Assert
        Assert.Equal(5, drinks.Count);
    }
}
