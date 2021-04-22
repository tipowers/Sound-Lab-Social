using Microsoft.AspNet.Identity;
using SoundLabSocial.Models;
using SoundLabSocial.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SoundLabSocial.Controllers
{
    [Authorize]
    public class SongController : Controller
    {
        // GET: Song
        public ActionResult Index()
        {
            var service = CreateSongService();
            var model = service.GetSongs();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        // CREATE: Song
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SongCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = CreateSongService();

            if (service.CreateSong(model))
            {
                TempData["SaveResult"] = "Your song was created.";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Song could not be created.");
            return View(model);
        }

        private SongService CreateSongService()
        {
            var userId = User.Identity.GetUserId();
            var service = new SongService(userId);
            return service;
        }
    }
}