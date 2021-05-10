using System.Collections.Generic;
using System.Windows.Forms;

namespace Pizzaria.PizzaElements
{
	internal class Elements
	{
		#region Static Ingredients
		public static Ingredient
			//ctor
			Sizes = new Ingredient("Lille", "Medium", "Stor", "Familie"),
			Doughs = new Ingredient("Normal", "Dobbel", "Deep Pan"),

			//Not included in ctor
			Sauces = new Ingredient("Ingen sovs", "Tomat", "Bernaise", "Dressing"),
			Cheeses = new Ingredient("Ingen ost", "Cheddar"),
			Spices = new Ingredient("Intet krydderi", "Karry", "Kanel", "Salt", "Pepper"),
			Meats = new Ingredient("Intet kød", "Pepperoni", "Skinke", "Bacon", "Kylling", "Oksekød", "Cotail Pølser", "Kebab", "Tun"),
			Salads = new Ingredient("Ingen salat", "Salat", "Tomat", "Agurk", "Pepperfrugt", "Ananas");
		#endregion

		public Ingredient Size, Dough, Sauce, Cheese, Spice, Meat, Salad;

		#region Constructors
		/// <summary> Pizza elements </summary>
		/// <param name="Size">Small, Medium, Large, Family</param>
		/// <param name="Dough">Normal, Dobbel, Deep Pan</param>
		/// <param name="Sauce">Tomat, Bernaise, Dressing</param>
		public Elements()
		{
			Size = new Ingredient(Sizes.Choices, 1);
			Dough = new Ingredient(Doughs.Choices, 0);

			SetDefault(ref Sauce, Sauces.Choices);
			SetDefault(ref Cheese, Cheeses.Choices);
			SetDefault(ref Spice, Spices.Choices);
			SetDefault(ref Meat, Meats.Choices);
			SetDefault(ref Salad, Salads.Choices);
		}
		public Elements(int SizeIndex, int DoughIndex) : this()
		{
			Size = new Ingredient(Sizes.Choices, SizeIndex);
			Dough = new Ingredient(Doughs.Choices, DoughIndex);
		}
		private void SetDefault(ref Ingredient ingredient, string[] Choices)
		{
			ingredient = new Ingredient(Choices, true);
			ingredient.Default = ingredient.Choices[0];
		}
		#endregion

		#region Display
		public void Display(App app)
		{
			DisplayOnBox(app.DropdownPizzaSizes, "Størrelse", Size);
			DisplayOnBox(app.DropdownMeat, "Kød", Meat);
			DisplayOnBox(app.DropdownSauce, "Sovs", Sauce);
			DisplayOnBox(app.DropdownCheese, "Ost", Cheese);
			DisplayOnBox(app.DropdownSalad, "Salat", Salad);
			DisplayOnBox(app.DropdownDoughs, "Dej", Dough);
			DisplayOnBox(app.DropdownSpice, "Krydderi", Spice);
		}
		private void DisplayOnBox(ComboBox Dropdown, string DropdownDefault, Ingredient ingredient)
		{
			if (DropdownDefault == "Størrelse" && 
				Dropdown.Text.Equals(DropdownDefault))
				return;

			Dropdown.Text = ingredient.ToString();
		}
		#endregion

		#region Extra stuffing
		public int GetExtraStuffing()
		{
			int Price = 0;
			var IngList = new Ingredient[] { Size, Dough, Sauce, Cheese, Spice, Meat, Salad };

			for (int x = 0; x < IngList.Length; x++)
				Price += ExtraStuffingCheck(IngList[x]);

			return Price;
		}
		private int ExtraStuffingCheck(Ingredient ingredient)
		{
			//If no custom values
			if (ingredient.Value is null && ingredient.ValueList is null)
				return 0;

			//Create 2 lists, figure out if data is singular or muliple
			List<string> Default = ingredient.DefaultList ?? new List<string>() { ingredient.Default },
						 Value = ingredient.ValueList ?? new List<string>() { ingredient.Value };
			int Price = 0;

			foreach (string item in Value)
				if (!Default.Contains(item))
					Price += 5;

			return Price;
		}
		#endregion

	}
}
