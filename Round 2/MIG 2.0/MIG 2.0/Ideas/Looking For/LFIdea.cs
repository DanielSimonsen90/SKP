using DanhoLibrary;
using MIG.References;
using MIG.References.Reference;
using System;

namespace MIG.Ideas.LookingFor
{
    internal class LFIdea : Idea
    {
        #region Variables
        /// <summary> Genre, Artist, BPM, Scale, Title </summary>
        public bool[] Used = new bool[5];
        public Artist Artist;
        public BPM BPM;
        public Scale Scale;
        public new LFTitle Title;
        #endregion

        #region Setters
        public void SetGenre() => 
            Genre =
                Used[1] && Used[2] ? LFGenre.GetBoth(Artist, BPM) : 
                Used[1] ? LFGenre.GetArtist(Artist) :
                Used[2] ? LFGenre.GetBPM(BPM) :
                LFGenre.GetAllGenres(Data.Playlist);
        public void SetArtist() =>
            Artist =
                Used[0] ? LFArtist.GetGenre(Genre) :
                Used[2] ? LFArtist.GetBPM(BPM) :
                LFArtist.GetAllArtists(Data.GetArtists());
        public void SetBPM() =>
            BPM =
                Used[0] ? LFBPM.GetGenre(Genre) :
                Used[1] ? LFBPM.GetArtist(Artist) :
                LFBPM.GetBPM();
        public void SetScale() => Scale = LFScale.Menu();
        public void SetTitle() => Title = new LFTitle();
        #endregion

        public void GetSpecifics()
        {
            if (Used.AnyTrue()) Console.WriteLine("--== Specifics ==--");
            if (Used[0]) Console.WriteLine($"Genre: {Genre}");
            if (Used[1]) Console.WriteLine($"Artist: {Artist}");
            if (Used[2]) Console.WriteLine($"BPM: {BPM}");
            if (Used[3]) Console.WriteLine($"Scale: {Scale.GetSpecifics()}");
            if (Used[4]) Console.WriteLine($"Title: {Title.LF}");
        }
        public new int Generate() => Generate(new LFIdea()).GetInfo();
        public Idea Generate(Idea NewIdea)
        {
            if (Used[0]) //Genre 
            {
                NewIdea.References = Used[1] ? 
                    new Reference(NewIdea.Genre = Genre, Artist) : 
                    new Reference(NewIdea.Genre = Genre);

                if (Used[2]) NewIdea.Genre.BPM = new BPM(Genre.BPM.Ranges, BPM.Value);
            }
            else if (Used[2]) //BPM
            {
                NewIdea.Genre = Used[1] ? LFGenre.GetGenres(Artist, BPM).GetRandomItem() : LFGenre.GetGenres(BPM).GetRandomItem();
                NewIdea.Genre.BPM = new BPM(NewIdea.Genre.BPM.Ranges, BPM.Value);
            }

            if (Used[1] && !Used[0]) NewIdea.References = new Reference(NewIdea.Genre, Artist); //Artist
            if (Used[2]) NewIdea.Genre.BPM = BPM; //BPM

            if (Used[3]) //Scale
                if (Scale.SpecificKey && Scale.SpecificType) NewIdea.Genre.Scale = Scale;
                else if (Scale.SpecificKey) NewIdea.Genre.Scale.Key = Scale.Key;
                else if (Scale.SpecificType) NewIdea.Genre.Scale.Type = Scale.Type;

            if (Used[4]) //Title
                NewIdea.Title = Title.Result;

            return NewIdea;
        }
    }
}