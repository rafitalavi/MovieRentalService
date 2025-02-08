using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;  // Add this for Include method
using MovieWala.Data;
using MovieWala.Models;
using MovieWala.ViewModels;

public class CustomersController : Controller
{//ForbidResult reading Data from dtabase
    private readonly MovieWalaContext _context;

    // Constructor injection 
    public CustomersController(MovieWalaContext context)
    {
        _context = context;
    }
    public ActionResult New()
    {    var membershipTypes =_context.MembershipTypes.ToList();
        var viewModel = new CustomerFormViewModel
        { MembershipTypes = membershipTypes };
        return View("CustomerForm",viewModel);
    }
    [HttpPost]
    public ActionResult Save(Customer customer) {
        if (!ModelState.IsValid)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            foreach (var error in errors)
            {
                Console.WriteLine(error.ErrorMessage);  // Log validation errors
            }
        }
        if (customer.Id == 0)
            _context.Customers.Add(customer);
        else {
            var customerIndb = _context.Customers.Single(c => c.Id == customer.Id);
            customerIndb.Name = customer.Name;
            customerIndb.Birthday = customer.Birthday;
            customerIndb.MembershipType = customer.MembershipType;
            customerIndb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
        }


        _context.SaveChanges();
        return RedirectToAction("Index", "Customers");
  }
    public ViewResult Index()
    {
        // Ensure Include is properly recognized
        var customers = _context.Customers.Include(c => c.MembershipType).ToList();
        return View(customers);
    }
    public ActionResult Edit(int id)
    {
        var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
        if (customer == null)
            return NotFound();
        var viewModel = new CustomerFormViewModel
        { Customer = customer,
        MembershipTypes = _context.MembershipTypes.ToList()};
        return View("CustomerForm", viewModel);
    }
    public ActionResult Details(int id)
    {
        var customer = _context.Customers.Include(c => c.MembershipType)
                                         .SingleOrDefault(c => c.Id == id);
        if (customer == null)
            return NotFound();

        return View(customer);
    }
}
