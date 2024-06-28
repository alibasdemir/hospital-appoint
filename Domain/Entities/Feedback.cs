using Core.DataAccess;

namespace Domain.Entities
{
    public class Feedback : Entity<int>
    {
		public string Title { get; set; }
		public string Description { get; set; }
		public int Rating { get; set; }
		public int? UserId { get; set; }
		public virtual User? User { get; set; }

        public Feedback()
        {
        }

        public Feedback(int id, string title, string description, int rating, int? userId) 
            : base(id)
        {
            Title = title;
            Description = description;
            Rating = rating;
            UserId = userId;
        }
    }
}
