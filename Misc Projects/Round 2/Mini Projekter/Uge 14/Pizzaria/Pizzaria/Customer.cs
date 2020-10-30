using Pizzaria.Menu;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;

namespace Pizzaria
{
    class Customer
    {
        public Pizza Pizza;
        public Drink Drink;
        public ListBox BasketList
        {
            get
            {
                List<string> List = new List<string>
                    (from Pizza pizza in BasketPizzas
                     select pizza.BasketDisplay());

                List.AddRange(from Drink drink in BasketDrinks 
                              select drink.BasketDisplay());

                ListBox listBox = new ListBox();
                listBox.Items.AddRange(List.ToArray());

                return listBox;
            }
        }
        public List<FoodItem> FoodItems
        {
            get
            {
                List<FoodItem> List = new List<FoodItem>();
                List.AddRange(BasketPizzas);
                List.AddRange(BasketDrinks);
                return List;
            }
        }
        public List<Pizza> BasketPizzas = new List<Pizza>();
        public List<Drink> BasketDrinks = new List<Drink>();
    }
}
