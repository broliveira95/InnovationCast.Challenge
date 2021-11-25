using AutoMapper;
using InnovationCast.Challenge.Api.Models.Dtos;
using InnovationCast.Challenge.Api.Models.Requests;
using InnovationCast.Challenge.Api.Models.Responses;
using InnovationCast.Challenge.Database.Models;
using InnovationCast.Challenge.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InnovationCast.Challenge.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommentsController : ControllerBase
    {
        protected readonly IMapper _mapper;
        private readonly ICommentsRepository _commentRepository;

        public CommentsController(IMapper mapper, ICommentsRepository commentRepository)
        {
            _mapper = mapper ?? throw new System.ArgumentNullException(nameof(mapper));
            _commentRepository = commentRepository ?? throw new System.ArgumentNullException(nameof(commentRepository));
        }

        [HttpGet]
        public ActionResult<GetCommentsResponse> GetList(string entityId, int skip = 0, int take = 10)
        {
            if (entityId is null)
            {
                throw new ArgumentNullException(nameof(entityId));
            }

            var commentsDb = _commentRepository.Getlist(entityId);
            var totalCount = commentsDb.Count();

            // if skip,take == 0 -> take all
            if (skip != 0 || take != 0 )
            {
                commentsDb = commentsDb.Skip(skip).Take(take).ToList();
            }

            var comments = _mapper.Map<IEnumerable<CommentDto>>(commentsDb);

            return new GetCommentsResponse
            {
                Skip = skip,
                Take = take,
                TotalCount = totalCount,
                Comments = comments,
            };
        }

        [HttpPost]
        public ActionResult<CreateCommentResponse> Create(CreateCommentRequest resquest)
        {
            var comment = _commentRepository.Add(new Comment
            {
                EntityId = resquest.EntityId,
                Description = resquest.Description,
                Author = resquest.Author
            });

            if (comment is null) 
            {
                return new CreateCommentResponse
                {
                    IsSuccessful = false
                };
            }

            return new CreateCommentResponse
            {
                IsSuccessful = true,
                CommentId = comment.Id,
            };
        }

        [HttpDelete]
        public ActionResult<bool> Delete(int commentId)
        {
            return _commentRepository.Delete(commentId);
        }
    }
}
