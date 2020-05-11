using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ActionResult Index()
        {

            var customer = GetCustomers();
            

            return View(customer);
        }

        public ActionResult Details(int id)
        {

            var customer = GetCustomers().SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);

           
            
        }




        private IEnumerable<Customer> GetCustomers()
        {


            return new List<Customer>

            {
                new Customer{Name="Jhon Smith",Id=1},
                new Customer{Name="Mary William",Id=2}

            };
        }









    }
}