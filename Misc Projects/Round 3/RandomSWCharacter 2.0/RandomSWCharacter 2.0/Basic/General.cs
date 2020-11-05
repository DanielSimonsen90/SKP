using DanhoLibrary;

namespace RandomSWCharacter_2._0
{
    public class General : IGetInfo
    {
        private string Name { get; }
        private int Age { get; }
        private Gender Gender { get; }

        public General()
        {
            Gender = ConsoleItems.RandomNumber(2) == 1 ? Gender.Male : Gender.Female;
            Name = Gender.Names.GetRandomItem();
            Age = ConsoleItems.RandomNumber(15, 69);
        }

        public string GetInfo() => new string[]
        {
            $"-- == Baisc Presentation == --",
            $"Name: {Name}",
            $"Age: {Age}",
            $"Gender: {Gender}"
        }.ToBigBoiString("\n");
    }
}