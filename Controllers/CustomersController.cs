using Eden.Models;
using Eden.ViewModels;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

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
            var viewModel = new CustomerFormViewModel
            {
                Customer = new Customer(),
                MembershipTypes = membershipTypes
            };

            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel()
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };

                return View("CustomerForm", viewModel);
            }

            if (customer.Id == 0)
                _context.Customers.Add(customer);
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);

                //TryUpdateModel(customerInDb); this method of updating leaves security holes behind.

                customerInDb.Name = customer.Name;
                customerInDb.Birthday = customer.Birthday;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubcribedToNewsletter = customer.IsSubcribedToNewsletter;

                //Mapper.Map(customer, customerInDb)  this is used with AutoMapper.
            }
            _context.SaveChanges();

            return RedirectToAction("Index","Customers");
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("CustomerForm", viewModel);
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