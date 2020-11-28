using Avalivre.Domain.Products;
using Avalivre.Domain.Users;
using System;

namespace Avalivre.Domain.Reviews
{
    public class Review
    {
        public Review(string description, short rating, long productId, int userId)
        {
            this.Description = description;
            this.Rating = rating;
            this.CreationDate = DateTime.Now;
            this.ProductId = productId;
            this.UserId = userId;
        }

        public long Id { get; private set; }
        public string Description { get; private set; }
        public short Rating { get; private set; }
        public DateTime CreationDate { get; private set; }
        public DateTime? UpdateDate { get; set; }
        public string UserProductImageUrl { get; set; }

        public long ProductId { get; private set; }
        public Product Product { get; set; }

        public int UserId { get; private set; }
        public User User { get; set; }
    }
}
