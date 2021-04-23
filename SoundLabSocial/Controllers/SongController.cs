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
    public class SongController : Controller
    {
        // GET: Song
        public ActionResult Index()
        {
            var service = CreateSongService();
            var model = service.GetSongs();
            return View(model);
        }

        // GET: Song By Id
        public SongDetail GetSongById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Songs
                    .Single(e => e.SongId == id);
                return new SongDetail
                {
                    SongId = entity.SongId,
                    SongName = entity.SongName,
                    SongArtist = entity.SongArtist,
                    SongAlbum = entity.SongAlbum,
                    ReleaseYear = entity.ReleaseYear,
                    CreatedUTC = entity.CreatedUTC,
                    ModifiedUTC = entity.ModifiedUTC
                };
            }
        }

        // CREATE: Song (Get)
        public ActionResult Create()
        {
            return View();
        }

        // CREATE: Song (Post)
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