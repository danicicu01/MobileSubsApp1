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

        //GET METHOD
        public IActionResult Create()
        {       
            return View();
        }

        //POST METHOD
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Subscription obj)
        {
            _db.Subscriptions.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
