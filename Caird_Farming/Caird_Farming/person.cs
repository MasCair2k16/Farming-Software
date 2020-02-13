using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caird_Farming
{
    class Person
    {

        // Methods
        public string name
        {
            get; set;
        }

        public string address
        {
            get; set;
        }

        public string phone
        {
            get; set;
        }

        public string role
        {
            get; set;
        }

        // Default Constructor
        public Person()
        {
            // Do nothing
        }

        // Constructor
        public Person(string name, string address, string phone, string role)
        {
            this.name = name;
            this.address = address;
            this.phone = phone;
            this.role = role;
        }

       
    }
}
