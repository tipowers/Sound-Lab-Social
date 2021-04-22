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
    public class PlaylistController : Controller
    {
        // GET: Playlist
        public ActionResult Index()
        {
            var service = CreatePlaylistService();
            var model = service.GetPlaylists();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        // CREATE: Playlist
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PlaylistCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = CreatePlaylistService();

            if (service.CreatePlaylist(model))
            {
                TempData["SaveResult"] = "Your playlist was created.";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Playlist could not be created.");
            return View(model);
        }

        private PlaylistService CreatePlaylistService()
        {
            var userId = User.Identity.GetUserId();
            var service = new PlaylistService(userId);
            return service;
        }
    }
}