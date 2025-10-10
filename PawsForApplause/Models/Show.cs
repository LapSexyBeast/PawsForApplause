using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; 

namespace PawsForApplause.Models
{

    //The event data will include the...
    public class Show
    {
        public int ShowId { get; set; }
        
        public string Name { get; set; } = string.Empty; // event's title
        [Display(Name = "Event Description")]
        public string Description { get; set; } = string.Empty; //description
        [Display(Name = "Event Date")]
        public DateTime Date { get; set; } //date and time
        public DateTime Created { get; set; } //date and time record created
        public DateTime LastModified { get; set; } //date and time record last modified
        public string Filename { get; set; } = string.Empty;

        // Foreign Keys
        [Display(Name = "Event Owner")]
        public int UserId { get; set; } // FK to User (who created the event)
        [Display(Name = "Event Location")]
        public int VenueId { get; set; } // FK to Venue
        [Display(Name = "Event Type")]
        public int CategoryId { get; set; } //FK to Category

        //Navigation Properties
        public Category? Category { get; set; }
        [Display(Name = "Event Owner")]
        public User? User { get; set; } // Navigation property to User
        [Display(Name = "Event Location")]
        public Venue? Venue { get; set; } // Navigation property to Venue
        

        [NotMapped]
        [Display(Name = "Event Image")]
        public IFormFile? FormFile { get; set; } //nullable

    }
}
