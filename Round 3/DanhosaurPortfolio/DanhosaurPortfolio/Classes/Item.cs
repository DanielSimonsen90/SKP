namespace DanhosaurPortfolio.Classes
{
    public class Item
    {
        public virtual string Title { get; }
        public virtual string Description { get; }

        public Item(string title, string description)
        {
            Title = title;
            Description = description;
        }
    }
}
