using Lab04.Models;
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

        public UserDashboardController(
            IUserService userService,
            IRecordService recordService
            )
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _recordService = recordService ?? throw new ArgumentNullException(nameof(recordService));
        }

        public IActionResult Index(int ID = 1)
        {
            User currentUser = _userService.GetById(ID);
            ViewData["User"] = currentUser;
            ViewData["Records"] = _recordService.GetRecordsByUser(currentUser.Id);
            return View();
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

        }
    }
}
