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
        var viewModel = new NewCustomerViewModel
        { MembershipTypes = membershipTypes };
        return View(viewModel);
    }
    [HttpPost]
    public ActionResult Create(Customer customer) {
        if (!ModelState.IsValid)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            foreach (var error in errors)
            {
                Console.WriteLine(error.ErrorMessage);  // Log validation errors
            }
        }

        _context.Customers.Add(customer);
        _context.SaveChanges();
        return RedirectToAction("Index", "Customers");
  }
    public ViewResult Index()
    {
        // Ensure Include is properly recognized
        var customers = _context.Customers.Include(c => c.MembershipType).ToList();
        return View(customers);
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
