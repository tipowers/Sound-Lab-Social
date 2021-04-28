﻿using Microsoft.AspNet.Identity;
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
        // GET: All Songs
        public ActionResult Index()
        {
            var service = CreateSongService();
            var model = service.GetSongs();
            return View(model);
        }

        // GET: Song Details
        public ActionResult Details(int id)
        {
            var svc = CreateSongService();
            var model = svc.GetSongById(id);

            return View(model);
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

        // UPDATE: Song
        public ActionResult Edit(int id)
        {
            var service = CreateSongService();
            var detail = service.GetSongById(id);
            var model = new SongEdit
            {
                SongId = detail.SongId,
                SongName = detail.SongName,
                SongArtist = detail.SongArtist,
                SongAlbum = detail.SongAlbum,
                ReleaseYear = detail.ReleaseYear
            };
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