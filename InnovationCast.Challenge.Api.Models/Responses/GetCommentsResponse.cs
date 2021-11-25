using InnovationCast.Challenge.Api.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace InnovationCast.Challenge.Api.Models.Responses
{
    public class GetCommentsResponse
    {
        public int Skip { get; set; }

        public int Take { get; set; }

        public int TotalCount { get; set; }

        public IEnumerable<CommentDto> Comments { get; set; }
    }
}
