using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InnovationCast.Challenge.Database.Models
{
    public class Comment
    {
        public int Id { get; set; }

        [Required]
        public string EntityId { get; set; }

        public string Description { get; set; }

        [DataType(DataType.Date)]
        public DateTime PublishDate { get; set; } = DateTime.UtcNow;

        public string Author { get; set; }
    }
}
