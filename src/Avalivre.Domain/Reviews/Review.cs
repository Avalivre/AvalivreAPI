using Avalivre.Domain.Products;
using Avalivre.Domain.Users;
using System;

namespace Avalivre.Domain.Reviews
{
    public class Review
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public short Rating { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserProductImageUrl { get; set; }

        public long ProductId { get; set; }
        public Product Product { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
