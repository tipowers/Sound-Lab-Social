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
        // GET: All PersonalAudios
        public ActionResult Index()
        {
            var service = CreatePersonalAudioService();
            var model = service.GetPersonalAudios();
            return View(model);
        }

        // GET: Personal Audio Details
        public ActionResult Details(int id)
        {
            var svc = CreatePersonalAudioService();
            var model = svc.GetPersonalAudioById(id);

            return View(model);
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

        // UPDATE: PersonalAudio
        public ActionResult Edit(int id)
        {
            var service = CreatePersonalAudioService();
            var detail = service.GetPersonalAudioById(id);
            var model = new PersonalAudioEdit
            {
                PersonalAudioId = detail.PersonalAudioId,
                AudioName = detail.AudioName,
                AudioMessage = detail.AudioMessage,
                PlaylistId = detail.PlaylistId
            };
            return View(model);
        }

        // OVERLOADED UPDATE: Personal Audio
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PersonalAudioEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.PersonalAudioId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreatePersonalAudioService();

            if (service.UpdatePersonalAudio(model))
            {
                TempData["SaveResult"] = "Your personal audio was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your personal audio could not be updated.");
            return View(model);
        }

        // DELETE: Personal Audio (Get)
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreatePersonalAudioService();
            var model = svc.GetPersonalAudioById(id);

            return View(model);
        }

        // DELETE: Personal Audio (Post)
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePersonalAudio(int id)
        {
            var service = CreatePersonalAudioService();
            service.DeletePersonalAudio(id);

            TempData["SaveResult"] = "Your personal audio was deleted";

            return RedirectToAction("Index");
        }

        private PersonalAudioService CreatePersonalAudioService()
        {
            var userId = User.Identity.GetUserId();
            var service = new PersonalAudioService(userId);
            return service;
        }
    }
}