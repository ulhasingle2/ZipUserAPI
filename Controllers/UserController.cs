using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ZIPUSERAPI.Data;
using ZIPUSERAPI.Dto;
using ZIPUSERAPI.Models;
using ZipUserAPI.Mapper;
using System.Linq;

namespace ZipUserAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepo _reprositry;
        private readonly IMapper _mapper;

        public UserController(IUserRepo reprositry, IMapper mapper )
        {
            _reprositry=reprositry;
            _mapper=mapper;
        }
        
        [HttpGet]
        public ActionResult <IEnumerable<UserRead>> UserList()
        {
                var userList=_reprositry.UserList();
                if (userList != null)
                {
                    var test=_mapper.Map<IEnumerable<UserRead>>(userList);
                    return Ok(test);
                }
                 return NotFound();
        }

         [HttpGet("{id}")]
         public ActionResult <UserRead> GetUserDetails(int id)
         {
             var userDetails=_reprositry.GetUser(id);
             if (userDetails != null)
             {
                      return Ok(_mapper.Map<UserRead>(userDetails));
             }
             return NotFound();
         }


        [HttpPost()]
        public ActionResult <UserRead> CreateUser(UserCreate userCreate)
        {
             if(!ModelState.IsValid)
                 return BadRequest(ModelState);   

                var user =_mapper.Map<User>(userCreate) ; 

                 var recordExits=  _reprositry.UserList().Where(x => x.Email == user.Email).FirstOrDefault();         
                  
            if(recordExits != null)  
                    return Conflict("User already exists");        
                      //return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status409Conflict,$"User '{user.Email}' already exists.");          

                _reprositry.CreateUser(user);
                _reprositry.SaveChanges();

                var userRead=_mapper.Map<UserRead>(user);
                return Created("User Created",user);         
            
        }
        
    }
}