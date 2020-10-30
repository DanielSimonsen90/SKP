using System;
using System.Windows.Forms;
using Pizzaria.PizzaElements;
using System.Collections.Generic;

namespace Pizzaria.Menu
{
    internal class Pizza : FoodItem
    {
        #region Variables
        public static new string[] SizesAvailable = Elements.Sizes.Choices;
        public Elements Elements, AppElements;
        #endregion

        public Pizza(string Name, int Price, Elements Elements)
        {
            this.Price = Price;
            this.Name = Name;
            this.Elements = Elements;
        }

        #region Display Information
        public Pizza GetPizza(Elements appElements)
        {
            AppElements = appElements;
            Elements = SetElements();
            return this;
        }
        private Elements SetElements()
        {
            SetElement(AppElements.Size, ref Elements.Size);
            SetElement(AppElements.Dough, ref Elements.Dough);
            SetElement(AppElements.Sauce, ref Elements.Sauce);
            SetElement(AppElements.Cheese, ref Elements.Cheese);
            SetElement(AppElements.Spice, ref Elements.Spice);
            SetElement(AppElements.Salad, ref Elements.Salad);
            SetElement(AppElements.Meat, ref Elements.Meat);
            return Elements;
        }
        private void SetElement(Ingredient appIngredient, ref Ingredient ingredient)
        {
            //if (ingredient is null) return;

            if (ingredient.Default != null)
                ingredient.Value = appIngredient.Value;
            else if (ingredient.DefaultList is null)
                if (ingredient.ValueList is null)
                    ingredient.ValueList = new List<string>() { appIngredient.Value };
                else ingredient.ValueList.Add(appIngredient.Value);
        }
        #endregion

        #region ToString stuff
        public string ToString(App app) => MenuDisplay(app);
        public string MenuDisplay(App app)
        {
            try { Elements.Display(app); }
            catch (Exception e) { MessageBox.Show(e.Message); }
            return ToString();
        }
        public override string BasketDisplay() => $"{Name}, {Elements.Size}, {Price}\n";
        #endregion
    }
}