using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Eden.Models;

namespace Eden.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ViewResult Index()
        {

            var customers = GetCustomers();

            return View(customers);
        }

        [Route("Customers/Details/{Id}")]
        public ActionResult Details(int Id)
        {
            var customer = GetCustomers().SingleOrDefault(c => c.Id == Id);  // ???

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

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
    }
}