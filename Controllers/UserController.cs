using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogBackEndL.Models;
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


        //GetUserByUsername

        [HttpGet("userbyusername/{username}")]

        public UseridDTO GetUserIdDTOByUsername(string username)
        {
            return _data.GetUserIdDTOByUsername(username);
        }



        //Add a user
        [HttpPost("AddUsers")]
        public bool AddUser(CreateAccountDTO UserToAdd) {

            return _data.AddUser(UserToAdd);
        }
            //if the user already exsist
            //if the user does not exist we need to create an account
            //Else throw an error

            //Get Users
            [HttpGet("GetAllUsers")]

            public IEnumerable<UserModel> GetAllUsers() {
                return _data.GetAllUsers();
            }

    //Login
            [HttpPost("Login")]
            public IActionResult Login([FromBody] LoginDTO User) 
            {
                return _data.Login(User);
            }
        
    //Delete User Account
            [HttpPost("DeleteUser/{userToDelete}")]

            public bool DeleteUser(string userToDelete)
            {
                return _data.DeleteUser(userToDelete);
            }
    //Update User Account
            [HttpPost("UpdateUser")]

            public bool UpdateUser(int id, string username)
            {
                return _data.UpdateUsername(id,username);
            }

    }


}