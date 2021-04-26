using Lab04.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab04.Models
{
    public class DbInitializer
    {
        public static void Initialize(IdentityContext context)
        {
            // Look for any students.
            if (context.Users.Any())
            {
                return;   // DB has been seeded
            }

            var users = new User[]
            {
                new User{ Name = "Ivanov Ivan", UserName = "Nagibator777", Description = "Love programming, 4chan and kitties", Avatar = "https://thispersondoesnotexist.com/image" },
                new User{ Name = "Pietrov Pietr", UserName = "Ugnetator666", Description = "Dunno lol", Avatar = "https://thispersondoesnotexist.com/image" },
                new User{ Name = "Simonov Oleh", UserName = "anon_from_nenka", Description = "Senior mobile developer, 10 years experience", Avatar = "https://thispersondoesnotexist.com/image" }
            };

            users[0].Subscribers = new List<User> { users[1], users[2] };
            users[0].Subscriptions = new List<User> { users[1] };
            users[1].Subscriptions = new List<User> { users[2] };

            var records = new Record[]
            {
                new Record
                { DateTime = DateTimeOffset.Now,
                    Text = "And here is my first post, hello", Likes = 14, User = users[0], Image = "https://picsum.photos/300/300"
                },
                new Record
                {  DateTime = DateTimeOffset.Now,
                    Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum",
                    Likes = 14, User = users[0], Image = ""
                }
            };

            users[0].Records = records.ToList();

            context.Users.AddRange(users);
            context.SaveChanges();

            context.Records.AddRange(records);
            context.SaveChanges();
        }
    }
}
