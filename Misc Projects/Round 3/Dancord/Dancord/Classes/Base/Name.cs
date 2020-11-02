namespace Dancord.Classes.Base
{
    public class Name
    {
        public delegate void OnChangeName(string nameValue, Name name);
        public event OnChangeName ChangeName;

        private string Value;
        public Name(string value)
        {
            this.Value = value;

            ChangeName += delegate { this.Value = value; };
        }
        public override string ToString() => this.Value;
    }
}
