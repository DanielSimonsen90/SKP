using Dancord.Classes.Members;

namespace Dancord.Classes.Base
{
    public delegate void OnDelete<T>(T item);
    public delegate void OnEdit<T>(string edit, T item);
}
