using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogBackEndL.Models;
using BlogBackEndL.Models.DTO;
using BlogBackEndL.Services.Context;
using System.Security.Cryptography;

namespace BlogBackEndL.Services
{
    public class UserService
    {
        //create a variable
        private readonly DataContext _context;
        //create a constructor
        public UserService(DataContext context) {
            _context = context;
        }

        //Helper function DoesUserExist(string username)
        public bool DoesUserExist(string? username) {
            //check the tables to see if the username exist
            // if one item matches our condition that item will be returned
            //if no item mateches it will return null
            // if multiple items match will return an error
            // UserModel foundUser =  _context.UserInfo.SingleOrDefault(user => user.Username == username)

            //     if(foundUser != null) {
            //     }
            //         //the user exist in the table
            //     else {
            //         //the user does not exist
            //     }


            return _context.UserInfo.SingleOrDefault(user => user.Username == username) != null;
            
        }

        public bool AddUser(CreateAccountDTO UserToAdd) {

            bool result = false;
            //if the user already exsist
            if(!DoesUserExist(UserToAdd.Username))
            {
                //wee need to create a new instance of our UserModel
                     UserModel newUser = new UserModel();

                     var newHashedPassword = HashPassword(UserToAdd.Password);

                     newUser.Id = UserToAdd.Id;

                     newUser.Username = UserToAdd.Username;

                     newUser.Salt = newHashedPassword.Salt;
                     newUser.Hash = newHashedPassword.Hash;
        //now need to add to our data base
                     _context.Add(newUser);
        //we need to save our changes
                     _context.SaveChanges();
            }
            return result;
            //if they do not exsist we then need to add account
            // Else throw a false

        }
        public PasswordDTO HashPassword(string password) {

            //logic goes here
            //create a password DTO this is what we are going to return
            //We nee to create an new instance of our PasswordDTO
             PasswordDTO newHashedPassword = new PasswordDTO();
             //salt bytes size of our Saltbytes wich is 64
           byte[] SaltBytes = new byte[64];
        //RNGCryptoServiceProvider creates random numbers
           var provider = new RNGCryptoServiceProvider();
        //now we are going to exlude all the zeros
        provider.GetNonZeroBytes(SaltBytes);
        //encrypt our 64 string and encrypt it for us
        var Salt = Convert.ToBase64String(SaltBytes);
        // we will use to create the hash first argument is the password, byts, iterations
        var rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, SaltBytes,10000);
        //Now we create our hash
        var Hash = Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256));
        //return newHashedPssword.Salt = Salt
        newHashedPassword.Salt = Salt;
        newHashedPassword.Hash = Hash;

        return newHashedPassword;

        }

        public bool VerifyUserPassword(string? Password, string? StoredHash, string? StoredSalt){
            var SaltBytes = Convert.FromBase64String(StoredSalt);
            var rfc2898DeriveBytes = new Rfc2898DeriveBytes(Password, SaltBytes,10000);
            var newHash = Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256));
            return newHash == StoredHash;
        }
    }
}