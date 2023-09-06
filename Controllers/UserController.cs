using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogBackEndL.Models.DTO;
using BlogBackEndL.Services;
using Microsoft.AspNetCore.Mvc;

namespace BlogBackEndL.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
            //create a variable with a type of service
            private readonly UserService _data;
            //Create a constructor

            public UserController(UserService dataFromService) {

                _data = dataFromService;
            }


        //Add a user
        [HttpPost("AddUsers")]
        public bool AddUser(CreateAccountDTO UserToAdd) {

            return _data.AddUser(UserToAdd);
        }
            //if the user already exsist
            //if the user does not exist we need to create an account
            //Else throw an error
        
    }
    //Login
    //Update User Account
    //Delete User Account
}