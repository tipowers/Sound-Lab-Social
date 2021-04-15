using SoundLabSocial.Models;
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
            var model = new PlaylistListItem[0];
            return View(model);
        }
    }
}