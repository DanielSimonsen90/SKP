namespace Dancord.Classes.Base
{
    public class Name : IJSONID
    {
        public delegate void OnChangeName(string nameValue, Name name);
        public event OnChangeName ChangeName;

        private string Value;
        public Name(string value)
        {
            this.Value = value;

            ChangeName += delegate { this.Value = value; };
        }

        public void Change(string name)
        {
            ChangeName(name, this);
            this.Value = name;
        }

        public override string ToString() => this.Value;

        public string ToJSON() => 
            "{" + 
                $"Value:{Value}" + 
            "}";
    }
}
