namespace LibraryOP
{
    internal interface ISerializer<T>
    {
        string Serialize(T obj);
        T Deserialize(string content);
    }
}
