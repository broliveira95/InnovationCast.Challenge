using InnovationCast.Challenge.Database.Models;
using System;
using System.Collections.Generic;

namespace InnovationCast.Challenge.Repository
{
    public interface ICommentsRepository
    {
        Comment Add(Comment comment);

        bool Delete(int id);

        IEnumerable<Comment> Getlist(string entityId);

    }
}
