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
            var userId = User.Identity.GetUserId();
            var service = new SongService(userId);
            var model = service.GetSongs();
            return View(model);
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

            var userId = User.Identity.GetUserId();
            var service = new SongService(userId);
            service.CreateSong(model);

            return RedirectToAction("Index");
        }
    }
}