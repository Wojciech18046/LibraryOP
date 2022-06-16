namespace LibraryOP
{
    public interface IPublication : ILibraryObject
    {
        public int PageCount { get; set; } 
        public string Author { get; set; }
    }
}
