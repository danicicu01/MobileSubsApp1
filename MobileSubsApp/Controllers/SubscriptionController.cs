using Microsoft.AspNetCore.Mvc;
using MobileSubsApp.Data;
using MobileSubsApp.Models;

namespace MobileSubsApp.Controllers
{
    public class SubscriptionController : Controller
    {
        private readonly ApplicationDbContext _db;

        public SubscriptionController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Subscription> objSubscriptionList = _db.Subscriptions;
            return View(objSubscriptionList);
        }

        //GET METHOD - ADD
        public IActionResult Create()
        {       
            return View();
        }

        //POST METHOD
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Subscription obj)
        {
            if (ModelState.IsValid)
            {
                _db.Subscriptions.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Subscription added successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
            
        }

        //GET METHOD - EDIT
        public IActionResult Edit(int? id)
        {
            if( id == null || id == 0 )
            {
                return NotFound();
            }
            var subscriptionFromDb = _db.Subscriptions.Find(id);


            if(subscriptionFromDb == null)
            {
                return NotFound();
            }

            return View(subscriptionFromDb);
        }

        //POST METHOD
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Subscription obj)
        {
            if (ModelState.IsValid)
            {
                _db.Subscriptions.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Subscription updated successfully";
                return RedirectToAction("Index");
            }
            return View(obj);

        }

        //GET METHOD - DELETE
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var subscriptionFromDb = _db.Subscriptions.Find(id);


            if (subscriptionFromDb == null)
            {
                return NotFound();
            }

            return View(subscriptionFromDb);
        }

        //POST METHOD
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.Subscriptions.Find(id);
            if(obj == null)
            {
                return NotFound();
            }

                _db.Subscriptions.Remove(obj);
                _db.SaveChanges();
                TempData["success"] = "Subscription deleted successfully";
                return RedirectToAction("Index");

        }
    }
}
