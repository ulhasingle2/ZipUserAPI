using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ZIPUSERAPI.Data;
using ZIPUSERAPI.Dto;
using ZIPUSERAPI.Models;
using ZipUserAPI.Mapper;
using System.Linq;
using ZipUserAPI.Data;

namespace ZipUserAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepo _reprositry;
        
        private readonly IMapper _mapper;

        public AccountController(IAccountRepo reprositry,  IMapper mapper )
        {
            _reprositry=reprositry;
            _mapper=mapper;

        }
        
        [HttpGet]
        public ActionResult <IEnumerable<AccountRead>> AccountList()
        {
                var accountList=_reprositry.AccountList();
                if (accountList != null)
                {
                    var test=_mapper.Map<IEnumerable<AccountRead>>(accountList);
                    return Ok(test);
                }
                 return NotFound();
        }

        


         [HttpPost()]
         public ActionResult <AccountRead> CreateAccount(AccountCreate accountCreate)
         {
              if(!ModelState.IsValid)
                  return BadRequest(ModelState);                 

                  var AccAmt1 = accountCreate.Salary -accountCreate.Expenses; 
                  
                  if(AccAmt1 < 1000)
                  return  StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status204NoContent,"Not Created");   

                 var account =_mapper.Map<Account>(accountCreate) ;
                _reprositry.CreateAccount(account);
                _reprositry.SaveChanges();

                 var accountRead=_mapper.Map<AccountRead>(account);
                  return Created("Account Creaated",account);       
         }
        
    }
}