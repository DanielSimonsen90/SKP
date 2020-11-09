namespace Dancord.Classes.Base
{
    interface IJSONID
    {
        string ToJSON(bool onlyID);
    }
    interface IJSON
    {
        string ToJSON();
    }
}
