using AutoMapper;
using ZIPUSERAPI.Dto;
using ZIPUSERAPI.Models;

namespace  ZipUserAPI.Mapper
{
    public class ProfileMapper  : Profile
    {
          
        // <Source,Destination>
        public ProfileMapper()
        {
            CreateMap<User,UserRead>();
            CreateMap<UserCreate,User>();
            CreateMap<Account,AccountRead>();
            CreateMap<AccountCreate,Account>();
        }

    }
}