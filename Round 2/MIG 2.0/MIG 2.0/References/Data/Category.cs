using System.Collections.Generic;

namespace MIG.References.Data
{
    public class Category
    {
        private readonly string Name;
        public List<Category> SubCategories;
        public List<Genre> Genres;
        public Category(string name) => Name = name;
        public override string ToString() => Name;
    }
}
