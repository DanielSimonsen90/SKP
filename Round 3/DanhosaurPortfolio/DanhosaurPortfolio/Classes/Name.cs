namespace DanhosaurPortfolio.Classes
{
    public struct Name
    {
        public string Full => "Daniel Simonsen";
        public string First => Split(0);
        public string Last => Split(1);
        private string Split(int pos) => Full.Split(' ')[pos];
        public override string ToString() => Full;
    }
}
