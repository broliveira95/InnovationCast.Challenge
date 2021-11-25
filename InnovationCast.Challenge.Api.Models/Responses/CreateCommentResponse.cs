using System;
using System.Collections.Generic;
using System.Text;

namespace InnovationCast.Challenge.Api.Models.Responses
{
    public class CreateCommentResponse
    {
        public int CommentId { get; set; }
        public bool IsSuccessful { get; set; }
    }
}
