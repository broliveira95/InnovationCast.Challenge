using InnovationCast.Challenge.Database;
using InnovationCast.Challenge.Database.Models;
using InnovationCast.Challenge.Repository.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InnovationCast.Challenge.Repository.Impl
{
    public class CommentsRepository : ICommentsRepository
    {
        private readonly InnovationCastContext _context;
        private readonly RepositorySettings _repositorySettings;

        public CommentsRepository(InnovationCastContext context, RepositorySettings repositorySettings)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _repositorySettings = repositorySettings ?? throw new ArgumentNullException(nameof(repositorySettings));
        }

        public Comment Add(Comment comment)
        {
            try
            {
                var entity = _context.Comments.Add(comment).Entity;
                _context.SaveChanges();

                return entity;
            }
            catch (Exception e)
            {
                // handles e (log)
                return null;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var comment = _context.Comments.FirstOrDefault(c => c.Id == id);
                
                if (comment != null)
                {
                    _context.Comments.Remove(comment);
                    _context.SaveChanges();
                }

                return true;
            }
            catch (Exception e)
            {
                // handles e (log)
                return false;
            }
        }

        public IEnumerable<Comment> Getlist(string entityId)
        {
            try 
            {
               return _context.Comments
                    .Where(c => c.EntityId == entityId)
                    .OrderByDescending(c => c.PublishDate);
            }
            catch (Exception e)
            {
                // handles e (log)
                return new List<Comment>();
            }
        }
    }
}
