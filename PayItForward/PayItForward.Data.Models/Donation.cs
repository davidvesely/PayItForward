namespace PayItForward.Data.Models
{
    public class Donation
    {
        public int DonationId { get; set; }

        public User User { get; set; }

        public Story Story { get; set; }

        public int StoryId { get; set; }

        public int Amount { get; set; }
    }
}
