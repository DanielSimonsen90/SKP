using Pizzaria.Menu;
using System.Windows.Forms;

namespace Pizzaria.AppHelpers
{
    class Display
    {
        /// <summary> 
        /// Displays warnings if needed 
        /// </summary>
        public static bool DisplayWarnings(App app)
        {
            //Clear warnings
            app.SizeWarningLabel.Visible = false;
            app.MenuWarningLabel.Visible = false;

            //Depending which was null, display respective warning
            if (app.DropdownMenu.SelectedItem is null && app.DropdownDrinks.SelectedItem is null)
                app.MenuWarningLabel.Visible = true;
            else if (app.DropdownMenu.SelectedItem != null && app.DropdownPizzaSizes.Text == "Størrelse" ||
                    app.DropdownDrinks.SelectedItem != null && app.DropdownDrinkSizes.Text == "Størrelse")
                app.SizeWarningLabel.Visible = true;
            return app.SizeWarningLabel.Visible || app.MenuWarningLabel.Visible;
        }
        /// <summary> Replaces dropdown values with selected pizza's values </summary>
        /// <param name="pizza"></param>
        public static void DisplayPizza(Pizza pizza, ref Customer Customer, App app)
        {
            Customer.Pizza = pizza is null ? Pizzaria.Menu.Menu.Pizzas[app.DropdownMenu.SelectedIndex] : pizza;
            app.DropdownMenu.Text = Customer.Pizza.MenuDisplay(app);
            if (!app.RunTextChanged) Update.UpdatePrice(ref Customer);
        }
        /// <summary> Replaces dropdown values with selected drink's values </summary>
        /// <param name="pizza"></param>
        public static void DisplayDrink(Drink drink, ref Customer Customer, ComboBox DropdownDrinkSizes, ComboBox DropdownDrinks)
        {
            Customer.Drink = drink is null ? Pizzaria.Menu.Menu.Drinks[DropdownDrinks.SelectedIndex] : drink;
            //DropdownDrinks.Text = Customer.Drink.Type;
            if (DropdownDrinkSizes.Text == string.Empty)
                DropdownDrinkSizes.Text = Customer.Drink.Size is null ? Drink.SizesAvailable[1] : drink.Size;
            else Customer.Drink.Size = DropdownDrinkSizes.Text;
        }
    }
}