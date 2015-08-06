using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Toci.Client.Controllers
{

    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        /*
            tutaj domyślnie powinien być panel administratora - powinien pozwalać wyciągnąć wszystkich użytkowników
            i wyświetlić na przykład tych który nie mają żadnej roli, lub takich z danej roli, lub po prostu dane jednego konkretnego użytkownika po userName
            dodatkowo powinien pozwalać na dodanie nowych scopeów

            Realizacja zależy od tego co powie vazco.
        */
    }
    
}