using Lab04.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab04.Services
{
    public class RecordService : IRecordService
    {
        public List<Record> GetRecordsByUser(long userId)
        {
            User user = new User
            {
                Id = 1,
                Name = "Ivanov Ivan",
                Username = "Nagibator777",
                Description = "Love programming, 4chan and kitties",
                Avatar = "https://thispersondoesnotexist.com/image"
            };

            return new List<Record>
            {
                new Record
                {
                    Id = 1,
                    DateTime = DateTimeOffset.Now,
                    Text = "And here is my first post, hello",
                    Likes = 14,
                    User = user,
                    Image = "https://picsum.photos/300/300"
                },
                new Record
                {
                    Id = 1,
                    DateTime = DateTimeOffset.Now,
                    Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum",
                    Likes = 14,
                    User = user,
                    Image = ""
                }
            };
        }

        public static string DateTimeHelperFormatter(DateTimeOffset dateTime)
        {
            const int SECOND = 1;
            const int MINUTE = 60 * SECOND;
            const int HOUR = 60 * MINUTE;
            const int DAY = 24 * HOUR;
            const int MONTH = 30 * DAY;

            var ts = new TimeSpan(DateTime.UtcNow.Ticks - dateTime.Ticks);
            double delta = Math.Abs(ts.TotalSeconds);

            if (delta < 1 * MINUTE)
                return ts.Seconds == 1 ? "one second ago" : ts.Seconds + " seconds ago";

            if (delta < 2 * MINUTE)
                return "a minute ago";

            if (delta < 45 * MINUTE)
                return ts.Minutes + " minutes ago";

            if (delta < 90 * MINUTE)
                return "an hour ago";

            if (delta < 24 * HOUR)
                return ts.Hours + " hours ago";

            if (delta < 48 * HOUR)
                return "yesterday";

            if (delta < 30 * DAY)
                return ts.Days + " days ago";

            if (delta < 12 * MONTH)
            {
                int months = Convert.ToInt32(Math.Floor((double)ts.Days / 30));
                return months <= 1 ? "one month ago" : months + " months ago";
            }
            else
            {
                int years = Convert.ToInt32(Math.Floor((double)ts.Days / 365));
                return years <= 1 ? "one year ago" : years + " years ago";
            }
        }
    }
}
