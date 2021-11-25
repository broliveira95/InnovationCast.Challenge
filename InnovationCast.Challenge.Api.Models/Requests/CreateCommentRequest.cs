using InnovationCast.Challenge.Api.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace InnovationCast.Challenge.Api.Models.Requests
{
    public class CreateCommentRequest
    {
        public string EntityId { get; set; }

        public string Description { get; set; }

        public string Author { get; set; }
    }
}
