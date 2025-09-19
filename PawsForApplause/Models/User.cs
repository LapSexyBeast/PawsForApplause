namespace PawsForApplause.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Role { get; set; } = "User"; // role (e.g., Admin, User)
        public string Username { get; set; } = string.Empty; // username
        public string Password { get; set; } = string.Empty; // password
        public string Email { get; set; } = string.Empty; // email
        public string FirstName { get; set; } = string.Empty; // first name
        public string LastName { get; set; } = string.Empty; // last name
        public DateTime Created { get; set; } // date and time record created
    }
}
