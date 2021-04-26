using Lab04.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab04.Services
{
    public class UserService : IUserService
    {
        public User GetById(long id)
        {
            return new User
            {
                Id = "1",
                Name = "Ivanov Ivan",
                UserName = "Nagibator777",
                Description = "Love programming, 4chan and kitties",
                Avatar = "https://thispersondoesnotexist.com/image"
            };
        }
    }
}
