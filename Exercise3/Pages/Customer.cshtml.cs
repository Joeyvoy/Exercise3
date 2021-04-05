using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exercise3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Exercise3.Pages
{
    public class CustomerModel : PageModel
    {
        public CustomerModel(CheckoutDBContext checkcontext)
        {
            _checkOutdbcontext = checkcontext;
        }
        private readonly CheckoutDBContext _checkOutdbcontext;
        [BindProperty]
        public Customer Customer { get; set; }

        public List<Customer> Customers = new List<Customer>();

        public void OnGet()
        {
            Customers = _checkOutdbcontext.Customers.ToList();
        }
        public ActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                Customers = _checkOutdbcontext.Customers.ToList();
                return Page();
            }
            _checkOutdbcontext.Customers.Add(Customer);
            _checkOutdbcontext.SaveChanges();
            return Redirect("/customer");
        }
        public void OnGetDelete(int id)
        {
            
            var cust = _checkOutdbcontext.Customers
                .FirstOrDefault(c => c.CustomerId == id);

            
            if (cust != null)
            {
                
                _checkOutdbcontext.Customers.Remove(cust);
                _checkOutdbcontext.SaveChanges();
            }


                
            OnGet();

        }

    }
}
