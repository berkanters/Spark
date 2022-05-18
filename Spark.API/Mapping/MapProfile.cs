using Spark.API.DTOs;
using Spark.Core.Models;

namespace Spark.API.Mapping;
using AutoMapper;

    public class MapProfile:Profile
    {

        public MapProfile()
        {
        CreateMap<User, UserDto>();
        CreateMap<UserDto, User>();
        CreateMap<Like, LikeDto>();
        CreateMap<LikeDto, Like>();
        }
    
}