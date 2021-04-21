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
    public class PersonalAudioController : Controller
    {
        // GET: PersonalAudio
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var service = new PersonalAudioService(userId);
            var model = service.GetPersonalAudios();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        // CREATE: PersonalAudio
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PersonalAudioCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userId = User.Identity.GetUserId();
            var service = new PersonalAudioService(userId);
            service.CreatePersonalAudio(model);

            return RedirectToAction("Index");
        }
    }
}