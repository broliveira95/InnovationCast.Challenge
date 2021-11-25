using AutoMapper;
using InnovationCast.Challenge.Api.Models.Dtos;
using InnovationCast.Challenge.Database.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace InnovationCast.Challenge.AutoMapper.Profiles
{
    public class CommentsProfile : Profile
    {
        public CommentsProfile()
        {
            CreateMap<Comment, CommentDto>()
                .ReverseMap();
        }
    }
}
