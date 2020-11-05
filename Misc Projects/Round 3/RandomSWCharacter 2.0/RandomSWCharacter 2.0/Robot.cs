using DanhoLibrary;

namespace RandomSWCharacter_2._0
{
    internal class Robot : IGetInfo
    {
        private int Class { get; } = ConsoleItems.RandomNumber(5);
        private string[] ClassNames => new string[] { "Calculation", "Engineering", "Human", "Flight", "Labor" };
        private string Type { get; }
        private string ID { get; }

        public Robot()
        {
            Type = GetDroidType();
            ID = GetDroidID();
        }

        private string GetDroidID()
        {
            var split = Type.Split(" ");
            string result = split[0].ToCharArray()[0].ToString() + Class.ToString();

            if (split.Length > 1 && split[1] != string.Empty)
                result += split[1].ToCharArray()[0].ToString() + ConsoleItems.RandomNumber(Class + ClassNames[Class - 1].Length + Type.Length);

            return result;
        }
        public string GetDroidType() => Class switch
        {
            1 => new string[] { "Medical", "Biological Science", "Physical Science", "Mathematics" }.GetRandomItem(),
            2 => new string[] { "Astromech", "Exporation", "Enviormental", "Engineering", "Maintenance" }.GetRandomItem(),
            3 => new string[] { "Protocol", "Tutor", "Child Care", "Servant" }.GetRandomItem(),
            4 => new string[] { "Security", "Gladiator", "Battle", "Assassin" }.GetRandomItem(),
            5 => new string[] { "General Labor", "Labor-specialist", "Hazardous-service" }.GetRandomItem(),
            _ => "UNKNOWN",
        };

        public string GetInfo() => new string[]
        {
            "-- == Robot == --",
            $"ID: {ID}",
            $"Class: {Class}, {ClassNames[Class - 1]}",
            $"Type: {Type}"
        }.ToBigBoiString("\n");
    }
}