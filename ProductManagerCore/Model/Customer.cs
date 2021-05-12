using ProductManager.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager.Model
{
    class Customer
    {
        public int? Id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }

        public string street { get; set; }

        public string zip { get; set; }

        public string city { get; set; }

        public string state { get; set; }

        public string country { get; set; }


        public string Address {
            get
            {
                return this.street + " " + this.zip + " " + this.state
                    + " " + this.country;
            }    
        }


        public Customer(string firstname, string lastname, string street,
            string zip, string city, string state, string country)
        {
            this.firstname = firstname;
            this.lastname = lastname;
            this.street = street;
            this.zip = zip;
            this.state = state;
            this.country = country;
        }

        public Customer(ECustomer ecustomer)
        {
            this.Id = ecustomer.ID;
            this.firstname = ecustomer.firstname;
            this.lastname = ecustomer.lastname;
            this.street = ecustomer.street;
            this.zip = ecustomer.zip;
            this.state = ecustomer.State;
            this.country = ecustomer.country;
        }

        public override string ToString()
        {
            return this.firstname + " " + this.lastname +" "+ this.Address;
        }
    }
}
