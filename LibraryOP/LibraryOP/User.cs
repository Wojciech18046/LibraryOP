namespace LibraryOP
{
    public class User
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        public User(string name, string Email, string Address)
        {
            //TODO: Add Id generation
            //this.Id = 
            this.Name = name;
            this.Email = Email;
            this.Address = Address; 
        }
    }
}
