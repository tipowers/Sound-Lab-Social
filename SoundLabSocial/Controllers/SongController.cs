using SoundLabSocial.Models;
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
            var model = new SongListItem[0];
            return View(model);
        }
    }
}