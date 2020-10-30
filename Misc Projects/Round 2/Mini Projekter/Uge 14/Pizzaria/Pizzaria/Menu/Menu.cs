using Pizzaria.PizzaElements;

namespace Pizzaria.Menu
{
    class Menu
    {
        public static Pizza[] Pizzas = 
        {
            new Pizza("Pepperoni", 69, new Elements()
            {
                Meat = new Ingredient(Elements.Meats.Choices, 1, 2),
                Cheese = new Ingredient(Elements.Cheeses.Choices, 1),
                Sauce = new Ingredient(Elements.Sauces.Choices, 1),
            }),
            new Pizza("Salat", 69, new Elements() 
            {
                Salad = new Ingredient(Elements.Salads.Choices, 1, 2, 3),
            }),
            new Pizza("Meat Lover", 69, new Elements()
            {
                Meat = new Ingredient(Elements.Meats.Choices, 1, 2, 3, 4, 5, 6, 7, 8)
            }),
            new Pizza("Lav-selv Pizza", 69, new Elements())
        };

        public static Drink[] Drinks =
        {
            new Drink("Coca Cola"),
            new Drink("Pepsi"),
            new Drink("Fanta"),
            new Drink("Carsberg Sport"),
            new Drink("Dr. Pepper")
        };
    }
}
