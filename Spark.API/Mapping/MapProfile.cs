using Spark.API.DTOs;
using Spark.Core.Models;

namespace Spark.API.Mapping;
using AutoMapper;

public class MapProfile : Profile
{

    public MapProfile()
    {
        CreateMap<User, UserDto>();
        CreateMap<UserDto, User>();
        CreateMap<Like, LikeDto>();
        CreateMap<LikeDto, Like>();
        CreateMap<ChatDto, Chat>();
        CreateMap<Chat, ChatDto>();
        CreateMap<User, LoginDto>();
        CreateMap<LoginDto, User>();
        CreateMap<User, RegisterDto>();
        CreateMap<RegisterDto, User>();
        CreateMap<User, LocationDto>();
        CreateMap<LocationDto, User>();
        CreateMap<UserWithLastMessageDto, User>();
        CreateMap<User, UserWithLastMessageDto>();
        CreateMap<User, UserProfileChangeDto>();
        CreateMap<UserProfileChangeDto, User>();
        CreateMap<Question, QuestionDto>();
        CreateMap<QuestionDto, Question>();
    }
}

