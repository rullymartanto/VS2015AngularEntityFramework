using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace A1.Models
{
    public class CustomerEntity
    {
        public List<CustomerModel> GetAllUserProfiles()
        {
            List<CustomerModel> profiles = new List<CustomerModel>();
            using (CustomersDBEntities db = new CustomersDBEntities())
            {
                CustomerModel UPV;
                var cust = db.customers.ToList();

                foreach (customer u in db.customers)
                {
                    UPV = new CustomerModel();
                    UPV.customerName = u.customerName;
                    UPV.email = u.email;
                    UPV.address = u.address;
                    UPV.city = u.city;
                    UPV.state = u.state;
                    UPV.country = u.country;
                    UPV.postalCode = u.postalCode;
                    UPV.customerNumber = u.customerNumber;
                    profiles.Add(UPV);
                }
            }

            return profiles;
        }

        public CustomerDataView GetCustomerDataView()
        {
            CustomerDataView UDV = new CustomerDataView();
            List<CustomerModel> profiles = GetAllUserProfiles();

            UDV.CustomerProfile = profiles;
            return UDV;
        }

        public void AddCustomer(CustomerModel Cust)
        {
            using (CustomersDBEntities db = new CustomersDBEntities())
            {
                customer c = new customer();
                c.customerName = Cust.customerName;
                c.address = Cust.address;
                c.city = Cust.city;
                c.email = Cust.email;
                c.state = Cust.state;
                c.country = Cust.country;
                c.postalCode = Cust.postalCode;
                db.customers.Add(c);
                db.SaveChanges();
            }
        }

        public CustomerModel GetCustomerProfile(int custN)
        {
            CustomerModel UPV = new CustomerModel();
            using (CustomersDBEntities db = new CustomersDBEntities())
            {
                var c = db.customers.Find(custN);
                if (c != null)
                {
                    UPV.customerName = c.customerName;
                    UPV.email = c.email;
                    UPV.address = c.address;
                    UPV.city = c.city;
                    UPV.state = c.state;
                    UPV.country = c.country;
                    UPV.postalCode = c.postalCode;
                    UPV.customerNumber = c.customerNumber;
                }
            }
            return UPV;
        }

        public void UpdateCustAccount(CustomerModel CUST)
        {

            using (CustomersDBEntities db = new CustomersDBEntities())
            {
                using (var dbContextTransaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        customer c = db.customers.Find(CUST.customerNumber);
                        c.email = CUST.email;
                        c.address = CUST.address;
                        c.city = CUST.city;
                        c.state = CUST.state;
                        c.country = CUST.country;
                        c.postalCode = CUST.postalCode;
                        c.customerName = CUST.customerName;
                        db.SaveChanges();
                        dbContextTransaction.Commit();
                    }
                    catch
                    {
                        dbContextTransaction.Rollback();
                    }
                }
            }
        }

        public void DeleteCustomer(int CustNo)
        {
            using (CustomersDBEntities db = new CustomersDBEntities())
            {
                using (var dbContextTransaction = db.Database.BeginTransaction())
                {
                    try
                    {

                        var SUR = db.customers.Where(o => o.customerNumber == CustNo);
                        if (SUR.Any())
                        {
                            db.customers.Remove(SUR.FirstOrDefault());
                            db.SaveChanges();
                        }

                        dbContextTransaction.Commit();
                    }
                    catch
                    {
                        dbContextTransaction.Rollback();
                    }
                }
            }
        }

    }
}