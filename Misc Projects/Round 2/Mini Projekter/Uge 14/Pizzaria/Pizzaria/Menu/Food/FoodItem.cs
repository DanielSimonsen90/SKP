namespace Pizzaria.Menu
{
    internal abstract class FoodItem
    {
        public static string[] SizesAvailable = { "Lille", "Mellem", "Stor" };
        public int Price;
        public string Name, Size;

        public abstract string BasketDisplay();
        public override string ToString() => $"{Name}, {Price}";
    }
}
