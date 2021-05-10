using Pizzaria.PizzaElements;
using Pizzaria.SubApps;
using Pizzaria.Menu;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Pizzaria
{
    public partial class App : Form
    {
        internal Customer Customer = new Customer();
        internal readonly Elements DropdownElements = new Elements();
        public bool SelectClicked = false, RunTextChanged = true;

        #region On Start
        public App()
        {
            InitializeComponent();
            SetDropdowns();
        }

        /// <summary> 
        /// Sets the default values of the Combo Boxes 
        /// </summary>
        private void SetDropdowns()
        {
            DropdownMenu.Items.AddRange(Pizzaria.Menu.Menu.Pizzas);
            DropdownPizzaSizes.Items.AddRange(Pizza.SizesAvailable);
            DropdownMeat.Items.AddRange(Elements.Meats.Choices);
            DropdownSauce.Items.AddRange(Elements.Sauces.Choices);
            DropdownCheese.Items.AddRange(Elements.Cheeses.Choices);
            DropdownSalad.Items.AddRange(Elements.Salads.Choices);
            DropdownDoughs.Items.AddRange(Elements.Doughs.Choices);
            DropdownSpice.Items.AddRange(Elements.Spices.Choices);

            DropdownDrinks.Items.AddRange(Pizzaria.Menu.Menu.Drinks);
            DropdownDrinkSizes.Items.AddRange(Drink.SizesAvailable);
        }
        #endregion

        #region Event handlers
        private void SelectButton_Click(object sender, EventArgs e)
        {
            SelectClicked = true;

            //If Size or menu wasn't selected
            if (DropdownMenu.SelectedItem is null || DropdownPizzaSizes.SelectedItem is null
                || DropdownDrinks.SelectedItem is null || DropdownDrinkSizes.SelectedItem is null)
                if (AppHelpers.Display.DisplayWarnings(this)) return;

            //If SelectedItem isn't from BasketListBox
            if (BasketListBox.SelectedIndex == -1)
            {
                if (Pizzaria.Menu.Menu.Pizzas.Contains(DropdownMenu.Text)) AddItemToBasket(Customer.Pizza);
                if (Pizzaria.Menu.Menu.Drinks.Contains(DropdownDrinks.Text)) AddItemToBasket(Customer.Drink);
            }
            else AppHelpers.Update.UpdateBasketItem(ref Customer, this);

            //Update BasketTotal
            AppHelpers.Update.UpdateBasketTotal(ref BasketListBox, ref Customer, ref BasketTotal);

            //Reset selection
            SelectClicked = false;
        }
        private void RemoveButton_Click(object sender, EventArgs e)
        {
            if (BasketListBox.Items.Count is 0) return;

            //Get <item>.Name (remove size & price from string)
            string BasketItem = BasketListBox.SelectedItem != null ? 
                                BasketListBox.SelectedItem.ToString().Split(',')[0] : 
                                BasketListBox.Items[BasketListBox.Items.Count - 1].ToString().Split(',')[0];

            //If BasketItem is a pizza
            if (Customer.BasketPizzas.Contains(BasketItem)) 
                Customer.BasketPizzas.RemoveAt(BasketListBox.SelectedIndex);

            //If BasketItem is a drink
            else if (Customer.BasketDrinks.Contains(BasketItem))
                Customer.BasketDrinks.RemoveAt(BasketListBox.SelectedIndex);

            AppHelpers.Update.UpdateBasketTotal(ref BasketListBox, ref Customer, ref BasketTotal);
        }
        private void BasketListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (FoodItem item in Customer.FoodItems)
                if((sender as ListBox).Text == item.BasketDisplay())
                {
                    SelectClicked = true;
                    if (item is Pizza) AppHelpers.Display.DisplayPizza(item as Pizza, ref Customer, this);
                    else AppHelpers.Display.DisplayDrink(item as Drink, ref Customer, DropdownDrinkSizes, DropdownDrinks);
                    SelectClicked = false;
                    return;
                }
        }

        private void DropdownMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            //If clicked, this wasn't meant to be called
            if (SelectClicked) return;

            BasketListBox.SelectedIndex = -1;

            RunTextChanged = false;
            AppHelpers.Display.DisplayPizza(Customer.Pizza = null, ref Customer, this);
            RunTextChanged = true;
        }
        private void DropdownDrinks_SelectedIndexChanged(object sender, EventArgs e)
        {
            //If clicked, this wasn't meant to be called
            if (SelectClicked) return;

            RunTextChanged = false;
            AppHelpers.Display.DisplayDrink(Customer.Drink = null, ref Customer, DropdownDrinkSizes, DropdownDrinks);
            RunTextChanged = true;
        }

        private void BuyButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"Du vil nu købe: {Customer.BasketList.DisplayOrder()}\n\nPris: {BasketTotal.Text}", "Kvitering") == DialogResult.OK)
                Environment.Exit(0);
        }

        #region Add SelectedItem to Basket
        private void AddItemToBasket(FoodItem item)
        {
            if (item is Pizza)
            {
                Customer.BasketPizzas.Add((item as Pizza).GetPizza(DropdownElements));
                SetFoodItemDefaults("Pizza", DropdownMenu, DropdownPizzaSizes);
            }
            else if (item is Drink)
            {
                Customer.BasketDrinks.Add(new Drink(Customer.Drink.Name, DropdownDrinkSizes.Text));
                SetFoodItemDefaults("Drink", DropdownDrinks, DropdownDrinkSizes);
            }
        }

        /// <summary> 
        /// Sets the reset value of inserted food item 
        /// </summary>
        internal void SetFoodItemDefaults(string MainText, ComboBox Main, ComboBox Size)
        {
            Main.SelectedIndex = Size.SelectedIndex = -1;
            Main.Text = MainText;
            Size.Text = "Størrelse";
        }
        #endregion

        #endregion

        #region Dropdown TextChanged
        private void DropdownDrinkSizes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RunTextChanged && Customer.Drink != null)
                Customer.Drink.Size = (sender as ComboBox).Text;
        }
        private void DropdownSizes_TextChanged(object sender, EventArgs e) => DropdownTextChanged(ref DropdownElements.Size, sender);
        private void DropdownSauce_TextChanged(object sender, EventArgs e) => DropdownTextChanged(ref DropdownElements.Sauce, sender);
        private void DropdownCheese_TextChanged(object sender, EventArgs e) => DropdownTextChanged(ref DropdownElements.Cheese, sender);
        private void DropdownSalad_TextChanged(object sender, EventArgs e) => DropdownTextChanged(ref DropdownElements.Salad, sender);
        private void DropdownDoughs_TextChanged(object sender, EventArgs e) => DropdownTextChanged(ref DropdownElements.Dough, sender);
        private void DropdownSpices_TextChanged(object sender, EventArgs e) => DropdownTextChanged(ref DropdownElements.Spice, sender);
        private void DropdownMeat_TextChanged(object sender, EventArgs e) => DropdownTextChanged(ref DropdownElements.Meat, sender);

        private void DropdownTextChanged(ref Ingredient ingredient, object sender)
        {
            if (RunTextChanged) 
                ingredient.Value = (sender as ComboBox).Text;
        }
        #endregion

        #region SubButton Clicks
        private void ButtonMeat_Click(object sender, EventArgs e) => SubButtons_Click(1, new MeatApp(GetElement(1)));
        private void ButtonSalad_Click(object sender, EventArgs e) => SubButtons_Click(2, new SaladApp(GetElement(2)));
        private void ButtonSpice_Click(object sender, EventArgs e) => SubButtons_Click(3, new SpiceApp(GetElement(3)));
        private Ingredient GetElement(int Index)
        {
            if (Customer.Pizza is null) return null;

            switch (Index)
            {
                case 1: return (!DropdownElements.Meat.Default.Equals(DropdownMeat.Text) && DropdownElements.Meat.DefaultList is null ||
                            !DropdownElements.Meat.Default.Equals(DropdownMeat.Text) && DropdownElements.Meat.DefaultList.Count == 0)
                            ? Customer.Pizza.Elements.Meat : DropdownElements.Meat;

                case 2: return (DropdownElements.Salad.Default.Equals(DropdownSalad.Text) && DropdownElements.Salad.DefaultList is null ||
                            !DropdownElements.Salad.Default.Equals(DropdownSalad.Text) && DropdownElements.Salad.DefaultList.Count == 0)
                           ? Customer.Pizza.Elements.Salad : DropdownElements.Salad;

                case 3: return (DropdownElements.Spice.Default.Equals(DropdownSpice.Text) && DropdownElements.Spice.DefaultList is null ||
                            !DropdownElements.Spice.Default.Equals(DropdownSpice.Text) && DropdownElements.Spice.DefaultList.Count == 0)
                           ? Customer.Pizza.Elements.Salad : DropdownElements.Salad;

                default: return null;
            }
        }

        /// <summary> When a <see cref="SubApp"/> was clicked, run this </summary>
        /// <param name="CustomIndex">Determines if Meat, Salad or Spice was clicked</param>
        /// <param name="app">SubApp to display</param>
        public void SubButtons_Click(int CustomIndex, SubApp app)
        {
            if (Customer.Pizza is null) { AppHelpers.Display.DisplayWarnings(this); return; }

            //When SubApp.DialogResult return OK || When user is done with app
            if (app.ShowDialog() == DialogResult.OK)
            {
                //What element is to be modified?
                switch (CustomIndex)
                {
                    //Edit values from this app to values from SubApp
                    case 1: 
                        DropdownElements.Meat.ValueList = app.Stuffing.ToList();
                        DropdownMeat.Text = DropdownElements.Meat.ToString();
                        Customer.Pizza.Elements.Meat = DropdownElements.Meat;
                        break;
                    case 2:
                        DropdownElements.Salad.ValueList = app.Stuffing.ToList();
                        DropdownSalad.Text = DropdownElements.Salad.ToString();
                        Customer.Pizza.Elements.Salad = DropdownElements.Salad;
                        break;
                    case 3:
                        DropdownElements.Spice.ValueList = app.Stuffing.ToList();
                        DropdownSpice.Text = DropdownElements.Spice.ToString();
                        Customer.Pizza.Elements.Spice = DropdownElements.Spice;
                        break;
                }

                //Display
                AppHelpers.Display.DisplayPizza(Customer.Pizza, ref Customer, this);
            }
        }
        #endregion

        #region ShowIngredientButton Clicks
        private void ShowMeatButton_Click(object sender, EventArgs e) => HandleShowButtons(ref ShowMeatButton, DropdownMeat, "Kød");
        private void ShowSaladButton_Click(object sender, EventArgs e) => HandleShowButtons(ref ShowSaladButton, DropdownSalad, "Salater");
        private void ShowSpiceButton_Click(object sender, EventArgs e) => HandleShowButtons(ref ShowSpiceButton, DropdownSpice, "Krydderier");

        /// <summary> When a Show<ingredient>Button is clicked </summary>
        /// <param name="Button">Caller</param>
        /// <param name="Dropdown">Reference Dropdown</param>
        /// <param name="Ingredient">Ingredient type</param>
        public void HandleShowButtons(ref Button Button, ComboBox Dropdown, string Ingredient)
        {
            Button.Text = (Dropdown.Visible ^= true) ? $"Gem " : $"Vis ";
            Button.Text += Ingredient;

            FixLocations(new Location[]
            {
                new Location(12, 225),
                new Location(12, 252),
                new Location(12, 279)
            }, new ComboBox[]
            {
                DropdownMeat, DropdownSalad, DropdownSpice
            }, 0);
        }

        /// <summary> Updates GUI so positions look :ok_hand: </summary>
        /// <param name="Locations">Predefined Locations</param>
        /// <param name="Dropdowns">Dropdowns</param>
        /// <param name="Count">I just didn't want a variable for it</param>
        private void FixLocations(Location[] Locations, ComboBox[] Dropdowns, int Count)
        {
            foreach (ComboBox Dropdown in Dropdowns)
                if (Dropdown.Visible)
                {
                    Dropdown.Location = Locations[Count].Position;
                    Count++;
                }
        }
        #endregion
    }
}