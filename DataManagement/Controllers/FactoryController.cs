using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DataManagement.Controllers
{
    public class FactoryController : Controller
    {
        // GET: FactoryController
        public ActionResult Index()
        {
            return View();
        }

        // GET: FactoryController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FactoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FactoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FactoryController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FactoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FactoryController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FactoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
