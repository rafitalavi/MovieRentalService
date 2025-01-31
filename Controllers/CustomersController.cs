using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;  // Add this for Include method
using MovieWala.Data;
using MovieWala.Models;

public class CustomersController : Controller
{//ForbidResult reading Data from dtabase
    private readonly MovieWalaContext _context;

    // Constructor injection 
    public CustomersController(MovieWalaContext context)
    {
        _context = context;
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
