using ITI_ITI.DbContexts;
using ITI_ITI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ITI_ITI.Controllers
{
    public class CustomersController : Controller
    {
        ApplicationDbContext _context;
        public CustomersController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult GetIndexView(string? search, int ResId, string? sortType, string? sortOrder)
        {
            var customers = _context.customers.AsQueryable();
            if (search != null)
            {
                customers = customers.Where(e => e.FullName.Contains(search));
            }
            ViewBag.CurrentSearch = search;
            if (ResId != 0)
            {
                customers = customers.Where(e => e.MyRestaurantId == ResId);
            }
            ViewBag.CurrentResId = ResId;
            ViewBag.AllRestaurants = _context.MyRestaurants;

            if (sortType != null && sortOrder != null)
            {
                if (sortType == "FullName")
                {
                    if (sortOrder == "asc")
                        customers = customers.OrderBy(e => e.FullName);
                    else if (sortOrder == "desc")
                        customers = customers.OrderByDescending(e => e.FullName);
                }
               
            }
            return View("Index", customers.ToList());
        }

        [HttpGet]
        public ActionResult GetDetailsView(int id)
        {
            Customer customer = _context.customers.Include(e => e.MyRestaurant).FirstOrDefault(e => e.Id == id);
            
            if (customer == null)
                return NotFound();
            else
                return View("Details", customer);
        }


        public ActionResult GetIndexView()
        {
            var Customer = _context.customers.ToList();
            return View("Index", Customer);
        }
        public ActionResult GetCreateView()
        {
            ViewBag.AllRestaurants = _context.MyRestaurants.ToList();
            return View("Create");
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult CreateCustomer([Bind("FullName,PhoneNumber,Description,MyRestaurantId")] Customer m)
        {
            if (m != null && _context.customers.Any(e => e.PhoneNumber == m.PhoneNumber))
            {
                ModelState.AddModelError(string.Empty, "This Phone number is registered to another employee.");
            }
            if (ModelState.IsValid == true)
            {
                _context.customers.Add(m);
                _context.SaveChanges();

                return RedirectToAction("GetIndexView");
            }
            else
            {
                ViewBag.AllRestaurants = _context.MyRestaurants;

                return View("create");
            }
        }
        [HttpGet]
        public ActionResult GetEditView(int id)
        {
            Customer customer = _context.customers.FirstOrDefault(e => e.Id == id);
            if (customer == null)
                return NotFound();
            else
            {
                ViewBag.AllRestaurants = _context.MyRestaurants;
                return View("Edit", customer);
            }
        }
        [ValidateAntiForgeryToken]
        [HttpPost]

        public ActionResult EditCustomer([Bind("Id,FullName,Description,PhoneNumber,MyRestaurantId")] Customer m)
        {


            if (m != null && _context.customers.Any(e => e.PhoneNumber == m.PhoneNumber
            && e.Id != m.Id))
            {
                ModelState.AddModelError(string.Empty, "This phone number is registered to another customer.");
            }
            if (ModelState.IsValid == true)
            {
                _context.customers.Update(m);
                _context.SaveChanges();

                return RedirectToAction("GetIndexView");
            }
            else
            {
                ViewBag.AllRestaurants = _context.MyRestaurants;
                return View("Edit");
            }
        }

        [HttpGet]
        public ActionResult GetDeleteView(int id)
        {
            Customer customer = _context.customers.Include(e => e.MyRestaurant).FirstOrDefault(e => e.Id == id);
            if (customer == null)
                return NotFound();
            else
                return View("Delete", customer);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult DeleteCustomer(int id)
        {
            Customer customer = _context.customers.FirstOrDefault(e => e.Id == id);

            _context.customers.Remove(customer);
            _context.SaveChanges();
            return RedirectToAction("GetIndexView");
        }

    }
}
