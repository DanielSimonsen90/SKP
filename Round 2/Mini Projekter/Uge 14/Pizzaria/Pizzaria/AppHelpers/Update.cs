using Pizzaria.Menu;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Pizzaria.AppHelpers
{
    class Update
    {
        /// <summary>
        /// Updates <paramref name="BasketTotal"/> label by calculating Discount
        /// </summary>
        public static void UpdateBasketTotal(ref ListBox BasketListBox, ref Customer Customer, ref Label BasketTotal)
        {
            UpdateBasketListBox(BasketListBox, Customer, out string[] Range);
            BasketTotal.Text = $"I alt: {GetBasketTotal(Range, Customer)} kr.";
        }

        /// <summary> 
        /// Removes all values in box, and adds all new values 
        /// </summary>
        private static void UpdateBasketListBox(ListBox BasketListBox, Customer Customer, out string[] Range)
        {
            //Remove all previous items
            for (int x = BasketListBox.Items.Count - 1; x >= 0; x--)
                BasketListBox.Items.RemoveAt(x);

            //Put Customer's items in BasketListBox
            BasketListBox.Items.AddRange(Customer.BasketList.Items);

            //If there's a discount, add that too
            if (DiscountCheck(Customer, out Range))
                BasketListBox.Items.AddRange(Range);
        }
        /// <summary> Get the number displayed in <see cref="BasketTotal"/> </summary>
        /// <param name="DiscountRange">Range from <see cref="DiscountCheck(out string[])"/></param>
        private static string GetBasketTotal(string[] DiscountRange, Customer Customer)
        {
            int TotalPrice = 0;

            //Add all Pizza.Price into TotalPrice
            for (int x = 0; x < Customer.BasketPizzas.Count; x++)
                TotalPrice += Customer.BasketPizzas[x].Price;

            //Add all Drink.Price into TotalPrice
            for (int x = 0; x < Customer.BasketDrinks.Count; x++)
                TotalPrice += Customer.BasketDrinks[x].Price;

            //For each string in DiscountRange, reduce TotalPrice by 10%
            for (int x = 0; x < DiscountRange.Length; x++)
                TotalPrice -= (TotalPrice / 100 * 10);

            return TotalPrice.ToString();
        }

        /// <summary>
        /// Updates items that are already in Basket to the new values
        /// </summary>
        internal static void UpdateBasketItem(ref Customer Customer, App app)
        {
            FoodItem Selected = Customer.FoodItems[app.BasketListBox.SelectedIndex];
            int Index = -1;

            if (Selected is Pizza)
            {
                for (int x = 0; x < Customer.BasketPizzas.Count; x++)
                    if (Customer.BasketPizzas[x] == Selected)
                        Index = x;

                Customer.BasketPizzas[Index] = (Selected as Pizza).GetPizza(app.DropdownElements);
                app.SetFoodItemDefaults("Pizza", app.DropdownMenu, app.DropdownPizzaSizes);
            }
            else if (Selected is Drink)
            {
                for (int x = 0; x < Customer.BasketDrinks.Count; x++)
                    if (Customer.BasketDrinks[x] == Selected)
                        Index = x;

                Customer.BasketDrinks[Index] = new Drink(app.DropdownDrinks.Text, app.DropdownDrinkSizes.Text);
                app.SetFoodItemDefaults("Drink", app.DropdownDrinks, app.DropdownDrinkSizes);
            }
        }

        /// <summary> Check for the 2 pizza x 2 drink discount </summary>
        /// <param name="Range">Discount messages</param>
        /// <returns>Returns if there is a discount</returns>
        private static bool DiscountCheck(Customer Customer, out string[] Range)
        {
            //Variables
            int PizzaLength = Customer.BasketPizzas.Count,
                DrinkLength = Customer.BasketDrinks.Count;
            bool Result = PizzaLength >= 2 && DrinkLength >= 2;
            List<string> RangeList = new List<string>();

            if (Result) RangeList.Add(string.Empty);

            //Discount check
            while (true)
                if (PizzaLength >= 2 && DrinkLength >= 2)
                {
                    RangeList.Add("Rabat! 2 pizzaer & 2 drinks: -10%");
                    PizzaLength -= 2;
                    DrinkLength -= 2;
                }
                else break;

            //Return
            Range = RangeList.ToArray();
            return Result;
        }

        /// <summary> 
        /// Updates the price of order 
        /// </summary>
        public static void UpdatePrice(ref Customer Customer)
        {
            //Updates price depending on Size
            Customer.Pizza.Price -= 15;
            for (int x = 0; x < Pizza.SizesAvailable.Length; x++)
            {
                if (Customer.Pizza.Elements.Size.Default == Pizza.SizesAvailable[x]) break;
                Customer.Pizza.Price += 15;
            }

            //Update price depending if custom stuffing
            Customer.Pizza.Price += Customer.Pizza.Elements.GetExtraStuffing();
        }
    }
}