using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Phoenix.Front.Areas.TeamLeasing.TeamSearching.Controllers
{
    public class TeamSearchingController : Controller
    {
        // GET: TeamLeasing/TeamSearching
        public ActionResult Index()
        {
            return View();
        }

        // GET: TeamLeasing/TeamSearching/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TeamLeasing/TeamSearching/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TeamLeasing/TeamSearching/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: TeamLeasing/TeamSearching/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TeamLeasing/TeamSearching/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: TeamLeasing/TeamSearching/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TeamLeasing/TeamSearching/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
