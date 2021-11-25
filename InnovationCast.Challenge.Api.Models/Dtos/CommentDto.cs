using System;
using System.Collections.Generic;
using System.Text;

namespace InnovationCast.Challenge.Api.Models.Dtos
{
    public class CommentDto
    {
        public int Id { get; set; }

        public string EntityId { get; set; }

        public string Description { get; set; }

        public DateTime PublishDate { get; set; }

        public string Author { get; set; }
    }
}
