namespace Team_Generator
{
    class PocketMonster
    {
        public PocketMonster(string LabelText, string TypeOne, string TypeTwo, string FighterType, int Generation, string PictureLocation)
        {
            this.LabelText = LabelText;
            this.TypeOne = TypeOne;
            this.TypeTwo = TypeTwo;
            this.FighterType = FighterType;
            this.Generation = Generation;
            this.PictureLocation = PictureLocation;
        }

        #region Properties
        public string LabelText { get; set; }
        public string TypeOne { get; set; }
        public string TypeTwo { get; set; }
        public string FighterType { get; set; }
        public int Generation { get; set; }
        public string PictureLocation { get; set; }
        #endregion
    }
}
