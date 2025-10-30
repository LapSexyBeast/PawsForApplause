using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PawsForApplause.Models
{
    public class Venue
    {
        public int VenueId { get; set; }
        public string Name { get; set; } = string.Empty; // venue name
        public string Address { get; set; } = string.Empty; // venue address
        public string City { get; set; } = string.Empty; // venue city
        public string Province { get; set; } = string.Empty; // venue Province
        public string PostalCode { get; set; } = string.Empty; // venue postal code
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = false)]
        public DateTime? Created { get; set; } // date and time record created
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = false)]
        public DateTime? LastModified { get; set; } //date and time record last modified

        //Navigation property to Shows held at the venue
        public ICollection<Show> Shows { get; set; } = new List<Show>();

        [NotMapped]
        public string FullAddress => $"{Name} - {Address}, {City}, {Province} {PostalCode}";

    }
}
