using System.Linq;

namespace Pizzaria.Menu
{
    class Drink : FoodItem
    {
        public new int Price 
        { 
            get
            {
                int Price = 20;

                if (Size is null) return Price;

                for (int x = 0; x < SizesAvailable.Length; x++)
                    if (Size == "Lille" || Size == SizesAvailable[x])
                        break;
                    else Price += 5;
                return Price;
            } 
        }

        #region Constructor
        public Drink(string Name) => this.Name = Name;
        public Drink(string Name, string Size) : this(Name) =>
            this.Size = SizesAvailable.Contains(Size) ? Size : "Mellem";
        #endregion

        public override string ToString() => $"{Name}, {Price}";
        public override string BasketDisplay() => $"{Name}, {Size}, {Price}\n";
    }
}
