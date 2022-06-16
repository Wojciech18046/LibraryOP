namespace LibraryOP
{
    public class User : ILibraryObject
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        public User(int id, string name, string Email, string Address)
        {
            this.Id = id;
            this.Name = name;
            this.Email = Email;
            this.Address = Address; 
        }
    }
}
