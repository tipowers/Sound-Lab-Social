using SoundLabSocial.Models;
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
            var model = new PersonalAudioListItem[0];
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PersonalAudioCreate model)
        {
            if (ModelState.IsValid)
            {

            }
            return View(model);
        }
    }
}