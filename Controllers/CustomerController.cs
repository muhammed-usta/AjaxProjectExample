using AjaxProjectExample.Context;
using AjaxProjectExample.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AjaxProjectExample.Controllers
{
    public class CustomerController : Controller
    {
        private readonly CustomerContext _context;

        public CustomerController(CustomerContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CustomerList()
        {
           var values=_context.Customers.ToList();
            var jsonValues=JsonConvert.SerializeObject(values);
            return Json(jsonValues);
        }


        public IActionResult CreateCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
            var values = JsonConvert.SerializeObject(customer);
            return Json(values);
        }

        public IActionResult DeleteCustomer(int id)
        {
            var value = _context.Customers.Find(id);
            _context.Customers.Remove(value);
            _context.SaveChanges();
            return NoContent();
        }

        public IActionResult GetCustomer(int id)
        {
            var value= _context.Customers.Find(id);
            var jsonValues=JsonConvert.SerializeObject(value);
            return Json(jsonValues);
        }

        public IActionResult UpdateCustomer(Customer customer)
        {
            _context.Customers.Update(customer);
            _context.SaveChanges();
            return NoContent();
        }

    }
}
