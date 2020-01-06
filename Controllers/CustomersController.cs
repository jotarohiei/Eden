using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Eden.Models;
using System.Data.Entity;
using Eden.ViewModels;

namespace Eden.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext(); //initialization ; _context is a disposable object
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ViewResult Index()
        {

            var customers = _context.Customers.Include(c => c.MembershipType).ToList();  // the .Customers method is a Db Set defined in hte Db Context. This is a defered exectution, not an actual query.

            return View(customers);
        }

        [Route("Customers/Details/{Id}")]
        public ActionResult Details(int Id)
        {
            var customer = _context.Customers.Include(m => m.MembershipType).ToList().SingleOrDefault(c => c.Id == Id);  // ???

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new NewCustomerViewModel
            {
                MembershipTypes = membershipTypes
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();

            return RedirectToAction("Index","Customers");
        }

        /* Hardcoding data entries :
        private IEnumerable<Customer> GetCustomers()  // must study IEnumerables further, but this basically assigns a list of customers 
                                                      // to GetCustomers() . 
        {
            return new List<Customer>
            {
                new Customer { Id = 1, Name = "John Smith" },
                new Customer { Id = 2, Name = "Mary Williams" },
                new Customer { Id = 3, Name = "Blaire Hathaway"}
            };
        }
        */

    }
}