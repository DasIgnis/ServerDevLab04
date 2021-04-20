using Lab04.Models;
using Lab04.Models.ViewModels;
using Lab04.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace Lab04.Controllers
{
    public class UserDashboardController : Controller
    {
        private IUserService _userService;
        private IRecordService _recordService;
        private BloggingContext _bloggingContext;

        public UserDashboardController(
            IUserService userService,
            IRecordService recordService,
            BloggingContext bloggingContext)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _recordService = recordService ?? throw new ArgumentNullException(nameof(recordService));
            _bloggingContext = bloggingContext ?? throw new ArgumentNullException(nameof(bloggingContext));
        }

        public IActionResult Index(int ID = 1)
        {
            User currentUser = _bloggingContext.Users.FirstOrDefault(user => user.Id == ID);
            if (currentUser == null)
            {
                return NotFound();
            }

            List<Record> records = _bloggingContext.Records.Where(record => record.User.Id == currentUser.Id).ToList();

            var model = new UserDashboardViewModel
            {
                User = currentUser,
                Records = records
            };
            return View(model);
        }

        public void NewPost()
        {

        }

        public void Like(long postId)
        {

        }

        public void Edit(long postId)
        {

        }

        public void Delete(long postId)
        {
            Record record = _bloggingContext.Records.FirstOrDefault(x => x.Id == postId);
            if (record == null)
            {
                return;
            }
            _bloggingContext.Remove(record);
            _bloggingContext.SaveChanges();
        }
    }
}
