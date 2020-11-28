using System;
using System.Collections.Generic;
using System.Text;

namespace Avalivre.Infrastructure.DTO.Review
{
    public class GetRecentReviewsDTO
    {
        public long ProductId { get; set; }
        public int Fetch { get; set; } = 5;
    }
}
