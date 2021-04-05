using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exercise3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Exercise3.Pages
{
    public class EditModel : PageModel
    {
        public EditModel(CheckoutDBContext checkcontext)
        {
            _checkOutdbcontext = checkcontext;
        }
        private readonly CheckoutDBContext _checkOutdbcontext;

        [BindProperty]
        public Customer Customer { get; set; }
        public void OnGet(int id)
        {
            Customer = _checkOutdbcontext.Customers.
                FirstOrDefault(customers => customers.CustomerId == id);
        }
        public ActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Customer cust = new Customer();
            cust = _checkOutdbcontext.Customers.FirstOrDefault(customer => customer.CustomerId == Customer.CustomerId);

            if (cust != null)
            {
                //update each field based on the submitted POST values
                cust.Name = Customer.Name;
                cust.Address = Customer.Address;
                cust.CheckIn = Customer.CheckIn;
                cust.CheckOut = Customer.CheckOut;
                cust.RoomNumber = Customer.RoomNumber;
                cust.EmailAddress = Customer.EmailAddress;
                cust.Billing = Customer.Billing;

                //update the student
                _checkOutdbcontext.Update(cust);
                //save the changes
                _checkOutdbcontext.SaveChanges();
            }
            return Redirect("Customer");

        }
    }
}
