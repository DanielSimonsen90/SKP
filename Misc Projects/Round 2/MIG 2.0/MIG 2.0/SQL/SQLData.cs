using DanhoLibrary.SQL;
using MIG.Ideas;

namespace MIG.SQL
{
    internal class SQLData
    {
        #region Statics
        public static Database MIG_V2_Ideas = new Database("MIG_V2_Ideas", new Table[]
        {
            new Table("Idea", new Column[]
            {

            })
        });
        public static int Length => int.Parse(MIG_V2_Ideas["Idea"].ExecuteReader("SELECT LENGTH(IdeaID) FROM Idea")[0]);
        public static int SaveIdea(Idea idea)
        {
            var Result = idea.GetInfo();
            MIG_V2_Ideas["Idea"].InsertInto($"{GetValues(idea)}, {Length}");
            return Result;
        }
        public static void ViewPastIdeas(int ID)
        {
            System.Console.Clear();
            MIG_V2_Ideas["Idea"].GetDataList<Idea>($"SELECT * FROM Idea WHERE IdeaID == {ID}")[0].GetInfo();
        }
        private static string GetValues(Idea idea) =>
            new System.Collections.Generic.List<SQLData>()
            {
                new SQLData(idea.Title),
                new SQLData(idea.References),
                new SQLData(idea.Genre),
                new SQLData(idea.Genre.Drums),
                new SQLData(idea.Genre.Synths),
                new SQLData(idea.Genre.Instruments)
            }.ValueAsString();
        #endregion

        public object Value;
        public SQLData(object Value) => this.Value = Value;
        public override string ToString()
        {
            if (Value.GetType() == typeof(References.Reference.Reference)) return HandleReferences(Value as References.Reference.Reference);
            else if (Value.GetType() == typeof(References.Genre)) return HandleGenre(Value as References.Genre);
            else if (Value.GetType() == typeof(SongElements.Drums.Drums)) return HandleDrums(Value as SongElements.Drums.Drums);
            else if (Value.GetType() == typeof(SongElements.Synths.Synths)) return HandleSynths(Value as SongElements.Synths.Synths);
            else if (Value.GetType() == typeof(SongElements.Instruments)) return HandleInstruments(Value as SongElements.Instruments);
            else return HandleStrings(Value.ToString()) + ",";
        }

        #region HandleElements
        private string HandleStrings(string input)
        {
            if (input is null) return "'NULL'";
            if (input.Contains("'")) input = input.Replace("'", "''");
            return $"'{input}'";
        }
        private string HandleBools(bool input) => HandleStrings(input ? "true" : "false");
        //private bool ConvertToBool(int value) => value == 1;
        
        private string HandleReferences(References.Reference.Reference reference) => reference.Artist is null ?
            $"{HandleStrings("NULL")}, {HandleStrings("NULL")}, " : $"{HandleStrings(reference.Artist.Name)}, {HandleStrings(reference.Track.Name)}, ";
        private string HandleGenre(References.Genre genre) =>
            $"{HandleStrings(genre.Name)}, " +
            $"{genre.BPM.Value}, " +
            $"{HandleStrings(genre.BPM.RangesText)}, " +
            $"{HandleStrings(genre.Scale.ToString())}, ";
        private string HandleDrums(SongElements.Drums.Drums drums) =>
            BasicDrums(drums) + ExtraDrums(drums);
        private string BasicDrums(SongElements.Drums.Drums drums) =>
            $"{HandleStrings(drums.Kick)}, " +
            $"{HandleStrings(drums.Clap)}, " +
            $"{HandleStrings(drums.HiHat)}, " +
            $"{HandleStrings(drums.OpenHat)}, " +
            $"{HandleStrings(drums.Snare)}, ";
        private string ExtraDrums(SongElements.Drums.Drums drums) =>
            $"{HandleBools(drums.Tom)}, " +
            $"{HandleBools(drums.Crash)}, " +
            $"{HandleBools(drums.Ride)}, " +
            $"{HandleBools(drums.Percussion)}, ";
        private string HandleSynths(SongElements.Synths.Synths synths)
        {
            try
            {
                return $"{HandleStrings(synths.Lead.ToString())}, " +
                       $"{HandleStrings(synths.Chords.ToString())}, " +
                       $"{HandleStrings(synths.Bass.ToString())}, " +
                       $"{HandleStrings(synths.Arp.ToString())}, ";
            }
            catch (System.NullReferenceException)
            {
                string Lead = synths.Lead is null ? "NULL" : synths.Lead.ToString(),
                    Chords = synths.Chords is null ? "NULL" : synths.Chords.ToString(),
                    Bass = synths.Bass is null ? "NULL" : synths.Bass.ToString(),
                    Arp = synths.Arp is null ? "NULL" : synths.Arp.ToString();
                return $"{HandleStrings(Lead)}, {HandleStrings(Chords)}, {HandleStrings(Bass)}, {HandleStrings(Arp)},";
            }
        }
        private string HandleInstruments(SongElements.Instruments instruments) =>
            $"{HandleBools(instruments.ContainsInstruments[0])}, " +
            $"{HandleBools(instruments.ContainsInstruments[1])}, " +
            $"{HandleBools(instruments.ContainsInstruments[2])}, " +
            $"{HandleBools(instruments.ContainsInstruments[3])}";
        #endregion
    }
}
