using Dancord.Classes.Members;

namespace Dancord.Classes.Base
{
    public delegate void OnChangeName(string nameValue, Name name);
    public delegate void OnDelete<T>(T item);
    public delegate void OnEdit<T>(string edit, T item);

}
