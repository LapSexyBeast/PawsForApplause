using System.ComponentModel.DataAnnotations.Schema;

namespace PawsForApplause.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty; // username
        public string Password { get; set; } = string.Empty; // password
        public string Email { get; set; } = string.Empty; // email
        public string FirstName { get; set; } = string.Empty; // first name
        public string LastName { get; set; } = string.Empty; // last name
        public DateTime Created { get; set; } // date and time record created

        //Navigation

        public List<Show> Shows { get; set; } = new(); // Navigation property to Shows created by the user
        public List<Ticket> Tickets { get; set; } = new(); // Navigation property to Tickets purchased by the user

        [NotMapped]
        public string FullName => $"{FirstName} {LastName}";



    }
}
