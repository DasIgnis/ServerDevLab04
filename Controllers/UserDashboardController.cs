﻿using Lab04.Models;
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
        private IdentityContext _bloggingContext;

        public UserDashboardController(
            IdentityContext bloggingContext)
        {
            _bloggingContext = bloggingContext ?? throw new ArgumentNullException(nameof(bloggingContext));
        }

        public IActionResult Index(string ID)
        {
            User currentUser = _bloggingContext.Users.FirstOrDefault(user => user.Id == ID.ToString());
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

        [HttpPost]
        public IActionResult Create([FromForm]RecordEditModel recordModel)
        {
            User user = _bloggingContext.Users.FirstOrDefault(user => user.Id == recordModel.UserId.ToString());
            if (user == null)
            {
                return NotFound("User not found");
            }

            Record record = new Record
            {
                Text = recordModel.Text,
                DateTime = DateTimeOffset.Now,
                Image = recordModel.Image,
                Likes = 0,
                User = user
            };

            user.Records.Add(record);
            _bloggingContext.Records.Add(record);
            _bloggingContext.SaveChanges();

            return RedirectToAction("Index", "UserDashboard", new { id = recordModel.UserId });
        }

        [HttpGet]
        public IActionResult Edit(long? id, int? userId)
        {
            Record record = _bloggingContext.Records.Where(x => x.Id == id).FirstOrDefault();
            if (record == null)
            {
                return NotFound("Post not found");
            }

            record.DateTime = DateTime.Now;
            _bloggingContext.SaveChanges();

            return RedirectToAction("Index", "UserDashboard", new { id = userId });
        }

        //VERY BAD design desision!
        [HttpGet]
        public IActionResult Delete(int? id, int? userId)
        {
            Record record = _bloggingContext.Records.Where(x => x.Id == id).FirstOrDefault();
            if (record == null)
            {
                return NotFound("Post not found");
            }

            _bloggingContext.Records.Remove(record);
            _bloggingContext.SaveChanges();


            return RedirectToAction("Index", "UserDashboard", new { id = userId });
        }
    }
}
