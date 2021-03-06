using Microsoft.AspNet.Identity;
using SoundLabSocial.Data;
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
        // GET: All Playlists
        public ActionResult Index()
        {
            var service = CreatePlaylistService();
            var model = service.GetPlaylists();
            return View(model);
        }

        // GET: Playlist Details
        public ActionResult Details(int id)
        {
            var svc = CreatePlaylistService();
            var model = svc.GetPlaylistById(id);

            return View(model);
        }

        // CREATE: Playlist (Get)
        public ActionResult Create()
        {
            return View();
        }

        // CREATE: Playlist (Post)
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

        // UPDATE: Playlist
        public ActionResult Edit(int id)
        {
            var service = CreatePlaylistService();
            var detail = service.GetPlaylistById(id);
            var model = new PlaylistEdit
            {
                PlaylistId = detail.PlaylistId,
                PlaylistName = detail.PlaylistName
            };
            return View(model);
        }

        // OVERLOADED UPDATE: Playlist
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PlaylistEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.PlaylistId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreatePlaylistService();

            if (service.UpdatePlaylist(model))
            {
                TempData["SaveResult"] = "Your playlist was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your playlist could not be updated.");
            return View(model);
        }

        // DELETE: Playlist (Get)
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreatePlaylistService();
            var model = svc.GetPlaylistById(id);

            return View(model);
        }

        // DELETE: Song (Post)
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePlaylist(int id)
        {
            var service = CreatePlaylistService();
            service.DeletePlaylist(id);

            TempData["SaveResult"] = "Your playlist was deleted";

            return RedirectToAction("Index");
        }

        private PlaylistService CreatePlaylistService()
        {
            var userId = User.Identity.GetUserId();
            var service = new PlaylistService(userId);
            return service;
        }
    }
}