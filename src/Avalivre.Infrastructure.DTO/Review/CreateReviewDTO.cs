namespace Avalivre.Infrastructure.DTO.Review
{
    public class CreateReviewDTO
    {
        public string Description { get; set; }
        public short Rating { get; set; }
        public long ProductId { get; set; }
        public int UserId { get; set; }
    }
}
