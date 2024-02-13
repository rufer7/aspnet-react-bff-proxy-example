using ReactBffProxy.Shared;

namespace ReactBffProxy.Server;

public class DrinksService
{
    private IList<DrinkModel> _drinks = new List<DrinkModel>
    {
        new() { DrinkId = 1, Name = "Coke", Category = "Arbitrary", Type = "Arbitrary" },
        new() { DrinkId = 2, Name = "Pepsi", Category = "Arbitrary", Type = "Arbitrary" },
        new() { DrinkId = 3, Name = "Dr. Pepper", Category = "Arbitrary", Type = "Arbitrary" },
        new() { DrinkId = 4, Name = "Sprite", Category = "Arbitrary", Type = "Arbitrary" },
        new() { DrinkId = 5, Name = "Mountain Dew", Category = "Arbitrary", Type = "Arbitrary" },
    };

    public IList<DrinkModel> GetAll()
    {
        return _drinks;
    }
}
