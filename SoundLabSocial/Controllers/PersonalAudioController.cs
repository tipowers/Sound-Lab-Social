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
    public class PersonalAudioController : Controller
    {
        // GET: PersonalAudio
        public ActionResult Index()
        {
            var service = CreatePersonalAudioService();
            var model = service.GetPersonalAudios();
            return View(model);
        }

        // GET: Personal Audio By Id
        public PersonalAudioDetail GetPersonalAudioById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.PersonalAudios
                    .Single(e => e.AudioId == id);
                return new PersonalAudioDetail
                {
                    AudioId = entity.AudioId,
                    AudioName = entity.AudioName,
                    CreatedUTC = entity.CreatedUTC,
                    ModifiedUTC = entity.ModifiedUTC
                };
            }
        }

        // CREATE: PersonalAudio (Get)
        public ActionResult Create()
        {
            return View();
        }

        // CREATE: PersonalAudio (Post)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PersonalAudioCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = CreatePersonalAudioService();
            
            if (service.CreatePersonalAudio(model))
            {
                TempData["SaveResult"] = "Your personal audio was created.";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Personal Audio could not be created.");
            return View(model);
        }

        private PersonalAudioService CreatePersonalAudioService()
        {
            var userId = User.Identity.GetUserId();
            var service = new PersonalAudioService(userId);
            return service;
        }
    }
}