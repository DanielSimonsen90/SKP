using Pizzaria.Menu;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Pizzaria
{
    internal static class CollectionExtender
    {
        public static bool Contains(this List<Pizza> Pizzas, string Name)
        {
            foreach (Pizza pizza in Pizzas)
                if (pizza.Name == Name)
                    return true;
            return false;
        }
        public static bool Contains(this Pizza[] Pizzas, string Name)
        {
            foreach (Pizza pizza in Pizzas)
                if (pizza.ToString() == Name)
                    return true;
            return false;
        }

        public static bool Contains(this List<Drink> Drinks, string Name)
        {
            foreach (Drink drink in Drinks)
                if (drink.Name == Name)
                    return true;
            return false;
        }
        public static bool Contains(this Drink[] Drinks, string Name)
        {
            foreach (Drink drink in Drinks)
                if (drink.Name == Name.Split(',')[0])
                    return true;
            return false;
        }

        /// <summary>
        /// Displays order
        /// </summary>
        public static string DisplayOrder(this ListBox Box)
        {
            string result = "\n";
            foreach (string item in Box.Items)
                result += item + "\n";
            return result;
        }
    }
}