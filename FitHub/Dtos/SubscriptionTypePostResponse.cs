namespace FitHub.Dtos
{
    public class SubscriptionTypePostResponse
    {
        public int Id { get; set; }
        public required string Description { get; set; }
        public required decimal Price { get; set; }
    }
}
