namespace PawsForApplause.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;

        //Navigation
        public ICollection<Show> Shows { get; set; } = new List<Show>();
    }
}
