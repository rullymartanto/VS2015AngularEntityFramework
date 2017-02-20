using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace A1.Models
{
    public class CustomerModel
    {
        public int customerNumber { get; set; }
        public string customerName { get; set; }
        public string email { get; set; }      
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string postalCode { get; set; }
        public string country { get; set; }
    }

    public class CustomerDataView
    {
        public IEnumerable<CustomerModel> CustomerProfile { get; set; }
    }
}