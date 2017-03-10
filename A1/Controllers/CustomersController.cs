using A1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace A1.Controllers
{
    public class CustomersController : ApiController
    {
        CustomerEntity UM = new CustomerEntity();
        // GET: api/Customers
        public IEnumerable<CustomerModel> Get()
        {
            CustomerDataView UDV = UM.GetCustomerDataView();
            return UDV.CustomerProfile;
        }

        // GET: api/Customers/5
        public CustomerModel Get(int id)
        {
            CustomerModel UDV = null;

            if (id != 0)
            {
                CustomerModel cs = UM.GetCustomerProfile(id);
                UDV = cs;
            }
            return UDV;
        }

        // POST: api/Customers
        public void Post(CustomerModel c)
        {
            CustomerModel UPV = new CustomerModel();
            CustomerModel cs = UM.GetCustomerProfile(c.customerNumber);

            if (cs.customerNumber == 0)
            {
                UM.AddCustomer(c);
            }
            else
            {
                UM.UpdateCustAccount(c);
            }
        }

        
        // PUT: api/Customers/5
        public void Put(int id, CustomerModel c)
        {
            CustomerModel UPV = new CustomerModel();
            CustomerModel cs = UM.GetCustomerProfile(id);
            UM.UpdateCustAccount(c);
        }

        // DELETE: api/Customers/5
        public void Delete(int id)
        {
            CustomerModel cs = UM.GetCustomerProfile(id);
            UM.DeleteCustomer(id);
        }
    }
}
